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
using Broadleaf.Library.Text;
using Broadleaf.Library.Net.Mail;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���[�����M�Ǘ��ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>note		: ���[�����M�Ǘ��ݒ���s���܂�
	///					: IMasterMaintenanceSingleType���������Ă��܂�</br>
	/// <br>Programer	: 22013 �v�� ����</br>
	/// <br>Date		: 2005.04.15</br>
	/// <br></br>
	/// <br>Update Note : 2005.06.13 22024 ���� �_�u</br>
	/// <br>            : �@�g�у��[�������ő�T�C�Y�ɂ�0�\�������l�ɕύX</br>
	/// <br>            : �A�����t�@�C�����̂Ƀt�H�[�J�X�J�ڂ���o�O�Ή��i�R���|�[�l���g�o�O�H�j</br>
	/// <br>Update Note : 2005.06.21 22024 ���� �_�u</br>
	/// <br>            : �@View��"���ݒ�"�\����""�ɕύX</br>
	/// <br>Update Note : 2005.06.21 22024 ����@�_�u</br>
	/// <br>            : �@CatchMouse�ATNedit(ZeroSupp�AImeMode)�AHotTracking</br>
	/// <br>Update Note : 2005.06.27 22024 ����@�_�u</br>
	/// <br>            : �@����{�^����Ł��L�[�⁨�L�[���͎��Ƀt�H�[�J�X�J�ڂ��Ȃ��悤�ɏC��</br>
	/// <br>Update Note : 2005.07.05 23013 �q�@���l</br>
	/// <br>            : �t���[���̍ŏI�ŏ����Ή�</br>
	/// <br>			: ArrowKeyControl��CatchMouse�v���p�e�B��True�ɐݒ�</br>
	/// <br>Update Note : 2005.07.06 23013 �q ���l</br>
	/// <br>					�E�r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C��</br>
	/// <br>Update Note : 2005.07.08 23013 �q ���l</br>
	/// <br>					�E�G���[���b�Z�[�W���o����UI��ʂ���鏈��</br>
	/// <br>Update Note : 2005.07.11 23013 �q ���l</br>
	/// <br>					�E�r�����䏈���̒��ɍŏ����Ή���ǉ�</br>
	/// <br>Update Note : 2005.09.03 23006 ���� ���q</br>
	/// <br>					�E����{�^���ւ̃t�H�[�J�X�Z�b�g����</br>
    /// <br>Update Note : 2005.09.08  23006 ���� ���q</br>
	/// <br>				    �E��ƃR�[�h�擾����</br>
	/// <br>Update Note : 2005.09.24  23006 ���� ���q</br>
	/// <br>				    �ETMsgDisp���i�Ή�</br>
	/// <br>Update Note : 2005.10.06  23006 ���� ���q</br>
	/// <br>				    �E�K�C�h�{�^�������Ή�</br>
	/// <br>Update Note : 2005.10.19  23006 ���� ���q</br>
	/// <br>				    �EUI�q���Hide����Owner.Activate�����ǉ�</br>
    /// <br>Update Note : 2006.07.26  23006 ���� ���q</br>
    /// <br>                    �E�u���b�V���A�b�v�Ή�</br>
    /// <br>Update Note : 2006.11.06  23013 �q�@���l</br>
    /// <br>                    �E���ڒǉ��EUI��ʁE�}�X�����^�C�v�啝�ύX</br>
    /// </remarks>
    public class SFDML09060UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel MailAddress_Label;
		private Infragistics.Win.Misc.UltraLabel Pop3UserId_Label;
		private Infragistics.Win.Misc.UltraLabel Pop3Password_Label;
		private Infragistics.Win.Misc.UltraLabel Pop3ServerName_Label;
		private Infragistics.Win.Misc.UltraLabel SmtpServerName_Label;
		private Infragistics.Win.Misc.UltraLabel SenderName_Label;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
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
        private Infragistics.Win.Misc.UltraLabel BackupFormal_Label;
        private Infragistics.Win.Misc.UltraLabel MailServerTimeoutVal_Label;
        private Infragistics.Win.Misc.UltraLabel PopServerPortNo_Label;
        private Infragistics.Win.Misc.UltraLabel SmtpServerPortNo_Label;
        private Infragistics.Win.Misc.UltraLabel MailSendDivUnitCnt_Label;
        private TNedit MailServerTimeoutVal_tNedit;
        private TNedit SmtpServerPortNo_tNedit;
        private TNedit PopServerPortNo_tNedit;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor SmtpAuthUseDiv_ultraCheckEditor;
        private RadioButton SmtpAuthUseDiv1_radioButton;
        private RadioButton PopBeforeSmtpUseDiv_radioButton;
        private RadioButton SmtpAuthUseDiv2_radioButton;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor BackupSendDivCd_ultraCheckEditor;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor MailSendDivUnitCnt_ultraCheckEditor;
        private TNedit MailSendDivUnitCnt_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private DataSet Bind_DataSet;
        private Infragistics.Win.Misc.UltraLabel SelectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TEdit SectionName_tEdit;
        private TEdit SectionCode_tEdit;
        private TComboEditor BackupFormal_tComboEditor;
        private Infragistics.Win.Misc.UltraButton Check_Button;
		private System.ComponentModel.IContainer components;
		#endregion

		#region �R���X�g���N�^
		/// <summary>
		/// SFDML09060U�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���[�����M�Ǘ��ݒ�R���X�g���N�^�ł�</br>
		/// <br>Programmer	: 22013  �v�ہ@����</br>
		/// <br>Date		: 2005.04.26</br>
		/// </remarks>
		public SFDML09060UA()
		{
			InitializeComponent();

            // DataSet����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = true;
            this._canNew = false;
            this._canDelete = false;
            this._canLogicalDeleteDataExtraction = false;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            this._nextData = false;
            this._totalCount = 0;

			// mailSndMng�N���X
			this._mailSndMng = new MailSndMng();
			// mailSndMng�N���X�A�N�Z�X�N���X
			this._mailSndMngAcs = new MailSndMngAcs();            

            this._mailSndMngTable = new Hashtable();

			//�@��ƃR�[�h���擾����
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

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
		private MailSndMng _mailSndMng;
		private MailSndMngAcs _mailSndMngAcs;
		private MailSndMng mailSndMngClone; // �f�[�^��r�p        
		private string enterpriseCode;

        //HashTable
        private Hashtable _mailSndMngTable;

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

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE                = "�폜��";                
        private const string VIEW_SECTIONNAME           = "���_����";
        private const string VIEW_SENDERNAME            = "���o�l��";
        private const string VIEW_MAILADDRESS           = "���[���A�h���X";
        private const string VIEW_POP3USERID            = "POP3���[�U�[ID";
        private const string VIEW_POP3PASSWORD          = "POP3�p�X���[�h";
        private const string VIEW_POP3SERVERNAME        = "POP3�T�[�o�[��";
        private const string VIEW_SMTPSERVERNAME        = "SMTP�T�[�o�[��";
        private const string VIEW_SMTPAUTHUSEDIV        = "SMTP�F�؎g�p";
        private const string VIEW_SMTPUSERID            = "SMTP���[�U�[ID";
        private const string VIEW_SMTPPASSWORD          = "SMTP�p�X���[�h";
        private const string VIEW_POPBEFORESMTPUSEDIV   = "��M���[���T�[�o�[�Ƀ��O�I��";
        private const string VIEW_POPSERVERPORTNO       = "POP�T�[�o�[ �|�[�g�ԍ�";
        private const string VIEW_SMTPSERVERPORTNO      = "SMTP�T�[�o�[ �|�[�g�ԍ�";
        private const string VIEW_MAILSERVERTIMEOUTVAL  = "���[���T�[�o�[�^�C���A�E�g�l";
        private const string VIEW_BACKUPSENDDIVCD       = "�o�b�N�A�b�v���M�敪";
        private const string VIEW_BACKUPFORMAL          = "�o�b�N�A�b�v�`��";
        private const string VIEW_MAILSENDDIVUNITCNT    = "���[�����M�����P�ʌ���";

        //GUID
        private const string VIEW_FILEHEADERGUID = "Guid";

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

		private const string HTML_HEADER_TITLE	= "�ݒ荀��";
		private const string HTML_HEADER_VALUE	= "�ݒ�l";
////////////////////////////////////////////// 2005.06.21 TERASAKA DEL STA //
//		private const string HTML_UNREGISTER	= "���ݒ�";
// 2005.06.21 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2005.06.21 TERASAKA ADD STA //
		private const string HTML_UNREGISTER	= "";
// 2005.06.21 TERASAKA ADD END //////////////////////////////////////////////

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

        // 2006.11.06 Maki Del
		// �萔
		//private const string UNITOFCHAR	 = "���i���p�j";

        private int _indexBuf;

		#endregion

		#region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            this.MailAddress_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3UserId_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3Password_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Pop3ServerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpServerName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SenderName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
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
            this.BackupFormal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MailServerTimeoutVal_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PopServerPortNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SmtpServerPortNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MailSendDivUnitCnt_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PopServerPortNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SmtpServerPortNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MailServerTimeoutVal_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SmtpAuthUseDiv_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.SmtpAuthUseDiv1_radioButton = new System.Windows.Forms.RadioButton();
            this.SmtpAuthUseDiv2_radioButton = new System.Windows.Forms.RadioButton();
            this.PopBeforeSmtpUseDiv_radioButton = new System.Windows.Forms.RadioButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.BackupSendDivCd_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.MailSendDivUnitCnt_ultraCheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.MailSendDivUnitCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.SelectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionCode_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.BackupFormal_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
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
            ((System.ComponentModel.ISupportInitialize)(this.MailSendDivUnitCnt_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackupFormal_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // MailAddress_Label
            // 
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance3.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance4.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance7.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.Mode_Label.Appearance = appearance7;
            this.Mode_Label.BackColor = System.Drawing.Color.Navy;
            this.Mode_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label.Location = new System.Drawing.Point(685, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 18;
            // 
            // Ok_Button
            // 
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(545, 620);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 21;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
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
            this.Close_Button.UseHotTracking= Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Close_Button.Location = new System.Drawing.Point(670, 620);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(125, 34);
            this.Close_Button.TabIndex = 22;
            this.Close_Button.Text = "����(&X)";
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // MailAddress_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlign = Infragistics.Win.HAlign.Left;
            this.MailAddress_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlign = Infragistics.Win.HAlign.Left;
            this.MailAddress_tEdit.Appearance = appearance9;
            this.MailAddress_tEdit.AutoSelect = true;
            this.MailAddress_tEdit.DataText = "";
            this.MailAddress_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailAddress_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.MailAddress_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MailAddress_tEdit.Location = new System.Drawing.Point(210, 105);
            this.MailAddress_tEdit.MaxLength = 64;
            this.MailAddress_tEdit.Name = "MailAddress_tEdit";
            this.MailAddress_tEdit.Size = new System.Drawing.Size(523, 24);
            this.MailAddress_tEdit.TabIndex = 2;
            // 
            // Pop3UserId_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3UserId_tEdit.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3UserId_tEdit.Appearance = appearance11;
            this.Pop3UserId_tEdit.AutoSelect = true;
            this.Pop3UserId_tEdit.DataText = "";
            this.Pop3UserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3UserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.Pop3UserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3UserId_tEdit.Location = new System.Drawing.Point(210, 140);
            this.Pop3UserId_tEdit.MaxLength = 64;
            this.Pop3UserId_tEdit.Name = "Pop3UserId_tEdit";
            this.Pop3UserId_tEdit.Size = new System.Drawing.Size(523, 24);
            this.Pop3UserId_tEdit.TabIndex = 3;
            // 
            // Pop3Password_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3Password_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3Password_tEdit.Appearance = appearance13;
            this.Pop3Password_tEdit.AutoSelect = true;
            this.Pop3Password_tEdit.DataText = "";
            this.Pop3Password_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3Password_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.Pop3Password_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3Password_tEdit.Location = new System.Drawing.Point(210, 175);
            this.Pop3Password_tEdit.MaxLength = 24;
            this.Pop3Password_tEdit.Name = "Pop3Password_tEdit";
            this.Pop3Password_tEdit.PasswordChar = '*';
            this.Pop3Password_tEdit.Size = new System.Drawing.Size(203, 24);
            this.Pop3Password_tEdit.TabIndex = 4;
            // 
            // Pop3ServerName_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance14.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3ServerName_tEdit.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            appearance15.TextHAlign = Infragistics.Win.HAlign.Left;
            this.Pop3ServerName_tEdit.Appearance = appearance15;
            this.Pop3ServerName_tEdit.AutoSelect = true;
            this.Pop3ServerName_tEdit.DataText = "";
            this.Pop3ServerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Pop3ServerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.Pop3ServerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Pop3ServerName_tEdit.Location = new System.Drawing.Point(210, 210);
            this.Pop3ServerName_tEdit.MaxLength = 64;
            this.Pop3ServerName_tEdit.Name = "Pop3ServerName_tEdit";
            this.Pop3ServerName_tEdit.Size = new System.Drawing.Size(523, 24);
            this.Pop3ServerName_tEdit.TabIndex = 5;
            // 
            // SmtpServerName_tEdit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpServerName_tEdit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpServerName_tEdit.Appearance = appearance17;
            this.SmtpServerName_tEdit.AutoSelect = true;
            this.SmtpServerName_tEdit.DataText = "";
            this.SmtpServerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpServerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.SmtpServerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpServerName_tEdit.Location = new System.Drawing.Point(210, 245);
            this.SmtpServerName_tEdit.MaxLength = 64;
            this.SmtpServerName_tEdit.Name = "SmtpServerName_tEdit";
            this.SmtpServerName_tEdit.Size = new System.Drawing.Size(523, 24);
            this.SmtpServerName_tEdit.TabIndex = 6;
            // 
            // SenderName_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SenderName_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SenderName_tEdit.Appearance = appearance19;
            this.SenderName_tEdit.AutoSelect = true;
            this.SenderName_tEdit.DataText = "";
            this.SenderName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SenderName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SenderName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SenderName_tEdit.Location = new System.Drawing.Point(210, 70);
            this.SenderName_tEdit.MaxLength = 32;
            this.SenderName_tEdit.Name = "SenderName_tEdit";
            this.SenderName_tEdit.Size = new System.Drawing.Size(528, 24);
            this.SenderName_tEdit.TabIndex = 1;
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
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SmtpUserId_tEdit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpUserId_tEdit.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpUserId_tEdit.Appearance = appearance45;
            this.SmtpUserId_tEdit.AutoSelect = true;
            this.SmtpUserId_tEdit.DataText = "";
            this.SmtpUserId_tEdit.Enabled = false;
            this.SmtpUserId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpUserId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.SmtpUserId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpUserId_tEdit.Location = new System.Drawing.Point(210, 380);
            this.SmtpUserId_tEdit.MaxLength = 64;
            this.SmtpUserId_tEdit.Name = "SmtpUserId_tEdit";
            this.SmtpUserId_tEdit.Size = new System.Drawing.Size(523, 24);
            this.SmtpUserId_tEdit.TabIndex = 10;
            // 
            // SmtpPassword_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpPassword_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SmtpPassword_tEdit.Appearance = appearance47;
            this.SmtpPassword_tEdit.AutoSelect = true;
            this.SmtpPassword_tEdit.DataText = "";
            this.SmtpPassword_tEdit.Enabled = false;
            this.SmtpPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SmtpPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.SmtpPassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SmtpPassword_tEdit.Location = new System.Drawing.Point(210, 415);
            this.SmtpPassword_tEdit.MaxLength = 24;
            this.SmtpPassword_tEdit.Name = "SmtpPassword_tEdit";
            this.SmtpPassword_tEdit.PasswordChar = '*';
            this.SmtpPassword_tEdit.Size = new System.Drawing.Size(203, 24);
            this.SmtpPassword_tEdit.TabIndex = 11;
            // 
            // SmtpPassword_Label
            // 
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            appearance48.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance49.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.SmtpUserId_Label.Appearance = appearance49;
            this.SmtpUserId_Label.Enabled = false;
            this.SmtpUserId_Label.Location = new System.Drawing.Point(65, 380);
            this.SmtpUserId_Label.Name = "SmtpUserId_Label";
            this.SmtpUserId_Label.Size = new System.Drawing.Size(135, 23);
            this.SmtpUserId_Label.TabIndex = 25;
            this.SmtpUserId_Label.Tag = "13";
            this.SmtpUserId_Label.Text = "SMTP���[�U�[ID";
            // 
            // BackupFormal_Label
            // 
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            appearance40.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.BackupFormal_Label.Appearance = appearance40;
            this.BackupFormal_Label.Enabled = false;
            this.BackupFormal_Label.Location = new System.Drawing.Point(455, 520);
            this.BackupFormal_Label.Name = "BackupFormal_Label";
            this.BackupFormal_Label.Size = new System.Drawing.Size(180, 23);
            this.BackupFormal_Label.TabIndex = 36;
            this.BackupFormal_Label.Tag = "16";
            this.BackupFormal_Label.Text = "�o�b�N�A�b�v�`��";
            // 
            // MailServerTimeoutVal_Label
            // 
            appearance41.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.MailServerTimeoutVal_Label.Appearance = appearance41;
            this.MailServerTimeoutVal_Label.Location = new System.Drawing.Point(65, 560);
            this.MailServerTimeoutVal_Label.Name = "MailServerTimeoutVal_Label";
            this.MailServerTimeoutVal_Label.Size = new System.Drawing.Size(210, 23);
            this.MailServerTimeoutVal_Label.TabIndex = 35;
            this.MailServerTimeoutVal_Label.Tag = "16";
            this.MailServerTimeoutVal_Label.Text = "���[���T�[�o�[�^�C���A�E�g";
            // 
            // PopServerPortNo_Label
            // 
            appearance42.TextVAlign = Infragistics.Win.VAlign.Middle;
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
            appearance43.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.SmtpServerPortNo_Label.Appearance = appearance43;
            this.SmtpServerPortNo_Label.Location = new System.Drawing.Point(65, 525);
            this.SmtpServerPortNo_Label.Name = "SmtpServerPortNo_Label";
            this.SmtpServerPortNo_Label.Size = new System.Drawing.Size(210, 23);
            this.SmtpServerPortNo_Label.TabIndex = 32;
            this.SmtpServerPortNo_Label.Tag = "16";
            this.SmtpServerPortNo_Label.Text = "SMTP�T�[�o�[ �|�[�g�ԍ�";
            // 
            // MailSendDivUnitCnt_Label
            // 
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.MailSendDivUnitCnt_Label.Appearance = appearance39;
            this.MailSendDivUnitCnt_Label.Enabled = false;
            this.MailSendDivUnitCnt_Label.Location = new System.Drawing.Point(455, 585);
            this.MailSendDivUnitCnt_Label.Name = "MailSendDivUnitCnt_Label";
            this.MailSendDivUnitCnt_Label.Size = new System.Drawing.Size(180, 23);
            this.MailSendDivUnitCnt_Label.TabIndex = 37;
            this.MailSendDivUnitCnt_Label.Tag = "16";
            this.MailSendDivUnitCnt_Label.Text = "���[�����M�����P�ʌ���";
            // 
            // PopServerPortNo_tNedit
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance37.TextHAlign = Infragistics.Win.HAlign.Right;
            this.PopServerPortNo_tNedit.ActiveAppearance = appearance37;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextHAlign = Infragistics.Win.HAlign.Right;
            this.PopServerPortNo_tNedit.Appearance = appearance38;
            this.PopServerPortNo_tNedit.AutoSelect = true;
            this.PopServerPortNo_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
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
            this.PopServerPortNo_tNedit.TabIndex = 13;
            // 
            // SmtpServerPortNo_tNedit
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance35.TextHAlign = Infragistics.Win.HAlign.Right;
            this.SmtpServerPortNo_tNedit.ActiveAppearance = appearance35;
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            appearance36.TextHAlign = Infragistics.Win.HAlign.Right;
            this.SmtpServerPortNo_tNedit.Appearance = appearance36;
            this.SmtpServerPortNo_tNedit.AutoSelect = true;
            this.SmtpServerPortNo_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
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
            this.SmtpServerPortNo_tNedit.TabIndex = 14;
            // 
            // MailServerTimeoutVal_tNedit
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance33.TextHAlign = Infragistics.Win.HAlign.Right;
            this.MailServerTimeoutVal_tNedit.ActiveAppearance = appearance33;
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextHAlign = Infragistics.Win.HAlign.Right;
            this.MailServerTimeoutVal_tNedit.Appearance = appearance34;
            this.MailServerTimeoutVal_tNedit.AutoSelect = true;
            this.MailServerTimeoutVal_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.MailServerTimeoutVal_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MailServerTimeoutVal_tNedit.DataText = "";
            this.MailServerTimeoutVal_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailServerTimeoutVal_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.MailServerTimeoutVal_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MailServerTimeoutVal_tNedit.Location = new System.Drawing.Point(285, 560);
            this.MailServerTimeoutVal_tNedit.MaxLength = 4;
            this.MailServerTimeoutVal_tNedit.Name = "MailServerTimeoutVal_tNedit";
            this.MailServerTimeoutVal_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MailServerTimeoutVal_tNedit.Size = new System.Drawing.Size(44, 24);
            this.MailServerTimeoutVal_tNedit.TabIndex = 15;
            // 
            // SmtpAuthUseDiv_ultraCheckEditor
            // 
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.SmtpAuthUseDiv_ultraCheckEditor.Appearance = appearance32;
            this.SmtpAuthUseDiv_ultraCheckEditor.Location = new System.Drawing.Point(25, 290);
            this.SmtpAuthUseDiv_ultraCheckEditor.Name = "SmtpAuthUseDiv_ultraCheckEditor";
            this.SmtpAuthUseDiv_ultraCheckEditor.Size = new System.Drawing.Size(260, 20);
            this.SmtpAuthUseDiv_ultraCheckEditor.TabIndex = 7;
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
            this.SmtpAuthUseDiv1_radioButton.TabIndex = 8;
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
            this.SmtpAuthUseDiv2_radioButton.TabIndex = 9;
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
            this.PopBeforeSmtpUseDiv_radioButton.TabIndex = 12;
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
            // BackupSendDivCd_ultraCheckEditor
            // 
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            this.BackupSendDivCd_ultraCheckEditor.Appearance = appearance31;
            this.BackupSendDivCd_ultraCheckEditor.Location = new System.Drawing.Point(400, 490);
            this.BackupSendDivCd_ultraCheckEditor.Name = "BackupSendDivCd_ultraCheckEditor";
            this.BackupSendDivCd_ultraCheckEditor.Size = new System.Drawing.Size(305, 20);
            this.BackupSendDivCd_ultraCheckEditor.TabIndex = 16;
            this.BackupSendDivCd_ultraCheckEditor.Text = "���ЃA�h���X�Ƀo�b�N�A�b�v�𑗐M����";
            this.BackupSendDivCd_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.BackupSendDivCd_ultraCheckEditor_CheckedChanged);
            // 
            // MailSendDivUnitCnt_ultraCheckEditor
            // 
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            this.MailSendDivUnitCnt_ultraCheckEditor.Appearance = appearance30;
            this.MailSendDivUnitCnt_ultraCheckEditor.Location = new System.Drawing.Point(400, 555);
            this.MailSendDivUnitCnt_ultraCheckEditor.Name = "MailSendDivUnitCnt_ultraCheckEditor";
            this.MailSendDivUnitCnt_ultraCheckEditor.Size = new System.Drawing.Size(200, 20);
            this.MailSendDivUnitCnt_ultraCheckEditor.TabIndex = 18;
            this.MailSendDivUnitCnt_ultraCheckEditor.Text = "���[�����M������������";
            this.MailSendDivUnitCnt_ultraCheckEditor.CheckedChanged += new System.EventHandler(this.MailSendDivUnitCnt_ultraCheckEditor_CheckedChanged);
            // 
            // MailSendDivUnitCnt_tNedit
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance28.TextHAlign = Infragistics.Win.HAlign.Right;
            this.MailSendDivUnitCnt_tNedit.ActiveAppearance = appearance28;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            appearance29.TextHAlign = Infragistics.Win.HAlign.Right;
            this.MailSendDivUnitCnt_tNedit.Appearance = appearance29;
            this.MailSendDivUnitCnt_tNedit.AutoSelect = true;
            this.MailSendDivUnitCnt_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
            this.MailSendDivUnitCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MailSendDivUnitCnt_tNedit.DataText = "";
            this.MailSendDivUnitCnt_tNedit.Enabled = false;
            this.MailSendDivUnitCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MailSendDivUnitCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MailSendDivUnitCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MailSendDivUnitCnt_tNedit.Location = new System.Drawing.Point(645, 585);
            this.MailSendDivUnitCnt_tNedit.MaxLength = 3;
            this.MailSendDivUnitCnt_tNedit.Name = "MailSendDivUnitCnt_tNedit";
            this.MailSendDivUnitCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MailSendDivUnitCnt_tNedit.Size = new System.Drawing.Size(36, 24);
            this.MailSendDivUnitCnt_tNedit.TabIndex = 19;
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
            appearance27.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel3.Appearance = appearance27;
            this.ultraLabel3.Location = new System.Drawing.Point(330, 560);
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
            appearance26.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.SelectionCode_Title_Label.Appearance = appearance26;
            this.SelectionCode_Title_Label.BackColor = System.Drawing.Color.Transparent;
            this.SelectionCode_Title_Label.Location = new System.Drawing.Point(65, 25);
            this.SelectionCode_Title_Label.Name = "SelectionCode_Title_Label";
            this.SelectionCode_Title_Label.Size = new System.Drawing.Size(135, 23);
            this.SelectionCode_Title_Label.TabIndex = 118;
            this.SelectionCode_Title_Label.Text = "���_����";
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
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance24.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SectionName_tEdit.ActiveAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextHAlign = Infragistics.Win.HAlign.Left;
            this.SectionName_tEdit.Appearance = appearance25;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 29, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SectionName_tEdit.Location = new System.Drawing.Point(210, 25);
            this.SectionName_tEdit.MaxLength = 29;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.Size = new System.Drawing.Size(242, 24);
            this.SectionName_tEdit.TabIndex = 120;
            // 
            // SectionCode_tEdit
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionCode_tEdit.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.SystemColors.Control;
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionCode_tEdit.Appearance = appearance23;
            this.SectionCode_tEdit.AutoSelect = true;
            this.SectionCode_tEdit.DataText = "";
            this.SectionCode_tEdit.Enabled = false;
            this.SectionCode_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionCode_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionCode_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SectionCode_tEdit.Location = new System.Drawing.Point(455, 25);
            this.SectionCode_tEdit.MaxLength = 12;
            this.SectionCode_tEdit.Name = "SectionCode_tEdit";
            this.SectionCode_tEdit.Size = new System.Drawing.Size(51, 24);
            this.SectionCode_tEdit.TabIndex = 121;
            this.SectionCode_tEdit.Visible = false;
            // 
            // BackupFormal_tComboEditor
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BackupFormal_tComboEditor.ActiveAppearance = appearance20;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            this.BackupFormal_tComboEditor.Appearance = appearance21;
            this.BackupFormal_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BackupFormal_tComboEditor.Enabled = false;
            this.BackupFormal_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            valueListItem1.DataValue = "ValueListItem0";
            valueListItem1.DisplayText = "���[���`��(BCC)";
            this.BackupFormal_tComboEditor.Items.Add(valueListItem1);
            this.BackupFormal_tComboEditor.Location = new System.Drawing.Point(645, 520);
            this.BackupFormal_tComboEditor.Name = "BackupFormal_tComboEditor";
            this.BackupFormal_tComboEditor.Size = new System.Drawing.Size(144, 24);
            this.BackupFormal_tComboEditor.TabIndex = 17;
            // 
            // Check_Button
            // 
            this.Check_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Check_Button.Location = new System.Drawing.Point(420, 620);
            this.Check_Button.Name = "Check_Button";
            this.Check_Button.Size = new System.Drawing.Size(125, 34);
            this.Check_Button.TabIndex = 20;
            this.Check_Button.Text = "�ڑ��e�X�g(&T)";
            this.Check_Button.Click += new System.EventHandler(this.Check_Button_Click);
            // 
            // SFDML09060UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(816, 683);
            this.Controls.Add(this.Check_Button);
            this.Controls.Add(this.BackupFormal_tComboEditor);
            this.Controls.Add(this.SectionCode_tEdit);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.SelectionCode_Title_Label);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.MailSendDivUnitCnt_tNedit);
            this.Controls.Add(this.MailSendDivUnitCnt_ultraCheckEditor);
            this.Controls.Add(this.BackupSendDivCd_ultraCheckEditor);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PopBeforeSmtpUseDiv_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv2_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv1_radioButton);
            this.Controls.Add(this.SmtpAuthUseDiv_ultraCheckEditor);
            this.Controls.Add(this.MailServerTimeoutVal_tNedit);
            this.Controls.Add(this.SmtpServerPortNo_tNedit);
            this.Controls.Add(this.PopServerPortNo_tNedit);
            this.Controls.Add(this.MailSendDivUnitCnt_Label);
            this.Controls.Add(this.BackupFormal_Label);
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
            this.Controls.Add(this.Ok_Button);
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
            this.Name = "SFDML09060UA";
            this.Text = "���[�����M�Ǘ��ݒ�";
            this.VisibleChanged += new System.EventHandler(this.SFDML09060UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFDML09060UA_Closing);
            this.Load += new System.EventHandler(this.SFDML09060UA_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.MailSendDivUnitCnt_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackupFormal_tComboEditor)).EndInit();
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
			System.Windows.Forms.Application.Run(new SFDML09060UA());
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

        #region Public Method

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
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
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList mailSndMngList = null;

            if (readCount == 0)
            {
                // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                status = this._mailSndMngAcs.Search(out mailSndMngList, this.enterpriseCode);

                this._totalCount = mailSndMngList.Count;
            }
            else
            {
                status = this._mailSndMngAcs.SearchAll(
                    out mailSndMngList,
                    out this._totalCount,
                    out this._nextData,
                    this.enterpriseCode,
                    readCount,
                    this._mailSndMng);
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (mailSndMngList.Count > 0)
                        {
                            // �ŏI�̃��[�����M�Ǘ��ݒ���I�u�W�F�N�g��ޔ�����
                            this._mailSndMng = ((MailSndMng)mailSndMngList[mailSndMngList.Count - 1]).Clone();
                        }
                        int index = 0;
                        // �ǂݍ��񂾃C���X�^���X
                        foreach (MailSndMng mailSndMng in mailSndMngList)
                        {
                            // DataSet�ɃZ�b�g����
                            MailSndMngToDataSet(mailSndMng.Clone(), index);
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
                            "SFDML09060U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���[���Ǘ��ݒ�",      			    // �v���O��������
                            "Search", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._mailSndMngAcs, 				// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
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
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public int Delete()
        {            
            return 0;
        }        
            
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
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
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            //�폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));            
            //���_����
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
            //SMTP�F�؎g�p
            appearanceTable.Add(VIEW_SMTPAUTHUSEDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //SMTP���[�U�[��
            appearanceTable.Add(VIEW_SMTPUSERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //SMTP�p�X���[�h
            appearanceTable.Add(VIEW_SMTPPASSWORD, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP Before SMTP�g�p�敪
            appearanceTable.Add(VIEW_POPBEFORESMTPUSEDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //POP�T�[�o�[ �|�[�g�ԍ�
            appearanceTable.Add(VIEW_POPSERVERPORTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //POP�T�[�o�[ �|�[�g�ԍ�
            appearanceTable.Add(VIEW_SMTPSERVERPORTNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //���[���T�[�o�[�^�C���A�E�g�l
            appearanceTable.Add(VIEW_MAILSERVERTIMEOUTVAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //�o�b�N�A�b�v���M�敪
            appearanceTable.Add(VIEW_BACKUPSENDDIVCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�o�b�N�A�b�v�`��
            appearanceTable.Add(VIEW_BACKUPFORMAL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���[�����M�����P�ʌ���
            appearanceTable.Add(VIEW_MAILSENDDIVUNITCNT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //GUID
            appearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        #endregion
        #endregion
        
        #region Private Properties 2006.11.06 Del
        /*

		/// <summary>
		/// Dmno�v���p�e�B
		/// </summary>
		/// <remarks>
		/// Dmno���擾�܂��͐ݒ肵�܂��B
		/// </remarks>
		private int Dmno
		{
			get{ return _dmno; }
			set{ _dmno = value; }
		}

		#endregion End Private Properties

		#region Public Method (IMasterMeintenanceSingleType����p��)
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ������������s���܂��i�������j</br>
		/// <br>Programmer	: 22013 �v�� ����</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		public int Print()
		{
			// ������
			return 0;
		}

		/// <summary>
		/// HTML�R�[�h�擾����
		/// </summary>
		/// <returns>HTML�R�[�h</returns>
		/// <remarks>
		/// <br>Note		: �r���[�p��HTML�R�[�h���擾���܂�</br>
		/// <br>Programmer	: 22013 �v�� ����</br>
		/// <br>Date		: 2005.04.15</br>
		/// <br></br>
		/// </remarks>
		public string GetHtmlCode()
		{
			// �o��HTML�R�[�h
			string outCode = "";

			// tHtmlGenerate���i�̈����𐶐�����
			string [,] array = new string[17,2];

			this.tHtmlGenerate1.Coltypes = new int[2];

			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

			// �^�C�g���ݒ�
			array[0,0] = HTML_HEADER_TITLE;//�u�ݒ荀�ځv
			array[0,1] = HTML_HEADER_VALUE;//�u�ݒ�l�v

            array[1, 0] = this.SenderName_Label.Text;			// ���o�l��
			array[2,0]  = this.MailAddress_Label.Text;			// ���[���A�h���X
			array[3,0]  = this.Pop3UserId_Label.Text;				// POP3���[�U�[ID
			array[4,0]  = this.Pop3Password_Label.Text;				// POP3�p�X���[�h
			array[5,0]  = this.Pop3ServerName_Label.Text;			// POP3�T�[�o�[��
			array[6,0]  = this.SmtpServerName_Label.Text;				// SMTP�T�[�o�[��
            array[7, 0] = "SMTP�F�؎g�p";					// SMTP�F�؎g�p�敪
            array[8,0]  = this.SmtpUserId_Label.Text;			// SMTP���[�U�[ID
			array[9,0]  = this.SmtpPassword_Label.Text;					// SMTP�p�X���[�h
			//array[8,0]  = this.SmtpAuthUseDiv_Label.Text;					// �_�C�A���A�b�v�敪
            //array[8, 0] = "SMTP�F�؎g�p";					// SMTP�F�؎g�p�敪
			//array[9,0]  = this.SenderName_Label.Text;			// ���o�l��
			//array[10,0] = this.PopBeforeSmtpUseDiv_Label.Text;				// �_�C�A���A�b�v���O�C����
            array[10, 0] = "��M���[���T�[�o�[�Ƀ��O�I��";				// POP Before SMTP�g�p�敪
			array[11,0] = this.PopServerPortNo_Label.Text;				// POP�T�[�o�[�|�[�g�ԍ�
			array[12,0] = this.SmtpServerPortNo_Label.Text;					// SMTP�T�[�o�[�|�[�g�ԍ�
			array[13,0] = this.MailServerTimeoutVal_Label.Text;					// ���[���T�[�o�[�^�C���A�E�g�l
			//array[14,0] = this.BackupSendDivCd_Label.Text;					// �o�b�N�A�b�v���M�敪
            array[14, 0] = "�o�b�N�A�b�v���M";					// �o�b�N�A�b�v���M�敪
			array[15,0] = this.BackupFormal_Label.Text;				// �o�b�N�A�b�v�`��
			array[16,0] = this.MailSendDivUnitCnt_Label.Text;				// ���[�����M�����P�ʌ���

			// TODO 1: �ǂݍ��ݏ����iReadMailSndMng�j
			int status = mailSndMngAcs.Read(out this.mailSndMng,this.enterpriseCode);
			// TODO guid1: dmno�ݒ�
			// ���[�����M�Ǘ��}�X�^����ǂݍ��񂾏����t�@�C���p�X�ƁA���[�������Ǘ��}�X�^�̏����t�@�C���p�X��
			// ���v������̂�T���֐����쐬����B�iwhile���ł��邭��񂵂ĒT���H�j
			if ( status == 0 )
			{
                // 2006.11.01 Maki Del >>>>>>>>>>>>>>>>>>>>
//                string companySignAttach = "";
//                switch(mailSndMng.CompanySignAttachCd)
//                {
//                    case 1:
//                    {
//                        companySignAttach = "�Y�t����";
//                        break;
//                    }
//                    default:
//                    {
//                        companySignAttach = "�Y�t���Ȃ�";
//                        break;					
//                    }
//                }
//                array[1,1]  = companySignAttach;									// ���Џ����敪
////				array[2,1]  = mailSndMng.AttachFilePath;							// �����t�@�C���p�X
//                array[2,1]  = RemovalExtensions(mailSndMng.AttachFilePath);			// �����t�@�C���p�X�i�g���q�폜��j
//                array[3,1]  = mailSndMng.MailDocMaxSize + UNITOFCHAR;				// ���[�������ő�T�C�Y
//                array[4,1]  = mailSndMng.MailLineStrMaxSize + UNITOFCHAR;			// ���[�������s�������ő�T�C�Y
//                array[5,1]  = mailSndMng.PMailDocMaxSize + UNITOFCHAR;				// �g�у��[�������ő�T�C�Y
//                array[6,1]  = mailSndMng.PMailLineStrMaxSize + UNITOFCHAR;			// �g�у��[�������s�������ő�T�C�Y
//                array[7,1]  = mailSndMng.MailAddress;								// ���[���A�h���X

//                // �_�C�A���A�b�v�敪�ύX
//                string dialUp;
//                switch(mailSndMng.DialUpCode)
//                {
//                    case 0:
//                    {
//                        dialUp = "�_�C�A��";
//                        break;
//                    }
//                    default:
//                    {
//                        dialUp = "LAN";
//                        break;
//                    }
//                }
//                array[8,1]  = dialUp;										// �_�C�A���A�b�v�敪
//                array[9,1]  = mailSndMng.DialUpConnectName;					// �_�C�A���A�b�v�ڑ�����
//                array[10,1] = mailSndMng.DialUpLoginName;					// �_�C�A���A�b�v���O�C����
//                array[11,1] = mailSndMng.DialUpPassword;					// �_�C�A���A�b�v�p�X���[�h
//                array[12,1] = mailSndMng.Pop3UserId;						// POP3���[�U�[ID
//                array[13,1] = mailSndMng.Pop3Password;						// POP3�p�X���[�h
//                array[14,1] = mailSndMng.SenderName;						// ���o�l��
//                array[15,1] = mailSndMng.Pop3ServerName;					// POP3�T�[�o�[��
//                array[16,1] = mailSndMng.SmtpServerName;					// SMTP�T�[�o�[��
                // 
                // 2006.11.01 Maki Add
                array[1, 1] = mailSndMng.SenderName;
                array[2, 1]  = mailSndMng.MailAddress;
                array[3, 1]  = mailSndMng.Pop3UserId;
                array[4, 1]  = mailSndMng.Pop3Password;
                array[5, 1]  = mailSndMng.Pop3ServerName;
                array[6, 1]  = mailSndMng.SmtpServerName;
                string smtpAuthUse;
                switch (mailSndMng.SmtpAuthUseDiv)
                {
                    case 0:
                        {
                            smtpAuthUse = "�g�p���Ȃ�";
                            break;
                        }
                    case 1:
                        {
                            smtpAuthUse = "POP�F�؂Ɠ���ID�E�p�X���[�h���g�p����";
                            break;
                        }
                    case 2:
                        {
                            smtpAuthUse = "SMTP�F�؂Ɠ���ID�E�p�X���[�h���g�p����";
                            break;
                        }
                    default:
                        {
                            smtpAuthUse = HTML_UNREGISTER;
                            break;
                        }
                }
                array[7, 1] = smtpAuthUse;
                array[8, 1]  = mailSndMng.SmtpUserId;
                array[9, 1]  = mailSndMng.SmtpPassword;
                //string smtpAuthUse;
                //switch (mailSndMng.SmtpAuthUseDiv)
                //{
                //    case 0:
                //        {
                //            smtpAuthUse = "�g�p���Ȃ�";
                //            break;
                //        }
                //    case 1:
                //        {
                //            smtpAuthUse = "POP�F�؂Ɠ���ID�E�p�X���[�h���g�p����";
                //            break;
                //        }
                //    case 2:
                //        {
                //            smtpAuthUse = "SMTP�F�؂Ɠ���ID�E�p�X���[�h���g�p����";
                //            break;
                //        }
                //    default:
                //        {
                //            smtpAuthUse = HTML_UNREGISTER;
                //            break;
                //        }
                //}
                //array[8, 1] = smtpAuthUse;
                //array[9, 1]  = mailSndMng.SenderName;
                string popBeforeSmtpUse;
                switch (mailSndMng.PopBeforeSmtpUseDiv)
                {
                    case 0:
                        {
                            popBeforeSmtpUse = "�g�p���Ȃ�";
                            break;
                        }
                    case 1:
                        {
                            popBeforeSmtpUse = "��M���[���T�[�o�[�Ƀ��O�I������";
                            break;
                        }
                    default:
                        {
                            popBeforeSmtpUse = HTML_UNREGISTER;
                            break;
                        }
                }
                array[10, 1] = popBeforeSmtpUse;
                array[11, 1] = mailSndMng.PopServerPortNo.ToString();
                array[12, 1] = mailSndMng.SmtpServerPortNo.ToString();
                array[13, 1] = mailSndMng.MailServerTimeoutVal.ToString();
                string backupSend;
                switch (mailSndMng.BackupSendDivCd)
                {
                    case 0:
                        {
                            backupSend = "���ЃA�h���X�Ƀo�b�N�A�b�v���M����";
                            break;
                        }
                    case 1:
                        {
                            backupSend = "���M���Ȃ�";
                            break;
                        }
                    default:
                        {
                            backupSend = HTML_UNREGISTER;
                            break;
                        }
                }
                array[14, 1] = backupSend;
                string backupFormal;
                switch (mailSndMng.BackupFormal)
                {
                    case 0:
                        {
                            backupFormal = "���[���`��(BCC)";
                            break;
                        }
                    case 1:
                        {
                            backupFormal = "�ꗗ�\�`��(�Ȉ�)";
                            break;
                        }
                    default:
                        {
                            backupFormal = HTML_UNREGISTER;
                            break;
                        }
                }
                array[15, 1] = backupFormal;
                string mailSendDivUnit;
                switch (mailSndMng.MailSendDivUnitCnt)
                {
                    case 0:
                        {
                            mailSendDivUnit = "�����������Ȃ�";
                            break;
                        }
                    default:
                        {
                            mailSendDivUnit = mailSndMng.MailSendDivUnitCnt.ToString();
                            break;
                        }
                }
                array[16, 1] = mailSendDivUnit;
                //
			}
			else
			{
				array[1,1]  = HTML_UNREGISTER;	// ���Џ����敪
				array[2,1]  = HTML_UNREGISTER;	// �����t�@�C���p�X
				array[3,1]  = HTML_UNREGISTER;	// ���[�������ő�T�C�Y
				array[4,1]  = HTML_UNREGISTER;	// ���[�������s�������ő�T�C�Y
				array[5,1]  = HTML_UNREGISTER;	// �g�у��[�������ő�T�C�Y
				array[6,1]  = HTML_UNREGISTER;	// �g�у��[�������s�������ő�T�C�Y
				array[7,1]  = HTML_UNREGISTER;	// ���[���A�h���X
				array[8,1]  = HTML_UNREGISTER;	// �_�C�A���A�b�v�敪
				array[9,1]  = HTML_UNREGISTER;	// �_�C�A���A�b�v�ڑ�����
				array[10,1] = HTML_UNREGISTER;	// �_�C�A���A�b�v���O�C����
				array[11,1] = HTML_UNREGISTER;	// �_�C�A���A�b�v�p�X���[�h
				array[12,1] = HTML_UNREGISTER;	// POP3���[�U�[ID
				array[13,1] = HTML_UNREGISTER;	// POP3�p�X���[�h
				array[14,1] = HTML_UNREGISTER;	// ���o�l��
				array[15,1] = HTML_UNREGISTER;	// POP3�T�[�o�[��
				array[16,1] = HTML_UNREGISTER;	// SMTP�T�[�o�[��

			}

			// �f�[�^�̂Q�����z��݂̂��w�肵�āA�v���p�e�B���g�p���ăO���b�h�\������
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);

			return outCode;
		}
        */
		#endregion

		#region Private Method
        /// <summary>
        /// ���[�����M�Ǘ��ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="mailSndMng">���[�����M�Ǘ��ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ���[�����M�Ǘ��ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void MailSndMngToDataSet(MailSndMng mailSndMng, int index)
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
            if (mailSndMng.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = mailSndMng.UpdateDateTimeJpInFormal;
            }
            // ���_����
            string sectionName;
            int status = this._mailSndMngAcs.ReadSectionName(out sectionName, this.enterpriseCode, mailSndMng.SectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = sectionName;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTIONNAME] = "";
            }
            // ���o�l��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SENDERNAME] = mailSndMng.SenderName;
            // ���[���A�h���X
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILADDRESS] = mailSndMng.MailAddress;
            // POP3���[�U�[ID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3USERID] = mailSndMng.Pop3UserId;
            // POP3�p�X���[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3PASSWORD] = mailSndMng.Pop3Password;
            // POP3�T�[�o�[��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POP3SERVERNAME] = mailSndMng.Pop3ServerName;
            // SMTP�T�[�o�[��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPSERVERNAME] = mailSndMng.SmtpServerName;
            // SMTP�F�؎g�p
            switch (mailSndMng.SmtpAuthUseDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "�g�p���Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "POP�F�؂Ɠ���ID�E�p�X���[�h���g�p";
                        break;
                    }
                case 2:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPAUTHUSEDIV] = "SMTP�F�؂�ID�E�p�X���[�h���g�p";
                        break;
                    }
            }
            // SMTP���[�U�[ID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPUSERID] = mailSndMng.SmtpUserId;                
            // SMTP�p�X���[�h
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPPASSWORD] = mailSndMng.SmtpPassword;
            // POP Before SMTP�g�p�敪
            switch (mailSndMng.PopBeforeSmtpUseDiv)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POPBEFORESMTPUSEDIV] = "�g�p���Ȃ�";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POPBEFORESMTPUSEDIV] = "�g�p����";
                        break;
                    }
            }
            // POP�T�[�o�[�|�[�g�ԍ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_POPSERVERPORTNO] = mailSndMng.PopServerPortNo;
            // SMTP�T�[�o�[�|�[�g�ԍ�
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SMTPSERVERPORTNO] = mailSndMng.SmtpServerPortNo;
            // ���[���T�[�o�[�^�C���A�E�g�l
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSERVERTIMEOUTVAL] = mailSndMng.MailServerTimeoutVal;
            // �o�b�N�A�b�v���M�敪
            switch (mailSndMng.BackupSendDivCd)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BACKUPSENDDIVCD] = "���ЃA�h���X�Ƀo�b�N�A�b�v���M����";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BACKUPSENDDIVCD] = "���M���Ȃ�";
                        break;
                    }
            }
            // �o�b�N�A�b�v�`��
            switch (mailSndMng.BackupFormal)
            {
                case 0:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BACKUPFORMAL] = "���[���`��(BCC)";
                        break;
                    }
                case 1:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BACKUPFORMAL] = "�ꗗ�\�`��(�Ȉ�)";
                        break;
                    }
            }            
            // ���[�����M�����P�ʌ���
            if (mailSndMng.MailSendDivUnitCnt == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSENDDIVUNITCNT] = "�����������Ȃ�";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MAILSENDDIVUNITCNT] = mailSndMng.MailSendDivUnitCnt.ToString();
            }
            //GUID
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FILEHEADERGUID] = mailSndMng.FileHeaderGuid;

            // �C���X�^���X�e�[�u���ɂ��Z�b�g����
            if (this._mailSndMngTable.ContainsKey(mailSndMng.FileHeaderGuid) == true)
            {
                this._mailSndMngTable.Remove(mailSndMng.FileHeaderGuid);
            }
            this._mailSndMngTable.Add(mailSndMng.FileHeaderGuid, mailSndMng);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable mailSndMngTable = new DataTable(VIEW_TABLE);

            //// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            mailSndMngTable.Columns.Add(DELETE_DATE, typeof(string));               //�폜��            
            mailSndMngTable.Columns.Add(VIEW_SECTIONNAME, typeof(string));          //���_����
            mailSndMngTable.Columns.Add(VIEW_SENDERNAME, typeof(string));           //���o�l��
            mailSndMngTable.Columns.Add(VIEW_MAILADDRESS, typeof(string));          //���[���A�h���X
            mailSndMngTable.Columns.Add(VIEW_POP3USERID, typeof(string));           //POP3���[�U�[ID
            mailSndMngTable.Columns.Add(VIEW_POP3PASSWORD, typeof(string));         //POP3�p�X���[�h
            mailSndMngTable.Columns.Add(VIEW_POP3SERVERNAME, typeof(string));       //POP3�T�[�o�[��
            mailSndMngTable.Columns.Add(VIEW_SMTPSERVERNAME, typeof(string));       //SMTP�T�[�o�[��
            mailSndMngTable.Columns.Add(VIEW_SMTPAUTHUSEDIV, typeof(string));       //SMTP�F�؎g�p�敪
            mailSndMngTable.Columns.Add(VIEW_SMTPUSERID, typeof(string));           //SMTP���[�U�[ID
            mailSndMngTable.Columns.Add(VIEW_SMTPPASSWORD, typeof(string));         //SMTP�p�X���[�h
            mailSndMngTable.Columns.Add(VIEW_POPBEFORESMTPUSEDIV, typeof(string));  //POP Before SMTP�g�p�敪
            mailSndMngTable.Columns.Add(VIEW_POPSERVERPORTNO, typeof(int));         //POP�T�[�o�[ �|�[�g�ԍ�
            mailSndMngTable.Columns.Add(VIEW_SMTPSERVERPORTNO, typeof(int));        //SMTP�T�[�o�[ �|�[�g�ԍ�
            mailSndMngTable.Columns.Add(VIEW_MAILSERVERTIMEOUTVAL, typeof(int));    //���[���T�[�o�[�^�C���A�E�g�l
            mailSndMngTable.Columns.Add(VIEW_BACKUPSENDDIVCD, typeof(string));      //�o�b�N�A�b�v���M�敪
            mailSndMngTable.Columns.Add(VIEW_BACKUPFORMAL, typeof(string));         //�o�b�N�A�b�v�`��
            mailSndMngTable.Columns.Add(VIEW_MAILSENDDIVUNITCNT, typeof(string));   //���[�����M�����P�ʌ���
            mailSndMngTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));         //GUID

            this.Bind_DataSet.Tables.Add(mailSndMngTable);
        }

		/// <summary>
		///	��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note			:	��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer		:	22013�v�ہ@����</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void ScreenInitialSetting()
        {
            #region 2006/11/06 Del
            // ���Џ����敪
            //CompanySignAttachCd_tComboEditor.Clear();
            //CompanySignAttachCd_tComboEditor.Items.Add(0,"�Y�t���Ȃ�");
            //CompanySignAttachCd_tComboEditor.Items.Add(1,"�Y�t����");
            //CompanySignAttachCd_tComboEditor.MaxDropDownItems = CompanySignAttachCd_tComboEditor.Items.Count;
			
            //// �_�C�A���A�b�v�敪
            //DialUpCode_tComboEditor.Clear();
            //DialUpCode_tComboEditor.Items.Add(0,"�_�C�A��");
            //DialUpCode_tComboEditor.Items.Add(1,"LAN");
            #endregion
            // Edit�n�N���A
			EditClear("","0");
        }

        #region 2006.11.06 �폜
        /*
		/// <summary>
		/// ��ʏ��˃��[�����M�Ǘ��ݒ�N���X�i�[����
		/// </summary>
		/// <remarks>
		/// <br>Note		:	��ʏ�񂩂烁�[�����M�Ǘ��ݒ�N���X�Ƀf�[�^���i�[���܂�</br>
		/// <br>Programmer	:	22013  �v�ہ@����</br>
		/// <br>Date		:   2005.4.26</br>
		/// </remarks>
		private void ScreenToMailSndMng( ref MailSndMng copyMailSndMng)
		{
			if (copyMailSndMng == null)
			{
				// �V�K�̏ꍇ
				copyMailSndMng = new MailSndMng();
			}

			// �w�b�_��
//			copyMailSndMng.FileHeaderGuid = System.Guid.NewGuid();
			// e-mail���M�Ǘ��ԍ��i�[���Œ�j
			copyMailSndMng.MailSendMngNo = 0;
            //// ���Џ����Y�t�敪
            //copyMailSndMng.CompanySignAttachCd = Convert.ToInt32(this.CompanySignAttachCd_tComboEditor.SelectedItem.DataValue);
            //// �����t�@�C���p�X
            //if (!this.AttachFilePath_tEdit.DataText.Equals(""))
            //{
            //    copyMailSndMng.AttachFilePath = this.AttachFilePath_tEdit.DataText + ".txt"; 
            //}
            //else
            //{ 
            //    copyMailSndMng.AttachFilePath = HTML_UNREGISTER;	
            //}
            //// ���[�������ő�T�C�Y
            //if (!this.MailDocMaxSize_tNedit.DataText.Equals(""))
            //{
            //    copyMailSndMng.MailDocMaxSize = this.MailDocMaxSize_tNedit.GetInt();
            //}
            //else
            //{
            //    copyMailSndMng.MailDocMaxSize = 0;
            //}
            //// ���[�������s�ő�T�C�Y
            //if (!this.MailLineStrMaxSize_tNedit.DataText.Equals(""))
            //{
            //    copyMailSndMng.MailLineStrMaxSize = this.MailLineStrMaxSize_tNedit.GetInt();
            //}
            //else
            //{
            //    copyMailSndMng.MailDocMaxSize = 0;
            //}
            //// �g�у��[�������ő�T�C�Y
            //if (!this.PMailDocMaxSize_tNedit.DataText.Equals(""))
            //{
            //    copyMailSndMng.PMailDocMaxSize = this.PMailDocMaxSize_tNedit.GetInt();
            //}
            //else
            //{
            //    copyMailSndMng.PMailDocMaxSize = 0;
            //}
            //// ���[�������s�ő�T�C�Y
            //if (!this.PMailLineStrMaxSize_tNedit.DataText.Equals(""))
            //{
            //    copyMailSndMng.PMailLineStrMaxSize = this.PMailLineStrMaxSize_tNedit.GetInt();
            //}
            //else
            //{
            //    copyMailSndMng.PMailDocMaxSize = 0;
            //}            
            //// �_�C�A���A�b�v�敪
            //copyMailSndMng.DialUpCode = Convert.ToInt32(this.DialUpCode_tComboEditor.SelectedItem.DataValue);
            //// �_�C�A���A�b�v�ڑ�����
            //if (!this.DialUpConnectName_tEdit.DataText.Equals(""))
            //{
            //    copyMailSndMng.DialUpConnectName = this.DialUpConnectName_tEdit.DataText;
            //}
            //else
            //{
            //    copyMailSndMng.DialUpConnectName = HTML_UNREGISTER;
            //}
            //// �_�C�A���A�b�v���O�C����
            //if (!this.DialUpLoginName_tEdit.DataText.Equals(""))
            //{
            //    copyMailSndMng.DialUpLoginName = this.DialUpLoginName_tEdit.DataText;
            //}
            //else
            //{
            //    copyMailSndMng.DialUpLoginName = HTML_UNREGISTER;
            //}
            //// �_�C�A���A�b�v�p�X���[�h
            //if (!this.DialUpPassword_tEdit.DataText.Equals(""))
            //{
            //    copyMailSndMng.DialUpPassword = this.DialUpPassword_tEdit.DataText;
            //}
            //else
            //{
            //    copyMailSndMng.DialUpPassword = HTML_UNREGISTER;
            //}
            //// �ڑ���d�b�ԍ��i���g�p�j
            //copyMailSndMng.AccessTelNo = "";

            // ���o�l��
            if (!this.SenderName_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.SenderName = this.SenderName_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.SenderName = HTML_UNREGISTER;
            }
            // ���[���A�h���X
            if (!this.MailAddress_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.MailAddress = this.MailAddress_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.MailAddress = HTML_UNREGISTER;
            }
			// POP3���[�U�[ID
			if (!this.Pop3UserId_tEdit.DataText.Equals(""))
			{
				copyMailSndMng.Pop3UserId = this.Pop3UserId_tEdit.DataText;
			}
			else
			{
				copyMailSndMng.Pop3UserId = HTML_UNREGISTER;
			}
			// POP3�p�X���[�h
			if (!this.Pop3Password_tEdit.DataText.Equals(""))
			{
				copyMailSndMng.Pop3Password = this.Pop3Password_tEdit.DataText;
			}
			else
			{
				copyMailSndMng.Pop3Password = HTML_UNREGISTER;
			}
            // POP3�T�[�o�[��
            if (!this.Pop3ServerName_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.Pop3ServerName = this.Pop3ServerName_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.Pop3ServerName = HTML_UNREGISTER;
            }
            // SMTP�T�[�o�[��
            if (!this.SmtpServerName_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.SmtpServerName = this.SmtpServerName_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.SmtpServerName = HTML_UNREGISTER;
            }
            // SMTP�F�؎g�p�敪
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                if (this.SmtpAuthUseDiv1_radioButton.Checked)
                {
                    // SMTP�F�؎g�p�敪 1:POP3�F�؂Ɠ���ID�E�p�X���[�h���g�p
                    copyMailSndMng.SmtpAuthUseDiv = 1;
                }
                else if (this.SmtpAuthUseDiv2_radioButton.Checked)
                {
                    // SMTP�F�؎g�p�敪 2:SMTP�F�؂�ID�E�p�X���[�h���g�p
                    copyMailSndMng.SmtpAuthUseDiv = 2;
                }
                else if (this.PopBeforeSmtpUseDiv_radioButton.Checked)
                {
                    // POP Before SMTP�g�p�敪 1:�g�p����
                    copyMailSndMng.PopBeforeSmtpUseDiv = 1;
                }
            }
            else
            {
                // SMTP�F�؎g�p�敪 0:�g�p���Ȃ�
                copyMailSndMng.SmtpAuthUseDiv = 0;
                // POP Before SMTP�g�p�敪 0:�g�p���Ȃ�
                copyMailSndMng.PopBeforeSmtpUseDiv = 0;
            }
            // SMTP���[�U�[ID
            if (!this.SmtpUserId_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.SmtpUserId = this.SmtpUserId_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.SmtpUserId = HTML_UNREGISTER;
            }
            // SMTP�p�X���[�h
            if (!this.SmtpPassword_tEdit.DataText.Equals(""))
            {
                copyMailSndMng.SmtpPassword = this.SmtpPassword_tEdit.DataText;
            }
            else
            {
                copyMailSndMng.SmtpPassword = HTML_UNREGISTER;
            }
            // POP�T�[�o�[�|�[�g�ԍ�
            if (this.PopServerPortNo_tNedit.GetInt() != 0)
            {
                copyMailSndMng.PopServerPortNo = this.PopServerPortNo_tNedit.GetInt();
            }
            else
            {
                copyMailSndMng.PopServerPortNo = 0;
            }
            // SMTP�T�[�o�[�|�[�g�ԍ�
            if (this.SmtpServerPortNo_tNedit.GetInt() != 0)
            {
                copyMailSndMng.SmtpServerPortNo = this.SmtpServerPortNo_tNedit.GetInt();
            }
            else
            {
                copyMailSndMng.SmtpServerPortNo = 0;
            }
            // ���[���T�[�o�[�^�C���A�E�g�l
            if (this.MailServerTimeoutVal_tNedit.GetInt() != 0)
            {
                copyMailSndMng.MailServerTimeoutVal = this.MailServerTimeoutVal_tNedit.GetInt();
            }
            else
            {
                copyMailSndMng.MailServerTimeoutVal = 0;
            }
            // �o�b�N�A�b�v���M�敪 TODO
            if (this.BackupSendDivCd_ultraCheckEditor.Checked)
            {
                // �o�b�N�A�b�v���M�敪 0:���ЃA�h���X�Ƀo�b�N�A�b�v���M����
                copyMailSndMng.BackupSendDivCd = 0;
            }
            else
            {
                // �o�b�N�A�b�v���M�敪 1:���M���Ȃ�
                copyMailSndMng.BackupSendDivCd = 1;
            }
            // �o�b�N�A�b�v�`�� 0:���[���`��(BCC) ���݂����g�p���Ȃ�
            copyMailSndMng.BackupFormal = 0;
            // ���[�����M�����P�ʌ���
            if (this.MailSendDivUnitCnt_ultraCheckEditor.Checked)
            {
                // ���[�����M�����P�ʌ���
                copyMailSndMng.MailSendDivUnitCnt = this.MailServerTimeoutVal_tNedit.GetInt();
            }
            else
            {
                // ���[�����M�����P�ʌ��� 0:�����������Ȃ�
                copyMailSndMng.MailSendDivUnitCnt = 0;
            }
		}
        */
        #endregion
        
        #region 2006.11.06 �폜
        /*
		/// <summary>
		///	���[�����M�Ǘ��ݒ�ݒ��ʓW�J����
		/// </summary>
		/// <remarks>
		/// <br>Note			:	���[�����M�Ǘ��ݒ�ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer		:	22013  �v�ہ@����</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void MailSndMngToScreen()
		{
			//this.CompanySignAttachCd_tComboEditor.Value = mailSndMng.CompanySignAttachCd;			// ���Џ����Y�t�敪
//			this.AttachFilePath_tEdit.DataText = mailSndMng.AttachFilePath;							// �����t�@�C���p�X
			//this.AttachFilePath_tEdit.DataText = RemovalExtensions(mailSndMng.AttachFilePath);		// �����t�@�C���p�X�i�g���q�폜��j
			//bool setEnabled = IsSetAttachFilePathEnabled(mailSndMng.CompanySignAttachCd);			// ��ʕ\�����{�^����Enabled��ݒ�
//			this.AttachFilePath_tEdit.Enabled = setEnabled;											// �����t�@�C���p�XEnabled�ݒ�
            //this.AttachFilePath_GuidUButton.Enabled = setEnabled;									// �����t�@�C���p�X�K�C�h�{�^��Enabled�ݒ�
            //this.MailDocMaxSize_tNedit.DataText = mailSndMng.MailDocMaxSize.ToString();				// ���[�������ő�T�C�Y
            //this.MailLineStrMaxSize_tNedit.DataText = mailSndMng.MailLineStrMaxSize.ToString();		// ���[�������s�����ő�T�C�Y
            //this.PMailDocMaxSize_tNedit.DataText = mailSndMng.PMailDocMaxSize.ToString();			// �g�у��[�������ő�T�C�Y
            //this.PMailLineStrMaxSize_tNedit.DataText = mailSndMng.PMailLineStrMaxSize.ToString();	// �g�у��[�������s�����ő�T�C�Y
			this.MailAddress_tEdit.DataText = mailSndMng.MailAddress;       						// ���[���A�h���X
            //this.DialUpCode_tComboEditor.Value = mailSndMng.DialUpCode;								// �_�C�A���A�b�v�敪
            //this.DialUpConnectName_tEdit.DataText = mailSndMng.DialUpConnectName;					// �_�C�A���A�b�v�ڑ�����
            //this.DialUpLoginName_tEdit.DataText = mailSndMng.DialUpLoginName;						// �_�C�A���A�b�v���O�C����	
            //this.DialUpPassword_tEdit.DataText = mailSndMng.DialUpPassword;							// �_�C�A���A�b�v�p�X���[�h
			this.Pop3UserId_tEdit.DataText = mailSndMng.Pop3UserId;									// POP3���[�U�[��
			this.Pop3Password_tEdit.DataText = mailSndMng.Pop3Password;								// POP3�p�X���[�h
            this.Pop3ServerName_tEdit.DataText = mailSndMng.Pop3ServerName;							// POP3�T�[�o�[��
            this.SmtpServerName_tEdit.DataText = mailSndMng.SmtpServerName;							// SMTP�T�[�o�[��
            this.SmtpUserId_tEdit.DataText = mailSndMng.SmtpUserId;							// SMTP�T�[�o�[��
            this.SmtpPassword_tEdit.DataText = mailSndMng.SmtpPassword;							// SMTP�T�[�o�[��
            //this.SmtpAuthUseDiv_ultraComboEditor.Value = mailSndMng.SmtpAuthUseDiv;							// SMTP�T�[�o�[��
            if (mailSndMng.SmtpAuthUseDiv == 0)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = false;
            }
            else
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                if (mailSndMng.SmtpAuthUseDiv == 1)
                {
                    this.SmtpAuthUseDiv1_radioButton.Checked = true;
                }
                else if (mailSndMng.SmtpAuthUseDiv == 2)
                {
                    this.SmtpAuthUseDiv2_radioButton.Checked = true;
                }
                else if (mailSndMng.PopBeforeSmtpUseDiv == 1)
                {
                    this.PopBeforeSmtpUseDiv_radioButton.Checked = true;
                }
            }
            //this.SmtpAuthUseDiv_ultraComboEditor.Value = mailSndMng.SmtpAuthUseDiv;							// SMTP�T�[�o�[��
            this.SenderName_tEdit.DataText = mailSndMng.SenderName;									// ���o�l��			
            //this.PopBeforeSmtpUseDiv_ultraComboEditor.Value = mailSndMng.PopBeforeSmtpUseDiv;
            this.PopServerPortNo_tNedit.SetInt(mailSndMng.PopServerPortNo);
            this.SmtpServerPortNo_tNedit.SetInt(mailSndMng.SmtpServerPortNo);
            this.MailServerTimeoutVal_tNedit.SetInt(mailSndMng.MailServerTimeoutVal);
            if (mailSndMng.BackupSendDivCd == 0)
            {
                this.BackupSendDivCd_ultraCheckEditor.Checked = true;
            }
            else
            {
                this.BackupSendDivCd_ultraCheckEditor.Checked = false;
            }
            //this.BackupSendDivCd_ultraComboEditor.Value = mailSndMng.BackupSendDivCd;
            this.BackupFormal_ultraComboEditor.Value = mailSndMng.BackupFormal;
            if (mailSndMng.MailSendDivUnitCnt == 0)
            {
                this.MailSendDivUnitCnt_ultraCheckEditor.Checked = false;
            }
            else
            {
                this.MailSendDivUnitCnt_tNedit.SetInt(mailSndMng.MailSendDivUnitCnt);
            }
            //this.MailSendDivUnitCnt_ultraComboEditor.Value = mailSndMng.MailSendDivUnitCnt;
		}
        */
        #endregion

        /// <summary>
		/// �G�f�B�b�g�{�b�N�X����������
		/// </summary>
		/// <param name="tEditValue">tEdit�ɑ������l</param>
		/// <param name="tNEditValue">tNEdit�ɑ������l</param>
		/// <remarks>
		/// <br>Note		:	TEdit,TNEdit�����������܂�</br>
		/// <br>Programmer	:	22013  �v�ہ@����</br>
		/// <br>Date		:   2005.4.26</br>
		/// </remarks>
		private void EditClear(string tEditValue, string tNEditValue)
		{
			MailAddress_tEdit.DataText      = tEditValue;				// ���[���A�h���X
			Pop3UserId_tEdit.DataText       = tEditValue;				// POP3���[�U�[ID
			Pop3Password_tEdit.DataText     = tEditValue;				// POP3�p�X���[�h
            Pop3ServerName_tEdit.DataText   = tEditValue;				// POP3�T�[�o�[��
            SmtpServerName_tEdit.DataText   = tEditValue;				// SMTP�T�[�o�[��
            SmtpUserId_tEdit.DataText       = tEditValue;               // SMTP���[�U�[ID
            SmtpPassword_tEdit.DataText     = tEditValue;               // SMTP�p�X���[�h
            SenderName_tEdit.DataText       = tEditValue;				// ���o�l��						
		}

		/// <summary>
		/// ��ʃN���A�[����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʂ��N���A�[���܂�</br>
		/// <br>Programmer	: 22013�@�v�ہ@����</br>
		/// <br>Date		: 2005.04.26</br>
		/// </remarks>
		private void ScreenClear()
		{            
            this.BackupFormal_tComboEditor.SelectedIndex = 0;

			EditClear("","");									// Edit�n�N���A
            this.PopServerPortNo_tNedit.SetInt(0);
            this.SmtpServerPortNo_tNedit.SetInt(0);
            this.MailServerTimeoutVal_tNedit.SetInt(0);
            this.MailServerTimeoutVal_tNedit.SetInt(0);
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 22013 �v�ہ@����</br>
		/// <br>Date       : 2005.04.26</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            if (this.DataIndex < 0)
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
                
                //_dataIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                MailSndMng mailSndMng = (MailSndMng)this._mailSndMngTable[guid];                

                if (mailSndMng.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    this.Ok_Button.Visible = true;
                    this.Close_Button.Visible = true;

                    ScreenInputPermissionControl(true);
                    
                    // ���o�l��
                    this.SenderName_tEdit.Focus();
                    // ��ʓW�J����
                    MailSndMngToScreen(mailSndMng);                    

                    // �N���[���쐬
                    this.mailSndMngClone = mailSndMng.Clone();
                    DispToMailSndMng(ref this.mailSndMngClone);
                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;

                    this.SenderName_tEdit.Focus();
                    this.SenderName_tEdit.SelectAll();
                }                
            }            
		}

        /// <summary>
        /// ��ʏ�񃁁[�����M�Ǘ��ݒ�N���X�i�[����
        /// </summary>
        /// <param name="mailSndMng">���[�����M�Ǘ��ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂烁�[�����M�Ǘ��ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void DispToMailSndMng(ref MailSndMng mailSndMng)
        {
            if (mailSndMng == null)
            {
                // �V�K�̏ꍇ
                mailSndMng = new MailSndMng();
            }

            // �e���ڂ̃Z�b�g
            mailSndMng.EnterpriseCode = this.enterpriseCode;			// �� �v�ύX
            // ���_�R�[�h
            mailSndMng.SectionCode = this.SectionCode_tEdit.Text;
            
            // e-mail���M�Ǘ��ԍ�
            mailSndMng.MailSendMngNo = 0; //0�Œ�
            // ���o�l��
            mailSndMng.SenderName = this.SenderName_tEdit.Text;
            // ���[���A�h���X
            mailSndMng.MailAddress = this.MailAddress_tEdit.Text;
            // POP3���[�U�[ID
            mailSndMng.Pop3UserId = this.Pop3UserId_tEdit.Text;
            // POP3�p�X���[�h
            mailSndMng.Pop3Password = this.Pop3Password_tEdit.Text;
            // POP3�T�[�o�[��
            mailSndMng.Pop3ServerName = this.Pop3ServerName_tEdit.Text;
            // SMTP�T�[�o�[��
            mailSndMng.SmtpServerName = this.SmtpServerName_tEdit.Text;
            // SMTP�F�؎g�p�敪
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked)
            {
                if (this.SmtpAuthUseDiv1_radioButton.Checked)
                {
                    mailSndMng.SmtpAuthUseDiv = 1; //POP�F�؂Ɠ���ID�E�p�X���[�h���g�p
                    mailSndMng.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP �g�p���Ȃ�
                }
                else if (this.SmtpAuthUseDiv2_radioButton.Checked)
                {
                    mailSndMng.SmtpAuthUseDiv = 2; //SMTP�F�؂�ID�E�p�X���[�h���g�p
                    mailSndMng.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP �g�p���Ȃ�
                }
                if (this.PopBeforeSmtpUseDiv_radioButton.Checked)
                {
                    mailSndMng.SmtpAuthUseDiv = 0;      //SMTP�F�؎g�p���Ȃ�
                    mailSndMng.PopBeforeSmtpUseDiv = 1; //�g�p����                    
                }
            }
            else
            {
                mailSndMng.SmtpAuthUseDiv = 0; //SMTP�F�؎g�p���Ȃ�
                mailSndMng.PopBeforeSmtpUseDiv = 0; //POP Berfore SMTP �g�p���Ȃ�
            }
            if (this.SmtpAuthUseDiv_ultraCheckEditor.Checked && this.SmtpAuthUseDiv1_radioButton.Checked)
            {
                // SMTP���[�U�[ID
                mailSndMng.SmtpUserId = this.Pop3UserId_tEdit.Text;
                // SMTP�p�X���[�h
                mailSndMng.SmtpPassword = this.Pop3Password_tEdit.Text;
            }
            else
            {
                // SMTP���[�U�[ID
                mailSndMng.SmtpUserId = this.SmtpUserId_tEdit.Text;
                // SMTP�p�X���[�h
                mailSndMng.SmtpPassword = this.SmtpPassword_tEdit.Text;
            }
            // POP�T�[�o�[�|�[�g�ԍ�
            mailSndMng.PopServerPortNo = this.PopServerPortNo_tNedit.GetInt();
            // SMTP�T�[�o�[�|�[�g�ԍ�
            mailSndMng.SmtpServerPortNo = this.SmtpServerPortNo_tNedit.GetInt();
            // ���[���T�[�o�[�^�C���A�E�g�l
            mailSndMng.MailServerTimeoutVal = this.MailServerTimeoutVal_tNedit.GetInt();
            // �o�b�N�A�b�v���M�敪
            if (this.BackupSendDivCd_ultraCheckEditor.Checked)
            {
                mailSndMng.BackupSendDivCd = 0; //���ЃA�h���X�Ƀo�b�N�A�b�v���M����
            }
            else
            {
                mailSndMng.BackupSendDivCd = 1; //���M���Ȃ�
            }
            // �o�b�N�A�b�v�`��
            mailSndMng.BackupFormal = 0; //���[���`��(BCC)�����̓[���Œ�
            // ���[�����M�����P�ʌ���
            if (this.MailSendDivUnitCnt_ultraCheckEditor.Checked)
            {
                mailSndMng.MailSendDivUnitCnt = this.MailSendDivUnitCnt_tNedit.GetInt(); //������������P�ʌ���
            }
            else
            {
                mailSndMng.MailSendDivUnitCnt = 0; //�����������Ȃ�
            }
        }

        /// <summary>
        /// ���[�����M�Ǘ��ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="mailSndMng">���[�����M�Ǘ��ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[�����M�Ǘ��ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void MailSndMngToScreen(MailSndMng mailSndMng)
        {
            // �e���ڂ̃Z�b�g
            // ���_�R�[�h
            this.SectionCode_tEdit.Text = mailSndMng.SectionCode;
            // ���_����
            string sectionName;
            int st = this._mailSndMngAcs.ReadSectionName(out sectionName, this.enterpriseCode, mailSndMng.SectionCode);
            if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SectionName_tEdit.Text = sectionName;
            }
            else
            {
                TMsgDisp.Show(this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                "SMDML09060U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                                "���_���̎擾�Ɏ��s���܂����B",      // �\�����郁�b�Z�[�W 
                                st,								// �X�e�[�^�X�l
                                MessageBoxButtons.OK);				// �\������{�^��
            }            
            // ���o�l��
            this.SenderName_tEdit.Text = mailSndMng.SenderName;
            // ���[���A�h���X
            this.MailAddress_tEdit.Text = mailSndMng.MailAddress;
            // POP3���[�U�[ID
            this.Pop3UserId_tEdit.Text = mailSndMng.Pop3UserId;
            // POP3�p�X���[�h
            this.Pop3Password_tEdit.Text = mailSndMng.Pop3Password;
            // POP3�T�[�o�[��
            this.Pop3ServerName_tEdit.Text = mailSndMng.Pop3ServerName;
            // SMTP�T�[�o�[��
            this.SmtpServerName_tEdit.Text = mailSndMng.SmtpServerName;
            // SMTP�F�؎g�p�敪
            if (mailSndMng.SmtpAuthUseDiv == 1) //1:Pop�F�؂Ɠ���ID�E�p�X���[�h
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            else if (mailSndMng.SmtpAuthUseDiv == 2) //2:SMTP�F�؂�ID�E�p�X���[�h
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = false;
                this.SmtpAuthUseDiv2_radioButton.Checked = true;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            else
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = false;
                this.SmtpAuthUseDiv1_radioButton.Checked = true;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = false;
            }
            // POP Before SMTP �g�p�敪
            if (mailSndMng.PopBeforeSmtpUseDiv == 1)
            {
                this.SmtpAuthUseDiv_ultraCheckEditor.Checked = true;
                this.SmtpAuthUseDiv1_radioButton.Checked = false;
                this.SmtpAuthUseDiv2_radioButton.Checked = false;
                this.PopBeforeSmtpUseDiv_radioButton.Checked = true;
            }
            // SMTP���[�U�[ID
            this.SmtpUserId_tEdit.Text = mailSndMng.SmtpUserId;
            // SMTP�p�X���[�h
            this.SmtpPassword_tEdit.Text = mailSndMng.SmtpPassword;
            // POP�T�[�o�[�|�[�g�ԍ�            
            this.PopServerPortNo_tNedit.SetInt(mailSndMng.PopServerPortNo);
            // SMTP�T�[�o�[�|�[�g�ԍ�
            this.SmtpServerPortNo_tNedit.SetInt(mailSndMng.SmtpServerPortNo);
            // ���[���T�[�o�[�^�C���A�E�g�l
            this.MailServerTimeoutVal_tNedit.SetInt(mailSndMng.MailServerTimeoutVal);
            // �o�b�N�A�b�v���M�敪
            if (mailSndMng.BackupSendDivCd == 0)
            {
                this.BackupSendDivCd_ultraCheckEditor.Checked = true;
            }
            else
            {
                this.BackupSendDivCd_ultraCheckEditor.Checked = false;
            }
            // �o�b�N�A�b�v�`��
            // ���[�����M�����P�ʌ���
            if (mailSndMng.MailSendDivUnitCnt == 0)
            {
                this.MailSendDivUnitCnt_ultraCheckEditor.Checked = false;
                this.MailSendDivUnitCnt_tNedit.SetInt(0);
            }
            else
            {
                this.MailSendDivUnitCnt_ultraCheckEditor.Checked = true;
                this.MailSendDivUnitCnt_tNedit.SetInt(mailSndMng.MailSendDivUnitCnt);
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="enabled">���͋��ݒ�l</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {                        
            this.SenderName_tEdit.Enabled = enabled;
            this.MailAddress_tEdit.Enabled = enabled;
            this.Pop3UserId_tEdit.Enabled = enabled;
            this.Pop3Password_tEdit.Enabled = enabled;
            this.Pop3ServerName_tEdit.Enabled = enabled;
            this.SmtpServerName_tEdit.Enabled = enabled;
            this.SmtpAuthUseDiv_ultraCheckEditor.Enabled = enabled;
            this.PopServerPortNo_tNedit.Enabled = enabled;
            this.SmtpServerPortNo_tNedit.Enabled = enabled;
            this.MailServerTimeoutVal_tNedit.Enabled = enabled;
            this.BackupSendDivCd_ultraCheckEditor.Enabled = enabled;
            this.MailSendDivUnitCnt_ultraCheckEditor.Enabled = enabled;
        }

        #region 2006.11.06 Maki Del
        /*
		/// <summary>
		/// �����t�@�C���p�XEnabled�ݒ�֐�
		/// </summary>
		/// <param name="attatchFilePathCode">���Џ����Y�t�敪</param>
		/// <returns>attachFilePathCode{1 : true | 1�ȊO : false}</returns>
		/// <remarks>
		/// <br>Note		: ���Џ����Y�t�敪�ɑ΂���A�����t�@�C���p�X��Enabled��ݒ肵�܂��B</br>
		/// <br>Programmer	: 22013  �v�ہ@����</br>
		/// <br>Date		: 2005.04.27</br>
		/// </remarks>
		private bool IsSetAttachFilePathEnabled(int attatchFilePathCode)
		{
			switch(attatchFilePathCode)
			{
				case 1:
				{
					// ���M����Ƃ�
					return true;
				}
				default:
				{
					// ���M���Ȃ��A�܂��͂���ȊO�̒l�������Ă����Ƃ�
					return false;
				}
			}
		}
        */
        #endregion

        /// <summary>
		/// OK_Button_Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ۑ��{�^���N���b�N�C�x���g</br>
		/// <br>Programmer	: 22013�@�v�ہ@����</br>
		/// <br>Date		: 2005.05.02</br>
		/// <br></br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// �ۑ��O�f�[�^�`�F�b�N
			if ( !IsValueCheck() )
			{
				// �`�F�b�N�m�f�̏ꍇ�����I��
				return;
			}
			// �f�[�^�ۑ�
			if ( !IsSaveProc() )
			{
				// �ۑ��Ɏ��s�����Ƃ��͏����I��
				return;
			}

            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // �f�[�^�C���f�b�N�X������������
                this.DataIndex = -1;

                // ��ʃN���A����
                ScreenClear();

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;
            }
            else
            {
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
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SATRT
			//this.mailSndMngClone = null;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		}
        
		/// <summary>
		/// �ۑ��O�f�[�^�`�F�b�N���\�b�h
		/// </summary>
		/// <returns>�`�F�b�N���ʁotrue : �`�F�b�N�n�j | false : �`�F�b�N�m�f�p</returns>
		/// <remarks>
		/// <br>Note		: �ۑ��O�f�[�^�`�F�b�N���\�b�h</br>
		/// <br>Programmer	: 22013�@�v�ہ@����</br>
		/// <br>Date		: 2005.05.02</br>
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
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFDML09060U",							// �A�Z���u��ID
						errorMsg,	                        �@�@// �\�����郁�b�Z�[�W
						0,   									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

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
		/// <br>Programmer	: 22013  �v�ہ@����</br>
		/// <br>Date		: 2005.05.02</br>
		/// <br></br>
		/// </remarks>
		private bool IsSaveProc()
        {
            #region 2006.11.06 Maki Del
            /*
			// ��ʏ��̃Z�b�g
			ScreenToMailSndMng(ref this.mailSndMng);

			int status = this.mailSndMngAcs.Write(ref this.mailSndMng);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				
				// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					ExclusiveTransaction(status);
					
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή���ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this.mailSndMngClone = null;
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή���ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.08 �G���[���b�Z�[�W���o����UI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> STRAT
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.08 �G���[���b�Z�[�W���o����UI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
					return false;
				}
				// 2005.07.06 �r�����䏈���@�r�������������Ƃ��Astatus��\�����Ȃ��悤�C�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFDML09060U",							// �A�Z���u��ID
						"���[�����M�Ǘ��ݒ�",                   // �v���O��������
						"IsSaveProc",                           // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this.mailSndMngAcs,				     	// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή���ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this.mailSndMngClone = null;
					// 2005.07.11 �r�����䏈���̒��ɍŏ����Ή���ǉ� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.08 �G���[���b�Z�[�W���o����UI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> STRAT
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.08 �G���[���b�Z�[�W���o����UI��ʂ���鏈�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END	
					return false;
				}
			}
			DialogResult dialogResult = DialogResult.OK;
			
			Mode_Label.Text = UPDATE_MODE;
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = dialogResult;

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
			return true;
            */
            //Control control = null;
            //string message = null;
            //string loginID = "";
            //Infragistics.Win.UltraWinTabControl.UltraTab selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
            #endregion

            MailSndMng mailSndMng = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_FILEHEADERGUID];
                mailSndMng = ((MailSndMng)this._mailSndMngTable[guid]).Clone();
            }
            
            this.DispToMailSndMng(ref mailSndMng);

            int status = this._mailSndMngAcs.Write(ref mailSndMng);

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
                            "SMDML09060U",						// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            "SFDML09060U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���[�����M�Ǘ��ݒ�",							// �v���O��������
                            "IsSaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._mailSndMngAcs,					// �G���[�����������I�u�W�F�N�g
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
            MailSndMngToDataSet(mailSndMng, this.DataIndex);

            return true;

		}
		/// <summary>
		/// �G���[�`�F�b�N����
		/// </summary>
		/// <param name="errorMsg">�G���[���b�Z�[�W�i�[�p�ϐ��i�󂯎�莞�͋�j</param>
		/// <returns>�t�H�[�J�X���Z�b�g����R���|�[�l���g</returns>
		/// <remarks>
		/// <br>Note		: �R���|�[�l���g�Ƀt�H�[�J�X���Z�b�g���܂��B</br>
		/// <br>Programmer	: 22013�@�v�ہ@����</br>
		/// <br>Date		; 2005.05.11</br>
		/// <br></br>
		/// </remarks>
		private int CheckError(ref string errorMsg)
        {
            #region 2006.11.02 Maki �폜
            // ������r�p
            //int mailDocMaxSizeNum = TStrConv.StrToIntDef(this.MailDocMaxSize_tNedit.DataText,0);
            //int mailLineStrMaxSizeNum = TStrConv.StrToIntDef(this.MailLineStrMaxSize_tNedit.DataText,0);
            //int pMailDocMaxSizeNum = TStrConv.StrToIntDef(this.PMailDocMaxSize_tNedit.DataText,0);
            //int pMailLineStrMaxSizeNum = TStrConv.StrToIntDef(this.PMailLineStrMaxSize_tNedit.DataText,0);

			            
            //// ���Џ����Y�t�敪���Y�t����̏ꍇ
            //if ( (int)CompanySignAttachCd_tComboEditor.SelectedItem.DataValue == 1 ) 
            //{
            //    // �����t�@�C�������󔒂͂���
            //    if ( CompanySignAttachCd_tComboEditor.SelectedItem.DisplayText.Trim().Equals("") )
            //    {
            //        errorMsg = "�����t�@�C�����̂���͂��Ă��������B";
            //        setFocusNum = 11;
            //    }
            //}
            //    // ���[�������ő�T�C�Y���[���̂Ƃ�
            //else if ( mailDocMaxSizeNum == 0)
            //{
            //    errorMsg = "�T�C�Y��ݒ肵�Ă��������B";
            //    setFocusNum = 20;
            //}
            //    // ���[�������s�ő啶�������[���̂Ƃ�
            //else if ( mailLineStrMaxSizeNum == 0 )
            //{
            //    errorMsg = "�T�C�Y��ݒ肵�Ă��������B";
            //    setFocusNum = 21;
            //}
            //    // �g�у��[�������ő�T�C�Y���[���̂Ƃ�
            //else if ( pMailDocMaxSizeNum == 0)
            //{
            //    errorMsg = "�T�C�Y��ݒ肵�Ă��������B";
            //    setFocusNum = 30;
            //}
            //    // �g�у��[�������s�ő啶�������[���̂Ƃ�
            //else if ( pMailLineStrMaxSizeNum == 0 )
            //{
            //    errorMsg = "�T�C�Y��ݒ肵�Ă��������B";
            //    setFocusNum = 30;
            //}
            //    // ���[�������s�ő啶�����͂V�Q�����܂�
            //else if ( TStrConv.StrToIntDef( this.MailLineStrMaxSize_tNedit.DataText, 99 ) > 72 )
            //{
            //    errorMsg = "�P�s�̕������͂V�Q�����܂łł��B";
            //    setFocusNum = 21;
            //}
            //    // �g�у��[�������s�ő啶�����͂V�Q�����܂�
            //else if ( TStrConv.StrToIntDef( this.PMailLineStrMaxSize_tNedit.DataText, 99 ) > 72 )
            //{
            //    errorMsg = "�P�s�̕������͂V�Q�����܂łł��B";
            //    setFocusNum = 31;
            //}
            //    // ���[�������ő�T�C�Y�I�[�o�[
            //else if ( TStrConv.StrToIntDef( this.MailDocMaxSize_tNedit.DataText, 99999) > 65536 )
            //{
            //    errorMsg = "���[�������̃T�C�Y�͍ő�U�T�T�R�U�����܂łł��B";
            //    setFocusNum = 20;
            //}
            //    // �g�у��[�������ő�T�C�Y�I�[�o�[
            //else if ( TStrConv.StrToIntDef( this.PMailDocMaxSize_tNedit.DataText, 99999) > 65536 )
            //{
            //    errorMsg = "���[�������̃T�C�Y�͍ő�U�T�T�R�U�����܂łł��B";
            //    setFocusNum = 30;
            //}
            //    // �P�s�̕��������ő�T�C�Y�𒴂��Ă���ꍇ�i�o�b�j
            //else if ( mailDocMaxSizeNum < mailLineStrMaxSizeNum )
            //{
            //    errorMsg = "���l���s���ł��B";
            //    setFocusNum = 20;
            //}
            //    // �P�s�̕��������ő�T�C�Y�𒴂��Ă���ꍇ�i�g�сj
            //else if ( pMailDocMaxSizeNum < pMailLineStrMaxSizeNum )
            //{
            //    errorMsg = "���l���s���ł��B";
            //    setFocusNum = 30;
            //}
            //    // ���[���A�h���X���ݒ肳��Ă��Ȃ��Ƃ���
            //else if ( this.MailAddress_tEdit.DataText.Equals("") )
            //{
            //    errorMsg = "���[���A�h���X��ݒ肵�Ă��������B";
            //    setFocusNum = 40;
            //}
            //    // ���o�l���̂Ƀ_�u���N�I�e�[�V�����i���E�S�p�j���܂܂�Ă���ꍇ
            //else if ( ( this.SenderName_tEdit.DataText.IndexOf('\"' ) != -1) ||
            //    ( SenderName_tEdit.DataText.IndexOf('�h' ) != -1) )
            //{
            //    errorMsg = "���o�l���̂Ɂu\"�v�͐ݒ�ł��܂���B";
            //    setFocusNum = 47;
            //}
#endregion

            // �t�H�[�J�X�Z�b�g����G�f�B�b�g�̔ԍ�
            int setFocusNum = 0;            

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
                errorMsg = "���[���A�h���X��ݒ肵�Ă��������B";
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
            // ���[�����M�����P�ʌ���
            if (this.MailSendDivUnitCnt_ultraCheckEditor.Checked)
            {
                if (this.MailSendDivUnitCnt_tNedit.GetInt() == 0)
                {
                    errorMsg = "��������������P�ʌ�������͂��Ă��������B";
                    setFocusNum = 10;
                    return setFocusNum;
                }
            }
            
			return setFocusNum;
		}
		/// <summary>
		/// �t�H�[�J�X�Z�b�g����
		/// </summary>
		/// <param name="setFocusNum">�t�H�[�J�X�Z�b�g����R���|�[�l���g�ԍ�</param>
		/// <remarks>
		/// <br>Note		: �R���|�[�l���g�Ƀt�H�[�J�X���Z�b�g���܂��B</br>
		/// <br>Programmer	: 22013�@�v�ہ@����</br>
		/// <br>Date		; 2005.05.11</br>
		/// <br></br>
		/// </remarks>
		private void SetFocusToComponent(int setFocusNum)
		{
			// �t�H�[�J�X�Z�b�g
			switch ( setFocusNum )
            {
                #region 2006.11.02 Maki �폜
                //    // ���Џ����敪
                //case 10:
                //{
                //    this.CompanySignAttachCd_tComboEditor.Focus();
                //    break;
                //}
                //    // �����t�@�C���p�X�K�C�h�{�^��
                //case 11:
                //{
                //    this.AttachFilePath_GuidUButton.Focus();
                //    break;
                //}
                //    // ���[�������ő�T�C�Y
                //case 20:
                //{
                //    this.MailDocMaxSize_tNedit.Focus();
                //    break;
                //}
                //    // ���[�������s�ő啶�����i�P�s������̕������j
                //case 21:
                //{
                //    this.MailLineStrMaxSize_tNedit.Focus();
                //    break;
                //}
                //    // �g�у��[�������ő�T�C�Y
                //case 30:
                //{
                //    this.PMailDocMaxSize_tNedit.Focus();
                //    break;
                //}
                //    // �g�у��[�������s�ő啶�����i�P�s������̕������j
                //case 31:
                //{
                //    this.PMailLineStrMaxSize_tNedit.Focus();
                //    break;
                //}
                //    // ���[���A�h���X
                //case 40:
                //{
                //    this.MailAddress_tEdit.Focus();
                //    break;
                //}
                //    // �_�C�A���A�b�v�敪
                //case 41:
                //{
                //    this.DialUpCode_tComboEditor.Focus();
                //    break;
                //}
                //    // �_�C�A���A�b�v�ڑ�����
                //case 42:
                //{
                //    this.DialUpConnectName_tEdit.Focus();
                //    break;
                //}
                //    // �_�C�A���A�b�v���O�C����
                //case 43:
                //{
                //    this.DialUpLoginName_tEdit.Focus();
                //    break;
                //}
                //    // �_�C�A���A�b�v�p�X���[�h
                //case 44:
                //{
                //    this.DialUpPassword_tEdit.Focus();
                //    break;
                //}
                //    // �o�n�o�R���[�U�[�h�c
                //case 45:
                //{
                //    this.Pop3UserId_tEdit.Focus();
                //    break;
                //}
                //    // �o�n�o�R�p�X���[�h
                //case 46:
                //{
                //    this.Pop3Password_tEdit.Focus();
                //    break;
                //}
                //    // ���o�l��
                //case 47:
                //{
                //    this.SenderName_tEdit.Focus();
                //    break;
                //}
                //    // �o�n�o�R�T�[�o�[��
                //case 48:
                //{
                //    this.Pop3ServerName_tEdit.Focus();
                //    break;
                //}
                //    // �r�l�s�o�T�[�o�[��
                //case 49:
                //{
                //    this.SmtpServerName_tEdit.Focus();
                //    break;
                //}
                //    // ELSE
                //default:
                //{
                //    break;
                //}
                #endregion
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
                        // ������������P�ʌ���
                        this.MailSendDivUnitCnt_tNedit.Focus();
                        break;
                    }                
                default:
                    {
                        break;
                    }
			}
        }

        #region 2006/11/06 Maki Del
        /*
		/// <summary>
		/// �g���q�폜�����i.txt��p�j
		/// </summary>
		/// <param name="removalString">�g���q���������镶����</param>
		/// <returns>�g���q�����㕶����</returns>
		/// <remarks>
		/// <br>Note		: �����񂩂�g���q���������܂��B�����t�@�C���p�X����u.txt�v���������߂Ɏg�p���܂��B</br>
		/// <br>Programmer	: 22013  �v�ہ@����</br>
		/// <br>Date		: 2005.05.11</br>
		/// <br></br>
		/// </remarks>
		private string RemovalExtensions(string removalString)
		{
			int extensionStartCount = 0;
			string beforeRemovalString = removalString;
			// �u.txt�v�J�n�ʒu����
			extensionStartCount = removalString.IndexOf(".txt");
			if (extensionStartCount != -1)
			{
				beforeRemovalString = removalString.Remove(extensionStartCount,4);
			}

			return beforeRemovalString;
		}
        */
        #endregion

        /// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2006.11.06</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFDML09060U",							// �A�Z���u��ID
						"���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFDML09060U",							// �A�Z���u��ID
						"���ɑ��[�����폜����Ă��܂��B",	    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END
					break;
				}
			}
        }

        #region 2006.11.06 Maki Del
        /*
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.06 TAKAHASHI ADD START
		/// <summary>
		/// �K�C�h�N������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �K�C�h���N�����A�I����e����ʂɓK�p���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.06</br>
		/// </remarks>
		private void StartGuidProc(string objectName)
		{
			// �����t�@�C���K�C�h
			// TODO : �ǂ�����́H�H�@�}�X�^���Ȃ��וۗ�
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.06 TAKAHASHI ADD END
        */
        #endregion

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.06</br>
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
        /// <br>Programmer : 23013 �q�@���l</br>
        /// <br>Date       : 2006.11.28</br>
        /// </remarks>
        private string AuthenticationCheck(int status)
        {
            string message = "";
            switch (status)
            {
                case 0: case 1:
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

		#endregion Private Method End

		# region Control Events
		/// <summary>
		///	Form.Load �C�x���g(SFDML09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer		:	22013  �v�ہ@����</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void SFDML09060UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������			
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;
			this.Close_Button.ImageList = imageList24;            			

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Close_Button.Appearance.Image = Size24_Index.CLOSE;

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();

		}
		/// <summary>
		///	Form.VisibleChanged �C�x���g(SFDML09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	��ʂ̕\���A��\�����ς�������ɔ������܂��B</br>
		/// <br>Programmer		:	22013  �v�ہ@����</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void SFDML09060UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END

				return;
			}

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SATRT
            //if (this.mailSndMngClone != null)
            //{
            //    return;
            //}
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

			timer1.Enabled = true;

			ScreenClear();		
		}

		/// <summary>
		///	Form.Load �C�x���g(SFDML09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note			:	���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer		:	22013  �v�ہ@����</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void Close_Button_Click(object sender, System.EventArgs e)
        {
            #region 2006.11.06 Maki Del
            /*
			// �ۑ��m�F
			MailSndMng compareMailSndMng = new MailSndMng();
			compareMailSndMng = this.mailSndMngClone.Clone();
			// ���݂̉�ʏ����擾����
			ScreenToMailSndMng(ref compareMailSndMng);

			//�ŏ��Ɏ擾������ʏ��Ɣ�r
			if (!(this.mailSndMngClone.Equals(compareMailSndMng)))	
			{
				//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
					"SFDML09060U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
					null, 					                              // �\�����郁�b�Z�[�W
					0, 					                                  // �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel);	                      // �\������{�^��
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

				switch(res)
				{
					case DialogResult.Yes:
					{
						// �ۑ��O�f�[�^�`�F�b�N���o�^���̂����s���Ă����珈�����f
						if ( !IsValueCheck() || !IsSaveProc() )
						{
							return;
						}
						break;
					}
					case DialogResult.No:
					{
						break;
					}
					default:
					{
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.03 TAKAHASHI ADD START
						this.Close_Button.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.03 TAKAHASHI ADD END

						return;
					}
				}
			}

			DialogResult dialogResult = DialogResult.Cancel;

			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SATRT
			this.mailSndMngClone = null;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
 */
            #endregion
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //�ۑ��m�F
                MailSndMng compareMailSndMng = new MailSndMng();
                compareMailSndMng = this.mailSndMngClone.Clone();
                //���݂̉�ʏ����擾����
                DispToMailSndMng(ref compareMailSndMng);
                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this.mailSndMngClone.Equals(compareMailSndMng)))
                {
                    //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    DialogResult res = TMsgDisp.Show(
                        this,								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
                        "SFDML09060U",						// �A�Z���u���h�c�܂��̓N���X�h�c
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
		/// Form.Closing�C�x���g(SFDML09060UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[���N���[�Y���̃C�x���g�ł�</br>
		/// <br>Programmer	: 22013  �v�ہ@����</br>
		/// <br>Date		: 2005.04.26</br>
		/// </remarks>
		private void SFDML09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            this._indexBuf = -2;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SATRT
			//this.mailSndMngClone = null;
			// 2005.07.05 �t���[���̍ŏI�ŏ����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
		/// <br>Programmer		:	22013 �v�ہ@����</br>
		/// <br>Date			:	2005.04.26</br>
		/// </remarks>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			timer1.Enabled = false;
			ScreenReconstruction();		
		}

        /// <summary>
        /// SMTP�F�؋敪�g�p�`�F�b�N�`�F���W����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	SMTP�F�؋敪�g�p�`�F�b�N�`�F���W����</br>
        /// <br>Programmer		:	23013 �q�@���l</br>
        /// <br>Date			:	2006.11.03</br>
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
        /// <br>Programmer		:	23013 �q�@���l</br>
        /// <br>Date			:	2006.11.03</br>
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
        /// <br>Programmer		:	23013 �q�@���l</br>
        /// <br>Date			:	2006.11.03</br>
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
        /// <br>Programmer		:	23013 �q�@���l</br>
        /// <br>Date			:	2006.11.03</br>
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
        /// �o�b�N�A�b�v���M�敪�`�F�b�N�`�F���W����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	�o�b�N�A�b�v���M�敪�`�F�b�N�`�F���W����</br>
        /// <br>Programmer		:	23013 �q�@���l</br>
        /// <br>Date			:	2006.11.03</br>
        /// </remarks>
        private void BackupSendDivCd_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.BackupSendDivCd_ultraCheckEditor.Checked)
            {                
                this.BackupFormal_tComboEditor.Enabled = true;
            }
            else
            {                
                this.BackupFormal_tComboEditor.Enabled = false;
            }
        }

        /// <summary>
        /// ���[�����M�����P�ʌ����`�F�b�N�`�F���W����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	���[�����M�����P�ʌ����`�F�b�N�`�F���W����</br>
        /// <br>Programmer		:	23013 �q�@���l</br>
        /// <br>Date			:	2006.11.03</br>
        /// </remarks>
        private void MailSendDivUnitCnt_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (MailSendDivUnitCnt_ultraCheckEditor.Checked)
            {
                this.MailSendDivUnitCnt_tNedit.Enabled = true;                
            }
            else
            {
                this.MailSendDivUnitCnt_tNedit.Enabled = false;                
            }
        }

        /// <summary>
        /// Check_Button�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note			:	Check_Button�N���b�N�C�x���g</br>
        /// <br>Programmer		:	23013 �q�@���l</br>
        /// <br>Date			:	2006.11.28</br>
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
            tSmtp.TraceOptions.TraceLogPath = "c:\\smtp.log"; // TODO

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
                    case 7: case 9:
                        TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                    "SFDML09060U",							// �A�Z���u��ID
                                    smtpMessage + "\n"
                                    + tSmtp.StatusMessage,              �@�@// �\�����郁�b�Z�[�W
                                    tSmtp.Status,							// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);					// �\������{�^��
                        break;
                    default:
                        TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        "SFDML09060U",							// �A�Z���u��ID
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
                tPop.TraceOptions.TraceLogPath = "c:\\pop.log"; //TODO

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
                    switch(popStatus)
                    {
                        case 9:
                            // �G���[
                            TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                                    "SFDML09060U",							// �A�Z���u��ID
                                    popMessage + "\n"
                                    + tPop.StatusMessage,              �@�@ // �\�����郁�b�Z�[�W
                                    tPop.Status,							// �X�e�[�^�X�l
                                    MessageBoxButtons.OK);					// �\������{�^��
                        break;
                        default:
                                // �G���[
                                TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                                     emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                                     "SFDML09060U",							// �A�Z���u��ID
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
                                "SFDML09060U",							// �A�Z���u��ID
                                popMessage,                        �@�@ // �\�����郁�b�Z�[�W
                                tPop.Status,							// �X�e�[�^�X�l
                                MessageBoxButtons.OK);					// �\������{�^��
                }
            }
            // �J�[�\����Default�ɖ߂�
            this.Cursor = Cursors.Default;

        }
        #endregion Control Events End        
    }
}
