//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���ϑS�̐ݒ�}�X�^
// �v���O�����T�v   �F���ϑS�̐ݒ�̓o�^�E�ύX�E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30415 �ēc �ύK
// �C����    2008/06/04     �C�����e�F�f�[�^���ڂ̒ǉ�/�폜�ɂ��C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30452 ��� �r��
// �C����    2008/09/16     �C�����e�F�ۑ����̋��_�R�[�h�`�F�b�N�ǉ�
//                                    ���_�K�C�h�����͎��̃��^�[���L�[�ړ�����ǉ�
//                                    �S�Ёi���_�R�[�h"00"�j�̘_���폜��s�ɏC��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H�� �b�D
// �C����    2008/09/26     �C�����e�F�s��Ή�[5659]
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30462 �s�V �m��
// �C����    2008/10/09     �C�����e�F�o�O�C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/07     �C�����e�FMantis�y12585�z�ŐV���擾�ƍX�V�`�F�b�N�̔�����C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���F����R
// �C����    2011/09/07     �C�����e�F��Q�� #24169�@���_�ݒ���s�����Ƌ��_�K�C�h������ƑS�Ћ��ʂ̕ҏW���s�����Ƃ��Ă��܂��B
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ ���_�R�[�h�Ƌ��_�K�C�h�̃t�H�[�J�X�ړ��̓��b�Z�[�W�\�����s��Ȃ��悤�ɏC��
// ---------------------------------------------------------------------//


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/26 �s��Ή�[5659]
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/26 �s��Ή�[5659]
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���Ϗ����l�ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ϗ����l�̐ݒ���s���N���X�ł��B</br>
	/// <br>Programmer : 980035 ����@��`</br>
	/// <br>Date       : 2007.09.27</br>
    /// <br>UpdateNote : 2008.03.14 980035 ���� ��`</br>
    /// <br>             �E�t�@�C�����C�A�E�g�ύX�Ή�</br>
    /// <br>UpdateNote : 2008/06/04 30415 �ēc �ύK</br>
    /// <br>        	 �E�f�[�^���ڂ̒ǉ�/�폜�ɂ��C��</br>
    /// <br>UpdateNote : 2008/09/16 30452 ��� �r��</br>
    /// <br>             �E�ۑ����̋��_�R�[�h�`�F�b�N�ǉ�</br>
    /// <br>             �E���_�K�C�h�����͎��̃��^�[���L�[�ړ�����ǉ�</br>
    /// <br>             �E�S�Ёi���_�R�[�h"00"�j�̘_���폜��s�ɏC��</br>
    /// <br>UpdateNote   : 2008/10/09 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote : 2011/09/07 ����R</br>
    /// <br>        	 �E��Q�� #24169</br>
    /// </remarks>
	public class DCMIT09010UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
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
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ListPricePrintDiv_Title_Label;
        private Infragistics.Win.Misc.UltraLabel EstimateTitle1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Broadleaf.Library.Windows.Forms.TEdit EstimateTitle1_tEdit;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.OpenFileDialog TakeInImage_OpenFileDialog;
		private Broadleaf.Library.Windows.Forms.TEdit EstimateNote1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit EstimateNote2_tEdit;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TComboEditor EstmFormNoPickDiv_tComboEditor;
        private TComboEditor EstimatePrtDiv_tComboEditor;
        private TComboEditor ListPricePrintDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel EstmFormNoPickDiv_Title_Label;
        private Infragistics.Win.Misc.UltraLabel EstimatePrtDiv_Title_Label;
        private TEdit EstimateNote3_tEdit;
        private Infragistics.Win.Misc.UltraLabel EstimateNote1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel EstimateNote2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel EstimateNote3_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TComboEditor ConsTaxPrintDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ConsTaxPrintDiv_Title_Label;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager2;
        private Infragistics.Win.Misc.UltraButton SectionGd_ultraButton;
        private TEdit tEdit_SectionCodeAllowZero2;
        private TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel SectionNm_Label;
        private Infragistics.Win.Misc.UltraLabel EstimateValidityTerm_Title_Label2;
        private Infragistics.Win.Misc.UltraLabel EstimateValidityTerm_Title_Label1;
        private TEdit EstimateValidityTerm_tEdit;
        private TComboEditor EstimateDtCreateDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel EstimateDtCreateDiv_Title_Label;
        private Infragistics.Win.Misc.UltraLabel PartsSelectDivCd_Title_Label;
        private Infragistics.Win.Misc.UltraLabel PartsSearchDivCd_Title_Label;
        private TComboEditor PartsSearchDivCd_tComboEditor;
        private TComboEditor PartsSelectDivCd_tComboEditor;
        private TComboEditor RateUseCode_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel RateUseCode_Title_Label;
        private TComboEditor PartsNoPrtCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel PartsNoPrtCd_Title_Label;
        private TComboEditor OptionPringDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel OptionPringDivCd_Title_Label;
        private TComboEditor FaxEstimatetDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel FaxEstimatetDiv_Title_Label;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructor
		/// <summary>
        /// ���Ϗ����l�ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public DCMIT09010UA()
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

			// ��ƃR�[�h�擾
			this._enterpriseCode					= LoginInfoAcquisition.EnterpriseCode;	// ��ƃR�[�h

			// ������
			this._dataIndex							= -1;
            this._estimateDefSetAcs                 = new EstimateDefSetAcs();
            this._secInfoAcs                        = new SecInfoAcs(1);
            this._logicalDeleteMode = 0;
			this._estimateDefSetTable				= new Hashtable();

			// _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf							= -2;

            // ADD 2008/09/26 �s��Ή�[5659] ---------->>>>>
            // ���_�K�C�h�̃t�H�[�J�X����
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.EstimatePrtDiv_tComboEditor
            );
            // ADD 2008/09/26 �s��Ή�[5659] ----------<<<<<
		}
		#endregion

		#region Private Members
        private EstimateDefSetAcs _estimateDefSetAcs;				// ���Ϗ����l�ݒ�A�N�Z�X�N���X
        private SecInfoAcs        _secInfoAcs;                      // ���_�}�X�^�A�N�Z�X�N���X
        private string            _enterpriseCode;					// ��ƃR�[�h
		private int				  _logicalDeleteMode;				// ���[�h
        private Hashtable         _estimateDefSetTable;				// ���Ϗ����l�ݒ�e�[�u��

		// ��r�pclone
        private EstimateDefSet  _estimateDefSetClone;

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

        private bool isError = false; // ADD 2011/09/07
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

		// Frame��View�pGrid���KEY���i�w�b�_�̃^�C�g�����ƂȂ�܂��B�j
        private const string DELETE_DATE                    = "�폜��";
        private const string SECTIONCODE_TITLE              = "���_�R�[�h"; // MOD 2008/10/01 �s��Ή�[5967] "�R�[�h"��"���_�R�[�h"
        private const string SECTIONNAME_TITLE              = "���_��";     // MOD 2008/10/01 �s��Ή�[5967] "���_����"��"���_��"
        // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //private const string FRACTIONPROCCD_TITLE           = "�[�������敪";
        //private const string CONSTAXLAYMETHOD_TITLE         = "����œ]�ŕ���";
        // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
        private const string CONSTAXPRINTDIV_TITLE          = "����ň���敪";
        // DEL 2008/10/09 �s��Ή�[6455] ��
        //private const string LISTPRICEPRINTDIV_TITLE        = "�艿����敪";
        private const string LISTPRICEPRINTDIV_TITLE        = "���i����敪";  // ADD 2008/10/09 �s��Ή�[6455]
        // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //private const string ERANAMEDISPCD1_TITLE           = "�����\���敪";
        //private const string ESTIMATEFORMTOTALPRTCD_TITLE   = "���ύ��v����敪";
        //private const string ESTIMATEFORMPRTCD_TITLE        = "���Ϗ�����敪";
        //private const string HONORIFICTITLEPRTCD_TITLE      = "�h�̈���敪";
        //private const string ESTIMATEREQUESTCD_TITLE        = "���ψ˗��敪";
        // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
        private const string ESTMFORMNOPICKDIV_TITLE        = "���Ϗ��ԍ��̔ԋ敪";
        private const string ESTIMATEPRTDIV_TITLE           = "���Ϗ����s�敪";
        // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
        //private const string ESTIMATEREQPRTDIV_TITLE        = "���ψ˗������s�敪";
        //private const string ESTIMATECONFPRTDIV_TITLE       = "���ϊm�F�����s�敪";
        // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<

        private const string ESTIMATETITLE1_TITLE       = "���σ^�C�g���P";
       private const string ESTIMATENOTE1_TITLE        = "���ϔ��l�P";
        private const string ESTIMATENOTE2_TITLE        = "���ϔ��l�Q";
        private const string ESTIMATENOTE3_TITLE        = "���ϔ��l�R";

        // --- ADD 2008/06/04 -------------------------------->>>>>
        private const string FAXESTIMATETDIV_TITLE      = "�e�`�w���ϋ敪";
        private const string PARTSNOPRTCD_TITLE         = "�i�Ԉ󎚋敪";
        private const string OPTIONPRINGDIVCD_TITLE     = "�I�v�V�����󎚋敪";
        private const string PARTSSELECTDIVCD_TITLE     = "���i�I���敪";
        private const string PARTSSEARCHDIVCD_TITLE     = "���i�����敪";
        private const string ESTIMATEDTCREATEDIV_TITLE  = "���σf�[�^�쐬�敪";
        private const string ESTIMATEVALIDITYTERM_TITLE = "���Ϗ��L������";
        private const string RATEUSECODE_TITLE          = "�|���g�p�敪";
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        private const string GUID_TITLE                 = "GUID";
        private const string ESTIMATEDEFSET_TABLE       = "ESTIMATEDEFSET"; // �e�[�u����
		
		// �ҏW���[�h
		private const string INSERT_MODE				= "�V�K���[�h";
		private const string UPDATE_MODE				= "�X�V���[�h";
		private const string DELETE_MODE				= "�폜���[�h";

        // �[�������敪
        private const string FRACPROC_CUT               = "�؎�";
        private const string FRACPROC_ROUND             = "�l�̌ܓ�";
        private const string FRACPROC_RAISE             = "�؏�";

        // ����œ]�ŕ���
        private const string CONSTAXLAY_SLIP            = "�`�[�P��";
        private const string CONSTAXLAY_DETAILS         = "���גP��";
        private const string CONSTAXLAY_CLAIMPARENT     = "�����e";
        private const string CONSTAXLAY_CLAIMCHILD      = "�����q";

        // �����\���敪
        private const string ERANAME_AD                 = "����";
        private const string ERANAME_JAPAN              = "�a��";

        // ���ʋ敪
        private const string DIVISION_YES               = "����";
        private const string DIVISION_NO                = "���Ȃ�";

        // ���Ϗ��ԍ��̔ԋ敪
        private const string DIVISION_ON                = "�L��";
        private const string DIVISION_OFF               = "����";

        // ���ύ��v����敪
        private const string ESTIMATETOTALPRTCD_MODEL   = "�ӂ̂�";
        private const string ESTIMATETOTALPRTCD_END     = "���ז���";
        private const string ESTIMATETOTALPRTCD_TOTAL   = "���v��";
        private const string ESTIMATETOTALPRTCD_NON     = "������Ȃ�";

        // ���Ϗ�����E���ψ˗�
        private const string ESTIMATEFORMPRTCD_NORMAL   = "�ʏ�";
        private const string ESTIMATEFORMPRTCD_PAGEOVER = "�P�łɓ���Ȃ��ꍇ���וʎ�";
        private const string ESTIMATEFORMPRTCD_ANOTHER  = "���וʎ�";

        // --- ADD 2008/06/04 -------------------------------->>>>>
        // ���i�����敪
        private const string PARTSSEARCHDIVCD_PARTS     = "���i����";
        private const string PARTSSEARCHDIVCD_NO        = "�i�Ԍ���";
        // �|���g�p�敪
        // DEL 2008/10/09 �s��Ή�[6455] ��
        //private const string RATEUSECODE_DEFAULT        = "����=�艿";
        private const string RATEUSECODE_DEFAULT        = "����=���i";  // ADD 2008/10/09 �s��Ή�[6455]
        private const string RATEUSECODE_RATESELECT     = "�|���w��";
        private const string RATEUSECODE_RATESET        = "�|���ݒ�";
        // --- ADD 2008/06/04 --------------------------------<<<<< 

        // ���ݒ莞�Ɏg�p
        private const string UNREGISTER = "";

        // ADD 2008/09/26 �s��Ή�[5659] ---------->>>>>
        /// <summary>���_�K�C�h�̐���I�u�W�F�N�g</summary>
        private readonly GeneralGuideUIController _sectionGuideController;
        /// <summary>
        /// ���_�K�C�h�̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���_�K�C�h�̐���I�u�W�F�N�g</value>
        private GeneralGuideUIController SectionGuideController
        {
            get { return _sectionGuideController; }
        }
        // ADD 2008/09/26 �s��Ή�[5659] ----------<<<<<

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
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCMIT09010UA));
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ListPricePrintDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateTitle1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateTitle1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.TakeInImage_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.EstimateNote1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EstimateNote2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ListPricePrintDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstimatePrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstmFormNoPickDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstmFormNoPickDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimatePrtDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateNote3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EstimateNote1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateNote2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateNote3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxPrintDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxPrintDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraToolTipManager2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateValidityTerm_Title_Label1 = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateValidityTerm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.EstimateValidityTerm_Title_Label2 = new Infragistics.Win.Misc.UltraLabel();
            this.EstimateDtCreateDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstimateDtCreateDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsSelectDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsSearchDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsSearchDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PartsSelectDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RateUseCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RateUseCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PartsNoPrtCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PartsNoPrtCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OptionPringDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.OptionPringDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FaxEstimatetDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.FaxEstimatetDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateTitle1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPricePrintDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatePrtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstmFormNoPickDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxPrintDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateValidityTerm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateDtCreateDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsSearchDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsSelectDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateUseCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsNoPrtCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPringDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxEstimatetDiv_tComboEditor)).BeginInit();
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
            this.Mode_Label.Location = new System.Drawing.Point(576, 4);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 33;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(176, 442);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 19;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(301, 442);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 20;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(426, 442);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 21;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(551, 442);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 22;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 484);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(684, 23);
            this.ultraStatusBar1.TabIndex = 59;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // SectionCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance2;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(20, 8);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.SectionCode_Title_Label.TabIndex = 23;
            this.SectionCode_Title_Label.Text = "���_";
            // 
            // ListPricePrintDiv_Title_Label
            // 
            appearance86.TextVAlignAsString = "Middle";
            this.ListPricePrintDiv_Title_Label.Appearance = appearance86;
            this.ListPricePrintDiv_Title_Label.Location = new System.Drawing.Point(330, 76);
            this.ListPricePrintDiv_Title_Label.Name = "ListPricePrintDiv_Title_Label";
            this.ListPricePrintDiv_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.ListPricePrintDiv_Title_Label.TabIndex = 25;
            this.ListPricePrintDiv_Title_Label.Text = "���i����敪";
            // 
            // EstimateTitle1_Title_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.EstimateTitle1_Title_Label.Appearance = appearance7;
            this.EstimateTitle1_Title_Label.Location = new System.Drawing.Point(20, 198);
            this.EstimateTitle1_Title_Label.Name = "EstimateTitle1_Title_Label";
            this.EstimateTitle1_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.EstimateTitle1_Title_Label.TabIndex = 32;
            this.EstimateTitle1_Title_Label.Text = "���σ^�C�g���P";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(10, 38);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel17.TabIndex = 42;
            // 
            // EstimateTitle1_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.EstimateTitle1_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.EstimateTitle1_tEdit.Appearance = appearance19;
            this.EstimateTitle1_tEdit.AutoSelect = true;
            this.EstimateTitle1_tEdit.DataText = "";
            this.EstimateTitle1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateTitle1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EstimateTitle1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.EstimateTitle1_tEdit.Location = new System.Drawing.Point(171, 198);
            this.EstimateTitle1_tEdit.MaxLength = 16;
            this.EstimateTitle1_tEdit.Name = "EstimateTitle1_tEdit";
            this.EstimateTitle1_tEdit.Size = new System.Drawing.Size(453, 24);
            this.EstimateTitle1_tEdit.TabIndex = 11;
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
            // 
            // TakeInImage_OpenFileDialog
            // 
            this.TakeInImage_OpenFileDialog.Filter = "�摜�t�@�C��(*.bmp;*.jpg;*.jpeg)|*.bmp;*.jpg;*.jpeg";
            this.TakeInImage_OpenFileDialog.RestoreDirectory = true;
            this.TakeInImage_OpenFileDialog.Title = "���Љ摜�I��";
            // 
            // EstimateNote1_tEdit
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.TextVAlignAsString = "Middle";
            this.EstimateNote1_tEdit.ActiveAppearance = appearance60;
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextVAlignAsString = "Middle";
            this.EstimateNote1_tEdit.Appearance = appearance61;
            this.EstimateNote1_tEdit.AutoSelect = true;
            this.EstimateNote1_tEdit.DataText = "";
            this.EstimateNote1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateNote1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EstimateNote1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.EstimateNote1_tEdit.Location = new System.Drawing.Point(171, 235);
            this.EstimateNote1_tEdit.MaxLength = 24;
            this.EstimateNote1_tEdit.Name = "EstimateNote1_tEdit";
            this.EstimateNote1_tEdit.Size = new System.Drawing.Size(453, 24);
            this.EstimateNote1_tEdit.TabIndex = 12;
            // 
            // EstimateNote2_tEdit
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.EstimateNote2_tEdit.ActiveAppearance = appearance58;
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColor = System.Drawing.Color.Black;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextVAlignAsString = "Middle";
            this.EstimateNote2_tEdit.Appearance = appearance59;
            this.EstimateNote2_tEdit.AutoSelect = true;
            this.EstimateNote2_tEdit.DataText = "";
            this.EstimateNote2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateNote2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EstimateNote2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.EstimateNote2_tEdit.Location = new System.Drawing.Point(171, 264);
            this.EstimateNote2_tEdit.MaxLength = 24;
            this.EstimateNote2_tEdit.Name = "EstimateNote2_tEdit";
            this.EstimateNote2_tEdit.Size = new System.Drawing.Size(453, 24);
            this.EstimateNote2_tEdit.TabIndex = 13;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // ListPricePrintDiv_tComboEditor
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ListPricePrintDiv_tComboEditor.ActiveAppearance = appearance91;
            appearance92.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            this.ListPricePrintDiv_tComboEditor.Appearance = appearance92;
            this.ListPricePrintDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ListPricePrintDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ListPricePrintDiv_tComboEditor.ItemAppearance = appearance93;
            this.ListPricePrintDiv_tComboEditor.Location = new System.Drawing.Point(481, 76);
            this.ListPricePrintDiv_tComboEditor.MaxDropDownItems = 18;
            this.ListPricePrintDiv_tComboEditor.Name = "ListPricePrintDiv_tComboEditor";
            this.ListPricePrintDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.ListPricePrintDiv_tComboEditor.TabIndex = 6;
            // 
            // EstimatePrtDiv_tComboEditor
            // 
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimatePrtDiv_tComboEditor.ActiveAppearance = appearance80;
            appearance81.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance81.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstimatePrtDiv_tComboEditor.Appearance = appearance81;
            this.EstimatePrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstimatePrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimatePrtDiv_tComboEditor.ItemAppearance = appearance82;
            this.EstimatePrtDiv_tComboEditor.Location = new System.Drawing.Point(171, 45);
            this.EstimatePrtDiv_tComboEditor.MaxDropDownItems = 18;
            this.EstimatePrtDiv_tComboEditor.Name = "EstimatePrtDiv_tComboEditor";
            this.EstimatePrtDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.EstimatePrtDiv_tComboEditor.TabIndex = 3;
            // 
            // EstmFormNoPickDiv_tComboEditor
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstmFormNoPickDiv_tComboEditor.ActiveAppearance = appearance75;
            appearance76.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstmFormNoPickDiv_tComboEditor.Appearance = appearance76;
            this.EstmFormNoPickDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstmFormNoPickDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstmFormNoPickDiv_tComboEditor.ItemAppearance = appearance77;
            this.EstmFormNoPickDiv_tComboEditor.Location = new System.Drawing.Point(171, 75);
            this.EstmFormNoPickDiv_tComboEditor.MaxDropDownItems = 18;
            this.EstmFormNoPickDiv_tComboEditor.Name = "EstmFormNoPickDiv_tComboEditor";
            this.EstmFormNoPickDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.EstmFormNoPickDiv_tComboEditor.TabIndex = 5;
            // 
            // EstmFormNoPickDiv_Title_Label
            // 
            appearance74.TextVAlignAsString = "Middle";
            this.EstmFormNoPickDiv_Title_Label.Appearance = appearance74;
            this.EstmFormNoPickDiv_Title_Label.Location = new System.Drawing.Point(20, 77);
            this.EstmFormNoPickDiv_Title_Label.Name = "EstmFormNoPickDiv_Title_Label";
            this.EstmFormNoPickDiv_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.EstmFormNoPickDiv_Title_Label.TabIndex = 27;
            this.EstmFormNoPickDiv_Title_Label.Text = "���Ϗ��ԍ��̔ԋ敪";
            // 
            // EstimatePrtDiv_Title_Label
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.EstimatePrtDiv_Title_Label.Appearance = appearance73;
            this.EstimatePrtDiv_Title_Label.Location = new System.Drawing.Point(20, 46);
            this.EstimatePrtDiv_Title_Label.Name = "EstimatePrtDiv_Title_Label";
            this.EstimatePrtDiv_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.EstimatePrtDiv_Title_Label.TabIndex = 26;
            this.EstimatePrtDiv_Title_Label.Text = "���Ϗ����s�敪";
            // 
            // EstimateNote3_tEdit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextVAlignAsString = "Middle";
            this.EstimateNote3_tEdit.ActiveAppearance = appearance42;
            appearance43.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.EstimateNote3_tEdit.Appearance = appearance43;
            this.EstimateNote3_tEdit.AutoSelect = true;
            this.EstimateNote3_tEdit.DataText = "";
            this.EstimateNote3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateNote3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.EstimateNote3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.EstimateNote3_tEdit.Location = new System.Drawing.Point(171, 293);
            this.EstimateNote3_tEdit.MaxLength = 24;
            this.EstimateNote3_tEdit.Name = "EstimateNote3_tEdit";
            this.EstimateNote3_tEdit.Size = new System.Drawing.Size(453, 24);
            this.EstimateNote3_tEdit.TabIndex = 14;
            // 
            // EstimateNote1_Title_Label
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.EstimateNote1_Title_Label.Appearance = appearance35;
            this.EstimateNote1_Title_Label.Location = new System.Drawing.Point(20, 235);
            this.EstimateNote1_Title_Label.Name = "EstimateNote1_Title_Label";
            this.EstimateNote1_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.EstimateNote1_Title_Label.TabIndex = 37;
            this.EstimateNote1_Title_Label.Text = "���ϔ��l�P";
            // 
            // EstimateNote2_Title_Label
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.EstimateNote2_Title_Label.Appearance = appearance36;
            this.EstimateNote2_Title_Label.Location = new System.Drawing.Point(20, 264);
            this.EstimateNote2_Title_Label.Name = "EstimateNote2_Title_Label";
            this.EstimateNote2_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.EstimateNote2_Title_Label.TabIndex = 38;
            this.EstimateNote2_Title_Label.Text = "���ϔ��l�Q";
            // 
            // EstimateNote3_Title_Label
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.EstimateNote3_Title_Label.Appearance = appearance37;
            this.EstimateNote3_Title_Label.Location = new System.Drawing.Point(20, 293);
            this.EstimateNote3_Title_Label.Name = "EstimateNote3_Title_Label";
            this.EstimateNote3_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.EstimateNote3_Title_Label.TabIndex = 39;
            this.EstimateNote3_Title_Label.Text = "���ϔ��l�R";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel1.Location = new System.Drawing.Point(10, 178);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel1.TabIndex = 44;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Location = new System.Drawing.Point(11, 335);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel2.TabIndex = 45;
            this.ultraLabel2.Click += new System.EventHandler(this.ultraLabel2_Click);
            // 
            // ConsTaxPrintDiv_Title_Label
            // 
            appearance90.TextVAlignAsString = "Middle";
            this.ConsTaxPrintDiv_Title_Label.Appearance = appearance90;
            this.ConsTaxPrintDiv_Title_Label.Location = new System.Drawing.Point(330, 46);
            this.ConsTaxPrintDiv_Title_Label.Name = "ConsTaxPrintDiv_Title_Label";
            this.ConsTaxPrintDiv_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.ConsTaxPrintDiv_Title_Label.TabIndex = 24;
            this.ConsTaxPrintDiv_Title_Label.Text = "����ň���敪";
            // 
            // ConsTaxPrintDiv_tComboEditor
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxPrintDiv_tComboEditor.ActiveAppearance = appearance87;
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColorDisabled = System.Drawing.Color.Black;
            this.ConsTaxPrintDiv_tComboEditor.Appearance = appearance88;
            this.ConsTaxPrintDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ConsTaxPrintDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ConsTaxPrintDiv_tComboEditor.ItemAppearance = appearance89;
            this.ConsTaxPrintDiv_tComboEditor.Location = new System.Drawing.Point(481, 46);
            this.ConsTaxPrintDiv_tComboEditor.MaxDropDownItems = 18;
            this.ConsTaxPrintDiv_tComboEditor.Name = "ConsTaxPrintDiv_tComboEditor";
            this.ConsTaxPrintDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.ConsTaxPrintDiv_tComboEditor.TabIndex = 4;
            // 
            // ultraToolTipManager2
            // 
            this.ultraToolTipManager2.ContainingControl = this;
            // 
            // SectionGd_ultraButton
            // 
            this.SectionGd_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGd_ultraButton.Location = new System.Drawing.Point(207, 7);
            this.SectionGd_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGd_ultraButton.Name = "SectionGd_ultraButton";
            this.SectionGd_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGd_ultraButton.TabIndex = 1;
            this.SectionGd_ultraButton.Click += new System.EventHandler(this.SectionGd_ultraButton_Click);
            // 
            // SectionNm_tEdit
            // 
            this.SectionNm_tEdit.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance65;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.SectionNm_tEdit.Location = new System.Drawing.Point(238, 7);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.ReadOnly = true;
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 2;
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance78;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance79;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(172, 7);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            // 
            // SectionNm_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SectionNm_Label.Appearance = appearance30;
            this.SectionNm_Label.Location = new System.Drawing.Point(359, 7);
            this.SectionNm_Label.Name = "SectionNm_Label";
            this.SectionNm_Label.Size = new System.Drawing.Size(210, 23);
            this.SectionNm_Label.TabIndex = 63;
            this.SectionNm_Label.Text = "���[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // EstimateValidityTerm_Title_Label1
            // 
            appearance66.TextVAlignAsString = "Middle";
            this.EstimateValidityTerm_Title_Label1.Appearance = appearance66;
            this.EstimateValidityTerm_Title_Label1.Location = new System.Drawing.Point(20, 137);
            this.EstimateValidityTerm_Title_Label1.Name = "EstimateValidityTerm_Title_Label1";
            this.EstimateValidityTerm_Title_Label1.Size = new System.Drawing.Size(145, 23);
            this.EstimateValidityTerm_Title_Label1.TabIndex = 65;
            this.EstimateValidityTerm_Title_Label1.Text = "���Ϗ��L������";
            // 
            // EstimateValidityTerm_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.EstimateValidityTerm_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.EstimateValidityTerm_tEdit.Appearance = appearance13;
            this.EstimateValidityTerm_tEdit.AutoSelect = true;
            this.EstimateValidityTerm_tEdit.DataText = "";
            this.EstimateValidityTerm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.EstimateValidityTerm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.EstimateValidityTerm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.EstimateValidityTerm_tEdit.Location = new System.Drawing.Point(171, 137);
            this.EstimateValidityTerm_tEdit.MaxLength = 2;
            this.EstimateValidityTerm_tEdit.Name = "EstimateValidityTerm_tEdit";
            this.EstimateValidityTerm_tEdit.Size = new System.Drawing.Size(28, 24);
            this.EstimateValidityTerm_tEdit.TabIndex = 9;
            // 
            // EstimateValidityTerm_Title_Label2
            // 
            appearance57.TextVAlignAsString = "Middle";
            this.EstimateValidityTerm_Title_Label2.Appearance = appearance57;
            this.EstimateValidityTerm_Title_Label2.Location = new System.Drawing.Point(200, 139);
            this.EstimateValidityTerm_Title_Label2.Name = "EstimateValidityTerm_Title_Label2";
            this.EstimateValidityTerm_Title_Label2.Size = new System.Drawing.Size(62, 23);
            this.EstimateValidityTerm_Title_Label2.TabIndex = 66;
            this.EstimateValidityTerm_Title_Label2.Text = "������";
            // 
            // EstimateDtCreateDiv_tComboEditor
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimateDtCreateDiv_tComboEditor.ActiveAppearance = appearance26;
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstimateDtCreateDiv_tComboEditor.Appearance = appearance27;
            this.EstimateDtCreateDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstimateDtCreateDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimateDtCreateDiv_tComboEditor.ItemAppearance = appearance28;
            this.EstimateDtCreateDiv_tComboEditor.Location = new System.Drawing.Point(481, 356);
            this.EstimateDtCreateDiv_tComboEditor.MaxDropDownItems = 18;
            this.EstimateDtCreateDiv_tComboEditor.Name = "EstimateDtCreateDiv_tComboEditor";
            this.EstimateDtCreateDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.EstimateDtCreateDiv_tComboEditor.TabIndex = 16;
            // 
            // EstimateDtCreateDiv_Title_Label
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.EstimateDtCreateDiv_Title_Label.Appearance = appearance29;
            this.EstimateDtCreateDiv_Title_Label.Location = new System.Drawing.Point(330, 356);
            this.EstimateDtCreateDiv_Title_Label.Name = "EstimateDtCreateDiv_Title_Label";
            this.EstimateDtCreateDiv_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.EstimateDtCreateDiv_Title_Label.TabIndex = 72;
            this.EstimateDtCreateDiv_Title_Label.Text = "���σf�[�^�쐬�敪";
            // 
            // PartsSelectDivCd_Title_Label
            // 
            appearance46.TextVAlignAsString = "Middle";
            this.PartsSelectDivCd_Title_Label.Appearance = appearance46;
            this.PartsSelectDivCd_Title_Label.Location = new System.Drawing.Point(20, 356);
            this.PartsSelectDivCd_Title_Label.Name = "PartsSelectDivCd_Title_Label";
            this.PartsSelectDivCd_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.PartsSelectDivCd_Title_Label.TabIndex = 74;
            this.PartsSelectDivCd_Title_Label.Text = "���i�I���敪";
            // 
            // PartsSearchDivCd_Title_Label
            // 
            appearance47.TextVAlignAsString = "Middle";
            this.PartsSearchDivCd_Title_Label.Appearance = appearance47;
            this.PartsSearchDivCd_Title_Label.Location = new System.Drawing.Point(20, 386);
            this.PartsSearchDivCd_Title_Label.Name = "PartsSearchDivCd_Title_Label";
            this.PartsSearchDivCd_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.PartsSearchDivCd_Title_Label.TabIndex = 75;
            this.PartsSearchDivCd_Title_Label.Text = "���i�����敪";
            // 
            // PartsSearchDivCd_tComboEditor
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsSearchDivCd_tComboEditor.ActiveAppearance = appearance48;
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsSearchDivCd_tComboEditor.Appearance = appearance49;
            this.PartsSearchDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PartsSearchDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsSearchDivCd_tComboEditor.ItemAppearance = appearance50;
            this.PartsSearchDivCd_tComboEditor.Location = new System.Drawing.Point(171, 386);
            this.PartsSearchDivCd_tComboEditor.MaxDropDownItems = 18;
            this.PartsSearchDivCd_tComboEditor.Name = "PartsSearchDivCd_tComboEditor";
            this.PartsSearchDivCd_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.PartsSearchDivCd_tComboEditor.TabIndex = 17;
            // 
            // PartsSelectDivCd_tComboEditor
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsSelectDivCd_tComboEditor.ActiveAppearance = appearance51;
            appearance52.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance52.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsSelectDivCd_tComboEditor.Appearance = appearance52;
            this.PartsSelectDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PartsSelectDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsSelectDivCd_tComboEditor.ItemAppearance = appearance53;
            this.PartsSelectDivCd_tComboEditor.Location = new System.Drawing.Point(171, 356);
            this.PartsSelectDivCd_tComboEditor.MaxDropDownItems = 18;
            this.PartsSelectDivCd_tComboEditor.Name = "PartsSelectDivCd_tComboEditor";
            this.PartsSelectDivCd_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.PartsSelectDivCd_tComboEditor.TabIndex = 15;
            // 
            // RateUseCode_tComboEditor
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateUseCode_tComboEditor.ActiveAppearance = appearance54;
            appearance55.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance55.ForeColorDisabled = System.Drawing.Color.Black;
            this.RateUseCode_tComboEditor.Appearance = appearance55;
            this.RateUseCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.RateUseCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateUseCode_tComboEditor.ItemAppearance = appearance56;
            this.RateUseCode_tComboEditor.Location = new System.Drawing.Point(481, 386);
            this.RateUseCode_tComboEditor.MaxDropDownItems = 18;
            this.RateUseCode_tComboEditor.Name = "RateUseCode_tComboEditor";
            this.RateUseCode_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.RateUseCode_tComboEditor.TabIndex = 18;
            // 
            // RateUseCode_Title_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.RateUseCode_Title_Label.Appearance = appearance3;
            this.RateUseCode_Title_Label.Location = new System.Drawing.Point(330, 386);
            this.RateUseCode_Title_Label.Name = "RateUseCode_Title_Label";
            this.RateUseCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.RateUseCode_Title_Label.TabIndex = 73;
            this.RateUseCode_Title_Label.Text = "�|���g�p�敪";
            // 
            // PartsNoPrtCd_tComboEditor
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsNoPrtCd_tComboEditor.ActiveAppearance = appearance69;
            appearance70.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance70.ForeColorDisabled = System.Drawing.Color.Black;
            this.PartsNoPrtCd_tComboEditor.Appearance = appearance70;
            this.PartsNoPrtCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PartsNoPrtCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PartsNoPrtCd_tComboEditor.ItemAppearance = appearance71;
            this.PartsNoPrtCd_tComboEditor.Location = new System.Drawing.Point(481, 105);
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = 18;
            this.PartsNoPrtCd_tComboEditor.Name = "PartsNoPrtCd_tComboEditor";
            this.PartsNoPrtCd_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.PartsNoPrtCd_tComboEditor.TabIndex = 8;
            // 
            // PartsNoPrtCd_Title_Label
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.PartsNoPrtCd_Title_Label.Appearance = appearance72;
            this.PartsNoPrtCd_Title_Label.Location = new System.Drawing.Point(330, 107);
            this.PartsNoPrtCd_Title_Label.Name = "PartsNoPrtCd_Title_Label";
            this.PartsNoPrtCd_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.PartsNoPrtCd_Title_Label.TabIndex = 78;
            this.PartsNoPrtCd_Title_Label.Text = "�i�Ԉ󎚋敪";
            // 
            // OptionPringDivCd_tComboEditor
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OptionPringDivCd_tComboEditor.ActiveAppearance = appearance94;
            appearance95.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance95.ForeColorDisabled = System.Drawing.Color.Black;
            this.OptionPringDivCd_tComboEditor.Appearance = appearance95;
            this.OptionPringDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.OptionPringDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OptionPringDivCd_tComboEditor.ItemAppearance = appearance96;
            this.OptionPringDivCd_tComboEditor.Location = new System.Drawing.Point(481, 135);
            this.OptionPringDivCd_tComboEditor.MaxDropDownItems = 18;
            this.OptionPringDivCd_tComboEditor.Name = "OptionPringDivCd_tComboEditor";
            this.OptionPringDivCd_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.OptionPringDivCd_tComboEditor.TabIndex = 10;
            // 
            // OptionPringDivCd_Title_Label
            // 
            appearance97.TextVAlignAsString = "Middle";
            this.OptionPringDivCd_Title_Label.Appearance = appearance97;
            this.OptionPringDivCd_Title_Label.Location = new System.Drawing.Point(330, 136);
            this.OptionPringDivCd_Title_Label.Name = "OptionPringDivCd_Title_Label";
            this.OptionPringDivCd_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.OptionPringDivCd_Title_Label.TabIndex = 79;
            this.OptionPringDivCd_Title_Label.Text = "�I�v�V��������敪";
            // 
            // FaxEstimatetDiv_tComboEditor
            // 
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FaxEstimatetDiv_tComboEditor.ActiveAppearance = appearance83;
            appearance84.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            this.FaxEstimatetDiv_tComboEditor.Appearance = appearance84;
            this.FaxEstimatetDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FaxEstimatetDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FaxEstimatetDiv_tComboEditor.ItemAppearance = appearance85;
            this.FaxEstimatetDiv_tComboEditor.Location = new System.Drawing.Point(171, 105);
            this.FaxEstimatetDiv_tComboEditor.MaxDropDownItems = 18;
            this.FaxEstimatetDiv_tComboEditor.Name = "FaxEstimatetDiv_tComboEditor";
            this.FaxEstimatetDiv_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.FaxEstimatetDiv_tComboEditor.TabIndex = 7;
            // 
            // FaxEstimatetDiv_Title_Label
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.FaxEstimatetDiv_Title_Label.Appearance = appearance68;
            this.FaxEstimatetDiv_Title_Label.Location = new System.Drawing.Point(20, 107);
            this.FaxEstimatetDiv_Title_Label.Name = "FaxEstimatetDiv_Title_Label";
            this.FaxEstimatetDiv_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.FaxEstimatetDiv_Title_Label.TabIndex = 81;
            this.FaxEstimatetDiv_Title_Label.Text = "�e�`�w���ϋ敪";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(301, 442);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 20;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // DCMIT09010UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 507);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.FaxEstimatetDiv_tComboEditor);
            this.Controls.Add(this.FaxEstimatetDiv_Title_Label);
            this.Controls.Add(this.PartsNoPrtCd_tComboEditor);
            this.Controls.Add(this.PartsNoPrtCd_Title_Label);
            this.Controls.Add(this.OptionPringDivCd_tComboEditor);
            this.Controls.Add(this.OptionPringDivCd_Title_Label);
            this.Controls.Add(this.EstimateDtCreateDiv_tComboEditor);
            this.Controls.Add(this.EstimateDtCreateDiv_Title_Label);
            this.Controls.Add(this.PartsSelectDivCd_Title_Label);
            this.Controls.Add(this.PartsSearchDivCd_Title_Label);
            this.Controls.Add(this.PartsSearchDivCd_tComboEditor);
            this.Controls.Add(this.PartsSelectDivCd_tComboEditor);
            this.Controls.Add(this.RateUseCode_tComboEditor);
            this.Controls.Add(this.RateUseCode_Title_Label);
            this.Controls.Add(this.EstimateValidityTerm_Title_Label2);
            this.Controls.Add(this.EstimateValidityTerm_Title_Label1);
            this.Controls.Add(this.EstimateValidityTerm_tEdit);
            this.Controls.Add(this.SectionNm_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionGd_ultraButton);
            this.Controls.Add(this.ConsTaxPrintDiv_tComboEditor);
            this.Controls.Add(this.ConsTaxPrintDiv_Title_Label);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.EstimateNote1_Title_Label);
            this.Controls.Add(this.EstimateNote2_Title_Label);
            this.Controls.Add(this.EstimateNote3_Title_Label);
            this.Controls.Add(this.EstimateNote3_tEdit);
            this.Controls.Add(this.EstimatePrtDiv_Title_Label);
            this.Controls.Add(this.EstmFormNoPickDiv_Title_Label);
            this.Controls.Add(this.EstmFormNoPickDiv_tComboEditor);
            this.Controls.Add(this.EstimatePrtDiv_tComboEditor);
            this.Controls.Add(this.ListPricePrintDiv_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.EstimateNote2_tEdit);
            this.Controls.Add(this.EstimateNote1_tEdit);
            this.Controls.Add(this.EstimateTitle1_tEdit);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.ListPricePrintDiv_Title_Label);
            this.Controls.Add(this.EstimateTitle1_Title_Label);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCMIT09010UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "���ϑS�̐ݒ�";
            this.Load += new System.EventHandler(this.DCMIT09010UA_Load);
            this.VisibleChanged += new System.EventHandler(this.DCMIT09010UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.DCMIT09010UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateTitle1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPricePrintDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatePrtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstmFormNoPickDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateNote3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTaxPrintDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateValidityTerm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimateDtCreateDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsSearchDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsSelectDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateUseCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartsNoPrtCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPringDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaxEstimatetDiv_tComboEditor)).EndInit();
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
			System.Windows.Forms.Application.Run(new DCMIT09010UA());
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// �폜��
			appearanceTable.Add( DELETE_DATE, 
				new GridColAppearance( MGridColDispType.DeletionDataBoth, 
				ContentAlignment.MiddleLeft, "", Color.Red ) );
            // ���_�R�[�h
            appearanceTable.Add(�@SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_����
            appearanceTable.Add( SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �[�������敪
            //appearanceTable.Add( FRACTIONPROCCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// ����œ]�ŕ���
            //appearanceTable.Add( CONSTAXLAYMETHOD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            // �艿����敪
            appearanceTable.Add( LISTPRICEPRINTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����\���敪�P
            //appearanceTable.Add( ERANAMEDISPCD1_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// ���ύ��v����敪
            //appearanceTable.Add( ESTIMATEFORMTOTALPRTCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// ���Ϗ�����敪
            //appearanceTable.Add( ESTIMATEFORMPRTCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// �h�̈���敪
            //appearanceTable.Add( HONORIFICTITLEPRTCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// ���ψ˗��敪
            //appearanceTable.Add( ESTIMATEREQUESTCD_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���Ϗ��ԍ��̔ԋ敪
            appearanceTable.Add( ESTMFORMNOPICKDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ���Ϗ����s�敪
            appearanceTable.Add( ESTIMATEPRTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ψ˗������s�敪
            //appearanceTable.Add( ESTIMATEREQPRTDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            //// ���ϊm�F�����s�敪
            //appearanceTable.Add( ESTIMATECONFPRTDIV_TITLE,
            //    new GridColAppearance(MGridColDispType.Both,
            //    ContentAlignment.MiddleLeft, "", Color.Black));
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
    
            // ���σ^�C�g���P
            appearanceTable.Add( ESTIMATETITLE1_TITLE,
                new GridColAppearance( MGridColDispType.Both,
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // ���ϔ��l�P
            appearanceTable.Add( ESTIMATENOTE1_TITLE,
                new GridColAppearance( MGridColDispType.Both,
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // ���ϔ��l�Q
            appearanceTable.Add( ESTIMATENOTE2_TITLE,
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // ���ϔ��l�R
            appearanceTable.Add( ESTIMATENOTE3_TITLE,
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // ����ň���敪
            appearanceTable.Add(CONSTAXPRINTDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // �e�`�w���ϋ敪
            appearanceTable.Add(FAXESTIMATETDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // �i�Ԉ󎚋敪
            appearanceTable.Add(PARTSNOPRTCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // �I�v�V�����󎚋敪
            appearanceTable.Add(OPTIONPRINGDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ���i�I���敪
            appearanceTable.Add(PARTSSELECTDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ���i�����敪
            appearanceTable.Add(PARTSSEARCHDIVCD_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ���σf�[�^�쐬�敪
            appearanceTable.Add(ESTIMATEDTCREATEDIV_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ���Ϗ��L������
            appearanceTable.Add(ESTIMATEVALIDITYTERM_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �|���g�p�敪
            appearanceTable.Add(RATEUSECODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/04 --------------------------------<<<<< 

			// GUID
			appearanceTable.Add( GUID_TITLE, 
				new GridColAppearance( MGridColDispType.None, 
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
			bindDataSet	= this.Bind_DataSet;
			tableName	= ESTIMATEDEFSET_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCnt">�S�Y������</param>
		/// <param name="readCnt">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		public int Search( ref int totalCnt, int readCnt )
		{
			return SearchEstimateDefSet( ref totalCnt, readCnt );
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCnt">���o�Ώی���</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�茏�����̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int SearchEstimateDefSet( ref int totalCnt, int readCnt )
		{
			int status = 0;
			ArrayList estimateDefSets = null;

			// ���o�Ώی�����0���̏ꍇ�͑S�����o�����s����
            status = this._estimateDefSetAcs.SearchAll(out estimateDefSets, this._enterpriseCode);
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
                    foreach (EstimateDefSet estimateDefSet in estimateDefSets)
                    {
						if( this._estimateDefSetTable.ContainsKey( estimateDefSet.FileHeaderGuid ) == false ) {
							EstimateDefSetToDataSet( estimateDefSet.Clone(), index );
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
                        "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "���ϑS�̐ݒ�", 					// �v���O��������
                        "SearchEstimateDefSet", 			// ��������
						TMsgDisp.OPE_GET, 					// �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
                        this._estimateDefSetAcs, 			// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					break;
				}
			}
			
			totalCnt = estimateDefSets.Count;

			return status;
		}

		/// <summary>
        /// ���Ϗ����l�ݒ�I�u�W�F�N�g�W�J����
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�N���X��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void EstimateDefSetToDataSet(EstimateDefSet estimateDefSet, int index)
		{
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows.Count))
            {
				// �V�K�Ɣ��f���A�s��ǉ�����B
				DataRow dataRow = this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].NewRow();
				this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Add( dataRow );

				// index���ŏI�s�ԍ��ɂ���
				index = this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Count - 1;
			}

			// �폜��
			if( estimateDefSet.LogicalDeleteCode == 0 ) {
                this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][DELETE_DATE] = "";
            }
			else {
				//this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ DELETE_DATE ] = estimateDefSet.UpdateDateTimeJpInFormal;
                this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][DELETE_DATE] = estimateDefSet.UpdateDateTime;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][SECTIONCODE_TITLE] = estimateDefSet.SectionCode.TrimEnd();
            // ���_����
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == estimateDefSet.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }
            // ADD 2008/10/02 �s��Ή�[5966]---------->>>>>
            // ���_�R�[�h�i�S�Ћ��ʁj
            if (SectionUtil.IsAllSection(estimateDefSet.SectionCode.TrimEnd()))
            {
                this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][SECTIONNAME_TITLE] = SectionUtil.ALL_SECTION_NAME;
            }
            // ADD 2008/10/02 �s��Ή�[5966]----------<<<<<

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �[�������敪
            //switch (estimateDefSet.FractionProcCd)
            //{
            //    case 1:
            //        wrkstr = FRACPROC_CUT;           // �؎�
            //        break;
            //    case 2:
            //        wrkstr = FRACPROC_ROUND;         // �l�̌ܓ�
            //        break;
            //    case 3:
            //        wrkstr = FRACPROC_RAISE;        // �؏�
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][FRACTIONPROCCD_TITLE] = wrkstr;

            //// ����œ]�ŕ���
            //switch (estimateDefSet.ConsTaxLayMethod)
            //{
            //    case 0:
            //        wrkstr = CONSTAXLAY_SLIP;       // �`�[�P��
            //        break;
            //    case 1:
            //        wrkstr = CONSTAXLAY_DETAILS;    // ���גP��
            //        break;
            //    case 2:
            //        wrkstr = CONSTAXLAY_CLAIMPARENT;// �����e
            //        break;
            //    case 3:
            //        wrkstr = CONSTAXLAY_CLAIMCHILD; // �����q
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][CONSTAXLAYMETHOD_TITLE] = wrkstr;
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<

            // �艿����敪
            switch (estimateDefSet.ListPricePrintDiv)
            {
                case 0:
                    wrkstr = DIVISION_NO;           // ���Ȃ�
                    break;
                case 1:
                    wrkstr = DIVISION_YES;          // ����
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][LISTPRICEPRINTDIV_TITLE] = wrkstr;

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �����\���敪
            //switch (estimateDefSet.EraNameDispCd1)
            //{
            //    case 0:
            //        wrkstr = ERANAME_AD;            // ����
            //        break;
            //    case 1:
            //        wrkstr = ERANAME_JAPAN;         // �a��
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ERANAMEDISPCD1_TITLE] = wrkstr;

            
            //// ���ύ��v����敪
            //switch (estimateDefSet.EstimateTotalPrtCd)
            //{
            //    case 0:
            //        wrkstr = ESTIMATETOTALPRTCD_MODEL;  // �ӂ̂�
            //        break;
            //    case 1:
            //        wrkstr = ESTIMATETOTALPRTCD_END;    // ���ז���
            //        break;
            //    case 2:
            //        wrkstr = ESTIMATETOTALPRTCD_TOTAL;  // ���v��
            //        break;
            //    case 3:
            //        wrkstr = ESTIMATETOTALPRTCD_NON;    // ������Ȃ�
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEFORMTOTALPRTCD_TITLE] = wrkstr;

            //// ���Ϗ�����敪
            //switch (estimateDefSet.EstimateFormPrtCd)
            //{
            //    case 0:
            //        wrkstr = ESTIMATEFORMPRTCD_NORMAL;  // �ʏ�
            //        break;
            //    case 1:
            //        wrkstr = ESTIMATEFORMPRTCD_PAGEOVER;// �P�łɓ���Ȃ��ꍇ���וʎ�
            //        break;
            //    case 2:
            //        wrkstr = ESTIMATEFORMPRTCD_ANOTHER; // ���וʎ�
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEFORMPRTCD_TITLE] = wrkstr;

            //// �h�̈���敪
            //switch (estimateDefSet.HonorificTitlePrtCd)
            //{
            //    case 0:
            //        wrkstr = DIVISION_YES;          // ����
            //        break;
            //    case 1:
            //        wrkstr = DIVISION_NO;           // ���Ȃ�
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][HONORIFICTITLEPRTCD_TITLE] = wrkstr;

            //// ���ψ˗��敪
            //switch (estimateDefSet.EstimateRequestCd)
            //{
            //    case 0:
            //        wrkstr = ESTIMATEFORMPRTCD_NORMAL;  // �ʏ�
            //        break;
            //    case 1:
            //        wrkstr = ESTIMATEFORMPRTCD_PAGEOVER;// �P�łɓ���Ȃ��ꍇ���וʎ�
            //        break;
            //    case 2:
            //        wrkstr = ESTIMATEFORMPRTCD_ANOTHER; // ���וʎ�
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEREQUESTCD_TITLE] = wrkstr;
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<

            // ���Ϗ��ԍ��̔ԋ敪
            switch (estimateDefSet.EstmFormNoPickDiv)
            {
                case 0:
                    wrkstr = DIVISION_ON;           // �L��
                    break;
                case 1:
                    wrkstr = DIVISION_OFF;          // ����
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTMFORMNOPICKDIV_TITLE] = wrkstr;

            // ���Ϗ����s�敪
            switch (estimateDefSet.EstimatePrtDiv)
            {
                case 0:
                    wrkstr = DIVISION_YES;          // ����
                    break;
                case 1:
                    wrkstr = DIVISION_NO;           // ���Ȃ�
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEPRTDIV_TITLE] = wrkstr;

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ψ˗������s�敪
            //switch (estimateDefSet.EstimateReqPrtDiv)
            //{
            //    case 0:
            //        wrkstr = DIVISION_YES;          // ����
            //        break;
            //    case 1:
            //        wrkstr = DIVISION_NO;           // ���Ȃ�
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEREQPRTDIV_TITLE] = wrkstr;

            //// ���ϊm�F�����s�敪
            //switch (estimateDefSet.EstimateConfPrtDiv)
            //{
            //    case 0:
            //        wrkstr = DIVISION_NO;           // ���Ȃ�
            //        break;
            //    case 1:
            //        wrkstr = DIVISION_YES;          // ����
            //        break;
            //    default:
            //        wrkstr = UNREGISTER;
            //        break;
            //}
            //this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATECONFPRTDIV_TITLE] = wrkstr;
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            // ���σ^�C�g���P
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ ESTIMATETITLE1_TITLE ] = estimateDefSet.EstimateTitle1;
            // ���ϔ��l�P
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ ESTIMATENOTE1_TITLE  ] = estimateDefSet.EstimateNote1;
            // ���ϔ��l�Q
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ ESTIMATENOTE2_TITLE  ] = estimateDefSet.EstimateNote2;
            // ���ϔ��l�R
            this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ ESTIMATENOTE3_TITLE  ] = estimateDefSet.EstimateNote3;
            // --- ADD 2008/06/04 -------------------------------->>>>>
            // ����ň���敪
            switch (estimateDefSet.ConsTaxPrintDiv)
            {
                case 0:
                    wrkstr = DIVISION_YES;          // ����
                    break;
                case 1:
                    wrkstr = DIVISION_NO;           // ���Ȃ�
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][CONSTAXPRINTDIV_TITLE] = wrkstr;

            // �e�`�w���ϋ敪
            switch (estimateDefSet.FaxEstimatetDiv)
            {
                case 0:
                    wrkstr = DIVISION_NO;           // ���Ȃ�
                    break;
                case 1:
                    wrkstr = DIVISION_YES;          // ����
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][FAXESTIMATETDIV_TITLE] = wrkstr;

            // �i�Ԉ󎚋敪
            switch (estimateDefSet.PartsNoPrtCd)
            {
                case 0:
                    wrkstr = DIVISION_NO;           // ���Ȃ�
                    break;
                case 1:
                    wrkstr = DIVISION_YES;          // ����
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][PARTSNOPRTCD_TITLE] = wrkstr;

            // �I�v�V�����󎚋敪
            switch (estimateDefSet.OptionPringDivCd)
            {
                case 0:
                    wrkstr = DIVISION_NO;           // ���Ȃ�
                    break;
                case 1:
                    wrkstr = DIVISION_YES;          // ����
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][OPTIONPRINGDIVCD_TITLE] = wrkstr;

            // ���i�I���敪
            switch (estimateDefSet.PartsSelectDivCd)
            {
                case 0:
                    wrkstr = DIVISION_YES;          // ����
                    break;
                case 1:
                    wrkstr = DIVISION_NO;           // ���Ȃ�
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][PARTSSELECTDIVCD_TITLE] = wrkstr;

            // ���i�����敪
            switch (estimateDefSet.PartsSearchDivCd)
            {
                case 0:
                    wrkstr = PARTSSEARCHDIVCD_PARTS; // ���i����
                    break;
                case 1:
                    wrkstr = PARTSSEARCHDIVCD_NO;    // �i�Ԍ���
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][PARTSSEARCHDIVCD_TITLE] = wrkstr;

            // ���σf�[�^�쐬�敪
            switch (estimateDefSet.EstimateDtCreateDiv)
            {
                case 0:
                    wrkstr = DIVISION_YES;          // ����
                    break;
                case 1:
                    wrkstr = DIVISION_NO;           // ���Ȃ�
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEDTCREATEDIV_TITLE] = wrkstr;

            // ���Ϗ��L������
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][ESTIMATEVALIDITYTERM_TITLE] = estimateDefSet.EstimateValidityTerm;

            // �|���g�p�敪
            switch (estimateDefSet.RateUseCode)
            {
                case 0:
                    wrkstr = RATEUSECODE_DEFAULT;     // ����=�艿
                    break;
                case 1:
                    wrkstr = RATEUSECODE_RATESELECT;  // �|���w��
                    break;
                case 2:
                    wrkstr = RATEUSECODE_RATESET;     // �|���ݒ�
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[index][RATEUSECODE_TITLE] = wrkstr;
            // --- ADD 2008/06/04 --------------------------------<<<<< 

			// GUID
			this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ index ][ GUID_TITLE ] = estimateDefSet.FileHeaderGuid;

            if (this._estimateDefSetTable.ContainsKey(estimateDefSet.FileHeaderGuid) == true)
            {
				this._estimateDefSetTable.Remove( estimateDefSet.FileHeaderGuid );
			}
			this._estimateDefSetTable.Add( estimateDefSet.FileHeaderGuid, estimateDefSet );

		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable estimateDefSetTable = new DataTable( ESTIMATEDEFSET_TABLE );
			estimateDefSetTable.Columns.Add( DELETE_DATE, typeof( string ) );

            estimateDefSetTable.Columns.Add( SECTIONCODE_TITLE              , typeof(string) );
			estimateDefSetTable.Columns.Add( SECTIONNAME_TITLE              , typeof(string) );
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSetTable.Columns.Add( FRACTIONPROCCD_TITLE           , typeof(string) );
            //estimateDefSetTable.Columns.Add( CONSTAXLAYMETHOD_TITLE         , typeof(string) );
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            estimateDefSetTable.Columns.Add(CONSTAXPRINTDIV_TITLE           , typeof(string));  // ADD 2008/06/04
			estimateDefSetTable.Columns.Add( LISTPRICEPRINTDIV_TITLE        , typeof(string) );
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSetTable.Columns.Add( ERANAMEDISPCD1_TITLE           , typeof(string) );
            //estimateDefSetTable.Columns.Add( ESTIMATEFORMTOTALPRTCD_TITLE   , typeof(string) );
            //estimateDefSetTable.Columns.Add( ESTIMATEFORMPRTCD_TITLE        , typeof(string) );
            //estimateDefSetTable.Columns.Add( HONORIFICTITLEPRTCD_TITLE      , typeof(string) );
            //estimateDefSetTable.Columns.Add( ESTIMATEREQUESTCD_TITLE        , typeof(string) );
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
			estimateDefSetTable.Columns.Add( ESTMFORMNOPICKDIV_TITLE        , typeof(string) );
			estimateDefSetTable.Columns.Add( ESTIMATEPRTDIV_TITLE           , typeof(string) );
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSetTable.Columns.Add( ESTIMATEREQPRTDIV_TITLE        , typeof(string) );
            //estimateDefSetTable.Columns.Add( ESTIMATECONFPRTDIV_TITLE       , typeof(string) );
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<

            estimateDefSetTable.Columns.Add( ESTIMATETITLE1_TITLE   , typeof(string) );
            estimateDefSetTable.Columns.Add( ESTIMATENOTE1_TITLE    , typeof(string) );
            estimateDefSetTable.Columns.Add( ESTIMATENOTE2_TITLE    , typeof(string) );
            estimateDefSetTable.Columns.Add( ESTIMATENOTE3_TITLE    , typeof(string) );
            // --- ADD 2008/06/04 -------------------------------->>>>>
            estimateDefSetTable.Columns.Add(FAXESTIMATETDIV_TITLE       , typeof(string));
            estimateDefSetTable.Columns.Add(PARTSNOPRTCD_TITLE          , typeof(string));
            estimateDefSetTable.Columns.Add(OPTIONPRINGDIVCD_TITLE      , typeof(string));
            estimateDefSetTable.Columns.Add(PARTSSELECTDIVCD_TITLE      , typeof(string));
            estimateDefSetTable.Columns.Add(PARTSSEARCHDIVCD_TITLE      , typeof(string));
            estimateDefSetTable.Columns.Add(ESTIMATEDTCREATEDIV_TITLE   , typeof(string));
            estimateDefSetTable.Columns.Add(ESTIMATEVALIDITYTERM_TITLE  , typeof(string));
            estimateDefSetTable.Columns.Add(RATEUSECODE_TITLE           , typeof(string));
            // --- ADD 2008/06/04 --------------------------------<<<<< 

			estimateDefSetTable.Columns.Add( GUID_TITLE, typeof( Guid ) );

			this.Bind_DataSet.Tables.Add( estimateDefSetTable );
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
			// �{�^���z�u
            int CANCELBUTTONLOCATION_X = this.Cancel_Button.Location.X;
            int OKBUTTONLOCATION_X = this.Ok_Button.Location.X;
            int DELETEBUTTONLOCATION_X = this.Revive_Button.Location.X;
            int BUTTONLOCATION_Y = this.Cancel_Button.Location.Y;
            this.Cancel_Button.Location = new System.Drawing.Point(CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Ok_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Revive_Button.Location = new System.Drawing.Point(OKBUTTONLOCATION_X, BUTTONLOCATION_Y);
            this.Delete_Button.Location = new System.Drawing.Point(DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y);

            /* --- DEL 2008/06/04 -------------------------------->>>>>
            // ���_�R���{�{�b�N�X�̃Z�b�g
            this.SectionCode_tComboEditor.Items.Clear();
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                this.SectionCode_tComboEditor.Items.Add(si.SectionCode.TrimEnd(), si.SectionGuideNm);
            }
               --- DEL 2008/06/04 --------------------------------<<<<< */

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �[�������敪�̺����ޯ���ɏ��Z�b�g
            //this.FractionProcCd_tComboEditor.Items.Clear();
            //this.FractionProcCd_tComboEditor.Items.Add(1, FRACPROC_CUT);
            //this.FractionProcCd_tComboEditor.Items.Add(2, FRACPROC_ROUND);
            //this.FractionProcCd_tComboEditor.Items.Add(3, FRACPROC_RAISE);
            //this.FractionProcCd_tComboEditor.MaxDropDownItems = this.FractionProcCd_tComboEditor.Items.Count;
            //this.FractionProcCd_tComboEditor.Value = 1;

            //// ����œ]�ŕ����̺����ޯ���ɏ��Z�b�g
            //this.ConsTaxLayMethod_tComboEditor.Items.Clear();
            //this.ConsTaxLayMethod_tComboEditor.Items.Add(0, CONSTAXLAY_SLIP);
            //this.ConsTaxLayMethod_tComboEditor.Items.Add(1, CONSTAXLAY_DETAILS);
            //this.ConsTaxLayMethod_tComboEditor.Items.Add(2, CONSTAXLAY_CLAIMPARENT);
            //this.ConsTaxLayMethod_tComboEditor.Items.Add(3, CONSTAXLAY_CLAIMCHILD);
            //this.ConsTaxLayMethod_tComboEditor.MaxDropDownItems = this.ConsTaxLayMethod_tComboEditor.Items.Count;

            //// �����\���敪�̺����ޯ���ɏ��Z�b�g
            //this.EraNameDispCd1_tComboEditor.Items.Clear();
            //this.EraNameDispCd1_tComboEditor.Items.Add(0, ERANAME_AD);
            //this.EraNameDispCd1_tComboEditor.Items.Add(1, ERANAME_JAPAN);
            //this.EraNameDispCd1_tComboEditor.MaxDropDownItems = this.EraNameDispCd1_tComboEditor.Items.Count;
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<

            // �艿����敪�̺����ޯ���ɏ��Z�b�g
            this.ListPricePrintDiv_tComboEditor.Items.Clear();
            this.ListPricePrintDiv_tComboEditor.Items.Add(0, DIVISION_NO);
            this.ListPricePrintDiv_tComboEditor.Items.Add(1, DIVISION_YES);
            this.ListPricePrintDiv_tComboEditor.MaxDropDownItems = this.ListPricePrintDiv_tComboEditor.Items.Count;

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ύ��v����敪�̺����ޯ���ɏ��Z�b�g
            //this.EstimateTotalPrtCd_tComboEditor.Items.Clear();
            //this.EstimateTotalPrtCd_tComboEditor.Items.Add(0, ESTIMATETOTALPRTCD_MODEL);
            //this.EstimateTotalPrtCd_tComboEditor.Items.Add(1, ESTIMATETOTALPRTCD_END);
            //this.EstimateTotalPrtCd_tComboEditor.Items.Add(2, ESTIMATETOTALPRTCD_TOTAL);
            //this.EstimateTotalPrtCd_tComboEditor.Items.Add(3, ESTIMATETOTALPRTCD_NON);
            //this.EstimateTotalPrtCd_tComboEditor.MaxDropDownItems = this.EstimateTotalPrtCd_tComboEditor.Items.Count;

            //// ���Ϗ�����敪�̺����ޯ���ɏ��Z�b�g
            //this.EstimateFormPrtCd_tComboEditor.Items.Clear();
            //this.EstimateFormPrtCd_tComboEditor.Items.Add(0, ESTIMATEFORMPRTCD_NORMAL);
            //this.EstimateFormPrtCd_tComboEditor.Items.Add(1, ESTIMATEFORMPRTCD_PAGEOVER);
            //this.EstimateFormPrtCd_tComboEditor.Items.Add(2, ESTIMATEFORMPRTCD_ANOTHER);
            //this.EstimateFormPrtCd_tComboEditor.MaxDropDownItems = this.EstimateFormPrtCd_tComboEditor.Items.Count;

            //// �h�̈���敪�̺����ޯ���ɏ��Z�b�g
            //this.HonorificTitlePrtCd_tComboEditor.Items.Clear();
            //this.HonorificTitlePrtCd_tComboEditor.Items.Add(0, DIVISION_YES);
            //this.HonorificTitlePrtCd_tComboEditor.Items.Add(1, DIVISION_NO);
            //this.HonorificTitlePrtCd_tComboEditor.MaxDropDownItems = this.HonorificTitlePrtCd_tComboEditor.Items.Count;

            //// ���ψ˗��敪�̺����ޯ���ɏ��Z�b�g
            //this.EstimateRequestCd_tComboEditor.Items.Clear();
            //this.EstimateRequestCd_tComboEditor.Items.Add(0, ESTIMATEFORMPRTCD_NORMAL);
            //this.EstimateRequestCd_tComboEditor.Items.Add(1, ESTIMATEFORMPRTCD_PAGEOVER);
            //this.EstimateRequestCd_tComboEditor.Items.Add(2, ESTIMATEFORMPRTCD_ANOTHER);
            //this.EstimateRequestCd_tComboEditor.MaxDropDownItems = this.EstimateRequestCd_tComboEditor.Items.Count;
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            
            // ���Ϗ��ԍ��̔ԋ敪�̺����ޯ���ɏ��Z�b�g
            this.EstmFormNoPickDiv_tComboEditor.Items.Clear();
            this.EstmFormNoPickDiv_tComboEditor.Items.Add(0, DIVISION_ON);
            this.EstmFormNoPickDiv_tComboEditor.Items.Add(1, DIVISION_OFF);
            this.EstmFormNoPickDiv_tComboEditor.MaxDropDownItems = this.EstmFormNoPickDiv_tComboEditor.Items.Count;

            // ���Ϗ����s�敪�̺����ޯ���ɏ��Z�b�g
            this.EstimatePrtDiv_tComboEditor.Items.Clear();
            this.EstimatePrtDiv_tComboEditor.Items.Add(0, DIVISION_YES);
            this.EstimatePrtDiv_tComboEditor.Items.Add(1, DIVISION_NO);
            this.EstimatePrtDiv_tComboEditor.MaxDropDownItems = this.EstimatePrtDiv_tComboEditor.Items.Count;

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ψ˗������s�敪�̺����ޯ���ɏ��Z�b�g
            //this.EstimateReqPrtDiv_tComboEditor.Items.Clear();
            //this.EstimateReqPrtDiv_tComboEditor.Items.Add(0, DIVISION_YES);
            //this.EstimateReqPrtDiv_tComboEditor.Items.Add(1, DIVISION_NO);
            //this.EstimateReqPrtDiv_tComboEditor.MaxDropDownItems = this.EstimateReqPrtDiv_tComboEditor.Items.Count;

            //// ���ϊm�F�����s�敪�̺����ޯ���ɏ��Z�b�g
            //this.EstimateConfPrtDiv_tComboEditor.Items.Clear();
            //this.EstimateConfPrtDiv_tComboEditor.Items.Add(0, DIVISION_NO);
            //this.EstimateConfPrtDiv_tComboEditor.Items.Add(1, DIVISION_YES);
            //this.EstimateConfPrtDiv_tComboEditor.MaxDropDownItems = this.EstimateConfPrtDiv_tComboEditor.Items.Count;
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<

            // ����ň���敪�̺����ޯ���ɏ��Z�b�g
            this.ConsTaxPrintDiv_tComboEditor.Items.Clear();
            this.ConsTaxPrintDiv_tComboEditor.Items.Add(0, DIVISION_YES);
            this.ConsTaxPrintDiv_tComboEditor.Items.Add(1, DIVISION_NO);
            this.ConsTaxPrintDiv_tComboEditor.MaxDropDownItems = this.ConsTaxPrintDiv_tComboEditor.Items.Count;

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // �e�`�w���ϋ敪�̺����ޯ���ɏ��Z�b�g
            this.FaxEstimatetDiv_tComboEditor.Items.Clear();
            this.FaxEstimatetDiv_tComboEditor.Items.Add(0, DIVISION_NO);
            this.FaxEstimatetDiv_tComboEditor.Items.Add(1, DIVISION_YES);
            this.FaxEstimatetDiv_tComboEditor.MaxDropDownItems = this.FaxEstimatetDiv_tComboEditor.Items.Count;

            // �i�Ԉ󎚋敪�̺����ޯ���ɏ��Z�b�g
            this.PartsNoPrtCd_tComboEditor.Items.Clear();
            this.PartsNoPrtCd_tComboEditor.Items.Add(0, DIVISION_NO);
            this.PartsNoPrtCd_tComboEditor.Items.Add(1, DIVISION_YES);
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = this.PartsNoPrtCd_tComboEditor.Items.Count;

            // �I�v�V�����󎚋敪�̺����ޯ���ɏ��Z�b�g
            this.OptionPringDivCd_tComboEditor.Items.Clear();
            this.OptionPringDivCd_tComboEditor.Items.Add(0, DIVISION_NO);
            this.OptionPringDivCd_tComboEditor.Items.Add(1, DIVISION_YES);
            this.OptionPringDivCd_tComboEditor.MaxDropDownItems = this.OptionPringDivCd_tComboEditor.Items.Count;

            // ���i�I���敪�̺����ޯ���ɏ��Z�b�g
            this.PartsSelectDivCd_tComboEditor.Items.Clear();
            this.PartsSelectDivCd_tComboEditor.Items.Add(0, DIVISION_YES);
            this.PartsSelectDivCd_tComboEditor.Items.Add(1, DIVISION_NO);
            this.PartsSelectDivCd_tComboEditor.MaxDropDownItems = this.PartsSelectDivCd_tComboEditor.Items.Count;

            // ���i�����敪�̺����ޯ���ɏ��Z�b�g
            this.PartsSearchDivCd_tComboEditor.Items.Clear();
            this.PartsSearchDivCd_tComboEditor.Items.Add(0, PARTSSEARCHDIVCD_PARTS);
            this.PartsSearchDivCd_tComboEditor.Items.Add(1, PARTSSEARCHDIVCD_NO);
            this.PartsSearchDivCd_tComboEditor.MaxDropDownItems = this.PartsSearchDivCd_tComboEditor.Items.Count;

            // ���σf�[�^�쐬�敪�̺����ޯ���ɏ��Z�b�g
            this.EstimateDtCreateDiv_tComboEditor.Items.Clear();
            this.EstimateDtCreateDiv_tComboEditor.Items.Add(0, DIVISION_YES);
            this.EstimateDtCreateDiv_tComboEditor.Items.Add(1, DIVISION_NO);
            this.EstimateDtCreateDiv_tComboEditor.MaxDropDownItems = this.EstimateDtCreateDiv_tComboEditor.Items.Count;

            // �|���g�p�敪�̺����ޯ���ɏ��Z�b�g
            this.RateUseCode_tComboEditor.Items.Clear();
            this.RateUseCode_tComboEditor.Items.Add(0, RATEUSECODE_DEFAULT);
            this.RateUseCode_tComboEditor.Items.Add(1, RATEUSECODE_RATESELECT);
            this.RateUseCode_tComboEditor.Items.Add(2, RATEUSECODE_RATESET);
            this.RateUseCode_tComboEditor.MaxDropDownItems = this.RateUseCode_tComboEditor.Items.Count;
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void ScreenClear()
		{
            //this.SectionCode_tComboEditor.SelectedIndex = 0;        // ���_  // DEL 2008/06/04

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.FractionProcCd_tComboEditor.SelectedIndex = 0;     // �[�������敪
            //this.ConsTaxLayMethod_tComboEditor.SelectedIndex = 0;   // ����œ]�ŕ���
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.ListPricePrintDiv_tComboEditor.SelectedIndex = 0;  // �艿����敪
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.EraNameDispCd1_tComboEditor.SelectedIndex = 0;     // �����\���敪�P
            //this.EstimateTotalPrtCd_tComboEditor.SelectedIndex = 0; // ���ύ��v����敪
            //this.EstimateFormPrtCd_tComboEditor.SelectedIndex = 0;  // ���Ϗ�����敪
            //this.HonorificTitlePrtCd_tComboEditor.SelectedIndex = 0;// �h�̈���敪
            //this.EstimateRequestCd_tComboEditor.SelectedIndex = 0;  // ���ψ˗��敪
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.EstmFormNoPickDiv_tComboEditor.SelectedIndex = 0;  // ���Ϗ��ԍ��̔ԋ敪
            this.EstimateTitle1_tEdit.Clear();                      // ���σ^�C�g���P		
            this.EstimateNote1_tEdit.Clear();                       // ���ϔ��l�P      
            this.EstimateNote2_tEdit.Clear();                       // ���ϔ��l�Q
            this.EstimateNote3_tEdit.Clear();                       // ���ϔ��l�R
            this.EstimatePrtDiv_tComboEditor.SelectedIndex = 0;     // ���Ϗ����s�敪
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.EstimateReqPrtDiv_tComboEditor.SelectedIndex = 0;  // ���ψ˗������s�敪
            //this.EstimateConfPrtDiv_tComboEditor.SelectedIndex = 0; // ���ϊm�F�����s�敪
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.ConsTaxPrintDiv_tComboEditor.SelectedIndex = 0;    // ����ň���敪

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this.FaxEstimatetDiv_tComboEditor.SelectedIndex = 0;      // �e�`�w���ϋ敪
            this.tEdit_SectionCodeAllowZero2.Clear();                  // ���_�R�[�h
            this.SectionNm_tEdit.Clear();                             // ���_�K�C�h����
            this.PartsNoPrtCd_tComboEditor.SelectedIndex = 0;         // �i�Ԉ󎚋敪
            this.OptionPringDivCd_tComboEditor.SelectedIndex = 0;     // �I�v�V�����󎚋敪
            this.EstimateValidityTerm_tEdit.Clear();                  // ���Ϗ��L������
            this.PartsSelectDivCd_tComboEditor.SelectedIndex = 0;     // ���i�I���敪
            this.PartsSearchDivCd_tComboEditor.SelectedIndex = 0;     // ���i�����敪
            this.EstimateDtCreateDiv_tComboEditor.SelectedIndex = 0;  // ���σf�[�^�쐬�敪
            this.RateUseCode_tComboEditor.SelectedIndex = 0;          // �|���g�p�敪
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			if( this._dataIndex < 0 ) {
				// �V�K���[�h
				this._logicalDeleteMode = -1;

                EstimateDefSet newEstimateDefSet = new EstimateDefSet();

                // �u���Ϗ��L�������v�����l�ݒ�
                newEstimateDefSet.EstimateValidityTerm = 1;  // ADD 2008/06/04

                // ���Ϗ����l�ݒ�I�u�W�F�N�g����ʂɓW�J
				EstimateDefSetToScreen( newEstimateDefSet );

                // �N���[���쐬
				this._estimateDefSetClone = newEstimateDefSet.Clone();
				DispToEstimateDefSet( ref this._estimateDefSetClone );
			}
			else {
				Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
                EstimateDefSet estimateDefSet = (EstimateDefSet)this._estimateDefSetTable[guid];

                // ���Ϗ����l�ݒ�I�u�W�F�N�g����ʂɓW�J
				EstimateDefSetToScreen( estimateDefSet );

                if ( estimateDefSet.LogicalDeleteCode == 0 ) {
					// �X�V���[�h
					this._logicalDeleteMode = 0;

					// �N���[���쐬
					this._estimateDefSetClone = estimateDefSet.Clone();
					DispToEstimateDefSet( ref this._estimateDefSetClone );
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
					this.Ok_Button.Visible			= true;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= false;
					this.Delete_Button.Visible		= false;
                    // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

					// �R���g���[���̕\���ݒ�
					ScreenInputPermissionControl( true );

                    // --- ADD 2008/06/04 -------------------------------->>>>>
                    // �����t�H�[�J�X���Z�b�g
                    this.tEdit_SectionCodeAllowZero2.Focus();

                    // ���_�R�[�h�̃R�����g�\��
                    SectionNm_Label.Visible = true;
                    // --- ADD 2008/06/04 --------------------------------<<<<< 

					break;
				}
				case 1:
				{
					// �폜���[�h
					this.Mode_Label.Text		= DELETE_MODE;

					// �{�^���̕\��
					this.Ok_Button.Visible			= false;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= true;
					this.Delete_Button.Visible		= true;
                    // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = false;
                    // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

					// �R���g���[���̕\���ݒ�
					ScreenInputPermissionControl( false );

					// �����t�H�[�J�X���Z�b�g
					this.Delete_Button.Focus();

                    // ���_�R�[�h�̃R�����g��\��
                    SectionNm_Label.Visible = false;  // ADD 2008/06/04

					break;
				}
				default:
				{
					// �X�V���[�h
					this.Mode_Label.Text		= UPDATE_MODE;

					// �{�^���̕\��
					this.Ok_Button.Visible			= true;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= false;
					this.Delete_Button.Visible		= false;
                    // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

					// �R���g���[���̕\���ݒ�
					ScreenInputPermissionControl( true );

                    // --- ADD 2008/06/04 -------------------------------->>>>>
                    // ���_�֌W�̃R���g���[�����g�p�s�ɂ���
                    tEdit_SectionCodeAllowZero2.Enabled = false;
                    SectionGd_ultraButton.Enabled = false;
                    SectionNm_tEdit.Enabled = false;

                    // ���_�R�[�h�̃R�����g��\��
                    SectionNm_Label.Visible = false;  
                    // --- ADD 2008/06/04 --------------------------------<<<<< 

					// �����t�H�[�J�X���Z�b�g
                    this.EstimatePrtDiv_tComboEditor.Focus();

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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		void ScreenInputPermissionControl( bool enabled )
		{
            // this.SectionCode_tComboEditor.Enabled           = enabled;  // ���_  // DEL 2008/06/04
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.FractionProcCd_tComboEditor.Enabled      = enabled;  // �[�������敪
            //this.ConsTaxLayMethod_tComboEditor.Enabled    = enabled;  // ����œ]�ŕ���
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.ListPricePrintDiv_tComboEditor.Enabled     = enabled;  // �艿����敪
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.EraNameDispCd1_tComboEditor.Enabled      = enabled;  // �����\���敪�P
            //this.EstimateTotalPrtCd_tComboEditor.Enabled	= enabled;  // ���ύ��v����敪
            //this.EstimateFormPrtCd_tComboEditor.Enabled	= enabled;  // ���Ϗ�����敪
            //this.HonorificTitlePrtCd_tComboEditor.Enabled	= enabled;  // �h�̈���敪
            //this.EstimateRequestCd_tComboEditor.Enabled	= enabled;  // ���ψ˗��敪
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.EstmFormNoPickDiv_tComboEditor.Enabled     = enabled;  // ���Ϗ��ԍ��̔ԋ敪
            this.EstimateTitle1_tEdit.Enabled				= enabled;  // ���σ^�C�g���P		
            this.EstimateNote1_tEdit.Enabled				= enabled;  // ���ϔ��l�P      
            this.EstimateNote2_tEdit.Enabled				= enabled;  // ���ϔ��l�Q
            this.EstimateNote3_tEdit.Enabled				= enabled;  // ���ϔ��l�R
            this.EstimatePrtDiv_tComboEditor.Enabled		= enabled;  // ���Ϗ����s�敪
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.EstimateReqPrtDiv_tComboEditor.Enabled   = enabled;  // ���ψ˗������s�敪
            //this.EstimateConfPrtDiv_tComboEditor.Enabled  = enabled;  // ���ϊm�F�����s�敪
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.ConsTaxPrintDiv_tComboEditor.Enabled       = enabled;  // ����ň���敪

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this.FaxEstimatetDiv_tComboEditor.Enabled		= enabled;  // �e�`�w���ϋ敪
            this.tEdit_SectionCodeAllowZero2.Enabled                  = enabled;  // ���_�R�[�h
            this.SectionGd_ultraButton.Enabled              = enabled;  // �K�C�h�{�^�� 
            this.SectionNm_tEdit.Enabled                    = enabled;  // ���_�K�C�h����
            this.PartsNoPrtCd_tComboEditor.Enabled          = enabled;  // �i�Ԉ󎚋敪
            this.OptionPringDivCd_tComboEditor.Enabled      = enabled;  // �I�v�V�����󎚋敪
            this.EstimateValidityTerm_tEdit.Enabled         = enabled;  // ���Ϗ��L������
            this.PartsSelectDivCd_tComboEditor.Enabled      = enabled;  // ���i�I���敪
            this.PartsSearchDivCd_tComboEditor.Enabled      = enabled;  // ���i�����敪
            this.EstimateDtCreateDiv_tComboEditor.Enabled   = enabled;  // ���σf�[�^�쐬�敪
            this.RateUseCode_tComboEditor.Enabled           = enabled;  // �|���g�p�敪

            // ������h�~�̈�
            this.Enabled = true;
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

		/// <summary>
        /// ���Ϗ����l�ݒ�N���X��ʓW�J����
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void EstimateDefSetToScreen( EstimateDefSet estimateDefSet)
		{
            //this.SectionCode_tComboEditor.Value         = estimateDefSet.SectionCode.TrimEnd(); // ���_�R�[�h  // DEL 2008/06/04

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (estimateDefSet.FractionProcCd == 0)
            //{
            //    this.FractionProcCd_tComboEditor.Value  = 1;		                            // �[�������敪
            //}
            //else
            //{
            //    this.FractionProcCd_tComboEditor.Value  = estimateDefSet.FractionProcCd;		// �[�������敪
            //}
            //this.ConsTaxLayMethod_tComboEditor.Value    = estimateDefSet.ConsTaxLayMethod;	    // ����œ]�ŕ���
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.ListPricePrintDiv_tComboEditor.Value   = estimateDefSet.ListPricePrintDiv;     // �艿����敪
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.EraNameDispCd1_tComboEditor.Value      = estimateDefSet.EraNameDispCd1;		  // �����\���敪�P
            //this.EstimateTotalPrtCd_tComboEditor.Value  = estimateDefSet.EstimateTotalPrtCd;    // ���ύ��v����敪
            //this.EstimateFormPrtCd_tComboEditor.Value   = estimateDefSet.EstimateFormPrtCd;     // ���Ϗ�����敪
            //this.HonorificTitlePrtCd_tComboEditor.Value = estimateDefSet.HonorificTitlePrtCd;   // �h�̈���敪
            //this.EstimateRequestCd_tComboEditor.Value   = estimateDefSet.EstimateRequestCd;     // ���ψ˗��敪
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.EstmFormNoPickDiv_tComboEditor.Value   = estimateDefSet.EstmFormNoPickDiv;     // ���Ϗ��ԍ��̔ԋ敪
            this.EstimateTitle1_tEdit.DataText          = estimateDefSet.EstimateTitle1;        // ���σ^�C�g���P
            this.EstimateNote1_tEdit.DataText           = estimateDefSet.EstimateNote1;         // ���ϔ��l�P
            this.EstimateNote2_tEdit.DataText           = estimateDefSet.EstimateNote2;         // ���ϔ��l�Q
            this.EstimateNote3_tEdit.DataText           = estimateDefSet.EstimateNote3;         // ���ϔ��l�R
            this.EstimatePrtDiv_tComboEditor.Value      = estimateDefSet.EstimatePrtDiv;        // ���Ϗ����s�敪
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //this.EstimateReqPrtDiv_tComboEditor.Value   = estimateDefSet.EstimateReqPrtDiv;     // ���ψ˗������s�敪
            //this.EstimateConfPrtDiv_tComboEditor.Value  = estimateDefSet.EstimateConfPrtDiv;    // ���ϊm�F�����s�敪
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            this.ConsTaxPrintDiv_tComboEditor.Value = estimateDefSet.ConsTaxPrintDiv;       // ����ň���敪

            // --- ADD 2008/06/04 -------------------------------->>>>>
            this.FaxEstimatetDiv_tComboEditor.Value     = estimateDefSet.FaxEstimatetDiv;         // �e�`�w���ϋ敪

            this.tEdit_SectionCodeAllowZero2.Value = estimateDefSet.SectionCode.TrimEnd();                  // ���_�R�[�h
            // ���_����
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == estimateDefSet.SectionCode.TrimEnd())
                {
                    this.SectionNm_tEdit.Value = si.SectionGuideNm;
                    break;
                }
            }
            // ADD 2008/10/02 �s��Ή�[5966]---------->>>>>
            // ���_�R�[�h�i�S�Ћ��ʁj
            if (SectionUtil.IsAllSection(estimateDefSet.SectionCode.TrimEnd()))
            {
                this.SectionNm_tEdit.Value = SectionUtil.ALL_SECTION_NAME;
            }
            // ADD 2008/10/02 �s��Ή�[5966]----------<<<<<

            this.PartsNoPrtCd_tComboEditor.Value = estimateDefSet.PartsNoPrtCd;                 // �i�Ԉ󎚋敪
            this.OptionPringDivCd_tComboEditor.Value = estimateDefSet.OptionPringDivCd;         // �I�v�V�����󎚋敪
            this.PartsSelectDivCd_tComboEditor.Value = estimateDefSet.PartsSelectDivCd;         // ���i�I���敪
            this.PartsSearchDivCd_tComboEditor.Value = estimateDefSet.PartsSearchDivCd;         // ���i�����敪
            this.EstimateDtCreateDiv_tComboEditor.Value = estimateDefSet.EstimateDtCreateDiv;   // ���σf�[�^�쐬�敪
            this.EstimateValidityTerm_tEdit.Value = estimateDefSet.EstimateValidityTerm;        // ���Ϗ��L������
            this.RateUseCode_tComboEditor.Value = estimateDefSet.RateUseCode;                   // �|���g�p�敪
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

		/// <summary>
        /// ���Ϗ����l�ݒ�N���X�i�[����
		/// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʏ�񂩂猩�Ϗ����l�ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
        private void DispToEstimateDefSet(ref EstimateDefSet estimateDefSet)
		{
			if( estimateDefSet == null ) {
                estimateDefSet = new EstimateDefSet();
			}

            estimateDefSet.EnterpriseCode       = this._enterpriseCode;					            // ��ƃR�[�h

            /* --- DEL 2008/06/04 -------------------------------->>>>>
            if ((this.SectionCode_tComboEditor.SelectedItem != null) &&
                (this.SectionCode_tComboEditor.Value != null))
            {
                estimateDefSet.SectionCode = this.SectionCode_tComboEditor.Value.ToString();        // ���_�R�[�h
            }
            else
            {
                estimateDefSet.SectionCode = "";
            }
               --- DEL 2008/06/04 --------------------------------<<<<< */

            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSet.FractionProcCd       = (int)this.FractionProcCd_tComboEditor.Value;      // �[�������敪
            //estimateDefSet.ConsTaxLayMethod     = (int)this.ConsTaxLayMethod_tComboEditor.Value;    // ����œ]�ŕ���
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            estimateDefSet.ListPricePrintDiv    = (int)this.ListPricePrintDiv_tComboEditor.Value;   // �艿����敪
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSet.EraNameDispCd1       = (int)this.EraNameDispCd1_tComboEditor.Value;      // �����\���敪�P
            //estimateDefSet.EstimateTotalPrtCd   = (int)this.EstimateTotalPrtCd_tComboEditor.Value;  // ���ύ��v����敪
            //estimateDefSet.EstimateFormPrtCd    = (int)this.EstimateFormPrtCd_tComboEditor.Value;   // ���Ϗ�����敪
            //estimateDefSet.HonorificTitlePrtCd  = (int)this.HonorificTitlePrtCd_tComboEditor.Value; // �h�̈���敪
            //estimateDefSet.EstimateRequestCd    = (int)this.EstimateRequestCd_tComboEditor.Value;   // ���ψ˗��敪
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            estimateDefSet.EstmFormNoPickDiv    = (int)this.EstmFormNoPickDiv_tComboEditor.Value;   // ���Ϗ��ԍ��̔ԋ敪
            estimateDefSet.EstimateTitle1       = this.EstimateTitle1_tEdit.DataText;               // ���σ^�C�g���P
            estimateDefSet.EstimateNote1        = this.EstimateNote1_tEdit.DataText;                // ���ϔ��l�P
            estimateDefSet.EstimateNote2        = this.EstimateNote2_tEdit.DataText;                // ���ϔ��l�Q
            estimateDefSet.EstimateNote3        = this.EstimateNote3_tEdit.DataText;                // ���ϔ��l�R
            estimateDefSet.EstimatePrtDiv       = (int)this.EstimatePrtDiv_tComboEditor.Value;      // ���Ϗ����s�敪
            // 2008.03.14 �폜 >>>>>>>>>>>>>>>>>>>>
            //estimateDefSet.EstimateReqPrtDiv    = (int)this.EstimateReqPrtDiv_tComboEditor.Value;   // ���ψ˗������s�敪
            //estimateDefSet.EstimateConfPrtDiv   = (int)this.EstimateConfPrtDiv_tComboEditor.Value;  // ���ϊm�F�����s�敪
            // 2008.03.14 �폜 <<<<<<<<<<<<<<<<<<<<
            estimateDefSet.ConsTaxPrintDiv      = (int)this.ConsTaxPrintDiv_tComboEditor.Value;     // ����ň���敪

            // --- ADD 2008/06/04 -------------------------------->>>>>
            estimateDefSet.FaxEstimatetDiv      = (int)this.FaxEstimatetDiv_tComboEditor.Value;     // �e�`�w���ϋ敪

            estimateDefSet.SectionCode          = this.tEdit_SectionCodeAllowZero2.DataText;         // ���_�R�[�h
            // ADD 2008/09/26 �s��Ή�[5659] ---------->>>>>
            // uiSetControl��""�̂Ƃ�"00"��ݒ肷��̂ŁA�f�t�H���g�l��"00"�Ƃ���
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                estimateDefSet.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/26 �s��Ή�[5659] ----------<<<<<

            estimateDefSet.PartsNoPrtCd         = (int)this.PartsNoPrtCd_tComboEditor.Value;        // �i�Ԉ󎚋敪
            estimateDefSet.OptionPringDivCd     = (int)this.OptionPringDivCd_tComboEditor.Value;    // �I�v�V�����󎚋敪
            estimateDefSet.PartsSelectDivCd     = (int)this.PartsSelectDivCd_tComboEditor.Value;    // ���i�I���敪
            estimateDefSet.PartsSearchDivCd     = (int)this.PartsSearchDivCd_tComboEditor.Value;    // ���i�����敪
            estimateDefSet.EstimateDtCreateDiv  = (int)this.EstimateDtCreateDiv_tComboEditor.Value; // ���σf�[�^�쐬�敪
            estimateDefSet.EstimateValidityTerm = Int32.Parse(this.EstimateValidityTerm_tEdit.Value.ToString()); // ���Ϗ��L������
            estimateDefSet.RateUseCode          = (int)this.RateUseCode_tComboEditor.Value;         // �|���g�p�敪
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

        /// <summary>
        /// ���Ϗ����l�ݒ�ۑ�����
		/// </summary>
		/// <returns>����</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�̕ۑ����s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
                    "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
					message, 							// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.OK );				// �\������{�^��
                // --- DEL 2011/09/07 -------------------------------->>>>>
                //control.Focus();
                //if( control is TNedit ) {
                //    ( ( TNedit )control ).SelectAll();
                //}
                //else if( control is TEdit ) {
                //    ( ( TEdit )control ).SelectAll();
                //}
                // --- DEL 2011/09/07 --------------------------------<<<<<
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
				return result;
			}
            // ----- ADD 2011/09/07 ---------->>>>>
            // ���_
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<


            EstimateDefSet estimateDefSet = null;
			if( this._dataIndex >= 0 ) {
				Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
                estimateDefSet = ((EstimateDefSet)this._estimateDefSetTable[guid]).Clone();
			}
			DispToEstimateDefSet( ref estimateDefSet );

            int status = this._estimateDefSetAcs.Write(ref estimateDefSet);
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    // VIEW�̃f�[�^�Z�b�g���X�V
					EstimateDefSetToDataSet( estimateDefSet.Clone(), this._dataIndex );
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// �R�[�h�d��
					TMsgDisp.Show( 
						this, 									// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                        "DCMIT09010U", 							// �A�Z���u���h�c�܂��̓N���X�h�c
						"���̃R�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
						0, 										// �X�e�[�^�X�l
						MessageBoxButtons.OK );					// �\������{�^��
                    //this.SectionCode_tComboEditor.Focus();  // DEL 2008/06/04
                    tEdit_SectionCodeAllowZero2.Focus();                  // ADD 2008/06/04
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
                        "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "���ϑS�̐ݒ�", 					// �v���O��������
						"SaveProc", 						// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
                        this._estimateDefSetAcs,			// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

            /* --- DEL 2008/06/04 -------------------------------->>>>>
			// ���_�R�[�h
            if (this.SectionCode_tComboEditor.Value == null)
            {
                message = this.SectionCode_Title_Label.Text + "��ݒ肵�ĉ������B";
                control = this.SectionCode_tComboEditor;
                result = false;
            }
               --- DEL 2008/06/04 --------------------------------<<<<< */

            // --- ADD 2008/06/04 -------------------------------->>>>>
            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.SectionCode_Title_Label.Text + "��ݒ肵�ĉ������B";
                control = this.tEdit_SectionCodeAllowZero2;
                result = false;
                return result; // ADD 2011/09/07
            }
            // --- ADD 2008/06/04 --------------------------------<<<<< 

            // --- ADD 2008/09/16 -------------------------------->>>>>
            // ���_�R�[�h�̑��݃`�F�b�N
            bool existCheck = false;
            // --- ADD 2011/09/07 -------------------------------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.DataText != "")
                this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');
            // --- ADD 2011/09/07 --------------------------------<<<<<

            // ADD 2008/09/26 �s��Ή�[5659]---------->>>>>
            // �S�Ћ��ʂ͋��_�}�X�^�ɓo�^����Ă��Ȃ����߁A�`�F�b�N�̑ΏۊO
            if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText))
            {
                foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                {
                    if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText)
                    {
                        existCheck = true;
                        break;
                    }
                }
            }
            else
            {
                existCheck = true;
            }
            // ADD 2008/09/26 �s��Ή�[5659]----------<<<<<
            // DEL 2008/09/26 �s��Ή�[5659] ---------->>>>>
            //foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            //{
            //    if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero.DataText)
            //    {
            //        existCheck = true;
            //        break;
            //    }
            //}
            // DEL 2008/09/26 �s��Ή�[5659] ----------<<<<<
            if (existCheck)
            {
                result = true;
            }
            else
            {
                message = "�w�肵�����_�R�[�h�͑��݂��܂���B";

                control = this.tEdit_SectionCodeAllowZero2;

                result = false;
            }
            // --- ADD 2008/09/16 --------------------------------<<<<<

            return result;
		}

		/// <summary>
        /// ���Ϗ����l�ݒ�I�u�W�F�N�g�_���폜����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�I�u�W�F�N�g�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int LogicalDelete()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// ���擾
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
            EstimateDefSet estimateDefSet = ((EstimateDefSet)this._estimateDefSetTable[guid]).Clone();

            // ���Ϗ����l�ݒ肪���݂��Ă��Ȃ�
			if( estimateDefSet == null ) {
				return -1;
			}

            // --- ADD 2008/09/16 -------------------------------->>>>>
            // �S�Ёi���_�R�[�h��"00"�j�̏ꍇ�A�폜�s�ɂ���B
            if (estimateDefSet.SectionCode.TrimEnd() == "00")
            {
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    "�S�Ћ��ʐݒ�͍폜�o���܂���B", 	// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��

                return -1;
            }
            // --- ADD 2008/09/16 --------------------------------<<<<<

            status = this._estimateDefSetAcs.LogicalDelete(ref estimateDefSet);
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					EstimateDefSetToDataSet( estimateDefSet.Clone(), this._dataIndex );
					break;
				}
				// �r������
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, false );
					return status;
				}
				default:
				{
						// �_���폜
						TMsgDisp.Show( 
							this, 								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ϑS�̐ݒ�", 					// �v���O��������
							"LogicalDelete", 					// ��������
							TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
							"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
							status, 							// �X�e�[�^�X�l
                            this._estimateDefSetAcs,			// �G���[�����������I�u�W�F�N�g
							MessageBoxButtons.OK, 				// �\������{�^��
							MessageBoxDefaultButton.Button1 );	// �����\���{�^��

					return status;
				}
			}
			return status;
		}

		/// <summary>
        /// ���Ϗ����l�ݒ�I�u�W�F�N�g�_���폜��������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�I�u�W�F�N�g�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int Revival()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// ���擾
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
            EstimateDefSet estimateDefSet = ((EstimateDefSet)this._estimateDefSetTable[guid]).Clone();

            // ���Ϗ����l�ݒ肪���݂��Ă��Ȃ�
			if( estimateDefSet == null ) {
				return -1;
			}

            status = this._estimateDefSetAcs.Revival(ref estimateDefSet);
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					EstimateDefSetToDataSet( estimateDefSet.Clone(), this._dataIndex );
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
                        "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "���ϑS�̐ݒ�", 					// �v���O��������
						"Revival", 							// ��������
						TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
						"�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
                        this._estimateDefSetAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					CloseForm( DialogResult.Cancel );
					return status;
				}
			}
			return status;
		}

		/// <summary>
        /// ���Ϗ����l�ݒ�I�u�W�F�N�g���S�폜����
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ϗ����l�ݒ�u�W�F�N�g�̊��S�폜���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private int PhysicalDelete()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// ���擾
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
            EstimateDefSet estimateDefSet = (EstimateDefSet)this._estimateDefSetTable[guid];

            // ���Ϗ����l�ݒ肪���݂��Ă��Ȃ�
			if( estimateDefSet == null ) {
				return -1;
			}

            // ADD 2008/09/26 �s��Ή�[5259] ---------->>>>>
            // ���_�R�[�h���S�Ћ��ʂ̏ꍇ�A�폜�s��
            if (IsAllSection(estimateDefSet))
            {
                TMsgDisp.Show(
                    this, 							                        // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // �G���[���x��
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text, 				                                // �v���O��������
                    MethodBase.GetCurrentMethod().Name,                     // ��������
                    TMsgDisp.OPE_DELETE, 				                    // TODO:�I�y���[�V����
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // �\�����郁�b�Z�[�W
                    status, 						                        // �X�e�[�^�X�l
                    this,			                                        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 			                        // �\������{�^��
                    MessageBoxDefaultButton.Button1                         // �����\���{�^��
                );
                return status;
            }
            // ADD 2008/09/26 �s��Ή�[5259] ----------<<<<<

            status = this._estimateDefSetAcs.Delete(estimateDefSet);
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    // �n�b�V���e�[�u������f�[�^���폜
					this._estimateDefSetTable.Remove( ( Guid )this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex][ GUID_TITLE ] );
					// �f�[�^�Z�b�g����f�[�^���폜
					this.Bind_DataSet.Tables[ ESTIMATEDEFSET_TABLE ].Rows[ this._dataIndex].Delete();
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
                        "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        "���ϑS�̐ݒ�", 					// �v���O��������
						"PhysicalDelete", 					// ��������
						TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
						"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
                        this._estimateDefSetAcs,			// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
					CloseForm( DialogResult.Cancel );
					return status;
				}
			}
			return status;
		}

        // ADD 2008/09/26 �s��Ή�[5659] ---------->>>>>
        /// <summary>
        /// �S�Ћ��ʂ����肵�܂��B
        /// </summary>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�</param>
        /// <returns><c>true</c> :�S�Ћ��ʂł���B<br/><c>false</c>:�S�Ћ��ʂł͂Ȃ��B</returns>
        /// <remarks>
        /// <br>Note       : �s��Ή�[5659]�ɂĒǉ�</br>
        /// <br>Programmer : 30434 �H�� �b�D</br>
        /// <br>Date       : 2008/09/26</br>
        /// </remarks>
        private static bool IsAllSection(EstimateDefSet estimateDefSet)
        {
            return SectionUtil.IsAllSection(estimateDefSet.SectionCode);
        }
        // ADD 2008/09/26 �s��Ή�[5659] ----------<<<<<

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
		/// <remarks>
		/// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
                        "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
                        "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();

            try
            {
                foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        #endregion

		#region Control Events
		/// <summary>
        /// Form.Load �C�x���g(DCMIT09010UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���[�U���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void DCMIT09010UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList							= imageList24;
			this.Cancel_Button.ImageList						= imageList24;
			this.Revive_Button.ImageList						= imageList24;
			this.Delete_Button.ImageList						= imageList24;
            // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

            this.Ok_Button.Appearance.Image						= Size24_Index.SAVE;	// �ۑ��{�^��
			this.Cancel_Button.Appearance.Image					= Size24_Index.CLOSE;	// ����{�^��
			this.Revive_Button.Appearance.Image					= Size24_Index.REVIVAL;	// �����{�^��
			this.Delete_Button.Appearance.Image					= Size24_Index.DELETE;	// ���S�폜�{�^��
            // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/19 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1]; // ADD 2008/06/04

            // ��ʂ��\�z
			ScreenInitialSetting();

            // ���_�K�C�h�̃t�H�[�J�X����̊J�n
            SectionGuideController.StartControl();  // ADD 2008/09/26 �s��Ή�[5659]
		}

		/// <summary>
        /// Form.Closing �C�x���g(DCMIT09010UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void DCMIT09010UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        /// Form.VisibleChanged �C�x���g(DCMIT09010UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void DCMIT09010UA_VisibleChanged(object sender, System.EventArgs e)
		{
			if( this.Visible == false ) {
				this.Owner.Activate();
				return;
			}

			// _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			// �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ������ꍇ�ȉ��̏������L�����Z������
			if( this._indexBuf == this._dataIndex ) {
				return;
			}

            // ������h�~�̈�
            this.Enabled = false;

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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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

                EstimateDefSet newEstimateDefSet = new EstimateDefSet();

                // �u���Ϗ��L�������v�����l�ݒ�
                newEstimateDefSet.EstimateValidityTerm = 1;  // ADD 2008/06/04

                // ���Ϗ����l�ݒ�I�u�W�F�N�g����ʂɓW�J
				EstimateDefSetToScreen( newEstimateDefSet );

                // �N���[���쐬
				this._estimateDefSetClone = newEstimateDefSet.Clone();
				DispToEstimateDefSet( ref this._estimateDefSetClone );

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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if( this.Mode_Label.Text != DELETE_MODE ) {
				// ���݂̉�ʏ����擾����
                EstimateDefSet compareEstimateDefSet = new EstimateDefSet();
				compareEstimateDefSet = this._estimateDefSetClone.Clone();
				DispToEstimateDefSet( ref compareEstimateDefSet );

				// �ŏ��Ɏ擾������ʏ��Ɣ�r
				if ( !( this._estimateDefSetClone.Equals( compareEstimateDefSet ) ))
                {
					// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					// �ۑ��m�F
					DialogResult res = TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                        "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
							// 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tEdit_SectionCodeAllowZero2.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
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
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date       : 2007.09.27</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// ���S�폜�m�F
			DialogResult result = TMsgDisp.Show( 
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                "DCMIT09010U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
        /// ���_�R�[�h�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�\������</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status != 0)
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/09 �s��Ή�[6226]
                    return;
                }

                // �擾�f�[�^�\��
                this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                // �t�H�[�J�X�����Ϗ����s�敪�ɕύX
                this.EstimatePrtDiv_tComboEditor.Focus(); //ADD 2008/09/08

                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                // �V�K���[�h���烂�[�h�ύX�Ή�
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        SectionGd_ultraButton.Tag = GeneralGuideUIController.CAN_FOCUS;
                        SectionGd_ultraButton.Focus();
                        return;
                    }
                }
                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- DEL 2008/09/22 -------------------------------->>>>>
        ///// <summary>
        ///// ���_�R�[�hEdit Leave����
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note       : ���_���̕\������</br>
        ///// <br>Programmer : 30415 �ēc �ύK</br>
        ///// <br>Date       : 2008/06/04</br>
        ///// </remarks>
        //private void tEdit_SectionCode_Leave(object sender, EventArgs e)
        //{
        //    // ���_�R�[�h���͂���H
        //    if (this.tEdit_SectionCodeAllowZero.Text != "")
        //    {
        //        // ���_�R�[�h���̐ݒ�
        //        this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero.Text.Trim());
        //    }
        //    else
        //    {
        //        // ���_�R�[�h���̃N���A
        //        this.SectionNm_tEdit.Text = "";
        //    }
        //}
        // --- DEL 2008/09/22 -------------------------------->>>>>

        // --- ADD 2008/09/16 -------------------------------->>>>>
        /// <summary>
        /// ���^�[���L�[�ړ��C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���^�[���L�[�������̐�����s���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            if (e.PrevCtrl.Name == "tEdit_SectionCodeAllowZero2")
            {
                // --- ADD 2008/09/22 -------------------------------->>>>>
                // ���͂��Ȃ��ꍇ�ƑS�Ђ̏ꍇ�͏������Ȃ�
                if (tEdit_SectionCodeAllowZero2.Text != "" &&
                    tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0') != "00")
                {
                    SecInfoSet secInfoSet;
                    int status = this._secInfoAcs.GetSecInfo(this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0').PadRight(6), out secInfoSet);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.TrimEnd();
                        this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

                        //// ���݂���ꍇ�͌��Ϗ����s�敪�Ƀt�H�[�J�X��ύX
                        //e.NextCtrl = this.EstimatePrtDiv_tComboEditor;
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // ���݂���ꍇ�͌��Ϗ����s�敪�Ƀt�H�[�J�X��ύX
                                e.NextCtrl = this.EstimatePrtDiv_tComboEditor;
                            }
                        }
                    }
                    else
                    {
                        this.tEdit_SectionCodeAllowZero2.DataText = this.tEdit_SectionCodeAllowZero2.DataText.PadLeft(2, '0');// ADD 2011/09/07
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "�w�肵�����_�R�[�h�͑��݂��܂���B",
                            -1,
                            MessageBoxButtons.OK);

                        // ���݂̓��͂��N���A
                        this.tEdit_SectionCodeAllowZero2.DataText = "";
                        this.SectionNm_tEdit.DataText = "";

                        // ���݂��Ȃ��ꍇ�̓K�C�h�{�^���փt�H�[�J�X��ύX
                        //e.NextCtrl = this.SectionGd_ultraButton; // DEL 2011/09/07
                        e.NextCtrl = this.tEdit_SectionCodeAllowZero2; // ADD 2011/09/07
                    }
                }
                // ADD 2008/09/26 �s��Ή�[5825]---------->>>>>
                else
                {
                    // uiSetControl��"00"�ɕ␳����̂ŁA���_���̂͑S�Ћ��ʂ�ݒ�
                    //this.SectionNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME; // DEL 2011/09/07
                    // --- ADD 2011/09/07 -------------------------------->>>>>
                    if (this.tEdit_SectionCodeAllowZero2.DataText == "0")
                    {
                        this.tEdit_SectionCodeAllowZero2.DataText = "00";
                    }
                    if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
                    {
                        this.SectionNm_tEdit.Text = SectionUtil.ALL_SECTION_NAME;
                    }
                    // --- ADD 2011/09/07 --------------------------------<<<<<
                }
                // ADD 2008/09/26 �s��Ή�[5825]----------<<<<<
                // --- ADD 2008/09/22 --------------------------------<<<<<

                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                // ADD 2009/04/07 ------>>>
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // �ŐV���{�^���͍X�V�`�F�b�N����O��
                    ;
                }
                // ADD 2009/04/07 ------<<<
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            }
            // ADD 2009/04/07 ------>>>
            else if (e.PrevCtrl.Name == "Renewal_Button")
            {
                // �ŐV���{�^������̑J�ڎ��A�X�V�`�F�b�N��ǉ�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero2")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            // ADD 2009/04/07 ------<<<
                
            return;
        }
        // --- ADD 2008/09/16 --------------------------------<<<<<
        #endregion

        private void ultraLabel2_Click(object sender, EventArgs e)
        {

        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "DCMIT09010U",						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            isError = false;
            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionNm_tEdit.Clear();
                return false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "���͂��ꂽ�R�[�h�̌��ϑS�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[ESTIMATEDEFSET_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "DCMIT09010U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̌��ϑS�̐ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        isError = true; // ADD 2011/09/07
                        // ���_�R�[�h�A���̂̃N���A
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h�̌��ϑS�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        "DCMIT09010U",                          // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    isError = true; // ADD 2011/09/07
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
                                // ���_�R�[�h�A���̂̃N���A
                                tEdit_SectionCodeAllowZero2.Clear();
                                SectionNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}
