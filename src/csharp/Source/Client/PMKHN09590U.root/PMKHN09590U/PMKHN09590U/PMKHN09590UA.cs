//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���[�����ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/05/24  �C�����e : �V�K�쐬
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
using Broadleaf.Library.Net.Mail;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�����ݒ�}�X�^�����e�i���X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���[�����M�Ǘ��ݒ���s���܂�
    ///					: IMasterMaintenanceSingleType���������Ă��܂�</br>
    /// <br>Programer	: �����</br>
    /// <br>Date		: 2010/05/24</br>
    /// <br></br>
    /// <br>Update Note : 2010/07/01 30517 �Ė� �x��</br>
    /// <br>              Mantis.15717�@���_�R�[�h���ꌅ�̏ꍇ0�l�߂��ĕۑ�����l�ɕύX</br>
    /// </remarks>
    public class PMKHN09590UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel MailAddress_Label;
        private Infragistics.Win.Misc.UltraLabel Pop3UserId_Label;
        private Infragistics.Win.Misc.UltraLabel Pop3Password_Label;
        private Infragistics.Win.Misc.UltraLabel Pop3ServerName_Label;
        private Infragistics.Win.Misc.UltraLabel SmtpServerName_Label;
        private Infragistics.Win.Misc.UltraLabel SenderName_Label;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraButton Close_Button;
        private Broadleaf.Library.Windows.Forms.TEdit MailAddress_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit Pop3UserId_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit Pop3Password_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit Pop3ServerName_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SmtpServerName_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit SenderName_tEdit;
        private System.Windows.Forms.Timer timer1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TEdit SmtpUserId_tEdit;
        private TEdit SmtpPassword_tEdit;
        private Infragistics.Win.Misc.UltraLabel SmtpPassword_Label;
        private Infragistics.Win.Misc.UltraLabel SmtpUserId_Label;
        private Infragistics.Win.Misc.UltraLabel MailServerTimeoutVal_Label;
        private Infragistics.Win.Misc.UltraLabel PopServerPortNo_Label;
        private Infragistics.Win.Misc.UltraLabel SmtpServerPortNo_Label;
        private TNedit MailServerTimeoutVal_tNedit;
        private TNedit SmtpServerPortNo_tNedit;
        private TNedit PopServerPortNo_tNedit;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor SmtpAuthUseDiv_ultraCheckEditor;
        private RadioButton SmtpAuthUseDiv1_radioButton;
        private RadioButton PopBeforeSmtpUseDiv_radioButton;
        private RadioButton SmtpAuthUseDiv2_radioButton;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private DataSet Bind_DataSet;
        private Infragistics.Win.Misc.UltraLabel SelectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TEdit SectionName_tEdit;
        private TEdit MailSaveBeforeFolder_tEdit;
        private Infragistics.Win.Misc.UltraLabel MailSaveBeforeFolder_Label;
        private Infragistics.Win.Misc.UltraButton SaveFolder_Button;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Check_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private System.ComponentModel.IContainer components;
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// PMKHN09590U�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���[�����M�Ǘ��ݒ�R���X�g���N�^�ł�</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// </remarks>
        public PMKHN09590UA()
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

            // mailSndMng�N���X
            this._mailInfoSetting = new MailInfoSetting();
            // mailSndMng�N���X�A�N�Z�X�N���X
            this._mailInfoSettingAcs = new MailInfoSettingAcs();

            this._mailInfoSettingTable = new Hashtable();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ����\�t���O��ݒ肵�܂��B
            // Frame�̈���{�^���̕\����\���̐���Ɏg�p���܂��B
            this._canPrint = false;

            this._indexBuf = -2;

            this._preSectionCode = string.Empty;
            this._preSectionName = string.Empty;
        }
        #endregion

        #region Private Member
        /// <summary>
        /// �O���[�o���ϐ��E�萔�錾
        /// </summary>
        private MailInfoSetting _mailInfoSetting;
        private MailInfoSettingAcs _mailInfoSettingAcs;
        private MailInfoSetting _mailInfoSettingClone; // �f�[�^��r�p        
        private string _enterpriseCode;

        //HashTable
        private Hashtable _mailInfoSettingTable;
        private string _preSectionCode;
        private string _preSectionName;

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

        private const string ASSEMBLY_ID = "PMKHN09590U";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";
        private const string VIEW_SECTIONCODE = "���_�R�[�h";
        private const string VIEW_SECTIONNAME = "���_";
        private const string VIEW_SENDERNAME = "���o�l��";
        private const string VIEW_MAILADDRESS = "���[���A�h���X";
        private const string VIEW_POP3USERID = "POP3���[�U�[ID";
        private const string VIEW_POP3PASSWORD = "POP3�p�X���[�h";
        private const string VIEW_POP3SERVERNAME = "POP3�T�[�o�[��";
        private const string VIEW_SMTPSERVERNAME = "SMTP�T�[�o�[��";
        private const string VIEW_SMTPAUTHUSEDIV = "���M�T�[�o�[(SMTP)�F��";
        private const string VIEW_SMTPUSERID = "SMTP���[�U�[ID";
        private const string VIEW_SMTPPASSWORD = "SMTP�p�X���[�h";
        private const string VIEW_POPBEFORESMTPUSEDIV = "��M���[���T�[�o�[�Ƀ��O�I��";
        private const string VIEW_POPSERVERPORTNO = "POP�T�[�o�[ �|�[�g�ԍ�";
        private const string VIEW_SMTPSERVERPORTNO = "SMTP�T�[�o�[ �|�[�g�ԍ�";
        private const string VIEW_MAILSERVERTIMEOUTVAL = "���[���T�[�o�[�^�C���A�E�g";
        private const string VIEW_MAILSAVEBEFOREFOLDER = "���[���ۑ���t�H���_";

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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            this.MailAddress_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3UserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3Password_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3ServerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpServerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SenderName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.MailAddress_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Pop3UserId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Pop3Password_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Pop3ServerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SmtpServerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SenderName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SmtpUserId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SmtpPassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SmtpPassword_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpUserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MailServerTimeoutVal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PopServerPortNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpServerPortNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PopServerPortNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SmtpServerPortNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MailServerTimeoutVal_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SmtpAuthUseDiv_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.SmtpAuthUseDiv1_radioButton = new System.Windows.Forms.RadioButton();
            this.SmtpAuthUseDiv2_radioButton = new System.Windows.Forms.RadioButton();
            this.PopBeforeSmtpUseDiv_radioButton = new System.Windows.Forms.RadioButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.SelectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MailSaveBeforeFolder_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MailSaveBeforeFolder_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SaveFolder_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Check_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.MailAddress_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3UserId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3Password_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3ServerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpServerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SenderName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpUserId_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpPassword_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopServerPortNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpServerPortNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailServerTimeoutVal_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailSaveBeforeFolder_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // MailAddress_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.MailAddress_Label.Appearance = appearance1;
            this.MailAddress_Label.Location = new System.Drawing.Point(65, 105);
            this.MailAddress_Label.Name = "MailAddress_Label";
            this.MailAddress_Label.Size = new System.Drawing.Size(135, 23);
            this.MailAddress_Label.TabIndex = 7;
            this.MailAddress_Label.Tag = "8";
            this.MailAddress_Label.Text = "���[���A�h���X";
            // 
            // Pop3UserId_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.Pop3UserId_Label.Appearance = appearance2;
            this.Pop3UserId_Label.Location = new System.Drawing.Point(65, 140);
            this.Pop3UserId_Label.Name = "Pop3UserId_Label";
            this.Pop3UserId_Label.Size = new System.Drawing.Size(135, 23);
            this.Pop3UserId_Label.TabIndex = 13;
            this.Pop3UserId_Label.Tag = "13";
            this.Pop3UserId_Label.Text = "POP3���[�U�[ID";
            // 
            // Pop3Password_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.Pop3Password_Label.Appearance = appearance3;
            this.Pop3Password_Label.Location = new System.Drawing.Point(65, 175);
            this.Pop3Password_Label.Name = "Pop3Password_Label";
            this.Pop3Password_Label.Size = new System.Drawing.Size(135, 23);
            this.Pop3Password_Label.TabIndex = 14;
            this.Pop3Password_Label.Tag = "14";
            this.Pop3Password_Label.Text = "POP3�p�X���[�h";
            // 
            // Pop3ServerName_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Pop3ServerName_Label.Appearance = appearance4;
            this.Pop3ServerName_Label.Location = new System.Drawing.Point(65, 210);
            this.Pop3ServerName_Label.Name = "Pop3ServerName_Label";
            this.Pop3ServerName_Label.Size = new System.Drawing.Size(135, 23);
            this.Pop3ServerName_Label.TabIndex = 15;
            this.Pop3ServerName_Label.Tag = "15";
            this.Pop3ServerName_Label.Text = "POP3�T�[�o�[��";
            // 
            // SmtpServerName_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.SmtpServerName_Label.Appearance = appearance5;
            this.SmtpServerName_Label.Location = new System.Drawing.Point(65, 245);
            this.SmtpServerName_Label.Name = "SmtpServerName_Label";
            this.SmtpServerName_Label.Size = new System.Drawing.Size(135, 23);
            this.SmtpServerName_Label.TabIndex = 16;
            this.SmtpServerName_Label.Tag = "16";
            this.SmtpServerName_Label.Text = "SMTP�T�[�o�[��";
            // 
            // SenderName_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.SenderName_Label.Appearance = appearance6;
            this.SenderName_Label.Location = new System.Drawing.Point(65, 70);
            this.SenderName_Label.Name = "SenderName_Label";
            this.SenderName_Label.Size = new System.Drawing.Size(135, 23);
            this.SenderName_Label.TabIndex = 17;
            this.SenderName_Label.Tag = "17";
            this.SenderName_Label.Text = "���o�l��";
            // 
            // Mode_Label
            // 
            appearance7.ForeColor = System.Drawing.Color.White;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance7;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label.Location = new System.Drawing.Point(685, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 18;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 660);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(816, 23);
            this.ultraStatusBar1.TabIndex = 21;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Close_Button
            // 
            this.Close_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Close_Button.Location = new System.Drawing.Point(670, 620);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(125, 34);
            this.Close_Button.TabIndex = 24;
            this.Close_Button.Text = "����(&X)";
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // MailAddress_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Left";
            this.MailAddress_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Left";
            this.MailAddress_tEdit.Appearance = appearance9;
            this.MailAddress_tEdit.AutoSelect = true;
            this.MailAddress_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MailAddress_tEdit.DataText = "";
            this.MailAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.MailAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MailAddress_tEdit.Location = new System.Drawing.Point(210, 105);
            this.MailAddress_tEdit.MaxLength = 64;
            this.MailAddress_tEdit.Name = "MailAddress_tEdit";
            this.MailAddress_tEdit.Size = new System.Drawing.Size(528, 24);
            this.MailAddress_tEdit.TabIndex = 4;
            // 
            // Pop3UserId_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlignAsString = "Left";
            this.Pop3UserId_tEdit.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Left";
            this.Pop3UserId_tEdit.Appearance = appearance11;
            this.Pop3UserId_tEdit.AutoSelect = true;
            this.Pop3UserId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Pop3UserId_tEdit.DataText = "";
            this.Pop3UserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3UserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.Pop3UserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3UserId_tEdit.Location = new System.Drawing.Point(210, 140);
            this.Pop3UserId_tEdit.MaxLength = 64;
            this.Pop3UserId_tEdit.Name = "Pop3UserId_tEdit";
            this.Pop3UserId_tEdit.Size = new System.Drawing.Size(528, 24);
            this.Pop3UserId_tEdit.TabIndex = 5;
            // 
            // Pop3Password_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.TextHAlignAsString = "Left";
            this.Pop3Password_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Left";
            this.Pop3Password_tEdit.Appearance = appearance13;
            this.Pop3Password_tEdit.AutoSelect = true;
            this.Pop3Password_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Pop3Password_tEdit.DataText = "";
            this.Pop3Password_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3Password_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.Pop3Password_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3Password_tEdit.Location = new System.Drawing.Point(210, 175);
            this.Pop3Password_tEdit.MaxLength = 24;
            this.Pop3Password_tEdit.Name = "Pop3Password_tEdit";
            this.Pop3Password_tEdit.PasswordChar = '*';
            this.Pop3Password_tEdit.Size = new System.Drawing.Size(203, 24);
            this.Pop3Password_tEdit.TabIndex = 6;
            // 
            // Pop3ServerName_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance14.TextHAlignAsString = "Left";
            this.Pop3ServerName_tEdit.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Left";
            this.Pop3ServerName_tEdit.Appearance = appearance15;
            this.Pop3ServerName_tEdit.AutoSelect = true;
            this.Pop3ServerName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Pop3ServerName_tEdit.DataText = "";
            this.Pop3ServerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3ServerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.Pop3ServerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3ServerName_tEdit.Location = new System.Drawing.Point(210, 210);
            this.Pop3ServerName_tEdit.MaxLength = 64;
            this.Pop3ServerName_tEdit.Name = "Pop3ServerName_tEdit";
            this.Pop3ServerName_tEdit.Size = new System.Drawing.Size(528, 24);
            this.Pop3ServerName_tEdit.TabIndex = 7;
            // 
            // SmtpServerName_tEdit
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance50.TextHAlignAsString = "Left";
            this.SmtpServerName_tEdit.ActiveAppearance = appearance50;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance51.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextHAlignAsString = "Left";
            this.SmtpServerName_tEdit.Appearance = appearance51;
            this.SmtpServerName_tEdit.AutoSelect = true;
            this.SmtpServerName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SmtpServerName_tEdit.DataText = "";
            this.SmtpServerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpServerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.SmtpServerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpServerName_tEdit.Location = new System.Drawing.Point(210, 245);
            this.SmtpServerName_tEdit.MaxLength = 64;
            this.SmtpServerName_tEdit.Name = "SmtpServerName_tEdit";
            this.SmtpServerName_tEdit.Size = new System.Drawing.Size(528, 24);
            this.SmtpServerName_tEdit.TabIndex = 8;
            // 
            // SenderName_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.TextHAlignAsString = "Left";
            this.SenderName_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Left";
            this.SenderName_tEdit.Appearance = appearance19;
            this.SenderName_tEdit.AutoSelect = true;
            this.SenderName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SenderName_tEdit.DataText = "";
            this.SenderName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SenderName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SenderName_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SenderName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SenderName_tEdit.Location = new System.Drawing.Point(210, 70);
            this.SenderName_tEdit.MaxLength = 32;
            this.SenderName_tEdit.Name = "SenderName_tEdit";
            this.SenderName_tEdit.Size = new System.Drawing.Size(528, 24);
            this.SenderName_tEdit.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SmtpUserId_tEdit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.TextHAlignAsString = "Left";
            this.SmtpUserId_tEdit.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextHAlignAsString = "Left";
            this.SmtpUserId_tEdit.Appearance = appearance45;
            this.SmtpUserId_tEdit.AutoSelect = true;
            this.SmtpUserId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SmtpUserId_tEdit.DataText = "";
            this.SmtpUserId_tEdit.Enabled = false;
            this.SmtpUserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpUserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.SmtpUserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpUserId_tEdit.Location = new System.Drawing.Point(210, 380);
            this.SmtpUserId_tEdit.MaxLength = 64;
            this.SmtpUserId_tEdit.Name = "SmtpUserId_tEdit";
            this.SmtpUserId_tEdit.Size = new System.Drawing.Size(528, 24);
            this.SmtpUserId_tEdit.TabIndex = 12;
            // 
            // SmtpPassword_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.TextHAlignAsString = "Left";
            this.SmtpPassword_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Left";
            this.SmtpPassword_tEdit.Appearance = appearance47;
            this.SmtpPassword_tEdit.AutoSelect = true;
            this.SmtpPassword_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SmtpPassword_tEdit.DataText = "";
            this.SmtpPassword_tEdit.Enabled = false;
            this.SmtpPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.SmtpPassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpPassword_tEdit.Location = new System.Drawing.Point(210, 415);
            this.SmtpPassword_tEdit.MaxLength = 24;
            this.SmtpPassword_tEdit.Name = "SmtpPassword_tEdit";
            this.SmtpPassword_tEdit.PasswordChar = '*';
            this.SmtpPassword_tEdit.Size = new System.Drawing.Size(203, 24);
            this.SmtpPassword_tEdit.TabIndex = 13;
            // 
            // SmtpPassword_Label
            // 
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            appearance48.TextVAlignAsString = "Middle";
            this.SmtpPassword_Label.Appearance = appearance48;
            this.SmtpPassword_Label.Enabled = false;
            this.SmtpPassword_Label.Location = new System.Drawing.Point(65, 415);
            this.SmtpPassword_Label.Name = "SmtpPassword_Label";
            this.SmtpPassword_Label.Size = new System.Drawing.Size(135, 23);
            this.SmtpPassword_Label.TabIndex = 27;
            this.SmtpPassword_Label.Tag = "14";
            this.SmtpPassword_Label.Text = "SMTP�p�X���[�h";
            // 
            // SmtpUserId_Label
            // 
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.SmtpUserId_Label.Appearance = appearance49;
            this.SmtpUserId_Label.Enabled = false;
            this.SmtpUserId_Label.Location = new System.Drawing.Point(65, 380);
            this.SmtpUserId_Label.Name = "SmtpUserId_Label";
            this.SmtpUserId_Label.Size = new System.Drawing.Size(135, 23);
            this.SmtpUserId_Label.TabIndex = 25;
            this.SmtpUserId_Label.Tag = "13";
            this.SmtpUserId_Label.Text = "SMTP���[�U�[ID";
            // 
            // MailServerTimeoutVal_Label
            // 
            appearance41.TextVAlignAsString = "Middle";
            this.MailServerTimeoutVal_Label.Appearance = appearance41;
            this.MailServerTimeoutVal_Label.Location = new System.Drawing.Point(402, 491);
            this.MailServerTimeoutVal_Label.Name = "MailServerTimeoutVal_Label";
            this.MailServerTimeoutVal_Label.Size = new System.Drawing.Size(210, 23);
            this.MailServerTimeoutVal_Label.TabIndex = 35;
            this.MailServerTimeoutVal_Label.Tag = "16";
            this.MailServerTimeoutVal_Label.Text = "���[���T�[�o�[�^�C���A�E�g";
            // 
            // PopServerPortNo_Label
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.PopServerPortNo_Label.Appearance = appearance42;
            this.PopServerPortNo_Label.Location = new System.Drawing.Point(65, 490);
            this.PopServerPortNo_Label.Name = "PopServerPortNo_Label";
            this.PopServerPortNo_Label.Size = new System.Drawing.Size(210, 23);
            this.PopServerPortNo_Label.TabIndex = 34;
            this.PopServerPortNo_Label.Tag = "14";
            this.PopServerPortNo_Label.Text = "POP�T�[�o�[ �|�[�g�ԍ�";
            // 
            // SmtpServerPortNo_Label
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.SmtpServerPortNo_Label.Appearance = appearance52;
            this.SmtpServerPortNo_Label.Location = new System.Drawing.Point(65, 525);
            this.SmtpServerPortNo_Label.Name = "SmtpServerPortNo_Label";
            this.SmtpServerPortNo_Label.Size = new System.Drawing.Size(210, 23);
            this.SmtpServerPortNo_Label.TabIndex = 32;
            this.SmtpServerPortNo_Label.Tag = "16";
            this.SmtpServerPortNo_Label.Text = "SMTP�T�[�o�[ �|�[�g�ԍ�";
            // 
            // PopServerPortNo_tNedit
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance37.TextHAlignAsString = "Right";
            this.PopServerPortNo_tNedit.ActiveAppearance = appearance37;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Right";
            this.PopServerPortNo_tNedit.Appearance = appearance38;
            this.PopServerPortNo_tNedit.AutoSelect = true;
            this.PopServerPortNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PopServerPortNo_tNedit.DataText = "";
            this.PopServerPortNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PopServerPortNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.PopServerPortNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.PopServerPortNo_tNedit.Location = new System.Drawing.Point(285, 490);
            this.PopServerPortNo_tNedit.MaxLength = 4;
            this.PopServerPortNo_tNedit.Name = "PopServerPortNo_tNedit";
            this.PopServerPortNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PopServerPortNo_tNedit.Size = new System.Drawing.Size(44, 24);
            this.PopServerPortNo_tNedit.TabIndex = 15;
            // 
            // SmtpServerPortNo_tNedit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.TextHAlignAsString = "Right";
            this.SmtpServerPortNo_tNedit.ActiveAppearance = appearance40;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            appearance36.TextHAlignAsString = "Right";
            this.SmtpServerPortNo_tNedit.Appearance = appearance36;
            this.SmtpServerPortNo_tNedit.AutoSelect = true;
            this.SmtpServerPortNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SmtpServerPortNo_tNedit.DataText = "";
            this.SmtpServerPortNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpServerPortNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SmtpServerPortNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SmtpServerPortNo_tNedit.Location = new System.Drawing.Point(285, 525);
            this.SmtpServerPortNo_tNedit.MaxLength = 4;
            this.SmtpServerPortNo_tNedit.Name = "SmtpServerPortNo_tNedit";
            this.SmtpServerPortNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SmtpServerPortNo_tNedit.Size = new System.Drawing.Size(44, 24);
            this.SmtpServerPortNo_tNedit.TabIndex = 17;
            // 
            // MailServerTimeoutVal_tNedit
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance33.TextHAlignAsString = "Right";
            this.MailServerTimeoutVal_tNedit.ActiveAppearance = appearance33;
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Right";
            this.MailServerTimeoutVal_tNedit.Appearance = appearance34;
            this.MailServerTimeoutVal_tNedit.AutoSelect = true;
            this.MailServerTimeoutVal_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MailServerTimeoutVal_tNedit.DataText = "";
            this.MailServerTimeoutVal_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailServerTimeoutVal_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.MailServerTimeoutVal_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MailServerTimeoutVal_tNedit.Location = new System.Drawing.Point(622, 491);
            this.MailServerTimeoutVal_tNedit.MaxLength = 4;
            this.MailServerTimeoutVal_tNedit.Name = "MailServerTimeoutVal_tNedit";
            this.MailServerTimeoutVal_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MailServerTimeoutVal_tNedit.Size = new System.Drawing.Size(44, 24);
            this.MailServerTimeoutVal_tNedit.TabIndex = 16;
            // 
            // SmtpAuthUseDiv_ultraCheckEditor
            // 
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.SmtpAuthUseDiv_ultraCheckEditor.Appearance = appearance32;
            this.SmtpAuthUseDiv_ultraCheckEditor.Location = new System.Drawing.Point(25, 290);
            this.SmtpAuthUseDiv_ultraCheckEditor.Name = "SmtpAuthUseDiv_ultraCheckEditor";
            this.SmtpAuthUseDiv_ultraCheckEditor.Size = new System.Drawing.Size(260, 20);
            this.SmtpAuthUseDiv_ultraCheckEditor.TabIndex = 9;
            this.SmtpAuthUseDiv_ultraCheckEditor.Text = "���M�T�[�o�[(SMTP)�͔F�؂��K�v";
            this.SmtpAuthUseDiv_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.SmtpAuthUseDiv_ultraCheckEditor_CheckedChanged);
            // 
            // SmtpAuthUseDiv1_radioButton
            // 
            this.SmtpAuthUseDiv1_radioButton.AutoSize = true;
            this.SmtpAuthUseDiv1_radioButton.Checked = true;
            this.SmtpAuthUseDiv1_radioButton.Enabled = false;
            this.SmtpAuthUseDiv1_radioButton.Location = new System.Drawing.Point(45, 320);
            this.SmtpAuthUseDiv1_radioButton.Name = "SmtpAuthUseDiv1_radioButton";
            this.SmtpAuthUseDiv1_radioButton.Size = new System.Drawing.Size(329, 19);
            this.SmtpAuthUseDiv1_radioButton.TabIndex = 10;
            this.SmtpAuthUseDiv1_radioButton.TabStop = true;
            this.SmtpAuthUseDiv1_radioButton.Text = "��M���[���T�[�o�[�Ɠ����ݒ���g�p����";
            this.SmtpAuthUseDiv1_radioButton.UseVisualStyleBackColor = true;
            this.SmtpAuthUseDiv1_radioButton.CheckedChanged += new System.EventHandler(this.SmtpAuthUseDiv1_radioButton_CheckedChanged);
            // 
            // SmtpAuthUseDiv2_radioButton
            // 
            this.SmtpAuthUseDiv2_radioButton.AutoSize = true;
            this.SmtpAuthUseDiv2_radioButton.Enabled = false;
            this.SmtpAuthUseDiv2_radioButton.Location = new System.Drawing.Point(45, 350);
            this.SmtpAuthUseDiv2_radioButton.Name = "SmtpAuthUseDiv2_radioButton";
            this.SmtpAuthUseDiv2_radioButton.Size = new System.Drawing.Size(345, 19);
            this.SmtpAuthUseDiv2_radioButton.TabIndex = 11;
            this.SmtpAuthUseDiv2_radioButton.Text = "���̃A�J�E���g�ƃp�X���[�h�Ń��O�I������";
            this.SmtpAuthUseDiv2_radioButton.UseVisualStyleBackColor = true;
            this.SmtpAuthUseDiv2_radioButton.CheckedChanged += new System.EventHandler(this.SmtpAuthUseDiv2_radioButton_CheckedChanged);
            // 
            // PopBeforeSmtpUseDiv_radioButton
            // 
            this.PopBeforeSmtpUseDiv_radioButton.AutoSize = true;
            this.PopBeforeSmtpUseDiv_radioButton.Enabled = false;
            this.PopBeforeSmtpUseDiv_radioButton.Location = new System.Drawing.Point(45, 450);
            this.PopBeforeSmtpUseDiv_radioButton.Name = "PopBeforeSmtpUseDiv_radioButton";
            this.PopBeforeSmtpUseDiv_radioButton.Size = new System.Drawing.Size(281, 19);
            this.PopBeforeSmtpUseDiv_radioButton.TabIndex = 14;
            this.PopBeforeSmtpUseDiv_radioButton.Text = "��M���[���T�[�o�[�Ƀ��O�I������";
            this.PopBeforeSmtpUseDiv_radioButton.UseVisualStyleBackColor = true;
            this.PopBeforeSmtpUseDiv_radioButton.CheckedChanged += new System.EventHandler(this.PopBeforeSmtpUseDiv_radioButton_CheckedChanged);
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel1.Location = new System.Drawing.Point(20, 275);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(780, 3);
            this.ultraLabel1.TabIndex = 48;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Location = new System.Drawing.Point(20, 475);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(780, 3);
            this.ultraLabel2.TabIndex = 52;
            // 
            // ultraLabel3
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance27;
            this.ultraLabel3.Location = new System.Drawing.Point(667, 491);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel3.TabIndex = 53;
            this.ultraLabel3.Tag = "16";
            this.ultraLabel3.Text = "�b";
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            // 
            // SelectionCode_Title_Label
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.SelectionCode_Title_Label.Appearance = appearance26;
            this.SelectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SelectionCode_Title_Label.Location = new System.Drawing.Point(65, 25);
            this.SelectionCode_Title_Label.Name = "SelectionCode_Title_Label";
            this.SelectionCode_Title_Label.Size = new System.Drawing.Size(135, 23);
            this.SelectionCode_Title_Label.TabIndex = 118;
            this.SelectionCode_Title_Label.Text = "���_";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel4.Location = new System.Drawing.Point(20, 55);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(780, 3);
            this.ultraLabel4.TabIndex = 119;
            // 
            // SectionName_tEdit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Left";
            this.SectionName_tEdit.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance21;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SectionName_tEdit.Location = new System.Drawing.Point(210, 25);
            this.SectionName_tEdit.MaxLength = 2;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.Size = new System.Drawing.Size(239, 24);
            this.SectionName_tEdit.TabIndex = 1;
            // 
            // MailSaveBeforeFolder_Label
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.MailSaveBeforeFolder_Label.Appearance = appearance43;
            this.MailSaveBeforeFolder_Label.Location = new System.Drawing.Point(65, 563);
            this.MailSaveBeforeFolder_Label.Name = "MailSaveBeforeFolder_Label";
            this.MailSaveBeforeFolder_Label.Size = new System.Drawing.Size(210, 23);
            this.MailSaveBeforeFolder_Label.TabIndex = 122;
            this.MailSaveBeforeFolder_Label.Tag = "16";
            this.MailSaveBeforeFolder_Label.Text = "���[���ۑ���t�H���_";
            // 
            // MailSaveBeforeFolder_tEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.TextHAlignAsString = "Left";
            this.MailSaveBeforeFolder_tEdit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Left";
            this.MailSaveBeforeFolder_tEdit.Appearance = appearance17;
            this.MailSaveBeforeFolder_tEdit.AutoSelect = true;
            this.MailSaveBeforeFolder_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MailSaveBeforeFolder_tEdit.DataText = "";
            this.MailSaveBeforeFolder_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailSaveBeforeFolder_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 256, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.MailSaveBeforeFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MailSaveBeforeFolder_tEdit.Location = new System.Drawing.Point(285, 562);
            this.MailSaveBeforeFolder_tEdit.MaxLength = 256;
            this.MailSaveBeforeFolder_tEdit.Name = "MailSaveBeforeFolder_tEdit";
            this.MailSaveBeforeFolder_tEdit.Size = new System.Drawing.Size(473, 24);
            this.MailSaveBeforeFolder_tEdit.TabIndex = 18;
            // 
            // SectionGuide_Button
            // 
            appearance39.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance39.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SectionGuide_Button.Appearance = appearance39;
            this.SectionGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionGuide_Button.Location = new System.Drawing.Point(452, 25);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_Button.TabIndex = 2;
            this.SectionGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // SaveFolder_Button
            // 
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance35.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SaveFolder_Button.Appearance = appearance35;
            this.SaveFolder_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SaveFolder_Button.Location = new System.Drawing.Point(768, 562);
            this.SaveFolder_Button.Name = "SaveFolder_Button";
            this.SaveFolder_Button.Size = new System.Drawing.Size(24, 24);
            this.SaveFolder_Button.TabIndex = 19;
            this.SaveFolder_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SaveFolder_Button.Click += new System.EventHandler(this.SaveFolder_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Location = new System.Drawing.Point(413, 620);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(131, 34);
            this.Delete_Button.TabIndex = 22;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Revive_Button.Location = new System.Drawing.Point(545, 620);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 23;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(545, 620);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 21;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Check_Button
            // 
            this.Check_Button.Location = new System.Drawing.Point(413, 620);
            this.Check_Button.Name = "Check_Button";
            this.Check_Button.Size = new System.Drawing.Size(131, 34);
            this.Check_Button.TabIndex = 20;
            this.Check_Button.Text = "�ڑ��e�X�g(&T)";
            this.Check_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Check_Button.Click += new System.EventHandler(this.Check_Button_Click);
            // 
            // PMKHN09590UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(816, 683);
            this.Controls.Add(this.Check_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.SaveFolder_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.MailSaveBeforeFolder_tEdit);
            this.Controls.Add(this.MailSaveBeforeFolder_Label);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.SelectionCode_Title_Label);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PopBeforeSmtpUseDiv_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv2_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv1_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv_ultraCheckEditor);
            this.Controls.Add(this.MailServerTimeoutVal_tNedit);
            this.Controls.Add(this.SmtpServerPortNo_tNedit);
            this.Controls.Add(this.PopServerPortNo_tNedit);
            this.Controls.Add(this.MailServerTimeoutVal_Label);
            this.Controls.Add(this.PopServerPortNo_Label);
            this.Controls.Add(this.SmtpServerPortNo_Label);
            this.Controls.Add(this.SmtpUserId_tEdit);
            this.Controls.Add(this.SmtpPassword_tEdit);
            this.Controls.Add(this.SmtpPassword_Label);
            this.Controls.Add(this.SmtpUserId_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.MailAddress_tEdit);
            this.Controls.Add(this.Pop3UserId_tEdit);
            this.Controls.Add(this.Pop3Password_tEdit);
            this.Controls.Add(this.Pop3ServerName_tEdit);
            this.Controls.Add(this.SmtpServerName_tEdit);
            this.Controls.Add(this.SenderName_tEdit);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SenderName_Label);
            this.Controls.Add(this.SmtpServerName_Label);
            this.Controls.Add(this.Pop3ServerName_Label);
            this.Controls.Add(this.Pop3Password_Label);
            this.Controls.Add(this.Pop3UserId_Label);
            this.Controls.Add(this.MailAddress_Label);
            this.Controls.Add(this.Close_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PMKHN09590UA";
            this.Text = "���[�����ݒ�";
            this.Load += new System.EventHandler(this.PMKHN09590UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09590UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09590UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.MailAddress_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3UserId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3Password_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pop3ServerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpServerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SenderName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpUserId_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpPassword_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PopServerPortNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SmtpServerPortNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailServerTimeoutVal_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MailSaveBeforeFolder_tEdit)).EndInit();
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
            System.Windows.Forms.Application.Run(new PMKHN09590UA());
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList mailInfoSettingList = null;

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._mailInfoSettingAcs.Search(out mailInfoSettingList, this._enterpriseCode);

                this._totalCount = mailInfoSettingList.Count;
            }
            else
            {
                status = this._mailInfoSettingAcs.SearchAll(
                    out mailInfoSettingList,
                    out this._totalCount,
                    out this._nextData,
                    this._enterpriseCode,
                    readCount,
                    this._mailInfoSetting);
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (mailInfoSettingList.Count > 0)
                        {
                            // �ŏI�̃��[�����M�Ǘ��ݒ���I�u�W�F�N�g��ޔ�����
                            this._mailInfoSetting = ((MailInfoSetting)mailInfoSettingList[mailInfoSettingList.Count - 1]).Clone();
                        }
                        int index = 0;
                        // �ǂݍ��񂾃C���X�^���X
                        foreach (MailInfoSetting mailInfoSetting in mailInfoSettingList)
                        {
                            // DataSet�ɃZ�b�g����
                            MailInfoSettingToDataSet(mailInfoSetting.Clone(), index);
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
                            "���[�����ݒ�}�X�^�����e�i���X", // �v���O��������
                            "Search", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._mailInfoSettingAcs, 			// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int Delete()
        {
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_FILEHEADERGUID];

            MailInfoSetting mailInfoSetting = (MailInfoSetting)this._mailInfoSettingTable[guid];

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ���[�����ݒ�}�X�^���_���폜����
            status = this._mailInfoSettingAcs.LogicalDelete(ref mailInfoSetting);

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
                            this._mailInfoSettingAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // ���[�����ݒ�}�X�^���N���X�f�[�^�Z�b�g�W�J����
            MailInfoSettingToDataSet(mailInfoSetting.Clone(), this.DataIndex);

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            //�폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            //���_
            appearanceTable.Add(VIEW_SECTIONCODE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //���_Name
            appearanceTable.Add(VIEW_SECTIONNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���o�l��
            appearanceTable.Add(VIEW_SENDERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���[���A�h���X
            appearanceTable.Add(VIEW_MAILADDRESS, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP3���[�U�[��
            appearanceTable.Add(VIEW_POP3USERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP3�p�X���[�h
            appearanceTable.Add(VIEW_POP3PASSWORD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP3�T�[�o�[��
            appearanceTable.Add(VIEW_POP3SERVERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //SMTP�T�[�o�[��
            appearanceTable.Add(VIEW_SMTPSERVERNAME, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���M�T�[�o�[(SMTP)�F��
            appearanceTable.Add(VIEW_SMTPAUTHUSEDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP�T�[�o�[ �|�[�g�ԍ�
            appearanceTable.Add(VIEW_POPSERVERPORTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //SMTP�T�[�o�[ �|�[�g�ԍ�
            appearanceTable.Add(VIEW_SMTPSERVERPORTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //���[���T�[�o�[�^�C���A�E�g�l
            appearanceTable.Add(VIEW_MAILSERVERTIMEOUTVAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���[���ۑ���t�H���_
            appearanceTable.Add(VIEW_MAILSAVEBEFOREFOLDER, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }
        #endregion
        #endregion

        #region Private Method
        /// <summary>
        /// ���[�����ݒ�}�X�^�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="mailInfoSetting">���[�����ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[�����ݒ�}�X�^�����e�i���X�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void MailInfoSettingToDataSet(MailInfoSetting mailInfoSetting, int index)
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
            if (mailInfoSetting.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = mailInfoSetting.UpdateDateTimeJpInFormal;
            }
            // ���_�R�[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONCODE] = mailInfoSetting.SectionCode.Trim().PadLeft(2, '0');
            // ���_����
            string sectionName;
            int status = this._mailInfoSettingAcs.ReadSectionName(out sectionName, this._enterpriseCode, mailInfoSetting.SectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = sectionName;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = "";
            }
            // ���o�l��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDERNAME] = mailInfoSetting.SenderName;
            // ���[���A�h���X
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILADDRESS] = mailInfoSetting.MailAddress;
            // POP3���[�U�[ID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3USERID] = mailInfoSetting.Pop3UserId;
            // POP3�p�X���[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3PASSWORD] = mailInfoSetting.Pop3Password;
            // POP3�T�[�o�[��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3SERVERNAME] = mailInfoSetting.Pop3ServerName;
            // SMTP�T�[�o�[��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPSERVERNAME] = mailInfoSetting.SmtpServerName;
            // ���M�T�[�o�[(SMTP)�F��
            if (mailInfoSetting.SmtpAuthUseDiv == 0 && mailInfoSetting.PopBeforeSmtpUseDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "�K�v";
            }
            // POP�T�[�o�[�|�[�g�ԍ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POPSERVERPORTNO] = mailInfoSetting.PopServerPortNo;
            // SMTP�T�[�o�[�|�[�g�ԍ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPSERVERPORTNO] = mailInfoSetting.SmtpServerPortNo;
            // ���[���T�[�o�[�^�C���A�E�g
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSERVERTIMEOUTVAL] = mailInfoSetting.MailServerTimeoutVal;
            // ���[���ۑ���t�H���_
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSAVEBEFOREFOLDER] = mailInfoSetting.FilePathNm;
            //GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = mailInfoSetting.FileHeaderGuid;

            // �C���X�^���X�e�[�u���ɂ��Z�b�g����
            if (this._mailInfoSettingTable.ContainsKey(mailInfoSetting.FileHeaderGuid) == true)
            {
                this._mailInfoSettingTable.Remove(mailInfoSetting.FileHeaderGuid);
            }
            this._mailInfoSettingTable.Add(mailInfoSetting.FileHeaderGuid, mailInfoSetting);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable mailSndMngTable = new DataTable(VIEW_TABLE);

            //// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            mailSndMngTable.Columns.Add(DELETE_DATE, typeof(string));               //�폜��
            mailSndMngTable.Columns.Add(VIEW_SECTIONCODE, typeof(string));          //���_
            mailSndMngTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));          //���_����
            mailSndMngTable.Columns.Add(VIEW_SENDERNAME, typeof(string));           //���o�l��
            mailSndMngTable.Columns.Add(VIEW_MAILADDRESS, typeof(string));          //���[���A�h���X
            mailSndMngTable.Columns.Add(VIEW_POP3USERID, typeof(string));           //POP3���[�U�[ID
            mailSndMngTable.Columns.Add(VIEW_POP3PASSWORD, typeof(string));         //POP3�p�X���[�h
            mailSndMngTable.Columns.Add(VIEW_POP3SERVERNAME, typeof(string));       //POP3�T�[�o�[��
            mailSndMngTable.Columns.Add(VIEW_SMTPSERVERNAME, typeof(string));       //SMTP�T�[�o�[��
            mailSndMngTable.Columns.Add(VIEW_SMTPAUTHUSEDIV, typeof(string));       //���M�T�[�o�[(SMTP)�F��
            mailSndMngTable.Columns.Add(VIEW_POPSERVERPORTNO, typeof(int));         //POP�T�[�o�[ �|�[�g�ԍ�
            mailSndMngTable.Columns.Add(VIEW_SMTPSERVERPORTNO, typeof(int));        //SMTP�T�[�o�[ �|�[�g�ԍ�
            mailSndMngTable.Columns.Add(VIEW_MAILSERVERTIMEOUTVAL, typeof(int));    //���[���T�[�o�[�^�C���A�E�g�l
            mailSndMngTable.Columns.Add(VIEW_MAILSAVEBEFOREFOLDER, typeof(string)); //���[���ۑ���t�H���_
            mailSndMngTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));         //GUID

            this.Bind_DataSet.Tables.Add(mailSndMngTable);
        }

        /// <summary>
        ///	��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note			:	��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // Edit�n�N���A
            EditClear("", "0");
        }

        /// <summary>
        /// �G�f�B�b�g�{�b�N�X����������
        /// </summary>
        /// <param name="tEditValue">tEdit�ɑ������l</param>
        /// <param name="tNEditValue">tNEdit�ɑ������l</param>
        /// <remarks>
        /// <br>Note		:	TEdit,TNEdit�����������܂�</br>
        /// <br>Programmer	:	�����</br>
        /// <br>Date		:   2010/05/24</br>
        /// </remarks>
        private void EditClear(string tEditValue, string tNEditValue)
        {
            this._preSectionCode = tEditValue;
            this._preSectionName = tEditValue;
            SectionName_tEdit.DataText = tEditValue;
            MailAddress_tEdit.DataText = tEditValue;				// ���[���A�h���X
            Pop3UserId_tEdit.DataText = tEditValue;				    // POP3���[�U�[ID
            Pop3Password_tEdit.DataText = tEditValue;				// POP3�p�X���[�h
            Pop3ServerName_tEdit.DataText = tEditValue;				// POP3�T�[�o�[��
            SmtpServerName_tEdit.DataText = tEditValue;				// SMTP�T�[�o�[��
            SmtpUserId_tEdit.DataText = tEditValue;                 // SMTP���[�U�[ID
            SmtpPassword_tEdit.DataText = tEditValue;               // SMTP�p�X���[�h
            SenderName_tEdit.DataText = tEditValue;				    // ���o�l��
            MailSaveBeforeFolder_tEdit.Text = tEditValue;

            this.PopServerPortNo_tNedit.Text = tNEditValue;
            this.SmtpServerPortNo_tNedit.Text = tNEditValue;
            this.MailServerTimeoutVal_tNedit.Text = tNEditValue;
        }

        /// <summary>
        /// ��ʃN���A�[����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ��N���A�[���܂�</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// </remarks>
        private void ScreenClear()
        {
            EditClear("", "");									// Edit�n�N���A
            this.PopServerPortNo_tNedit.SetInt(0);
            this.SmtpServerPortNo_tNedit.SetInt(0);
            this.MailServerTimeoutVal_tNedit.SetInt(0);
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                MailInfoSetting mailInfoSetting = new MailInfoSetting();
                this._mailInfoSettingClone = mailInfoSetting.Clone();
                //_dataIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

                // ��ʓW�J����
                MailInfoSettingToScreen(mailInfoSetting);

                // ��ʏ�񃁁[�����ݒ�}�X�^�����e�i���X�N���X�i�[����
                DispToMailInfoSetting(ref this._mailInfoSettingClone);

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.SectionName_tEdit.Focus();
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                MailInfoSetting mailInfoSetting = (MailInfoSetting)this._mailInfoSettingTable[guid];

                // ��ʓW�J����
                MailInfoSettingToScreen(mailInfoSetting);

                if (mailInfoSetting.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �N���[���쐬
                    this._mailInfoSettingClone = mailInfoSetting.Clone();
                    // ��ʏ�񃁁[�����ݒ�}�X�^�����e�i���X�N���X�i�[����
                    DispToMailInfoSetting(ref this._mailInfoSettingClone);

                    this.SenderName_tEdit.Focus();
                    this.SenderName_tEdit.SelectAll();
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
        /// ��ʏ�񃁁[�����ݒ�}�X�^�����e�i���X�N���X�i�[����
        /// </summary>
        /// <param name="mailInfoSetting">���[�����ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂烁�[�����ݒ�}�X�^�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void DispToMailInfoSetting(ref MailInfoSetting mailInfoSetting)
        {
            if (mailInfoSetting == null)
            {
                // �V�K�̏ꍇ
                mailInfoSetting = new MailInfoSetting();
            }

            // �e���ڂ̃Z�b�g
            mailInfoSetting.EnterpriseCode = this._enterpriseCode;
            // ���_�R�[�h
            // 2010/07/01 >>>
            //mailInfoSetting.SectionCode = this._preSectionCode;
            mailInfoSetting.SectionCode = this._preSectionCode.Trim().PadLeft(2, '0');
            // 2010/07/01 <<<

            // e-mail���M�Ǘ��ԍ�
            mailInfoSetting.MailSendMngNo = 0; //0�Œ�
            // ���o�l��
            mailInfoSetting.SenderName = this.SenderName_tEdit.Text;
            // ���[���A�h���X
            mailInfoSetting.MailAddress = this.MailAddress_tEdit.Text;
            // POP3���[�U�[ID
            mailInfoSetting.Pop3UserId = this.Pop3UserId_tEdit.Text;
            // POP3�p�X���[�h
            mailInfoSetting.Pop3Password = this.Pop3Password_tEdit.Text;
            // POP3�T�[�o�[��
            mailInfoSetting.Pop3ServerName = this.Pop3ServerName_tEdit.Text;
            // SMTP�T�[�o�[��
            mailInfoSetting.SmtpServerName = this.SmtpServerName_tEdit.Text;
            // SMTP�F�؎g�p�敪
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                if (this.SmtpAuthUseDiv1_radioButton.Checked)
                {
                    mailInfoSetting.SmtpAuthUseDiv = 1; //POP�F�؂Ɠ���ID�E�p�X���[�h���g�p
                    mailInfoSetting.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP �g�p���Ȃ�
                }
                else if (this.SmtpAuthUseDiv2_radioButton.Checked)
                {
                    mailInfoSetting.SmtpAuthUseDiv = 2; //SMTP�F�؂�ID�E�p�X���[�h���g�p
                    mailInfoSetting.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP �g�p���Ȃ�
                }
                if (this.PopBeforeSmtpUseDiv_radioButton.Checked)
                {
                    mailInfoSetting.SmtpAuthUseDiv = 0;      //SMTP�F�؎g�p���Ȃ�
                    mailInfoSetting.PopBeforeSmtpUseDiv = 1; //�g�p����                    
                }
            }
            else
            {
                mailInfoSetting.SmtpAuthUseDiv = 0; //SMTP�F�؎g�p���Ȃ�
                mailInfoSetting.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP �g�p���Ȃ�
            }
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked && this.SmtpAuthUseDiv1_radioButton.Checked)
            {
                // SMTP���[�U�[ID
                mailInfoSetting.SmtpUserId = this.Pop3UserId_tEdit.Text;
                // SMTP�p�X���[�h
                mailInfoSetting.SmtpPassword = this.Pop3Password_tEdit.Text;
            }
            else
            {
                // SMTP���[�U�[ID
                mailInfoSetting.SmtpUserId = this.SmtpUserId_tEdit.Text;
                // SMTP�p�X���[�h
                mailInfoSetting.SmtpPassword = this.SmtpPassword_tEdit.Text;
            }
            // POP�T�[�o�[�|�[�g�ԍ�
            mailInfoSetting.PopServerPortNo = this.PopServerPortNo_tNedit.GetInt();
            // SMTP�T�[�o�[�|�[�g�ԍ�
            mailInfoSetting.SmtpServerPortNo = this.SmtpServerPortNo_tNedit.GetInt();
            // ���[���T�[�o�[�^�C���A�E�g�l
            mailInfoSetting.MailServerTimeoutVal = this.MailServerTimeoutVal_tNedit.GetInt();
            // �t�@�C���p�X��
            mailInfoSetting.FilePathNm = this.MailSaveBeforeFolder_tEdit.Text;
        }

        /// <summary>
        /// ���[�����ݒ�}�X�^�����e�i���X�N���X��ʓW�J����
        /// </summary>
        /// <param name="mailInfoSetting">���[�����ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[�����ݒ�}�X�^�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void MailInfoSettingToScreen(MailInfoSetting mailInfoSetting)
        {
            // �e���ڂ̃Z�b�g
            // ���_�R�[�h
            this._preSectionCode = mailInfoSetting.SectionCode;
            // ���_����
            string sectionName;
            int st = this._mailInfoSettingAcs.ReadSectionName(out sectionName, this._enterpriseCode, mailInfoSetting.SectionCode);
            if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionName_tEdit.Text = sectionName;
            }
            else
            {
                TMsgDisp.Show(this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                "���_���̎擾�Ɏ��s���܂����B",      // �\�����郁�b�Z�[�W 
                                st,								// �X�e�[�^�X�l
                                MessageBoxButtons.OK);				// �\������{�^��
            }
            // ���o�l��
            this.SenderName_tEdit.Text = mailInfoSetting.SenderName;
            // ���[���A�h���X
            this.MailAddress_tEdit.Text = mailInfoSetting.MailAddress;
            // POP3���[�U�[ID
            this.Pop3UserId_tEdit.Text = mailInfoSetting.Pop3UserId;
            // POP3�p�X���[�h
            this.Pop3Password_tEdit.Text = mailInfoSetting.Pop3Password;
            // POP3�T�[�o�[��
            this.Pop3ServerName_tEdit.Text = mailInfoSetting.Pop3ServerName;
            // SMTP�T�[�o�[��
            this.SmtpServerName_tEdit.Text = mailInfoSetting.SmtpServerName;

            // SMTP�F�؎g�p�敪:0:�g�p���Ȃ�,POP Before SMTP�g�p�敪:0:�g�p���Ȃ�
            if (mailInfoSetting.SmtpAuthUseDiv == 0 && mailInfoSetting.PopBeforeSmtpUseDiv == 0)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = false;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            // SMTP�F�؎g�p�敪:0:�g�p���Ȃ�,POP Before SMTP�g�p�敪:1:�g�p����
            else if (mailInfoSetting.SmtpAuthUseDiv == 0 && mailInfoSetting.PopBeforeSmtpUseDiv == 1)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = false;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = true;
            }
            // SMTP�F�؎g�p�敪:1:POP�F�؂Ɠ���,POP Before SMTP�g�p�敪:0:�g�p���Ȃ�
            else if (mailInfoSetting.SmtpAuthUseDiv == 1 && mailInfoSetting.PopBeforeSmtpUseDiv == 0)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            // SMTP�F�؎g�p�敪:2:SMTP�F�؂Ɠ���,POP Before SMTP�g�p�敪:0:�g�p���Ȃ�
            else if (mailInfoSetting.SmtpAuthUseDiv == 2 && mailInfoSetting.PopBeforeSmtpUseDiv == 0)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = false;
                this.SmtpAuthUseDiv2_radioButton.Checked = true;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            // ���̑��̑g�����̏ꍇ
            else
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = false;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }

            // SMTP���[�U�[ID
            this.SmtpUserId_tEdit.Text = mailInfoSetting.SmtpUserId;
            // SMTP�p�X���[�h
            this.SmtpPassword_tEdit.Text = mailInfoSetting.SmtpPassword;
            // POP�T�[�o�[�|�[�g�ԍ�            
            this.PopServerPortNo_tNedit.SetInt(mailInfoSetting.PopServerPortNo);
            // SMTP�T�[�o�[�|�[�g�ԍ�
            this.SmtpServerPortNo_tNedit.SetInt(mailInfoSetting.SmtpServerPortNo);
            // ���[���T�[�o�[�^�C���A�E�g�l
            this.MailServerTimeoutVal_tNedit.SetInt(mailInfoSetting.MailServerTimeoutVal);
            // �t�@�C���p�X��
            this.MailSaveBeforeFolder_tEdit.Text = mailInfoSetting.FilePathNm;
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                    // ���͍���
                    this.SectionName_tEdit.Enabled = true;
                    this.SectionGuide_Button.Enabled = true;
                    this.SenderName_tEdit.Enabled = true;
                    this.MailAddress_tEdit.Enabled = true;
                    this.Pop3UserId_tEdit.Enabled = true;
                    this.Pop3Password_tEdit.Enabled = true;
                    this.Pop3ServerName_tEdit.Enabled = true;
                    this.SmtpServerName_tEdit.Enabled = true;
                    this.SmtpAuthUseDiv_ultraCheckEditor.Enabled = true;
                    this.PopServerPortNo_tNedit.Enabled = true;
                    this.SmtpServerPortNo_tNedit.Enabled = true;
                    this.MailServerTimeoutVal_tNedit.Enabled = true;
                    this.MailSaveBeforeFolder_tEdit.Enabled = true;
                    this.SaveFolder_Button.Enabled = true;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;
                    this.Check_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    break;
                case UPDATE_MODE:
                    // ���͍���
                    this.SectionName_tEdit.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.SenderName_tEdit.Enabled = true;
                    this.MailAddress_tEdit.Enabled = true;
                    this.Pop3UserId_tEdit.Enabled = true;
                    this.Pop3Password_tEdit.Enabled = true;
                    this.Pop3ServerName_tEdit.Enabled = true;
                    this.SmtpServerName_tEdit.Enabled = true;
                    this.SmtpAuthUseDiv_ultraCheckEditor.Enabled = true;
                    this.PopServerPortNo_tNedit.Enabled = true;
                    this.SmtpServerPortNo_tNedit.Enabled = true;
                    this.MailServerTimeoutVal_tNedit.Enabled = true;
                    this.MailSaveBeforeFolder_tEdit.Enabled = true;
                    this.SaveFolder_Button.Enabled = true;

                    // �{�^��
                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;
                    this.Check_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    SmtpAuthUseDiv_ultraCheckEditor_CheckedChanged(new object(), new EventArgs());
                    break;
                case DELETE_MODE:
                    // ���͍���
                    this.SectionName_tEdit.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.SenderName_tEdit.Enabled = false;
                    this.MailAddress_tEdit.Enabled = false;
                    this.Pop3UserId_tEdit.Enabled = false;
                    this.Pop3Password_tEdit.Enabled = false;
                    this.Pop3ServerName_tEdit.Enabled = false;
                    this.SmtpServerName_tEdit.Enabled = false;
                    this.SmtpAuthUseDiv_ultraCheckEditor.Enabled = false;
                    this.SmtpAuthUseDiv1_radioButton.Enabled = false;
                    this.SmtpAuthUseDiv2_radioButton.Enabled = false;
                    this.PopBeforeSmtpUseDiv_radioButton.Enabled = false;
                    this.SmtpUserId_tEdit.Enabled = false;
                    this.SmtpPassword_tEdit.Enabled = false;
                    this.PopServerPortNo_tNedit.Enabled = false;
                    this.SmtpServerPortNo_tNedit.Enabled = false;
                    this.MailServerTimeoutVal_tNedit.Enabled = false;
                    this.MailSaveBeforeFolder_tEdit.Enabled = false;
                    this.SaveFolder_Button.Enabled = false;

                    // �{�^��
                    this.Ok_Button.Visible = false;
                    this.Close_Button.Visible = true;
                    this.Check_Button.Visible = false;
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
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
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
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private bool IsValueCheck()
        {
            string errorMsg = "";	// �G���[���b�Z�[�W�i�[
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
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private bool IsSaveProc()
        {
            MailInfoSetting mailInfoSetting = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                mailInfoSetting = ((MailInfoSetting)this._mailInfoSettingTable[guid]).Clone();
            }

            this.DispToMailInfoSetting(ref mailInfoSetting);

            int status = this._mailInfoSettingAcs.Write(ref mailInfoSetting);

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
                            "���̋��_�͊��Ɏg�p����Ă��܂��B",						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��

                        this.SectionName_tEdit.Focus();
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
                            "���[�����M�Ǘ��ݒ�",							// �v���O��������
                            "IsSaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._mailInfoSettingAcs,					// �G���[�����������I�u�W�F�N�g
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
            MailInfoSettingToDataSet(mailInfoSetting, this.DataIndex);

            return true;

        }

        /// <summary>
        /// �G���[�`�F�b�N����
        /// </summary>
        /// <param name="errorMsg">�G���[���b�Z�[�W�i�[�p�ϐ��i�󂯎�莞�͋�j</param>
        /// <returns>�t�H�[�J�X���Z�b�g����R���|�[�l���g</returns>
        /// <remarks>
        /// <br>Note		: �R���|�[�l���g�Ƀt�H�[�J�X���Z�b�g���܂��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		; 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private int CheckError(ref string errorMsg)
        {
            // �t�H�[�J�X�Z�b�g����G�f�B�b�g�̔ԍ�
            int setFocusNum = 0;

            // ���_�����͂���Ă��Ȃ��ꍇ
            if (this.SectionName_tEdit.DataText.Equals(""))
            {
                errorMsg = "���_��ݒ肵�ĉ������B";
                setFocusNum = 11;
                return setFocusNum;
            }

            // ���o�l���̂����͂���Ă��Ȃ��ꍇ
            if (this.SenderName_tEdit.DataText.Equals(""))
            {
                errorMsg = "���o�l������͂��Ă��������B";
                setFocusNum = 1;
                return setFocusNum;
            }
            // ���o�l���̂Ƀ_�u���N�I�e�[�V�����i���E�S�p�j���܂܂�Ă���ꍇ
            if ((this.SenderName_tEdit.DataText.IndexOf('\"') != -1) ||
                (SenderName_tEdit.DataText.IndexOf('�h') != -1))
            {
                errorMsg = "���o�l���̂Ɂu\"�v�͐ݒ�ł��܂���B";
                setFocusNum = 2;
                return setFocusNum;
            }
            // ���[���A�h���X���ݒ肳��Ă��Ȃ��Ƃ���
            if (this.MailAddress_tEdit.DataText.Equals(""))
            {
                errorMsg = "���M�����[���A�h���X��ݒ肵�ĉ������B";
                setFocusNum = 3;
                return setFocusNum;
            }
            // POP3���[�U�[ID���ݒ肳��Ă��Ȃ��Ƃ���
            if (this.Pop3UserId_tEdit.DataText.Equals(""))
            {
                errorMsg = "POP3���[�U�[ID����͂��Ă��������B";
                setFocusNum = 4;
                return setFocusNum;
            }
            // POP3�p�X���[�h���ݒ肳��Ă��Ȃ��Ƃ���
            if (this.Pop3Password_tEdit.DataText.Equals(""))
            {
                errorMsg = "POP3�p�X���[�h����͂��Ă��������B";
                setFocusNum = 5;
                return setFocusNum;
            }
            // POP3�T�[�o�[�����ݒ肳��Ă��Ȃ��Ƃ���
            if (this.Pop3ServerName_tEdit.DataText.Equals(""))
            {
                errorMsg = "POP3�T�[�o�[������͂��Ă��������B";
                setFocusNum = 6;
                return setFocusNum;
            }
            // SMTP�T�[�o�[�����ݒ肳��Ă��Ȃ��Ƃ���
            if (this.SmtpServerName_tEdit.DataText.Equals(""))
            {
                errorMsg = "SMTP�T�[�o�[������͂��Ă��������B";
                setFocusNum = 7;
                return setFocusNum;
            }
            // SMTP�F�؎g�p�敪
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked && this.SmtpAuthUseDiv2_radioButton.Checked)
            {
                // SMTP���[�U�[ID
                if (this.SmtpUserId_tEdit.DataText.Equals(""))
                {
                    errorMsg = "SMTP���[�U�[ID����͂��Ă��������B";
                    setFocusNum = 8;
                    return setFocusNum;
                }
                // SMTP�p�X���[�h
                else if (this.SmtpPassword_tEdit.DataText.Equals(""))
                {
                    errorMsg = "SMTP�p�X���[�h����͂��Ă��������B";
                    setFocusNum = 9;
                    return setFocusNum;
                }
            }

            // ���[���ۑ��p�t�H���_
            if (this.MailSaveBeforeFolder_tEdit.DataText.Equals(""))
            {
                errorMsg = "���[���ۑ��p�t�H���_��ݒ肵�ĉ������B";
                setFocusNum = 10;
                return setFocusNum;
            }

            // ���[���ۑ��t�H���_�L���`�F�b�N
            if (!Directory.Exists(this.MailSaveBeforeFolder_tEdit.DataText))
            {
                errorMsg = "���[���ۑ��p�t�H���_�������ł��B";
                setFocusNum = 10;
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
        /// <br>Programmer	: �����</br>
        /// <br>Date		; 2010/05/24</br>
        /// <br></br>
        /// </remarks>
        private void SetFocusToComponent(int setFocusNum)
        {
            // �t�H�[�J�X�Z�b�g
            switch (setFocusNum)
            {
                case 11:
                    {
                        // ���_
                        this.SectionName_tEdit.Focus();
                        break;
                    }
                case 1:
                    {
                        // ���o�l��
                        this.SenderName_tEdit.Focus();
                        break;
                    }
                case 2:
                    {
                        // ���o�l��
                        this.SenderName_tEdit.Focus();
                        break;
                    }
                case 3:
                    {
                        // ���[���A�h���X
                        this.MailAddress_tEdit.Focus();
                        break;
                    }
                case 4:
                    {
                        // POP3���[�U�[ID
                        this.Pop3UserId_tEdit.Focus();
                        break;
                    }
                case 5:
                    {
                        // POP3�p�X���[�h
                        this.Pop3Password_tEdit.Focus();
                        break;
                    }
                case 6:
                    {
                        // POP3�T�[�o�[��
                        this.Pop3ServerName_tEdit.Focus();
                        break;
                    }
                case 7:
                    {
                        // SMTP�T�[�o�[��
                        this.SmtpServerName_tEdit.Focus();
                        break;
                    }
                case 8:
                    {
                        // SMTP���[�U�[ID
                        this.SmtpUserId_tEdit.Focus();
                        break;
                    }
                case 9:
                    {
                        // SMTP�p�X���[�h
                        this.SmtpPassword_tEdit.Focus();
                        break;
                    }
                case 10:
                    {
                        // ���[���ۑ���t�H���_
                        this.MailSaveBeforeFolder_tEdit.Focus();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
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

        /// <summary>
        /// SMTP POP �T�[�o�[�F�؃`�F�b�N�p
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : SMTP POP �T�[�o�[�F�؃`�F�b�N�p</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private string AuthenticationCheck(int status)
        {
            string message = "";
            switch (status)
            {
                case 0:
                case 1:
                    message = "SMTP POP �T�[�o�[�F�؂ɐ������܂����B";
                    break;
                case 3:
                    message = "POP�F�؃G���[" + "\n" + "��M���[���T�[�o�[(POP3)�ɐڑ��ł��܂���ł����B"
                        + "\n" + "�T�[�o�[���A�|�[�g�ԍ��A�E�C���X�X�L�����̐ݒ���m�F���Ă��������B";
                    break;
                case 5:
                    message = "�ڑ��G���[" + "\n" + "���M���[���T�[�o�[(SMTP)�ɐڑ��ł��܂���ł����B"
                        + "\n" + "�T�[�o�[���A�|�[�g�ԍ��A�E�C���X�X�L�����̐ݒ���m�F���Ă��������B";
                    break;
                case 7:
                    message = "�����G���[";
                    break;
                case 9:
                    message = "�G���[";
                    break;
                default:
                    break;
            }
            return message;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        ///�@����M�Ώۋ��_�̑��݃`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : ����M�Ώۋ��_�̑��݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/05/24</br>
        /// </remarks>
        private bool ModeChangeProc()
        {
            bool status = false;

            if (this.DataIndex > 0 || this._indexBuf == -2)
            {
                return status;
            }

            string iMsg1 = "���͂��ꂽ�R�[�h�̃��[�����ݒ肪���ɓo�^����Ă��܂��B\n\n�ҏW���s���܂����H";
            string iMsg2 = "���͂��ꂽ�R�[�h�̃��[�����ݒ�͊��ɍ폜����Ă��܂��B";

            string sectionCode = this.SectionName_tEdit.DataText.Trim().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                string section = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTIONCODE];

                if (sectionCode.Equals(section.Trim().PadLeft(2, '0')))
                {
                    // ���͂��ꂽ�R�[�h�͍폜��ԏꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != string.Empty)
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, iMsg2, 0, MessageBoxButtons.OK);

                        this.SectionName_tEdit.Clear();

                        return true;
                    }

                    // ���͂��ꂽ�R�[�h�����ݏꍇ
                    switch (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, ASSEMBLY_ID, iMsg1, 0, MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            this.DataIndex = i;
                            this.ScreenClear();
                            this.ScreenReconstruction();
                            break;

                        case DialogResult.No:
                            this.SectionName_tEdit.Clear();
                            break;
                    }
                    return true;
                }
            }
            return status;
        }
        #endregion Private Method End

        # region Control Events
        /// <summary>
        ///	Form.Load �C�x���g(PMKHN09590UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void PMKHN09590UA_Load(object sender, System.EventArgs e)
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
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.SaveFolder_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // ��ʏ����ݒ菈��
            ScreenInitialSetting();
        }

        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMKHN09590UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	��ʂ̕\���A��\�����ς�������ɔ������܂��B</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void PMKHN09590UA_VisibleChanged(object sender, System.EventArgs e)
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

            ScreenClear();
        }

        /// <summary>
        ///	Form.Load �C�x���g(PMKHN09590UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void Close_Button_Click(object sender, System.EventArgs e)
        {
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                MailInfoSetting compareMailInfoSetting = new MailInfoSetting();
                compareMailInfoSetting = this._mailInfoSettingClone.Clone();
                //���݂̉�ʏ����擾����
                DispToMailInfoSetting(ref compareMailInfoSetting);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._mailInfoSettingClone.Equals(compareMailInfoSetting)))
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
            this._preSectionCode = string.Empty;
            this._preSectionName = string.Empty;

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
        /// Form.Closing�C�x���g(PMKHN09590UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���N���[�Y���̃C�x���g�ł�</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2010/05/24</br>
        /// </remarks>
        private void PMKHN09590UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// <br>Note			:	�^�C�}�[����</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Enabled = false;
            // ��ʍč\�z����
            ScreenReconstruction();
        }

        /// <summary>
        /// SMTP�F�؋敪�g�p�`�F�b�N�`�F���W����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	SMTP�F�؋敪�g�p�`�F�b�N�`�F���W����</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void SmtpAuthUseDiv_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                this.SmtpAuthUseDiv1_radioButton.Enabled = true;
                this.SmtpAuthUseDiv2_radioButton.Enabled = true;
                this.PopBeforeSmtpUseDiv_radioButton.Enabled = true;
                // SMTP�F�؎g�p :POP�F�؂Ɠ���ID�E�p�X���[�h���g�p����
                if (this.SmtpAuthUseDiv1_radioButton.Checked)
                {
                    this.SmtpUserId_tEdit.Text = this.Pop3UserId_tEdit.Text;
                    this.SmtpPassword_tEdit.Text = this.Pop3Password_tEdit.Text;
                }
                // SMTP�F�؎g�p :SMTP�F�؂�ID�E�p�X���[�h���g�p����
                if (this.SmtpAuthUseDiv2_radioButton.Checked)
                {
                    this.SmtpUserId_tEdit.Enabled = true;
                    this.SmtpPassword_tEdit.Enabled = true;
                }
            }
            else
            {
                this.SmtpAuthUseDiv1_radioButton.Enabled = false;
                this.SmtpAuthUseDiv2_radioButton.Enabled = false;
                this.PopBeforeSmtpUseDiv_radioButton.Enabled = false;
                this.SmtpUserId_tEdit.Enabled = false;
                this.SmtpPassword_tEdit.Enabled = false;
                this.SmtpUserId_tEdit.Text = "";
                this.SmtpPassword_tEdit.Text = "";
            }
        }

        /// <summary>
        /// SMTP�F�؋敪�g�p���W�I�{�^���`�F�b�N�`�F���W����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	SMTP�F�؋敪�g�p���W�I�{�^���`�F�b�N�`�F���W����</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void SmtpAuthUseDiv1_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SmtpAuthUseDiv1_radioButton.Checked)
            {
                this.SmtpUserId_tEdit.Enabled = false;
                this.SmtpPassword_tEdit.Enabled = false;
                this.SmtpUserId_tEdit.Text = this.Pop3UserId_tEdit.Text;
                this.SmtpPassword_tEdit.Text = this.Pop3Password_tEdit.Text;
            }
        }

        /// <summary>
        /// SMTP�F�؋敪�g�p���W�I�{�^���`�F�b�N�`�F���W����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	SMTP�F�؋敪�g�p���W�I�{�^���`�F�b�N�`�F���W����</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void SmtpAuthUseDiv2_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SmtpAuthUseDiv2_radioButton.Checked)
            {
                this.SmtpUserId_tEdit.Enabled = true;
                this.SmtpPassword_tEdit.Enabled = true;
                this.SmtpUserId_tEdit.Text = "";
                this.SmtpPassword_tEdit.Text = "";
            }
            else
            {
                this.SmtpUserId_tEdit.Enabled = false;
                this.SmtpPassword_tEdit.Enabled = false;
            }
        }

        /// <summary>
        /// POP Before SMTP�g�p�敪�`�F�b�N�`�F���W����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	POP Before SMTP�g�p�敪�`�F�b�N�`�F���W����</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void PopBeforeSmtpUseDiv_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (PopBeforeSmtpUseDiv_radioButton.Checked)
            {
                this.SmtpUserId_tEdit.Text = "";
                this.SmtpPassword_tEdit.Text = "";
            }
        }

        /// <summary>
        /// Check_Button�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	Check_Button�N���b�N�C�x���g</br>
        /// <br>Programmer		:	�����</br>
        /// <br>Date			:	2010/05/24</br>
        /// </remarks>
        private void Check_Button_Click(object sender, EventArgs e)
        {
            // �������̓J�[�\����Wait�ɐݒ�
            this.Cursor = Cursors.WaitCursor;

            // ���M��SMTP�T�[�o�[�F��
            TSMTP tSmtp = new TSMTP();

            // �T�[�o�[���Z�b�g(SMTP�T�[�o�[)
            tSmtp.ServerInfo.POPPort = this.PopServerPortNo_tNedit.GetInt();
            tSmtp.ServerInfo.POPServer = this.Pop3ServerName_tEdit.Text;
            tSmtp.ServerInfo.POPTimeOut = this.MailServerTimeoutVal_tNedit.GetInt();
            tSmtp.ServerInfo.SMTPPort = this.SmtpServerPortNo_tNedit.GetInt();
            tSmtp.ServerInfo.SMTPServer = this.SmtpServerName_tEdit.Text;
            tSmtp.ServerInfo.SMTPTimeOut = this.MailServerTimeoutVal_tNedit.GetInt();

            // ���[�U�[�F�؏��Z�b�g
            tSmtp.AuthorizationInfo.PopAccount = this.Pop3UserId_tEdit.Text;
            tSmtp.AuthorizationInfo.PopPassWord = this.Pop3Password_tEdit.Text;
            tSmtp.AuthorizationInfo.SmtpAccount = this.SmtpUserId_tEdit.Text;
            tSmtp.AuthorizationInfo.SmtpPassWord = this.SmtpPassword_tEdit.Text;

            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                if (this.PopBeforeSmtpUseDiv_radioButton.Checked)
                {
                    // POP Before SMTP�^�F�؂�ݒ�
                    tSmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.POPBeforeSMTP;
                }
                else
                {
                    // SMTP AUTH �� POP Before SMT �������Ńg���C���Ă����ݒ�
                    tSmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.Auto;
                }
            }
            else
            {
                // �F�؎g�p����
                tSmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.None;
            }

            // �g���[�X
            tSmtp.TraceOptions.Trace = false;
            tSmtp.TraceOptions.TraceLog = false;
            tSmtp.TraceOptions.TraceLogPath = "c:\\smtp.log";

            // �_�C�A���O�\��
            tSmtp.ProgressDialog = true;
            tSmtp.DialogConfirm = false;

            // �ڑ��`�F�b�N
            int smtpStatus = tSmtp.CheckServerConnection();

            // �F�؃G���[���b�Z�[�W�\��
            string smtpMessage = this.AuthenticationCheck(smtpStatus);
            if (smtpStatus > 1)
            {
                switch (smtpStatus)
                {
                    case 7:
                    case 9:
                        TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                    ASSEMBLY_ID,							// �A�Z���u��ID
                                    smtpMessage + "\n"
                                    + tSmtp.StatusMessage,              �@�@// �\�����郁�b�Z�[�W
                                    tSmtp.Status,							// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);					// �\������{�^��
                        break;
                    default:
                        TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        ASSEMBLY_ID,							// �A�Z���u��ID
                        smtpMessage,                        �@�@// �\�����郁�b�Z�[�W
                        tSmtp.Status,							// �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��

                        break;
                }
            }
            else
            {
                // SMTP�̔F�؂��������Ă���ꍇ��M���̔F�؃`�F�b�N���s��
                // ��M��POP�T�[�o�[�F��
                TPOP tPop = new TPOP();

                tPop.Logout();

                // ��M�����ݒ�
                tPop.MailOptions.ReceiveMethodEnumType = ReceiveMethodEnumTypes.Synchronous;

                // �g���[�X�I�v�V�����̐ݒ�
                tPop.TraceOptions.Trace = false;
                tPop.TraceOptions.TraceLog = false;
                tPop.TraceOptions.TraceLogPath = "c:\\pop.log";

                // �_�C�A���O�֘A�ݒ�
                tPop.ProgressDialog = true;
                tPop.DialogConfirm = false;

                // POP3�T�[�o�[�̐ݒ���s���܂��B
                tPop.ServerInfo.POPServer = this.Pop3ServerName_tEdit.Text;
                tPop.ServerInfo.POPPort = this.PopServerPortNo_tNedit.GetInt();

                // POP3�̔F�؂Ɋւ���ݒ���s���܂��B
                tPop.AuthorizationInfo.Account = this.Pop3UserId_tEdit.Text;
                tPop.AuthorizationInfo.PassWord = this.Pop3Password_tEdit.Text;
                tPop.AuthorizationInfo.AuthType = TPOP.AuthorizationTypes.Auto;

                //  �ڑ��`�F�b�N
                int popStatus = tPop.CheckServerConnection();

                // �F�؃G���[���b�Z�[�W�\��
                string popMessage = this.AuthenticationCheck(popStatus);
                if (popStatus > 1)
                {
                    switch (popStatus)
                    {
                        case 9:
                            // �G���[
                            TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                    ASSEMBLY_ID,							// �A�Z���u��ID
                                    popMessage + "\n"
                                    + tPop.StatusMessage,              �@�@ // �\�����郁�b�Z�[�W
                                    tPop.Status,							// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);					// �\������{�^��
                            break;
                        default:
                            // �G���[
                            TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                                 ASSEMBLY_ID,							// �A�Z���u��ID
                                 popMessage,                        �@�@// �\�����郁�b�Z�[�W
                                 tPop.Status,							// �X�e�[�^�X�l
                                 MessageBoxButtons.OK);					// �\������{�^��
                            break;
                    }
                }
                else
                {
                    // ����
                    TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                                ASSEMBLY_ID,							// �A�Z���u��ID
                                popMessage,                        �@�@ // �\�����郁�b�Z�[�W
                                tPop.Status,							// �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��
                }
            }
            // �J�[�\����Default�ɖ߂�
            this.Cursor = Cursors.Default;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.SectionName_tEdit.Text = secInfoSet.SectionCode.Trim();

                    if (this.ModeChangeProc())
                    {
                        return;
                    }

                    string sectionName;
                    this._mailInfoSettingAcs.ReadSectionName(out sectionName, this._enterpriseCode, secInfoSet.SectionCode.Trim());
                    this.SectionName_tEdit.DataText = sectionName.Trim();
                    this._preSectionCode = secInfoSet.SectionCode.Trim();
                    this._preSectionName = this.SectionName_tEdit.Text;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(SaveFolder_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[���ۑ���t�H���_�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void SaveFolder_Button_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "���[���ۑ��p�t�H���_�I��";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    MailSaveBeforeFolder_tEdit.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
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
            MailInfoSetting mailInfoSetting = ((MailInfoSetting)this._mailInfoSettingTable[guid]).Clone();

            // ���[�����ݒ�}�X�^�폜����
            int status = this._mailInfoSettingAcs.Delete(mailInfoSetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._mailInfoSettingTable.Remove(mailInfoSetting.FileHeaderGuid);

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
                            this._mailInfoSettingAcs, 			// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            // �m�F���b�Z�[�W
            DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,                       // �G���[���x��
                ASSEMBLY_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                "���ݕ\�����̃��[�����ݒ�}�X�^�𕜊����܂��B" + "\r\n"
                + "��낵���ł����H", 					              // �\�����郁�b�Z�[�W
                0, 					                                  // �X�e�[�^�X�l
                MessageBoxButtons.YesNo);	                          // �\������{�^��

            if (res != DialogResult.Yes)
            {
                this.Revive_Button.Focus();
                return;
            }

            // �����Ώۃf�[�^�擾
            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
            MailInfoSetting mailInfoSetting = ((MailInfoSetting)this._mailInfoSettingTable[guid]).Clone();

            // ���[�����ݒ�}�X�^�_���폜��������
            int status = this._mailInfoSettingAcs.Revival(ref mailInfoSetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        MailInfoSettingToDataSet(mailInfoSetting, this._dataIndex);
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
                            this._mailInfoSettingAcs,					// �G���[�����������I�u�W�F�N�g
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�J�X���[�X�g�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2010/05/24</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.SectionName_tEdit)
            {
                // ����M�Ώۋ��_�̑��݃`�F�b�N
                if (this.ModeChangeProc())
                {
                    return;
                }
                bool flag = true;
                try
                {
                    // ���_�R�[�h�擾
                    string sectionCode = this.SectionName_tEdit.DataText.Trim();

                    if (sectionCode.Trim().Equals(""))
                    {
                        this.SectionName_tEdit.DataText = string.Empty;
                        this._preSectionCode = string.Empty;
                        this._preSectionName = string.Empty;
                        flag = false;
                        return;
                    }

                    if (sectionCode.Trim().Equals(this._preSectionName))
                    {
                        flag = false;
                        return;
                    }

                    // ���_���̎擾
                    string sectionName;
                    int st = this._mailInfoSettingAcs.ReadSectionName(out sectionName, this._enterpriseCode, sectionCode);
                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.SectionName_tEdit.Text = sectionName;
                        this._preSectionCode = sectionCode;
                        this._preSectionName = sectionName;
                        flag = true;
                    }
                    else
                    {
                        TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                ASSEMBLY_ID,							// �A�Z���u��ID
                                "�w�肵�����_�R�[�h�͑��݂��܂���B",	// �\�����郁�b�Z�[�W
                                0,									    // �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��

                        this.SectionName_tEdit.Text = this._preSectionName;
                        flag = false;
                    }
                }
                finally
                {
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (flag)
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.SenderName_tEdit;
                            }
                            else
                            {
                                // �t�H�[�J�X�ݒ�
                                e.NextCtrl = this.SectionGuide_Button;
                            }
                        }
                    }
                }
            }
        }
        #endregion Control Events End
    }
}
