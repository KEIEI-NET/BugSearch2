using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ж��̐ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ж��̂̐ݒ���s���N���X�ł��B</br>
	/// <br>Programmer : 23001 �H�R�@����</br>
	/// <br>Date       : 2005.09.09</br>
	/// <br>Update Note: 2005.09.22 23001 �H�R�@����</br>
	/// <br>                        ���b�Z�[�W�{�b�N�X�\�����i�̑g����</br>
	/// <br>Update Note: 2005.10.18 23001 �H�R�@����</br>
	/// <br>                        �K�C�h�I���m�莞�Ɏ��̍��ڂփt�H�[�J�X���ړ�����悤�ɏC��</br>
	/// <br>Update Note: 2005.10.19 23001 �H�R�@����</br>
	/// <br>                        �t�H�[����\�����Ƀ��C���t���[�����A�N�e�B�u�ɂ���悤�ɏC��</br>
	/// <br>Update Note: 2005.11.01 23001 �H�R�@����</br>
	/// <br>                        �i�Ǐ�Q�Ή� (�Ǘ�No.000273-01)</br>
	/// <br>                        �r���ɂ��ۑ��s���ɑ��݂��Ȃ��摜�����[�h���悤�Ƃ���st=04���o��̂��C��</br>
	/// <br>Update Note: 2005.11.04 23001 �H�R�@����</br>
	/// <br>                        �i�Ǐ�Q�Ή� (�Ǘ�No.000273-02)</br>
	/// <br>                        �ʒ[���ŉ摜�ۑ����ɁA�L���b�V���̉e���ňقȂ�摜���\������Ă���̂��C��</br>
	/// <br>Update Note: 2006.03.14 23010 �����@�m</br>
	/// <br>                        ���ڂ̒ǉ����s���܂�</br>
	/// <br>Update Note: 2006.05.19 23010 �����@�m</br>
	/// <br>                        �Z���K�C�h����30�����𒴂���Z�����߂��Ă����ۂɁA�������ďZ���P�A�Z���R�ɕ\��������悤�ɏC��</br>
    /// <br>Update Note: 2007.05.17 20031 �É�@���S��</br>
    /// <br>                        �摜�o�^�@�\�폜�A�摜���R�[�h�ǉ�</br>
    /// <br>                        �X�֔ԍ������{�^��(������)���\���ɕύX</br>
    /// <br>Update Note: 2007.05.27 20031 �É�@���S��</br>
    /// <br>                        �Z���́u���ځv�\�����\���ɕύX</br>
    /// <br>Update Note: 2007.07.13 20031 �É�@���S��</br>
    /// <br>                        �d�b�ԍ��^�C�g���Ɠd�b�ԍ��\�L��ύX</br>
    /// <br>Update Note: 2008/06/04 30414 �E�@�K�j</br>
    /// <br>                        �u�Z��2�v�폜</br>
    /// </remarks>
	public class SFUKN09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region Private Members (Component)
		private System.Data.DataSet Bind_DataSet;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel CompanyNameCd_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyName1_Title_Label;
		private Infragistics.Win.Misc.UltraLabel PostNo_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyName2_Title_Label;
		private Infragistics.Win.Misc.UltraLabel Address_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyTel1Title_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyTel2Title_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyTel3Title_Title_Label;
		private Infragistics.Win.Misc.UltraLabel TransferGuidance_Title_Label;
		private Infragistics.Win.Misc.UltraLabel AccountNoInfo1_Title_Label;
		private Infragistics.Win.Misc.UltraLabel AccountNoInfo2_Title_Label;
		private Infragistics.Win.Misc.UltraLabel AccountNoInfo3_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanySetNote_Title_Label;
		private Broadleaf.Library.Windows.Forms.TNedit CompanyNameCd_tNedit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyName1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyName2_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TEdit PostNoMark_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PostNo_tEdit;
		private Infragistics.Win.Misc.UltraLabel PostNo_Border_Label;
		private Broadleaf.Library.Windows.Forms.TEdit Address1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit Address3_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit Address4_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraButton AddressGuide_Button;
		private Infragistics.Win.Misc.UltraLabel CompanyPr_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelTitle1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelTitle2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelTitle3_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelNo1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelNo2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelNo3_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TransferGuidance_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit AccountNoInfo1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit AccountNoInfo2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit AccountNoInfo3_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanySetNote1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanySetNote2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyPr_tEdit;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraLabel ImageInfoCode_Title_Label;
		private System.Windows.Forms.OpenFileDialog TakeInImage_OpenFileDialog;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyUrl_tEdit;
		private Infragistics.Win.Misc.UltraLabel CompanyUrl_Title_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyPr2_tEdit;
		private Infragistics.Win.Misc.UltraLabel ImageCommentForPrt1_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit ImageCommentForPrt1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit ImageCommentForPrt2_tEdit;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TComboEditor ImageInfoCode_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel CompanyTel1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel3_Title_Label;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructor
		/// <summary>
		/// ���Ж��̐ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ж��̐ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public SFUKN09020UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l
			this._canClose							= false;	// ����@�\�i�f�t�H���gtrue�Œ�j
			this._canDelete							= true;		// �폜�@�\
			this._canLogicalDeleteDataExtraction	= true;		// �_���폜�f�[�^�\���@�\
			this._canNew							= true;		// �V�K�쐬�@�\
			this._canPrint							= false;	// ����@�\
			this._canSpecificationSearch			= false;	// �����w�茟���@�\
			this._defaultAutoFillToColumn			= false;	// ��T�C�Y���������@�\

            # region 2007.05.17  S.Koga  DEL
            // �摜�Ǘ��}�X�^�֘A
            //this._imageGroup						= null;					// �摜�O���[�v�N���X
            //this._imgManage							= null;					// �摜�Ǘ��N���X
            # endregion
            // 2007.05.17  S.Koga  add ----------------------------------------
            this._imageInfoAcs = new ImageInfoAcs();
            this.ImageInfoDS = new DataSet();
            // ----------------------------------------------------------------

            // ���Љ摜�]���N���X�C���X�^���X�쐬
            //this._SFUKN09020UB                      = new SFUKN09020UB();
			// �^�C���A�E�g��10��(600�b)�ɐݒ�
            //this._SFUKN09020UB.TimeOut              = 600;
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			this._imageImgAcs						= new ImageImgAcs();	// �摜�Ǘ��}�X�^�A�N�Z�X�N���X
//			// �摜�t�@�C������M�����C�x���g
//			this._imageImgAcs.FileReceived			+= new EventHandler( this.ImageImgAcs_FileReceived );
//			this._imageImgAcs.FileSended			+= new EventHandler( this.ImageImgAcs_FileSended );
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// ��ƃR�[�h�擾
			this._enterpriseCode					= LoginInfoAcquisition.EnterpriseCode;	// ��ƃR�[�h

			// ������
			this._dataIndex							= -1;
			this._companyNmAcs						= new CompanyNmAcs();
			this._logicalDeleteMode					= 0;
			this._companyNmTable					= new Hashtable();
			this._changeFlg							= false;

			this._changeTakeInImage					= false;
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			this._imageTransferring					= false;
//
//			this._waitWindow						= null;
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf							= -2;
		}
		#endregion

		#region Private Members
		private CompanyNmAcs	_companyNmAcs;						// ���Ж��̃A�N�Z�X�N���X
		private string			_enterpriseCode;					// ��ƃR�[�h
		private int				_logicalDeleteMode;					// ���[�h
		private Hashtable		_companyNmTable;					// ���Ж��̃e�[�u��
		private bool			_changeFlg = false;					// �R�[�h�ύX�t���O

		// �摜�Ǘ��}�X�^�֘A
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//		private ImageImgAcs		_imageImgAcs;						// �摜�Ǘ��}�X�^�A�N�Z�X�N���X
        // 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
        # region 2007.05.17  S.Koga  DEL
        //private ImageGroup		_imageGroup;						// �摜�O���[�v�I�u�W�F�N�g
        //private ImgManage		_imgManage;							// �摜�Ǘ��I�u�W�F�N�g
        # endregion
        // 2007.05.17  S.Koga  add --------------------------------------------
        // �摜���A�N�Z�X�N���X
        private ImageInfoAcs _imageInfoAcs = null;
        // �摜���擾�pDataSet
        private DataSet ImageInfoDS = null;
        // --------------------------------------------------------------------

        private const int SYSTEMDIV_CD			= 0;			// �V�X�e���敪
		private const int IMAGEUSESYSTEM_CODE	= 10;			// �摜�g�p�V�X�e���敪

		private bool			_changeTakeInImage;					// �捞�摜�ύX�t���O
// 2006.08.18 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		// ���Љ摜�]���N���X
        //private SFUKN09020UB    _SFUKN09020UB   = null;
// 2006.08.18 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//		private bool			_imageTransferring;					// �摜�]�����t���O
//
//		private SFUKN09020UB	_waitWindow = null;					// ���҂�����������
//		private readonly object _syncObject = new object();			//���b�N�Ɏg�p����I�u�W�F�N�g
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

		// ��r�pclone
		private CompanyNm		_companyNmClone;

		// _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int				_indexBuf;

		// �v���p�e�B�p
		private bool	_canClose;
		private bool	_canDelete;
		private bool	_canLogicalDeleteDataExtraction;
		private bool	_canNew;
		private bool	_canPrint;
		private bool	_canSpecificationSearch;
		private int		_dataIndex;
		private bool	_defaultAutoFillToColumn;

        // 2009.03.23 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.23 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

		// Frame��View�pGrid���KEY���i�w�b�_�̃^�C�g�����ƂȂ�܂��B�j
		private const string DELETE_DATE				= "�폜��";
		private const string COMPANYNAMECD_TITLE		= "�R�[�h";
		private const string COMPANYNAME_TITLE			= "���Ж���";
		private const string POSTNO_TITLE				= "�X�֔ԍ�";
		private const string ADDRESS_TITLE				= "�Z��";
		private const string COMPANYTELNO1_TITLE		= "�d�b�ԍ��P";
		private const string COMPANYTELNO2_TITLE		= "�d�b�ԍ��Q";
		private const string COMPANYTELNO3_TITLE		= "�d�b�ԍ��R";
		private const string TRANSFERGUIDANCE_TITLE		= "��s�U���ē���";
		private const string ACCOUNTNOINFO1_TITLE		= "��s�����P";
		private const string ACCOUNTNOINFO2_TITLE		= "��s�����Q";
		private const string ACCOUNTNOINFO3_TITLE		= "��s�����R";
		private const string COMPANYSETNOTE1_TITLE		= "���Аݒ�E�v�P";
		private const string COMPANYSETNOTE2_TITLE		= "���Аݒ�E�v�Q";
		private const string COMPANYPR_TITLE			= "���Ђo�q���P";
		private const string COMPANYPR2_TITLE			= "���Ђo�q���Q";
        // 2007.05.17  S.Koga  ADD --------------------------------------------
        private const string IMAGEINFODIV_TITLE         = "�摜���敪";
        private const string IMAGEINFOCODE_TITLE        = "�摜���R�[�h";
        // --------------------------------------------------------------------
        private const string COMPANYURL_TITLE = "���Ђt�q�k";
		private const string IMAGECOMMENTFORPRT1_TITLE	= "�摜�󎚗p�R�����g�P";
		private const string IMAGECOMMENTFORPRT2_TITLE	= "�摜�󎚗p�R�����g�Q";
		private const string GUID_TITLE					= "GUID";
		private const string COMPANYNM_TABLE			= "COMPANYNM";				// �e�[�u����

        // 2007.05.17  S.Koga  ADD --------------------------------------------
        // �摜���敪(10:���Љ摜 �Œ�)
        private const int IMAGEINFODIV_DATA = 10;
        // --------------------------------------------------------------------
	
		
		// �ҏW���[�h
		private const string INSERT_MODE				= "�V�K���[�h";
		private const string UPDATE_MODE				= "�X�V���[�h";
		private const string DELETE_MODE				= "�폜���[�h";
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�Z���K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
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
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKN09020UA));
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AddressGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.CompanyNameCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyName1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PostNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyName2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Address_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel1Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel2Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel3Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TransferGuidance_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AccountNoInfo1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AccountNoInfo2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AccountNoInfo3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanySetNote_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyPr_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyNameCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CompanyName1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyName2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.PostNoMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PostNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PostNo_Border_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Address1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Address3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Address4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTelTitle1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelTitle2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelTitle3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelNo1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelNo2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelNo3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.TransferGuidance_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AccountNoInfo1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AccountNoInfo2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AccountNoInfo3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanySetNote1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanySetNote2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyPr_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ImageInfoCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TakeInImage_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CompanyUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyUrl_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyPr2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ImageCommentForPrt1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ImageCommentForPrt1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ImageCommentForPrt2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ImageInfoCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CompanyTel1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameCd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNoMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransferGuidance_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanySetNote1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanySetNote2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPr_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPr2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCommentForPrt1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCommentForPrt2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageInfoCode_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(579, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // AddressGuide_Button
            // 
            this.AddressGuide_Button.Location = new System.Drawing.Point(301, 148);
            this.AddressGuide_Button.Name = "AddressGuide_Button";
            this.AddressGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.AddressGuide_Button.TabIndex = 7;
            this.AddressGuide_Button.Text = "?";
            ultraToolTipInfo1.ToolTipText = "�Z���K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.AddressGuide_Button, ultraToolTipInfo1);
            this.AddressGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.AddressGuide_Button.Visible = false;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(175, 626);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 28;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(300, 626);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 29;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(425, 626);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 30;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(550, 626);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 31;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 669);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(684, 23);
            this.ultraStatusBar1.TabIndex = 59;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // CompanyNameCd_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.CompanyNameCd_Title_Label.Appearance = appearance2;
            this.CompanyNameCd_Title_Label.Location = new System.Drawing.Point(20, 8);
            this.CompanyNameCd_Title_Label.Name = "CompanyNameCd_Title_Label";
            this.CompanyNameCd_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyNameCd_Title_Label.TabIndex = 34;
            this.CompanyNameCd_Title_Label.Text = "���Ж��̃R�[�h";
            // 
            // CompanyName1_Title_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.CompanyName1_Title_Label.Appearance = appearance3;
            this.CompanyName1_Title_Label.Location = new System.Drawing.Point(20, 60);
            this.CompanyName1_Title_Label.Name = "CompanyName1_Title_Label";
            this.CompanyName1_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyName1_Title_Label.TabIndex = 36;
            this.CompanyName1_Title_Label.Text = "���Ж��̂P";
            // 
            // PostNo_Title_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.PostNo_Title_Label.Appearance = appearance4;
            this.PostNo_Title_Label.Location = new System.Drawing.Point(20, 148);
            this.PostNo_Title_Label.Name = "PostNo_Title_Label";
            this.PostNo_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.PostNo_Title_Label.TabIndex = 40;
            this.PostNo_Title_Label.Text = "�X�֔ԍ�";
            // 
            // CompanyName2_Title_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.CompanyName2_Title_Label.Appearance = appearance5;
            this.CompanyName2_Title_Label.Location = new System.Drawing.Point(20, 86);
            this.CompanyName2_Title_Label.Name = "CompanyName2_Title_Label";
            this.CompanyName2_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyName2_Title_Label.TabIndex = 37;
            this.CompanyName2_Title_Label.Text = "���Ж��̂Q";
            // 
            // Address_Title_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.Address_Title_Label.Appearance = appearance6;
            this.Address_Title_Label.Location = new System.Drawing.Point(20, 174);
            this.Address_Title_Label.Name = "Address_Title_Label";
            this.Address_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.Address_Title_Label.TabIndex = 41;
            this.Address_Title_Label.Text = "�Z��";
            // 
            // CompanyTel1Title_Title_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.CompanyTel1Title_Title_Label.Appearance = appearance7;
            this.CompanyTel1Title_Title_Label.Location = new System.Drawing.Point(20, 252);
            this.CompanyTel1Title_Title_Label.Name = "CompanyTel1Title_Title_Label";
            this.CompanyTel1Title_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.CompanyTel1Title_Title_Label.TabIndex = 42;
            this.CompanyTel1Title_Title_Label.Text = "�d�b�ԍ��P�^�C�g��";
            // 
            // CompanyTel2Title_Title_Label
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.CompanyTel2Title_Title_Label.Appearance = appearance8;
            this.CompanyTel2Title_Title_Label.Location = new System.Drawing.Point(20, 278);
            this.CompanyTel2Title_Title_Label.Name = "CompanyTel2Title_Title_Label";
            this.CompanyTel2Title_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.CompanyTel2Title_Title_Label.TabIndex = 43;
            this.CompanyTel2Title_Title_Label.Text = "�d�b�ԍ��Q�^�C�g��";
            // 
            // CompanyTel3Title_Title_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.CompanyTel3Title_Title_Label.Appearance = appearance9;
            this.CompanyTel3Title_Title_Label.Location = new System.Drawing.Point(20, 304);
            this.CompanyTel3Title_Title_Label.Name = "CompanyTel3Title_Title_Label";
            this.CompanyTel3Title_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.CompanyTel3Title_Title_Label.TabIndex = 44;
            this.CompanyTel3Title_Title_Label.Text = "�d�b�ԍ��R�^�C�g��";
            // 
            // TransferGuidance_Title_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.TransferGuidance_Title_Label.Appearance = appearance10;
            this.TransferGuidance_Title_Label.Location = new System.Drawing.Point(20, 392);
            this.TransferGuidance_Title_Label.Name = "TransferGuidance_Title_Label";
            this.TransferGuidance_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.TransferGuidance_Title_Label.TabIndex = 46;
            this.TransferGuidance_Title_Label.Text = "��s�U���ē���";
            // 
            // AccountNoInfo1_Title_Label
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.AccountNoInfo1_Title_Label.Appearance = appearance11;
            this.AccountNoInfo1_Title_Label.Location = new System.Drawing.Point(20, 418);
            this.AccountNoInfo1_Title_Label.Name = "AccountNoInfo1_Title_Label";
            this.AccountNoInfo1_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.AccountNoInfo1_Title_Label.TabIndex = 47;
            this.AccountNoInfo1_Title_Label.Text = "��s�����P";
            // 
            // AccountNoInfo2_Title_Label
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.AccountNoInfo2_Title_Label.Appearance = appearance12;
            this.AccountNoInfo2_Title_Label.Location = new System.Drawing.Point(20, 444);
            this.AccountNoInfo2_Title_Label.Name = "AccountNoInfo2_Title_Label";
            this.AccountNoInfo2_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.AccountNoInfo2_Title_Label.TabIndex = 48;
            this.AccountNoInfo2_Title_Label.Text = "��s�����Q";
            // 
            // AccountNoInfo3_Title_Label
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.AccountNoInfo3_Title_Label.Appearance = appearance13;
            this.AccountNoInfo3_Title_Label.Location = new System.Drawing.Point(20, 470);
            this.AccountNoInfo3_Title_Label.Name = "AccountNoInfo3_Title_Label";
            this.AccountNoInfo3_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.AccountNoInfo3_Title_Label.TabIndex = 49;
            this.AccountNoInfo3_Title_Label.Text = "��s�����R";
            // 
            // CompanySetNote_Title_Label
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.CompanySetNote_Title_Label.Appearance = appearance14;
            this.CompanySetNote_Title_Label.Location = new System.Drawing.Point(20, 330);
            this.CompanySetNote_Title_Label.Name = "CompanySetNote_Title_Label";
            this.CompanySetNote_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanySetNote_Title_Label.TabIndex = 50;
            this.CompanySetNote_Title_Label.Text = "�E�v";
            // 
            // CompanyPr_Title_Label
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.CompanyPr_Title_Label.Appearance = appearance15;
            this.CompanyPr_Title_Label.Location = new System.Drawing.Point(20, 34);
            this.CompanyPr_Title_Label.Name = "CompanyPr_Title_Label";
            this.CompanyPr_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyPr_Title_Label.TabIndex = 35;
            this.CompanyPr_Title_Label.Text = "���Ђo�q���P";
            // 
            // CompanyNameCd_tNedit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.CompanyNameCd_tNedit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.CompanyNameCd_tNedit.Appearance = appearance17;
            this.CompanyNameCd_tNedit.AutoSelect = true;
            this.CompanyNameCd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CompanyNameCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CompanyNameCd_tNedit.DataText = "";
            this.CompanyNameCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyNameCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CompanyNameCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyNameCd_tNedit.Location = new System.Drawing.Point(171, 8);
            this.CompanyNameCd_tNedit.MaxLength = 4;
            this.CompanyNameCd_tNedit.Name = "CompanyNameCd_tNedit";
            this.CompanyNameCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CompanyNameCd_tNedit.Size = new System.Drawing.Size(44, 24);
            this.CompanyNameCd_tNedit.TabIndex = 0;
            // 
            // CompanyName1_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.Appearance = appearance19;
            this.CompanyName1_tEdit.AutoSelect = true;
            this.CompanyName1_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CompanyName1_tEdit.DataText = "";
            this.CompanyName1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyName1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyName1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyName1_tEdit.Location = new System.Drawing.Point(171, 60);
            this.CompanyName1_tEdit.MaxLength = 20;
            this.CompanyName1_tEdit.Name = "CompanyName1_tEdit";
            this.CompanyName1_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyName1_tEdit.TabIndex = 2;
            // 
            // CompanyName2_tEdit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.CompanyName2_tEdit.ActiveAppearance = appearance20;
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextVAlignAsString = "Middle";
            this.CompanyName2_tEdit.Appearance = appearance21;
            this.CompanyName2_tEdit.AutoSelect = true;
            this.CompanyName2_tEdit.DataText = "";
            this.CompanyName2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyName2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyName2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyName2_tEdit.Location = new System.Drawing.Point(171, 86);
            this.CompanyName2_tEdit.MaxLength = 20;
            this.CompanyName2_tEdit.Name = "CompanyName2_tEdit";
            this.CompanyName2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyName2_tEdit.TabIndex = 3;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(10, 141);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel17.TabIndex = 39;
            // 
            // PostNoMark_tEdit
            // 
            this.PostNoMark_tEdit.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.White;
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.PostNoMark_tEdit.Appearance = appearance23;
            this.PostNoMark_tEdit.AutoSelect = true;
            this.PostNoMark_tEdit.BackColor = System.Drawing.Color.White;
            this.PostNoMark_tEdit.DataText = "��";
            this.PostNoMark_tEdit.Enabled = false;
            this.PostNoMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PostNoMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PostNoMark_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PostNoMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PostNoMark_tEdit.Location = new System.Drawing.Point(171, 148);
            this.PostNoMark_tEdit.MaxLength = 12;
            this.PostNoMark_tEdit.Name = "PostNoMark_tEdit";
            this.PostNoMark_tEdit.Size = new System.Drawing.Size(37, 24);
            this.PostNoMark_tEdit.TabIndex = 5;
            this.PostNoMark_tEdit.TabStop = false;
            this.PostNoMark_tEdit.Text = "��";
            // 
            // PostNo_tEdit
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextVAlignAsString = "Middle";
            this.PostNo_tEdit.ActiveAppearance = appearance24;
            appearance25.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.PostNo_tEdit.Appearance = appearance25;
            this.PostNo_tEdit.AutoSelect = true;
            this.PostNo_tEdit.DataText = "";
            this.PostNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PostNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.PostNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PostNo_tEdit.Location = new System.Drawing.Point(206, 148);
            this.PostNo_tEdit.MaxLength = 10;
            this.PostNo_tEdit.Name = "PostNo_tEdit";
            this.PostNo_tEdit.Size = new System.Drawing.Size(92, 24);
            this.PostNo_tEdit.TabIndex = 5;
            this.PostNo_tEdit.ValueChanged += new System.EventHandler(this.PostNo_tEdit_ValueChanged);
            this.PostNo_tEdit.Leave += new System.EventHandler(this.PostNo_tEdit_Leave);
            this.PostNo_tEdit.Enter += new System.EventHandler(this.PostNo_tEdit_Enter);
            this.PostNo_tEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostNo_tEdit_KeyDown);
            // 
            // PostNo_Border_Label
            // 
            appearance26.BackColor = System.Drawing.Color.White;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.PostNo_Border_Label.Appearance = appearance26;
            this.PostNo_Border_Label.Location = new System.Drawing.Point(206, 149);
            this.PostNo_Border_Label.Name = "PostNo_Border_Label";
            this.PostNo_Border_Label.Size = new System.Drawing.Size(3, 22);
            this.PostNo_Border_Label.TabIndex = 6;
            // 
            // Address1_tEdit
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.Address1_tEdit.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.Address1_tEdit.Appearance = appearance28;
            this.Address1_tEdit.AutoSelect = true;
            this.Address1_tEdit.DataText = "";
            this.Address1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address1_tEdit.Location = new System.Drawing.Point(171, 174);
            this.Address1_tEdit.MaxLength = 30;
            this.Address1_tEdit.Name = "Address1_tEdit";
            this.Address1_tEdit.Size = new System.Drawing.Size(496, 24);
            this.Address1_tEdit.TabIndex = 8;
            // 
            // Address3_tEdit
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextVAlignAsString = "Middle";
            this.Address3_tEdit.ActiveAppearance = appearance29;
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            appearance30.TextVAlignAsString = "Middle";
            this.Address3_tEdit.Appearance = appearance30;
            this.Address3_tEdit.AutoSelect = true;
            this.Address3_tEdit.DataText = "";
            this.Address3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 22, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address3_tEdit.Location = new System.Drawing.Point(171, 200);
            this.Address3_tEdit.MaxLength = 22;
            this.Address3_tEdit.Name = "Address3_tEdit";
            this.Address3_tEdit.Size = new System.Drawing.Size(469, 24);
            this.Address3_tEdit.TabIndex = 10;
            // 
            // Address4_tEdit
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.Address4_tEdit.ActiveAppearance = appearance31;
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            appearance32.TextVAlignAsString = "Middle";
            this.Address4_tEdit.Appearance = appearance32;
            this.Address4_tEdit.AutoSelect = true;
            this.Address4_tEdit.DataText = "";
            this.Address4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address4_tEdit.Location = new System.Drawing.Point(171, 226);
            this.Address4_tEdit.MaxLength = 30;
            this.Address4_tEdit.Name = "Address4_tEdit";
            this.Address4_tEdit.Size = new System.Drawing.Size(496, 24);
            this.Address4_tEdit.TabIndex = 11;
            // 
            // ultraLabel2
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance35;
            this.ultraLabel2.Location = new System.Drawing.Point(211, 200);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(43, 23);
            this.ultraLabel2.TabIndex = 57;
            this.ultraLabel2.Text = "����";
            this.ultraLabel2.Visible = false;
            // 
            // CompanyTelTitle1_tEdit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.TextVAlignAsString = "Middle";
            this.CompanyTelTitle1_tEdit.ActiveAppearance = appearance36;
            appearance37.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextVAlignAsString = "Middle";
            this.CompanyTelTitle1_tEdit.Appearance = appearance37;
            this.CompanyTelTitle1_tEdit.AutoSelect = true;
            this.CompanyTelTitle1_tEdit.DataText = "";
            this.CompanyTelTitle1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle1_tEdit.Location = new System.Drawing.Point(171, 252);
            this.CompanyTelTitle1_tEdit.MaxLength = 6;
            this.CompanyTelTitle1_tEdit.Name = "CompanyTelTitle1_tEdit";
            this.CompanyTelTitle1_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle1_tEdit.TabIndex = 12;
            // 
            // CompanyTelTitle2_tEdit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.CompanyTelTitle2_tEdit.ActiveAppearance = appearance38;
            appearance39.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextVAlignAsString = "Middle";
            this.CompanyTelTitle2_tEdit.Appearance = appearance39;
            this.CompanyTelTitle2_tEdit.AutoSelect = true;
            this.CompanyTelTitle2_tEdit.DataText = "";
            this.CompanyTelTitle2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle2_tEdit.Location = new System.Drawing.Point(171, 278);
            this.CompanyTelTitle2_tEdit.MaxLength = 6;
            this.CompanyTelTitle2_tEdit.Name = "CompanyTelTitle2_tEdit";
            this.CompanyTelTitle2_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle2_tEdit.TabIndex = 14;
            // 
            // CompanyTelTitle3_tEdit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.CompanyTelTitle3_tEdit.ActiveAppearance = appearance40;
            appearance41.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextVAlignAsString = "Middle";
            this.CompanyTelTitle3_tEdit.Appearance = appearance41;
            this.CompanyTelTitle3_tEdit.AutoSelect = true;
            this.CompanyTelTitle3_tEdit.DataText = "";
            this.CompanyTelTitle3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle3_tEdit.Location = new System.Drawing.Point(171, 304);
            this.CompanyTelTitle3_tEdit.MaxLength = 6;
            this.CompanyTelTitle3_tEdit.Name = "CompanyTelTitle3_tEdit";
            this.CompanyTelTitle3_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle3_tEdit.TabIndex = 16;
            // 
            // CompanyTelNo1_tEdit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextVAlignAsString = "Middle";
            this.CompanyTelNo1_tEdit.ActiveAppearance = appearance42;
            appearance43.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.CompanyTelNo1_tEdit.Appearance = appearance43;
            this.CompanyTelNo1_tEdit.AutoSelect = true;
            this.CompanyTelNo1_tEdit.DataText = "";
            this.CompanyTelNo1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo1_tEdit.Location = new System.Drawing.Point(411, 252);
            this.CompanyTelNo1_tEdit.MaxLength = 16;
            this.CompanyTelNo1_tEdit.Name = "CompanyTelNo1_tEdit";
            this.CompanyTelNo1_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo1_tEdit.TabIndex = 13;
            // 
            // CompanyTelNo2_tEdit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.TextVAlignAsString = "Middle";
            this.CompanyTelNo2_tEdit.ActiveAppearance = appearance44;
            appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance45.ForeColor = System.Drawing.Color.Black;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextVAlignAsString = "Middle";
            this.CompanyTelNo2_tEdit.Appearance = appearance45;
            this.CompanyTelNo2_tEdit.AutoSelect = true;
            this.CompanyTelNo2_tEdit.DataText = "";
            this.CompanyTelNo2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo2_tEdit.Location = new System.Drawing.Point(411, 278);
            this.CompanyTelNo2_tEdit.MaxLength = 16;
            this.CompanyTelNo2_tEdit.Name = "CompanyTelNo2_tEdit";
            this.CompanyTelNo2_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo2_tEdit.TabIndex = 15;
            // 
            // CompanyTelNo3_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.TextVAlignAsString = "Middle";
            this.CompanyTelNo3_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextVAlignAsString = "Middle";
            this.CompanyTelNo3_tEdit.Appearance = appearance47;
            this.CompanyTelNo3_tEdit.AutoSelect = true;
            this.CompanyTelNo3_tEdit.DataText = "";
            this.CompanyTelNo3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo3_tEdit.Location = new System.Drawing.Point(411, 304);
            this.CompanyTelNo3_tEdit.MaxLength = 16;
            this.CompanyTelNo3_tEdit.Name = "CompanyTelNo3_tEdit";
            this.CompanyTelNo3_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo3_tEdit.TabIndex = 17;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel3.Location = new System.Drawing.Point(10, 385);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel3.TabIndex = 45;
            // 
            // TransferGuidance_tEdit
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.TextVAlignAsString = "Middle";
            this.TransferGuidance_tEdit.ActiveAppearance = appearance48;
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.TransferGuidance_tEdit.Appearance = appearance49;
            this.TransferGuidance_tEdit.AutoSelect = true;
            this.TransferGuidance_tEdit.DataText = "";
            this.TransferGuidance_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TransferGuidance_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TransferGuidance_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TransferGuidance_tEdit.Location = new System.Drawing.Point(171, 392);
            this.TransferGuidance_tEdit.MaxLength = 20;
            this.TransferGuidance_tEdit.Name = "TransferGuidance_tEdit";
            this.TransferGuidance_tEdit.Size = new System.Drawing.Size(337, 24);
            this.TransferGuidance_tEdit.TabIndex = 20;
            // 
            // AccountNoInfo1_tEdit
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance50.ForeColor = System.Drawing.Color.Black;
            appearance50.TextVAlignAsString = "Middle";
            this.AccountNoInfo1_tEdit.ActiveAppearance = appearance50;
            appearance51.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextVAlignAsString = "Middle";
            this.AccountNoInfo1_tEdit.Appearance = appearance51;
            this.AccountNoInfo1_tEdit.AutoSelect = true;
            this.AccountNoInfo1_tEdit.DataText = "";
            this.AccountNoInfo1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AccountNoInfo1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.AccountNoInfo1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.AccountNoInfo1_tEdit.Location = new System.Drawing.Point(171, 418);
            this.AccountNoInfo1_tEdit.MaxLength = 30;
            this.AccountNoInfo1_tEdit.Name = "AccountNoInfo1_tEdit";
            this.AccountNoInfo1_tEdit.Size = new System.Drawing.Size(496, 24);
            this.AccountNoInfo1_tEdit.TabIndex = 21;
            // 
            // AccountNoInfo2_tEdit
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.ForeColor = System.Drawing.Color.Black;
            appearance52.TextVAlignAsString = "Middle";
            this.AccountNoInfo2_tEdit.ActiveAppearance = appearance52;
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            appearance53.TextVAlignAsString = "Middle";
            this.AccountNoInfo2_tEdit.Appearance = appearance53;
            this.AccountNoInfo2_tEdit.AutoSelect = true;
            this.AccountNoInfo2_tEdit.DataText = "";
            this.AccountNoInfo2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AccountNoInfo2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.AccountNoInfo2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.AccountNoInfo2_tEdit.Location = new System.Drawing.Point(171, 444);
            this.AccountNoInfo2_tEdit.MaxLength = 30;
            this.AccountNoInfo2_tEdit.Name = "AccountNoInfo2_tEdit";
            this.AccountNoInfo2_tEdit.Size = new System.Drawing.Size(496, 24);
            this.AccountNoInfo2_tEdit.TabIndex = 22;
            // 
            // AccountNoInfo3_tEdit
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance54.ForeColor = System.Drawing.Color.Black;
            appearance54.TextVAlignAsString = "Middle";
            this.AccountNoInfo3_tEdit.ActiveAppearance = appearance54;
            appearance55.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance55.ForeColor = System.Drawing.Color.Black;
            appearance55.ForeColorDisabled = System.Drawing.Color.Black;
            appearance55.TextVAlignAsString = "Middle";
            this.AccountNoInfo3_tEdit.Appearance = appearance55;
            this.AccountNoInfo3_tEdit.AutoSelect = true;
            this.AccountNoInfo3_tEdit.DataText = "";
            this.AccountNoInfo3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AccountNoInfo3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.AccountNoInfo3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.AccountNoInfo3_tEdit.Location = new System.Drawing.Point(171, 470);
            this.AccountNoInfo3_tEdit.MaxLength = 30;
            this.AccountNoInfo3_tEdit.Name = "AccountNoInfo3_tEdit";
            this.AccountNoInfo3_tEdit.Size = new System.Drawing.Size(496, 24);
            this.AccountNoInfo3_tEdit.TabIndex = 23;
            // 
            // CompanySetNote1_tEdit
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.ForeColor = System.Drawing.Color.Black;
            appearance56.TextVAlignAsString = "Middle";
            this.CompanySetNote1_tEdit.ActiveAppearance = appearance56;
            appearance57.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance57.ForeColor = System.Drawing.Color.Black;
            appearance57.ForeColorDisabled = System.Drawing.Color.Black;
            appearance57.TextVAlignAsString = "Middle";
            this.CompanySetNote1_tEdit.Appearance = appearance57;
            this.CompanySetNote1_tEdit.AutoSelect = true;
            this.CompanySetNote1_tEdit.DataText = "";
            this.CompanySetNote1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanySetNote1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanySetNote1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanySetNote1_tEdit.Location = new System.Drawing.Point(171, 330);
            this.CompanySetNote1_tEdit.MaxLength = 20;
            this.CompanySetNote1_tEdit.Name = "CompanySetNote1_tEdit";
            this.CompanySetNote1_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanySetNote1_tEdit.TabIndex = 18;
            // 
            // CompanySetNote2_tEdit
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.CompanySetNote2_tEdit.ActiveAppearance = appearance58;
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColor = System.Drawing.Color.Black;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextVAlignAsString = "Middle";
            this.CompanySetNote2_tEdit.Appearance = appearance59;
            this.CompanySetNote2_tEdit.AutoSelect = true;
            this.CompanySetNote2_tEdit.DataText = "";
            this.CompanySetNote2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanySetNote2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanySetNote2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanySetNote2_tEdit.Location = new System.Drawing.Point(171, 356);
            this.CompanySetNote2_tEdit.MaxLength = 20;
            this.CompanySetNote2_tEdit.Name = "CompanySetNote2_tEdit";
            this.CompanySetNote2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanySetNote2_tEdit.TabIndex = 19;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel4.Location = new System.Drawing.Point(10, 499);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel4.TabIndex = 51;
            // 
            // CompanyPr_tEdit
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.TextVAlignAsString = "Middle";
            this.CompanyPr_tEdit.ActiveAppearance = appearance60;
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextVAlignAsString = "Middle";
            this.CompanyPr_tEdit.Appearance = appearance61;
            this.CompanyPr_tEdit.AutoSelect = true;
            this.CompanyPr_tEdit.DataText = "";
            this.CompanyPr_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyPr_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyPr_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyPr_tEdit.Location = new System.Drawing.Point(171, 34);
            this.CompanyPr_tEdit.MaxLength = 20;
            this.CompanyPr_tEdit.Name = "CompanyPr_tEdit";
            this.CompanyPr_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyPr_tEdit.TabIndex = 1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ImageInfoCode_Title_Label
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.ImageInfoCode_Title_Label.Appearance = appearance80;
            this.ImageInfoCode_Title_Label.Location = new System.Drawing.Point(20, 532);
            this.ImageInfoCode_Title_Label.Name = "ImageInfoCode_Title_Label";
            this.ImageInfoCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.ImageInfoCode_Title_Label.TabIndex = 53;
            this.ImageInfoCode_Title_Label.Text = "�摜���";
            // 
            // TakeInImage_OpenFileDialog
            // 
            this.TakeInImage_OpenFileDialog.Filter = "�摜�t�@�C��(*.bmp;*.jpg;*.jpeg)|*.bmp;*.jpg;*.jpeg";
            this.TakeInImage_OpenFileDialog.RestoreDirectory = true;
            this.TakeInImage_OpenFileDialog.Title = "���Љ摜�I��";
            // 
            // CompanyUrl_tEdit
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance78.ForeColor = System.Drawing.Color.Black;
            appearance78.TextVAlignAsString = "Middle";
            this.CompanyUrl_tEdit.ActiveAppearance = appearance78;
            appearance79.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance79.ForeColor = System.Drawing.Color.Black;
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            appearance79.TextVAlignAsString = "Middle";
            this.CompanyUrl_tEdit.Appearance = appearance79;
            this.CompanyUrl_tEdit.AutoSelect = true;
            this.CompanyUrl_tEdit.DataText = "";
            this.CompanyUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 300, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CompanyUrl_tEdit.Location = new System.Drawing.Point(171, 506);
            this.CompanyUrl_tEdit.MaxLength = 300;
            this.CompanyUrl_tEdit.Name = "CompanyUrl_tEdit";
            this.CompanyUrl_tEdit.Size = new System.Drawing.Size(469, 24);
            this.CompanyUrl_tEdit.TabIndex = 24;
            // 
            // CompanyUrl_Title_Label
            // 
            appearance77.TextVAlignAsString = "Middle";
            this.CompanyUrl_Title_Label.Appearance = appearance77;
            this.CompanyUrl_Title_Label.Location = new System.Drawing.Point(20, 506);
            this.CompanyUrl_Title_Label.Name = "CompanyUrl_Title_Label";
            this.CompanyUrl_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyUrl_Title_Label.TabIndex = 52;
            this.CompanyUrl_Title_Label.Text = "���Ђt�q�k";
            // 
            // CompanyPr2_tEdit
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance74.ForeColor = System.Drawing.Color.Black;
            appearance74.TextVAlignAsString = "Middle";
            this.CompanyPr2_tEdit.ActiveAppearance = appearance74;
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColor = System.Drawing.Color.Black;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            appearance75.TextVAlignAsString = "Middle";
            this.CompanyPr2_tEdit.Appearance = appearance75;
            this.CompanyPr2_tEdit.AutoSelect = true;
            this.CompanyPr2_tEdit.DataText = "";
            this.CompanyPr2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyPr2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyPr2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyPr2_tEdit.Location = new System.Drawing.Point(171, 112);
            this.CompanyPr2_tEdit.MaxLength = 20;
            this.CompanyPr2_tEdit.Name = "CompanyPr2_tEdit";
            this.CompanyPr2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyPr2_tEdit.TabIndex = 4;
            // 
            // ultraLabel1
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance76;
            this.ultraLabel1.Location = new System.Drawing.Point(20, 112);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(125, 23);
            this.ultraLabel1.TabIndex = 38;
            this.ultraLabel1.Text = "���Ђo�q���Q";
            // 
            // ImageCommentForPrt1_Title_Label
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt1_Title_Label.Appearance = appearance73;
            this.ImageCommentForPrt1_Title_Label.Location = new System.Drawing.Point(20, 558);
            this.ImageCommentForPrt1_Title_Label.Name = "ImageCommentForPrt1_Title_Label";
            this.ImageCommentForPrt1_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.ImageCommentForPrt1_Title_Label.TabIndex = 56;
            this.ImageCommentForPrt1_Title_Label.Text = "�摜�󎚗p�R�����g";
            // 
            // ImageCommentForPrt1_tEdit
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance71.ForeColor = System.Drawing.Color.Black;
            appearance71.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt1_tEdit.ActiveAppearance = appearance71;
            appearance72.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance72.ForeColor = System.Drawing.Color.Black;
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt1_tEdit.Appearance = appearance72;
            this.ImageCommentForPrt1_tEdit.AutoSelect = true;
            this.ImageCommentForPrt1_tEdit.DataText = "";
            this.ImageCommentForPrt1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ImageCommentForPrt1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.ImageCommentForPrt1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ImageCommentForPrt1_tEdit.Location = new System.Drawing.Point(171, 558);
            this.ImageCommentForPrt1_tEdit.MaxLength = 20;
            this.ImageCommentForPrt1_tEdit.Name = "ImageCommentForPrt1_tEdit";
            this.ImageCommentForPrt1_tEdit.Size = new System.Drawing.Size(337, 24);
            this.ImageCommentForPrt1_tEdit.TabIndex = 26;
            // 
            // ImageCommentForPrt2_tEdit
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt2_tEdit.ActiveAppearance = appearance69;
            appearance70.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance70.ForeColor = System.Drawing.Color.Black;
            appearance70.ForeColorDisabled = System.Drawing.Color.Black;
            appearance70.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt2_tEdit.Appearance = appearance70;
            this.ImageCommentForPrt2_tEdit.AutoSelect = true;
            this.ImageCommentForPrt2_tEdit.DataText = "";
            this.ImageCommentForPrt2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ImageCommentForPrt2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.ImageCommentForPrt2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ImageCommentForPrt2_tEdit.Location = new System.Drawing.Point(171, 584);
            this.ImageCommentForPrt2_tEdit.MaxLength = 20;
            this.ImageCommentForPrt2_tEdit.Name = "ImageCommentForPrt2_tEdit";
            this.ImageCommentForPrt2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.ImageCommentForPrt2_tEdit.TabIndex = 27;
            // 
            // ultraLabel6
            // 
            appearance68.ForeColor = System.Drawing.Color.Red;
            appearance68.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance68;
            this.ultraLabel6.Location = new System.Drawing.Point(514, 558);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(153, 54);
            this.ultraLabel6.TabIndex = 55;
            this.ultraLabel6.Text = "���`�[�Ŏ��Љ摜���g�p����ۂɈ󎚂���܂��B";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // ImageInfoCode_tComboEditor
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance65.ForeColor = System.Drawing.Color.Black;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            appearance65.TextVAlignAsString = "Middle";
            this.ImageInfoCode_tComboEditor.ActiveAppearance = appearance65;
            appearance66.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextVAlignAsString = "Middle";
            this.ImageInfoCode_tComboEditor.Appearance = appearance66;
            this.ImageInfoCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ImageInfoCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.ForeColor = System.Drawing.Color.Black;
            appearance67.ForeColorDisabled = System.Drawing.Color.Black;
            this.ImageInfoCode_tComboEditor.ItemAppearance = appearance67;
            this.ImageInfoCode_tComboEditor.Location = new System.Drawing.Point(171, 532);
            this.ImageInfoCode_tComboEditor.Name = "ImageInfoCode_tComboEditor";
            this.ImageInfoCode_tComboEditor.Size = new System.Drawing.Size(337, 24);
            this.ImageInfoCode_tComboEditor.TabIndex = 25;
            // 
            // CompanyTel1_Title_Label
            // 
            appearance62.TextVAlignAsString = "Middle";
            this.CompanyTel1_Title_Label.Appearance = appearance62;
            this.CompanyTel1_Title_Label.Location = new System.Drawing.Point(318, 252);
            this.CompanyTel1_Title_Label.Name = "CompanyTel1_Title_Label";
            this.CompanyTel1_Title_Label.Size = new System.Drawing.Size(87, 23);
            this.CompanyTel1_Title_Label.TabIndex = 60;
            this.CompanyTel1_Title_Label.Text = "�d�b�ԍ��P";
            // 
            // CompanyTel2_Title_Label
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.CompanyTel2_Title_Label.Appearance = appearance63;
            this.CompanyTel2_Title_Label.Location = new System.Drawing.Point(318, 278);
            this.CompanyTel2_Title_Label.Name = "CompanyTel2_Title_Label";
            this.CompanyTel2_Title_Label.Size = new System.Drawing.Size(87, 23);
            this.CompanyTel2_Title_Label.TabIndex = 61;
            this.CompanyTel2_Title_Label.Text = "�d�b�ԍ��Q";
            // 
            // CompanyTel3_Title_Label
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.CompanyTel3_Title_Label.Appearance = appearance64;
            this.CompanyTel3_Title_Label.Location = new System.Drawing.Point(318, 304);
            this.CompanyTel3_Title_Label.Name = "CompanyTel3_Title_Label";
            this.CompanyTel3_Title_Label.Size = new System.Drawing.Size(87, 23);
            this.CompanyTel3_Title_Label.TabIndex = 62;
            this.CompanyTel3_Title_Label.Text = "�d�b�ԍ��R";
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(300, 626);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 29;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SFUKN09020UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 692);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.CompanyTel1_Title_Label);
            this.Controls.Add(this.CompanyTel2_Title_Label);
            this.Controls.Add(this.CompanyTel3_Title_Label);
            this.Controls.Add(this.ImageInfoCode_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ImageCommentForPrt2_tEdit);
            this.Controls.Add(this.ImageCommentForPrt1_tEdit);
            this.Controls.Add(this.ImageCommentForPrt1_Title_Label);
            this.Controls.Add(this.CompanyPr2_tEdit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PostNo_Border_Label);
            this.Controls.Add(this.CompanyUrl_Title_Label);
            this.Controls.Add(this.CompanyUrl_tEdit);
            this.Controls.Add(this.CompanyTelNo1_tEdit);
            this.Controls.Add(this.CompanyTelTitle3_tEdit);
            this.Controls.Add(this.CompanyTelTitle2_tEdit);
            this.Controls.Add(this.CompanyTelTitle1_tEdit);
            this.Controls.Add(this.Address1_tEdit);
            this.Controls.Add(this.PostNo_tEdit);
            this.Controls.Add(this.PostNoMark_tEdit);
            this.Controls.Add(this.CompanyName2_tEdit);
            this.Controls.Add(this.CompanyName1_tEdit);
            this.Controls.Add(this.CompanyNameCd_tNedit);
            this.Controls.Add(this.Address3_tEdit);
            this.Controls.Add(this.Address4_tEdit);
            this.Controls.Add(this.CompanyTelNo2_tEdit);
            this.Controls.Add(this.CompanyTelNo3_tEdit);
            this.Controls.Add(this.TransferGuidance_tEdit);
            this.Controls.Add(this.AccountNoInfo1_tEdit);
            this.Controls.Add(this.AccountNoInfo2_tEdit);
            this.Controls.Add(this.AccountNoInfo3_tEdit);
            this.Controls.Add(this.CompanySetNote1_tEdit);
            this.Controls.Add(this.CompanySetNote2_tEdit);
            this.Controls.Add(this.CompanyPr_tEdit);
            this.Controls.Add(this.ImageInfoCode_Title_Label);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.CompanyNameCd_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.AddressGuide_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.CompanyName1_Title_Label);
            this.Controls.Add(this.PostNo_Title_Label);
            this.Controls.Add(this.CompanyName2_Title_Label);
            this.Controls.Add(this.Address_Title_Label);
            this.Controls.Add(this.CompanyTel1Title_Title_Label);
            this.Controls.Add(this.CompanyTel2Title_Title_Label);
            this.Controls.Add(this.CompanyTel3Title_Title_Label);
            this.Controls.Add(this.TransferGuidance_Title_Label);
            this.Controls.Add(this.AccountNoInfo1_Title_Label);
            this.Controls.Add(this.AccountNoInfo2_Title_Label);
            this.Controls.Add(this.AccountNoInfo3_Title_Label);
            this.Controls.Add(this.CompanySetNote_Title_Label);
            this.Controls.Add(this.CompanyPr_Title_Label);
            this.Controls.Add(this.ultraLabel4);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKN09020UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "���Ж��̐ݒ�";
            this.Load += new System.EventHandler(this.SFUKN09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKN09020UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKN09020UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameCd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNoMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransferGuidance_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanySetNote1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanySetNote2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPr_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPr2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCommentForPrt1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCommentForPrt2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageInfoCode_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKN09020UA());
		}
		#endregion

		#region Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ������ɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region Properties
		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get {
				return this._canClose;
			}
			set {
				this._canClose = value;
			}
		}

		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get {
				return this._canDelete;
			}
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get {
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>�V�K�쐬�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�쐬���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get {
				return this._canNew;
			}
		}

		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>������\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get {
				return this._canPrint;
			}
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanSpecificationSearch
		{
			get {
				return this._canSpecificationSearch;
			}
		}

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get {
				return this._dataIndex;
			}
			set {
				this._dataIndex = value;
			}
		}

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get {
				return this._defaultAutoFillToColumn;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �O���b�h�̊e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// �폜��
			appearanceTable.Add( DELETE_DATE, 
				new GridColAppearance( MGridColDispType.DeletionDataBoth, 
				ContentAlignment.MiddleLeft, "", Color.Red ) );
			// �R�[�h
			appearanceTable.Add( COMPANYNAMECD_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleRight, "", Color.Black ) );
			// ���Ж���
			appearanceTable.Add( COMPANYNAME_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// �X�֔ԍ�
			appearanceTable.Add( POSTNO_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// �Z��
			appearanceTable.Add( ADDRESS_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// �d�b�ԍ��P
			appearanceTable.Add( COMPANYTELNO1_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// �d�b�ԍ��Q
			appearanceTable.Add( COMPANYTELNO2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// �d�b�ԍ��R
			appearanceTable.Add( COMPANYTELNO3_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// ��s�U���ē���
			appearanceTable.Add( TRANSFERGUIDANCE_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// ��s�����P
			appearanceTable.Add( ACCOUNTNOINFO1_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// ��s�����Q
			appearanceTable.Add( ACCOUNTNOINFO2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// ��s�����R
			appearanceTable.Add( ACCOUNTNOINFO3_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// ���Аݒ�E�v�P
			appearanceTable.Add( COMPANYSETNOTE1_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// ���Аݒ�E�v�Q
			appearanceTable.Add( COMPANYSETNOTE2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// ���Ђo�q��
			appearanceTable.Add( COMPANYPR_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// ���Ђo�q���Q
			appearanceTable.Add( COMPANYPR2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            // �摜���敪
            appearanceTable.Add(IMAGEINFODIV_TITLE,
                new GridColAppearance(MGridColDispType.DetailsOnly,
                ContentAlignment.MiddleRight, "", Color.Black));
            // �摜���R�[�h
            appearanceTable.Add(IMAGEINFOCODE_TITLE,
                new GridColAppearance(MGridColDispType.DetailsOnly,
                ContentAlignment.MiddleRight, "", Color.Black));
            // ----------------------------------------------------------------
			// ����URL��
			appearanceTable.Add( COMPANYURL_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// GUID
			appearanceTable.Add( GUID_TITLE, 
				new GridColAppearance( MGridColDispType.None, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// �摜�󎚗p�R�����g�P
			appearanceTable.Add( IMAGECOMMENTFORPRT1_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// �摜�󎚗p�R�����g�Q
			appearanceTable.Add( IMAGECOMMENTFORPRT2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );

			return appearanceTable;
		}

		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u����</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
			bindDataSet	= this.Bind_DataSet;
			tableName	= COMPANYNM_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCnt">�S�Y������</param>
		/// <param name="readCnt">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Search( ref int totalCnt, int readCnt )
		{
			return SearchCompanyNm( ref totalCnt, readCnt );
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCnt">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�茏�����̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int SearchNext( int readCnt )
		{
			// ������
			return ( int )ConstantManagement.DB_Status.ctDB_EOF;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Delete()
		{
			return LogicalDelete();
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCnt">�S�Y������</param>
		/// <param name="readCnt">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private int SearchCompanyNm( ref int totalCnt, int readCnt )
		{
			int status = 0;
			ArrayList companyNms = null;

			// ���o�Ώی�����0���̏ꍇ�͑S�����o�����s����
			status = this._companyNmAcs.SearchAll( out companyNms, this._enterpriseCode );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
					foreach( CompanyNm companyNm in companyNms ) {
						if( this._companyNmTable.ContainsKey( companyNm.FileHeaderGuid ) == false ) {
							CompanyNmToDataSet( companyNm.Clone(), index );
							index++;
						}
					}

					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// �T�[�`
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���Ж��̐ݒ�", 					// �v���O��������
						"SearchCompanyNm", 					// ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._companyNmAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					break;
				}
			}
			
			totalCnt = companyNms.Count;

			return status;
		}

		/// <summary>
		/// ���Ж��̃I�u�W�F�N�g�W�J����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : ���Ж��̃N���X��DataSet�Ɋi�[���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void CompanyNmToDataSet( CompanyNm companyNm, int index )
		{
			if( ( index < 0 ) || ( index >= this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count ) ) {
				// �V�K�Ɣ��f���A�s��ǉ�����B
				DataRow dataRow = this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].NewRow();
				this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Add( dataRow );

				// index���ŏI�s�ԍ��ɂ���
				index = this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count - 1;
			}

			// �폜��
			if( companyNm.LogicalDeleteCode == 0 ) {
				this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ DELETE_DATE ] = "";
			}
			else {
				this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ DELETE_DATE ] = companyNm.UpdateDateTimeJpInFormal;
			}

			// ���Ж��̃R�[�h
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYNAMECD_TITLE ]	= companyNm.CompanyNameCd;
			// ���Ж���
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYNAME_TITLE ]		= companyNm.CompanyName1 + "�@" + companyNm.CompanyName2;
			// �X�֔ԍ�
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ POSTNO_TITLE ]			= companyNm.PostNo;
			string address = "";
			address += companyNm.Address1;
            # region 2007.05.27  S.Koga  DEL
            // �Z���Q�i���ځj����
            //if( companyNm.Address2 > 0 ) {
            //    address += companyNm.Address2.ToString() + "����";
            //}
            # endregion
            address += companyNm.Address3 + "�@" + companyNm.Address4;
			// �Z��
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ ADDRESS_TITLE ]			= address;
			// �d�b�ԍ��P
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYTELNO1_TITLE ]	= companyNm.CompanyTelTitle1 + " " + companyNm.CompanyTelNo1;
			// �d�b�ԍ��Q
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYTELNO2_TITLE ]	= companyNm.CompanyTelTitle2 + " " + companyNm.CompanyTelNo2;
			// �d�b�ԍ��R
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYTELNO3_TITLE ]	= companyNm.CompanyTelTitle3 + " " + companyNm.CompanyTelNo3;
			// ��s�U���ē���
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ TRANSFERGUIDANCE_TITLE ]	= companyNm.TransferGuidance;
			// ��s�����P
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ ACCOUNTNOINFO1_TITLE ]	= companyNm.AccountNoInfo1;
			// ��s�����Q
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ ACCOUNTNOINFO2_TITLE ]	= companyNm.AccountNoInfo2;
			// ��s�����R
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ ACCOUNTNOINFO3_TITLE ]	= companyNm.AccountNoInfo3;
			// ���Аݒ�E�v�P
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYSETNOTE1_TITLE ]	= companyNm.CompanySetNote1;
			// ���Аݒ�E�v�Q
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYSETNOTE2_TITLE ]	= companyNm.CompanySetNote2;
			// ���Ђo�q��
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYPR_TITLE ]		= companyNm.CompanyPr;
			// ���Ђo�q���Q
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYPR2_TITLE ]		= companyNm.CompanyPrSentence2;
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            // �摜���敪
            this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ IMAGEINFODIV_TITLE ]     = companyNm.ImageInfoDiv;
            // �摜���R�[�h
            this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ IMAGEINFOCODE_TITLE ]    = companyNm.ImageInfoCode;
            // ----------------------------------------------------------------
			// ���Ђt�q�k
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYURL_TITLE ]   = companyNm.CompanyUrl;
			// �摜�󎚗p�R�����g�P
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ IMAGECOMMENTFORPRT1_TITLE ]	= companyNm.ImageCommentForPrt1;
			// �摜�󎚗p�R�����g�Q
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ IMAGECOMMENTFORPRT2_TITLE ]	= companyNm.ImageCommentForPrt2;
			// GUID
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ GUID_TITLE ] = companyNm.FileHeaderGuid;

			if( this._companyNmTable.ContainsKey( companyNm.FileHeaderGuid ) == true ) {
				this._companyNmTable.Remove( companyNm.FileHeaderGuid );
			}
			this._companyNmTable.Add( companyNm.FileHeaderGuid, companyNm );

		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable companyNmTable = new DataTable( COMPANYNM_TABLE );
			companyNmTable.Columns.Add( DELETE_DATE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYNAMECD_TITLE, typeof( int ) );
			companyNmTable.Columns.Add( COMPANYNAME_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( POSTNO_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( ADDRESS_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYTELNO1_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYTELNO2_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYTELNO3_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( TRANSFERGUIDANCE_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( ACCOUNTNOINFO1_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( ACCOUNTNOINFO2_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( ACCOUNTNOINFO3_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYSETNOTE1_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYSETNOTE2_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYPR_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYPR2_TITLE, typeof( string ) );
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            companyNmTable.Columns.Add( IMAGEINFODIV_TITLE, typeof( int ) );
            companyNmTable.Columns.Add( IMAGEINFOCODE_TITLE, typeof( int ) );
            // ----------------------------------------------------------------
			companyNmTable.Columns.Add( COMPANYURL_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( IMAGECOMMENTFORPRT1_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( IMAGECOMMENTFORPRT2_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( GUID_TITLE, typeof( Guid ) );

			this.Bind_DataSet.Tables.Add( companyNmTable );
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// �{�^���z�u
			int CANCELBUTTONLOCATION_X	= this.Cancel_Button.Location.X;
			int OKBUTTONLOCATION_X		= this.Ok_Button.Location.X;
			int DELETEBUTTONLOCATION_X	= this.Revive_Button.Location.X;
			int BUTTONLOCATION_Y		= this.Cancel_Button.Location.Y;
			this.Cancel_Button.Location		= new System.Drawing.Point( CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y );
			this.Ok_Button.Location			= new System.Drawing.Point( OKBUTTONLOCATION_X, BUTTONLOCATION_Y );
			this.Revive_Button.Location		= new System.Drawing.Point( OKBUTTONLOCATION_X, BUTTONLOCATION_Y );
			this.Delete_Button.Location		= new System.Drawing.Point( DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y );
            this.ImageInfoCode_tComboEditor.Items.Clear();
            // 2007.05.17  S.Koga  add ----------------------------------------
            GetImageInfoCode(IMAGEINFODIV_DATA);
            // ----------------------------------------------------------------

        }

        // 2007.05.17  S.Koga  add --------------------------------------------
        private void GetImageInfoCode(int imageInfoCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int totalcount = 0;
            status = this._imageInfoAcs.Search(out totalcount, this._enterpriseCode, imageInfoCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (totalcount > 0))
            {
                ImageInfoDS = this._imageInfoAcs.BindDataSet;
                DataTable imageDT = ImageInfoDS.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];
                this.ImageInfoCode_tComboEditor.MaxLength = imageDT.DefaultView.Count + 1;
                this.ImageInfoCode_tComboEditor.Items.Add(0, " ");
                for (int i = 0; i < imageDT.DefaultView.Count; i++)
                {
                    DataRow imageDR = imageDT.DefaultView[i].Row;
                    // --- CHG 2008/11/06 --------------------------------------------------------------------->>>>>
                    //this.ImageInfoCode_tComboEditor.Items.Add((int)imageDR[ImageInfoAcs.COL_IMAGEINFOCODE_TITLE], (string)imageDR[ImageInfoAcs.COL_IMAGEINFONAME_TITLE]);
                    this.ImageInfoCode_tComboEditor.Items.Add(int.Parse((string)imageDR[ImageInfoAcs.COL_IMAGEINFOCODE_TITLE]), (string)imageDR[ImageInfoAcs.COL_IMAGEINFONAME_TITLE]);
                    // --- CHG 2008/11/06 ---------------------------------------------------------------------<<<<<
                }
            }
            else
            {
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetErrorMessage(status);
                // �󔒂��Z�b�g
                this.ImageInfoCode_tComboEditor.MaxLength = 1;
                this.ImageInfoCode_tComboEditor.Items.Add(0, " ");
            }
        }

        private void SetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �摜��񂪓o�^����Ă��Ȃ����߂��̂܂܏I��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
                            "MAKHN09632A", 							// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�摜��񂪎擾�ł��܂���B",           // �\�����郁�b�Z�[�W
                            errorCode, 								// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "MAKHN09632A", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���Ж��̐ݒ�", 					// �v���O��������
                            "SetErrorMessage", 					// ��������
                            TMsgDisp.OPE_LOAD,   				// �I�y���[�V����
                            "�摜���擾�Ɏ��s���܂����B",     // �\�����郁�b�Z�[�W
                            errorCode, 							// �X�e�[�^�X�l
                            this._imageInfoAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        break;
                    }
            }
        }
        // --------------------------------------------------------------------

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.12</br>
        /// </remarks>
        private void ScreenClear()
		{
			this.CompanyNameCd_tNedit.Clear();		// ���Ж��̃R�[�h
			this.CompanyName1_tEdit.Clear();		// ���Ж��̂P
			this.CompanyName2_tEdit.Clear();		// ���Ж��̂Q
			this.PostNo_tEdit.Clear();				// �X�֔ԍ�
			this.Address1_tEdit.Clear();			// �Z���P
            //this.Address2_tNedit.Clear();			// �Z���Q  // DEL 2008/06/04
			this.Address3_tEdit.Clear();			// �Z���R
			this.Address4_tEdit.Clear();			// �Z���S
			this.CompanyTelTitle1_tEdit.Clear();	// ���Гd�b�ԍ��^�C�g���P
			this.CompanyTelTitle2_tEdit.Clear();	// ���Гd�b�ԍ��^�C�g���Q
			this.CompanyTelTitle3_tEdit.Clear();	// ���Гd�b�ԍ��^�C�g���R
			this.CompanyTelNo1_tEdit.Clear();		// ���Гd�b�ԍ��P
			this.CompanyTelNo2_tEdit.Clear();		// ���Гd�b�ԍ��Q
			this.CompanyTelNo3_tEdit.Clear();		// ���Гd�b�ԍ��R
			this.TransferGuidance_tEdit.Clear();	// ��s�U���ē���
			this.AccountNoInfo1_tEdit.Clear();		// ��s�����P
			this.AccountNoInfo2_tEdit.Clear();		// ��s�����Q
			this.AccountNoInfo3_tEdit.Clear();		// ��s�����R
			this.CompanySetNote1_tEdit.Clear();		// ���Аݒ�E�v�P
			this.CompanySetNote2_tEdit.Clear();		// ���Аݒ�E�v�Q
			this.CompanyPr_tEdit.Clear();			// ���Ђo�q��
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            this.ImageInfoCode_tComboEditor.SelectedIndex = 0;  // �摜���R�[�h
            // ----------------------------------------------------------------
			this.CompanyUrl_tEdit.Clear();			// ����URL��
			this.CompanyPr2_tEdit.Clear();          // ����PR���Q
			this.ImageCommentForPrt1_tEdit.Clear(); // �摜�󎚗p�R�����g�P
			this.ImageCommentForPrt2_tEdit.Clear(); // �摜�󎚗p�R�����g�Q
            # region 2007.05.17  S.Koga  DEL
            //this.Image_tEdit.Clear();	// �捞�摜�p�X

            //this.TakeInImage_GuideButton.Enabled = false;
            //this.TakeInImageDelete_Button.Enabled = false;
			// �摜�\���s�N�`���[�{�b�N�X
            //this.TakeInImage_UltraPictureBox.Image = null;
            //this._imageGroup		= null;
            //this._imgManage			= null;
            # endregion
            this._changeTakeInImage	= false;
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			this._imageTransferring	= false;
//
//			// �]��������null�ŏ�����
//			this._waitWindow = null;
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			this._changeFlg = false;
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			if( this._dataIndex < 0 ) {
				// �V�K���[�h
				this._logicalDeleteMode = -1;

				CompanyNm newCompanyNm		= new CompanyNm();
				// ���Ж��̃I�u�W�F�N�g����ʂɓW�J
				CompanyNmToScreen( newCompanyNm );

                # region 2007.05.17  S.Koga  DEL
                //TakeInImageToScreen( newCompanyNm );
                # endregion

                // �N���[���쐬
				this._companyNmClone = newCompanyNm.Clone();
				DispToCompanyNm( ref this._companyNmClone );
                this.ImageInfoCode_tComboEditor.NullText = "";
			}
			else {
				Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
				CompanyNm companyNm = ( CompanyNm )this._companyNmTable[ guid ];

				// ���Ж��̃I�u�W�F�N�g����ʂɓW�J
				CompanyNmToScreen( companyNm );

                # region 2007.05.17  S.Koga  DEL
                //TakeInImageToScreen( companyNm );
                # endregion

                if ( companyNm.LogicalDeleteCode == 0 ) {
					// �X�V���[�h
					this._logicalDeleteMode = 0;

					// �N���[���쐬
					this._companyNmClone = companyNm.Clone();
					DispToCompanyNm( ref this._companyNmClone );
				}
				else {
					// �폜���[�h
					this._logicalDeleteMode = 1;
				}
			}
			// _GridIndex�o�b�t�@�ێ��i���C���t���[���ŏ����Ή��j
			this._indexBuf = this._dataIndex;

			ScreenInputPermissionControl();
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void ScreenInputPermissionControl()
		{
            switch (this._logicalDeleteMode)
            {
				case -1:
				{
					// �V�K���[�h
					this.Mode_Label.Text		= INSERT_MODE;

					// �{�^���̕\��
                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= false;
					this.Delete_Button.Visible		= false;

					// �R���g���[���̕\���ݒ�
					ScreenInputPermissionControl( true );

					// �X�֔ԍ��}�[�N�̔w�i�F�ݒ�
					this.PostNoMark_tEdit.Appearance.BackColorDisabled = System.Drawing.Color.White;

					// �����t�H�[�J�X���Z�b�g
					this.CompanyNameCd_tNedit.Focus();
					this.CompanyNameCd_tNedit.SelectAll();

					break;
				}
				case 1:
				{
					// �폜���[�h
					this.Mode_Label.Text		= DELETE_MODE;

					// �{�^���̕\��
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= true;
					this.Delete_Button.Visible		= true;

					// �R���g���[���̕\���ݒ�
					ScreenInputPermissionControl( false );

					// �X�֔ԍ��}�[�N�̔w�i�F�ݒ�
					this.PostNoMark_tEdit.Appearance.BackColorDisabled = System.Drawing.SystemColors.Control;

					// �����t�H�[�J�X���Z�b�g
					this.Delete_Button.Focus();

					break;
				}
				default:
				{
					// �X�V���[�h
					this.Mode_Label.Text		= UPDATE_MODE;

					// �{�^���̕\��
                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= false;
					this.Delete_Button.Visible		= false;

					// �R���g���[���̕\���ݒ�
					ScreenInputPermissionControl( true );
					this.CompanyNameCd_tNedit.Enabled	= false;

					// �X�֔ԍ��}�[�N�̔w�i�F�ݒ�
					this.PostNoMark_tEdit.Appearance.BackColorDisabled = System.Drawing.Color.White;

					// �����t�H�[�J�X���Z�b�g
					this.CompanyPr_tEdit.Focus();
					this.CompanyPr_tEdit.SelectAll();

					break;
				}
			}
		}
		
		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		void ScreenInputPermissionControl( bool enabled )
		{
			this.CompanyNameCd_tNedit.Enabled		= enabled;	// ���Ж��̃R�[�h
			this.CompanyName1_tEdit.Enabled			= enabled;	// ���Ж��̂P
			this.CompanyName2_tEdit.Enabled			= enabled;	// ���Ж��̂Q
			this.PostNo_tEdit.Enabled				= enabled;	// �X�֔ԍ�
			this.PostNo_Border_Label.Enabled		= enabled;	// �X�֔ԍ��{�[�_�[�B���p���x��
			this.AddressGuide_Button.Enabled		= enabled;	// �Z���K�C�h�{�^��
			this.Address1_tEdit.Enabled				= enabled;	// �Z���P
            //this.Address2_tNedit.Enabled			= enabled;	// �Z���Q  // DEL 2008/06/04
			this.Address3_tEdit.Enabled				= enabled;	// �Z���R
			this.Address4_tEdit.Enabled				= enabled;	// �Z���S
			this.CompanyTelTitle1_tEdit.Enabled		= enabled;	// ���Гd�b�ԍ��^�C�g���P
			this.CompanyTelTitle2_tEdit.Enabled		= enabled;	// ���Гd�b�ԍ��^�C�g���Q
			this.CompanyTelTitle3_tEdit.Enabled		= enabled;	// ���Гd�b�ԍ��^�C�g���R
			this.CompanyTelNo1_tEdit.Enabled		= enabled;	// ���Гd�b�ԍ��P
			this.CompanyTelNo2_tEdit.Enabled		= enabled;	// ���Гd�b�ԍ��Q
			this.CompanyTelNo3_tEdit.Enabled		= enabled;	// ���Гd�b�ԍ��R
			this.TransferGuidance_tEdit.Enabled		= enabled;	// ��s�U���ē���
			this.AccountNoInfo1_tEdit.Enabled		= enabled;	// ��s�����P
			this.AccountNoInfo2_tEdit.Enabled		= enabled;	// ��s�����Q
			this.AccountNoInfo3_tEdit.Enabled		= enabled;	// ��s�����R
			this.CompanySetNote1_tEdit.Enabled		= enabled;	// ���Аݒ�E�v�P
			this.CompanySetNote2_tEdit.Enabled		= enabled;	// ���Аݒ�E�v�Q
			this.CompanyPr_tEdit.Enabled			= enabled;	// ���Ђo�q��
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            this.ImageInfoCode_tComboEditor.Enabled = enabled;  // �摜���R�[�h
            // ----------------------------------------------------------------
			this.CompanyUrl_tEdit.Enabled			= enabled;	// ����URL��
			this.CompanyPr2_tEdit.Enabled           = enabled;  // ����PR���Q
			this.ImageCommentForPrt1_tEdit.Enabled  = enabled;  // �摜�󎚗p�R�����g�P
			this.ImageCommentForPrt2_tEdit.Enabled  = enabled;  // �摜�󎚗p�R�����g�Q
            # region 2007.05.17  S.Koga  DEL
            //this.TakeInImage_GuideButton.Enabled	= enabled;	// ���Љ摜�I���{�^��
            //this.TakeInImageDelete_Button.Enabled	= enabled;	// ���Љ摜�폜�{�^��
            # endregion

        }

		/// <summary>
		/// ���Ж��̃N���X��ʓW�J����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���Ж��̃I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void CompanyNmToScreen( CompanyNm companyNm )
		{
			
			if( companyNm.CompanyNameCd == 0 ) {
				this.CompanyNameCd_tNedit.Clear();									// ���Ж��̃R�[�h
			}
			else {
				this.CompanyNameCd_tNedit.SetInt( companyNm.CompanyNameCd );		// ���Ж��̃R�[�h
			}
			this.CompanyName1_tEdit.DataText		= companyNm.CompanyName1;		// ���Ж��̂P
			this.CompanyName2_tEdit.DataText		= companyNm.CompanyName2;		// ���Ж��̂Q
			this.PostNo_tEdit.DataText				= companyNm.PostNo;				// �X�֔ԍ�
			this.Address1_tEdit.DataText			= companyNm.Address1;			// �Z���P
            // 2007.05.27  S.Koga  amend --------------------------------------
            //this.Address2_tNedit.SetInt( companyNm.Address2 );						// �Z���Q
            //this.Address2_tNedit.SetInt(0);  // DEL 2008/06/04
            // ----------------------------------------------------------------
			this.Address3_tEdit.DataText			= companyNm.Address3;			// �Z���R
			this.Address4_tEdit.DataText			= companyNm.Address4;			// �Z���S
			this.CompanyTelTitle1_tEdit.DataText	= companyNm.CompanyTelTitle1;	// ���Гd�b�ԍ��^�C�g���P
			this.CompanyTelTitle2_tEdit.DataText	= companyNm.CompanyTelTitle2;	// ���Гd�b�ԍ��^�C�g���Q
			this.CompanyTelTitle3_tEdit.DataText	= companyNm.CompanyTelTitle3;	// ���Гd�b�ԍ��^�C�g���R
			this.CompanyTelNo1_tEdit.DataText		= companyNm.CompanyTelNo1;		// ���Гd�b�ԍ��P
			this.CompanyTelNo2_tEdit.DataText		= companyNm.CompanyTelNo2;		// ���Гd�b�ԍ��Q
			this.CompanyTelNo3_tEdit.DataText		= companyNm.CompanyTelNo3;		// ���Гd�b�ԍ��R
			this.TransferGuidance_tEdit.DataText	= companyNm.TransferGuidance;	// ��s�U���ē���
			this.AccountNoInfo1_tEdit.DataText		= companyNm.AccountNoInfo1;		// ��s�����P
			this.AccountNoInfo2_tEdit.DataText		= companyNm.AccountNoInfo2;		// ��s�����Q
			this.AccountNoInfo3_tEdit.DataText		= companyNm.AccountNoInfo3;		// ��s�����R
			this.CompanySetNote1_tEdit.DataText		= companyNm.CompanySetNote1;	// ���Аݒ�E�v�P
			this.CompanySetNote2_tEdit.DataText		= companyNm.CompanySetNote2;	// ���Аݒ�E�v�Q
			this.CompanyPr_tEdit.DataText			= companyNm.CompanyPr;			// ���Ђo�q��
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            this.ImageInfoCode_tComboEditor.Value = (object)companyNm.ImageInfoCode;   // �摜���R�[�h
            // ----------------------------------------------------------------
			this.CompanyUrl_tEdit.DataText			= companyNm.CompanyUrl;			// ����URL��
			this.CompanyPr2_tEdit.DataText          = companyNm.CompanyPrSentence2;  // ����PR���Q
			this.ImageCommentForPrt1_tEdit.DataText = companyNm.ImageCommentForPrt1;  // �摜�󎚗p�R�����g�P
			this.ImageCommentForPrt2_tEdit.DataText = companyNm.ImageCommentForPrt2;  // �摜�󎚗p�R�����g�Q
		}

		/// <summary>
		/// ���Ж��̃N���X�i�[����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂玩�Ж��̃I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void DispToCompanyNm( ref CompanyNm companyNm )
		{
			if( companyNm == null ) {
				companyNm = new CompanyNm();
			}

			companyNm.EnterpriseCode	= this._enterpriseCode;					// ��ƃR�[�h
			companyNm.CompanyNameCd		= this.CompanyNameCd_tNedit.GetInt();	// ���Ж��̃R�[�h
			companyNm.CompanyName1		= this.CompanyName1_tEdit.DataText;		// ���Ж��̂P
			companyNm.CompanyName2		= this.CompanyName2_tEdit.DataText;		// ���Ж��̂Q
			companyNm.PostNo			= this.PostNo_tEdit.DataText;			// �X�֔ԍ�
			companyNm.Address1			= this.Address1_tEdit.DataText;			// �Z���P
            //companyNm.Address2			= this.Address2_tNedit.GetInt();		// �Z���Q  // DEL 2008/06/04
			companyNm.Address3			= this.Address3_tEdit.DataText;			// �Z���R
			companyNm.Address4			= this.Address4_tEdit.DataText;			// �Z���S
			companyNm.CompanyTelTitle1	= this.CompanyTelTitle1_tEdit.DataText;	// ���Гd�b�ԍ��^�C�g���P
			companyNm.CompanyTelTitle2	= this.CompanyTelTitle2_tEdit.DataText;	// ���Гd�b�ԍ��^�C�g���Q
			companyNm.CompanyTelTitle3	= this.CompanyTelTitle3_tEdit.DataText;	// ���Гd�b�ԍ��^�C�g���R
			companyNm.CompanyTelNo1		= this.CompanyTelNo1_tEdit.DataText;	// ���Гd�b�ԍ��P
			companyNm.CompanyTelNo2		= this.CompanyTelNo2_tEdit.DataText;	// ���Гd�b�ԍ��Q
			companyNm.CompanyTelNo3		= this.CompanyTelNo3_tEdit.DataText;	// ���Гd�b�ԍ��R
			companyNm.TransferGuidance	= this.TransferGuidance_tEdit.DataText;	// ��s�U���ē���
			companyNm.AccountNoInfo1	= this.AccountNoInfo1_tEdit.DataText;	// ��s�����P
			companyNm.AccountNoInfo2	= this.AccountNoInfo2_tEdit.DataText;	// ��s�����Q
			companyNm.AccountNoInfo3	= this.AccountNoInfo3_tEdit.DataText;	// ��s�����R
			companyNm.CompanySetNote1	= this.CompanySetNote1_tEdit.DataText;	// ���Аݒ�E�v�P
			companyNm.CompanySetNote2	= this.CompanySetNote2_tEdit.DataText;	// ���Аݒ�E�v�Q
			companyNm.CompanyPr			= this.CompanyPr_tEdit.DataText;		// ���Ђo�q��
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            companyNm.ImageInfoDiv      = IMAGEINFODIV_DATA;                    // �摜���敪
            if(this.ImageInfoCode_tComboEditor.SelectedItem != null)
                companyNm.ImageInfoCode     = (int)this.ImageInfoCode_tComboEditor.SelectedItem.DataValue;   // �摜���R�[�h
            // ----------------------------------------------------------------
			companyNm.CompanyUrl		= this.CompanyUrl_tEdit.DataText;		// ����URL��
			companyNm.CompanyPrSentence2 = this.CompanyPr2_tEdit.DataText;  // ����PR���Q
			companyNm.ImageCommentForPrt1 = this.ImageCommentForPrt1_tEdit.DataText;  // �摜�󎚗p�R�����g�P
			companyNm.ImageCommentForPrt2 = this.ImageCommentForPrt2_tEdit.DataText;  // �摜�󎚗p�R�����g�Q

            # region 2007.05.17  S.Koga  DEL
            //if ( companyNm.TakeInImageGroupCd == Guid.Empty ) 
            //{
            //    if( this.TakeInImage_UltraPictureBox.Image != null ) {
            //        companyNm.TakeInImageGroupCd = Guid.NewGuid();
            //    }
            //}
            //else {
            //    if( this.TakeInImage_UltraPictureBox.Image == null ) {
            //        companyNm.TakeInImageGroupCd = Guid.Empty;
            //    }
            //}
            # endregion
        }

        # region 2007.05.17  S.Koga  DEL
        ///// <summary>
        ///// �捞�摜�\������
        ///// </summary>
        ///// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
        ///// <remarks>
        ///// <br>Note       : �捞�摜���擾���ĕ\�����s���܂��B�i���ۂ̕\�������͉摜�f�[�^��M�����C�x���g�̒��ōs���܂��B�j</br>
        ///// <br>Programmer : 23001 �H�R�@����</br>
        ///// <br>Date       : 2005.10.11</br>
        ///// </remarks>
        //private void TakeInImageToScreen( CompanyNm companyNm )
        //{
        //    if( this._dataIndex < 0 ) {
        //        companyNm.TakeInImageGroupCd = Guid.Empty;
        //    }
        //    else {
        //        if( companyNm.TakeInImageGroupCd != Guid.Empty ) {
        //            int status = ReadImageData( this._enterpriseCode, companyNm.TakeInImageGroupCd );
        //            if( status != 0 ) {
        //                companyNm.TakeInImageGroupCd = Guid.Empty;
        //            }
        //        }
        //    }
        //}
        # endregion

        /// <summary>
		/// ���Ж��̕ۑ�����
		/// </summary>
		/// <returns>����</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̕ۑ����s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;

			// ���̓`�F�b�N
			Control control = null;
			string message = null;
			if( !ScreenDataCheck( ref control, ref message ) ) {
				// ���̓`�F�b�N
				TMsgDisp.Show( 
					this, 								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
					"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
					message, 							// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.OK );				// �\������{�^��
				control.Focus();
				if( control is TNedit ) {
					( ( TNedit )control ).SelectAll();
				}
				else if( control is TEdit ) {
					( ( TEdit )control ).SelectAll();
				}
				return result;
			}

			CompanyNm companyNm = null;
			if( this._dataIndex >= 0 ) {
				Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
///////////////////////////////////////////////////////////////////// 2005.11.01 AKIYAMA ADD STA //
				// �i�Ǐ�Q�Ή� (�Ǘ�No.000273-01)
				companyNm = ( ( CompanyNm )this._companyNmTable[ guid ] ).Clone();
// 2005.11.01 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.11.01 AKIYAMA DEL STA //
//				companyNm = ( CompanyNm )this._companyNmTable[ guid ];
// 2005.11.01 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			}
			DispToCompanyNm( ref companyNm );

			int status = this._companyNmAcs.Write( ref companyNm );
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    # region 2007.05.17  S.Koga  DEL
                        // �摜�Ǘ��}�X�^�֕ۑ�
                    //if( companyNm.TakeInImageGroupCd != Guid.Empty ) {
                    //    if( this._changeTakeInImage == true ) {
                    //        status = SaveImageData( this._enterpriseCode, companyNm.TakeInImageGroupCd );
                    //    }
                    //}
					// �摜�Ǘ��}�X�^����폜
//                    else {
//                        if( this._imageGroup != null ) {
//// 2006.08.18 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                            this._SFUKN09020UB.Delete( this._imageGroup );
//// 2006.08.18 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
//// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
////							this._imageImgAcs.Delete( this._imageGroup );
//// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
//                        }
//                    }
                        # endregion
                    // VIEW�̃f�[�^�Z�b�g���X�V
					CompanyNmToDataSet( companyNm.Clone(), this._dataIndex );
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// �R�[�h�d��
					TMsgDisp.Show( 
						this, 									// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
						"SFUKN09020U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
						"���̃R�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
						0, 										// �X�e�[�^�X�l
						MessageBoxButtons.OK );					// �\������{�^��
					this.CompanyNameCd_tNedit.Focus();
					this.CompanyNameCd_tNedit.SelectAll();
					return result;
				}
				// �r������
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return result;
				}
				default:
				{
					// �o�^���s
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���Ж��̐ݒ�", 					// �v���O��������
						"SaveProc", 						// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._companyNmAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					CloseForm( DialogResult.Cancel );
					return result;
				}
			}

			result = true;
			return result;
		}

        /// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͂̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

			// ���Ж��̃R�[�h
			if( this.CompanyNameCd_tNedit.GetInt() == 0 ) {
				message = this.CompanyNameCd_Title_Label.Text + "����͂��Ă��������B";
				control = this.CompanyNameCd_tNedit;
				result = false;
			}
			// ���Ж���
			else if( this.CompanyName1_tEdit.DataText.TrimEnd() == "" ) {
				message = this.CompanyName1_Title_Label.Text + "����͂��Ă��������B";
				control = this.CompanyName1_tEdit;
				result = false;
			}

			return result;
		}

		/// <summary>
		/// ���Ж��̃I�u�W�F�N�g�_���폜����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̃I�u�W�F�N�g�̘_���폜���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private int LogicalDelete()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// ���擾
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
			CompanyNm companyNm = ( ( CompanyNm )this._companyNmTable[ guid ] ).Clone();

			// ���Ж��̂����݂��Ă��Ȃ�
			if( companyNm == null ) {
				return -1;
			}

			status = this._companyNmAcs.LogicalDelete( ref companyNm );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					CompanyNmToDataSet( companyNm.Clone(), this._dataIndex );
					break;
				}
				// �r������
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, false );
					return status;
				}
///////////////////////////////////////////////////////////////////// 2005.12.09 AKIYAMA ADD STA //
				// ���_�ݒ�Ŏg�p��
				case -2:
				{
					TMsgDisp.Show( 
						this, 									// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
						"SFUKN09020U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
						// �\�����郁�b�Z�[�W
						"���̃��R�[�h�͋��_�ݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���B", 
						status, 								// �X�e�[�^�X�l
						MessageBoxButtons.OK );					// �\������{�^��
					return status;
				}
// 2005.12.09 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				default:
				{
						// �_���폜
						TMsgDisp.Show( 
							this, 								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
							"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
							"���Ж��̐ݒ�", 					// �v���O��������
							"LogicalDelete", 					// ��������
							TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
							"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
							status, 							// �X�e�[�^�X�l
							this._companyNmAcs, 				// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK, 				// �\������{�^��
							MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					return status;
				}
			}
			return status;
		}

		/// <summary>
		/// ���Ж��̃I�u�W�F�N�g�_���폜��������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̃I�u�W�F�N�g�̘_���폜�������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private int Revival()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// ���擾
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
			CompanyNm companyNm = ( ( CompanyNm )this._companyNmTable[ guid ] ).Clone();

			// ���Ж��̂����݂��Ă��Ȃ�
			if( companyNm == null ) {
				return -1;
			}

			status = this._companyNmAcs.Revival( ref companyNm );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					CompanyNmToDataSet( companyNm.Clone(), this._dataIndex );
					break;
				}
				// �r������
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// �������s
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���Ж��̐ݒ�", 					// �v���O��������
						"Revival", 							// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._companyNmAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					CloseForm( DialogResult.Cancel );
					return status;
				}
			}
			return status;
		}

		/// <summary>
		/// ���Ж��̃I�u�W�F�N�g���S�폜����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̃I�u�W�F�N�g�̊��S�폜���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private int PhysicalDelete()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// ���擾
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
			CompanyNm companyNm = ( CompanyNm )this._companyNmTable[ guid ];

			// ���Ж��̂����݂��Ă��Ȃ�
			if( companyNm == null ) {
				return -1;
			}

			status = this._companyNmAcs.Delete( companyNm );
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    # region 2007.05.17  S.Koga  DEL
                        // �摜�Ǘ��}�X�^����폜
                    //if( ( companyNm.TakeInImageGroupCd != Guid.Empty ) && ( this._imageGroup != null ) ) {
// 2006.08.18 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                        //this._SFUKN09020UB.Delete( this._imageGroup );
// 2006.08.18 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//						this._imageImgAcs.Delete( this._imageGroup );
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                    //}
                        # endregion
                    // �n�b�V���e�[�u������f�[�^���폜
					this._companyNmTable.Remove( ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex][ GUID_TITLE ] );
					// �f�[�^�Z�b�g����f�[�^���폜
					this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex].Delete();
					break;
				}
				// �r������
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// �����폜
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���Ж��̐ݒ�", 					// �v���O��������
						"PhysicalDelete", 					// ��������
						TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
						"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
						this._companyNmAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					CloseForm( DialogResult.Cancel );
					return status;
				}
			}
			return status;
		}

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
		/// <remarks>
		/// <br>Note       : �r���������s���܂�</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void ExclusiveTransaction( int status, bool hide )
		{
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// ���[���X�V
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
					if( hide == true ) {
						CloseForm( DialogResult.Cancel );
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// ���[���폜
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						"���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.OK );				// �\������{�^��
					if( hide == true ) {
						CloseForm( DialogResult.Cancel );
					}
					break;
				}
			}
		}

		/// <summary>
		/// �t�H�[���N���[�Y�����j
		/// </summary>
		/// <param name="dialogResult">�_�C�A���O����</param>
		/// <remarks>
		/// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void CloseForm( DialogResult dialogResult )
		{
			// ��ʔ�\���C�x���g
			if ( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( dialogResult );
				UnDisplaying( this, me );
			}

			this.DialogResult = dialogResult;

			// _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;
			
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// �X�֔ԍ��ύX����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �X�֔ԍ��ɂ��킹�ĕ\������Ă���Z���P�̕ύX���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNoChange()
		{
			AddressGuide addressGuide			= new AddressGuide();
			AddressGuideResult addrGuideResult	= null;
			string postNo = this.PostNo_tEdit.DataText.TrimEnd();

			// �Z���}�X�^�Ǎ���
			DialogResult result = addressGuide.ShowPostNoSearchGuide( postNo, out addrGuideResult );
			if( ( result == DialogResult.OK ) && 
				( addrGuideResult.PostNo != "" ) && 
				( addrGuideResult.AddressName != "" ) ) {
				// �X�֔ԍ�
				this.PostNo_tEdit.DataText		= addrGuideResult.PostNo;

// 2006.05.19 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// �Z���P
				this.SetAddress1( addrGuideResult.AddressName );
// 2006.05.19 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.05.19 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				this.Address1_tEdit.DataText	= addrGuideResult.AddressName;
// 2006.05.19 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			}
		}

// 2006.05.19 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		/// <summary>
		/// �Z���P�i�[����
		/// </summary>
		/// <param name="address1">�i�[�ΏۏZ���P</param>
		/// <remarks>
		/// <br>Note       : �Z���P����ʂɕ\�����܂��B���������������͕������āA�Z���R�Ɋi�[���܂��B</br>
		/// </remarks>
		private void SetAddress1( string address1 )
		{
			// �Z���P�̕�������30�𒴂��鎞�́A�������ďZ���R�֊i�[
			if( address1.Length > 30 ) {
				string wkAddress3 = "";

				// �Z���P(�擪����30�����܂ł��i�[)
				this.Address1_tEdit.DataText     = address1.Substring( 0, 30 );
				// �Z���R(31�����ڂ��疖���܂�)
				wkAddress3                       = address1.Substring( 30, address1.Length - 30 );

				// �Z���R�ɂ����肫��Ȃ��ꍇ(�Z���R��22�����𒴂���ꍇ)
				if( wkAddress3.Length > 22 ) {
					// �Z���R(�擪����22�����܂ł��i�[)
					this.Address3_tEdit.DataText = wkAddress3.Substring( 0, 22 );
					// �Z���S(23�����ڂ���30�������B)
					this.Address3_tEdit.DataText = wkAddress3.Substring( 22, Math.Min( wkAddress3.Length - 22, 30 ) );
				}
				else {
					// �Z���R
					this.Address3_tEdit.DataText = wkAddress3;
				}
			}
			else {
				// �Z���P
				this.Address1_tEdit.DataText     = address1;
			}
		}
// 2006.05.19 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		#endregion

		#region Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFUKN09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void SFUKN09020UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
			this.Cancel_Button.ImageList						= imageList24;
			this.Revive_Button.ImageList						= imageList24;
			this.Delete_Button.ImageList						= imageList24;
			this.AddressGuide_Button.ImageList					= imageList16;
            # region 2007.05.17  S.Koga  DEL
            //this.TakeInImage_GuideButton.ImageList				= imageList16;
            # endregion

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;	// �ۑ��{�^��
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;	// �ŐV���{�^��
			this.Cancel_Button.Appearance.Image					= Size24_Index.CLOSE;	// ����{�^��
			this.Revive_Button.Appearance.Image					= Size24_Index.REVIVAL;	// �����{�^��
			this.Delete_Button.Appearance.Image					= Size24_Index.DELETE;	// ���S�폜�{�^��
			this.AddressGuide_Button.Appearance.Image			= Size16_Index.STAR1;	// �Z���K�C�h�{�^��
            # region 2007.05.17  S.Koga  DEL
            //this.TakeInImage_GuideButton.Appearance.Image		= Size16_Index.STAR1;	// ���Љ摜�K�C�h�{�^��
            # endregion

            // ��ʂ��\�z
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFUKN09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void SFUKN09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			if( this._canClose == false ) {
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Form.VisibleChanged �C�x���g(SFUKN09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void SFUKN09020UA_VisibleChanged(object sender, System.EventArgs e)
		{
			if( this.Visible == false ) {
///////////////////////////////////////////////////////////////////// 2005.10.19 AKIYAMA ADD STA //
				this.Owner.Activate();
// 2005.10.19 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				return;
			}

			// _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			// �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ������ꍇ�ȉ��̏������L�����Z������
			if( this._indexBuf == this._dataIndex ) {
				return;
			}

			this.Initial_Timer.Enabled = true;
			ScreenClear();
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
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;
		
			ScreenReconstruction();
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if( !SaveProc() ) {			// �o�^
				return;
			}

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

			// �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if ( this.Mode_Label.Text == INSERT_MODE )
			{
				ScreenClear();

				// �V�K���[�h
				this._logicalDeleteMode = -1;

				CompanyNm newCompanyNm		= new CompanyNm();
				// ���Ж��̃I�u�W�F�N�g����ʂɓW�J
				CompanyNmToScreen( newCompanyNm );

                # region 2007.05.17  S.Koga  DEL
                //TakeInImageToScreen( newCompanyNm );
                # endregion

                // �N���[���쐬
				this._companyNmClone = newCompanyNm.Clone();
				DispToCompanyNm( ref this._companyNmClone );

				// _GridIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;

				ScreenInputPermissionControl();
			}
			else {
				this.DialogResult = DialogResult.OK;

				// _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
				this._indexBuf = -2;

				if( this._canClose == true ) {
					this.Close();
				}
				else {
					this.Hide();
				}
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if( this.Mode_Label.Text != DELETE_MODE ) {
				// ���݂̉�ʏ����擾����
				CompanyNm compareCompanyNm = new CompanyNm();
				compareCompanyNm = this._companyNmClone.Clone();
				DispToCompanyNm( ref compareCompanyNm );

				// �ŏ��Ɏ擾������ʏ��Ɣ�r
				if( !( this._companyNmClone.Equals( compareCompanyNm ) ) || ( this._changeTakeInImage == true ) ) {
					// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					// �ۑ��m�F
					DialogResult res = TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
						"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						null, 								// �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel );	// �\������{�^��
					switch( res ) {
						case DialogResult.Yes:
						{
							if ( !SaveProc() ) {
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
							// 2009.03.23 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                CompanyNameCd_tNedit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.23 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
							return;
						}
					}
				}
			}

			if ( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.Cancel );
				UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.Cancel;

			// _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			if ( this._canClose ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			if( Revival() != 0 ) {
				return;
			}

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.OK;

			// _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// ���S�폜�m�F
			DialogResult result = TMsgDisp.Show( 
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
				"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
				"�f�[�^���폜���܂��B" + "\r\n" + 
				"��낵���ł����H", 				// �\�����郁�b�Z�[�W
				0, 									// �X�e�[�^�X�l
				MessageBoxButtons.OKCancel, 		// �\������{�^��
				MessageBoxDefaultButton.Button2 );	// �����\���{�^��

			if( result == DialogResult.OK ) {
				if( PhysicalDelete() != 0 ) {
					return;
				}
            }
            else
            {
				this.Delete_Button.Focus();
                return;
            }

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

            this.DialogResult = DialogResult.OK;

			// _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(AddressGuide_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �Z���K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void AddressGuide_Button_Click(object sender, System.EventArgs e)
		{
			AddressGuide addressGuide			= new AddressGuide();
			AddressGuideResult addrGuideResult	= null;
			DialogResult result = addressGuide.ShowAddressGuide( out addrGuideResult );

			if( ( result == DialogResult.OK ) && 
				( addrGuideResult.AddressName != "" ) ) {
// 2006.05.19 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// �Z���P
				this.SetAddress1( addrGuideResult.AddressName );
// 2006.05.19 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.05.19 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				this.Address1_tEdit.DataText	= addrGuideResult.AddressName;
// 2006.05.19 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				this.PostNo_tEdit.DataText		= addrGuideResult.PostNo;
///////////////////////////////////////////////////////////////////// 2005.10.18 AKIYAMA ADD STA //
				// ���_�I�����̓t�H�[�J�X�����ֈړ�
				this.SelectNextControl( ( Control )sender, true, true, true, true );
// 2005.10.18 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
			}
			else {
///////////////////////////////////////////////////////////////////// 2005.10.18 AKIYAMA ADD STA //
				( ( Control )sender ).Focus();
// 2005.10.18 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
			}
		}

		/// <summary>
		/// Control.Enter �C�x���g(PostNo_tEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����t�H�[�J�X�𓾂��Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNo_tEdit_Enter(object sender, System.EventArgs e)
		{
			this._changeFlg = false;
		}

		/// <summary>
		/// Control.KeyDown �C�x���g(PostNo_tEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[���ŃL�[�������ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNo_tEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
///////////////////////////////////////////////////////////////////// 2006.01.10 AKIYAMA DEL STA //
//			if( ( e.ToString() != "" ) && 
//				( e.KeyValue != 37 ) && 	// �u���v�L�[
//				( e.KeyValue != 39 ) ) {	// �u���v�L�[
//				this._changeFlg = true;
//			}					
// 2006.01.10 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		}

///////////////////////////////////////////////////////////////////// 2006.01.10 AKIYAMA ADD STA //
		/// <summary>
		/// TEdit.ValueChanged �C�x���g(PostNo_tEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNo_tEdit_ValueChanged(object sender, System.EventArgs e)
		{
			if( this.PostNo_tEdit.Modified == true ) {
				this._changeFlg = true;
			}
		}
// 2006.01.10 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Control.Leave �C�x���g(PostNo_tEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����t�H�[�J�X���������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNo_tEdit_Leave(object sender, System.EventArgs e)
		{
			if( this._changeFlg == true ) {
				PostNoChange();
			}
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tArrowKeyControlChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.23 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.23 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "CompanyNameCd_tNedit":    // 2009.03.23 �V�K���[�h���烂�[�h�ύX�Ή�
                    {
                        // ���Ж��̃R�[�h
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = CompanyNameCd_tNedit;
                            }
                        }
                        break;
                    }
                case "Address4_tEdit":
                    // �Z���S�Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Down)
                    {
                        // �d�b�ԍ��P�^�C�g���Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = CompanyTelTitle1_tEdit;
                    }
                    break;
                case "Cancel_Button":
                    // ����{�^���Ƀt�H�[�J�X������ꍇ
                    if (e.Key == Keys.Up)
                    {
                        // �摜�󎚗p�R�����g�Ƀt�H�[�J�X���ڂ��܂�
                        e.NextCtrl = ImageCommentForPrt2_tEdit;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            ImageInfoCode_tComboEditor.Items.Clear();
            GetImageInfoCode(IMAGEINFODIV_DATA);

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "SFUKN09020U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.23 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // ���Ж��̃R�[�h
            int compCd = CompanyNameCd_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[COMPANYNM_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsCompCd = (int)this.Bind_DataSet.Tables[COMPANYNM_TABLE].Rows[i][COMPANYNAMECD_TITLE];
                if (compCd == dsCompCd)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[COMPANYNM_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "SFUKN09020U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̎��Ж��̐ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���Ж��̃R�[�h�̃N���A
                        CompanyNameCd_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        "SFUKN09020U",                          // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̎��Ж��̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���Ж��̃R�[�h�̃N���A
                                CompanyNameCd_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.23 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        
        # region 2007.05.17  S.Koga  DEL
//        /// <summary>
//        /// Control.Click �C�x���g(TakeInImage_GuideButton)
//        /// </summary>
//        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
//        /// <param name="e">�C�x���g�p�����[�^</param>
//        /// <remarks>
//        /// <br>Note       : �捞�摜�I���K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
//        /// <br>Programmer : 23001 �H�R�@����</br>
//        /// <br>Date       : 2005.10.04</br>
//        /// </remarks>
//        private void TakeInImage_GuideButton_Click(object sender, System.EventArgs e)
//        {
//            // �J���ĕ\��
//            this.TakeInImage_OpenFileDialog.FileName = this.Image_tEdit.DataText;
//            DialogResult result = this.TakeInImage_OpenFileDialog.ShowDialog();
//            if( result == DialogResult.OK ) {
//                this.Image_tEdit.DataText = this.TakeInImage_OpenFileDialog.FileName;
//                this.TakeInImage_UltraPictureBox.Image = Image.FromFile( this.TakeInImage_OpenFileDialog.FileName );
//                this._changeTakeInImage = true;
/////////////////////////////////////////////////////////////////////// 2005.10.24 AKIYAMA ADD STA //
//                // ���_�I�����̓t�H�[�J�X�����ֈړ�
//                this.SelectNextControl( ( Control )sender, true, true, true, true );
//// 2005.10.24 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
//            }
/////////////////////////////////////////////////////////////////////// 2005.10.24 AKIYAMA ADD STA //
//            else {
//                ( ( Control )sender ).Focus();
//            }
//// 2005.10.24 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
        //        }

        ///// <summary>
        ///// Control.Click �C�x���g(TakeInImageDelete_Button)
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : �捞�摜�폜�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        ///// <br>Programmer : 23001 �H�R�@����</br>
        ///// <br>Date       : 2005.10.04</br>
        ///// </remarks>
        //private void TakeInImageDelete_Button_Click(object sender, System.EventArgs e)
        //{
        //    this.TakeInImage_UltraPictureBox.Image = null;
        //    this.Image_tEdit.Clear();
        //}
        # endregion

// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//		/// <summary>
//		/// Timer.Tick �C�x���g(Wait_Timer)
//		/// </summary>
//		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
//		/// <param name="e">�C�x���g�p�����[�^</param>
//		/// <remarks>
//		/// <br>Note        : �摜�]�������Ď��^�C�}�[</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.09.12</br>
//		/// </remarks>
//		private void Wait_Timer_Tick(object sender, System.EventArgs e)
//		{
//			lock( this._syncObject ) {
//				// ���ɉ摜�]����������\��
//				if( this._waitWindow == null ) {
//					this.Wait_Timer.Enabled = false;
//					return;
//				}
//				if( ( this._imageTransferring == false ) && 
//					( this._waitWindow.Visible == true ) ) {
//					this._waitWindow.CloseDialog( 0 );
//					this._waitWindow = null;
//					this.Wait_Timer.Enabled = false;
//				}
//			}
//		}
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

		#endregion

		#region �摜�Ǘ��}�X�^�֘A

        # region 2007.05.17  S.Koga  DEL
        ///// <summary>
        ///// �摜�Ǎ�����
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �摜�Ǘ��}�X�^����摜�̓ǂݍ��݂��s���܂�</br>
        ///// <br>Programmer : 23001 �H�R�@����</br>
        ///// <br>Date       : 2005.10.04</br>
        ///// </remarks>
        //private int ReadImageData( string enterpriseCode, Guid takeInImageGroupCd )
        //{
        //    int status = 0;

        //    if( takeInImageGroupCd != Guid.Empty ) {

        //        Image      image      = null;
        //        ImgManage  imgManage  = null;
        //        ImageGroup imageGroup = null;

        //        status = this._SFUKN09020UB.ReadImage( out image, out imageGroup, out imgManage, this._enterpriseCode, takeInImageGroupCd );

        //        switch( status ) {
        //            case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                this._imageGroup = imageGroup;
        //                this._imgManage  = imgManage;

        //                // �T���l�[���\�����X�V����
        //                if( image != null ) {
        //                    this.TakeInImage_UltraPictureBox.Image = image;

        //                    if( ( this._imageGroup != null ) && ( this._companyNmClone != null ) ) {
        //                        this._companyNmClone.TakeInImageGroupCd = this._imageGroup.TakeInImageGroupCd;
        //                    }
        //                }
        //                break;
        //            }
        //            case ( int )ConstantManagement.DB_Status.ctDB_EOF:
        //            case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            {
        //                break;
        //            }
        //            default:
        //            {
        //                // �T�[�`
        //                TMsgDisp.Show( 
        //                    this, 										// �e�E�B���h�E�t�H�[��
        //                    emErrorLevel.ERR_LEVEL_STOP, 				// �G���[���x��
        //                    "SFUKN09020U", 								// �A�Z���u���h�c�܂��̓N���X�h�c
        //                    "���Ж��̐ݒ�", 							// �v���O��������
        //                    "ReadImageData", 							// ��������
        //                    TMsgDisp.OPE_GET, 							// �I�y���[�V����
        //                    "�摜�Ǘ��}�X�^�̎擾�Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
        //                    status, 									// �X�e�[�^�X�l
        //                    this._SFUKN09020UB, 						// �G���[�����������I�u�W�F�N�g
        //                    MessageBoxButtons.OK, 						// �\������{�^��
        //                    MessageBoxDefaultButton.Button1 );			// �����\���{�^��
        //                break;
        //            }
        //        }
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// �摜�ۑ�����
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �摜�Ǘ��}�X�^�։摜�̕ۑ����s���܂�</br>
        ///// <br>Programmer : 23001 �H�R�@����</br>
        ///// <br>Date       : 2005.10.04</br>
        ///// </remarks>
        //private int SaveImageData( string enterpriseCode, Guid takeInImageGroupCd )
        //{
        //    int status = 0;

        //    // �捞�C���[�W�擾
        //    Image takeInImage	= this.TakeInImage_UltraPictureBox.Image as Image;
        //    if( takeInImage == null ) {
        //        status = -1;
        //        return status;
        //    }

        //    status = this._SFUKN09020UB.SaveImage( this._enterpriseCode, takeInImageGroupCd, 
        //        takeInImage, ref this._imageGroup, ref this._imgManage );

        //    if( status != 0 ) {
        //        // �o�^���s
        //        TMsgDisp.Show( 
        //            this, 										// �e�E�B���h�E�t�H�[��
        //            emErrorLevel.ERR_LEVEL_STOP, 				// �G���[���x��
        //            "SFUKN09020U", 								// �A�Z���u���h�c�܂��̓N���X�h�c
        //            "���Ж��̐ݒ�", 							// �v���O��������
        //            "SaveImageData", 							// ��������
        //            TMsgDisp.OPE_UPDATE, 						// �I�y���[�V����
        //            "�摜�Ǘ��}�X�^�̓o�^�Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
        //            status, 									// �X�e�[�^�X�l
        //            this._SFUKN09020UB, 						// �G���[�����������I�u�W�F�N�g
        //            MessageBoxButtons.OK, 						// �\������{�^��
        //            MessageBoxDefaultButton.Button1 );			// �����\���{�^��
        //    }

        //    return status;
        //}
        # endregion

        // 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//		/// <summary>
//		/// �摜��M��������
//		/// </summary>
//		/// <param name="sender">�摜�Ǘ��}�X�^�z��(ImgManage[])</param>
//		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
//		/// <remarks>
//		/// <br>Note       : �摜�̎�M�����������^�C�~���O�ŁA�摜�Ǘ��}�X�^�N���X�z����󂯎��܂��B
//		///					 �擾�����摜�Ǘ��}�X�^�N���X�z��������ɁA�t���[����������ʂɕ\�����܂��B</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private void ImageImgAcs_FileReceived( object sender, EventArgs e )
//		{
//
//			// �A�b�v���[�h�����N���[�Y�i�摜�]�����t���OOFF�j
//			WaitWindowClose( 0 );
//
//			ImgManage[] imgManageArray = sender as ImgManage[];
//
//			if( ( imgManageArray == null ) || ( imgManageArray.Length == 0 ) ) {
//				return;
//			}
//
//			// �摜�Ǘ��}�X�^�����擾����i�P���R�[�h�̂݁j
//			this._imgManage = imgManageArray[ 0 ];
//
//			// �T���l�[���\�����X�V����
//			if( ( this._imgManage != null ) && ( this._imgManage.TakeInImage != null ) ) {
//				this.TakeInImage_UltraPictureBox.Image = this._imgManage.TakeInImage;
//				if( ( this._imageGroup != null ) && ( this._companyNmClone != null ) ) {
//					this._companyNmClone.TakeInImageGroupCd = this._imageGroup.TakeInImageGroupCd;
//				}
//			}
//		}
//
//		/// <summary>
//		/// �摜���M��������
//		/// </summary>
//		/// <param name="sender">�X�e�[�^�X(Int32)</param>
//		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
//		/// <remarks>
//		/// <br>Note       : �摜���M�������������_�ŁA�X�e�[�^�X���󂯎��܂��B</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private	void ImageImgAcs_FileSended(object sender, EventArgs e)
//		{
//			int status = -1;
//
//			// �A�b�v���[�h�����N���[�Y�i�摜�]�����t���OOFF�j
//			WaitWindowClose( 0 );
//			
//			if (sender is Int32)
//			{
//				status = Convert.ToInt32(sender);
//
//				switch( status ) {
//					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
//					{
//						break;
//					}
//					default:
//					{
//						TMsgDisp.Show( 
//							this, 								// �e�E�B���h�E�t�H�[��
//							emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
//							"SFUKN09020U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
//							"���Ж��̐ݒ�", 					// �v���O��������
//							"ImageImgAcs_FileSended", 			// ��������
//							TMsgDisp.OPE_SEND, 					// �I�y���[�V����
//							"���Љ摜�̑��M�Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
//							status, 							// �X�e�[�^�X�l
//							this._imageImgAcs, 					// �G���[�����������I�u�W�F�N�g
//							MessageBoxButtons.OK, 				// �\������{�^��
//							MessageBoxDefaultButton.Button1 );	// �����\���{�^��
//						return;
//					}
//				}
//			}
//		}
//
//		/// <summary>
//		/// �摜�Ǎ�����
//		/// </summary>
//		/// <param name="enterpriseCode">��ƃR�[�h</param>
//		/// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h</param>
//		/// <returns>STATUS</returns>
//		/// <remarks>
//		/// <br>Note       : �摜�Ǘ��}�X�^����摜�̓ǂݍ��݂��s���܂�</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private int ReadImageData( string enterpriseCode, Guid takeInImageGroupCd )
//		{
//			int status = 0;
//
//			if( takeInImageGroupCd != Guid.Empty ) {
//				// �摜�O���[�v�}�X�^���摜�Ǘ��}�X�^��������
//				ImageGroup[] imageGroupArray;
//				ImgManage[] imgManageArray;
//
//				// �]�������b�Z�[�W���̃C���X�^���X�𐶐��i�摜�]�����t���OON�j
//				WaitWindowCreate();
//
//				status = this._imageImgAcs.Search( out imageGroupArray, out imgManageArray, enterpriseCode, takeInImageGroupCd, SYSTEMDIV_CD, IMAGEUSESYSTEM_CODE, true );
//
//				switch( status ) {
//					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
//					{
//						// �_�E�����[�h���̃��b�Z�[�W��\��
//						WaitWindowShow( 0 );
//
//						if( ( imageGroupArray != null ) && ( imageGroupArray.Length > 0 ) ) {
//							this._imageGroup = imageGroupArray[ 0 ];
//						}
//
//						if( ( imgManageArray != null ) && ( imgManageArray.Length > 0 ) ) {
//							this._imgManage = imgManageArray[ 0 ];
//						}
//
//						break;
//					}
//					case ( int )ConstantManagement.DB_Status.ctDB_EOF:
//					case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//					{
//						// �A�b�v���[�h�����N���[�Y�i�摜�]�����t���OOFF�j
//						WaitWindowClose( 0 );
//						break;
//					}
//					default:
//					{
//						// �A�b�v���[�h�����N���[�Y�i�摜�]�����t���OOFF�j
//						WaitWindowClose( -1 );
//						// �T�[�`
//						TMsgDisp.Show( 
//							this, 										// �e�E�B���h�E�t�H�[��
//							emErrorLevel.ERR_LEVEL_STOP, 				// �G���[���x��
//							"SFUKN09020U", 								// �A�Z���u���h�c�܂��̓N���X�h�c
//							"���Ж��̐ݒ�", 							// �v���O��������
//							"ReadImageData", 							// ��������
//							TMsgDisp.OPE_GET, 							// �I�y���[�V����
//							"�摜�Ǘ��}�X�^�̎擾�Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
//							status, 									// �X�e�[�^�X�l
//							this._imageImgAcs, 							// �G���[�����������I�u�W�F�N�g
//							MessageBoxButtons.OK, 						// �\������{�^��
//							MessageBoxDefaultButton.Button1 );			// �����\���{�^��
//						return status;
//					}
//				}
//			}
//
//			return status;
//		}
//
//		/// <summary>
//		/// �摜�ۑ�����
//		/// </summary>
//		/// <param name="enterpriseCode">��ƃR�[�h</param>
//		/// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h</param>
//		/// <returns>STATUS</returns>
//		/// <remarks>
//		/// <br>Note       : �摜�Ǘ��}�X�^�։摜�̕ۑ����s���܂�</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private int SaveImageData( string enterpriseCode, Guid takeInImageGroupCd )
//		{
//			int status = 0;
//
//			// �捞�C���[�W�擾
//			Image takeInImage	= this.TakeInImage_UltraPictureBox.Image as Image;
//			if( takeInImage == null ) {
//				status = -1;
//				return status;
//			}
//			// �T���l�[��
////			Image thmnailImage	= takeInImage.GetThumbnailImage( 
////				Convert.ToInt32( takeInImage.Width / 10 ), 
////				Convert.ToInt32( takeInImage.Height / 10 ), 
////				new Image.GetThumbnailImageAbort( this.GetThumbnailAbort ), 
////				IntPtr.Zero );
//
//			byte[] takeInImageBinaryData	= ImageImgAcs.ImageToBinary( takeInImage, System.Drawing.Imaging.ImageFormat.Png );
////			byte[] thmnailImageBinaryData	= ImageImgAcs.ImageToBinary( thmnailImage, System.Drawing.Imaging.ImageFormat.Png );
//
//			// �摜�Ǘ��}�X�^���[�N�N���X����
/////////////////////////////////////////////////////////////////////// 2005.11.04 AKIYAMA ADD STA //
//			// �i�Ǐ�Q�Ή� (�Ǘ�No.000273-02)
//			if( this._imgManage != null ) {
//				this._imageImgAcs.DeleteImage( this._imgManage, enterpriseCode );
//			}
//			this._imgManage = new ImgManage();
//			this._imgManage.EnterpriseCode			= enterpriseCode;
//			this._imgManage.TakeInImageCode = Guid.NewGuid();
//// 2005.11.04 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////// 2005.11.04 AKIYAMA DEL STA //
////			if( this._imgManage == null ) {
////				this._imgManage = new ImgManage();
////			}
////			this._imgManage.EnterpriseCode			= enterpriseCode;
////			if( this._imgManage.TakeInImageCode == Guid.Empty ) {
////				this._imgManage.TakeInImageCode = Guid.NewGuid();
////			}
//// 2005.11.04 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
//			this._imgManage.TakeInImageDispName		= "���Ж��̐ݒ�_���Љ摜";
//			this._imgManage.TakeInImageFileType		= ImageImgAcs.ImageFormatToString( System.Drawing.Imaging.ImageFormat.Png );
//			this._imgManage.TakeInImageColorCnt		= ImageImgAcs.PixelFormatToInt32( takeInImage.PixelFormat );
//			this._imgManage.TakeInImageWidth		= takeInImage.Width;
//			this._imgManage.TakeInImageHeight		= takeInImage.Height;
//			this._imgManage.TakeInImageFileSize		= takeInImageBinaryData.Length;
//			this._imgManage.TakeInImageFileUrl		= 
//				this._imgManage.TakeInImageCode.ToString() + "." + this._imgManage.TakeInImageFileType;
//			this._imgManage.TakeInImageDispOrder	= 1;
//			this._imgManage.TakeInImage				= takeInImage;
//			this._imgManage.TakeInImageDateTime		= TDateTime.GetSFDateNow();
//
//			this._imgManage.ThmnailImageFileType	= "";
//			this._imgManage.ThmnailImageColorCnt	= 0;
//			this._imgManage.ThmnailImageWidth		= 0;
//			this._imgManage.ThmnailImageHeight		= 0;
//			this._imgManage.ThmnailImageFileSize	= 0;
//			this._imgManage.ThmnailImage			= null;
//			this._imgManage.ThmnailImageFileUrl		= "";
//			this._imgManage.FreeMemoCmpDtSavePlc	= "";
//			this._imgManage.FreeMemoData			= null;
//
//			// �摜�O���[�v�N���X����
//			if( this._imageGroup == null ) {
//				this._imageGroup = new ImageGroup();
//			}
//			this._imageGroup.EnterpriseCode		= enterpriseCode;
//			this._imageGroup.TakeInImageGroupCd	= takeInImageGroupCd;
//			this._imageGroup.TakeInImageCode	= this._imgManage.TakeInImageCode;
//			this._imageGroup.SystemDivCd		= SYSTEMDIV_CD;
//			this._imageGroup.ImageUseSystemCode	= IMAGEUSESYSTEM_CODE;
//
//			// �A�N�Z�X�N���X�p�����[�^�ݒ�
//			ImageGroup[] imageGroupArray = new ImageGroup[ 1 ];
//			imageGroupArray[ 0 ] = this._imageGroup;
//
//			ImgManage[] imgManageArray = new ImgManage[ 1 ];
//			imgManageArray[ 0 ] = this._imgManage;
//
//			// �]�������b�Z�[�W���̃C���X�^���X�𐶐��i�摜�]�����t���OON�j
//			WaitWindowCreate();
//
//			// �摜�O���[�v�}�X�^���摜�Ǘ��}�X�^�o�^����
//			status = this._imageImgAcs.Write( ref imageGroupArray, ref imgManageArray, enterpriseCode, true );
//
//			if( status == 0 ) {
//				// �A�b�v���[�h�����b�Z�[�W�\��
//				WaitWindowShow( 1 );
//			}
//			else {
//				// �A�b�v���[�h�����N���[�Y�i�摜�]�����t���OOFF�j
//				WaitWindowClose( -1 );
//
//				// �o�^���s
//				TMsgDisp.Show( 
//					this, 										// �e�E�B���h�E�t�H�[��
//					emErrorLevel.ERR_LEVEL_STOP, 				// �G���[���x��
//					"SFUKN09020U", 								// �A�Z���u���h�c�܂��̓N���X�h�c
//					"���Ж��̐ݒ�", 							// �v���O��������
//					"SaveImageData", 							// ��������
//					TMsgDisp.OPE_UPDATE, 						// �I�y���[�V����
//					"�摜�Ǘ��}�X�^�̓o�^�Ɏ��s���܂����B", 	// �\�����郁�b�Z�[�W
//					status, 									// �X�e�[�^�X�l
//					this._imageImgAcs, 							// �G���[�����������I�u�W�F�N�g
//					MessageBoxButtons.OK, 						// �\������{�^��
//					MessageBoxDefaultButton.Button1 );			// �����\���{�^��
//			}
//
//			return status;
//		}
//
//		/// <summary>
//		/// �T���l�C���摜�쐬���f����
//		/// </summary>
//		/// <returns>false</returns>
//		/// <remarks>
//		/// <br>Note       : �T���l�C���摜�쐬���Ɏ��s�����ꍇ�̏����ł��B</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private bool GetThumbnailAbort()
//		{
//			return false;
//		}
//
//		/// <summary>
//		/// �摜�]�������C���X�^���X�����i�摜�]�����t���OON�j
//		/// </summary>
//		/// <remarks>
//		/// <br>Note       : ���Љ摜�]�������̃C���X�^���X�𐶐����܂��B</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.11.14</br>
//		/// </remarks>
//		private void WaitWindowCreate()
//		{
//			lock( this._syncObject ) {
//				// �摜�]�����t���O��ON
//				this._imageTransferring = true;
//				//���������ꍇ
//				if( ( this._waitWindow == null ) || 
//					( this._waitWindow.IsDisposed ) ) {
//					this._waitWindow = new SFUKN09020UB();
//				}
//				this._waitWindow.Icon = this.Icon;
//				// �Ď��^�C�}�[��ON��
//				this.Wait_Timer.Enabled = true;
//			}
//		}
//
//		/// <summary>
//		/// �摜�]�������\���֐�
//		/// </summary>
//		/// <remarks>
//		/// <br>Note       : ���҂�������������\�����܂��B</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.11.11</br>
//		/// </remarks>
//		private void WaitWindowShow( int transferMode )
//		{
//			lock( this._syncObject ) {
//				// ���ɓ]�������̂Ƃ�
//				if( this._waitWindow == null ) {
//					return;
//				}
//			}
//			this._waitWindow.ShowDialog( transferMode );
////			this._waitWindow.Refresh();
//		}
//		
//		/// <summary>
//		/// �摜�]����������֐��i�摜�]�����t���OOFF�j
//		/// </summary>
//		/// <remarks>
//		/// <br>Note       : ���҂���������������܂��B</br>
//		/// <br>Programmer : 23001 �H�R�@����</br>
//		/// <br>Date       : 2005.11.11</br>
//		/// </remarks>
//		private void WaitWindowClose( int status )
//		{
//			// ���b�N
//			lock( this._syncObject ) {
//				this._imageTransferring = false;
//				if( this._waitWindow != null )
//				{
//					this._waitWindow.CloseDialog( status );
//					this._waitWindow = null;
//					this.Wait_Timer.Enabled = false;
//				}
//			}
//		}
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

		#endregion
	}
}
