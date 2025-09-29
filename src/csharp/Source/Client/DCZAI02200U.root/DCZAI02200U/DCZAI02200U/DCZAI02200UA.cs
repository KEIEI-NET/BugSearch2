//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌ɓ��o�Ɋm�F�\
// �v���O�����T�v   : �݌ɓ��o�Ɋm�F�\UI�t�H�[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��؁@���b
// �� �� ��  2007/09/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/07  �C�����e : �s��Ή�[12997]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : yangmj
// �C �� ��  2010/11/15  �C�����e : �@�\���ǂp�S
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;

using Broadleaf.Application.Controller.Util; // ADD 2010/11/15
namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌ɓ��o�Ɋm�F�\UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɓ��o�Ɋm�F�\UI�t�H�[���N���X</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br>UpdateNote : 2009/04/07 �Ɠc �M�u�@�s��Ή�[12997]</br>
    /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
    /// </remarks>
	public partial class DCZAI02200UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
	{
		#region �� Constructor
		/// <summary>
		/// �݌Ɏ󕥊m�F�\UI�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌Ɏ󕥊m�F�\UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// <br></br>
		/// </remarks>
		public DCZAI02200UA ()
		{
			InitializeComponent();

			// ��ƃR�[�h�擾
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// ���_�p��Hashtable�쐬
			this._selectedSectionList	= new Hashtable();

            // ���t�擾���i
            _dateGetAcs = DateGetAcs.GetInstance();

            // �K�C�h�㎟�t�H�[�J�X����
            SettingGuideNextFocusControl();
		}
        /// <summary>
        /// �K�C�h�㎟�t�H�[�J�X����
        /// </summary>
        private void SettingGuideNextFocusControl()
        {
            _guideNextFocusControl = new GuideNextFocusControl();

            _guideNextFocusControl.AddRange( new Control[] { tEdit_WarehouseCode_St, tEdit_WarehouseCode_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tNedit_GoodsMakerCd_St, tNedit_GoodsMakerCd_Ed } );
            _guideNextFocusControl.AddRange( new Control[] { tEdit_GoodsNo_St, tEdit_GoodsNo_Ed } );
        }
		#endregion �� Constructor

		#region �� Private Member
		#region �� Interface member
		//--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract				= false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf					= true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint					= true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton		= false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton			= true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton		= true;

        //--IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ� -------------------
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd		= false;
        // ���_�I�v�V�����L��
        private bool _isOptSection				= false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc			= false;
		// �I�����_���X�g
        private Hashtable _selectedSectionList	= new Hashtable();
		#endregion �� Interface member

		// ��ƃR�[�h
		private string _enterpriseCode = "";
		// ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// ���o�����N���X
		private StockAcPayListCndtn _stockAcPayListCndtn;

        //// ���_�K�C�h�p
        //SecInfoSetAcs _secInfoSetAcs;

        // �q�ɃK�C�h�p
        private WarehouseAcs _wareHouseAcs;

        //// �d����K�C�h�p
        //private UltraButton _customerGuideSender;
        //private SFTOK01370UA _customerGuid;

        // ���i�R�[�h�p
        private MAKHN04110UA _goodsGuid = new MAKHN04110UA();
        //private GoodsAcs _goodsAcs;

        // ���[�J�[�K�C�h�p
        private MakerAcs _makerAcs;

        //// �S���҃K�C�h�p
        //EmployeeAcs _employeeAcs;

        //// �݌Ɍ���(���Е��ރK�C�h�p)
        //SearchStockAcs _searchStockAcs;

        // �K�C�h�㎟�t�H�[�J�X����
        private GuideNextFocusControl _guideNextFocusControl;

        // ���t�擾���i
        private DateGetAcs _dateGetAcs;

		#endregion �� Private Member

		#region �� Private Const
		#region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "DCZAI02200UA";
        // �v���O����ID
        private const string ct_PGID = "DCZAI02200U";
        //// ���[����
        private string _printName = "�݌ɓ��o�Ɋm�F�\"; // MOD 2008/09/25 �s��Ή�[5542] "�݌Ɏ󕥊m�F�\"��"�݌ɓ��o�Ɋm�F�\"
        // ���[�L�[	
        private string _printKey = "da797c1f-b718-4fa4-8dec-cd4977b7792a";
        #endregion �� Interface member

		// ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// �o�͏���
        private const string ct_ExBarGroupNm_ReportSortGroup = "ReportSortGroup";           // �\�[�g����
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����

        //--- ADD 2008/07/02 ---------->>>>>
        // ����
        private const string ct_Section = "���_";
        private const string ct_Warehouse = "�q��";
        private const string ct_Nothing = "���Ȃ�";

        // �q�ɃR�[�h
        private const string ct_WarehouseCode_Max = "9999";
        private const string ct_WarehouseCode_Min = "0";
        // ���[�J�[�R�[�h
        private const string ct_MakerCode_Max = "9999";
        private const string ct_MakerCode_Min = "0";
        //--- ADD 2008/07/02 ----------<<<<<

        // ---ADD 2010/11/15 ------------------------>>>>>
        private const string ct_Group_0 = "���Ȃ�";
        private const string ct_Group_1 = "����";

        private const string ct_SlipKuben_0 = "�S��";
        private const string ct_SlipKuben_10 = "�d��";
        private const string ct_SlipKuben_20 = "����";
        private const string ct_SlipKuben_30 = "�ړ��o��";
        private const string ct_SlipKuben_31 = "�ړ�����";
        private const string ct_SlipKuben_11 = "����";
        private const string ct_SlipKuben_22 = "�ݏo";
        private const string ct_SlipKuben_13 = "�݌Ɏd��";
        private const string ct_SlipKuben_42 = "�}�X�^�����e";
        private const string ct_SlipKuben_50 = "�I��";
        private const string ct_SlipKuben_60 = "�g��";
        private const string ct_SlipKuben_61 = "����";
        private const string ct_SlipKuben_70 = "��[����";
        private const string ct_SlipKuben_71 = "��[�o��";
        // ---ADD 2010/11/15 ------------------------<<<<<
        #endregion

		#region �� IPrintConditionInpType �����o
		#region �� Public Event
		/// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		#endregion �� Public Event

		#region �� Public Property
		/// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
		public bool CanExtract
		{
			get { return this._canExtract; }
		}

		/// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
		public bool CanPdf
		{
			get { return this._canPdf; }
		}

		/// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
		public bool CanPrint
		{
			get { return this._canPrint; }
		}

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
		public bool VisibledExtractButton
		{
			get { return this._visibledExtractButton; }
		}

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
		public bool VisibledPdfButton
		{
			get { return this._visibledPdfButton; }
		}

        /// <summary> ����{�^���\���v���p�e�B </summary>
		public bool VisibledPrintButton
		{
			get { return this._visibledPrintButton; }
		}

		#endregion �� Public Property

		#region �� Public Method
		#region �� ���o����
		/// <summary>
        /// ���o����
        /// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>0( �Œ� )</returns>
		public int Extract ( ref object parameter )
		{
            // ���o�����͖����̂ŏ����I��
            return 0;
		}
		#endregion

		#region �� �������
		/// <summary>
		/// �������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
			SFCMN06001U printDialog	= new SFCMN06001U();		// ���[�I���K�C�h
			SFCMN06002C printInfo	= parameter as SFCMN06002C;	// ������p�����[�^

			// ��ƃR�[�h���Z�b�g
			printInfo.enterpriseCode	= this._enterpriseCode;
			printInfo.kidopgid			= ct_PGID;				// �N��PGID

			// PDF�o�͗���p
			printInfo.key				= this._printKey;
			printInfo.prpnm				= this._printName;

			printInfo.PrintPaperSetCd	= 0;
			// ��ʁ����o�����N���X
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// ���o�����̐ݒ�
			printInfo.jyoken			= this._stockAcPayListCndtn;
			printDialog.PrintInfo		= printInfo;
			
			// ���[�I���K�C�h
			DialogResult dialogResult = printDialog.ShowDialog();

			if( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN ) {
				MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0 );
			}

			 parameter = printInfo;

			return printInfo.status;
		}
		#endregion

		#region �� ����O�m�F����
		/// <summary>
		/// ����O�m�F����
		/// </summary>
		/// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public bool PrintBeforeCheck ()
		{
			bool status = true;

			string errMessage = "";
			Control errComponent = null;

			if( !this.ScreenInputCheck( ref errMessage, ref errComponent ) )
			{
				// ���b�Z�[�W��\��
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

				// �R���g���[���Ƀt�H�[�J�X���Z�b�g
				if( errComponent != null ) {
					errComponent.Focus();
				}

				status = false;
			}

			return status;
		}
		#endregion

		#region �� ��ʕ\������
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void Show ( object parameter )
		{
            this._stockAcPayListCndtn = new StockAcPayListCndtn();

            this.Show();
			return;
		}
		#endregion

		#endregion �� Public Method
		#endregion �� IPrintConditionInpType �����o

		#region �� IPrintConditionInpTypeSelectedSection �����o
		#region �� Public Property

        /// <summary> �{�Ћ@�\�v���p�e�B </summary>
		public bool IsMainOfficeFunc
		{
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
		}

        /// <summary> ���_�I�v�V�����v���p�e�B </summary>
		public bool IsOptSection
		{
            get { return _isOptSection; }
            set { _isOptSection = value; }
		}

        /// <summary> �v�㋒�_�I��\���擾�v���p�e�B </summary>
		public bool VisibledSelectAddUpCd
		{
            get { return _visibledSelectAddUpCd; }
		}

		#endregion �� Public Property

		#region �� Public Method

		#region �� ���_�I������
		/// <summary>
		/// ���_�I������
		/// </summary>
		/// <param name="sectionCode">�I�����_�R�[�h</param>
		/// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void CheckedSection ( string sectionCode, CheckState checkState )
		{
            // ���_��I��������
            if ( checkState == CheckState.Checked )
            {
                // �S�Ђ��I�����ꂽ�ꍇ
                if ( sectionCode == "0" )
                {
                    this._selectedSectionList.Clear();
                }

                if ( !this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Add( sectionCode, sectionCode );
                }
            }
            // ���_�I��������������
            else if ( checkState == CheckState.Unchecked )
            {
                if ( this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Remove( sectionCode );
                }
            }
		}
		#endregion

		#region �� �����I���v�㋒�_�ݒ菈��( ������ )
		/// <summary>
		/// �����I���v�㋒�_�ݒ菈��( ������ )
		/// </summary>
		/// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void InitSelectAddUpCd ( int addUpCd )
		{
			// �v�㋒�_�I�����Ȃ��̂Ŗ�����
		}
		#endregion

		#region �� �����I�����_�ݒ菈��
		/// <summary>
		/// �����I�����_�ݒ菈��
		/// </summary>
		/// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void InitSelectSection ( string[] sectionCodeLst )
		{
            // �I�����X�g������
            this._selectedSectionList.Clear();
            foreach ( string wk in sectionCodeLst )
            {
                this._selectedSectionList.Add( wk, wk );
            }
		}
		#endregion

		#region �� �������_�I��\���`�F�b�N����
        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">true�F�X���C�_�[�\���@false�F�X���C�_�[��\��</param>
        /// <remarks>
        /// <br>Note		: ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
        /// <br>			: ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public bool InitVisibleCheckSection ( bool isDefaultState )
		{
            //return isDefaultState;            //DEL 2009/04/07 �s��Ή�[12997]
            return false;                       //ADD 2009/04/07 �s��Ή�[12997]
        }
		#endregion

		#region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		public void SelectedAddUpCd (int addUpCd )
		{
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
		}
		#endregion

		#endregion �� Public Method
		#endregion �� IPrintConditionInpTypeSelectedSection �����o

		#region �� IPrintConditionInpTypePdfCareer �����o
		#region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
		public string PrintKey
		{
            get { return this._printKey; }
		}

        /// <summary> ���[���v���p�e�B </summary>
		public string PrintName
		{
            get { return this._printName; }
		}

		#endregion �� Public Method
		#endregion �� IPrintConditionInpTypePdfCareer �����o

		#region �� Private Method
		#region �� ��ʏ������֌W
		#region �� ��ʏ���������
		/// <summary>
		/// ��ʏ���������
		/// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // �����l�Z�b�g�E���t
                this.tde_St_IoGoodsDay.SetDateTime( DateTime.Today ); // �V�X�e�����t
                this.tde_Ed_IoGoodsDay.SetDateTime( DateTime.Today ); // �V�X�e�����t

                // �����l�Z�b�g�E������
                this.tEdit_WarehouseCode_St.DataText = string.Empty;
                this.tEdit_WarehouseCode_Ed.DataText = string.Empty;
                this.tEdit_GoodsNo_St.DataText = string.Empty;
                this.tEdit_GoodsNo_Ed.DataText = string.Empty;
                //--- ADD 2008/07/02 ---------->>>>>
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                //--- ADD 2008/07/02 ----------<<<<<

                // �����l�Z�b�g�E���l
                //--- DEL 2008/07/02 ---------->>>>>
                //this.tne_St_GoodsMakerCd.SetInt(0);
                //this.tne_Ed_GoodsMakerCd.SetInt( 0 );
                //--- DEL 2008/07/02 ----------<<<<<
                //this.tne_Ed_GoodsMakerCd.SetInt( Int32.Parse( new string( '9', this.tne_Ed_GoodsMakerCd.ExtEdit.Column ) ) );

                // �{�^���ݒ�
                // DEL 2008/09/25 �s��Ή�[5603] ---------->>>>>
                //this.SetIconImage( this.ub_St_GoodsGuid, Size16_Index.STAR1 );
                //this.SetIconImage( this.ub_Ed_GoodsGuid, Size16_Index.STAR1 );
                // DEL 2008/09/25 �s��Ή�[5603] ----------<<<<<
                this.SetIconImage( this.ub_St_GoodsMakerGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_GoodsMakerGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_St_WarehouseGuid, Size16_Index.STAR1 );
                this.SetIconImage( this.ub_Ed_WarehouseGuid, Size16_Index.STAR1 );

                /* ---DEL 2009/04/07 �s��Ή�[12997] ------------------------>>>>>
                //--- ADD 2008/07/02 ---------->>>>>
                // ���ŃA�C�e���ǉ�
                tComboEditor1.Items.Add(0, ct_Section);
                tComboEditor1.Items.Add(0, ct_Warehouse);
                tComboEditor1.Items.Add(0, ct_Nothing);
                tComboEditor1.SelectedIndex = 0;
                //--- ADD 2008/07/02 ----------<<<<<
                   ---DEL 2009/04/07 �s��Ή�[12997] ------------------------<<<<< */
                // ---ADD 2009/04/07 �s��Ή�[12997] ------------------------>>>>>
                // ���ŃA�C�e���ǉ�
                tComboEditor1.Items.Add(1, ct_Warehouse);
                tComboEditor1.Items.Add(2, ct_Nothing);
                tComboEditor1.SelectedIndex = 0;
                // ---ADD 2009/04/07 �s��Ή�[12997] ------------------------<<<<<

                // ---ADD 2010/11/15 ------------------------>>>>>
                // ���v�󎚃A�C�e���ǉ�
                Group_tComboEditor.Items.Add(0, ct_Group_0);
                Group_tComboEditor.Items.Add(1, ct_Group_1);
                Group_tComboEditor.SelectedIndex = 0;
                // �`�[�敪�A�C�e���ǉ�
                SlipDiv_tComboEditor.Items.Add(0, ct_SlipKuben_0);
                SlipDiv_tComboEditor.Items.Add(10, ct_SlipKuben_10);
                SlipDiv_tComboEditor.Items.Add(20, ct_SlipKuben_20);
                SlipDiv_tComboEditor.Items.Add(30, ct_SlipKuben_30);
                SlipDiv_tComboEditor.Items.Add(31, ct_SlipKuben_31);
                SlipDiv_tComboEditor.Items.Add(11, ct_SlipKuben_11);
                SlipDiv_tComboEditor.Items.Add(22, ct_SlipKuben_22);
                SlipDiv_tComboEditor.Items.Add(13, ct_SlipKuben_13);
                SlipDiv_tComboEditor.Items.Add(42, ct_SlipKuben_42);
                SlipDiv_tComboEditor.Items.Add(50, ct_SlipKuben_50);
                SlipDiv_tComboEditor.Items.Add(60, ct_SlipKuben_60);
                SlipDiv_tComboEditor.Items.Add(61, ct_SlipKuben_61);
                SlipDiv_tComboEditor.Items.Add(70, ct_SlipKuben_70);
                SlipDiv_tComboEditor.Items.Add(71, ct_SlipKuben_71);
                SlipDiv_tComboEditor.SelectedIndex = 0;
                // �o�͏��ǉ�
                Sort_tComboEditor.SelectedIndex = 0;
                // ---ADD 2010/11/15 ------------------------<<<<<

                // �����t�H�[�J�X�Z�b�g
                this.tde_St_IoGoodsDay.Focus();
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

		#region �� �{�^���A�C�R���ݒ菈��
		/// <summary>
		/// �{�^���A�C�R���ݒ菈��
		/// </summary>
		/// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
		/// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
		private void SetIconImage ( object settingControl, Size16_Index iconIndex )
		{
			((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((UltraButton)settingControl).Appearance.Image = iconIndex;
		}
		#endregion
		#endregion �� ��ʏ������֌W

		#region �� ����O����
		#region �� ���̓`�F�b�N����
		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="errMessage">�G���[���b�Z�[�W</param>
		/// <param name="errComponent">�G���[�����R���|�[�l���g</param>
		/// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

			const string ct_InputError = "�̓��͂��s���ł�";
			const string ct_NoInput	   = "����͂��ĉ�����";
			const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            //--- DEL 2008/07/03 ---------->>>>>
            //const string ct_FullRangeError = "�͂P�����͈͓̔��œ��͂��ĉ�����";
            //--- DEL 2008/07/03 ----------<<<<<
            //--- ADD 2008/07/03 ---------->>>>>
            // ---DEL 2010/11/15 ------------------------>>>>>
            //const string ct_FullRangeError = "�͂R�����͈͓̔��œ��͂��ĉ�����";
            // ---DEL 2010/11/15 ------------------------<<<<<
            //--- ADD 2008/07/03 ----------<<<<<

            //--------------------------------------------------------------------------
            // ���o�ד�
            //--------------------------------------------------------------------------
            if ( CallCheckDateRange( out cdrResult, ref tde_St_IoGoodsDay, ref tde_Ed_IoGoodsDay ) == false )
            {
                switch ( cdrResult )
                {
                    // ---DEL 2010/11/15 ------------------------>>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        errMessage = string.Format("�J�n���o�ד�{0}", ct_NoInput);
                    //        errComponent = this.tde_St_IoGoodsDay;
                    //    }
                    //    break;
                    // ---DEL 2010/11/15 ------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format( "�J�n���o�ד�{0}", ct_InputError );
                            errComponent = this.tde_St_IoGoodsDay;
                        }
                        break;
                    // ---DEL 2010/11/15 ------------------------>>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        errMessage = string.Format("�I�����o�ד�{0}", ct_NoInput);
                    //        errComponent = this.tde_Ed_IoGoodsDay;
                    //    }
                    //    break;
                    // ---DEL 2010/11/15 ------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format( "�I�����o�ד�{0}", ct_InputError );
                            errComponent = this.tde_Ed_IoGoodsDay;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format( "���o�ד�{0}", ct_RangeError );
                            errComponent = this.tde_St_IoGoodsDay;
                        }
                        break;
                    // ---DEL 2010/11/15 ------------------------>>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        errMessage = string.Format( "���o�ד�{0}", ct_FullRangeError );
                    //        errComponent = this.tde_St_IoGoodsDay;
                    //    }
                    //    break;
                    // ---DEL 2010/11/15 ------------------------<<<<<
                }

                status = false;
            }
            // ---ADD 2010/11/15 ------------------------>>>>>
            else if (this.tde_St_IoGoodsDay.GetDateTime() == DateTime.MinValue && this.tde_Ed_IoGoodsDay.GetDateTime() != DateTime.MinValue)
            {
                errMessage = string.Format("���o�ד��J�n{0}", ct_InputError);
                errComponent = this.tde_St_IoGoodsDay;
                status = false;
            }
            else if (this.tde_St_IoGoodsDay.GetDateTime() != DateTime.MinValue && this.tde_Ed_IoGoodsDay.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("���o�ד��I��{0}", ct_InputError);
                errComponent = this.tde_Ed_IoGoodsDay;
                status = false;
            }
            // ---ADD 2010/11/15 ------------------------<<<<<
            //--------------------------------------------------------------------------
            // �q�ɃR�[�h
            //--------------------------------------------------------------------------
            else if (
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_WarehouseCode_St.DataText.TrimEnd().CompareTo( this.tEdit_WarehouseCode_Ed.DataText.TrimEnd() ) > 0) )
            {
                errMessage = string.Format("�q��{0}", ct_RangeError); // MOD 2008/10/02 �s��Ή�[6040] "�q�ɃR�[�h{0}"��"�q��{0}"
                errComponent = this.tEdit_WarehouseCode_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // ���[�J�[�R�[�h
            //--------------------------------------------------------------------------
            // (�J�n > �I�� �� NG�j
            else if ( this.tNedit_GoodsMakerCd_St.GetInt() > GetEndCode( this.tNedit_GoodsMakerCd_Ed ) )
            {
                errMessage = string.Format("���[�J�[{0}", ct_RangeError);   // MOD 2008/10/02 �s��Ή�[6040] "���[�J�[�R�[�h{0}"��"���[�J�[{0}"
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
            }
            //--------------------------------------------------------------------------
            // ���i�ԍ�
            //--------------------------------------------------------------------------
            else if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_St.DataText.TrimEnd().CompareTo( this.tEdit_GoodsNo_Ed.DataText.TrimEnd() ) > 0) )
            {
                errMessage = string.Format("�i��{0}", ct_RangeError);   // MOD 2008/10/02 �s��Ή�[6040] "���i�ԍ�{0}"��"�i��{0}"
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
            }
            // ---ADD 2010/11/15 ------------------------>>>>>
            //--------------------------------------------------------------------------
            // ���͓�
            //--------------------------------------------------------------------------
            else if (CallCheckDateRange(out cdrResult, ref detInputDay_St, ref detInputDay_Ed) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n���͓�{0}", ct_InputError);
                            errComponent = this.detInputDay_St;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I�����͓�{0}", ct_InputError);
                            errComponent = this.detInputDay_Ed;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("���͓�{0}", ct_RangeError);
                            errComponent = this.detInputDay_St;
                        }
                        break;
                }

                status = false;
            }
            else if (this.detInputDay_St.GetDateTime() == DateTime.MinValue && this.detInputDay_Ed.GetDateTime() != DateTime.MinValue)
            {
                errMessage = string.Format("���͓��J�n{0}", ct_InputError);
                errComponent = this.detInputDay_St;
                status = false;
            }
            else if (this.detInputDay_St.GetDateTime() != DateTime.MinValue && this.detInputDay_Ed.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("���͓��I��{0}", ct_InputError);
                errComponent = this.detInputDay_Ed;
                status = false;
            }
            else if (this.tde_St_IoGoodsDay.GetDateTime() == DateTime.MinValue && this.detInputDay_St.GetDateTime() == DateTime.MinValue)
            {
                errMessage = string.Format("���o�ד��܂��́A���͓�{0}", ct_NoInput);
                errComponent = this.tde_St_IoGoodsDay;
                status = false;
            }
            //--------------------------------------------------------------------------
            // �`�[�ԍ�
            //--------------------------------------------------------------------------
            else if (
              (this.tNedit_SupplierSlipNo_St.DataText.TrimEnd() != string.Empty) &&
              (this.tNedit_SupplierSlipNo_Ed.DataText.TrimEnd() != string.Empty) &&
              (this.tNedit_SupplierSlipNo_St.DataText.TrimEnd().CompareTo(this.tNedit_SupplierSlipNo_Ed.DataText.TrimEnd()) > 0))
            {
                errMessage = string.Format("�`�[�ԍ�{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierSlipNo_St;
                status = false;
            }
            // ---ADD 2010/11/15 ------------------------<<<<<

            return status;
        }
        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        /// <returns></returns>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit)
        {
            //--- DEL 2008/07/03 ---------->>>>>
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref startDateEdit, ref endDateEdit, false, false);
            //--- DEL 2008/07/03 ----------<<<<<
            // ---UPD 2010/11/15 ------------------------>>>>>
            //--- ADD 2008/07/03 ---------->>>>>
            
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref startDateEdit, ref endDateEdit, false, false);
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDateEdit, ref endDateEdit, false);

            //--- ADD 2008/07/03 ----------<<<<<
            //return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
            bool result = false;
            if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput || cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput)
            {
                result = true;
            }
            else
            {
                result = cdrResult == DateGetAcs.CheckDateRangeResult.OK;
            }
            return result;
            // ---UPD 2010/11/15 ------------------------<<<<<
        }
		#endregion

		#region �� ���t���̓`�F�b�N����
		/// <summary>
		/// ���t���̓`�F�b�N����
		/// </summary>
		/// <param name="targetDateEdit">�`�F�b�N�ΏۃR���g���[��</param>
		/// <param name="allowEmpty">�����͋���[true:����, false:�s����]</param>
		/// <returns>�`�F�b�N����(true/false)</returns>
		/// <remarks>
		/// <br>Note		: ���t���͂̃`�F�b�N���s���B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
		/// </remarks>
		private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowEmpty )
		{
			bool status = true;

			// ���͓��t�𐔒l�^�Ŏ擾
			int date = targetDateEdit.GetLongDate();
			int yy = date / 10000;
			int mm = ( date / 100 ) % 100;
			int dd = date % 100;

			// ���t�����̓`�F�b�N
            if ( targetDateEdit.GetLongDate() < 10101 && targetDateEdit.GetDateTime() == DateTime.MinValue )
			{
				if( allowEmpty == true ) 
				{
					return status;
				}
				else 
				{
					status = false;
				}
			}
			// �V�X�e���T�|�[�g�`�F�b�N
			else if( yy < 1900 )
			{
				status = false;
			}
			// �N�����ʓ��̓`�F�b�N
			else if( ( yy == 0 ) || ( mm == 0 ) || ( dd == 0 ) )
			{
				status = false;
			}
			// �P�����t�Ó����`�F�b�N
			else if( TDateTime.IsAvailableDate( targetDateEdit.GetDateTime() ) == false )
			{
				status = false;
			}

			return status;
		}
		#endregion

		#region �� ���o�����ݒ菈��(��ʁ����o����)
		/// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        /// </remarks>
        private int SetExtraInfoFromScreen( )
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                /* ---DEL 2009/04/07 �s��Ή�[12997] -------------------------->>>>>
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                // �u�S���_�v���I������Ă���ꍇ�̓��X�g���N���A
                bool allSections = false;

                foreach ( object obj in _selectedSectionList.Values )
                {
                    if ( obj is string )
                    {
                        if ( (obj as string) == "0" )
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if ( allSections )
                {
                    _selectedSectionList.Clear();
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                   ---DEL 2009/04/07 �s��Ή�[12997] --------------------------<<<<< */
                _selectedSectionList.Clear();       //ADD 2009/04/07 �s��Ή�[12997]

                // ���_�I�v�V����
                this._stockAcPayListCndtn.IsOptSection = this._isOptSection;
                // ��ƃR�[�h
                this._stockAcPayListCndtn.EnterpriseCode = this._enterpriseCode;

                // ���_�R�[�h�i�����w��j
                ArrayList sectionList = new ArrayList( this._selectedSectionList.Values );
                this._stockAcPayListCndtn.SectionCodes = (string[])sectionList.ToArray(typeof(string));

                // �L���敪
                this._stockAcPayListCndtn.ValidDivCd = 0;   // 0:�L���̂�
                // �J�n���o�ד�
                this._stockAcPayListCndtn.St_IoGoodsDay = this.tde_St_IoGoodsDay.GetDateTime();
                // �I�����o�ד�
                this._stockAcPayListCndtn.Ed_IoGoodsDay = this.tde_Ed_IoGoodsDay.GetDateTime();
                // �J�n�v����t
                this._stockAcPayListCndtn.St_AddUpADate = DateTime.MinValue; //(�\������)
                // �I���v����t
                this._stockAcPayListCndtn.Ed_AddUpADate = DateTime.MinValue; //(�\������)
                // ---DEL 2010/11/15 ------------------------>>>>>
                // �󕥌��`�[�敪
                //this._stockAcPayListCndtn.AcPaySlipCd = -1; // -1:�S��
                // ---DEL 2010/11/15 ------------------------<<<<<
                // �J�n�q�ɃR�[�h
                this._stockAcPayListCndtn.St_WarehouseCode = this.tEdit_WarehouseCode_St.Text;
                // �I���q�ɃR�[�h
                this._stockAcPayListCndtn.Ed_WarehouseCode = this.tEdit_WarehouseCode_Ed.Text;
                // �J�n���i���[�J�[�R�[�h
                this._stockAcPayListCndtn.St_GoodsMakerCd = this.tNedit_GoodsMakerCd_St.GetInt();
                // �I�����i���[�J�[�R�[�h
                this._stockAcPayListCndtn.Ed_GoodsMakerCd = GetEndCode(this.tNedit_GoodsMakerCd_Ed, 999999);

                // ---UPD 2010/11/15 ------------------------>>>>>
                //// �J�n�󕥌��`�[�ԍ�
                //this._stockAcPayListCndtn.St_AcPaySlipNum = string.Empty;
                //// �I���󕥌��`�[�ԍ�
                //this._stockAcPayListCndtn.Ed_AcPaySlipNum = string.Empty;

                this._stockAcPayListCndtn.St_AcPaySlipNum = this.tNedit_SupplierSlipNo_St.Text;
                this._stockAcPayListCndtn.Ed_AcPaySlipNum = this.tNedit_SupplierSlipNo_Ed.Text;
                // ---UPD 2010/11/15 ------------------------<<<<<

                // �J�n���i�ԍ�
                this._stockAcPayListCndtn.St_GoodsNo = this.tEdit_GoodsNo_St.Text;
                // �I�����i�ԍ�
                this._stockAcPayListCndtn.Ed_GoodsNo = this.tEdit_GoodsNo_Ed.Text;

                //--- ADD 2008/07/02 ---------->>>>>
                // ���ŏ��
                //this._stockAcPayListCndtn.ChangePage = this.tComboEditor1.SelectedIndex;                  //DEL 2009/04/07 �s��Ή�[12997]
                this._stockAcPayListCndtn.ChangePage = int.Parse(this.tComboEditor1.Value.ToString());      //ADD 2009/04/07 �s��Ή�[12997]
                //--- ADD 2008/07/02 ----------<<<<<

                // ---ADD 2010/11/15 ------------------------>>>>>
                // ���͓�
                string fromD = this.detInputDay_St.GetDateTime().ToString(DateTimeUtil.DEFAULT_DATE_TIME_FORMAT);
                string fromT = DateTimeUtil.DEFAULT_FROM_TIME;
                this._stockAcPayListCndtn.St_detInputDay = DateTime.Parse(fromD + " " + fromT);

                string toD = this.detInputDay_Ed.GetDateTime().ToString(DateTimeUtil.DEFAULT_DATE_TIME_FORMAT);
                string toT = DateTimeUtil.DEFAULT_TO_TIME;
                this._stockAcPayListCndtn.Ed_detInputDay = DateTime.Parse(toD + " " + toT);

                // ���v���
                this._stockAcPayListCndtn.GroupCnt = int.Parse(this.Group_tComboEditor.Value.ToString());

                // �o�͏�
                this._stockAcPayListCndtn.Sort = int.Parse(this.Sort_tComboEditor.Value.ToString());

                // �`�[�敪
                if (int.Parse(this.SlipDiv_tComboEditor.Value.ToString()) == 0)
                {
                    this._stockAcPayListCndtn.AcPaySlipCd = -1;
                }
                else
                {
                    this._stockAcPayListCndtn.AcPaySlipCd = int.Parse(this.SlipDiv_tComboEditor.Value.ToString());
                }
                // ---ADD 2010/11/15 ------------------------<<<<<
            }
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// </remarks>
        private int GetEndCode( TNedit tNedit )
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode( tNedit, Int32.Parse( new string( '9', (tNedit.ExtEdit.Column) ) ) );
        }
        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode( TNedit tNedit, int endCodeOnDB )
        {
            if ( tNedit.GetInt() == 0 )
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        #endregion
		#endregion �� ����O����

        # region �� �G���[���b�Z�[�W ��
        /// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2006.03.24</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
		{
			TMsgDisp.Show( 
				iLevel, 							// �G���[���x��
				ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				this._printName,					// �v���O��������
				"", 								// ��������
				"",									// �I�y���[�V����
				message,							// �\�����郁�b�Z�[�W
				status, 							// �X�e�[�^�X�l
				null, 								// �G���[�����������I�u�W�F�N�g
				MessageBoxButtons.OK, 				// �\������{�^��
				MessageBoxDefaultButton.Button1 );	// �����\���{�^��
		}
		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="procnm">�������\�b�hID</param>
		/// <param name="ex">��O���</param>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2006.03.24</br>
		/// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
				ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				this._printName,					// �v���O��������
				procnm, 							// ��������
				"",									// �I�y���[�V����
				errMessage,							// �\�����郁�b�Z�[�W
				status, 							// �X�e�[�^�X�l
				null, 								// �G���[�����������I�u�W�F�N�g
				MessageBoxButtons.OK, 				// �\������{�^��
				MessageBoxDefaultButton.Button1 );	// �����\���{�^��
        }
        # endregion �� �G���[���b�Z�[�W ��

        #endregion �� Private Method

        # region �� �R���g���[���C�x���g ��

        # region �� �t�H�[���C�x���g ��
        /// <summary>
		/// DCZAI02200UA_Load Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: 22018 ��� ���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
		private void DCZAI02200UA_Load ( object sender, EventArgs e )
		{
			string errMsg = string.Empty;

			// �R���g���[��������
			int status = this.InitializeScreen( out errMsg );
			if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}

			// ��ʃC���[�W����
			this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

			ParentToolbarSettingEvent( this );						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        # endregion �� �t�H�[���C�x���g ��

        # region �� �R���g���[���E�o�C�x���g ��
        /// <summary>
        /// ���l���ڊJ�n�E�o�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �󔒂̏ꍇ�͏����l���Z�b�g
            //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
            //    ( ( TNedit ) sender ).SetInt(0);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        /// <summary>
        /// ���l���ڏI���E�o�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_Leave ( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// �󔒂̏ꍇ�͏����l���Z�b�g
            //if ( ( ( TNedit ) sender ).DataText == string.Empty ) {
            //    string maxValueText = new string('9', ((TNedit)sender).ExtEdit.Column);
            //    ( ( TNedit ) sender ).SetInt(Int32.Parse(maxValueText));
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }
        # endregion �� �R���g���[���E�o�C�x���g ��

        # region �� �K�C�h�{�^���N���b�N�C�x���g ��
        ///// <summary>
        ///// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        //private void ub_St_CustomerGuide_Click ( object sender, EventArgs e )
        //{
        //    // �������ꂽ�{�^����ޔ�
        //    if (sender is UltraButton)
        //    {
        //        _customerGuideSender = (UltraButton)sender;
        //    }

        //    this._customerGuid = new SFTOK01370UA( SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY );
        //    this._customerGuid.CustomerSelect += new CustomerSelectEventHandler( customerSearchForm_CustomerSelect );
        //    this._customerGuid.ShowDialog(this);
        //}
        ///// <summary>
        ///// ���Ӑ�K�C�h�I���C�x���g
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="customerSearchRet"></param>
        //void customerSearchForm_CustomerSelect ( object sender, CustomerSearchRet customerSearchRet )
        //{
        //    if (customerSearchRet == null) return;

        //    if ( _customerGuideSender == this.ub_St_CustomerGuide )
        //    {
        //        this.tne_St_CustomerCode.SetInt( customerSearchRet.CustomerCode );
        //    }
        //    else
        //    {
        //        this.tne_Ed_CustomerCode.SetInt( customerSearchRet.CustomerCode );
        //    }

        //}
        ///// <summary>
        ///// �S���҃K�C�h�{�^���N���b�N�C�x���g
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_EmployeeGuide_Click ( object sender, EventArgs e )
        //{
        //    if ( this._employeeAcs == null )
        //    {
        //        this._employeeAcs = new EmployeeAcs();
        //    }

        //    Employee employee;
        //    int status = this._employeeAcs.ExecuteGuid( this._enterpriseCode, true, out employee);

        //    if ( status == 0 )
        //    {
        //        if ( sender == this.ub_St_EmployeeGuide )
        //        {
        //            this.te_St_EmployeeCode.Text = employee.EmployeeCode.TrimEnd();
        //        }
        //        else
        //        {
        //            this.te_Ed_EmployeeCode.Text = employee.EmployeeCode.TrimEnd();
        //        }
        //    }
        //}

        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_WarehouseGuid_Click ( object sender, EventArgs e )
        {
            int status = 0;
            Warehouse warehouse;
            string sectionCode = GetWarehouseGuideSection( this._selectedSectionList );

            if ( this._wareHouseAcs == null )
            {
                this._wareHouseAcs = new WarehouseAcs();
            }

            status = this._wareHouseAcs.ExecuteGuid( out warehouse, this._enterpriseCode, sectionCode );
            if ( status != 0 ) return;

            string tag = (string)( (UltraButton)sender ).Tag;
            TEdit targetControl = null;
            if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) targetControl = this.tEdit_WarehouseCode_St;
            else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) targetControl = this.tEdit_WarehouseCode_Ed;
            else return;

            // �R�[�h�W�J
            targetControl.DataText = warehouse.WarehouseCode.TrimEnd();
            // ���t�H�[�J�X
            _guideNextFocusControl.GetNextControl( targetControl ).Focus();
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// �q�ɃK�C�h�p���_�R�[�h�擾����
        /// </summary>
        /// <param name="selectedSectionList"></param>
        /// <returns>�q�ɃK�C�h�p�̎w�苒�_�R�[�h</returns>
        /// <remarks>
        /// <br>�o�͑Ώۋ��_�̑I���󋵂ɉ����āA���_�R�[�h��Ԃ��܂�</br>
        /// </remarks>
        private string GetWarehouseGuideSection( Hashtable selectedSectionList )
        {
            if ( selectedSectionList.Count >= 2 )
            {
                // �������_���I������Ă�����A���w��
                return string.Empty;
            }
            else if ( selectedSectionList.Count == 0 )
            {
                // ���_���I������Ă��Ȃ���΁A���w��
                return string.Empty;
            }
            else if ( selectedSectionList.Contains( "0" ) )
            {
                // �u�S���_�v���I������Ă�����A���w��
                return string.Empty;
            }

            // �I������Ă��鋒�_�R�[�h��Ԃ�
            foreach ( object obj in selectedSectionList.Values )
            {
                if ( obj is string )
                {
                    return (obj as string);
                }
            }

            return string.Empty;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsMakerGuid_Click ( object sender, EventArgs e )
        {
            MakerUMnt maker;

            if ( this._makerAcs == null )
            {
                this._makerAcs = new MakerAcs();
            }

            int status = this._makerAcs.ExecuteGuid( this._enterpriseCode, out maker );
            if ( status != 0 ) return;


            TNedit targetControl;
            if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "1" ) == 0 ) { targetControl = this.tNedit_GoodsMakerCd_St; }
            else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 )  { targetControl = this.tNedit_GoodsMakerCd_Ed; }
            else return;

            // �l�i�[
            targetControl.SetInt( maker.GoodsMakerCd );

            // ���t�H�[�J�X
            _guideNextFocusControl.GetNextControl( targetControl ).Focus();

        }

        // DEL 2008/09/25 �s��Ή�[5603] ---------->>>>>
        ///// <summary>
        ///// ���i�K�C�h�{�^���N���b�N�C�x���g����
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void ub_St_GoodsGuid_Click ( object sender, EventArgs e )
        //{
        //    if ( this._goodsGuid == null )
        //    {
        //        this._goodsGuid = new MAKHN04110UA();
        //    }

        //    GoodsUnitData goodsUnitData;
        //    DialogResult status = this._goodsGuid.ShowGuide( null, this._enterpriseCode, out goodsUnitData );

        //    if ( status != DialogResult.OK ) return;

        //    TEdit targetControl;
        //    if ( ((UltraButton)sender).Tag.ToString().CompareTo( "1" ) == 0 ) { targetControl = this.tEdit_GoodsNo_St; }
        //    else if ( ( (UltraButton)sender ).Tag.ToString().CompareTo( "2" ) == 0 ) {targetControl =  this.tEdit_GoodsNo_Ed; }
        //    else return;

        //    // �l�i�[
        //    targetControl.Text = goodsUnitData.GoodsNo.TrimEnd();

        //    // ���t�H�[�J�X
        //    _guideNextFocusControl.GetNextControl( targetControl ).Focus();
        //}
        // DEL 2008/09/25 �s��Ή�[5603] ----------<<<<<

        # endregion �� �K�C�h�{�^���N���b�N�C�x���g ��

        # region �� ExplorerBar�̏k���E�W�J���� ��
        /// <summary>
        /// �O���[�v�W�J
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // ��ɃL�����Z��
            e.Cancel = true;
        }
        /// <summary>
        /// �O���[�v�k��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
        {
            // ��ɃL�����Z��
            e.Cancel = true;
        }
        # endregion ��  ��
        # endregion �� �R���g���[���C�x���g ��

        # region �� �K�C�h�㎟�t�H�[�J�X����N���X ��
        /// <summary>
        /// �K�C�h�㎟�t�H�[�J�X����N���X
        /// </summary>
        internal class GuideNextFocusControl
        {
            private List<Control> _controls;
            private Dictionary<Control, int> _indexDic;

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public GuideNextFocusControl()
            {
                _controls = new List<Control>();
                _indexDic = new Dictionary<Control, int>();
            }
            /// <summary>
            /// �ΏۃR���g���[���ǉ�
            /// </summary>
            /// <param name="control"></param>
            public void Add( Control control )
            {
                _controls.Add( control );
                if ( !_indexDic.ContainsKey( control ) )
                {
                    _indexDic.Add( control, _controls.Count - 1 );
                }
            }
            /// <summary>
            /// �ΏۃR���g���[���ǉ�
            /// </summary>
            /// <param name="collection"></param>
            public void AddRange( IEnumerable<Control> collection )
            {
                int stIndex = _controls.Count;
                _controls.AddRange( collection );
                int edIndex = _controls.Count - 1;

                for ( int i = stIndex; i <= edIndex; i++ )
                {
                    if ( !_indexDic.ContainsKey( _controls[i] ) )
                    {
                        _indexDic.Add( _controls[i], i );
                    }
                }
            }
            /// <summary>
            /// �ΏۃR���g���[���N���A
            /// </summary>
            public void Clear()
            {
                _controls.Clear();
                _indexDic.Clear();
            }
            /// <summary>
            /// ���R���g���[���擾
            /// </summary>
            /// <param name="control"></param>
            /// <returns></returns>
            public Control GetNextControl( Control control )
            {
                int index = _indexDic[control];
                index++;

                for ( int i = index; i < _controls.Count; i++ )
                {
                    if ( !_controls[i].Visible || !_controls[i].Enabled )
                    {
                        continue;
                    }

                    if ( _controls[i] is TEdit )
                    {
                        if ( (_controls[i] as TEdit).ReadOnly == true )
                        {
                            continue;
                        }
                    }

                    return _controls[i];
                }
                return _controls[_controls.Count - 1];
            }
        }
        # endregion �� �K�C�h�㎟�t�H�[�J�X����N���X ��

        //--- ADD 2008/07/02 ---------->>>>>
        /// <summary>
        /// te_St_WarehouseCd_Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void te_St_WarehouseCd_Leave(object sender, EventArgs e)
        {
            if (this.tEdit_WarehouseCode_St.Text == ct_WarehouseCode_Min)
            {
                this.tEdit_WarehouseCode_St.Text = "";
            }
        }

        /// <summary>
        /// te_Ed_WarehouseCd_Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void te_Ed_WarehouseCd_Leave(object sender, EventArgs e)
        {
            if (this.tEdit_WarehouseCode_Ed.Text == ct_WarehouseCode_Max)
            {
                this.tEdit_WarehouseCode_Ed.Text = "";
            }
        }

        /// <summary>
        /// tne_St_GoodsMakerCd_Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_GoodsMakerCd_Leave(object sender, EventArgs e)
        {
            if (this.tNedit_GoodsMakerCd_St.Text == ct_MakerCode_Min)
            {
                this.tNedit_GoodsMakerCd_St.Text = "";
            }
        }

        /// <summary>
        /// tne_Ed_GoodsMakerCd_Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_GoodsMakerCd_Leave(object sender, EventArgs e)
        {
            if (this.tNedit_GoodsMakerCd_Ed.Text == ct_MakerCode_Max)
            {
                this.tNedit_GoodsMakerCd_Ed.Text = "";
            }
        }
        //--- ADD 2008/07/02 ---------->>>>>
    }
}