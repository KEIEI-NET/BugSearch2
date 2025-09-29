//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �����S�̐ݒ�
// �v���O�����T�v   : �����S�̐ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �O�� �O��
// �� �� ��  2005/08/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : enokida
// �C �� ��  2005/09/09  �C�����e : ���O�C�����擾�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : enokida
// �C �� ��  2005/09/17  �C�����e : Message���i�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �J���@�͍K
// �C �� ��  2005/10/19  �C�����e : UI�q���Hide����Owner.Activate�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�R�@����
// �C �� ��  2006/06/01  �C�����e : �O����Z��敪��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �i�� �m�q
// �C �� ��  2006/12/13  �C�����e : 
// 1.SF�ł𗬗p���g�єł��쐬
// 2.���g�p���ڂ��Œ�l�֕ύX(�}�C�i�X����p�c�������敪�E�O����Z��敪���폜)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ēc �ύK
// �C �� ��  2008/06/13  �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �s�V �m��
// �C �� ��  2008/10/09  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  13142       �쐬�S�� : �H���@�b�D
// �C �� ��  2009/04/08  �C�����e : ������Ԃŋ��_�K�C�h���͂��s���ƑS�Ћ��ʂɂȂ��Ă��܂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/04/14  �C�����e : Mantis�y13176�z�S�Ћ��ʂ̂ݏ����Ώے�������͉ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10704766-00  �쐬�S���F����3
// �C �� �� 2011/09/07   �C�����e�F�A��909 ���_�ݒ���s�����Ƌ��_�K�C�h������ƑS�Ћ��ʂ̕ҏW���s�����Ƃ��Ă��܂��B
//                       ���_�R�[�h�Ƌ��_�K�C�h�̃t�H�[�J�X�ړ��̓��b�Z�[�W�\�����s��Ȃ��悤�ɏC�����Ă��������B
// ---------------------------------------------------------------------------//

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;                        // ADD 2008/09/19 �s��Ή��ɂ�鋤�ʎd�l�̓W�J
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/09/19 �s��Ή��ɂ�鋤�ʎd�l�̓W�J
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �����S�̐ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>note	   : �����֘A�̐ݒ���s���܂��B
	///					 IMasterMaintenanceSingleType���������Ă��܂��B</br>              
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2005.08.01</br>
	/// <br>Update Note: 2005.09.09 23003 enokida</br>
	/// <br>           : ���O�C�����擾�Ή�</br>	
	/// <br>Update Note: 2005.09.17 23003 enokida</br>
	/// <br>           : Message���i�Ή�</br>
	/// <br>Update Note: 2005.10.19 22021 �J���@�͍K</br>
	/// <br>		   : �EUI�q���Hide����Owner.Activate�����ǉ�</br>
	/// <br>Update Note: 2006.06.01 23001 �H�R�@����</br>
    /// <br>                        1.�O����Z��敪��ǉ�</br>
    /// <br>Update Note: 2006.12.13 22022 �i�� �m�q</br>
    /// <br>					    1.SF�ł𗬗p���g�єł��쐬</br>
    /// <br>					    2.���g�p���ڂ��Œ�l�֕ύX(�}�C�i�X����p�c�������敪�E�O����Z��敪���폜)</br>
    /// <br>Programmer : 30415 �ēc �ύK</br>
    /// <br>Date       : 2008/06/13</br>	
    /// <br>UpdateNote   : 2008/10/09 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2009/04/08 30434 �H�� �b�D�@�o�O�C��</br>
    /// <br>UpdateNote : 2011/09/07 ����R</br>
    /// <br>        	 �E��Q�� #24169</br>
    /// </remarks>
    public class SFUKK09100UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private System.Windows.Forms.Timer timer1;
        private Infragistics.Win.Misc.UltraLabel AllowanceProcCd_Title_Label;
        private Broadleaf.Library.Windows.Forms.TComboEditor AllowanceProcCd_tComboEditor;
        private TComboEditor DepositSlipMntCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DepositSlipMntCd_Title_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel SectionNm_Label;
        private TEdit tEdit_SectionCodeAllowZero2;
        private TEdit SectionNm_tEdit;
        private Infragistics.Win.Misc.UltraButton SectionGd_ultraButton;
        private Infragistics.Win.Misc.UltraLabel SectionCode_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay12_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay11_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay8_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay9_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay10_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay7_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay6_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay5_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay3_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CustomerTotalDay4_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay_Title_Label;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay12_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay11_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay8_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay9_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay10_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay7_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay6_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay5_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay3_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay4_Title_Label;
        private Infragistics.Win.Misc.UltraLabel SupplierTotalDay1_Title_Label;
        private DataSet Bind_DataSet;
        private TNedit CustomerTotalDay1_tEdit;
        private TNedit CustomerTotalDay4_tEdit;
        private TNedit CustomerTotalDay5_tEdit;
        private TNedit CustomerTotalDay12_tEdit;
        private TNedit CustomerTotalDay11_tEdit;
        private TNedit CustomerTotalDay9_tEdit;
        private TNedit CustomerTotalDay8_tEdit;
        private TNedit CustomerTotalDay6_tEdit;
        private TNedit CustomerTotalDay7_tEdit;
        private TNedit CustomerTotalDay3_tEdit;
        private TNedit CustomerTotalDay2_tEdit;
        private TNedit CustomerTotalDay10_tEdit;
        private TNedit SupplierTotalDay1_tEdit;
        private TNedit SupplierTotalDay12_tEdit;
        private TNedit SupplierTotalDay11_tEdit;
        private TNedit SupplierTotalDay10_tEdit;
        private TNedit SupplierTotalDay9_tEdit;
        private TNedit SupplierTotalDay8_tEdit;
        private TNedit SupplierTotalDay7_tEdit;
        private TNedit SupplierTotalDay6_tEdit;
        private TNedit SupplierTotalDay5_tEdit;
        private TNedit SupplierTotalDay4_tEdit;
        private TNedit SupplierTotalDay3_tEdit;
        private TNedit SupplierTotalDay2_tEdit;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel CollectPlnDiv_Title_Label;
        private TComboEditor CollectPlnDiv_tComboEditor;
		private System.ComponentModel.IContainer components;

		# endregion

		# region Constructor
		/// <summary>
		/// SFUKK09100UA�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>note	   : �����S�̐ݒ�N���X�A�����S�̐ݒ�A�N�Z�X�N���X�𐶐����܂��B
		///					 �t���[����ʂ̈���{�^����\���ݒ���s���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		public SFUKK09100UA()
		{
			InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l
            this._canClose = false;	                       // ����@�\�i�f�t�H���gtrue�Œ�j
            this._canDelete = true;		                   // �폜�@�\
            this._canLogicalDeleteDataExtraction = true;   // �_���폜�f�[�^�\���@�\
            this._canNew = true;		                   // �V�K�쐬�@�\
            this._canPrint = false;	                       // ����@�\
            this._canSpecificationSearch = false;	       // �����w�茟���@�\
            this._defaultAutoFillToColumn = false;	       // ��T�C�Y���������@�\

			// 2005.09.09 enokida ADD ���O�C�����擾�Ή� >>>>>>>>>>>>>>>>> START
			//�@��ƃR�[�h���擾����
			this._enterPriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.09 enokida ADD ���O�C�����擾�Ή� <<<<<<<<<<<<<<<<< END

            // autoliaSet�N���X
            this._billAllSt = new BillAllSt();

            // ������
            this._dataIndex = -1;
            this._billAllStAcs = new BillAllStAcs();
            this._secInfoAcs = new SecInfoAcs(1);
            this._logicalDeleteMode = 0;
            this._billAllStTable = new Hashtable();

            // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ADD 2008/09/16 �s��Ή�[5257] ---------->>>>>
            // ���_�K�C�h�̃t�H�[�J�X����
            _sectionGuideController = new GeneralGuideUIController(
                this.tEdit_SectionCodeAllowZero2,
                this.SectionGd_ultraButton,
                this.AllowanceProcCd_tComboEditor
            );
            // ADD 2008/09/16 �s��Ή�[5257] ----------<<<<<
		}
		# endregion

		# region Dispose
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
		# endregion

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09100UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.AllowanceProcCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AllowanceProcCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DepositSlipMntCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DepositSlipMntCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionNm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGd_ultraButton = new Infragistics.Win.Misc.UltraButton();
            this.SectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay4_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay5_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay6_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay12_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay11_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay8_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay9_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay10_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerTotalDay7_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.SupplierTotalDay12_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay11_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay8_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay9_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay10_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay7_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay6_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay5_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay4_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierTotalDay1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Bind_DataSet = new System.Data.DataSet();
            this.CustomerTotalDay1_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay2_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay3_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay7_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay6_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay8_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay9_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay11_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay12_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay5_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay4_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerTotalDay10_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay1_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay2_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay3_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay4_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay5_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay6_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay7_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay8_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay9_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay10_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay11_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierTotalDay12_tEdit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.CollectPlnDiv_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CollectPlnDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.AllowanceProcCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositSlipMntCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay7_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay6_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay8_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay9_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay11_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay12_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay5_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay10_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay5_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay6_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay7_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay8_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay9_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay10_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay11_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay12_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectPlnDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Ok_Button.Location = new System.Drawing.Point(180, 366);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 32;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(25, 25);
            this.Cancel_Button.Location = new System.Drawing.Point(306, 366);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 33;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 420);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(469, 23);
            this.ultraStatusBar1.TabIndex = 10;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // AllowanceProcCd_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AllowanceProcCd_tComboEditor.ActiveAppearance = appearance5;
            this.AllowanceProcCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AllowanceProcCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AllowanceProcCd_tComboEditor.ItemAppearance = appearance6;
            this.AllowanceProcCd_tComboEditor.Location = new System.Drawing.Point(195, 84);
            this.AllowanceProcCd_tComboEditor.Name = "AllowanceProcCd_tComboEditor";
            this.AllowanceProcCd_tComboEditor.Size = new System.Drawing.Size(155, 24);
            this.AllowanceProcCd_tComboEditor.TabIndex = 3;
            // 
            // AllowanceProcCd_Title_Label
            // 
            this.AllowanceProcCd_Title_Label.Location = new System.Drawing.Point(21, 87);
            this.AllowanceProcCd_Title_Label.Name = "AllowanceProcCd_Title_Label";
            this.AllowanceProcCd_Title_Label.Size = new System.Drawing.Size(125, 14);
            this.AllowanceProcCd_Title_Label.TabIndex = 7;
            this.AllowanceProcCd_Title_Label.Text = "���������敪";
            // 
            // Mode_Label
            // 
            appearance22.ForeColor = System.Drawing.Color.White;
            appearance22.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance22.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance22.TextHAlignAsString = "Center";
            appearance22.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance22;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance23.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance23.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance23.TextHAlignAsString = "Center";
            appearance23.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance23;
            this.Mode_Label.Location = new System.Drawing.Point(336, 2);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DepositSlipMntCd_tComboEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositSlipMntCd_tComboEditor.ActiveAppearance = appearance7;
            this.DepositSlipMntCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DepositSlipMntCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DepositSlipMntCd_tComboEditor.ItemAppearance = appearance8;
            this.DepositSlipMntCd_tComboEditor.Location = new System.Drawing.Point(195, 114);
            this.DepositSlipMntCd_tComboEditor.Name = "DepositSlipMntCd_tComboEditor";
            this.DepositSlipMntCd_tComboEditor.Size = new System.Drawing.Size(155, 24);
            this.DepositSlipMntCd_tComboEditor.TabIndex = 4;
            // 
            // DepositSlipMntCd_Title_Label
            // 
            this.DepositSlipMntCd_Title_Label.Location = new System.Drawing.Point(21, 114);
            this.DepositSlipMntCd_Title_Label.Name = "DepositSlipMntCd_Title_Label";
            this.DepositSlipMntCd_Title_Label.Size = new System.Drawing.Size(140, 14);
            this.DepositSlipMntCd_Title_Label.TabIndex = 8;
            this.DepositSlipMntCd_Title_Label.Text = "�����`�[�C���敪";
            // 
            // SectionNm_Label
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.SectionNm_Label.Appearance = appearance30;
            this.SectionNm_Label.Location = new System.Drawing.Point(251, 32);
            this.SectionNm_Label.Name = "SectionNm_Label";
            this.SectionNm_Label.Size = new System.Drawing.Size(210, 23);
            this.SectionNm_Label.TabIndex = 163;
            this.SectionNm_Label.Text = "���[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance83;
            appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance84;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(64, 32);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero2.Leave += new System.EventHandler(this.tEdit_SectionCodeAllowZero_Leave);
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
            this.SectionNm_tEdit.Location = new System.Drawing.Point(130, 32);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.ReadOnly = true;
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 2;
            // 
            // SectionGd_ultraButton
            // 
            this.SectionGd_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
            this.SectionGd_ultraButton.Location = new System.Drawing.Point(99, 32);
            this.SectionGd_ultraButton.Margin = new System.Windows.Forms.Padding(4);
            this.SectionGd_ultraButton.Name = "SectionGd_ultraButton";
            this.SectionGd_ultraButton.Size = new System.Drawing.Size(24, 24);
            this.SectionGd_ultraButton.TabIndex = 1;
            this.SectionGd_ultraButton.Click += new System.EventHandler(this.SectionGd_ultraButton_Click);
            // 
            // SectionCode_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SectionCode_Title_Label.Appearance = appearance2;
            this.SectionCode_Title_Label.Location = new System.Drawing.Point(21, 32);
            this.SectionCode_Title_Label.Name = "SectionCode_Title_Label";
            this.SectionCode_Title_Label.Size = new System.Drawing.Size(60, 23);
            this.SectionCode_Title_Label.TabIndex = 161;
            this.SectionCode_Title_Label.Text = "���_";
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(12, 63);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(435, 3);
            this.ultraLabel17.TabIndex = 164;
            // 
            // CustomerTotalDay_Title_Label
            // 
            this.CustomerTotalDay_Title_Label.Location = new System.Drawing.Point(20, 186);
            this.CustomerTotalDay_Title_Label.Name = "CustomerTotalDay_Title_Label";
            this.CustomerTotalDay_Title_Label.Size = new System.Drawing.Size(191, 17);
            this.CustomerTotalDay_Title_Label.TabIndex = 165;
            this.CustomerTotalDay_Title_Label.Text = "�����Ώے����i���Ӑ�j";
            // 
            // CustomerTotalDay1_Title_Label
            // 
            appearance108.BackColor = System.Drawing.SystemColors.Highlight;
            appearance108.ForeColor = System.Drawing.Color.White;
            appearance108.TextHAlignAsString = "Center";
            appearance108.TextVAlignAsString = "Middle";
            this.CustomerTotalDay1_Title_Label.Appearance = appearance108;
            this.CustomerTotalDay1_Title_Label.Location = new System.Drawing.Point(20, 209);
            this.CustomerTotalDay1_Title_Label.Name = "CustomerTotalDay1_Title_Label";
            this.CustomerTotalDay1_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay1_Title_Label.TabIndex = 166;
            this.CustomerTotalDay1_Title_Label.Text = "1";
            // 
            // CustomerTotalDay4_Title_Label
            // 
            appearance107.BackColor = System.Drawing.SystemColors.Highlight;
            appearance107.ForeColor = System.Drawing.Color.White;
            appearance107.TextHAlignAsString = "Center";
            appearance107.TextVAlignAsString = "Middle";
            this.CustomerTotalDay4_Title_Label.Appearance = appearance107;
            this.CustomerTotalDay4_Title_Label.Location = new System.Drawing.Point(125, 209);
            this.CustomerTotalDay4_Title_Label.Name = "CustomerTotalDay4_Title_Label";
            this.CustomerTotalDay4_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay4_Title_Label.TabIndex = 167;
            this.CustomerTotalDay4_Title_Label.Text = "4";
            // 
            // CustomerTotalDay3_Title_Label
            // 
            appearance106.BackColor = System.Drawing.SystemColors.Highlight;
            appearance106.ForeColor = System.Drawing.Color.White;
            appearance106.TextHAlignAsString = "Center";
            appearance106.TextVAlignAsString = "Middle";
            this.CustomerTotalDay3_Title_Label.Appearance = appearance106;
            this.CustomerTotalDay3_Title_Label.Location = new System.Drawing.Point(90, 209);
            this.CustomerTotalDay3_Title_Label.Name = "CustomerTotalDay3_Title_Label";
            this.CustomerTotalDay3_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay3_Title_Label.TabIndex = 168;
            this.CustomerTotalDay3_Title_Label.Text = "3";
            // 
            // CustomerTotalDay2_Title_Label
            // 
            appearance105.BackColor = System.Drawing.SystemColors.Highlight;
            appearance105.ForeColor = System.Drawing.Color.White;
            appearance105.TextHAlignAsString = "Center";
            appearance105.TextVAlignAsString = "Middle";
            this.CustomerTotalDay2_Title_Label.Appearance = appearance105;
            this.CustomerTotalDay2_Title_Label.Location = new System.Drawing.Point(55, 209);
            this.CustomerTotalDay2_Title_Label.Name = "CustomerTotalDay2_Title_Label";
            this.CustomerTotalDay2_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay2_Title_Label.TabIndex = 169;
            this.CustomerTotalDay2_Title_Label.Text = "2";
            // 
            // CustomerTotalDay5_Title_Label
            // 
            appearance104.BackColor = System.Drawing.SystemColors.Highlight;
            appearance104.ForeColor = System.Drawing.Color.White;
            appearance104.TextHAlignAsString = "Center";
            appearance104.TextVAlignAsString = "Middle";
            this.CustomerTotalDay5_Title_Label.Appearance = appearance104;
            this.CustomerTotalDay5_Title_Label.Location = new System.Drawing.Point(160, 209);
            this.CustomerTotalDay5_Title_Label.Name = "CustomerTotalDay5_Title_Label";
            this.CustomerTotalDay5_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay5_Title_Label.TabIndex = 170;
            this.CustomerTotalDay5_Title_Label.Text = "5";
            // 
            // CustomerTotalDay6_Title_Label
            // 
            appearance103.BackColor = System.Drawing.SystemColors.Highlight;
            appearance103.ForeColor = System.Drawing.Color.White;
            appearance103.TextHAlignAsString = "Center";
            appearance103.TextVAlignAsString = "Middle";
            this.CustomerTotalDay6_Title_Label.Appearance = appearance103;
            this.CustomerTotalDay6_Title_Label.Location = new System.Drawing.Point(195, 209);
            this.CustomerTotalDay6_Title_Label.Name = "CustomerTotalDay6_Title_Label";
            this.CustomerTotalDay6_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay6_Title_Label.TabIndex = 171;
            this.CustomerTotalDay6_Title_Label.Text = "6";
            // 
            // CustomerTotalDay12_Title_Label
            // 
            appearance97.BackColor = System.Drawing.SystemColors.Highlight;
            appearance97.ForeColor = System.Drawing.Color.White;
            appearance97.TextHAlignAsString = "Center";
            appearance97.TextVAlignAsString = "Middle";
            this.CustomerTotalDay12_Title_Label.Appearance = appearance97;
            this.CustomerTotalDay12_Title_Label.Location = new System.Drawing.Point(405, 209);
            this.CustomerTotalDay12_Title_Label.Name = "CustomerTotalDay12_Title_Label";
            this.CustomerTotalDay12_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay12_Title_Label.TabIndex = 177;
            this.CustomerTotalDay12_Title_Label.Text = "12";
            // 
            // CustomerTotalDay11_Title_Label
            // 
            appearance98.BackColor = System.Drawing.SystemColors.Highlight;
            appearance98.ForeColor = System.Drawing.Color.White;
            appearance98.TextHAlignAsString = "Center";
            appearance98.TextVAlignAsString = "Middle";
            this.CustomerTotalDay11_Title_Label.Appearance = appearance98;
            this.CustomerTotalDay11_Title_Label.Location = new System.Drawing.Point(370, 209);
            this.CustomerTotalDay11_Title_Label.Name = "CustomerTotalDay11_Title_Label";
            this.CustomerTotalDay11_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay11_Title_Label.TabIndex = 176;
            this.CustomerTotalDay11_Title_Label.Text = "11";
            // 
            // CustomerTotalDay8_Title_Label
            // 
            appearance99.BackColor = System.Drawing.SystemColors.Highlight;
            appearance99.ForeColor = System.Drawing.Color.White;
            appearance99.TextHAlignAsString = "Center";
            appearance99.TextVAlignAsString = "Middle";
            this.CustomerTotalDay8_Title_Label.Appearance = appearance99;
            this.CustomerTotalDay8_Title_Label.Location = new System.Drawing.Point(265, 209);
            this.CustomerTotalDay8_Title_Label.Name = "CustomerTotalDay8_Title_Label";
            this.CustomerTotalDay8_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay8_Title_Label.TabIndex = 175;
            this.CustomerTotalDay8_Title_Label.Text = "8";
            // 
            // CustomerTotalDay9_Title_Label
            // 
            appearance100.BackColor = System.Drawing.SystemColors.Highlight;
            appearance100.ForeColor = System.Drawing.Color.White;
            appearance100.TextHAlignAsString = "Center";
            appearance100.TextVAlignAsString = "Middle";
            this.CustomerTotalDay9_Title_Label.Appearance = appearance100;
            this.CustomerTotalDay9_Title_Label.Location = new System.Drawing.Point(300, 209);
            this.CustomerTotalDay9_Title_Label.Name = "CustomerTotalDay9_Title_Label";
            this.CustomerTotalDay9_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay9_Title_Label.TabIndex = 174;
            this.CustomerTotalDay9_Title_Label.Text = "9";
            // 
            // CustomerTotalDay10_Title_Label
            // 
            appearance101.BackColor = System.Drawing.SystemColors.Highlight;
            appearance101.ForeColor = System.Drawing.Color.White;
            appearance101.TextHAlignAsString = "Center";
            appearance101.TextVAlignAsString = "Middle";
            this.CustomerTotalDay10_Title_Label.Appearance = appearance101;
            this.CustomerTotalDay10_Title_Label.Location = new System.Drawing.Point(335, 209);
            this.CustomerTotalDay10_Title_Label.Name = "CustomerTotalDay10_Title_Label";
            this.CustomerTotalDay10_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay10_Title_Label.TabIndex = 173;
            this.CustomerTotalDay10_Title_Label.Text = "10";
            // 
            // CustomerTotalDay7_Title_Label
            // 
            appearance102.BackColor = System.Drawing.SystemColors.Highlight;
            appearance102.ForeColor = System.Drawing.Color.White;
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.CustomerTotalDay7_Title_Label.Appearance = appearance102;
            this.CustomerTotalDay7_Title_Label.Location = new System.Drawing.Point(230, 209);
            this.CustomerTotalDay7_Title_Label.Name = "CustomerTotalDay7_Title_Label";
            this.CustomerTotalDay7_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay7_Title_Label.TabIndex = 172;
            this.CustomerTotalDay7_Title_Label.Text = "7";
            // 
            // SupplierTotalDay_Title_Label
            // 
            this.SupplierTotalDay_Title_Label.Location = new System.Drawing.Point(21, 273);
            this.SupplierTotalDay_Title_Label.Name = "SupplierTotalDay_Title_Label";
            this.SupplierTotalDay_Title_Label.Size = new System.Drawing.Size(191, 17);
            this.SupplierTotalDay_Title_Label.TabIndex = 190;
            this.SupplierTotalDay_Title_Label.Text = "�����Ώے����i�d����j";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(21, 366);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 30;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(54, 366);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 31;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // SupplierTotalDay12_Title_Label
            // 
            appearance69.BackColor = System.Drawing.SystemColors.Highlight;
            appearance69.ForeColor = System.Drawing.Color.White;
            appearance69.TextHAlignAsString = "Center";
            appearance69.TextVAlignAsString = "Middle";
            this.SupplierTotalDay12_Title_Label.Appearance = appearance69;
            this.SupplierTotalDay12_Title_Label.Location = new System.Drawing.Point(405, 295);
            this.SupplierTotalDay12_Title_Label.Name = "SupplierTotalDay12_Title_Label";
            this.SupplierTotalDay12_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay12_Title_Label.TabIndex = 228;
            this.SupplierTotalDay12_Title_Label.Text = "12";
            // 
            // SupplierTotalDay11_Title_Label
            // 
            appearance70.BackColor = System.Drawing.SystemColors.Highlight;
            appearance70.ForeColor = System.Drawing.Color.White;
            appearance70.TextHAlignAsString = "Center";
            appearance70.TextVAlignAsString = "Middle";
            this.SupplierTotalDay11_Title_Label.Appearance = appearance70;
            this.SupplierTotalDay11_Title_Label.Location = new System.Drawing.Point(370, 295);
            this.SupplierTotalDay11_Title_Label.Name = "SupplierTotalDay11_Title_Label";
            this.SupplierTotalDay11_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay11_Title_Label.TabIndex = 227;
            this.SupplierTotalDay11_Title_Label.Text = "11";
            // 
            // SupplierTotalDay8_Title_Label
            // 
            appearance71.BackColor = System.Drawing.SystemColors.Highlight;
            appearance71.ForeColor = System.Drawing.Color.White;
            appearance71.TextHAlignAsString = "Center";
            appearance71.TextVAlignAsString = "Middle";
            this.SupplierTotalDay8_Title_Label.Appearance = appearance71;
            this.SupplierTotalDay8_Title_Label.Location = new System.Drawing.Point(265, 295);
            this.SupplierTotalDay8_Title_Label.Name = "SupplierTotalDay8_Title_Label";
            this.SupplierTotalDay8_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay8_Title_Label.TabIndex = 226;
            this.SupplierTotalDay8_Title_Label.Text = "8";
            // 
            // SupplierTotalDay9_Title_Label
            // 
            appearance72.BackColor = System.Drawing.SystemColors.Highlight;
            appearance72.ForeColor = System.Drawing.Color.White;
            appearance72.TextHAlignAsString = "Center";
            appearance72.TextVAlignAsString = "Middle";
            this.SupplierTotalDay9_Title_Label.Appearance = appearance72;
            this.SupplierTotalDay9_Title_Label.Location = new System.Drawing.Point(300, 295);
            this.SupplierTotalDay9_Title_Label.Name = "SupplierTotalDay9_Title_Label";
            this.SupplierTotalDay9_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay9_Title_Label.TabIndex = 225;
            this.SupplierTotalDay9_Title_Label.Text = "9";
            // 
            // SupplierTotalDay10_Title_Label
            // 
            appearance73.BackColor = System.Drawing.SystemColors.Highlight;
            appearance73.ForeColor = System.Drawing.Color.White;
            appearance73.TextHAlignAsString = "Center";
            appearance73.TextVAlignAsString = "Middle";
            this.SupplierTotalDay10_Title_Label.Appearance = appearance73;
            this.SupplierTotalDay10_Title_Label.Location = new System.Drawing.Point(335, 295);
            this.SupplierTotalDay10_Title_Label.Name = "SupplierTotalDay10_Title_Label";
            this.SupplierTotalDay10_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay10_Title_Label.TabIndex = 224;
            this.SupplierTotalDay10_Title_Label.Text = "10";
            // 
            // SupplierTotalDay7_Title_Label
            // 
            appearance74.BackColor = System.Drawing.SystemColors.Highlight;
            appearance74.ForeColor = System.Drawing.Color.White;
            appearance74.TextHAlignAsString = "Center";
            appearance74.TextVAlignAsString = "Middle";
            this.SupplierTotalDay7_Title_Label.Appearance = appearance74;
            this.SupplierTotalDay7_Title_Label.Location = new System.Drawing.Point(230, 295);
            this.SupplierTotalDay7_Title_Label.Name = "SupplierTotalDay7_Title_Label";
            this.SupplierTotalDay7_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay7_Title_Label.TabIndex = 223;
            this.SupplierTotalDay7_Title_Label.Text = "7";
            // 
            // SupplierTotalDay6_Title_Label
            // 
            appearance75.BackColor = System.Drawing.SystemColors.Highlight;
            appearance75.ForeColor = System.Drawing.Color.White;
            appearance75.TextHAlignAsString = "Center";
            appearance75.TextVAlignAsString = "Middle";
            this.SupplierTotalDay6_Title_Label.Appearance = appearance75;
            this.SupplierTotalDay6_Title_Label.Location = new System.Drawing.Point(195, 295);
            this.SupplierTotalDay6_Title_Label.Name = "SupplierTotalDay6_Title_Label";
            this.SupplierTotalDay6_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay6_Title_Label.TabIndex = 222;
            this.SupplierTotalDay6_Title_Label.Text = "6";
            // 
            // SupplierTotalDay5_Title_Label
            // 
            appearance76.BackColor = System.Drawing.SystemColors.Highlight;
            appearance76.ForeColor = System.Drawing.Color.White;
            appearance76.TextHAlignAsString = "Center";
            appearance76.TextVAlignAsString = "Middle";
            this.SupplierTotalDay5_Title_Label.Appearance = appearance76;
            this.SupplierTotalDay5_Title_Label.Location = new System.Drawing.Point(160, 295);
            this.SupplierTotalDay5_Title_Label.Name = "SupplierTotalDay5_Title_Label";
            this.SupplierTotalDay5_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay5_Title_Label.TabIndex = 221;
            this.SupplierTotalDay5_Title_Label.Text = "5";
            // 
            // SupplierTotalDay2_Title_Label
            // 
            appearance77.BackColor = System.Drawing.SystemColors.Highlight;
            appearance77.ForeColor = System.Drawing.Color.White;
            appearance77.TextHAlignAsString = "Center";
            appearance77.TextVAlignAsString = "Middle";
            this.SupplierTotalDay2_Title_Label.Appearance = appearance77;
            this.SupplierTotalDay2_Title_Label.Location = new System.Drawing.Point(55, 295);
            this.SupplierTotalDay2_Title_Label.Name = "SupplierTotalDay2_Title_Label";
            this.SupplierTotalDay2_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay2_Title_Label.TabIndex = 220;
            this.SupplierTotalDay2_Title_Label.Text = "2";
            // 
            // SupplierTotalDay3_Title_Label
            // 
            appearance80.BackColor = System.Drawing.SystemColors.Highlight;
            appearance80.ForeColor = System.Drawing.Color.White;
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.SupplierTotalDay3_Title_Label.Appearance = appearance80;
            this.SupplierTotalDay3_Title_Label.Location = new System.Drawing.Point(90, 295);
            this.SupplierTotalDay3_Title_Label.Name = "SupplierTotalDay3_Title_Label";
            this.SupplierTotalDay3_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay3_Title_Label.TabIndex = 219;
            this.SupplierTotalDay3_Title_Label.Text = "3";
            // 
            // SupplierTotalDay4_Title_Label
            // 
            appearance81.BackColor = System.Drawing.SystemColors.Highlight;
            appearance81.ForeColor = System.Drawing.Color.White;
            appearance81.TextHAlignAsString = "Center";
            appearance81.TextVAlignAsString = "Middle";
            this.SupplierTotalDay4_Title_Label.Appearance = appearance81;
            this.SupplierTotalDay4_Title_Label.Location = new System.Drawing.Point(125, 295);
            this.SupplierTotalDay4_Title_Label.Name = "SupplierTotalDay4_Title_Label";
            this.SupplierTotalDay4_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay4_Title_Label.TabIndex = 218;
            this.SupplierTotalDay4_Title_Label.Text = "4";
            // 
            // SupplierTotalDay1_Title_Label
            // 
            appearance82.BackColor = System.Drawing.SystemColors.Highlight;
            appearance82.ForeColor = System.Drawing.Color.White;
            appearance82.TextHAlignAsString = "Center";
            appearance82.TextVAlignAsString = "Middle";
            this.SupplierTotalDay1_Title_Label.Appearance = appearance82;
            this.SupplierTotalDay1_Title_Label.Location = new System.Drawing.Point(20, 295);
            this.SupplierTotalDay1_Title_Label.Name = "SupplierTotalDay1_Title_Label";
            this.SupplierTotalDay1_Title_Label.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay1_Title_Label.TabIndex = 217;
            this.SupplierTotalDay1_Title_Label.Text = "1";
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // CustomerTotalDay1_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay1_tEdit.ActiveAppearance = appearance12;
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.CustomerTotalDay1_tEdit.Appearance = appearance13;
            this.CustomerTotalDay1_tEdit.AutoSelect = true;
            this.CustomerTotalDay1_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay1_tEdit.DataText = "";
            this.CustomerTotalDay1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay1_tEdit.Location = new System.Drawing.Point(20, 239);
            this.CustomerTotalDay1_tEdit.MaxLength = 2;
            this.CustomerTotalDay1_tEdit.Name = "CustomerTotalDay1_tEdit";
            this.CustomerTotalDay1_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay1_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay1_tEdit.TabIndex = 6;
            // 
            // CustomerTotalDay2_tEdit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay2_tEdit.ActiveAppearance = appearance26;
            appearance27.TextHAlignAsString = "Right";
            appearance27.TextVAlignAsString = "Middle";
            this.CustomerTotalDay2_tEdit.Appearance = appearance27;
            this.CustomerTotalDay2_tEdit.AutoSelect = true;
            this.CustomerTotalDay2_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay2_tEdit.DataText = "";
            this.CustomerTotalDay2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay2_tEdit.Location = new System.Drawing.Point(55, 239);
            this.CustomerTotalDay2_tEdit.MaxLength = 2;
            this.CustomerTotalDay2_tEdit.Name = "CustomerTotalDay2_tEdit";
            this.CustomerTotalDay2_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay2_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay2_tEdit.TabIndex = 7;
            // 
            // CustomerTotalDay3_tEdit
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay3_tEdit.ActiveAppearance = appearance28;
            appearance29.TextHAlignAsString = "Right";
            appearance29.TextVAlignAsString = "Middle";
            this.CustomerTotalDay3_tEdit.Appearance = appearance29;
            this.CustomerTotalDay3_tEdit.AutoSelect = true;
            this.CustomerTotalDay3_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay3_tEdit.DataText = "";
            this.CustomerTotalDay3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay3_tEdit.Location = new System.Drawing.Point(90, 239);
            this.CustomerTotalDay3_tEdit.MaxLength = 2;
            this.CustomerTotalDay3_tEdit.Name = "CustomerTotalDay3_tEdit";
            this.CustomerTotalDay3_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay3_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay3_tEdit.TabIndex = 8;
            // 
            // CustomerTotalDay7_tEdit
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay7_tEdit.ActiveAppearance = appearance35;
            appearance36.TextHAlignAsString = "Right";
            appearance36.TextVAlignAsString = "Middle";
            this.CustomerTotalDay7_tEdit.Appearance = appearance36;
            this.CustomerTotalDay7_tEdit.AutoSelect = true;
            this.CustomerTotalDay7_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay7_tEdit.DataText = "";
            this.CustomerTotalDay7_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay7_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay7_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay7_tEdit.Location = new System.Drawing.Point(230, 239);
            this.CustomerTotalDay7_tEdit.MaxLength = 2;
            this.CustomerTotalDay7_tEdit.Name = "CustomerTotalDay7_tEdit";
            this.CustomerTotalDay7_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay7_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay7_tEdit.TabIndex = 12;
            // 
            // CustomerTotalDay6_tEdit
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay6_tEdit.ActiveAppearance = appearance33;
            appearance34.TextHAlignAsString = "Right";
            appearance34.TextVAlignAsString = "Middle";
            this.CustomerTotalDay6_tEdit.Appearance = appearance34;
            this.CustomerTotalDay6_tEdit.AutoSelect = true;
            this.CustomerTotalDay6_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay6_tEdit.DataText = "";
            this.CustomerTotalDay6_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay6_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay6_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay6_tEdit.Location = new System.Drawing.Point(195, 239);
            this.CustomerTotalDay6_tEdit.MaxLength = 2;
            this.CustomerTotalDay6_tEdit.Name = "CustomerTotalDay6_tEdit";
            this.CustomerTotalDay6_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay6_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay6_tEdit.TabIndex = 11;
            // 
            // CustomerTotalDay8_tEdit
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay8_tEdit.ActiveAppearance = appearance37;
            appearance38.TextHAlignAsString = "Right";
            appearance38.TextVAlignAsString = "Middle";
            this.CustomerTotalDay8_tEdit.Appearance = appearance38;
            this.CustomerTotalDay8_tEdit.AutoSelect = true;
            this.CustomerTotalDay8_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay8_tEdit.DataText = "";
            this.CustomerTotalDay8_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay8_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay8_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay8_tEdit.Location = new System.Drawing.Point(265, 239);
            this.CustomerTotalDay8_tEdit.MaxLength = 2;
            this.CustomerTotalDay8_tEdit.Name = "CustomerTotalDay8_tEdit";
            this.CustomerTotalDay8_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay8_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay8_tEdit.TabIndex = 13;
            // 
            // CustomerTotalDay9_tEdit
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay9_tEdit.ActiveAppearance = appearance39;
            appearance40.TextHAlignAsString = "Right";
            appearance40.TextVAlignAsString = "Middle";
            this.CustomerTotalDay9_tEdit.Appearance = appearance40;
            this.CustomerTotalDay9_tEdit.AutoSelect = true;
            this.CustomerTotalDay9_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay9_tEdit.DataText = "";
            this.CustomerTotalDay9_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay9_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay9_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay9_tEdit.Location = new System.Drawing.Point(300, 239);
            this.CustomerTotalDay9_tEdit.MaxLength = 2;
            this.CustomerTotalDay9_tEdit.Name = "CustomerTotalDay9_tEdit";
            this.CustomerTotalDay9_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay9_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay9_tEdit.TabIndex = 14;
            // 
            // CustomerTotalDay11_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay11_tEdit.ActiveAppearance = appearance10;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.CustomerTotalDay11_tEdit.Appearance = appearance11;
            this.CustomerTotalDay11_tEdit.AutoSelect = true;
            this.CustomerTotalDay11_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay11_tEdit.DataText = "";
            this.CustomerTotalDay11_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay11_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay11_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay11_tEdit.Location = new System.Drawing.Point(370, 239);
            this.CustomerTotalDay11_tEdit.MaxLength = 2;
            this.CustomerTotalDay11_tEdit.Name = "CustomerTotalDay11_tEdit";
            this.CustomerTotalDay11_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay11_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay11_tEdit.TabIndex = 16;
            // 
            // CustomerTotalDay12_tEdit
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay12_tEdit.ActiveAppearance = appearance41;
            appearance42.TextHAlignAsString = "Right";
            appearance42.TextVAlignAsString = "Middle";
            this.CustomerTotalDay12_tEdit.Appearance = appearance42;
            this.CustomerTotalDay12_tEdit.AutoSelect = true;
            this.CustomerTotalDay12_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay12_tEdit.DataText = "";
            this.CustomerTotalDay12_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay12_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay12_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay12_tEdit.Location = new System.Drawing.Point(405, 239);
            this.CustomerTotalDay12_tEdit.MaxLength = 2;
            this.CustomerTotalDay12_tEdit.Name = "CustomerTotalDay12_tEdit";
            this.CustomerTotalDay12_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay12_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay12_tEdit.TabIndex = 17;
            // 
            // CustomerTotalDay5_tEdit
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay5_tEdit.ActiveAppearance = appearance31;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.CustomerTotalDay5_tEdit.Appearance = appearance32;
            this.CustomerTotalDay5_tEdit.AutoSelect = true;
            this.CustomerTotalDay5_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay5_tEdit.DataText = "";
            this.CustomerTotalDay5_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay5_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay5_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay5_tEdit.Location = new System.Drawing.Point(160, 239);
            this.CustomerTotalDay5_tEdit.MaxLength = 2;
            this.CustomerTotalDay5_tEdit.Name = "CustomerTotalDay5_tEdit";
            this.CustomerTotalDay5_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay5_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay5_tEdit.TabIndex = 10;
            // 
            // CustomerTotalDay4_tEdit
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay4_tEdit.ActiveAppearance = appearance24;
            appearance25.TextHAlignAsString = "Right";
            appearance25.TextVAlignAsString = "Middle";
            this.CustomerTotalDay4_tEdit.Appearance = appearance25;
            this.CustomerTotalDay4_tEdit.AutoSelect = true;
            this.CustomerTotalDay4_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay4_tEdit.DataText = "";
            this.CustomerTotalDay4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay4_tEdit.Location = new System.Drawing.Point(125, 239);
            this.CustomerTotalDay4_tEdit.MaxLength = 2;
            this.CustomerTotalDay4_tEdit.Name = "CustomerTotalDay4_tEdit";
            this.CustomerTotalDay4_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay4_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay4_tEdit.TabIndex = 9;
            // 
            // CustomerTotalDay10_tEdit
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerTotalDay10_tEdit.ActiveAppearance = appearance43;
            appearance44.TextHAlignAsString = "Right";
            appearance44.TextVAlignAsString = "Middle";
            this.CustomerTotalDay10_tEdit.Appearance = appearance44;
            this.CustomerTotalDay10_tEdit.AutoSelect = true;
            this.CustomerTotalDay10_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.CustomerTotalDay10_tEdit.DataText = "";
            this.CustomerTotalDay10_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerTotalDay10_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.CustomerTotalDay10_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CustomerTotalDay10_tEdit.Location = new System.Drawing.Point(335, 239);
            this.CustomerTotalDay10_tEdit.MaxLength = 2;
            this.CustomerTotalDay10_tEdit.Name = "CustomerTotalDay10_tEdit";
            this.CustomerTotalDay10_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.CustomerTotalDay10_tEdit.Size = new System.Drawing.Size(28, 24);
            this.CustomerTotalDay10_tEdit.TabIndex = 15;
            // 
            // SupplierTotalDay1_tEdit
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay1_tEdit.ActiveAppearance = appearance14;
            appearance96.TextHAlignAsString = "Right";
            appearance96.TextVAlignAsString = "Middle";
            this.SupplierTotalDay1_tEdit.Appearance = appearance96;
            this.SupplierTotalDay1_tEdit.AutoSelect = true;
            this.SupplierTotalDay1_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay1_tEdit.DataText = "";
            this.SupplierTotalDay1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay1_tEdit.Location = new System.Drawing.Point(20, 325);
            this.SupplierTotalDay1_tEdit.MaxLength = 2;
            this.SupplierTotalDay1_tEdit.Name = "SupplierTotalDay1_tEdit";
            this.SupplierTotalDay1_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay1_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay1_tEdit.TabIndex = 18;
            // 
            // SupplierTotalDay2_tEdit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay2_tEdit.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.SupplierTotalDay2_tEdit.Appearance = appearance16;
            this.SupplierTotalDay2_tEdit.AutoSelect = true;
            this.SupplierTotalDay2_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay2_tEdit.DataText = "";
            this.SupplierTotalDay2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay2_tEdit.Location = new System.Drawing.Point(55, 325);
            this.SupplierTotalDay2_tEdit.MaxLength = 2;
            this.SupplierTotalDay2_tEdit.Name = "SupplierTotalDay2_tEdit";
            this.SupplierTotalDay2_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay2_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay2_tEdit.TabIndex = 19;
            // 
            // SupplierTotalDay3_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay3_tEdit.ActiveAppearance = appearance17;
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.SupplierTotalDay3_tEdit.Appearance = appearance18;
            this.SupplierTotalDay3_tEdit.AutoSelect = true;
            this.SupplierTotalDay3_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay3_tEdit.DataText = "";
            this.SupplierTotalDay3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay3_tEdit.Location = new System.Drawing.Point(90, 325);
            this.SupplierTotalDay3_tEdit.MaxLength = 2;
            this.SupplierTotalDay3_tEdit.Name = "SupplierTotalDay3_tEdit";
            this.SupplierTotalDay3_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay3_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay3_tEdit.TabIndex = 20;
            // 
            // SupplierTotalDay4_tEdit
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay4_tEdit.ActiveAppearance = appearance19;
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.SupplierTotalDay4_tEdit.Appearance = appearance20;
            this.SupplierTotalDay4_tEdit.AutoSelect = true;
            this.SupplierTotalDay4_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay4_tEdit.DataText = "";
            this.SupplierTotalDay4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay4_tEdit.Location = new System.Drawing.Point(125, 325);
            this.SupplierTotalDay4_tEdit.MaxLength = 2;
            this.SupplierTotalDay4_tEdit.Name = "SupplierTotalDay4_tEdit";
            this.SupplierTotalDay4_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay4_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay4_tEdit.TabIndex = 21;
            // 
            // SupplierTotalDay5_tEdit
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay5_tEdit.ActiveAppearance = appearance21;
            appearance45.TextHAlignAsString = "Right";
            appearance45.TextVAlignAsString = "Middle";
            this.SupplierTotalDay5_tEdit.Appearance = appearance45;
            this.SupplierTotalDay5_tEdit.AutoSelect = true;
            this.SupplierTotalDay5_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay5_tEdit.DataText = "";
            this.SupplierTotalDay5_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay5_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay5_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay5_tEdit.Location = new System.Drawing.Point(160, 325);
            this.SupplierTotalDay5_tEdit.MaxLength = 2;
            this.SupplierTotalDay5_tEdit.Name = "SupplierTotalDay5_tEdit";
            this.SupplierTotalDay5_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay5_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay5_tEdit.TabIndex = 22;
            // 
            // SupplierTotalDay6_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay6_tEdit.ActiveAppearance = appearance46;
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.SupplierTotalDay6_tEdit.Appearance = appearance85;
            this.SupplierTotalDay6_tEdit.AutoSelect = true;
            this.SupplierTotalDay6_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay6_tEdit.DataText = "";
            this.SupplierTotalDay6_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay6_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay6_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay6_tEdit.Location = new System.Drawing.Point(195, 325);
            this.SupplierTotalDay6_tEdit.MaxLength = 2;
            this.SupplierTotalDay6_tEdit.Name = "SupplierTotalDay6_tEdit";
            this.SupplierTotalDay6_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay6_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay6_tEdit.TabIndex = 23;
            // 
            // SupplierTotalDay7_tEdit
            // 
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay7_tEdit.ActiveAppearance = appearance86;
            appearance87.TextHAlignAsString = "Right";
            appearance87.TextVAlignAsString = "Middle";
            this.SupplierTotalDay7_tEdit.Appearance = appearance87;
            this.SupplierTotalDay7_tEdit.AutoSelect = true;
            this.SupplierTotalDay7_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay7_tEdit.DataText = "";
            this.SupplierTotalDay7_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay7_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay7_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay7_tEdit.Location = new System.Drawing.Point(230, 325);
            this.SupplierTotalDay7_tEdit.MaxLength = 2;
            this.SupplierTotalDay7_tEdit.Name = "SupplierTotalDay7_tEdit";
            this.SupplierTotalDay7_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay7_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay7_tEdit.TabIndex = 24;
            // 
            // SupplierTotalDay8_tEdit
            // 
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay8_tEdit.ActiveAppearance = appearance88;
            appearance89.TextHAlignAsString = "Right";
            appearance89.TextVAlignAsString = "Middle";
            this.SupplierTotalDay8_tEdit.Appearance = appearance89;
            this.SupplierTotalDay8_tEdit.AutoSelect = true;
            this.SupplierTotalDay8_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay8_tEdit.DataText = "";
            this.SupplierTotalDay8_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay8_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay8_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay8_tEdit.Location = new System.Drawing.Point(265, 325);
            this.SupplierTotalDay8_tEdit.MaxLength = 2;
            this.SupplierTotalDay8_tEdit.Name = "SupplierTotalDay8_tEdit";
            this.SupplierTotalDay8_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay8_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay8_tEdit.TabIndex = 25;
            // 
            // SupplierTotalDay9_tEdit
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay9_tEdit.ActiveAppearance = appearance90;
            appearance91.TextHAlignAsString = "Right";
            appearance91.TextVAlignAsString = "Middle";
            this.SupplierTotalDay9_tEdit.Appearance = appearance91;
            this.SupplierTotalDay9_tEdit.AutoSelect = true;
            this.SupplierTotalDay9_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay9_tEdit.DataText = "";
            this.SupplierTotalDay9_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay9_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay9_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay9_tEdit.Location = new System.Drawing.Point(300, 325);
            this.SupplierTotalDay9_tEdit.MaxLength = 2;
            this.SupplierTotalDay9_tEdit.Name = "SupplierTotalDay9_tEdit";
            this.SupplierTotalDay9_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay9_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay9_tEdit.TabIndex = 26;
            // 
            // SupplierTotalDay10_tEdit
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay10_tEdit.ActiveAppearance = appearance92;
            appearance93.TextHAlignAsString = "Right";
            appearance93.TextVAlignAsString = "Middle";
            this.SupplierTotalDay10_tEdit.Appearance = appearance93;
            this.SupplierTotalDay10_tEdit.AutoSelect = true;
            this.SupplierTotalDay10_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay10_tEdit.DataText = "";
            this.SupplierTotalDay10_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay10_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay10_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay10_tEdit.Location = new System.Drawing.Point(335, 325);
            this.SupplierTotalDay10_tEdit.MaxLength = 2;
            this.SupplierTotalDay10_tEdit.Name = "SupplierTotalDay10_tEdit";
            this.SupplierTotalDay10_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay10_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay10_tEdit.TabIndex = 27;
            // 
            // SupplierTotalDay11_tEdit
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay11_tEdit.ActiveAppearance = appearance94;
            appearance95.TextHAlignAsString = "Right";
            appearance95.TextVAlignAsString = "Middle";
            this.SupplierTotalDay11_tEdit.Appearance = appearance95;
            this.SupplierTotalDay11_tEdit.AutoSelect = true;
            this.SupplierTotalDay11_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay11_tEdit.DataText = "";
            this.SupplierTotalDay11_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay11_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay11_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay11_tEdit.Location = new System.Drawing.Point(370, 325);
            this.SupplierTotalDay11_tEdit.MaxLength = 2;
            this.SupplierTotalDay11_tEdit.Name = "SupplierTotalDay11_tEdit";
            this.SupplierTotalDay11_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay11_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay11_tEdit.TabIndex = 28;
            // 
            // SupplierTotalDay12_tEdit
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierTotalDay12_tEdit.ActiveAppearance = appearance78;
            appearance79.TextHAlignAsString = "Right";
            appearance79.TextVAlignAsString = "Middle";
            this.SupplierTotalDay12_tEdit.Appearance = appearance79;
            this.SupplierTotalDay12_tEdit.AutoSelect = true;
            this.SupplierTotalDay12_tEdit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierTotalDay12_tEdit.DataText = "";
            this.SupplierTotalDay12_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierTotalDay12_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SupplierTotalDay12_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierTotalDay12_tEdit.Location = new System.Drawing.Point(405, 325);
            this.SupplierTotalDay12_tEdit.MaxLength = 2;
            this.SupplierTotalDay12_tEdit.Name = "SupplierTotalDay12_tEdit";
            this.SupplierTotalDay12_tEdit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.SupplierTotalDay12_tEdit.Size = new System.Drawing.Size(28, 24);
            this.SupplierTotalDay12_tEdit.TabIndex = 29;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // CollectPlnDiv_Title_Label
            // 
            this.CollectPlnDiv_Title_Label.Location = new System.Drawing.Point(21, 144);
            this.CollectPlnDiv_Title_Label.Name = "CollectPlnDiv_Title_Label";
            this.CollectPlnDiv_Title_Label.Size = new System.Drawing.Size(100, 23);
            this.CollectPlnDiv_Title_Label.TabIndex = 229;
            this.CollectPlnDiv_Title_Label.Text = "����\��敪";
            // 
            // CollectPlnDiv_tComboEditor
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CollectPlnDiv_tComboEditor.ActiveAppearance = appearance3;
            this.CollectPlnDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CollectPlnDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CollectPlnDiv_tComboEditor.ItemAppearance = appearance4;
            this.CollectPlnDiv_tComboEditor.Location = new System.Drawing.Point(195, 144);
            this.CollectPlnDiv_tComboEditor.Name = "CollectPlnDiv_tComboEditor";
            this.CollectPlnDiv_tComboEditor.Size = new System.Drawing.Size(155, 24);
            this.CollectPlnDiv_tComboEditor.TabIndex = 5;
            // 
            // SFUKK09100UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(469, 443);
            this.Controls.Add(this.CollectPlnDiv_tComboEditor);
            this.Controls.Add(this.CollectPlnDiv_Title_Label);
            this.Controls.Add(this.SupplierTotalDay12_tEdit);
            this.Controls.Add(this.SupplierTotalDay11_tEdit);
            this.Controls.Add(this.SupplierTotalDay10_tEdit);
            this.Controls.Add(this.SupplierTotalDay9_tEdit);
            this.Controls.Add(this.SupplierTotalDay8_tEdit);
            this.Controls.Add(this.SupplierTotalDay7_tEdit);
            this.Controls.Add(this.SupplierTotalDay6_tEdit);
            this.Controls.Add(this.SupplierTotalDay5_tEdit);
            this.Controls.Add(this.SupplierTotalDay4_tEdit);
            this.Controls.Add(this.SupplierTotalDay3_tEdit);
            this.Controls.Add(this.SupplierTotalDay2_tEdit);
            this.Controls.Add(this.SupplierTotalDay1_tEdit);
            this.Controls.Add(this.CustomerTotalDay10_tEdit);
            this.Controls.Add(this.CustomerTotalDay4_tEdit);
            this.Controls.Add(this.CustomerTotalDay5_tEdit);
            this.Controls.Add(this.CustomerTotalDay12_tEdit);
            this.Controls.Add(this.CustomerTotalDay11_tEdit);
            this.Controls.Add(this.CustomerTotalDay9_tEdit);
            this.Controls.Add(this.CustomerTotalDay8_tEdit);
            this.Controls.Add(this.CustomerTotalDay6_tEdit);
            this.Controls.Add(this.CustomerTotalDay7_tEdit);
            this.Controls.Add(this.CustomerTotalDay3_tEdit);
            this.Controls.Add(this.CustomerTotalDay2_tEdit);
            this.Controls.Add(this.CustomerTotalDay1_tEdit);
            this.Controls.Add(this.SupplierTotalDay12_Title_Label);
            this.Controls.Add(this.SupplierTotalDay11_Title_Label);
            this.Controls.Add(this.SupplierTotalDay8_Title_Label);
            this.Controls.Add(this.SupplierTotalDay9_Title_Label);
            this.Controls.Add(this.SupplierTotalDay10_Title_Label);
            this.Controls.Add(this.SupplierTotalDay7_Title_Label);
            this.Controls.Add(this.SupplierTotalDay6_Title_Label);
            this.Controls.Add(this.SupplierTotalDay5_Title_Label);
            this.Controls.Add(this.SupplierTotalDay2_Title_Label);
            this.Controls.Add(this.SupplierTotalDay3_Title_Label);
            this.Controls.Add(this.SupplierTotalDay4_Title_Label);
            this.Controls.Add(this.SupplierTotalDay1_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SupplierTotalDay_Title_Label);
            this.Controls.Add(this.CustomerTotalDay12_Title_Label);
            this.Controls.Add(this.CustomerTotalDay11_Title_Label);
            this.Controls.Add(this.CustomerTotalDay8_Title_Label);
            this.Controls.Add(this.CustomerTotalDay9_Title_Label);
            this.Controls.Add(this.CustomerTotalDay10_Title_Label);
            this.Controls.Add(this.CustomerTotalDay7_Title_Label);
            this.Controls.Add(this.CustomerTotalDay6_Title_Label);
            this.Controls.Add(this.CustomerTotalDay5_Title_Label);
            this.Controls.Add(this.CustomerTotalDay2_Title_Label);
            this.Controls.Add(this.CustomerTotalDay3_Title_Label);
            this.Controls.Add(this.CustomerTotalDay4_Title_Label);
            this.Controls.Add(this.CustomerTotalDay1_Title_Label);
            this.Controls.Add(this.CustomerTotalDay_Title_Label);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.SectionNm_Label);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionGd_ultraButton);
            this.Controls.Add(this.SectionCode_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.DepositSlipMntCd_tComboEditor);
            this.Controls.Add(this.DepositSlipMntCd_Title_Label);
            this.Controls.Add(this.AllowanceProcCd_tComboEditor);
            this.Controls.Add(this.AllowanceProcCd_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09100UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�����S�̐ݒ�";
            this.Load += new System.EventHandler(this.SFUKK09100UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09100UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09100UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.AllowanceProcCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositSlipMntCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay7_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay6_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay8_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay9_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay11_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay12_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay5_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerTotalDay10_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay5_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay6_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay7_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay8_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay9_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay10_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay11_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierTotalDay12_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectPlnDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>
		/// ��ʔ�\���C�x���g
		/// </summary>
		/// <remarks>
		/// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
		/// </remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
           --- DEL 2008/06/13 --------------------------------<<<<< */

        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ������ɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		#region Private Members

		private BillAllSt _billAllSt;
        private BillAllStAcs _billAllStAcs;
		private string _enterPriseCode;

		// �v���p�e�B�p
		private bool _canPrint;
        // --- ADD 2008/06/13 -------------------------------->>>>>
        private bool _canDelete;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canNew;
        private bool _canSpecificationSearch;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        private SecInfoAcs _secInfoAcs;  // ���_�}�X�^�A�N�Z�X�N���X

        // ���ݒ莞�Ɏg�p
        private const string UNREGISTER = "";

        private int _logicalDeleteMode;				// ���[�h
        // --- ADD 2008/06/13 --------------------------------<<<<< 
        private bool isError = false; // ADD 2011/09/07

		/// <summary>
		/// �I���v���p�e�B
		/// </summary>
		/// <remarks>
		/// �A�Z���u�����I�����邩�A���Ȃ������擾���̓Z�b�g���܂��B
		/// </remarks>
		private bool _canClose;

        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        // --- ADD 2008/06/13 -------------------------------->>>>>
        private Hashtable _billAllStTable;	 // �����S�̐ݒ�e�[�u��

        private const string GUID_TITLE = "GUID";
        private const string BILLALLST_TABLE = "BILLALLST"; // �e�[�u����

        // Frame��View�pGrid���KEY���i�w�b�_�̃^�C�g�����ƂȂ�܂��B�j
        private const string DELETE_DATE       = "�폜��";
        // DEL 2008/10/09 �s��Ή�[6444] ---------->>>>>
        //private const string SECTIONCODE_TITLE = "�R�[�h";        
        //private const string SECTIONNAME_TITLE = "���_����";
        // DEL 2008/10/09 �s��Ή�[6444] ----------<<<<<
        // ADD 2008/10/09 �s��Ή�[6444] ---------->>>>>
        private const string SECTIONCODE_TITLE = "���_�R�[�h";   
        private const string SECTIONNAME_TITLE = "���_��";
        // ADD 2008/10/09 �s��Ή�[6444] ----------<<<<<

        private const string CUSTOMERTOTALDAY01_TITLE = "�����Ώے����P�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY02_TITLE = "�����Ώے����Q�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY03_TITLE = "�����Ώے����R�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY04_TITLE = "�����Ώے����S�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY05_TITLE = "�����Ώے����T�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY06_TITLE = "�����Ώے����U�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY07_TITLE = "�����Ώے����V�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY08_TITLE = "�����Ώے����W�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY09_TITLE = "�����Ώے����X�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY10_TITLE = "�����Ώے����P�O�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY11_TITLE = "�����Ώے����P�P�i���Ӑ�j";
        private const string CUSTOMERTOTALDAY12_TITLE = "�����Ώے����P�Q�i���Ӑ�j";

        private const string SUPPLIERTOTALDAY01_TITLE = "�����Ώے����P�i�d����j";
        private const string SUPPLIERTOTALDAY02_TITLE = "�����Ώے����Q�i�d����j";
        private const string SUPPLIERTOTALDAY03_TITLE = "�����Ώے����R�i�d����j";
        private const string SUPPLIERTOTALDAY04_TITLE = "�����Ώے����S�i�d����j";
        private const string SUPPLIERTOTALDAY05_TITLE = "�����Ώے����T�i�d����j";
        private const string SUPPLIERTOTALDAY06_TITLE = "�����Ώے����U�i�d����j";
        private const string SUPPLIERTOTALDAY07_TITLE = "�����Ώے����V�i�d����j";
        private const string SUPPLIERTOTALDAY08_TITLE = "�����Ώے����W�i�d����j";
        private const string SUPPLIERTOTALDAY09_TITLE = "�����Ώے����X�i�d����j";
        private const string SUPPLIERTOTALDAY10_TITLE = "�����Ώے����P�O�i�d����j";
        private const string SUPPLIERTOTALDAY11_TITLE = "�����Ώے����P�P�i�d����j";
        private const string SUPPLIERTOTALDAY12_TITLE = "�����Ώے����P�Q�i�d����j";

        private const string TOTALDAY_NGMSG_BETWEEN     = "1���珇�ɊԂ��󂩂Ȃ��悤�ɐݒ肵�ĉ������B";
        private const string TOTALDAY_NGMSG_REPEAT      = "���t���d�����Ȃ��悤�ɐݒ肵�ĉ������B";
        private const string TOTALDAY_NGMSG_DAYS        = "1�`31�͈̔͂Ŏw�肵�ĉ������B";
        private const string TOTALDAY_NGMSG_SMALL       = "�����̐ݒ�l�����傫���l��ݒ肵�ĉ������B";
        // --- ADD 2008/06/13 --------------------------------<<<<< 

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		private const string HTML_HEADER_TITLE    = "�ݒ荀��";
		private const string HTML_HEADER_VALUE    = "�ݒ�l";
	    private const string HTML_UNREGISTER      = "";
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
        // �ҏW���[�h
		private const string INSERT_MODE          = "�V�K���[�h";
		private const string UPDATE_MODE          = "�X�V���[�h";
		private const string DELETE_MODE          = "�폜���[�h";

        // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
        //// ����Œ[�������敪
        //private const string MINUSVARCSTBL_NON    = "�������Ȃ�";
        //private const string MINUSVARCSTBL_1CUT   = "����p���}�C�i�X���ɏ���p�c���O�ɂ���";
        // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

        // ���������敪
		private const string ALLOWANCEPROC_OK     = "����";
		private const string ALLOWANCEPROC_NG     = "�K�{";
		private const string ALLOWANCEPROC_REFER  = "�s��";

        // �����`�[�C���敪
		private const string DEPOSITSLIP_NONREFER = "�C����";
		private const string DEPOSITSLIP_REFER    = "�C���s��";

        //����\��敪
        private const string COLLECTPLNDIV_DIV = "�敪";
        private const string COLLECTPLNDIV_DAY  = "���t";



        // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//        // �O����Z��敪
//        private const string BFRMONCALC_ALL       = "�a������͕��̂ݑO����Ƃ���";
//        private const string BFRMONCALC_DIVIDE    = "�ʏ��������������ƑO����ɐU�蕪����";
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
        // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

		// �ύX�L������p
	    //private BillAllSt chkBillAllSet;
        private BillAllSt _billAllStClone;

		//2005.09.17 enokida ADD MessageBox�Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
		string pgId = "SFUKK09100U";
        string pgNm = "�����S�̐ݒ�";
		//string obj = "BillAllStAcs";  // DEL 2008/06/16
		//2005.09.17 enokida ADD MessageBox�Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

        // ADD 2008/09/16 �s��Ή�[5257] ---------->>>>>
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
        // ADD 2008/09/16 �s��Ή�[5257] ----------<<<<<

		#endregion

		# region Main
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09100UA());
		}
		# endregion

		# region Properties
		/// <summary>
		/// ����v���p�e�B
		/// </summary>
		/// <remarks>
		/// ����\���ǂ����̐ݒ���擾���܂��B�ifalse�Œ�j
		/// </remarks>
		public bool CanPrint
		{
			get{ return _canPrint; }
		}

        // --- ADD 2008/06/13 -------------------------------->>>>>
        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>�V�K�쐬�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�쐬���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

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

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public int Delete()
        {
            return LogicalDelete();
        }
        // --- ADD 2008/06/13 --------------------------------<<<<< 

		/// <summary>
		/// ��ʃN���[�Y�v���p�e�B
		/// </summary>
		/// <remarks>
		/// ��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B
		/// false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B
		/// </remarks>
		public bool CanClose
		{
			get{ return _canClose; }
			set{ _canClose = value; }
		}
		# endregion

		# region Public Methods	
		/// <summary>
		///	�������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note	   :�i�������j</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u����</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = BILLALLST_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCnt">�S�Y������</param>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public int Search(ref int totalCnt, int readCnt)
        {
            return SearchBillAllSt(ref totalCnt, readCnt);
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�茏�����̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public int SearchNext(int readCnt)
        {
            // ������
            return (int)ConstantManagement.DB_Status.ctDB_EOF;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̊e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE,
                new GridColAppearance(MGridColDispType.DeletionDataBoth,
                ContentAlignment.MiddleLeft, "", Color.Red));
            // ���_�R�[�h
            appearanceTable.Add(SECTIONCODE_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_����
            appearanceTable.Add(SECTIONNAME_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ���������敪
            appearanceTable.Add(AllowanceProcCd_Title_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // �����`�[�C���敪
            appearanceTable.Add(DepositSlipMntCd_Title_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            //����\��敪
            appearanceTable.Add(CollectPlnDiv_Title_Label.Text,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleLeft, "", Color.Black));

            // ���Ӑ�����P
            appearanceTable.Add(CUSTOMERTOTALDAY01_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����Q
            appearanceTable.Add(CUSTOMERTOTALDAY02_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����R
            appearanceTable.Add(CUSTOMERTOTALDAY03_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����S
            appearanceTable.Add(CUSTOMERTOTALDAY04_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����T
            appearanceTable.Add(CUSTOMERTOTALDAY05_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����U
            appearanceTable.Add(CUSTOMERTOTALDAY06_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����V
            appearanceTable.Add(CUSTOMERTOTALDAY07_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����W
            appearanceTable.Add(CUSTOMERTOTALDAY08_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����X
            appearanceTable.Add(CUSTOMERTOTALDAY09_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����P�O
            appearanceTable.Add(CUSTOMERTOTALDAY10_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����P�P
            appearanceTable.Add(CUSTOMERTOTALDAY11_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // ���Ӑ�����P�Q
            appearanceTable.Add(CUSTOMERTOTALDAY12_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������P
            appearanceTable.Add(SUPPLIERTOTALDAY01_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������Q
            appearanceTable.Add(SUPPLIERTOTALDAY02_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������R
            appearanceTable.Add(SUPPLIERTOTALDAY03_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������S
            appearanceTable.Add(SUPPLIERTOTALDAY04_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������T
            appearanceTable.Add(SUPPLIERTOTALDAY05_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������U
            appearanceTable.Add(SUPPLIERTOTALDAY06_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������V
            appearanceTable.Add(SUPPLIERTOTALDAY07_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������W
            appearanceTable.Add(SUPPLIERTOTALDAY08_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������X
            appearanceTable.Add(SUPPLIERTOTALDAY09_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������P�O
            appearanceTable.Add(SUPPLIERTOTALDAY10_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������P�P
            appearanceTable.Add(SUPPLIERTOTALDAY11_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // �d��������P�Q
            appearanceTable.Add(SUPPLIERTOTALDAY12_TITLE,
                new GridColAppearance(MGridColDispType.Both,
                ContentAlignment.MiddleRight, "", Color.Black));

            // GUID
            appearanceTable.Add(GUID_TITLE,
                new GridColAppearance(MGridColDispType.None,
                ContentAlignment.MiddleLeft, "", Color.Black));

            return appearanceTable;
        }

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>
		///	HTML�R�[�h�擾����
		/// </summary>
		/// <returns>HTML�R�[�h</returns>
		/// <remarks>
		/// <br>Note	   : �r���[�p�̂g�s�l�k�R�[�h���擾���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		public string GetHtmlCode()
		{
			string outCode = "";

            // tHtmlGenerate���i�̈����𐶐�����
            // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            string[,] array = new string[3, 2];
            // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            string [,] array = new string[5,2];
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
// 2006.06.01 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//string [,] array = new string[4,2];
// 2006.06.01 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		
			this.tHtmlGenerate1.Coltypes = new int[2];
			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
			
			array[0,0] = HTML_HEADER_TITLE;                              //�u�ݒ荀�ځv
			array[0,1] = HTML_HEADER_VALUE;                              //�u�ݒ�l�v
            // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			array[1,0] = this.AllowanceProcCd_Title_Label.Text;          // ���������敪
            array[2,0] = this.DepositSlipMntCd_Title_Label.Text;         // �����`�[�C���敪
            // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            array[1,0] = this.MinusVarCstBlAdjstCd_Title_Label.Text;     // �}�C�i�X����p�c�������敪
//            array[2,0] = this.AllowanceProcCd_Title_Label.Text;          // ���������敪
//            array[3,0] = this.DepositSlipMntCd_Title_Label.Text;         // �����`�[�C���敪
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            array[4,0] = this.BfRmonCalcDivCd_Title_Label.Text;          // �O����Z��敪
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

            int status = this._billAllStAcs.Read(out this._billAllSt, this._enterPriseCode);
			if (status == 0)
            {
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				switch(this._billAllSt.AllowanceProcCd)
				{	
					case 0:
						array[1,1] = ALLOWANCEPROC_OK;        //"����"
						break;
					case 1:
						array[1,1] = ALLOWANCEPROC_NG;        //"�K�{"
						break;
					case 2:
						array[1,1] = ALLOWANCEPROC_REFER;     //"�s��"
						break;
					default:
						array[1,1] = HTML_UNREGISTER;
						break;
				}
                switch(this._billAllSt.DepositSlipMntCd)
				{
					case 0:
						array[2,1] = DEPOSITSLIP_NONREFER;    //"�C����"
						break;
					case 1:
						array[2,1] = DEPOSITSLIP_REFER;       //"�C���s��"
						break;
					default:
						array[2,1] = HTML_UNREGISTER;
						break;
                }
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                switch(billAllSet.MinusVarCstBlAdjstCd)
//                {
//                    case 0:
//                        array[1,1] = MINUSVARCSTBL_NON;       // "�������Ȃ�"
//                        break;
//                    case 1:
//                        array[1,1] = MINUSVARCSTBL_1CUT;      //"����p�c��ϲŽ���ɏ���p�c��0�ɂ���"
//                        break;
//                    default:
//                        array[1,1] = HTML_UNREGISTER;
//                        break;

//                }
//                switch(billAllSet.AllowanceProcCd)
//                {	
//                    case 0:
//                        array[2,1] = ALLOWANCEPROC_OK;        //"����"
//                        break;
//                    case 1:
//                        array[2,1] = ALLOWANCEPROC_NG;        //"�K�{"
//                        break;
//                    case 2:
//                        array[2,1] = ALLOWANCEPROC_REFER;     //"�s��"
//                        break;
//                    default:
//                        array[2,1] = HTML_UNREGISTER;
//                        break;
//                }
//                switch(billAllSet.DepositSlipMntCd)
//                {
//                    case 0:
//                        array[3,1] = DEPOSITSLIP_NONREFER;    //"�C����"
//                        break;
//                    case 1:
//                        array[3,1] = DEPOSITSLIP_REFER;       //"�C���s��"
//                        break;
//                    default:
//                        array[3,1] = HTML_UNREGISTER;
//                        break;
//                }
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                switch( billAllSet.BfRmonCalcDivCd ) {
//                    case 0:
//                    {
//                        array[ 4, 1 ] = BFRMONCALC_ALL;     // �a����͑S�đO����Ƃ���
//                        break;
//                    }
//                    case 1:
//                    {
//                        array[ 4, 1 ] = BFRMONCALC_DIVIDE;  // �����I�ɍ�������ƑO����ɐU�蕪����
//                        break;
//                    }
//                    default:
//                    {
//                        array[ 4, 1 ] = HTML_UNREGISTER;
//                        break;
//                    }
//                }
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			}
			else
			{
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				array[1,1] = HTML_UNREGISTER;
                array[2,1] = HTML_UNREGISTER;
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                array[1,1] = HTML_UNREGISTER;
//                array[2,1] = HTML_UNREGISTER;
//                array[3,1] = HTML_UNREGISTER;
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                array[ 4, 1 ] = HTML_UNREGISTER;
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			}

			// �f�[�^�̂Q�����z��݂̂��w�肵�āA�v���p�e�B���g�p���ăO���b�h�\������
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);
			return outCode;
		}
           --- DEL 2008/06/13 --------------------------------<<<<< */
        # endregion

        # region private Methods

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable billAllStTable = new DataTable(BILLALLST_TABLE);
            billAllStTable.Columns.Add(DELETE_DATE, typeof(string));

            billAllStTable.Columns.Add(SECTIONCODE_TITLE, typeof(string));
            billAllStTable.Columns.Add(SECTIONNAME_TITLE, typeof(string));
            billAllStTable.Columns.Add(AllowanceProcCd_Title_Label.Text, typeof(string));   // ���������敪
            billAllStTable.Columns.Add(DepositSlipMntCd_Title_Label.Text, typeof(string));  // �����`�[�C���敪
            billAllStTable.Columns.Add(CollectPlnDiv_Title_Label.Text, typeof(string));  // ����\��敪

            billAllStTable.Columns.Add(CUSTOMERTOTALDAY01_TITLE, typeof(string));   // ���Ӑ�����P
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY02_TITLE, typeof(string));   // ���Ӑ�����Q
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY03_TITLE, typeof(string));   // ���Ӑ�����R
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY04_TITLE, typeof(string));   // ���Ӑ�����S
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY05_TITLE, typeof(string));   // ���Ӑ�����T
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY06_TITLE, typeof(string));   // ���Ӑ�����U
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY07_TITLE, typeof(string));   // ���Ӑ�����V
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY08_TITLE, typeof(string));   // ���Ӑ�����W
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY09_TITLE, typeof(string));   // ���Ӑ�����X
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY10_TITLE, typeof(string));   // ���Ӑ�����P�O
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY11_TITLE, typeof(string));   // ���Ӑ�����P�P
            billAllStTable.Columns.Add(CUSTOMERTOTALDAY12_TITLE, typeof(string));   // ���Ӑ�����P�Q

            billAllStTable.Columns.Add(SUPPLIERTOTALDAY01_TITLE, typeof(string));   // �d��������P
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY02_TITLE, typeof(string));   // �d��������Q
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY03_TITLE, typeof(string));   // �d��������R
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY04_TITLE, typeof(string));   // �d��������S
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY05_TITLE, typeof(string));   // �d��������T
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY06_TITLE, typeof(string));   // �d��������U
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY07_TITLE, typeof(string));   // �d��������V
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY08_TITLE, typeof(string));   // �d��������W
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY09_TITLE, typeof(string));   // �d��������X
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY10_TITLE, typeof(string));   // �d��������P�O
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY11_TITLE, typeof(string));   // �d��������P�P
            billAllStTable.Columns.Add(SUPPLIERTOTALDAY12_TITLE, typeof(string));   // �d��������P�Q

            billAllStTable.Columns.Add(GUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(billAllStTable);
        }

        /// <summary>
		///	��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note	�@ : ��ʂ̏����ݒ���s���܂�(�����ޯ���ɌŒ�lADD)</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
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

            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            ////�}�C�i�X����p�c�������敪�̺����ޯ���ɏ��Z�b�g
            //MinusVarCstBlAdjstCd_tComboEditor.Items.Clear();                    
            //MinusVarCstBlAdjstCd_tComboEditor.Items.Add(0,MINUSVARCSTBL_NON);    //�������Ȃ�
            //MinusVarCstBlAdjstCd_tComboEditor.Items.Add(1,MINUSVARCSTBL_1CUT);   //����p�c��ϲŽ���ɏ���p�c��0�ɂ���

            //MinusVarCstBlAdjstCd_tComboEditor.MaxDropDownItems = MinusVarCstBlAdjstCd_tComboEditor.Items.Count;
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			
			//���������敪�̺����ޯ���ɏ��Z�b�g
			AllowanceProcCd_tComboEditor.Items.Clear();
			AllowanceProcCd_tComboEditor.Items.Add(0,ALLOWANCEPROC_OK);          //����
			AllowanceProcCd_tComboEditor.Items.Add(1,ALLOWANCEPROC_NG);          //�K�{
			AllowanceProcCd_tComboEditor.Items.Add(2,ALLOWANCEPROC_REFER);       //�s��
			AllowanceProcCd_tComboEditor.MaxDropDownItems = AllowanceProcCd_tComboEditor.Items.Count;
			
			//�����`�[�C���敪�̺����ޯ���ɏ��Z�b�g
			DepositSlipMntCd_tComboEditor.Items.Clear();
			DepositSlipMntCd_tComboEditor.Items.Add(0,DEPOSITSLIP_NONREFER);     //�C����
			DepositSlipMntCd_tComboEditor.Items.Add(1,DEPOSITSLIP_REFER);        //�C���s��
			DepositSlipMntCd_tComboEditor.MaxDropDownItems = DepositSlipMntCd_tComboEditor.Items.Count;

            //����\��敪�̺����ޯ���ɏ��Z�b�g
            CollectPlnDiv_tComboEditor.Items.Clear();
            CollectPlnDiv_tComboEditor.Items.Add(0, COLLECTPLNDIV_DIV);     //�敪
            CollectPlnDiv_tComboEditor.Items.Add(1, COLLECTPLNDIV_DAY);        //���t
            CollectPlnDiv_tComboEditor.MaxDropDownItems = CollectPlnDiv_tComboEditor.Items.Count;

            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            this.BfRmonCalcDivCd_tComboEditor.Items.Clear();
//            this.BfRmonCalcDivCd_tComboEditor.Items.Add( 0, BFRMONCALC_ALL );    // �a����͑S�đO����Ƃ���
//            this.BfRmonCalcDivCd_tComboEditor.Items.Add( 1, BFRMONCALC_DIVIDE ); // �����I�ɍ�������ƑO����ɐU�蕪����
//            this.BfRmonCalcDivCd_tComboEditor.MaxDropDownItems = this.BfRmonCalcDivCd_tComboEditor.Items.Count;
//// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
		}
	
		/// <summary>
		///	��ʏ��ː����S�̐ݒ�ݒ�N���X�i�[����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʏ�񂩂琿���S�̐ݒ�N���X�Ƀf�[�^��
		///					 �i�[���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
		/// </remarks>
        private void ScreenToBillAllSt(ref BillAllSt billAllSt)
		{
            if (billAllSt == null)
            {
                billAllSt = new BillAllSt();
            }

            billAllSt.EnterpriseCode = this._enterPriseCode;			                 // ��ƃR�[�h
            billAllSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText.Trim();     // ���_�R�[�h
            // ADD 2008/09/19 �s��Ή��ɂ�鋤�ʎd�l�̓W�J ---------->>>>>
            // uiSetControl��""�̂Ƃ�"00"��ݒ肷��̂ŁA�f�t�H���g�l��"00"�Ƃ���
            if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd()))
            {
                billAllSt.SectionCode = SectionUtil.ALL_SECTION_CODE;
            }
            // ADD 2008/09/19 �s��Ή��ɂ�鋤�ʎd�l�̓W�J ----------<<<<<

            billAllSt.AllowanceProcCd  = (int)this.AllowanceProcCd_tComboEditor.Value;   // ���������敪
            billAllSt.DepositSlipMntCd = (int)this.DepositSlipMntCd_tComboEditor.Value;  // �����`�[�C���敪
            billAllSt.CollectPlnDiv = (int)this.CollectPlnDiv_tComboEditor.Value;  �@�@�@// ����\��敪
            
            // ���Ӑ�����P
            if(this.CustomerTotalDay1_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay1 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay1 = Int32.Parse(this.CustomerTotalDay1_tEdit.DataText);    
            }

            // ���Ӑ�����Q
            if (this.CustomerTotalDay2_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay2 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay2 = Int32.Parse(this.CustomerTotalDay2_tEdit.DataText);    
            }

            // ���Ӑ�����R
            if (this.CustomerTotalDay3_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay3 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay3 = Int32.Parse(this.CustomerTotalDay3_tEdit.DataText);    
            }

            // ���Ӑ�����S
            if (this.CustomerTotalDay4_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay4 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay4 = Int32.Parse(this.CustomerTotalDay4_tEdit.DataText);    
            }

            // ���Ӑ�����T
            if (this.CustomerTotalDay5_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay5 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay5 = Int32.Parse(this.CustomerTotalDay5_tEdit.DataText);    
            }

            // ���Ӑ�����U
            if (this.CustomerTotalDay6_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay6 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay6 = Int32.Parse(this.CustomerTotalDay6_tEdit.DataText);    
            }

            // ���Ӑ�����V
            if (this.CustomerTotalDay7_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay7 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay7 = Int32.Parse(this.CustomerTotalDay7_tEdit.DataText);   
            }

            // ���Ӑ�����W
            if (this.CustomerTotalDay8_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay8 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay8 = Int32.Parse(this.CustomerTotalDay8_tEdit.DataText);    
            }

            // ���Ӑ�����X
            if (this.CustomerTotalDay9_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay9 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay9 = Int32.Parse(this.CustomerTotalDay9_tEdit.DataText);    
            }

            // ���Ӑ�����P�O
            if (this.CustomerTotalDay10_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay10 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay10 = Int32.Parse(this.CustomerTotalDay10_tEdit.DataText);  
            }

            // ���Ӑ�����P�P
            if (this.CustomerTotalDay11_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay11 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay11 = Int32.Parse(this.CustomerTotalDay11_tEdit.DataText);  
            }

            // ���Ӑ�����P�Q
            if (this.CustomerTotalDay12_tEdit.DataText == "")
            {
                billAllSt.CustomerTotalDay12 = 0;
            }
            else
            {
                billAllSt.CustomerTotalDay12 = Int32.Parse(this.CustomerTotalDay12_tEdit.DataText);  
            }

            // �d��������P
            if (this.SupplierTotalDay1_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay1 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay1 = Int32.Parse(this.SupplierTotalDay1_tEdit.DataText);    
            }

            // �d��������Q
            if (this.SupplierTotalDay2_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay2 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay2 = Int32.Parse(this.SupplierTotalDay2_tEdit.DataText);    
            }

            // �d��������R
            if (this.SupplierTotalDay3_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay3 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay3 = Int32.Parse(this.SupplierTotalDay3_tEdit.DataText);    
            }

            // �d��������S
            if (this.SupplierTotalDay4_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay4 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay4 = Int32.Parse(this.SupplierTotalDay4_tEdit.DataText);    
            }

            // �d��������T
            if (this.SupplierTotalDay5_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay5 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay5 = Int32.Parse(this.SupplierTotalDay5_tEdit.DataText);    
            }

            // �d��������U
            if (this.SupplierTotalDay6_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay6 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay6 = Int32.Parse(this.SupplierTotalDay6_tEdit.DataText);    
            }

            // �d��������V
            if (this.SupplierTotalDay7_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay7 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay7 = Int32.Parse(this.SupplierTotalDay7_tEdit.DataText);    
            }

            // �d��������W
            if (this.SupplierTotalDay8_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay8 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay8 = Int32.Parse(this.SupplierTotalDay8_tEdit.DataText);    
            }

            // �d��������X
            if (this.SupplierTotalDay9_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay9 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay9 = Int32.Parse(this.SupplierTotalDay9_tEdit.DataText);    
            }

            // �d��������P�O
            if (this.SupplierTotalDay10_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay10 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay10 = Int32.Parse(this.SupplierTotalDay10_tEdit.DataText);  
            }

            // �d��������P�P
            if (this.SupplierTotalDay11_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay11 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay11 = Int32.Parse(this.SupplierTotalDay11_tEdit.DataText);  
            }

            // �d��������P�Q
            if (this.SupplierTotalDay12_tEdit.DataText == "")
            {
                billAllSt.SupplierTotalDay12 = 0;
            }
            else
            {
                billAllSt.SupplierTotalDay12 = Int32.Parse(this.SupplierTotalDay12_tEdit.DataText);  
            }

		}

		/// <summary>
		///	�����S�̐ݒ��ʓW�J����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : �����S�̐ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
		/// </remarks>
        private void BillAllStToScreen(BillAllSt billAllSt)
		{
            this.tEdit_SectionCodeAllowZero2.Value = billAllSt.SectionCode;  // ���_�R�[�h
            // ���_����
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == billAllSt.SectionCode.TrimEnd())
                {
                    this.SectionNm_tEdit.Value = si.SectionGuideNm;
                    break;
                }
            }
            // ADD 2008/10/10 �s��Ή�[6445] ---------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.Text.Trim().Equals("00"))
            {
                this.SectionNm_tEdit.Text = "�S�Ћ���";
            }
            // ADD 2008/10/10 �s��Ή�[6445] ----------<<<<<

            this.AllowanceProcCd_tComboEditor.Value = billAllSt.AllowanceProcCd;               // ���������敪
            this.DepositSlipMntCd_tComboEditor.Value = billAllSt.DepositSlipMntCd;             // �����`�[�C���敪
            this.CollectPlnDiv_tComboEditor.Value = billAllSt.CollectPlnDiv;        �@�@�@�@   // ����\��敪
            this.CustomerTotalDay1_tEdit.DataText = billAllSt.CustomerTotalDay1.ToString();    // ���Ӑ�����P
            this.CustomerTotalDay2_tEdit.DataText = billAllSt.CustomerTotalDay2.ToString();    // ���Ӑ�����Q
            this.CustomerTotalDay3_tEdit.DataText = billAllSt.CustomerTotalDay3.ToString();    // ���Ӑ�����R
            this.CustomerTotalDay4_tEdit.DataText = billAllSt.CustomerTotalDay4.ToString();    // ���Ӑ�����S
            this.CustomerTotalDay5_tEdit.DataText = billAllSt.CustomerTotalDay5.ToString();    // ���Ӑ�����T
            this.CustomerTotalDay6_tEdit.DataText = billAllSt.CustomerTotalDay6.ToString();    // ���Ӑ�����U
            this.CustomerTotalDay7_tEdit.DataText = billAllSt.CustomerTotalDay7.ToString();    // ���Ӑ�����V
            this.CustomerTotalDay8_tEdit.DataText = billAllSt.CustomerTotalDay8.ToString();    // ���Ӑ�����W
            this.CustomerTotalDay9_tEdit.DataText = billAllSt.CustomerTotalDay9.ToString();    // ���Ӑ�����X
            this.CustomerTotalDay10_tEdit.DataText = billAllSt.CustomerTotalDay10.ToString();  // ���Ӑ�����P�O
            this.CustomerTotalDay11_tEdit.DataText = billAllSt.CustomerTotalDay11.ToString();  // ���Ӑ�����P�P
            this.CustomerTotalDay12_tEdit.DataText = billAllSt.CustomerTotalDay12.ToString();  // ���Ӑ�����P�Q
            this.SupplierTotalDay1_tEdit.DataText = billAllSt.SupplierTotalDay1.ToString();    // �d��������P
            this.SupplierTotalDay2_tEdit.DataText = billAllSt.SupplierTotalDay2.ToString();    // �d��������Q
            this.SupplierTotalDay3_tEdit.DataText = billAllSt.SupplierTotalDay3.ToString();    // �d��������R
            this.SupplierTotalDay4_tEdit.DataText = billAllSt.SupplierTotalDay4.ToString();    // �d��������S
            this.SupplierTotalDay5_tEdit.DataText = billAllSt.SupplierTotalDay5.ToString();    // �d��������T
            this.SupplierTotalDay6_tEdit.DataText = billAllSt.SupplierTotalDay6.ToString();    // �d��������U
            this.SupplierTotalDay7_tEdit.DataText = billAllSt.SupplierTotalDay7.ToString();    // �d��������V
            this.SupplierTotalDay8_tEdit.DataText = billAllSt.SupplierTotalDay8.ToString();    // �d��������W
            this.SupplierTotalDay9_tEdit.DataText = billAllSt.SupplierTotalDay9.ToString();    // �d��������X
            this.SupplierTotalDay10_tEdit.DataText = billAllSt.SupplierTotalDay10.ToString();  // �d��������P�O
            this.SupplierTotalDay11_tEdit.DataText = billAllSt.SupplierTotalDay11.ToString();  // �d��������P�P
            this.SupplierTotalDay12_tEdit.DataText = billAllSt.SupplierTotalDay12.ToString();  // �d��������P�Q
		}
		
		/// <summary>
		///	�����S�̐ݒ��ʏ���������
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʏ������������܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void ScreenClear()
        {
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //this.MinusVarCstBlAdjstCd_tComboEditor.Value = 0;
            // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			this.AllowanceProcCd_tComboEditor.SelectedIndex = 0;
			this.DepositSlipMntCd_tComboEditor.SelectedIndex = 0;
            this.CollectPlnDiv_tComboEditor.SelectedIndex = 0;


            // --- ADD 2008/06/13 -------------------------------->>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();     // ���_�R�[�h
            this.SectionNm_tEdit.Clear();                // ���_�K�C�h����

            this.CustomerTotalDay1_tEdit.Clear();        // ���Ӑ�����P
            this.CustomerTotalDay2_tEdit.Clear();        // ���Ӑ�����Q
            this.CustomerTotalDay3_tEdit.Clear();        // ���Ӑ�����R
            this.CustomerTotalDay4_tEdit.Clear();        // ���Ӑ�����S
            this.CustomerTotalDay5_tEdit.Clear();        // ���Ӑ�����T
            this.CustomerTotalDay6_tEdit.Clear();        // ���Ӑ�����U
            this.CustomerTotalDay7_tEdit.Clear();        // ���Ӑ�����V
            this.CustomerTotalDay8_tEdit.Clear();        // ���Ӑ�����W
            this.CustomerTotalDay9_tEdit.Clear();        // ���Ӑ�����X
            this.CustomerTotalDay10_tEdit.Clear();       // ���Ӑ�����P�O
            this.CustomerTotalDay11_tEdit.Clear();       // ���Ӑ�����P�P
            this.CustomerTotalDay12_tEdit.Clear();       // ���Ӑ�����P�Q

            this.SupplierTotalDay1_tEdit.Clear();        // �d��������P
            this.SupplierTotalDay2_tEdit.Clear();        // �d��������Q
            this.SupplierTotalDay3_tEdit.Clear();        // �d��������R
            this.SupplierTotalDay4_tEdit.Clear();        // �d��������S
            this.SupplierTotalDay5_tEdit.Clear();        // �d��������T
            this.SupplierTotalDay6_tEdit.Clear();        // �d��������U
            this.SupplierTotalDay7_tEdit.Clear();        // �d��������V
            this.SupplierTotalDay8_tEdit.Clear();        // �d��������W
            this.SupplierTotalDay9_tEdit.Clear();        // �d��������X
            this.SupplierTotalDay10_tEdit.Clear();       // �d��������P�O
            this.SupplierTotalDay11_tEdit.Clear();       // �d��������P�P
            this.SupplierTotalDay12_tEdit.Clear();       // �d��������P�Q
            // --- ADD 2008/06/13 --------------------------------<<<<< 
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            /* --- DEL 2008/06/13 -------------------------------->>>>>
            int status = this._billAllStAcs.Read(out this._billAllSt, this._enterPriseCode);
			if (status == 0)
			{
				Mode_Label.Text = UPDATE_MODE;
				// �S�̏����\���ݒ�N���X��ʓW�J����
				billAllSetToScreen();

                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                AllowanceProcCd_tComboEditor.Focus();
                // 2006.12.13 DANJO ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                //MinusVarCstBlAdjstCd_tComboEditor.Focus();
                // 2006.12.13 DANJO DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
			}
			else
			{
				Mode_Label.Text = INSERT_MODE;
			}   
			//��ʂɕ\������������U�f�[�^�N���X�ɃZ�b�g
			ScreenTobillAllSet();
			//�ǂݏo�����f�[�^�̃N���[���쐬
            this._billAllStClone = this._billAllSt.Clone();

			return;
               --- DEL 2008/06/13 --------------------------------<<<<< */

            // --- ADD 2008/06/13 -------------------------------->>>>>
            if (this._dataIndex < 0)
            {
                // �V�K���[�h
                this._logicalDeleteMode = -1;

                BillAllSt newBillAllSt = new BillAllSt();

                // �����S�̐ݒ�I�u�W�F�N�g����ʂɓW�J
                BillAllStToScreen(newBillAllSt);

                // �N���[���쐬
                this._billAllStClone = newBillAllSt.Clone();
                ScreenToBillAllSt(ref this._billAllStClone);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                BillAllSt billAllSt = (BillAllSt)this._billAllStTable[guid];

                // �����S�̐ݒ�I�u�W�F�N�g����ʂɓW�J
                BillAllStToScreen(billAllSt);

                if (billAllSt.LogicalDeleteCode == 0)
                {
                    // �X�V���[�h
                    this._logicalDeleteMode = 0;

                    // �N���[���쐬
                    this._billAllStClone = billAllSt.Clone();
                    ScreenToBillAllSt(ref this._billAllStClone);
                }
                else
                {
                    // �폜���[�h
                    this._logicalDeleteMode = 1;
                }
            }
            // _GridIndex�o�b�t�@�ێ��i���C���t���[���ŏ����Ή��j
            this._indexBuf = this._dataIndex;

            ScreenInputPermissionControl();
            // --- ADD 2008/06/13 --------------------------------<<<<< 
		}
    
		/// <summary>
		/// �f�[�^�ۑ���������
		/// </summary>
		/// <returns>�ۑ����ʁitrue:OK�^false:�G���[�݂�j</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�̓o�^�X�V�������s���܂�</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
		/// </remarks>
		private bool DataSaveProc()
		{
            bool result = false;

            // ���̓`�F�b�N
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
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

            BillAllSt billAllSt = null;
            if (this._dataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
                billAllSt = ((BillAllSt)this._billAllStTable[guid]).Clone();
            }
            ScreenToBillAllSt(ref billAllSt);

            // ADD 2008/09/19 �s��Ή��ɂ�鋤�ʎd�l�̓W�J ---------->>>>>
            // ���_�R�[�h�����݂��Ă��Ȃ��ꍇ�A�o�^���Ȃ��B
            if (!SectionUtil.ExistsCode(billAllSt.SectionCode))
            {
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0'); // 2011/09/07 
                TMsgDisp.Show(
                    this, 								                    // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,                     // �G���[���x��
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text, 		                                        // �v���O��������
                    MethodBase.GetCurrentMethod().Name, 					// ��������
                    TMsgDisp.OPE_UPDATE, 				                    // �I�y���[�V����
                    SectionUtil.MSG_SECTION_CODE_IS_NOT_FOUND,              // �\�����郁�b�Z�[�W
                    (int)ConstantManagement.MethodResult.ctFNC_NORMAL, 		// �X�e�[�^�X�l
                    this,			                                        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 				                    // �\������{�^��
                    MessageBoxDefaultButton.Button1                         // �����\���{�^��
                );
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.tEdit_SectionCodeAllowZero2.Focus();
                // --- ADD 2011/09/07 --------------------------------<<<<<
                return false;

            }
            // ADD 2008/09/19 �s��Ή��ɂ�鋤�ʎd�l�̓W�J ----------<<<<<
            // ----- ADD 2011/09/08 ---------->>>>>
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
            // ----- ADD 2011/09/08 ----------<<<<<

            int status = this._billAllStAcs.Write(ref billAllSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // VIEW�̃f�[�^�Z�b�g���X�V
                        BillAllStToDataSet(billAllSt.Clone(), this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this, 									// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                            pgId, 							// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B", 	// �\�����郁�b�Z�[�W
                            0, 										// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        tEdit_SectionCodeAllowZero2.Focus();                 
                        return result;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            pgNm, 					            // �v���O��������
                            "SaveProc", 						// ��������
                            TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._billAllStAcs,			        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return result;
                    }
            }

            result = true;
            return result;
		}
    
        /// <summary>
        /// �����S�̐ݒ�I�u�W�F�N�g�_���폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�I�u�W�F�N�g�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private int LogicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            BillAllSt billAllSt = ((BillAllSt)this._billAllStTable[guid]).Clone();

            // �����S�̐ݒ肪���݂��Ă��Ȃ�
            if (billAllSt == null)
            {
                return -1;
            }

            // ADD 2008/09/17 �s��Ή�[5288] ---------->>>>>
            // ���_�R�[�h���S�Ћ��ʂ̏ꍇ�A�폜�s��
            if (IsAllSection(billAllSt))
            {
                TMsgDisp.Show(
                    this, 							                        // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO, 	                        // �G���[���x��
                    AssemblyUtil.GetName(Assembly.GetExecutingAssembly()),  // �A�Z���u���h�c�܂��̓N���X�h�c
                    this.Text, 				                                // �v���O��������
                    MethodBase.GetCurrentMethod().Name,                     // ��������
                    TMsgDisp.OPE_HIDE, 				                        // TODO:�I�y���[�V����
                    SectionUtil.MSG_ALL_SECTION_CANNOT_BE_DELETED, 	        // �\�����郁�b�Z�[�W
                    status, 						                        // �X�e�[�^�X�l
                    this,			                                        // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK, 			                        // �\������{�^��
                    MessageBoxDefaultButton.Button1                         // �����\���{�^��
                );
                return status;
            }
            // ADD 2008/09/17 �s��Ή�[5288] ----------<<<<<

            status = this._billAllStAcs.LogicalDelete(ref billAllSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        BillAllStToDataSet(billAllSt.Clone(), this._dataIndex);
                        break;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            pgNm, 				                // �v���O��������
                            "LogicalDelete", 					// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._billAllStAcs,			        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        return status;
                    }
            }
            return status;
        }

        // ADD 2008/09/17 �s��Ή�[5288] ---------->>>>>
        /// <summary>
        /// �S�Аݒ肩���肵�܂��B
        /// </summary>
        /// <param name="billAllSt">�����S�̐ݒ�</param>
        /// <returns><c>true</c> :�S�Аݒ�ł���B<br/><c>false</c>:�S�Аݒ�ł͂Ȃ��B</returns>
        /// <remarks>
        /// <br>Note       : �s��Ή�[5288]�ɂĒǉ�</br>
        /// <br>Programmer : 30434 �H�� �b�D</br>
        /// <br>Date       : 2008/09/17</br>
        /// </remarks>
        private static bool IsAllSection(BillAllSt billAllSt)
        {
            return SectionUtil.IsAllSection(billAllSt.SectionCode);
        }
        // ADD 2008/09/17 �s��Ή�[5288] ----------<<<<<

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCnt">�S�Y������</param>
        /// <param name="readCnt">���o�Ώی���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^���������A���o���ʂ�W�J�����f�[�^�Z�b�g�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private int SearchBillAllSt(ref int totalCnt, int readCnt)
        {
            int status = 0;
            ArrayList billAllSts = null;

            // ���o�Ώی�����0���̏ꍇ�͑S�����o�����s����
            status = this._billAllStAcs.SearchAll(out billAllSts, this._enterPriseCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach (BillAllSt billAllSt in billAllSts)
                        {
                            if (this._billAllStTable.ContainsKey(billAllSt.FileHeaderGuid) == false)
                            {
                                BillAllStToDataSet(billAllSt.Clone(), index);
                                index++;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        break;
                    }
                default:
                    {
                        // �T�[�`
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            pgNm, 			                    // �v���O��������
                            "SearchBillAllSt", 			        // ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._billAllStAcs, 		     	// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }

            totalCnt = billAllSts.Count;

            return status;
        }

        /// <summary>
        /// �����S�̐ݒ�I�u�W�F�N�g�W�J����
        /// </summary>
        /// <param name="billAllSt">�����S�̐ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�N���X��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void BillAllStToDataSet(BillAllSt billAllSt, int index)
        {
            string wrkstr;

            if ((index < 0) || (index >= this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count))
            {
                // �V�K�Ɣ��f���A�s��ǉ�����B
                DataRow dataRow = this.Bind_DataSet.Tables[BILLALLST_TABLE].NewRow();
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Add(dataRow);

                // index���ŏI�s�ԍ��ɂ���
                index = this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count - 1;
            }

            // �폜��
            if (billAllSt.LogicalDeleteCode == 0)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][DELETE_DATE] = billAllSt.UpdateDateTime;
            }

            // ���_�R�[�h
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SECTIONCODE_TITLE] = billAllSt.SectionCode.TrimEnd();
            // ���_����
            foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            {
                if (si.SectionCode.TrimEnd() == billAllSt.SectionCode.TrimEnd())
                {
                    this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SECTIONNAME_TITLE] = si.SectionGuideNm;
                    break;
                }
            }
            
            // ADD 2008/10/09 �s��Ή�[6445] ---------->>>>>
            if (billAllSt.SectionCode.Trim().Equals("00"))
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SECTIONNAME_TITLE] = "�S�Ћ���";
            }
            // ADD 2008/10/09 �s��Ή�[6445] ----------<<<<<

            // ���������敪
            switch (billAllSt.AllowanceProcCd)
            {
                case 0:
                    wrkstr = ALLOWANCEPROC_OK;          // ����
                    break;
                case 1:
                    wrkstr = ALLOWANCEPROC_NG;          // �K�{
                    break;
                case 2:
                    wrkstr = ALLOWANCEPROC_REFER;       // �s��
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][AllowanceProcCd_Title_Label.Text] = wrkstr;

            // �����`�[�C���敪
            switch (billAllSt.DepositSlipMntCd)
            {
                case 0:
                    wrkstr = DEPOSITSLIP_NONREFER;       // �C����
                    break;
                case 1:
                    wrkstr = DEPOSITSLIP_REFER;          // �C���s��
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][DepositSlipMntCd_Title_Label.Text] = wrkstr;


            // ����\��敪
            switch (billAllSt.CollectPlnDiv)
            {
                case 0:
                    wrkstr = COLLECTPLNDIV_DIV;       // �敪
                    break;
                case 1:
                    wrkstr = COLLECTPLNDIV_DAY;          // ���t
                    break;
                default:
                    wrkstr = UNREGISTER;
                    break;
            }
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CollectPlnDiv_Title_Label.Text] = wrkstr;



            // ���Ӑ�����P
            if (0 == billAllSt.CustomerTotalDay1)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY01_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY01_TITLE] = billAllSt.CustomerTotalDay1;
            }

            // ���Ӑ�����Q
            if (0 == billAllSt.CustomerTotalDay2)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY02_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY02_TITLE] = billAllSt.CustomerTotalDay2;
            }

            // ���Ӑ�����R
            if (0 == billAllSt.CustomerTotalDay3)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY03_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY03_TITLE] = billAllSt.CustomerTotalDay3;
            }

            // ���Ӑ�����S
            if (0 == billAllSt.CustomerTotalDay4)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY04_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY04_TITLE] = billAllSt.CustomerTotalDay4;
            }

            // ���Ӑ�����T
            if (0 == billAllSt.CustomerTotalDay5)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY05_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY05_TITLE] = billAllSt.CustomerTotalDay5;
            }

            // ���Ӑ�����U
            if (0 == billAllSt.CustomerTotalDay6)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY06_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY06_TITLE] = billAllSt.CustomerTotalDay6;
            }

            // ���Ӑ�����V
            if (0 == billAllSt.CustomerTotalDay7)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY07_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY07_TITLE] = billAllSt.CustomerTotalDay7;
            }

            // ���Ӑ�����W
            if (0 == billAllSt.CustomerTotalDay8)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY08_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY08_TITLE] = billAllSt.CustomerTotalDay8;
            }

            // ���Ӑ�����X
            if (0 == billAllSt.CustomerTotalDay9)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY09_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY09_TITLE] = billAllSt.CustomerTotalDay9;
            }

            // ���Ӑ�����P�O
            if (0 == billAllSt.CustomerTotalDay10)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY10_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY10_TITLE] = billAllSt.CustomerTotalDay10;
            }

            // ���Ӑ�����P�P
            if (0 == billAllSt.CustomerTotalDay11)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY11_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY11_TITLE] = billAllSt.CustomerTotalDay11;
            }

            // ���Ӑ�����P�Q
            if (0 == billAllSt.CustomerTotalDay12)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY12_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][CUSTOMERTOTALDAY12_TITLE] = billAllSt.CustomerTotalDay12;
            }

            // �d��������P
            if (0 == billAllSt.SupplierTotalDay1)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY01_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY01_TITLE] = billAllSt.SupplierTotalDay1;
            }

            // �d��������Q
            if (0 == billAllSt.SupplierTotalDay2)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY02_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY02_TITLE] = billAllSt.SupplierTotalDay2;
            }

            // �d��������R
            if (0 == billAllSt.SupplierTotalDay3)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY03_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY03_TITLE] = billAllSt.SupplierTotalDay3;
            }

            // �d��������S
            if (0 == billAllSt.SupplierTotalDay4)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY04_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY04_TITLE] = billAllSt.SupplierTotalDay4;
            }

            // �d��������T
            if (0 == billAllSt.SupplierTotalDay5)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY05_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY05_TITLE] = billAllSt.SupplierTotalDay5;
            }

            // �d��������U
            if (0 == billAllSt.SupplierTotalDay6)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY06_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY06_TITLE] = billAllSt.SupplierTotalDay6;
            }

            // �d��������V
            if (0 == billAllSt.SupplierTotalDay7)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY07_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY07_TITLE] = billAllSt.SupplierTotalDay7;
            }

            // �d��������W
            if (0 == billAllSt.SupplierTotalDay8)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY08_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY08_TITLE] = billAllSt.SupplierTotalDay8;
            }

            // �d��������X
            if (0 == billAllSt.SupplierTotalDay9)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY09_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY09_TITLE] = billAllSt.SupplierTotalDay9;
            }

            // �d��������P�O
            if (0 == billAllSt.SupplierTotalDay10)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY10_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY10_TITLE] = billAllSt.SupplierTotalDay10;
            }

            // �d��������P�P
            if (0 == billAllSt.SupplierTotalDay11)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY11_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY11_TITLE] = billAllSt.SupplierTotalDay11;
            }

            // �d��������P�Q
            if (0 == billAllSt.SupplierTotalDay12)
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY12_TITLE] = UNREGISTER;
            }
            else
            {
                this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][SUPPLIERTOTALDAY12_TITLE] = billAllSt.SupplierTotalDay12;
            }

            // GUID
            this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[index][GUID_TITLE] = billAllSt.FileHeaderGuid;

            if (this._billAllStTable.ContainsKey(billAllSt.FileHeaderGuid) == true)
            {
                this._billAllStTable.Remove(billAllSt.FileHeaderGuid);
            }
            this._billAllStTable.Add(billAllSt.FileHeaderGuid, billAllSt);

        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
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
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
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
            this._indexBuf = -2;  // ADD 2008/06/04

            // ��r�p�N���[���N���A
            this._billAllStClone = null;
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
        /// �����S�̐ݒ�I�u�W�F�N�g���S�폜����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private int PhysicalDelete()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            BillAllSt billAllSt = (BillAllSt)this._billAllStTable[guid];

            // �����S�̐ݒ肪���݂��Ă��Ȃ�
            if (billAllSt == null)
            {
                return -1;
            }

            // ADD 2008/09/17 �s��Ή�[5288] ---------->>>>>
            // ���_�R�[�h���S�Аݒ�̏ꍇ�A�폜�s��
            if (IsAllSection(billAllSt))
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
            // ADD 2008/09/17 �s��Ή�[5288] ----------<<<<<

            status = this._billAllStAcs.Delete(billAllSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �n�b�V���e�[�u������f�[�^���폜
                        this._billAllStTable.Remove((Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE]);
                        // �f�[�^�Z�b�g����f�[�^���폜
                        this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex].Delete();
                        break;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // �����폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            pgId, 					         	// �A�Z���u���h�c�܂��̓N���X�h�c
                            pgNm, 				             	// �v���O��������
                            "PhysicalDelete", 					// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._billAllStAcs,			        // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// �����S�̐ݒ�I�u�W�F�N�g�_���폜��������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�I�u�W�F�N�g�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private int Revival()
        {
            int status = 0;

            if ((this._dataIndex < 0) ||
                (this._dataIndex >= this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count))
            {
                return -1;
            }

            // ���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[this._dataIndex][GUID_TITLE];
            BillAllSt billAllSt = ((BillAllSt)this._billAllStTable[guid]).Clone();

            // �����S�̐ݒ肪���݂��Ă��Ȃ�
            if (billAllSt == null)
            {
                return -1;
            }

            status = this._billAllStAcs.Revival(ref billAllSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        BillAllStToDataSet(billAllSt.Clone(), this._dataIndex);
                        break;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, true);
                        return status;
                    }
                default:
                    {
                        // �������s
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                            pgNm, 					            // �v���O��������
                            "Revival", 							// ��������
                            TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                            "�����Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._billAllStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return status;
                    }
            }
            return status;
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void ScreenInputPermissionControl()
        {
            switch (this._logicalDeleteMode)
            {
                case -1:
                    {
                        // �V�K���[�h
                        this.Mode_Label.Text = INSERT_MODE;

                        // �{�^���̕\��
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // �R���g���[���̕\���ݒ�
                        ScreenInputPermissionControl(true);

                        // �����t�H�[�J�X���Z�b�g
                        this.tEdit_SectionCodeAllowZero2.Focus();

                        // ���_�R�[�h�̃R�����g�\��
                        SectionNm_Label.Visible = true;

                        break;
                    }
                case 1:
                    {
                        // �폜���[�h
                        this.Mode_Label.Text = DELETE_MODE;

                        // �{�^���̕\��
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Delete_Button.Visible = true;

                        // �R���g���[���̕\���ݒ�
                        ScreenInputPermissionControl(false);

                        // �����t�H�[�J�X���Z�b�g
                        this.Delete_Button.Focus();

                        // ���_�R�[�h�̃R�����g��\��
                        SectionNm_Label.Visible = false;  

                        break;
                    }
                default:
                    {
                        // �X�V���[�h
                        this.Mode_Label.Text = UPDATE_MODE;

                        // �{�^���̕\��
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Revive_Button.Visible = false;
                        this.Delete_Button.Visible = false;

                        // �R���g���[���̕\���ݒ�
                        ScreenInputPermissionControl(true);

                        // ���_�֌W�̃R���g���[�����g�p�s�ɂ���
                        tEdit_SectionCodeAllowZero2.Enabled = false;
                        SectionGd_ultraButton.Enabled = false;
                        SectionNm_tEdit.Enabled = false;

                        // ���_�R�[�h�̃R�����g��\��
                        SectionNm_Label.Visible = false;

                        // �����t�H�[�J�X���Z�b�g
                        this.AllowanceProcCd_tComboEditor.Focus();

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
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        void ScreenInputPermissionControl(bool enabled)
        {
            this.tEdit_SectionCodeAllowZero2.Enabled = enabled;              // ���_�R�[�h
            this.SectionGd_ultraButton.Enabled = enabled;          // �K�C�h�{�^�� 
            this.SectionNm_tEdit.Enabled = enabled;                // ���_�K�C�h����
            this.AllowanceProcCd_tComboEditor.Enabled = enabled;   // ���������敪
            this.DepositSlipMntCd_tComboEditor.Enabled = enabled;  // �����`�[�C���敪
            this.CollectPlnDiv_tComboEditor.Enabled = enabled; �@  // ����\��敪
            // DEL 2009/04/14 ------>>>
            //this.CustomerTotalDay1_tEdit.Enabled = enabled;        // ���Ӑ�����P
            //this.CustomerTotalDay2_tEdit.Enabled = enabled;        // ���Ӑ�����Q
            //this.CustomerTotalDay3_tEdit.Enabled = enabled;        // ���Ӑ�����R 
            //this.CustomerTotalDay4_tEdit.Enabled = enabled;        // ���Ӑ�����S 
            //this.CustomerTotalDay5_tEdit.Enabled = enabled;        // ���Ӑ�����T 
            //this.CustomerTotalDay6_tEdit.Enabled = enabled;        // ���Ӑ�����U 
            //this.CustomerTotalDay7_tEdit.Enabled = enabled;        // ���Ӑ�����V 
            //this.CustomerTotalDay8_tEdit.Enabled = enabled;        // ���Ӑ�����W 
            //this.CustomerTotalDay9_tEdit.Enabled = enabled;        // ���Ӑ�����X 
            //this.CustomerTotalDay10_tEdit.Enabled = enabled;       // ���Ӑ�����P�O 
            //this.CustomerTotalDay11_tEdit.Enabled = enabled;       // ���Ӑ�����P�P 
            //this.CustomerTotalDay12_tEdit.Enabled = enabled;       // ���Ӑ�����P�Q 
            //this.SupplierTotalDay1_tEdit.Enabled = enabled;        // �d��������P
            //this.SupplierTotalDay2_tEdit.Enabled = enabled;        // �d��������Q
            //this.SupplierTotalDay3_tEdit.Enabled = enabled;        // �d��������R
            //this.SupplierTotalDay4_tEdit.Enabled = enabled;        // �d��������S
            //this.SupplierTotalDay5_tEdit.Enabled = enabled;        // �d��������T
            //this.SupplierTotalDay6_tEdit.Enabled = enabled;        // �d��������U
            //this.SupplierTotalDay7_tEdit.Enabled = enabled;        // �d��������V
            //this.SupplierTotalDay8_tEdit.Enabled = enabled;        // �d��������W
            //this.SupplierTotalDay9_tEdit.Enabled = enabled;        // �d��������X
            //this.SupplierTotalDay10_tEdit.Enabled = enabled;       // �d��������P�O
            //this.SupplierTotalDay11_tEdit.Enabled = enabled;       // �d��������P�P
            //this.SupplierTotalDay12_tEdit.Enabled = enabled;       // �d��������P�Q
            // DEL 2009/04/14 ------<<<
            // ADD 2009/04/14 ------>>>
            if ((tEdit_SectionCodeAllowZero2.Text.TrimEnd() != string.Empty) && 
                (tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0') == "00"))
            {
                // �S�Ћ��ʂ̏ꍇ
                this.CustomerTotalDay1_tEdit.Enabled = enabled;         // ���Ӑ�����P
                this.CustomerTotalDay2_tEdit.Enabled = enabled;         // ���Ӑ�����Q
                this.CustomerTotalDay3_tEdit.Enabled = enabled;         // ���Ӑ�����R 
                this.CustomerTotalDay4_tEdit.Enabled = enabled;         // ���Ӑ�����S 
                this.CustomerTotalDay5_tEdit.Enabled = enabled;         // ���Ӑ�����T 
                this.CustomerTotalDay6_tEdit.Enabled = enabled;         // ���Ӑ�����U 
                this.CustomerTotalDay7_tEdit.Enabled = enabled;         // ���Ӑ�����V 
                this.CustomerTotalDay8_tEdit.Enabled = enabled;         // ���Ӑ�����W 
                this.CustomerTotalDay9_tEdit.Enabled = enabled;         // ���Ӑ�����X 
                this.CustomerTotalDay10_tEdit.Enabled = enabled;        // ���Ӑ�����P�O 
                this.CustomerTotalDay11_tEdit.Enabled = enabled;        // ���Ӑ�����P�P 
                this.CustomerTotalDay12_tEdit.Enabled = enabled;        // ���Ӑ�����P�Q 
                this.SupplierTotalDay1_tEdit.Enabled = enabled;         // �d��������P
                this.SupplierTotalDay2_tEdit.Enabled = enabled;         // �d��������Q
                this.SupplierTotalDay3_tEdit.Enabled = enabled;         // �d��������R
                this.SupplierTotalDay4_tEdit.Enabled = enabled;         // �d��������S
                this.SupplierTotalDay5_tEdit.Enabled = enabled;         // �d��������T
                this.SupplierTotalDay6_tEdit.Enabled = enabled;         // �d��������U
                this.SupplierTotalDay7_tEdit.Enabled = enabled;         // �d��������V
                this.SupplierTotalDay8_tEdit.Enabled = enabled;         // �d��������W
                this.SupplierTotalDay9_tEdit.Enabled = enabled;         // �d��������X
                this.SupplierTotalDay10_tEdit.Enabled = enabled;        // �d��������P�O
                this.SupplierTotalDay11_tEdit.Enabled = enabled;        // �d��������P�P
                this.SupplierTotalDay12_tEdit.Enabled = enabled;        // �d��������P�Q
            }
            else
            {
                // �S�Ћ��ʈȊO�́A���͕s��
                this.CustomerTotalDay1_tEdit.Enabled = false;           // ���Ӑ�����P
                this.CustomerTotalDay2_tEdit.Enabled = false;           // ���Ӑ�����Q
                this.CustomerTotalDay3_tEdit.Enabled = false;           // ���Ӑ�����R 
                this.CustomerTotalDay4_tEdit.Enabled = false;           // ���Ӑ�����S 
                this.CustomerTotalDay5_tEdit.Enabled = false;           // ���Ӑ�����T 
                this.CustomerTotalDay6_tEdit.Enabled = false;           // ���Ӑ�����U 
                this.CustomerTotalDay7_tEdit.Enabled = false;           // ���Ӑ�����V 
                this.CustomerTotalDay8_tEdit.Enabled = false;           // ���Ӑ�����W 
                this.CustomerTotalDay9_tEdit.Enabled = false;           // ���Ӑ�����X 
                this.CustomerTotalDay10_tEdit.Enabled = false;          // ���Ӑ�����P�O 
                this.CustomerTotalDay11_tEdit.Enabled = false;          // ���Ӑ�����P�P 
                this.CustomerTotalDay12_tEdit.Enabled = false;          // ���Ӑ�����P�Q 
                this.SupplierTotalDay1_tEdit.Enabled = false;           // �d��������P
                this.SupplierTotalDay2_tEdit.Enabled = false;           // �d��������Q
                this.SupplierTotalDay3_tEdit.Enabled = false;           // �d��������R
                this.SupplierTotalDay4_tEdit.Enabled = false;           // �d��������S
                this.SupplierTotalDay5_tEdit.Enabled = false;           // �d��������T
                this.SupplierTotalDay6_tEdit.Enabled = false;           // �d��������U
                this.SupplierTotalDay7_tEdit.Enabled = false;           // �d��������V
                this.SupplierTotalDay8_tEdit.Enabled = false;           // �d��������W
                this.SupplierTotalDay9_tEdit.Enabled = false;           // �d��������X
                this.SupplierTotalDay10_tEdit.Enabled = false;          // �d��������P�O
                this.SupplierTotalDay11_tEdit.Enabled = false;          // �d��������P�P
                this.SupplierTotalDay12_tEdit.Enabled = false;          // �d��������P�Q
            }
            // ADD 2009/04/14 ------<<<
            
            // ������h�~�̈�
            this.Enabled = true;
            // --- ADD 2008/06/04 --------------------------------<<<<< 
        }

        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͂̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            int i;
            ArrayList days = new ArrayList();
            bool spaceFlg = false;
            bool result = true;

            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.SectionCode_Title_Label.Text + "��ݒ肵�ĉ������B";
                control = this.tEdit_SectionCodeAllowZero2;
                result = false; 

                return result;
            }

            Broadleaf.Library.Windows.Forms.TEdit[] customerTotalDay_tEdit = new TEdit[12];
            customerTotalDay_tEdit[0] = CustomerTotalDay1_tEdit;
            customerTotalDay_tEdit[1] = CustomerTotalDay2_tEdit;
            customerTotalDay_tEdit[2] = CustomerTotalDay3_tEdit;
            customerTotalDay_tEdit[3] = CustomerTotalDay4_tEdit;
            customerTotalDay_tEdit[4] = CustomerTotalDay5_tEdit;
            customerTotalDay_tEdit[5] = CustomerTotalDay6_tEdit;
            customerTotalDay_tEdit[6] = CustomerTotalDay7_tEdit;
            customerTotalDay_tEdit[7] = CustomerTotalDay8_tEdit;
            customerTotalDay_tEdit[8] = CustomerTotalDay9_tEdit;
            customerTotalDay_tEdit[9] = CustomerTotalDay10_tEdit;
            customerTotalDay_tEdit[10] = CustomerTotalDay11_tEdit;
            customerTotalDay_tEdit[11] = CustomerTotalDay12_tEdit;

            // �����Ώے����i���Ӑ�j�`�F�b�N
            for (i = 0;i < 12 ;i++)
            {
                if (customerTotalDay_tEdit[i].DataText == "")
                {
                    if (spaceFlg != true)
                    {
                        spaceFlg = true;
                        control = customerTotalDay_tEdit[i];
                    }
                }
                else
                {
                    if (spaceFlg == true)
                    {
                        // �Ԃ������Ă���ꍇ
                        message = TOTALDAY_NGMSG_BETWEEN;
                        result = false;

                        return result;
                    }

                    if (Int32.Parse(customerTotalDay_tEdit[i].DataText) > 31)
                    {
                        // 1�`31�͈̔͊O�̏ꍇ
                        message = TOTALDAY_NGMSG_DAYS;
                        control = customerTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }

                    if ((i != 0) && (Int32.Parse(customerTotalDay_tEdit[i - 1].DataText) > Int32.Parse(customerTotalDay_tEdit[i].DataText)))
                    {
                        // �����̍��ڂ����l���������ꍇ
                        message = TOTALDAY_NGMSG_SMALL;
                        control = customerTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }

                    if (days.IndexOf(customerTotalDay_tEdit[i].DataText) >= 0)
                    {
                        // �d�����Ă���ꍇ
                        message = TOTALDAY_NGMSG_REPEAT;
                        control = customerTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }
                    else
                    {
                        days.Add(customerTotalDay_tEdit[i].DataText);
                    }
                }
            }

            days.Clear();
            spaceFlg = false;

            Broadleaf.Library.Windows.Forms.TEdit[] supplierTotalDay_tEdit = new TEdit[12];
            supplierTotalDay_tEdit[0] = SupplierTotalDay1_tEdit;
            supplierTotalDay_tEdit[1] = SupplierTotalDay2_tEdit;
            supplierTotalDay_tEdit[2] = SupplierTotalDay3_tEdit;
            supplierTotalDay_tEdit[3] = SupplierTotalDay4_tEdit;
            supplierTotalDay_tEdit[4] = SupplierTotalDay5_tEdit;
            supplierTotalDay_tEdit[5] = SupplierTotalDay6_tEdit;
            supplierTotalDay_tEdit[6] = SupplierTotalDay7_tEdit;
            supplierTotalDay_tEdit[7] = SupplierTotalDay8_tEdit;
            supplierTotalDay_tEdit[8] = SupplierTotalDay9_tEdit;
            supplierTotalDay_tEdit[9] = SupplierTotalDay10_tEdit;
            supplierTotalDay_tEdit[10] = SupplierTotalDay11_tEdit;
            supplierTotalDay_tEdit[11] = SupplierTotalDay12_tEdit;

            // �����Ώے����i�d����j�`�F�b�N
            for (i = 0; i < 12; i++)
            {
                if (supplierTotalDay_tEdit[i].DataText == "")
                {
                    if(spaceFlg != true)
                    {
                        spaceFlg = true;
                        control = supplierTotalDay_tEdit[i];
                    }
                }
                else
                {
                    if (spaceFlg == true)
                    {
                        message = TOTALDAY_NGMSG_BETWEEN;
                        result = false;

                        return result;
                    }

                    if (Int32.Parse(supplierTotalDay_tEdit[i].DataText) > 31)
                    {
                        // 1�`31�͈̔͊O�̏ꍇ
                        message = TOTALDAY_NGMSG_DAYS;
                        control = supplierTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }

                    if ((i != 0) && (Int32.Parse(supplierTotalDay_tEdit[i - 1].DataText) > Int32.Parse(supplierTotalDay_tEdit[i].DataText))) 
                    {
                        // �����̍��ڂ����l���������ꍇ
                        message = TOTALDAY_NGMSG_SMALL;
                        control = supplierTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }

                    if (days.IndexOf(supplierTotalDay_tEdit[i].DataText) >= 0)
                    {
                        message = TOTALDAY_NGMSG_REPEAT;
                        control = supplierTotalDay_tEdit[i];
                        result = false;

                        return result;
                    }
                    else
                    {
                        days.Add(supplierTotalDay_tEdit[i].DataText);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        /// 
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            secInfoAcs.ResetSectionInfo();

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
                // --- ADD 2011/09/07 -------------------------------->>>>>
                if (sectionCode.Trim().PadLeft(2, '0') == "00")
                    sectionName = "�S�Ћ���";
                // --- ADD 2011/09/07 --------------------------------<<<<<
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }
		# endregion

		# region Control Events
		
		/// <summary>
		///	Form.Load �C�x���g(SFUKK09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void SFUKK09100UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList = imageList24;
			this.Cancel_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // --- ADD 2008/06/13 -------------------------------->>>>>
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;	// �����{�^��
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;	// ���S�폜�{�^��

            this.SectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2008/06/13 --------------------------------<<<<< 

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();

            // ���_�K�C�h�̃t�H�[�J�X����̊J�n
            SectionGuideController.StartControl();  // ADD 2008/09/16 �s��Ή�[5257]
		}
		
		/// <summary>
		///	Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///					 �������܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            /* --- DEL 2008/06/13 -------------------------------->>>>>
            //�ۑ�����
            if (!DataSaveProc()) 
            {return;}

            DialogResult dialogResult = DialogResult.OK;

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }
		
            this.DialogResult = dialogResult;
            this._billAllStClone = null;

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
               --- DEL 2008/06/13 --------------------------------<<<<< */

            // --- ADD 2008/06/13 -------------------------------->>>>>
            if (!DataSaveProc())
            {			// �o�^
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                ScreenClear();

                // �V�K���[�h
                this._logicalDeleteMode = -1;

                BillAllSt newBillAllSt = new BillAllSt();

                // �����S�̐ݒ�I�u�W�F�N�g����ʂɓW�J
                BillAllStToScreen(newBillAllSt);

                // �N���[���쐬
                this._billAllStClone = newBillAllSt.Clone();
                ScreenToBillAllSt(ref this._billAllStClone);

                // _GridIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

                ScreenInputPermissionControl();
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
                this._indexBuf = -2;

                if (this._canClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }
            }
            // --- ADD 2008/06/13 --------------------------------<<<<< 
		}

		/// <summary>
		///	Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ���
		///					 �������܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ���݂̉�ʏ����擾����
                BillAllSt compareBillAllSt = new BillAllSt();
                compareBillAllSt = this._billAllStClone.Clone();
                ScreenToBillAllSt(ref compareBillAllSt);

                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                if (!(this._billAllStClone.Equals(compareBillAllSt)))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                    // �ۑ��m�F
                    DialogResult res = TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
                        pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 								// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	// �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!DataSaveProc())
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
                                // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
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
                                // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                                
                                return;
                            }
                    }
                }
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            if (this._canClose)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
		}

		/// <summary>
		///	Form.Closing �C�x���g(SFUKK09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note	   : �t�H�[�������O�ɁA���[�U�[���t�H�[�����
		///					 �悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void SFUKK09100UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            //this._billAllStClone = null;  // DEL 2008/06/13

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j			
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}
		
		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFUKK09100UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void SFUKK09100UA_VisibleChanged(object sender, System.EventArgs e)
		{    
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				//2005.10.19 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				//2005.10.19 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
				return;
			}

            // _GridIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            // �^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ������ꍇ�ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ������h�~�̈�
            this.Enabled = false;

			timer1.Enabled = true;

			ScreenClear();		
		}
      
		/// <summary>
		/// Timer.Tick �C�x���g(timer1_Tick)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///                  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///	                 �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.08.01</br>
		/// </remarks>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			timer1.Enabled = false;
			ScreenReconstruction();		
		}

        /// <summary>
        /// ���_�R�[�h�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�\������</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void SectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            int status = secInfoSetAcs.ExecuteGuid(this._enterPriseCode, false, out secInfoSet);
            if (status != 0)
            {
                ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2008/10/09 �s��Ή�[6226]
                return;
            }

            // �擾�f�[�^�\��
            this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
            this.SectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;

            // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            if (this._dataIndex < 0)
            {
                if (ModeChangeProc())
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS;
                    ((Control)sender).Focus();
                }
            }
            // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }
		# endregion

        /// <summary>
        /// ���S�폜�{�^���N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂�</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                pgId, 						        // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel, 		// �\������{�^��
                MessageBoxDefaultButton.Button2);	// �����\���{�^��

            if (result == DialogResult.OK)
            {
                if (PhysicalDelete() != 0)
                {
                    return;
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

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
        /// �����{�^���N���b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂�</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            if (Revival() != 0)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

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
        /// ���_�R�[�hEdit Leave����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���_���̕\������</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/13</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Leave(object sender, EventArgs e)
        {
            // ���_�R�[�h���͂���H
            if (this.tEdit_SectionCodeAllowZero2.Text != "")
            {
                // ���_�R�[�h���̐ݒ�
                this.SectionNm_tEdit.Text = GetSectionName(this.tEdit_SectionCodeAllowZero2.Text.Trim());
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                if (this.SectionNm_tEdit.Text == "")
                {
                    TMsgDisp.Show(
                        this, 								 // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,  // �G���[���x��
                        "DCKHN09210U", 						 // �A�Z���u���h�c�܂��̓N���X�h�c
                        "�w�肵�����_�R�[�h�͑��݂��܂���B",// �\�����郁�b�Z�[�W
                        0, 									 // �X�e�[�^�X�l
                        MessageBoxButtons.OK);
                    this.tEdit_SectionCodeAllowZero2.Text = "";
                    this.tEdit_SectionCodeAllowZero2.Focus();
                    this.tEdit_SectionCodeAllowZero2.Select();
                }
                // --- ADD 2011/09/07 --------------------------------<<<<<
            }
            else
            {
                // ���_�R�[�h���̃N���A
                this.SectionNm_tEdit.Text = "";
            }

            // ADD 2008/10/10 �s��Ή�[6445] ---------->>>>>
            if (this.tEdit_SectionCodeAllowZero2.Text.Trim().Equals("00") ||
                this.tEdit_SectionCodeAllowZero2.Text.Trim().Equals("0"))    // DEL 2009/04/10 �s��Ή�[13142] �폜���������� || this.SectionNm_tEdit.Text.Equals(""))
            {
                this.SectionNm_tEdit.Text = "�S�Ћ���";
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');// ADD 2011/09/07
            }
            // ADD 2008/10/10 �s��Ή�[6445] ----------<<<<<
        }

        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// tArrowKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            _modeFlg = false;
            
            switch (e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero2":
                    {
                        // ���_�R�[�h
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tEdit_SectionCodeAllowZero2;
                            }
                        }
                        break;
                    }
            }
        }

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
            tEdit_SectionCodeAllowZero2.Text = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');
            SectionNm_tEdit.Text = GetSectionName(tEdit_SectionCodeAllowZero2.Text);
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "���͂��ꂽ�R�[�h�̐����S�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');
            // ADD 2009/04/08 �s��Ή�[13142]�F������Ԃŋ��_�K�C�h���͂��s���ƑS�Ћ��ʂɂȂ��Ă��܂� ---------->>>>>
            if (sectionCd.Equals("00") && string.IsNullOrEmpty(SectionGuideController.GetPreviousText()))
            {
                sectionCd = string.Empty;
            }
            // ADD 2009/04/08 �s��Ή�[13142]�F������Ԃŋ��_�K�C�h���͂��s���ƑS�Ћ��ʂɂȂ��Ă��܂� ----------<<<<<

            for (int i = 0; i < this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[i][SECTIONCODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[BILLALLST_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          pgId,						            // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̐����S�̐ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�A���̂̃N���A
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionNm_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h�̐����S�̐ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        pgId,                                   // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    isError = true;
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
        // 2009.03.25 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
	}
}
