//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�S�̏����\���ݒ�}�X�^
// �v���O�����T�v   �F�S�̏����\���ݒ�̓o�^�E�C���E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E�@�K�j
// �C����    2008/06/04     �C�����e�F�u�ڋq�R�[�h�������ԁv�u���Ӑ�폜�`�F�b�N�v�u������Ǘ��v�폜
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E�@�K�j
// �C����    2008/09/10     �C�����e�F�u����Ŏ����␳�敪�v�폜
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E�@�K�j
// �C����    2008/09/12     �C�����e�F�S�Ћ��ʃf�[�^�͍폜�ł��Ȃ��悤�ύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30418  ���i�@�r��
// �C����    2008/11/05     �C�����e�F�S�Ћ��ʂ��Ăяo�����Ƃ��ɂ́u���o�^�v�ł͂Ȃ��u�S�Ћ��ʁv�ƕ\������悤�ɏC��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E�@�K�j
// �C����    2009/01/05     �C�����e�F��QID�F0009053�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/17     �C�����e�FMantis�y12827�z���x�A�b�v�Ή�
//                                  �FMantis�y13190�z�}�X�����ŐV���Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30531 ���@�r��
// �C����    2010/01/18     �C�����e�FMantis�y14890�z�����\���������o�͋敪�폜���A�������^�C�v���̏o�͋敪�ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���Fzhouyu
// �C����    2011/07/19     �C�����e�F�A�� 1028 �݌Ɏd�����͂ŁA�i�ԓ��͌�Ɏ����� �d����=�P �ƕ\������A���݌ɐ���������ĕ\���ɂȂ蕪���肸�炢
//                                    PM7�ł́A�d����=1�ƕ\������d���O�̌��݌���\���A�s�ړ���Ɍ��݌����ĕ\�������
//                                    ����`�[���́C�d���`�[���� ������
// ---------------------------------------------------------------------//
// �Ǘ��ԍ� 10704766-00     �쐬�S���F����3
// �C����    2011/07/28     �C�����e�F�A��909�@���S�̏����\���ݒ聄�ŋ��_�ݒ���s�����Ƌ��_�K�C�h������ƑS�Ћ��ʂ̕ҏW���s�����Ƃ��Ă��܂��B
//                          ���_�R�[�h�Ƌ��_�K�C�h�̃t�H�[�J�X�ړ��̓��b�Z�[�W�\�����s��Ȃ��悤�ɏC�����Ă��������B
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���F����R
// �C����    2011/09/07     �C�����e�F��Q�� #24169�@
//                                    ���_�R�[�h�u1�v�œo�^�����ۂɁu01�v�œo�^�����
//                                    �S���_�ł̓o�^
//                                    ���_�ݒ���s�����Ƌ��_�K�C�h������ƑS�Ћ��ʂ̕ҏW���s�����Ƃ��Ă��܂��B
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@���_�R�[�h�Ƌ��_�K�C�h�̃t�H�[�J�X�ړ��̓��b�Z�[�W�\�����s��Ȃ��悤�ɏC��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10901273-00    �쐬�S���F���N
// �C����    2013/05/02     �C�����e�F2013/06/18�z�M���@ Redmine#35434�@
//                                    ���i�݌Ƀ}�X�^�N���敪�̒ǉ�
// ---------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util; // ADD 2011/09/07

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �S�̏����\���ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �S�̏����\���ݒ���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>   
	/// <br>Programmer	: 23006  ���� ���q</br>
	/// <br>Date		: 2005.10.03</br>
    /// <br></br>
	/// <br>Update Note : 2005.10.04  23006 ���� ���q</br>
	/// <br>			    �E�t�@�C���d�l���ύX�ׁ̈A�Ή�</br>
    /// <br></br>
	/// <br>Update Note : 2005.10.19  23006 ���� ���q</br>
	/// <br>			    �EUI�q���Hide����Owner.Activate�����ǉ�</br>
    /// <br></br>
	/// <br>Update Note : 2005.11.10  23006 ���� ���q</br>
	/// <br>                �E�Q�ƌ^�R���{�{�b�N�X�u�폜�ρv�\���Ή�</br>
    /// <br></br>
	/// <br>Update Note : 2005.12.19  23006 ���� ���q</br>
	/// <br>                �E�L���b�V����{���Ή�</br>
    /// <br></br>
	/// <br>Update Note : 2006.01.13  23006 ���� ���q</br>
	/// <br>                �E�R�[�h�Q�ƍ��ڂ̓��͕ύX�t���O�𗧂Ă�Ƃ��̏����C��</br>
    /// <br></br>
    /// <br>Update Note : 2006.07.26  23006 ���� ���q</br>
    /// <br>                �E�u���b�V���A�b�v�Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2006.09.13  23006 ���� ���q</br>
    /// <br>                �E�u���^�������ԍ��v�ǉ��Ή�</br>
	/// <br></br>
    /// <br>Update Note : 2006.12.05  18322 �ؑ� ����</br>
    /// <br>                ���g�уV�X�e���Ή�</br>
    /// <br>�@�@�@�@�@�@�@�@�@�ǋ�R�[�h�A�����\���Z���R�[�h�P�`�R�A�����\���Z���A</br>
    /// <br>                  �����ӎZ��敪�A�ԗ��m��I������A���^�������ԍ����폜</br>
    /// <br>              2007.02.07 18322 T.Kimura ��ʃX�L���ύX�Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2007.03.05 30005 �،��@��</br>
    /// <br>                ���g�уV�X�e���Ή�</br>
    /// <br>                  �V�������ځu������Ǘ��敪�v��ǉ�</br>
    /// <br></br>
    /// <br>Update Note : 2007.03.28 22022 �i��@�m�q</br>
    /// <br>                �E�u���z�\�����@�v�̃O���b�h�\���ʒu�̏�Q�Ή�</br>
    /// <br>                �E�u��v���Ǘ��敪�v�̃O���b�h�ݒ�̏�Q�Ή�</br>
    /// <br>                �E��ʍ��ڃ^�C�g���E���ڈʒu�̏�Q�Ή�</br>
    /// <br></br>
    /// <br>Update Note : 2007.05.19 30005  �،��@��</br>
    /// <br>                �E�s�v��XML�R�����g�̃R�����g�A�E�g</br>
    /// <br></br>
    /// <br>Update Note : 2007.07.12 20031  �É�@���S��</br>
    /// <br>                �E�uDM�敪�v���\���ɕύX(���A�̉\���𓥂܂��A��\���ɕύX����ɗ��߂�)</br>
    /// <br></br>
    /// <br>Update Note : 2007.08.08 20056  ���n ���</br>
    /// <br>                �����ʔ̔���Ή�</br>
    /// <br>                �E�����\���敪�P�E�Q�E�R</br>
    /// <br>Update Note : 2008/06/04 30414  �E�@�K�j</br>
    /// <br>                �E�u�ڋq�R�[�h�������ԁv�u���Ӑ�폜�`�F�b�N�v�u������Ǘ��v�폜</br>
    /// <br>Update Note : 2008/09/10 30414  �E�@�K�j</br>
    /// <br>                �E�u����Ŏ����␳�敪�v�폜</br>
    /// <br>Update Note : 2008/09/12 30414  �E�@�K�j</br>
    /// <br>                �E�S�Ћ��ʃf�[�^�͍폜�ł��Ȃ��悤�ύX</br>
    /// <br>Update Note : 2008/11/05 30418  ���i�@�r��</br>
    /// <br>                �E�S�Ћ��ʂ��Ăяo�����Ƃ��ɂ́u���o�^�v�ł͂Ȃ��u�S�Ћ��ʁv�ƕ\������悤�ɏC��</br>
    /// <br>Update Note : 2009/01/05 30414  �E�@�K�j</br>
    /// <br>                �E��QID�F0009053�Ή�</br>
    /// <br>Update Note : 2010/01/18 30531  ��� �r��</br>
    /// <br>                �E�������o�͋敪���폜���A�������^�C�v���̏o�͋敪�ǉ��i�R���ځj</br>
    /// <br>Update Note : 2011/07/19 zhouyu</br>
    /// <br>                �E�A�� 1028</br>
    /// <br>                  �C�����e�F�A�� 1028 �݌Ɏd�����͂ŁA�i�ԓ��͌�Ɏ����� �d����=�P �ƕ\������A���݌ɐ���������ĕ\���ɂȂ蕪���肸�炢</br>
    /// <br>                  PM7�ł́A�d����=1�ƕ\������d���O�̌��݌���\���A�s�ړ���Ɍ��݌����ĕ\�������</br>
    /// <br>                  ����`�[���́C�d���`�[���� ������</br>
    /// <br>Update Note : 2011/07/28 ����3</br>
    /// <br>                �E�A��909�@���S�̏����\���ݒ聄�ŋ��_�ݒ���s�����Ƌ��_�K�C�h������ƑS�Ћ��ʂ̕ҏW���s�����Ƃ��Ă��܂��B</br>
    /// <br>                  ���_�R�[�h�Ƌ��_�K�C�h�̃t�H�[�J�X�ړ��̓��b�Z�[�W�\�����s��Ȃ��悤�ɏC�����Ă��������B</br>
    /// <br>UpdateNote : 2011/09/07 ����R</br>
    /// <br>        	 �E��Q�� #24169</br>
    /// <br>UpdateNote : ���N</br>�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@
    /// <br>Date       : 2013/05/02</br>
    /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br> 
    /// <br>�@         : Redmine#35434�̑Ή�</br>
    /// </remarks>
	public class SFCMN09080UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel DefDspCustTtlDay_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit DefDspCustTtlDay_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TNedit DefDspCustClctMnyDay_tNedit;
		private Infragistics.Win.Misc.UltraLabel DefDspCustClctMnyDay_uLabel;
		private Infragistics.Win.Misc.UltraLabel DefDspClctMnyMonthCd_uLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor DefDspClctMnyMonthCd_tComEditor;
		private Infragistics.Win.Misc.UltraLabel IniDspPrslOrCorpCd_uLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor IniDspPrslOrCorpCd_tComEditor;
		private Infragistics.Win.Misc.UltraLabel Section_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TComboEditor EraNameDispCd1_tComEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private TComboEditor RemCntAutoDspDiv_tComboEditor;
        private TComboEditor MemoMoveDiv_tComboEditor;
        private TComboEditor GoodsNoInpDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private TEdit tEdit_SectionCodeAllowZero2;
        private UiSetControl uiSetControl1;
        private TComboEditor EraNameDispCd2_tComEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TComboEditor DefSlTtlBillOutput_tComboEditor;
        private TComboEditor DefDtlBillOutput_tComboEditor;
        private TComboEditor DefTtlBillOutput_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel DtlCalcStckCntDsp_Label;
        private TComboEditor DtlCalcStckCntDsp_tComboEditor;
        private TComboEditor GoodsStockMstBootDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel StockShowType_Lable;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;

		#endregion

		#region -- Constructor --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����\���ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: �S�̏����\���ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
        public SFCMN09080UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._allDefSetAcs = new AllDefSetAcs();
            //this._prevAllDefSet = null;  // DEL 2008/06/04
            //this._nextData = false;  // DEL 2008/06/04
            this._totalCount = 0;
            this._allDefSetTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            this._secInfoAcs = new SecInfoAcs();    // ADD 2009/04/17

            // �� 20061205 18322 d
            // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            // // ���^���������̃A�N�Z�X�N���X
            // this._landTrnsNmAcs = new LandTrnsNmAcs();
            // // ���^���������̊i�[�p
            // this._landTrnsNmBuf = null;
            // // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            // �� 20061205 18322 d
        }
		#endregion

		private System.ComponentModel.IContainer components;

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region -- Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09080UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspCustTtlDay_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspCustTtlDay_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspCustClctMnyDay_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.DefDspCustClctMnyDay_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspClctMnyMonthCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DefDspClctMnyMonthCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.IniDspPrslOrCorpCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.IniDspPrslOrCorpCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.EraNameDispCd1_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsNoInpDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MemoMoveDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RemCntAutoDspDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.EraNameDispCd2_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.DefTtlBillOutput_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DefDtlBillOutput_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DefSlTtlBillOutput_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.DtlCalcStckCntDsp_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DtlCalcStckCntDsp_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.StockShowType_Lable = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsStockMstBootDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspCustTtlDay_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspCustClctMnyDay_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspClctMnyMonthCd_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IniDspPrslOrCorpCd_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraNameDispCd1_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNoInpDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoMoveDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemCntAutoDspDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraNameDispCd2_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefTtlBillOutput_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDtlBillOutput_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefSlTtlBillOutput_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtlCalcStckCntDsp_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsStockMstBootDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(726, 334);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 19;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(595, 334);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 17;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 374);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(886, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(751, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // DefDspCustTtlDay_uLabel
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.DefDspCustTtlDay_uLabel.Appearance = appearance10;
            this.DefDspCustTtlDay_uLabel.Location = new System.Drawing.Point(16, 99);
            this.DefDspCustTtlDay_uLabel.Name = "DefDspCustTtlDay_uLabel";
            this.DefDspCustTtlDay_uLabel.Size = new System.Drawing.Size(194, 24);
            this.DefDspCustTtlDay_uLabel.TabIndex = 171;
            this.DefDspCustTtlDay_uLabel.Text = "���Ӑ����";
            // 
            // DefDspCustTtlDay_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.DefDspCustTtlDay_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.DefDspCustTtlDay_tNedit.Appearance = appearance9;
            this.DefDspCustTtlDay_tNedit.AutoSelect = true;
            this.DefDspCustTtlDay_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DefDspCustTtlDay_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DefDspCustTtlDay_tNedit.DataText = "";
            this.DefDspCustTtlDay_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DefDspCustTtlDay_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DefDspCustTtlDay_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DefDspCustTtlDay_tNedit.Location = new System.Drawing.Point(214, 99);
            this.DefDspCustTtlDay_tNedit.MaxLength = 2;
            this.DefDspCustTtlDay_tNedit.Name = "DefDspCustTtlDay_tNedit";
            this.DefDspCustTtlDay_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DefDspCustTtlDay_tNedit.Size = new System.Drawing.Size(28, 24);
            this.DefDspCustTtlDay_tNedit.TabIndex = 3;
            this.DefDspCustTtlDay_tNedit.Leave += new System.EventHandler(this.Day_Leave);
            // 
            // ultraLabel1
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance13;
            this.ultraLabel1.Location = new System.Drawing.Point(248, 99);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel1.TabIndex = 173;
            this.ultraLabel1.Text = "��";
            // 
            // ultraLabel2
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance14;
            this.ultraLabel2.Location = new System.Drawing.Point(248, 129);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel2.TabIndex = 176;
            this.ultraLabel2.Text = "��";
            // 
            // DefDspCustClctMnyDay_tNedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Right";
            this.DefDspCustClctMnyDay_tNedit.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.DefDspCustClctMnyDay_tNedit.Appearance = appearance16;
            this.DefDspCustClctMnyDay_tNedit.AutoSelect = true;
            this.DefDspCustClctMnyDay_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DefDspCustClctMnyDay_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.DefDspCustClctMnyDay_tNedit.DataText = "";
            this.DefDspCustClctMnyDay_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.DefDspCustClctMnyDay_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.DefDspCustClctMnyDay_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DefDspCustClctMnyDay_tNedit.Location = new System.Drawing.Point(214, 129);
            this.DefDspCustClctMnyDay_tNedit.MaxLength = 2;
            this.DefDspCustClctMnyDay_tNedit.Name = "DefDspCustClctMnyDay_tNedit";
            this.DefDspCustClctMnyDay_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.DefDspCustClctMnyDay_tNedit.Size = new System.Drawing.Size(28, 24);
            this.DefDspCustClctMnyDay_tNedit.TabIndex = 4;
            this.DefDspCustClctMnyDay_tNedit.Leave += new System.EventHandler(this.Day_Leave);
            // 
            // DefDspCustClctMnyDay_uLabel
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.DefDspCustClctMnyDay_uLabel.Appearance = appearance17;
            this.DefDspCustClctMnyDay_uLabel.Location = new System.Drawing.Point(16, 129);
            this.DefDspCustClctMnyDay_uLabel.Name = "DefDspCustClctMnyDay_uLabel";
            this.DefDspCustClctMnyDay_uLabel.Size = new System.Drawing.Size(194, 24);
            this.DefDspCustClctMnyDay_uLabel.TabIndex = 174;
            this.DefDspCustClctMnyDay_uLabel.Text = "���Ӑ�W����";
            // 
            // DefDspClctMnyMonthCd_uLabel
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.DefDspClctMnyMonthCd_uLabel.Appearance = appearance18;
            this.DefDspClctMnyMonthCd_uLabel.Location = new System.Drawing.Point(16, 159);
            this.DefDspClctMnyMonthCd_uLabel.Name = "DefDspClctMnyMonthCd_uLabel";
            this.DefDspClctMnyMonthCd_uLabel.Size = new System.Drawing.Size(194, 24);
            this.DefDspClctMnyMonthCd_uLabel.TabIndex = 177;
            this.DefDspClctMnyMonthCd_uLabel.Text = "�W����";
            // 
            // DefDspClctMnyMonthCd_tComEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.DefDspClctMnyMonthCd_tComEditor.ActiveAppearance = appearance19;
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.DefDspClctMnyMonthCd_tComEditor.Appearance = appearance20;
            this.DefDspClctMnyMonthCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DefDspClctMnyMonthCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DefDspClctMnyMonthCd_tComEditor.ItemAppearance = appearance21;
            this.DefDspClctMnyMonthCd_tComEditor.Location = new System.Drawing.Point(214, 159);
            this.DefDspClctMnyMonthCd_tComEditor.Name = "DefDspClctMnyMonthCd_tComEditor";
            this.DefDspClctMnyMonthCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.DefDspClctMnyMonthCd_tComEditor.TabIndex = 5;
            // 
            // IniDspPrslOrCorpCd_uLabel
            // 
            appearance55.TextVAlignAsString = "Middle";
            this.IniDspPrslOrCorpCd_uLabel.Appearance = appearance55;
            this.IniDspPrslOrCorpCd_uLabel.Location = new System.Drawing.Point(441, 129);
            this.IniDspPrslOrCorpCd_uLabel.Name = "IniDspPrslOrCorpCd_uLabel";
            this.IniDspPrslOrCorpCd_uLabel.Size = new System.Drawing.Size(130, 24);
            this.IniDspPrslOrCorpCd_uLabel.TabIndex = 179;
            this.IniDspPrslOrCorpCd_uLabel.Text = "�l�E�@�l";
            // 
            // IniDspPrslOrCorpCd_tComEditor
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.TextVAlignAsString = "Middle";
            this.IniDspPrslOrCorpCd_tComEditor.ActiveAppearance = appearance30;
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            this.IniDspPrslOrCorpCd_tComEditor.Appearance = appearance35;
            this.IniDspPrslOrCorpCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.IniDspPrslOrCorpCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.IniDspPrslOrCorpCd_tComEditor.ItemAppearance = appearance37;
            this.IniDspPrslOrCorpCd_tComEditor.Location = new System.Drawing.Point(627, 129);
            this.IniDspPrslOrCorpCd_tComEditor.Name = "IniDspPrslOrCorpCd_tComEditor";
            this.IniDspPrslOrCorpCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.IniDspPrslOrCorpCd_tComEditor.TabIndex = 11;
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(16, 42);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(192, 24);
            this.Section_uLabel.TabIndex = 184;
            this.Section_uLabel.Text = "���_";
            // 
            // SectionName_tEdit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance3;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(255, 42);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(175, 24);
            this.SectionName_tEdit.TabIndex = 1;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(437, 42);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "���_�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // EraNameDispCd1_tComEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.EraNameDispCd1_tComEditor.ActiveAppearance = appearance7;
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.EraNameDispCd1_tComEditor.Appearance = appearance11;
            this.EraNameDispCd1_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EraNameDispCd1_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EraNameDispCd1_tComEditor.ItemAppearance = appearance12;
            this.EraNameDispCd1_tComEditor.Location = new System.Drawing.Point(214, 189);
            this.EraNameDispCd1_tComEditor.Name = "EraNameDispCd1_tComEditor";
            this.EraNameDispCd1_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.EraNameDispCd1_tComEditor.TabIndex = 6;
            // 
            // ultraLabel3
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance26;
            this.ultraLabel3.Location = new System.Drawing.Point(16, 189);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(194, 24);
            this.ultraLabel3.TabIndex = 247;
            this.ultraLabel3.Text = "�����\���敪(�N��)";
            // 
            // ultraLabel7
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance68;
            this.ultraLabel7.Location = new System.Drawing.Point(441, 99);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel7.TabIndex = 253;
            this.ultraLabel7.Text = "�i�ԓ��͋敪";
            // 
            // ultraLabel12
            // 
            appearance62.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance62;
            this.ultraLabel12.Location = new System.Drawing.Point(441, 279);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel12.TabIndex = 259;
            this.ultraLabel12.Text = "�c�������\���敪";
            // 
            // ultraLabel13
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance63;
            this.ultraLabel13.Location = new System.Drawing.Point(441, 249);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel13.TabIndex = 258;
            this.ultraLabel13.Text = "�������ʋ敪";
            // 
            // GoodsNoInpDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.GoodsNoInpDiv_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsNoInpDiv_tComboEditor.Appearance = appearance59;
            this.GoodsNoInpDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.GoodsNoInpDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsNoInpDiv_tComboEditor.ItemAppearance = appearance60;
            this.GoodsNoInpDiv_tComboEditor.Location = new System.Drawing.Point(627, 99);
            this.GoodsNoInpDiv_tComboEditor.Name = "GoodsNoInpDiv_tComboEditor";
            this.GoodsNoInpDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.GoodsNoInpDiv_tComboEditor.TabIndex = 10;
            // 
            // MemoMoveDiv_tComboEditor
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.MemoMoveDiv_tComboEditor.ActiveAppearance = appearance43;
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.MemoMoveDiv_tComboEditor.Appearance = appearance44;
            this.MemoMoveDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MemoMoveDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MemoMoveDiv_tComboEditor.ItemAppearance = appearance45;
            this.MemoMoveDiv_tComboEditor.Location = new System.Drawing.Point(627, 249);
            this.MemoMoveDiv_tComboEditor.Name = "MemoMoveDiv_tComboEditor";
            this.MemoMoveDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MemoMoveDiv_tComboEditor.TabIndex = 15;
            // 
            // RemCntAutoDspDiv_tComboEditor
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.RemCntAutoDspDiv_tComboEditor.ActiveAppearance = appearance40;
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            this.RemCntAutoDspDiv_tComboEditor.Appearance = appearance41;
            this.RemCntAutoDspDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.RemCntAutoDspDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RemCntAutoDspDiv_tComboEditor.ItemAppearance = appearance42;
            this.RemCntAutoDspDiv_tComboEditor.Location = new System.Drawing.Point(627, 279);
            this.RemCntAutoDspDiv_tComboEditor.Name = "RemCntAutoDspDiv_tComboEditor";
            this.RemCntAutoDspDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.RemCntAutoDspDiv_tComboEditor.TabIndex = 16;
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(22, 81);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(825, 3);
            this.DivideLine_Label.TabIndex = 261;
            // 
            // ultraLabel6
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance34;
            this.ultraLabel6.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(468, 42);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(239, 24);
            this.ultraLabel6.TabIndex = 262;
            this.ultraLabel6.Text = "���[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(595, 334);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 18;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(464, 334);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 13;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance6;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCodeAllowZero2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(214, 42);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(35, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // EraNameDispCd2_tComEditor
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.EraNameDispCd2_tComEditor.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            this.EraNameDispCd2_tComEditor.Appearance = appearance28;
            this.EraNameDispCd2_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EraNameDispCd2_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EraNameDispCd2_tComEditor.ItemAppearance = appearance29;
            this.EraNameDispCd2_tComEditor.Location = new System.Drawing.Point(214, 219);
            this.EraNameDispCd2_tComEditor.Name = "EraNameDispCd2_tComEditor";
            this.EraNameDispCd2_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.EraNameDispCd2_tComEditor.TabIndex = 7;
            // 
            // ultraLabel4
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance22;
            this.ultraLabel4.Location = new System.Drawing.Point(16, 219);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(194, 24);
            this.ultraLabel4.TabIndex = 264;
            this.ultraLabel4.Text = "�����\���敪(�`�[)";
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(464, 334);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 17;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // DefTtlBillOutput_tComboEditor
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.DefTtlBillOutput_tComboEditor.ActiveAppearance = appearance49;
            appearance50.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance50.ForeColorDisabled = System.Drawing.Color.Black;
            this.DefTtlBillOutput_tComboEditor.Appearance = appearance50;
            this.DefTtlBillOutput_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DefTtlBillOutput_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DefTtlBillOutput_tComboEditor.ItemAppearance = appearance51;
            this.DefTtlBillOutput_tComboEditor.Location = new System.Drawing.Point(627, 159);
            this.DefTtlBillOutput_tComboEditor.Name = "DefTtlBillOutput_tComboEditor";
            this.DefTtlBillOutput_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DefTtlBillOutput_tComboEditor.TabIndex = 12;
            // 
            // DefDtlBillOutput_tComboEditor
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.TextVAlignAsString = "Middle";
            this.DefDtlBillOutput_tComboEditor.ActiveAppearance = appearance46;
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            this.DefDtlBillOutput_tComboEditor.Appearance = appearance47;
            this.DefDtlBillOutput_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DefDtlBillOutput_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DefDtlBillOutput_tComboEditor.ItemAppearance = appearance48;
            this.DefDtlBillOutput_tComboEditor.Location = new System.Drawing.Point(627, 189);
            this.DefDtlBillOutput_tComboEditor.Name = "DefDtlBillOutput_tComboEditor";
            this.DefDtlBillOutput_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DefDtlBillOutput_tComboEditor.TabIndex = 13;
            // 
            // DefSlTtlBillOutput_tComboEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.DefSlTtlBillOutput_tComboEditor.ActiveAppearance = appearance23;
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.DefSlTtlBillOutput_tComboEditor.Appearance = appearance24;
            this.DefSlTtlBillOutput_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DefSlTtlBillOutput_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DefSlTtlBillOutput_tComboEditor.ItemAppearance = appearance25;
            this.DefSlTtlBillOutput_tComboEditor.Location = new System.Drawing.Point(627, 219);
            this.DefSlTtlBillOutput_tComboEditor.Name = "DefSlTtlBillOutput_tComboEditor";
            this.DefSlTtlBillOutput_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DefSlTtlBillOutput_tComboEditor.TabIndex = 14;
            // 
            // ultraLabel5
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance52;
            this.ultraLabel5.Location = new System.Drawing.Point(441, 159);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(159, 24);
            this.ultraLabel5.TabIndex = 268;
            this.ultraLabel5.Text = "���v�������o�͋敪";
            // 
            // ultraLabel8
            // 
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance53;
            this.ultraLabel8.Location = new System.Drawing.Point(441, 189);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(159, 24);
            this.ultraLabel8.TabIndex = 269;
            this.ultraLabel8.Text = "���א������o�͋敪";
            // 
            // ultraLabel9
            // 
            appearance54.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance54;
            this.ultraLabel9.Location = new System.Drawing.Point(441, 219);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(180, 24);
            this.ultraLabel9.TabIndex = 270;
            this.ultraLabel9.Text = "�`�[���v�������o�͋敪";
            // 
            // DtlCalcStckCntDsp_Label
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.DtlCalcStckCntDsp_Label.Appearance = appearance80;
            this.DtlCalcStckCntDsp_Label.Location = new System.Drawing.Point(16, 249);
            this.DtlCalcStckCntDsp_Label.Name = "DtlCalcStckCntDsp_Label";
            this.DtlCalcStckCntDsp_Label.Size = new System.Drawing.Size(194, 24);
            this.DtlCalcStckCntDsp_Label.TabIndex = 271;
            this.DtlCalcStckCntDsp_Label.Text = "���׎Z�o��݌ɐ��\���敪";
            // 
            // StockShowType_Lable
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.StockShowType_Lable.Appearance = appearance80;
            this.StockShowType_Lable.Location = new System.Drawing.Point(16, 279);
            this.StockShowType_Lable.Name = "StockShowType_Lable";
            this.StockShowType_Lable.Size = new System.Drawing.Size(194, 24);
            this.StockShowType_Lable.TabIndex = 272;
            this.StockShowType_Lable.Text = "���i�݌Ƀ}�X�^�N���敪";
            // 
            // DtlCalcStckCntDsp_tComboEditor
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance77.ForeColor = System.Drawing.Color.Black;
            appearance77.TextVAlignAsString = "Middle";
            this.DtlCalcStckCntDsp_tComboEditor.ActiveAppearance = appearance77;
            appearance78.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.DtlCalcStckCntDsp_tComboEditor.Appearance = appearance78;
            this.DtlCalcStckCntDsp_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DtlCalcStckCntDsp_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DtlCalcStckCntDsp_tComboEditor.ItemAppearance = appearance79;
            this.DtlCalcStckCntDsp_tComboEditor.Location = new System.Drawing.Point(214, 249);
            this.DtlCalcStckCntDsp_tComboEditor.Name = "DtlCalcStckCntDsp_tComboEditor";
            this.DtlCalcStckCntDsp_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DtlCalcStckCntDsp_tComboEditor.TabIndex = 8;
            // 
            // GoodsStockMstBootDiv_tComboEditor
            // 
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance77.ForeColor = System.Drawing.Color.Black;
            appearance77.TextVAlignAsString = "Middle";
            this.GoodsStockMstBootDiv_tComboEditor.ActiveAppearance = appearance77;
            appearance78.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsStockMstBootDiv_tComboEditor.Appearance = appearance78;
            this.GoodsStockMstBootDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.GoodsStockMstBootDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsStockMstBootDiv_tComboEditor.ItemAppearance = appearance79;
            this.GoodsStockMstBootDiv_tComboEditor.Location = new System.Drawing.Point(214, 279);
            this.GoodsStockMstBootDiv_tComboEditor.Name = "GoodsStockMstBootDiv_tComboEditor";
            this.GoodsStockMstBootDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.GoodsStockMstBootDiv_tComboEditor.TabIndex = 9;
            // 
            // SFCMN09080UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(886, 397);
            this.Controls.Add(this.GoodsStockMstBootDiv_tComboEditor);
            this.Controls.Add(this.StockShowType_Lable);
            this.Controls.Add(this.DtlCalcStckCntDsp_tComboEditor);
            this.Controls.Add(this.DtlCalcStckCntDsp_Label);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.DefSlTtlBillOutput_tComboEditor);
            this.Controls.Add(this.DefDtlBillOutput_tComboEditor);
            this.Controls.Add(this.DefTtlBillOutput_tComboEditor);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.EraNameDispCd2_tComEditor);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.RemCntAutoDspDiv_tComboEditor);
            this.Controls.Add(this.MemoMoveDiv_tComboEditor);
            this.Controls.Add(this.GoodsNoInpDiv_tComboEditor);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.EraNameDispCd1_tComEditor);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.IniDspPrslOrCorpCd_tComEditor);
            this.Controls.Add(this.IniDspPrslOrCorpCd_uLabel);
            this.Controls.Add(this.DefDspClctMnyMonthCd_tComEditor);
            this.Controls.Add(this.DefDspClctMnyMonthCd_uLabel);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.DefDspCustClctMnyDay_tNedit);
            this.Controls.Add(this.DefDspCustClctMnyDay_uLabel);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.DefDspCustTtlDay_tNedit);
            this.Controls.Add(this.DefDspCustTtlDay_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09080UA";
            this.Text = "�S�̏����\���ݒ�";
            this.Load += new System.EventHandler(this.SFCMN09080UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09080UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09080UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.DefDspCustTtlDay_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspCustClctMnyDay_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDspClctMnyMonthCd_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IniDspPrslOrCorpCd_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraNameDispCd1_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNoInpDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoMoveDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemCntAutoDspDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EraNameDispCd2_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefTtlBillOutput_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefDtlBillOutput_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DefSlTtlBillOutput_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtlCalcStckCntDsp_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsStockMstBootDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region -- Events --
		/*----------------------------------------------------------------------------------*/
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region -- Private Members --
		/*----------------------------------------------------------------------------------*/
		private AllDefSetAcs _allDefSetAcs;
        //private AllDefSet _prevAllDefSet;  // DEL 2008/06/04
        //private bool _nextData;  // DEL 2008/06/04
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _allDefSetTable;

        private SecInfoAcs _secInfoAcs;     // ADD 2009/04/17

        // �� 20070207 18322 a MA.NS�p�ɕύX
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // �� 20070207 18322 a

		// �ۑ���r�pClone
		private AllDefSet _allDefSetClone;

        // �� 20061205 18322 d
		//// �ύX�t���O
		//private bool _changeFlg = false;
        // �� 20061205 18322 d

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

		// Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE                          = "�폜��";  // ADD 2008/06/04
		private const string VIEW_SECTION_CODE_TITLE	          = "���_�R�[�h";
		private const string VIEW_SECTION_NAME_TITLE              = "���_����";
        // �� 20061205 18322 d
		//private const string VIEW_DISTRICT_CODE_TITLE             = "�ǋ�R�[�h";
        //private const string VIEW_DISTRICT_NAME_TITLE = "�����ǋ�";
        //private const string VIEW_DEF_DISP_ADDR_CD1_TITLE = "�����\���Z���R�[�h1";
		//private const string VIEW_DEF_DISP_ADDR_CD2_TITLE         = "�����\���Z���R�[�h2";
		//private const string VIEW_DEF_DISP_ADDR_CD3_TITLE         = "�����\���Z���R�[�h3";
		//private const string VIEW_DEF_DISP_ADDRESS_TITLE          = "�����\���Z��";
        //private const string VIEW_NO88_AUTO_LIA_CALC_DIV_CD_TITLE = "88No.�����ӎZ��敪";
        //private const string VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE = "88No.�����ӎZ��";
        // �� 20061205 18322 d

        // 2007.03.05 modified by T-Kidate
        //private const string VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE = "���Ӑ�R�[�h�������ԋ敪";
        //private const string VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE = "���Ӑ�R�[�h��������";
        //private const string VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE   = "���Ӑ�폜�`�F�b�N�敪";
        //private const string VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE   = "���Ӑ�폜�`�F�b�N";
        //private const string VIEW_DEF_DSP_CUST_TTL_DAY_TITLE      = "���Ӑ����";
        //private const string VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE = "���Ӑ�W����";
        //private const string VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE = "�W�����敪";
        //private const string VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE = "�W����";
        //private const string VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE   = "�l��@�l�敪";
        //private const string VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE   = "�l��@�l";
        //private const string VIEW_INIT_DSP_DM_DIV_CD_TITLE        = "�c�l�敪";
        //private const string VIEW_INIT_DSP_DM_DIV_NM_TITLE        = "�c�l";
        //private const string VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE   = "�������o�͋敪";
        //private const string VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE   = "�������o��";
        // 2007.03.28 DANJO CHG START
        //private const string VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE = "�ڋq�R�[�h�������ԋ敪";
        //private const string VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE = "�ڋq�R�[�h��������";
        //private const string VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE = "���Ӑ�폜�`�F�b�N�敪";
        //private const string VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE = "���Ӑ�폜�`�F�b�N";
        //private const string VIEW_DEF_DSP_CUST_TTL_DAY_TITLE = "�ڋq����";
        //private const string VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE = "�ڋq�W����";
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE = "���Ӑ�R�[�h�������ԋ敪";
        private const string VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE = "���Ӑ�R�[�h��������";
        private const string VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE   = "���Ӑ�폜�`�F�b�N�敪";
        private const string VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE   = "���Ӑ�폜�`�F�b�N";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        private const string VIEW_DEF_DSP_CUST_TTL_DAY_TITLE      = "���Ӑ����";
        private const string VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE = "���Ӑ�W����";
        // 2007.03.28 DANJO CHG END
        private const string VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE = "�W�����敪";
        private const string VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE = "�W����";
        private const string VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE = "�l��@�l�敪";
        private const string VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE = "�l��@�l";
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string VIEW_INIT_DSP_DM_DIV_CD_TITLE = "�c�l�敪";
        private const string VIEW_INIT_DSP_DM_DIV_NM_TITLE = "�c�l";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        // --- ADD  ���r��  2010/01/18 ---------->>>>>
        //private const string VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE = "�������o�͋敪";
        //private const string VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE = "�������o��";
        // --- ADD  ���r��  2010/01/18 ----------<<<<<
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string VIEW_MEMBER_INFO_DISP_CD_TITLE = "������Ǘ��敪";
        private const string VIEW_MEMBER_INFO_DISP_NM_TITLE = "������Ǘ�";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // �� 20061205 18322 d
		//private const string VIEW_CAR_FIX_SELECT_METHOD_NM_TITLE  = "�ԗ��m��I�����";
        // �� 20061205 18322 d
        //private const string NEWFLG_TITLE = "�V�K�f�[�^�t���O";  // DEL 2008/06/09
		private const string VIEW_GUID_KEY_TITLE		          = "Guid";

        /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
        private const string VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE = "���z�\�����@�敪";
        private const string VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE = "���z�\�����@";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
           --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima
        private const string VIEW_ERA_NAME_DISP_CD1_TITLE = "�����\���敪(�N��)";
        private const string VIEW_ERA_NAME_DISP_CD2_TITLE = "�����\���敪(�`�[)";
        //private const string VIEW_ERA_NAME_DISP_CD3_TITLE = "�����\���敪(���̑�)"; // DEL 2009/01/30

        private const string VIEW_GOODS_NO_INP_DIV_TITLE = "�i�ԓ��͋敪";
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string VIEW_JAN_CODE_INP_DIV_TITLE = "�i�`�m�R�[�h���͋敪";
        private const string VIEW_UN_CST_LINK_DIV_TITLE = "���P���A���敪";
        private const string VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE = "����Ŏ����␳�敪";
        private const string VIEW_REMAIN_CNT_MNG_DIV_TITLE = "�c���Ǘ��敪";
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        private const string VIEW_MEMO_MOVE_DIV_TITLE = "�������ʋ敪";
        private const string VIEW_REM_CNT_AUTO_DSP_DIV_TITLE = "�c�������\���敪";
        /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
        private const string VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE = "���z�\���|���K�p�敪";
           --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
        // �� 20061205 18322 d
        //// ���^���������̃A�N�Z�X�N���X
        //private LandTrnsNmAcs _landTrnsNmAcs;
        //// ���^���������̊i�[�p
        //private ArrayList _landTrnsNmBuf;
        //
        //private const string VIEW_LAND_TRANS_BRANCH_CD_TITLE      = "���^�������R�[�h";
        //private const string VIEW_LAND_TRANS_BRANCH_NM_TITLE = "���^����������";
        // �� 20061205 18322 d
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END

        // --- ADD  ���r��  2010/01/18 ---------->>>>>
        private const string VIEW_DEF_TTL_BILL_OUT_PUT_CD_TITLE = "���v�������o�͋敪";
        private const string VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE = "���v�������o��";
        private const string VIEW_DEF_DTL_BILL_OUT_PUT_CD_TITLE = "���א������o�͋敪";
        private const string VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE = "���א������o��";
        private const string VIEW_DEF_SL_TTL_BILL_OUT_PUT_CD_TITLE = "�`�[���v�������o�͋敪";
        private const string VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE = "�`�[���v�������o��";
        // --- ADD  ���r��  2010/01/18 ----------<<<<<

		// View�pGrid�ɕ\��������e�[�u����
		private const string VIEW_TABLE = "VIEW_TABLE";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";	   
		private const string DELETE_MODE = "�폜���[�h";

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        private const string ALL_SECTIONCODE = "00";
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        //ADD  START zhouyu 2011/07/19------------------------------------------------------------>>>>>
        private const string UPDATE_AFTERCODE = "�����㔽�f";
        private const string UPDATE_AFTERDTL = "�s�ړ������f";
        private const string VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE = "���׎Z�o��݌ɐ��\���敪";
        //ADD  END zhouyu 2011/07/19--------------------------------------------------------------<<<<<

        // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
        private const string STOCKMSTBOOTDIV1 = "���i�݌Ƀ}�X�^";
        private const string STOCKMSTBOOTDIV2 = "���i�݌Ƀ}�X�^�U";
        private const string VIEW_DEF_STOCKMSTBOOT_TITLE = "���i�݌Ƀ}�X�^�N���敪";
        // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<

        private bool isError = false; // ADD 2011/09/07

		#endregion

		#region -- Main --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09080UA());
		}
		# endregion

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
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}
		#endregion

		#region -- Public Methods --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
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
		/// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
		///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList allDefSets = null;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			if (readCount == 0)
			{
				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
				status = this._allDefSetAcs.SearchAll(out allDefSets, this._enterpriseCode);
				this._totalCount = allDefSets.Count;
			}
			else
			{
				status = this._allDefSetAcs.SearchSpecificationAll(
					out allDefSets,
					out this._totalCount,
					out this._nextData,
					this._enterpriseCode,
					readCount,
					this._prevAllDefSet);
			}
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._allDefSetTable.Clear();

            status = this._allDefSetAcs.SearchAll(out allDefSets, this._enterpriseCode);
            this._totalCount = allDefSets.Count;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
					if( allDefSets.Count > 0 ) {
						// �ŏI�̑S�̏����\���ݒ�I�u�W�F�N�g��ޔ�����
						this._prevAllDefSet = ((AllDefSet)allDefSets[allDefSets.Count - 1]).Clone();
					}
                       --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                    
                    int index = 0;

					foreach(AllDefSet allDefSet in allDefSets)
					{
					�@�@AllDefSetToDataSet(allDefSet.Clone(), index);
						++index;
					}
					break;
				}

				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}

				default:
				{
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFCMN09080U",							// �A�Z���u��ID
						"�S�̏����\���ݒ�",              �@�@     // �v���O��������
						"Search",                               // ��������
						TMsgDisp.OPE_GET,                       // �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._allDefSetAcs,					    // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��

					break;
				}
			}
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �����Ȃ�
            return 9;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			int dummy = 0;
			ArrayList allDefSets = null;

			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			if (readCount == 0)
			{
				readCount = this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._allDefSetAcs.SearchSpecificationAll(
				out allDefSets,
				out dummy,
				out this._nextData,
				this._enterpriseCode,
				readCount,
				this._prevAllDefSet);

			switch (status) 
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( allDefSets.Count > 0 ) {
						// �ŏI�̑S�̏����\���ݒ�N���X��ޔ�����
						this._prevAllDefSet = ((AllDefSet)allDefSets[allDefSets.Count - 1]).Clone();
					}
					int index = 0;
					foreach(AllDefSet allDefSet in allDefSets)
					{
						if (this._allDefSetTable.ContainsKey(allDefSet.FileHeaderGuid) == false)
						{  
							index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count;
							AllDefSetToDataSet(allDefSet.Clone(), index);
						}
					}
					break;
				}

				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break; 
				}
				 
				default:
				{
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFCMN09080U",							// �A�Z���u��ID
						"�S�̏����\���ݒ�", �@�@                  // �v���O��������
						"SearchNext",                           // ��������
						TMsgDisp.OPE_GET,                       // �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._allDefSetAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��

					break;
				}
			}
			return status;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B(������)</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public int Delete()
		{
            //return 0;  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            AllDefSet allDefSet = (AllDefSet)this._allDefSetTable[guid];

            // --- ADD 2008/09/12 --------------------------------------------------------------------->>>>>
            if (allDefSet.SectionCode.Trim() == ALL_SECTIONCODE)
            {
                TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        "SFCMN09080U",							// �A�Z���u��ID
                        "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                return (0);
            }
            // --- ADD 2008/09/12 ---------------------------------------------------------------------<<<<<

            int status;

            // �S�̏����\���ݒ���_���폜����
            status = this._allDefSetAcs.LogicalDelete(ref allDefSet);
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
                            "SFCMN09080U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._allDefSetAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // �S�̏����\���ݒ���N���X�f�[�^�Z�b�g�W�J����
            AllDefSetToDataSet(allDefSet.Clone(), this.DataIndex);

            return status;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note        : ������������s���܂��B(������)</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
        /// <br>Update Note : ���N</br>
        /// <br>Date        : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�    : 10901273-00  2013/06/18�z�M��</br>
        /// <br>            : Redmine#35434�̑Ή�</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            
            // �� 20061205 18322 d
            //appearanceTable.Add(VIEW_DISTRICT_CODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
			//appearanceTable.Add(VIEW_DISTRICT_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DISP_ADDR_CD1_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DISP_ADDR_CD2_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DISP_ADDR_CD3_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DISP_ADDRESS_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            //
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            //appearanceTable.Add(VIEW_LAND_TRANS_BRANCH_CD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //appearanceTable.Add(VIEW_LAND_TRANS_BRANCH_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			//appearanceTable.Add(VIEW_NO88_AUTO_LIA_CALC_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // �� 20061205 18322 d

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
            appearanceTable.Add(VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			appearanceTable.Add(VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			appearanceTable.Add(VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			appearanceTable.Add(VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            appearanceTable.Add(VIEW_DEF_DSP_CUST_TTL_DAY_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"#0\\��",Color.Black));
            appearanceTable.Add(VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "#0\\��", Color.Black));
			appearanceTable.Add(VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
            appearanceTable.Add(VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			appearanceTable.Add(VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			appearanceTable.Add(VIEW_INIT_DSP_DM_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            //appearanceTable.Add(VIEW_INIT_DSP_DM_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            appearanceTable.Add(VIEW_INIT_DSP_DM_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // ----------------------------------------------------------------
            // --- DEL  ���r��  2010/01/18 ---------->>>>>
			//appearanceTable.Add(VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			//appearanceTable.Add(VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // --- DEL  ���r��  2010/01/18 ----------<<<<<
			// �� 20061205 18322 d
            //appearanceTable.Add(VIEW_CAR_FIX_SELECT_METHOD_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // �� 20061205 18322 d

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            appearanceTable.Add(VIEW_MEMBER_INFO_DISP_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            // 2007.03.28 DANJO CHG START
            appearanceTable.Add(VIEW_MEMBER_INFO_DISP_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            //appearanceTable.Add(VIEW_MEMBER_INFO_DISP_NM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));
            // 2007.03.28 DANJO CHG END
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima
            appearanceTable.Add(VIEW_ERA_NAME_DISP_CD1_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_ERA_NAME_DISP_CD2_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(VIEW_ERA_NAME_DISP_CD3_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); // DEL 2009/01/30
            appearanceTable.Add(VIEW_GOODS_NO_INP_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            appearanceTable.Add(VIEW_JAN_CODE_INP_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_UN_CST_LINK_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_REMAIN_CNT_MNG_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            appearanceTable.Add(VIEW_MEMO_MOVE_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_REM_CNT_AUTO_DSP_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            appearanceTable.Add(VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima

            //appearanceTable.Add(NEWFLG_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));  // DEL 2008/06/09
			appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            appearanceTable.Add(VIEW_DEF_TTL_BILL_OUT_PUT_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_DTL_BILL_OUT_PUT_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_SL_TTL_BILL_OUT_PUT_CD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU  2011/07/19
            //�d���E�o�׌㐔�\���敪
            appearanceTable.Add(VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //ADD END ZHOUYU  2011/07/19
            appearanceTable.Add(VIEW_DEF_STOCKMSTBOOT_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black)); // ���i�݌Ƀ}�X�^�\���敪�@// ADD ���N�@2013/05/02�@Redmine#35434
			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date	   : 2005.10.03</br>
		/// </remarks>
		private void ScreenReconstruction()
		{		
			if (this.DataIndex < 0)
			{
				// �o�^���[�h
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible                = true;
				this.Cancel_Button.Visible            = true;
                // �� 20061205 18322 d
				//this.DefDispAddrGuide_uButton.Visible = true;
                // �� 20061205 18322 d

				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.10 TAKAHASHI ADD START
//				this.DistrictCode_tComEditor.NullText = "";
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.10 TAKAHASHI ADD END
			}
			else
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
				AllDefSet allDefSet = new AllDefSet();
				allDefSet = (AllDefSet)this._allDefSetTable[guid];
				string NewFlg = this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][NEWFLG_TITLE].ToString();

				if(Convert.ToInt32(NewFlg) == 1)
				{
					allDefSet.SectionCode = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_SECTION_CODE_TITLE];
				}

                // �� 20061205 18322 d
				//this.DistrictCode_tComEditor.Focus();
                // �� 20061205 18322 d

				// �N���[�����쐬
				this._allDefSetClone = allDefSet.Clone();
				AllDefSetToScreen(allDefSet);

				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;

				if(Convert.ToInt32(NewFlg) == 1)
				{
					// �o�^���[�h
					this.Mode_Label.Text = INSERT_MODE;

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.10 TAKAHASHI ADD START
//					this.DistrictCode_tComEditor.NullText = "";
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.10 TAKAHASHI ADD END
				}
				else
				{
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					this.Ok_Button.Visible                = true;
					this.Cancel_Button.Visible            = true;

                    // �� 20061205 18322 d
					//this.DefDispAddrGuide_uButton.Visible = true;
                    // �� 20061205 18322 d

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.10 TAKAHASHI ADD START
//					this.DistrictCode_tComEditor.NullText = "���o�^";
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.10 TAKAHASHI ADD END
				}
			}
		}
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                AllDefSet allDefSet = new AllDefSet();
                //�N���[���쐬
                this._allDefSetClone = allDefSet.Clone();
                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToAllDefSet(ref this._allDefSetClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCodeAllowZero2.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                AllDefSet allDefSet = (AllDefSet)this._allDefSetTable[guid];

                // �S�̏����\�����N���X��ʓW�J����
                AllDefSetToScreen(allDefSet);

                if (allDefSet.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.DefDspCustTtlDay_tNedit.Focus();

                    // �N���[���쐬
                    this._allDefSetClone = allDefSet.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToAllDefSet(ref this._allDefSetClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();

                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// <br>Update Note: ���N</br>�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M���@ </br> 
        /// <br>�@         : Redmine#35434�̑Ή�</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    this.Renewal_Button.Visible = true;     // ADD 2009/04/17
                    this.SectionName_tEdit.Enabled = false;
                    this.DefDspCustTtlDay_tNedit.Enabled = true;
                    this.DefDspCustClctMnyDay_tNedit.Enabled = true;
                    this.DefDspClctMnyMonthCd_tComEditor.Enabled = true;
                    this.EraNameDispCd1_tComEditor.Enabled = true;
                    this.EraNameDispCd2_tComEditor.Enabled = true;
                    //this.EraNameDispCd3_tComEditor.Enabled = true; // DEL 2009/01/30
                    this.GoodsNoInpDiv_tComboEditor.Enabled = true;
                    /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
                    this.TotalAmoDispWayCd_tComEditor.Enabled = true;
                       --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
                    this.IniDspPrslOrCorpCd_tComEditor.Enabled = true;
                    /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
                    this.InitDspDmDiv_tComEditor.Enabled = true;
                       --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
                    // --- DEL  ���r��  2010/01/18 ---------->>>>>
                    //this.DefDspBillPrtDivCd_tComEditor.Enabled = true;
                    // --- DEL  ���r��  2010/01/18 ----------<<<<<
                    /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
                    this.CnsTaxAutoCorrDiv_tComboEditor.Enabled = true;
                    this.RemainCntMngDiv_tComboEditor.Enabled = true;
                       --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
                    this.MemoMoveDiv_tComboEditor.Enabled = true;
                    this.RemCntAutoDspDiv_tComboEditor.Enabled = true;
                    /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
                    this.TtlAmntDspRateDivCd_tComboEditor.Enabled = true;
                       --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
                    // --- ADD  ���r��  2010/01/18 ---------->>>>>
                    this.DefTtlBillOutput_tComboEditor.Enabled = true;
                    this.DefDtlBillOutput_tComboEditor.Enabled = true;
                    this.DefSlTtlBillOutput_tComboEditor.Enabled = true;
                    // --- ADD  ���r��  2010/01/18 ----------<<<<<

                    if (mode == INSERT_MODE)
                    {
                        // �V�K���[�h
                        this.tEdit_SectionCodeAllowZero2.Enabled = true;
                        this.SectionGuide_Button.Enabled = true;
                    }
                    else
                    {
                        // �X�V���[�h
                        this.tEdit_SectionCodeAllowZero2.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                    }
                    this.DtlCalcStckCntDsp_tComboEditor.Enabled = true;//ADD 2011/09/07
                    this.GoodsStockMstBootDiv_tComboEditor.Enabled = true; // ADD ���N 2013/05/02 Redmine#35434

                    break;
                case DELETE_MODE:
                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    this.Renewal_Button.Visible = false;    // ADD 2009/04/17
                    this.tEdit_SectionCodeAllowZero2.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    this.SectionName_tEdit.Enabled = false;
                    this.DefDspCustTtlDay_tNedit.Enabled = false;
                    this.DefDspCustClctMnyDay_tNedit.Enabled = false;
                    this.DefDspClctMnyMonthCd_tComEditor.Enabled = false;
                    this.EraNameDispCd1_tComEditor.Enabled = false;
                    this.EraNameDispCd2_tComEditor.Enabled = false;
                    //this.EraNameDispCd3_tComEditor.Enabled = false; // DEL 2009/01/30
                    this.GoodsNoInpDiv_tComboEditor.Enabled = false;
                    /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
                    this.TotalAmoDispWayCd_tComEditor.Enabled = false;
                       --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
                    this.IniDspPrslOrCorpCd_tComEditor.Enabled = false;
                    /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
                    this.InitDspDmDiv_tComEditor.Enabled = false;
                       --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
                    // --- DEL  ���r��  2010/01/18 ---------->>>>>
                    //this.DefDspBillPrtDivCd_tComEditor.Enabled = false;
                    // --- DEL  ���r��  2010/01/18 ----------<<<<<
                    /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
                    this.CnsTaxAutoCorrDiv_tComboEditor.Enabled = false;
                    this.RemainCntMngDiv_tComboEditor.Enabled = false;
                       --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
                    this.MemoMoveDiv_tComboEditor.Enabled = false;
                    this.RemCntAutoDspDiv_tComboEditor.Enabled = false;
                    /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
                    this.TtlAmntDspRateDivCd_tComboEditor.Enabled = false;
                       --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
                    // --- ADD  ���r��  2010/01/18 ---------->>>>>
                    this.DefTtlBillOutput_tComboEditor.Enabled = false;
                    this.DefDtlBillOutput_tComboEditor.Enabled = false;
                    this.DefSlTtlBillOutput_tComboEditor.Enabled = false;
                �@�@// --- ADD  ���r��  2010/01/18 ----------<<<<<
                    this.DtlCalcStckCntDsp_tComboEditor.Enabled = false;//ADD 2011/09/07
                    this.GoodsStockMstBootDiv_tComboEditor.Enabled = false; // ADD ���N 2013/05/02 Redmine#35434
                    break;
            }
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����\���ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="allDefSet">�S�̏����\���ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �S�̏����\���ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private void AllDefSetToDataSet(AllDefSet allDefSet, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (allDefSet.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = allDefSet.UpdateDateTimeJpInFormal;
            }

			// ���_�R�[�h
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = allDefSet.SectionCode;

            string sectionName = GetSectionName(allDefSet.SectionCode);
            // --- ADD 2011/09/07 -------------------------------->>>>>
            if(sectionName=="")
            {
                sectionName = "�S�Ћ���";
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            // �� 20061205 18322 d
            //// �ǋ�R�[�h
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISTRICT_CODE_TITLE] = allDefSet.DistrictCode;
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISTRICT_NAME_TITLE] = allDefSet.DistrictName;
            //
			//// �����\���Z��
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDR_CD1_TITLE] = allDefSet.DefDispAddrCd1;
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDR_CD2_TITLE] = allDefSet.DefDispAddrCd2;
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDR_CD3_TITLE] = allDefSet.DefDispAddrCd3;
            //
            // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
//			// this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDR_CD4_TITLE] = allDefSet.DefDispAddrCd4;
			// // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END
			//
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DISP_ADDRESS_TITLE]  = allDefSet.DefDispAddress;
            //
			// // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            //string LandTransBranchNm = "";
            //this.GetLandTransBranchName(1, allDefSet.LandTransBranchCd, out LandTransBranchNm);
            //
            // // ���^�������ԍ�
            //if (allDefSet.LandTransBranchCd != 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LAND_TRANS_BRANCH_CD_TITLE] = allDefSet.LandTransBranchCd;
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LAND_TRANS_BRANCH_CD_TITLE] = DBNull.Value;
            //}
            //
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_LAND_TRANS_BRANCH_NM_TITLE] = LandTransBranchNm;
			// // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			// // 88No.�����ӎZ��
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NO88_AUTO_LIA_CALC_DIV_CD_TITLE] = allDefSet.No88AutoLiaCalcDiv;
			//switch(allDefSet.No88AutoLiaCalcDiv)
			//{
			//	case 0:
			//		this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE] = "��";
			//		break;
            //
			//	case 1:
			//		this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE] = "�L";
			//		break;			
			//}
            // �� 20061205 18322 d

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			// ���z�\�����@
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE] = allDefSet.TotalAmountDispWayCd;
			switch(allDefSet.TotalAmountDispWayCd)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE] = "���z�\�����Ȃ��i�Ŕ����j";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE] = "���z�\������i�ō��݁j";
					break;			
			}
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// �ڋq�R�[�h��������
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE] = allDefSet.CustCdAutoNumbering;
			switch(allDefSet.CustCdAutoNumbering)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE] = "����͉�";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE] = "����͕s��";
					break;			
			}

			// ���Ӑ�폜�`�F�b�N
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE] = allDefSet.CustomerDelChkDivCd;
			switch(allDefSet.CustomerDelChkDivCd)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE] = "�������`�[���ݎ��͍폜�s��";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE] = "�������`�[���ݎ��ł��폜�\";
					break;			
			}
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // ���Ӑ����
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CUST_TTL_DAY_TITLE] = allDefSet.DefDspCustTtlDay;

			// ���Ӑ�W����
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE] = allDefSet.DefDspCustClctMnyDay;

			// �W����
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE] = allDefSet.DefDspClctMnyMonthCd;
			switch(allDefSet.DefDspClctMnyMonthCd)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE] = "����";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE] = "����";
					break;
	
				case 2:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE] = "���X��";
					break;

                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE] = "���X�X";
                    break;
			}

			// �l��@�l
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE] = allDefSet.IniDspPrslOrCorpCd;
			switch(allDefSet.IniDspPrslOrCorpCd)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "�l";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "�@�l";
					break;

				case 2:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "����@�l";
					break;

				case 3:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "�Ǝ�";
					break;

				case 4:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "�Ј�";
					break;

				case 5:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE] = "�`�`";
					break;
			}

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// �c�l
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INIT_DSP_DM_DIV_CD_TITLE] = allDefSet.InitDspDmDiv;
			switch(allDefSet.InitDspDmDiv)
			{
				case 0:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INIT_DSP_DM_DIV_NM_TITLE] = "�c�l�o�͂���";
					break;

				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_INIT_DSP_DM_DIV_NM_TITLE] = "�c�l�o�͂��Ȃ�";
					break;
			}
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            // �������o��
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE] = allDefSet.DefDspBillPrtDivCd;
            //switch(allDefSet.DefDspBillPrtDivCd)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE] = "�������o�͂���";
            //        break;

            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE] = "�������o�͂��Ȃ�";
            //        break;
            //}
            // --- ADD  ���r��  2010/01/18 ----------<<<<<

            // �� 20061205 18322 d
			// // �ԗ��m��I�����
			//this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CAR_FIX_SELECT_METHOD_NM_TITLE] = allDefSet.CarFixSelectMethodNm;
            // �� 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            // ������Ǘ��敪
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMBER_INFO_DISP_CD_TITLE] = allDefSet.MemberInfoDispCd;
            switch (allDefSet.MemberInfoDispCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMBER_INFO_DISP_NM_TITLE] = "������Ǘ�����";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMBER_INFO_DISP_NM_TITLE] = "������Ǘ����Ȃ�";
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima
            switch (allDefSet.EraNameDispCd1)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD1_TITLE] = "����";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD1_TITLE] = "�a��";
                    break;
            }
            switch (allDefSet.EraNameDispCd2)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD2_TITLE] = "����";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD2_TITLE] = "�a��";
                    break;
            }
            // --- DEL 2009/01/30 -------------------------------->>>>>
            //switch (allDefSet.EraNameDispCd3)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD3_TITLE] = "����";
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ERA_NAME_DISP_CD3_TITLE] = "�a��";
            //        break;
            //}
            // --- DEL 2009/01/30 --------------------------------<<<<<
            switch (allDefSet.GoodsNoInpDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODS_NO_INP_DIV_TITLE] = "�C��";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GOODS_NO_INP_DIV_TITLE] = "�K�{";
                    break;
            }
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            switch (allDefSet.CnsTaxAutoCorrDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE] = "����";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE] = "�蓮";
                    break;
            }
            switch (allDefSet.RemainCntMngDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REMAIN_CNT_MNG_DIV_TITLE] = "����";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REMAIN_CNT_MNG_DIV_TITLE] = "���Ȃ�";
                    break;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            switch (allDefSet.MemoMoveDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMO_MOVE_DIV_TITLE] = "����";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMO_MOVE_DIV_TITLE] = "�ЊO�����̂�";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MEMO_MOVE_DIV_TITLE] = "���Ȃ�";
                    break;
            }
            switch (allDefSet.RemCntAutoDspDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "���Ȃ�";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "�o�׎c����׎c�̂�";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "�󔭒��c�̂�";
                    break;
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "�o�׎c����׎c���󔭒��c";
                    break;
                case 4:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_REM_CNT_AUTO_DSP_DIV_TITLE] = "�󔭒��c���o�׎c����׎c";
                    break;
            }

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            switch (allDefSet.TtlAmntDspRateDivCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE] = "�ō��P��";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE] = "�Ŕ��P��";
                    break;
            }
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima
            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            //���v�������o��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_TTL_BILL_OUT_PUT_CD_TITLE] = allDefSet.DefTtlBillOutput;
            switch (allDefSet.DefTtlBillOutput)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE] = "�o�͂���";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE] = "�o�͂��Ȃ�";
                    break;
            }

            //���א������o��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DTL_BILL_OUT_PUT_CD_TITLE] = allDefSet.DefDtlBillOutput;
            switch (allDefSet.DefDtlBillOutput)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE] = "�o�͂���";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE] = "�o�͂��Ȃ�";
                    break;
            }

            //�`�[���v������
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_SL_TTL_BILL_OUT_PUT_CD_TITLE] = allDefSet.DefSlTtlBillOutput;
            switch (allDefSet.DefSlTtlBillOutput)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE] = "�o�͂���";
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE] = "�o�͂��Ȃ�";
                    break;
            }
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU  2011/07/19
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE] = allDefSet.DtlCalcStckCntDsp;
            switch (allDefSet.DtlCalcStckCntDsp)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE] = UPDATE_AFTERCODE;
                    break;

                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE] = UPDATE_AFTERDTL;
                    break;
            }
            //ADD END ZHOUYU 2011/07/19
            // ----- ADD ���N�@2013/05/02�@Redmine#35434 ----->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_STOCKMSTBOOT_TITLE] = allDefSet.GoodsStockMSTBootDiv;
            switch (allDefSet.GoodsStockMSTBootDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_STOCKMSTBOOT_TITLE] = STOCKMSTBOOTDIV1;
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEF_STOCKMSTBOOT_TITLE] = STOCKMSTBOOTDIV2;
                    break;
            }
            // ----- ADD ���N�@2013/05/02�@Redmine#35434 -----<<<<<

            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][NEWFLG_TITLE] = 0;  // DEL 2008/06/09
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = allDefSet.FileHeaderGuid;
			
			if (this._allDefSetTable.ContainsKey(allDefSet.FileHeaderGuid) == true)
			{
				this._allDefSetTable.Remove(allDefSet.FileHeaderGuid);
			}
			this._allDefSetTable.Add(allDefSet.FileHeaderGuid, allDefSet);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable allDefSetTable = new DataTable(VIEW_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            allDefSetTable.Columns.Add(DELETE_DATE, typeof(string));			// �폜��
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
            
            allDefSetTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));

            // �� 20061205 18322 d
			//allDefSetTable.Columns.Add(VIEW_DISTRICT_CODE_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DISTRICT_NAME_TITLE, typeof(string));
			//allDefSetTable.Columns.Add(VIEW_DEF_DISP_ADDR_CD1_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DEF_DISP_ADDR_CD2_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DEF_DISP_ADDR_CD3_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DEF_DISP_ADDRESS_TITLE, typeof(string));
            //
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            //allDefSetTable.Columns.Add(VIEW_LAND_TRANS_BRANCH_CD_TITLE, typeof(int));
            //allDefSetTable.Columns.Add(VIEW_LAND_TRANS_BRANCH_NM_TITLE, typeof(string));
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			//allDefSetTable.Columns.Add(VIEW_NO88_AUTO_LIA_CALC_DIV_CD_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_NO88_AUTO_LIA_CALC_DIV_NM_TITLE, typeof(string));
            // �� 20061205 18322 d

            // 2007.03.28 DANJO MOV START
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
            //allDefSetTable.Columns.Add(VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE, typeof(int));
            //allDefSetTable.Columns.Add(VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE, typeof(string));
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
            // 2007.03.28 DANJO MOV END

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			allDefSetTable.Columns.Add(VIEW_CUST_CD_AUTO_NUMBERING_CD_TITLE, typeof(int));
			allDefSetTable.Columns.Add(VIEW_CUST_CD_AUTO_NUMBERING_NM_TITLE, typeof(string));
			allDefSetTable.Columns.Add(VIEW_CUSTOMER_DEL_CHK_DIV_CD_TITLE, typeof(int));
			allDefSetTable.Columns.Add(VIEW_CUSTOMER_DEL_CHK_DIV_NM_TITLE, typeof(string));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            allDefSetTable.Columns.Add(VIEW_DEF_DSP_CUST_TTL_DAY_TITLE, typeof(int));
			allDefSetTable.Columns.Add(VIEW_DEF_DSP_CUST_CLCT_MNY_DAY_TITLE, typeof(int));
			allDefSetTable.Columns.Add(VIEW_DEF_DSP_CLCT_MNY_MONTH_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_DEF_DSP_CLCT_MNY_MONTH_NM_TITLE, typeof(string));

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            // 2007.03.28 DANJO MOV START
            allDefSetTable.Columns.Add(VIEW_TOTAL_AMO_DISP_WAY_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_TOTAL_AMO_DISP_WAY_NM_TITLE, typeof(string));
            // 2007.03.28 DANJO MOV END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            allDefSetTable.Columns.Add(VIEW_INI_DSP_PRSL_OR_CORP_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_INI_DSP_PRSL_OR_CORP_NM_TITLE, typeof(string));
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            allDefSetTable.Columns.Add(VIEW_INIT_DSP_DM_DIV_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_INIT_DSP_DM_DIV_NM_TITLE, typeof(string));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // --- UPD  ���r��  2010/01/18 ---------->>>>>
            //allDefSetTable.Columns.Add(VIEW_DEF_DSP_BILL_PRT_DIV_CD_TITLE, typeof(int));
			//allDefSetTable.Columns.Add(VIEW_DEF_DSP_BILL_PRT_DIV_NM_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DEF_TTL_BILL_OUT_PUT_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_DEF_TTL_BILL_OUT_PUT_NM_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DEF_DTL_BILL_OUT_PUT_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_DEF_DTL_BILL_OUT_PUT_NM_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_DEF_SL_TTL_BILL_OUT_PUT_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_DEF_SL_TTL_BILL_OUT_PUT_NM_TITLE, typeof(string));
            // --- UPD  ���r��  2010/01/18 ----------<<<<<
            // �� 20061205 18322 d
			//allDefSetTable.Columns.Add(VIEW_CAR_FIX_SELECT_METHOD_NM_TITLE, typeof(string));
            // �� 20061205 18322 d
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            allDefSetTable.Columns.Add(VIEW_MEMBER_INFO_DISP_CD_TITLE, typeof(int));
            allDefSetTable.Columns.Add(VIEW_MEMBER_INFO_DISP_NM_TITLE, typeof(string));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima
            allDefSetTable.Columns.Add(VIEW_ERA_NAME_DISP_CD1_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_ERA_NAME_DISP_CD2_TITLE, typeof(string));
            //allDefSetTable.Columns.Add(VIEW_ERA_NAME_DISP_CD3_TITLE, typeof(string)); // DEL 2009/01/30

            allDefSetTable.Columns.Add(VIEW_GOODS_NO_INP_DIV_TITLE, typeof(string));
            
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            allDefSetTable.Columns.Add(VIEW_JAN_CODE_INP_DIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_UN_CST_LINK_DIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_CNS_TAX_AUTO_CORR_DIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_REMAIN_CNT_MNG_DIV_TITLE, typeof(string));
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            allDefSetTable.Columns.Add(VIEW_MEMO_MOVE_DIV_TITLE, typeof(string));
            allDefSetTable.Columns.Add(VIEW_REM_CNT_AUTO_DSP_DIV_TITLE, typeof(string));
            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            allDefSetTable.Columns.Add(VIEW_TTL_AMNT_DSP_RATE_DIV_TITLE, typeof(string));
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima

            

            //allDefSetTable.Columns.Add(NEWFLG_TITLE, typeof(short));  // DEL 2008/06/09
			allDefSetTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));
            //ADD START ZHOUYU 2011/07/19
            //�d���E�o�׌㐔�\���敪
            allDefSetTable.Columns.Add(VIEW_DEF_AFTER_STOCK_OUT_DIP_CD_TITLE, typeof(string));
            //ADD END ZHOUYU 2011/07/19

            allDefSetTable.Columns.Add(VIEW_DEF_STOCKMSTBOOT_TITLE, typeof(string)); //ADD ���N�@2013/05/02�@Redmine#35434
			this.Bind_DataSet.Tables.Add(allDefSetTable);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // �� 20061205 18322 d
			// // �ǋ�
			//DistrictCode_tComEditor.Items.Clear();
			//SetAreaKind(this.DistrictCode_tComEditor);
			//this.DistrictCode_tComEditor.MaxDropDownItems = DistrictCode_tComEditor.Items.Count;
            //
			// // 88No.�����ӎZ��
			//No88AutoLiaCalcDiv_tComEditor.Items.Clear();
			//No88AutoLiaCalcDiv_tComEditor.Items.Add(0, "��");
			//No88AutoLiaCalcDiv_tComEditor.Items.Add(1, "�L");
			//No88AutoLiaCalcDiv_tComEditor.MaxDropDownItems = No88AutoLiaCalcDiv_tComEditor.Items.Count;
            //
			// // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
			// ���z�\�����@
			TotalAmoDispWayCd_tComEditor.Items.Clear();
			TotalAmoDispWayCd_tComEditor.Items.Add(0, "���z�\�����Ȃ��i�Ŕ����j");
			TotalAmoDispWayCd_tComEditor.Items.Add(1, "���z�\������i�ō��݁j");
			TotalAmoDispWayCd_tComEditor.MaxDropDownItems = TotalAmoDispWayCd_tComEditor.Items.Count;
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// ���Ӑ�R�[�h��������
			CustCdAutoNumbering_tComEditor.Items.Clear();
			CustCdAutoNumbering_tComEditor.Items.Add(0, "����͉�");
			CustCdAutoNumbering_tComEditor.Items.Add(1, "����͕s��");
			CustCdAutoNumbering_tComEditor.MaxDropDownItems = CustCdAutoNumbering_tComEditor.Items.Count;

			// ���Ӑ�폜�`�F�b�N
			CustomerDelChkDivCd_tComEditor.Items.Clear();
			CustomerDelChkDivCd_tComEditor.Items.Add(0, "�������`�[���ݎ��͍폜�s��");
			CustomerDelChkDivCd_tComEditor.Items.Add(1, "�������`�[���ݎ��ł��폜�\");
			CustomerDelChkDivCd_tComEditor.MaxDropDownItems = CustomerDelChkDivCd_tComEditor.Items.Count;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // �W����
			DefDspClctMnyMonthCd_tComEditor.Items.Clear();
			DefDspClctMnyMonthCd_tComEditor.Items.Add(0, "����");
			DefDspClctMnyMonthCd_tComEditor.Items.Add(1, "����");
            DefDspClctMnyMonthCd_tComEditor.Items.Add(2, "���X��");
            DefDspClctMnyMonthCd_tComEditor.Items.Add(3, "���X�X");
			DefDspClctMnyMonthCd_tComEditor.MaxDropDownItems = DefDspClctMnyMonthCd_tComEditor.Items.Count;

			// �l��@�l
			IniDspPrslOrCorpCd_tComEditor.Items.Clear();
			IniDspPrslOrCorpCd_tComEditor.Items.Add(0, "�l");
			IniDspPrslOrCorpCd_tComEditor.Items.Add(1, "�@�l");
			IniDspPrslOrCorpCd_tComEditor.Items.Add(2, "����@�l");
			IniDspPrslOrCorpCd_tComEditor.Items.Add(3, "�Ǝ�");
			IniDspPrslOrCorpCd_tComEditor.Items.Add(4, "�Ј�");
            IniDspPrslOrCorpCd_tComEditor.Items.Add(5, "�`�`");
			IniDspPrslOrCorpCd_tComEditor.MaxDropDownItems = IniDspPrslOrCorpCd_tComEditor.Items.Count;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// �c�l
			InitDspDmDiv_tComEditor.Items.Clear();
			InitDspDmDiv_tComEditor.Items.Add(0, "�c�l�o�͂���");
			InitDspDmDiv_tComEditor.Items.Add(1, "�c�l�o�͂��Ȃ�");
			InitDspDmDiv_tComEditor.MaxDropDownItems = InitDspDmDiv_tComEditor.Items.Count;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- DEL  ���r��  2010/01/18 ---------->>>>>
			// �������o��
			//DefDspBillPrtDivCd_tComEditor.Items.Clear();
			//DefDspBillPrtDivCd_tComEditor.Items.Add(0, "�������o�͂���");
			//DefDspBillPrtDivCd_tComEditor.Items.Add(1, "�������o�͂��Ȃ�");
			//DefDspBillPrtDivCd_tComEditor.MaxDropDownItems = DefDspBillPrtDivCd_tComEditor.Items.Count;
            // --- DEL  ���r��  2010/01/18 ----------<<<<<

            // �� 20061205 18322 d
			// // �ԗ��m��I�����
			//CarFixSelectMethod_tComEditor.Items.Clear();
			//AllDefSet allDefSet = new AllDefSet();
			//foreach (int ix in AllDefSet.CarFixSelectMethods)
			//{
			//	CarFixSelectMethod_tComEditor.Items.Add(ix, allDefSet.GetCarFixSelectMethodNm(ix));
			//}
			//CarFixSelectMethod_tComEditor.MaxDropDownItems = CarFixSelectMethod_tComEditor.Items.Count;
            // �� 20061205 18322 d

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            MemberInfoDispCd_tComboEditor.Items.Clear();
            MemberInfoDispCd_tComboEditor.Items.Add(0, "������Ǘ�����");
            MemberInfoDispCd_tComboEditor.Items.Add(1, "������Ǘ����Ȃ�");
            MemberInfoDispCd_tComboEditor.MaxDropDownItems = MemberInfoDispCd_tComboEditor.Items.Count;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            // �����\���敪�P
            EraNameDispCd1_tComEditor.Items.Clear();
            EraNameDispCd1_tComEditor.Items.Add(0, "����");
            EraNameDispCd1_tComEditor.Items.Add(1, "�a��");
            EraNameDispCd1_tComEditor.MaxDropDownItems = EraNameDispCd1_tComEditor.Items.Count;
            // �����\���敪�Q
            EraNameDispCd2_tComEditor.Items.Clear();
            EraNameDispCd2_tComEditor.Items.Add(0, "����");
            EraNameDispCd2_tComEditor.Items.Add(1, "�a��");
            EraNameDispCd2_tComEditor.MaxDropDownItems = EraNameDispCd2_tComEditor.Items.Count;
            // �����\���敪�R
            // --- DEL 2009/01/30 -------------------------------->>>>>
            //EraNameDispCd3_tComEditor.Items.Clear();
            //EraNameDispCd3_tComEditor.Items.Add(0, "����");
            //EraNameDispCd3_tComEditor.Items.Add(1, "�a��");
            //EraNameDispCd3_tComEditor.MaxDropDownItems = EraNameDispCd3_tComEditor.Items.Count;
            // --- DEL 2009/01/30 --------------------------------<<<<<
            // �i�ԓ��͋敪
            GoodsNoInpDiv_tComboEditor.Items.Clear();
            GoodsNoInpDiv_tComboEditor.Items.Add(0, "�C��");
            GoodsNoInpDiv_tComboEditor.Items.Add(1, "�K�{");
            GoodsNoInpDiv_tComboEditor.MaxDropDownItems = GoodsNoInpDiv_tComboEditor.Items.Count;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            // ����Ŏ����␳�敪
            CnsTaxAutoCorrDiv_tComboEditor.Items.Clear();
            CnsTaxAutoCorrDiv_tComboEditor.Items.Add(0, "����");
            CnsTaxAutoCorrDiv_tComboEditor.Items.Add(1, "�蓮");
            CnsTaxAutoCorrDiv_tComboEditor.MaxDropDownItems = CnsTaxAutoCorrDiv_tComboEditor.Items.Count;
            // �c���Ǘ��敪
            RemainCntMngDiv_tComboEditor.Items.Clear();
            RemainCntMngDiv_tComboEditor.Items.Add(0, "����");
            RemainCntMngDiv_tComboEditor.Items.Add(1, "���Ȃ�");
            RemainCntMngDiv_tComboEditor.MaxDropDownItems = RemainCntMngDiv_tComboEditor.Items.Count;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            // �������ʋ敪
            MemoMoveDiv_tComboEditor.Items.Clear();
            MemoMoveDiv_tComboEditor.Items.Add(0, "����");
            MemoMoveDiv_tComboEditor.Items.Add(1, "�ЊO�����̂�");
            MemoMoveDiv_tComboEditor.Items.Add(2, "���Ȃ�");
            MemoMoveDiv_tComboEditor.MaxDropDownItems = MemoMoveDiv_tComboEditor.Items.Count;
            // �c�������\���敪
            RemCntAutoDspDiv_tComboEditor.Items.Clear();
            RemCntAutoDspDiv_tComboEditor.Items.Add(0, "���Ȃ�");
            RemCntAutoDspDiv_tComboEditor.Items.Add(1, "�o�׎c����׎c�̂�");
            RemCntAutoDspDiv_tComboEditor.Items.Add(2, "�󔭒��c�̂�");
            RemCntAutoDspDiv_tComboEditor.Items.Add(3, "�o�׎c����׎c���󔭒��c");
            RemCntAutoDspDiv_tComboEditor.Items.Add(4, "�󔭒��c���o�׎c����׎c");
            RemCntAutoDspDiv_tComboEditor.MaxDropDownItems = RemCntAutoDspDiv_tComboEditor.Items.Count;

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            // ���z�\���|���K�p�敪
            TtlAmntDspRateDivCd_tComboEditor.Items.Clear();
            TtlAmntDspRateDivCd_tComboEditor.Items.Add(0, "�ō��P��");
            TtlAmntDspRateDivCd_tComboEditor.Items.Add(1, "�Ŕ��P��");
            TtlAmntDspRateDivCd_tComboEditor.MaxDropDownItems = TtlAmntDspRateDivCd_tComboEditor.Items.Count;
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            //���v������
            DefTtlBillOutput_tComboEditor.Items.Clear();
            DefTtlBillOutput_tComboEditor.Items.Add(0, "�o�͂���");
            DefTtlBillOutput_tComboEditor.Items.Add(1, "�o�͂��Ȃ�");
            //���א�����
            DefDtlBillOutput_tComboEditor.Items.Clear();
            DefDtlBillOutput_tComboEditor.Items.Add(0, "�o�͂���");
            DefDtlBillOutput_tComboEditor.Items.Add(1, "�o�͂��Ȃ�");
            //�`�[���v������
            DefSlTtlBillOutput_tComboEditor.Items.Clear();
            DefSlTtlBillOutput_tComboEditor.Items.Add(0, "�o�͂���");
            DefSlTtlBillOutput_tComboEditor.Items.Add(1, "�o�͂��Ȃ�");
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU 2011/07/19
            //�d���E�o�׌㐔�\���敪
            DtlCalcStckCntDsp_tComboEditor.Items.Clear();
            DtlCalcStckCntDsp_tComboEditor.Items.Add(0, UPDATE_AFTERCODE);
            DtlCalcStckCntDsp_tComboEditor.Items.Add(1, UPDATE_AFTERDTL);
            //ADD END ZHOUYU 2011/07/19
            // ----- ADD ���N 2013/05/02 Redmine#35434 ----->>>>>
            GoodsStockMstBootDiv_tComboEditor.Items.Clear();
            GoodsStockMstBootDiv_tComboEditor.Items.Add(0, STOCKMSTBOOTDIV1);
            GoodsStockMstBootDiv_tComboEditor.Items.Add(1, STOCKMSTBOOTDIV2);
            // ----- ADD ���N 2013/05/02 Redmine#35434 -----<<<<<

        }
		
		/*----------------------------------------------------------------------------------*/
        /* ��2007.05.19 deleted b by T-Kidate : �uXML�R�����g���L���Ȍ���v�f�̒��ɂ���܂���B�v�Ή�
        /// <summary>
       ///	�n����0�Z�b�g�����i20061205�F�g�уV�X�e���ł͎g�p���Ȃ��̂ō폜�j
       /// </summary>
       /// <param name="targetCombo">�Z�b�g����TComboEditor</param>
       /// <remarks>
       /// <br>Note	    : �n��O���[�v�}�X�^����n����0�̂��̂��擾��
       ///					  TComboEditor�Ɋi�[���܂��B</br>
       /// <br>Programmer  : 23006  ���� ���q</br>
       /// <br>Date	    : 2005.10.04</br>
       /// <br></br>
       /// <br>Update Note : 2005.12.19  23006 ���� ���q</br>
       /// <br>               �E�L���b�V����{���Ή�</br>
       /// </remarks>
            ��*/ 
       // �� 20061205 18322 d
       //private void SetAreaKind(TComboEditor targetCombo)
       //{	
       //	if (this._allDefSetAcs.areaKindList != null)
       //	{
       //		foreach (AreaGroup areaGroup in this._allDefSetAcs.areaKindList)
       //		{
       //			if ((areaGroup.LogicalDeleteCode == 0) &&
       //				(areaGroup.AreaKind == 0))
       //			{
       //				// TComboEditor�ɒn�於�̂��i�[
       //				targetCombo.Items.Add(areaGroup.AreaGroupCode, areaGroup.AreaName);
       //			}
       //		}
       //	}
       //}
       // �� 20061205 18322 d

       /*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note        : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
        /// <br>Update Note : ���N</br>
        /// <br>Date        : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�    : 10901273-00 2013/06/18�z�M��</br>
        /// <br>            : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private void ScreenClear()
		{
            this.tEdit_SectionCodeAllowZero2.DataText                    = "";  // ADD 2008/06/04
			this.SectionName_tEdit.DataText                    = "";

            // �� 20061205 18322 d
			//this.DistrictCode_tComEditor.Value                 = -1;
			//this.DefDispAddrCd1_tNedit.DataText                = "";
			//this.DefDispAddrCd2_tNedit.DataText                = "";
			//this.DefDispAddrCd3_tNedit.DataText                = "";
			//this.DefDispAddress_tEdit.DataText                 = "";
            // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
			//this.LandTransBranchCd_tNedit.DataText             = "";
            //this.LandTransBranchCd_tEdit.DataText              = "";
			// // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
			//this.No88AutoLiaCalcDiv_tComEditor.SelectedIndex   = 0;
            // �� 20061205 18322 d

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			this.TotalAmoDispWayCd_tComEditor.SelectedIndex    = 0;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			this.CustCdAutoNumbering_tComEditor.SelectedIndex  = 0;
			this.CustomerDelChkDivCd_tComEditor.SelectedIndex  = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            this.DefDspCustTtlDay_tNedit.DataText              = "";
			this.DefDspCustClctMnyDay_tNedit.DataText          = "";
			this.DefDspClctMnyMonthCd_tComEditor.SelectedIndex = 0;
			this.IniDspPrslOrCorpCd_tComEditor.SelectedIndex   = 0;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			this.InitDspDmDiv_tComEditor.SelectedIndex         = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // --- DEL  ���r��  2010/01/18 ---------->>>>>
            //this.DefDspBillPrtDivCd_tComEditor.SelectedIndex = 0;
            // --- DEL  ���r��  2010/01/18 ----------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            this.MemberInfoDispCd_tComboEditor.SelectedIndex   = 0;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // �� 20061205 18322 d 
			//this.CarFixSelectMethod_tComEditor.SelectedIndex   = 0;
            //
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.01.13 TAKAHASHI ADD START
			//// �ύX�t���O
			//this._changeFlg = false;
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.01.13 TAKAHASHI ADD END
            // �� 20061205 18322 d

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            this.EraNameDispCd1_tComEditor.SelectedIndex = 0;
            this.EraNameDispCd2_tComEditor.SelectedIndex = 0;
            //this.EraNameDispCd3_tComEditor.SelectedIndex = 0; // DEL 2009/01/30
            this.GoodsNoInpDiv_tComboEditor.SelectedIndex = 0;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            this.CnsTaxAutoCorrDiv_tComboEditor.SelectedIndex = 0;
            this.RemainCntMngDiv_tComboEditor.SelectedIndex = 0;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            this.MemoMoveDiv_tComboEditor.SelectedIndex = 0;
            this.RemCntAutoDspDiv_tComboEditor.SelectedIndex = 0;
            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            this.TtlAmntDspRateDivCd_tComboEditor.SelectedIndex = 0;
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            this.DefTtlBillOutput_tComboEditor.SelectedIndex = 0;
            this.DefDtlBillOutput_tComboEditor.SelectedIndex = 0;
            this.DefSlTtlBillOutput_tComboEditor.SelectedIndex = 0;
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU 2011/07/19
            //�d���E�o�׌㐔�\���敪
            this.DtlCalcStckCntDsp_tComboEditor.SelectedIndex = 0;
            //ADD END ZHOUYU 2011/07/19
            this.GoodsStockMstBootDiv_tComboEditor.SelectedIndex = 0;//ADD ���N 2013/05/02 Redmine#35434 

        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �S�̏����\���ݒ�N���X��ʓW�J����
		/// </summary>
		/// <param name="allDefSet">�S�̏����\���ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �S�̏����\���ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private void AllDefSetToScreen(AllDefSet allDefSet)
		{
            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero2.DataText = allDefSet.SectionCode;


            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
  			// ���_����
            // add 2008/11/05
            string sectionName = string.Empty;
            if (allDefSet.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "�S�Ћ���";
            }
            else
            {
                sectionName = this._allDefSetAcs.GetSectionName(allDefSet.EnterpriseCode, allDefSet.SectionCode);
            }
            // add 2008/11/05 end
            this.SectionName_tEdit.DataText = sectionName;

            // �� 20061205 18322 d
            // // �ǋ�
			//this.DistrictCode_tComEditor.Value = allDefSet.DistrictCode;
            //
            // // �����\���Z��
            //if (allDefSet.DefDispAddrCd1 != 0)
            //{
            //    this.DefDispAddrCd1_tNedit.DataText = allDefSet.DefDispAddrCd1.ToString();
            //}
            //else
            //{
            //    this.DefDispAddrCd1_tNedit.Clear();
            //}
            //
            //if (allDefSet.DefDispAddrCd2 != 0)
            //{
            //    this.DefDispAddrCd2_tNedit.DataText = allDefSet.DefDispAddrCd2.ToString();
            //}
            //else
            //{
            //    this.DefDispAddrCd2_tNedit.Clear();
            //}
            //
            //if (allDefSet.DefDispAddrCd3 != 0)
            //{
            //    this.DefDispAddrCd3_tNedit.DataText = allDefSet.DefDispAddrCd3.ToString();
            //}
            //else
            //{
            //    this.DefDispAddrCd3_tNedit.Clear();
            //}
            //
			// // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
//			//this.DefDispAddrCd4_tNedit.DataText = allDefSet.DefDispAddrCd4.ToString();
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END
			//
			// this.DefDispAddress_tEdit.DataText  = allDefSet.DefDispAddress;
            //
            // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            // string LandTransBranchNm = "";
            // this.GetLandTransBranchName(1, allDefSet.LandTransBranchCd, out LandTransBranchNm);
            //
            // // ���^�������ԍ�
            // this.LandTransBranchCd_tNedit.DataText = allDefSet.LandTransBranchCd.ToString();
            // this.LandTransBranchCd_tEdit.DataText = LandTransBranchNm;
            // // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			// // 88No.�����ӎZ��
			//this.No88AutoLiaCalcDiv_tComEditor.SelectedIndex = allDefSet.No88AutoLiaCalcDiv;
            // �� 20061205 18322 d

            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
			// ���z�\�����@
			this.TotalAmoDispWayCd_tComEditor.SelectedIndex  = allDefSet.TotalAmountDispWayCd;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// �ڋq�R�[�h��������
			this.CustCdAutoNumbering_tComEditor.SelectedIndex = allDefSet.CustCdAutoNumbering;

			// ���Ӑ�폜�`�F�b�N
			this.CustomerDelChkDivCd_tComEditor.SelectedIndex = allDefSet.CustomerDelChkDivCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            // ���Ӑ����
			this.DefDspCustTtlDay_tNedit.DataText = allDefSet.DefDspCustTtlDay.ToString();

			// ���Ӑ�W����
			this.DefDspCustClctMnyDay_tNedit.DataText = allDefSet.DefDspCustClctMnyDay.ToString();

			// �W����
			this.DefDspClctMnyMonthCd_tComEditor.SelectedIndex = allDefSet.DefDspClctMnyMonthCd;

			// �l��@�l
			this.IniDspPrslOrCorpCd_tComEditor.SelectedIndex = allDefSet.IniDspPrslOrCorpCd;

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// �c�l
			this.InitDspDmDiv_tComEditor.SelectedIndex = allDefSet.InitDspDmDiv;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- DEL  ���r��  2010/01/18 ---------->>>>>
            // �������o��
			//this.DefDspBillPrtDivCd_tComEditor.SelectedIndex = allDefSet.DefDspBillPrtDivCd;
            // --- DEL  ���r��  2010/01/18 ----------<<<<<


            
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            // ������Ǘ��敪
            this.MemberInfoDispCd_tComboEditor.SelectedIndex = allDefSet.MemberInfoDispCd;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // �� 20061205 18322 d
			//// �������o��
			//this.CarFixSelectMethod_tComEditor.SelectedIndex = allDefSet.CarFixSelectMethod;
            // �� 20061205 18322 d

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            // �����\���敪�P
            this.EraNameDispCd1_tComEditor.SelectedIndex = allDefSet.EraNameDispCd1;
            // �����\���敪�Q
            this.EraNameDispCd2_tComEditor.SelectedIndex = allDefSet.EraNameDispCd2;
            // �����\���敪�R
            //this.EraNameDispCd3_tComEditor.SelectedIndex = allDefSet.EraNameDispCd3; // DEL 2009/01/30
            // �i�ԓ��͋敪
            this.GoodsNoInpDiv_tComboEditor.SelectedIndex = allDefSet.GoodsNoInpDiv;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            // ����Ŏ����␳�敪
            this.CnsTaxAutoCorrDiv_tComboEditor.SelectedIndex = allDefSet.CnsTaxAutoCorrDiv;
            // �c���Ǘ��敪
            this.RemainCntMngDiv_tComboEditor.SelectedIndex = allDefSet.RemainCntMngDiv;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            // �������ʋ敪
            this.MemoMoveDiv_tComboEditor.SelectedIndex = allDefSet.MemoMoveDiv;
            // �c�������\���敪
            this.RemCntAutoDspDiv_tComboEditor.SelectedIndex = allDefSet.RemCntAutoDspDiv;
            /* --- DEL 2009/01/05 --------------------------------------------------------------------->>>>>
            // ���z�\���|���K�p�敪
            this.TtlAmntDspRateDivCd_tComboEditor.SelectedIndex = allDefSet.TtlAmntDspRateDivCd;
               --- DEL 2009/01/05 ---------------------------------------------------------------------<<<<<*/
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            this.DefTtlBillOutput_tComboEditor.SelectedIndex = allDefSet.DefTtlBillOutput;
            this.DefDtlBillOutput_tComboEditor.SelectedIndex = allDefSet.DefDtlBillOutput;
            this.DefSlTtlBillOutput_tComboEditor.SelectedIndex = allDefSet.DefSlTtlBillOutput;
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU 2011/07/19
            //�d���E�o�׌㐔�\���敪
            this.DtlCalcStckCntDsp_tComboEditor.SelectedIndex = allDefSet.DtlCalcStckCntDsp;
            //ADD END ZHOUYU 2011/07/19
            this.GoodsStockMstBootDiv_tComboEditor.SelectedIndex = allDefSet.GoodsStockMSTBootDiv;//ADD ���N 2013/05/02 Redmine#35434 

        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʏ��S�̏����\���ݒ�N���X�i�[����
		/// </summary>
		/// <param name="allDefSet">�S�̏����\���ݒ�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�S�̏����\���ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date	   : 2005.10.03</br>
        /// <br>Update Note: ���N</br>
        /// <br>Date       : 2013/05/02</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>           : Redmine#35434�̑Ή�</br>
		/// </remarks>
		private void ScreenToAllDefSet(ref AllDefSet allDefSet)
		{
			if (allDefSet == null)
			{
				// �V�K�̏ꍇ
				allDefSet = new AllDefSet();
			}

			// ���_����
			//allDefSet.SectionName = this.SectionName_tEdit.DataText;

            // �� 20061205 18322 d
			//// �ǋ�
			//if ((int)this.DistrictCode_tComEditor.SelectedIndex < 0) 
			//{
			//	allDefSet.DistrictCode = 0;
			//	allDefSet.DistrictName = "";
			//}
			//else 
			//{
			//	allDefSet.DistrictCode = (int)this.DistrictCode_tComEditor.Value;
			//  allDefSet.DistrictName = this.DistrictCode_tComEditor.SelectedItem.ToString();
			//}
            //
			//// �����\���Z��
			//allDefSet.DefDispAddrCd1 = this.DefDispAddrCd1_tNedit.GetInt();
			//allDefSet.DefDispAddrCd2 = this.DefDispAddrCd2_tNedit.GetInt();
			//allDefSet.DefDispAddrCd3 = this.DefDispAddrCd3_tNedit.GetInt();
            //
			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI DELETE START
            ////allDefSet.DefDispAddrCd4 = this.DefDispAddrCd4_tNedit.GetInt();
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI DELETE END
			//
			//allDefSet.DefDispAddress = this.DefDispAddress_tEdit.DataText;
            //
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            //// ���^�������ԍ�
            //allDefSet.LandTransBranchCd = this.LandTransBranchCd_tNedit.GetInt();
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
            //
			//// 88No.�����ӎZ��
			//allDefSet.No88AutoLiaCalcDiv = this.No88AutoLiaCalcDiv_tComEditor.SelectedIndex;
            // �� 20061205 18322 d

            // --- CHG 2009/01/05 --------------------------------------------------------------------->>>>>
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.04 TAKAHASHI ADD START
            //// ���z�\�����@
            //allDefSet.TotalAmountDispWayCd = (int)this.TotalAmoDispWayCd_tComEditor.Value;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.04 TAKAHASHI ADD END
            // ���z�\�����@
            allDefSet.TotalAmountDispWayCd = 0;
            // --- CHG 2009/01/05 ---------------------------------------------------------------------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// �ڋq�R�[�h��������
			allDefSet.CustCdAutoNumbering = this.CustCdAutoNumbering_tComEditor.SelectedIndex;

			// ���Ӑ�폜�`�F�b�N
			allDefSet.CustomerDelChkDivCd = this.CustomerDelChkDivCd_tComEditor.SelectedIndex;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // ���_�R�[�h
            allDefSet.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText;
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            //��ƃR�[�h
            allDefSet.EnterpriseCode = this._enterpriseCode; 
            
            // ���Ӑ����
			if (this.DefDspCustTtlDay_tNedit.DataText == "")
			{
				allDefSet.DefDspCustTtlDay = 31;
			}
			else
			{
				allDefSet.DefDspCustTtlDay = this.DefDspCustTtlDay_tNedit.GetInt();
			}

			// ���Ӑ�W����
			if (this.DefDspCustClctMnyDay_tNedit.DataText == "")
			{
				allDefSet.DefDspCustClctMnyDay = 10;
			}
			else
			{
				allDefSet.DefDspCustClctMnyDay = this.DefDspCustClctMnyDay_tNedit.GetInt();
			}

			// �W����
            allDefSet.DefDspClctMnyMonthCd = (int)this.DefDspClctMnyMonthCd_tComEditor.Value;

			// �l��@�l
            allDefSet.IniDspPrslOrCorpCd = (int)this.IniDspPrslOrCorpCd_tComEditor.Value;

			// �c�l
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            // DM�敪�͋����I��"���s���Ȃ�"�ɐݒ�
            // ----------------------------------------------------------------
            //allDefSet.InitDspDmDiv = this.InitDspDmDiv_tComEditor.SelectedIndex;
            allDefSet.InitDspDmDiv = 1;         // ���s���Ȃ�
            // ----------------------------------------------------------------

            // --- DEL  ���r��  2010/01/18 ---------->>>>>
			// �������o��
            //allDefSet.DefDspBillPrtDivCd = (int)this.DefDspBillPrtDivCd_tComEditor.Value;
            // --- DEL  ���r��  2010/01/18 ----------<<<<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            // 2007.03.05 added by T-Kidate
            // ������Ǘ��敪
            allDefSet.MemberInfoDispCd = this.MemberInfoDispCd_tComboEditor.SelectedIndex;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // �� 20061205 18322 d
			//// �ԗ��m�����
			//allDefSet.CarFixSelectMethod = this.CarFixSelectMethod_tComEditor.SelectedIndex;	
            // �� 20061205 18322 d

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.08.08 Tsushima ADD START
            // �����\���敪�P
            allDefSet.EraNameDispCd1 = (int)this.EraNameDispCd1_tComEditor.Value;
            // �����\���敪�Q
            allDefSet.EraNameDispCd2 = (int)this.EraNameDispCd2_tComEditor.Value;
            // �����\���敪�R
            //allDefSet.EraNameDispCd3 = (int)this.EraNameDispCd3_tComEditor.Value; // DEL 2009/01/30
            allDefSet.EraNameDispCd3 = 0; // ADD 2009/01/30
            // �i�ԓ��͋敪
            allDefSet.GoodsNoInpDiv = (int)this.GoodsNoInpDiv_tComboEditor.Value;
            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
            // ����Ŏ����␳�敪
            allDefSet.CnsTaxAutoCorrDiv = this.CnsTaxAutoCorrDiv_tComboEditor.SelectedIndex;
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
            // �c���Ǘ��敪
            //allDefSet.RemainCntMngDiv = (int)this.RemainCntMngDiv_tComboEditor.Value;
            allDefSet.RemainCntMngDiv = 0;
            // �������ʋ敪
            allDefSet.MemoMoveDiv = (int)this.MemoMoveDiv_tComboEditor.Value;
            // �c�������\���敪
            allDefSet.RemCntAutoDspDiv = (int)this.RemCntAutoDspDiv_tComboEditor.Value;
            // ���z�\���|���K�p�敪
            // --- CHG 2009/01/05 --------------------------------------------------------------------->>>>>
            //allDefSet.TtlAmntDspRateDivCd = (int)this.TtlAmntDspRateDivCd_tComboEditor.Value;
            allDefSet.TtlAmntDspRateDivCd = 0;
            // --- CHG 2009/01/05 ---------------------------------------------------------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.08.08 Tsushima ADD END

            // --- ADD  ���r��  2010/01/18 ---------->>>>>
            allDefSet.DefTtlBillOutput = (int)this.DefTtlBillOutput_tComboEditor.Value;
            allDefSet.DefDtlBillOutput = (int)this.DefDtlBillOutput_tComboEditor.Value;
            allDefSet.DefSlTtlBillOutput = (int)this.DefSlTtlBillOutput_tComboEditor.Value;
            // --- ADD  ���r��  2010/01/18 ----------<<<<<
            //ADD START ZHOUYU 2011/07/19
            //�d���E�o�׌㐔�\���敪
            allDefSet.DtlCalcStckCntDsp = (int)this.DtlCalcStckCntDsp_tComboEditor.Value;
            //ADD END ZHOUYU 2011/07/19
            allDefSet.GoodsStockMSTBootDiv = (int)this.GoodsStockMstBootDiv_tComboEditor.Value;//ADD ���N 2013/05/02 Redmine#35434 

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
		/// <br>Programmer : 23006�@���� ���q</br>
		/// <br>Date	   : 2005.10.03</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
			{
				TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
					"SFCMN09080U",							// �A�Z���u��ID
					"���ɑ��[�����X�V����Ă��܂��B",	    // �\�����郁�b�Z�[�W
					status,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);					// �\������{�^��
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	�S�̏����\���ݒ��ʓ��̓`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : �S�̏����\���ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date	   : 2005.10.03</br>
		/// </remarks>
		private int CheckDisplay(ref string checkMessage)
		{
			int returnStatus = 0;

			try
			{
                // �� 20061205 18322 d
				// // �ǋ�
				//if (DistrictCode_tComEditor.SelectedIndex < 0)
				//{
				//	checkMessage = "�����ǋ悪���I���ł��B";
				//	returnStatus = 10;
				//	return returnStatus;
				//}
                //
                // // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
                // // ���^�������ԍ�
                //string landTransBranchNm = "";
                //if (this.GetLandTransBranchName(1, this.LandTransBranchCd_tNedit.GetInt(), out landTransBranchNm) != 0)
                //{
                //    checkMessage = "���^�������ԍ����s���ł��B";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                // // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
                // �� 20061205 18322 d

                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                // ���_�R�[�h
                if (this.tEdit_SectionCodeAllowZero2.DataText.Trim() == "")
                {
                    checkMessage = "���_�R�[�h����͂��ĉ������B";
                    this.tEdit_SectionCodeAllowZero2.Focus(); // ADD 2011/09/07
                    returnStatus = 20;
                    return returnStatus;
                }
                // --- ADD 2011/09/07 -------------------------------->>>>>
                // ���_�R�[�h�̑��݃`�F�b�N
                bool existCheck = false;
                // �S�Ћ��ʂ͋��_�}�X�^�ɓo�^����Ă��Ȃ����߁A�`�F�b�N�̑ΏۊO
                if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText) || this.tEdit_SectionCodeAllowZero2.DataText == "0")
                {
                    foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                    {
                        if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText.TrimEnd ())
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
                if (existCheck)
                {
                   ;
                }
                else
                {
                    checkMessage = "�w�肵�����_�R�[�h�͑��݂��܂���B";
                    returnStatus = 50;
                    return returnStatus;
                }
                // --- ADD 2011/09/07 --------------------------------<<<<<
                // --- DEL 2011/09/07 -------------------------------->>>>>
                //if (GetSectionName(this.tEdit_SectionCodeAllowZero2.DataText.Trim()) == "")
                //{
                //    checkMessage = "�}�X�^�ɓo�^����Ă��܂���B";
                //    returnStatus = 20;
                //    return returnStatus;
                //}
                // --- DEL 2011/09/07 --------------------------------<<<<<
                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

				// ���Ӑ����
				if ((this.DefDspCustTtlDay_tNedit.DataText == "") || 
					(this.DefDspCustTtlDay_tNedit.GetInt() > 31))
				{
					checkMessage = "���Ӑ������ 1�`31���̊Ԃɐݒ肵�ĉ������B";
					returnStatus = 30;
					return returnStatus;
				}

				// ���Ӑ�W����
				if ((this.DefDspCustClctMnyDay_tNedit.DataText == "") || 
					(this.DefDspCustClctMnyDay_tNedit.GetInt() > 31))
				{
					checkMessage = "���Ӑ�W������ 1�`31���̊Ԃɐݒ肵�ĉ������B";
					returnStatus = 40;
					return returnStatus;
				}

				return returnStatus;
			}
			finally
			{
				if( returnStatus != 0 )
				{
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						"SFCMN09080U",							// �A�Z���u��ID
						checkMessage,	                        // �\�����郁�b�Z�[�W
						0,									    // �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��

					//�G���[�X�e�[�^�X�ɍ��킹�ăt�H�[�J�X�Z�b�g
                    switch (returnStatus)
                    {
                        case 10:
                            {
                                // �� 20061205 18322 d
                                //this.DistrictCode_tComEditor.Focus();
                                // �� 20061205 18322 d
                                break;
                            }

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
                        case 20:
                            {
                                // �� 20061205 18322 d
                                //this.LandTransBranchCd_tNedit.Focus();
                                // �� 20061205 18322 d
                                break;
                            }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END

                        case 30:
                            {
                                this.DefDspCustTtlDay_tNedit.Focus();
                                break;
                            }

                        case 40:
                            {
                                this.DefDspCustClctMnyDay_tNedit.Focus();
                                break;
                            }
                        // --- ADD 2011/09/07 -------------------------------->>>>>
                        case 50:
                            {
                                this.tEdit_SectionCodeAllowZero2.Clear();
                                this.tEdit_SectionCodeAllowZero2.Focus();
                                break;
                            }
                        // --- ADD 2011/09/07 --------------------------------<<<<<
                    }
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///�@�ۑ�����(SaveAllDefSet())
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		private bool SaveAllDefSet()
        {
            bool result = false;

            // ----- ADD 2011/09/07 ---------->>>>>
            // ���_
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                }
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            Control control = null;
			//��ʃf�[�^���̓`�F�b�N����
			string checkMessage = "";
			int chkSt = CheckDisplay(ref checkMessage);
			if( chkSt != 0 )
			{
				return result;
			}


	
			AllDefSet allDefSet = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
				allDefSet = ((AllDefSet)this._allDefSetTable[guid]).Clone();
			}

			ScreenToAllDefSet(ref allDefSet);
			int status = this._allDefSetAcs.Write(ref allDefSet);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                {
                    RepeatTransaction(status, ref control);
                    control.Focus();
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
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						"SFCMN09080U",							// �A�Z���u��ID
						"�S�̏����\���ݒ�",  �@�@                 // �v���O��������
						"SaveAllDefSet",                       // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._allDefSetAcs,				    	// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,			  		// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��

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

			AllDefSetToDataSet(allDefSet, this.DataIndex);

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
			result = true;
			return result;
		}

        /*----------------------------------------------------------------------------------*/
        /* ��2007.05.19 deleted b by T-Kidate : �uXML�R�����g���L���Ȍ���v�f�̒��ɂ���܂���B�v�Ή�
        /// <summary>
       /// �Z���R�[�h�ύX�����i20061205�F�g�уV�X�e���ł͎g�p���Ȃ����ߍ폜�j
       /// </summary>
       /// <remarks>
       /// <br>Note		: �Z���R�[�h�ɂ��킹�ĕ\������Ă��鏉���\���Z��1�̕ύX���s���܂��B</br>
       /// <br>Programmer	: 23006�@���� ���q</br>
       /// <br>Date		: 2005.10.03</br>
       /// </remarks>
            ��*/ 
       // �� 20061205 18322 d
       //private void EpAddrCdChange(int addressMode)
       //{
       //    AddressGuide addrGuide = new AddressGuide();
       //    AddressGuideResult adgRet = new AddressGuideResult();
       //
       //    int epAddrCd1 = this.DefDispAddrCd1_tNedit.GetInt();
       //    int epAddrCd2 = this.DefDispAddrCd2_tNedit.GetInt();
       //    int epAddrCd3 = this.DefDispAddrCd3_tNedit.GetInt();
       //
       //    switch (addressMode)
       //    {
       //        case 1:
       //            {
       //                this.DefDispAddrCd2_tNedit.Clear();
       //                this.DefDispAddrCd3_tNedit.Clear();
       //                this.DefDispAddress_tEdit.Clear();
       //
       //                break;
       //            }
       //
       //        case 2:
       //            {
       //                this.DefDispAddrCd3_tNedit.Clear();
       //                this.DefDispAddress_tEdit.Clear();
       //
       //                break;
       //            }
       //
       //        case 3:
       //            {
       //                this.DefDispAddress_tEdit.Clear();
       //
       //                break;
       //          }
       //    }
       //
       //    // �Z���}�X�^�Ǎ���
       //    addrGuide.SearchAddressFromAddressCode(epAddrCd1, epAddrCd2, epAddrCd3, ref adgRet);
       //
       //    if ((adgRet.PostNo != "") && (adgRet.AddressName != ""))
       //    {
       //        this.DefDispAddress_tEdit.Text = adgRet.AddressName;
       //    }
       //}
       // �� 20061205 18322 d

       /*----------------------------------------------------------------------------------*/
        /* ��2007.05.19 deleted b by T-Kidate : �uXML�R�����g���L���Ȍ���v�f�̒��ɂ���܂���B�v�Ή�
        /// <summary>
       /// ���^�����Ǐ��ύX����
       /// </summary>
       /// <param name="ix">���b�Z�[�W�\���L�� (0:���b�Z�[�W�\������  1:���b�Z�[�W�\�����Ȃ�)</param>
       /// <remarks>
       /// <br>Note		: �����R�[�h�ɂ��킹�ĕ\������Ă��闤�����̕ύX���s���܂��B</br>
       /// <br>Programmer	: 23006  ���� ���q</br>
       /// <br>Date		: 2006.09.13</br>
       /// </remarks>
           ��*/ 
       // �� 20061205 18322 d
       //private int GetLandTransBranchName(int ix, int landTransBranchCd, out string numberPlate1Name)
       //{
       //    int status = 0;
       //    numberPlate1Name = "";
       //    LandTrnsNm landTrnsNm = null;
       //
       //    // ���^�����ǃ}�X�^�Ǎ���(����̂�)
       //    // �_���폜�����擾
       //    if (this._landTrnsNmBuf == null)
       //    {
       //        status = this._landTrnsNmAcs.SearchAll(out _landTrnsNmBuf, this._enterpriseCode);
       //    }
       //
       //    if (landTransBranchCd != 0)
       //    {
       //        // ���^�����ǃ}�X�^Buffer����擾
       //        foreach (LandTrnsNm landTransNmWork in this._landTrnsNmBuf)
       //        {
       //            if (landTransNmWork.NumberPlate1Code == landTransBranchCd)
       //            {
       //                landTrnsNm = landTransNmWork.Clone();
       //                break;
       //            }
       //        }
       //
       //        // �Y���R�[�h�����������ꍇStatus��NotFound��ݒ�
       //        if (landTrnsNm == null)
       //        {
       //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
       //        }
       //
       //        switch (status)
       //        {
       //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
       //                {
       //                    if (landTrnsNm.LogicalDeleteCode != 0)
       //                    {
       //                        if (ix == 0)
       //                        {
       //                            TMsgDisp.Show(
       //                                this,								// �e�E�B���h�E�t�H�[��
       //                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
       //                                "SFCMN09080U",						// �A�Z���u���h�c�܂��̓N���X�h�c
       //                                "�}�X�^����폜����Ă��܂��B",		// �\�����郁�b�Z�[�W 
       //                                0,									// �X�e�[�^�X�l
       //                                MessageBoxButtons.OK);				// �\������{�^��
       //
       //                            numberPlate1Name = "�폜��";
       //                        }
       //                        return -2;
       //                    }
       //                    else
       //                    {
       //                        numberPlate1Name = landTrnsNm.NumberPlate1Name;
       //                    }
       //                    break;
       //                }
       //
       //            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
       //                {
       //                    if (ix == 0)
       //                    {
       //                        TMsgDisp.Show(
       //                            this,								// �e�E�B���h�E�t�H�[��
       //                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
       //                            "SFCMN09080U",						// �A�Z���u���h�c�܂��̓N���X�h�c
       //                            "�}�X�^�ɓo�^����Ă��܂���B",		// �\�����郁�b�Z�[�W 
       //                            0,									// �X�e�[�^�X�l
       //                            MessageBoxButtons.OK);				// �\������{�^��
       //
       //                        numberPlate1Name = "���o�^";
       //                    }
       //                    break;
       //                }
       //
       //            default:
       //                {
       //                    TMsgDisp.Show(
       //                        this,								  // �e�E�B���h�E�t�H�[��
       //                        emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
       //                        "SFCMN09080U",						  // �A�Z���u���h�c�܂��̓N���X�h�c
       //                        this.Text,							  // �v���O��������
       //                        "GetLandTransBranchName",			  // ��������
       //                        TMsgDisp.OPE_GET,					  // �I�y���[�V����
       //                        "�ǂݍ��݂Ɏ��s���܂����B",			  // �\�����郁�b�Z�[�W 
       //                        status,								  // �X�e�[�^�X�l
       //                        this._landTrnsNmAcs,				  // �G���[�����������I�u�W�F�N�g
       //                        MessageBoxButtons.OK,				  // �\������{�^��
       //                        MessageBoxDefaultButton.Button1);	  // �����\���{�^��
       //
       //                    numberPlate1Name = "";
       //                    break;
       //                }
       //        }
       //    }
       //    else
       //    {
       //        numberPlate1Name = "";
       //    }
       //
       //  //  return status;
       //}
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                "SFCMN09080U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�͊��Ɏg�p����Ă��܂�" , 	                    // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
                tEdit_SectionCodeAllowZero2.Focus();

                control = tEdit_SectionCodeAllowZero2;
        }






        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/6/4</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(36, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(179, 24);
            this.DefDspCustTtlDay_tNedit.Size = new System.Drawing.Size(28, 24);
            this.DefDspCustClctMnyDay_tNedit.Size = new System.Drawing.Size(28, 24);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";
            // --- DEL 2011/07/28 ----->>>>>
            //if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            //{
            //    sectionName = "�S�Ћ���";
            //    return sectionName;
            //}
            // --- DEL 2011/07/28 -----<<<<<
            // DEL 2009/04/17 ------>>>
            //ArrayList retList = new ArrayList();
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //secInfoAcs.ResetSectionInfo();
            // DEL 2009/04/17 ------<<<
            
            try
            {
                //foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)          // DEL 2009/04/17
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)      // ADD 2009/04/17
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

        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

       # endregion

       # region -- Control Events --
       /*----------------------------------------------------------------------------------*/		
		/// <summary>
		///	Form.Load �C�x���g(SFCMN9080UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		private void SFCMN09080UA_Load(object sender, System.EventArgs e)
		{
            // �� 20070207 18322 a MA.NS�p�ɕύX
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            // �� 20070207 18322 a

			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList                 = imageList24;
			this.Cancel_Button.ImageList             = imageList24;

            // �� 20061205 18322 d
			//this.DefDispAddrGuide_uButton.ImageList  = imageList16;
            //this.LandTransBranchCd_uButton.ImageList = imageList16;     // 2006.09.13 TAKAHASHI ADD
            // �� 20061205 18322 d

			this.Ok_Button.Appearance.Image                 = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image             = Size24_Index.CLOSE;

            // �� 20061205 18322 d
            //this.DefDispAddrGuide_uButton.Appearance.Image = Size16_Index.STAR1;
            //this.LandTransBranchCd_uButton.Appearance.Image = Size16_Index.STAR1;     // 2006.09.13 TAKAHASHI ADD
            // �� 20061205 18322 d

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

            // ADD 2009/04/17 ------>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // ADD 2009/04/17 ------<<<
            
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.Closing �C�x���g(SFCMN09080UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
		///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		private void SFCMN09080UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Form.VisibleChanged �C�x���g(SFCMN09080UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
		///					  ���Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006�@���� ���q</br>
		/// <br>Date		: 2005.10.03</br>
		/// </remarks>
		private void SFCMN09080UA_VisibleChanged(object sender, System.EventArgs e)
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

			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			
			ScreenClear();

            Timer.Enabled = true;
		}

		/*----------------------------------------------------------------------------------*/
        /* ��2007.05.19 deleted b by T-Kidate : �uXML�R�����g���L���Ȍ���v�f�̒��ɂ���܂���B�v�Ή�
		/// <summary>
		/// Control.Click �C�x���g(DefDispAddrGuide_uButton) 20061205(�g�уV�X�e���ł͎g�p���Ȃ����ߍ폜)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �Z���K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.04</br>
		/// </remarks>
		    ��*/
        // �� 20061205 18322 d
        //private void DefDispAddrGuide_uButton_Click(object sender, System.EventArgs e)
		//{
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.07.26 TAKAHASHI ADD END
		//	// �Z���K�C�h
		//	AddressGuide addrGuide = new AddressGuide();
        //    AddressGuideResult adgRet;
        //
        //    int epAddrCd1 = this.DefDispAddrCd1_tNedit.GetInt();  
		//	int epAddrCd2 = this.DefDispAddrCd2_tNedit.GetInt();  
		//	int epAddrCd3 = this.DefDispAddrCd3_tNedit.GetInt();
        //    DialogResult dialogResult = addrGuide.ShowAddressGuide(epAddrCd1, epAddrCd2, epAddrCd3, out adgRet);
        //
        //    if (dialogResult == DialogResult.OK)
		//	{
        //        if ((adgRet.AddressCode1Upper * 1000 + adgRet.AddressCode1Lower) == 0)
        //        {
        //            this.DefDispAddrCd1_tNedit.Clear();
        //        }
        //        else
        //        {
        //            this.DefDispAddrCd1_tNedit.SetInt(adgRet.AddressCode1Upper * 1000 + adgRet.AddressCode1Lower);
        //        }//
        //
        //        if (adgRet.AddressCode2 == 0)
        //        {
        //            this.DefDispAddrCd2_tNedit.Clear();
        //        }
        //        else
        //        {
        //            this.DefDispAddrCd2_tNedit.SetInt(adgRet.AddressCode2);
        //        }
        //
        //        if (adgRet.AddressCode3 == 0)
        //        {
        //            this.DefDispAddrCd3_tNedit.Clear();
        //        }
        //        else
        //        {
        //            this.DefDispAddrCd3_tNedit.SetInt(adgRet.AddressCode3);
        //        }
        //
		//		this.DefDispAddress_tEdit.Text = adgRet.AddressName;
		//		this.No88AutoLiaCalcDiv_tComEditor.Focus();
		//	}
		//	else
		//	{
		//		this.DefDispAddrGuide_uButton.Focus();
		//	}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.07.26 TAKAHASHI ADD END
        //
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.07.26 TAKAHASHI DELETE START
        //    //// �Z���K�C�h
        //    //AddressGuide addrGuide = new AddressGuide();
        //    //AddressGuideResult adgRet = new AddressGuideResult();
        //
        //    //string EnterpriseCode = this._enterpriseCode;
        //    //addrGuide.SearchAddress(this._enterpriseCode, ref adgRet);
        //
        //    //if (adgRet.AddressName != "")
        //    //{
        //    //    this.DefDispAddrCd1_tNedit.SetInt(adgRet.AddressCode1Upper * 1000 + adgRet.AddressCode1Lower);
        //    //    this.DefDispAddrCd2_tNedit.SetInt(adgRet.AddressCode2);
        //    //    this.DefDispAddrCd3_tNedit.SetInt(adgRet.AddressCode3);
        //
        //    //    this.DefDispAddress_tEdit.Text = adgRet.AddressName;
        //    //    this.No88AutoLiaCalcDiv_tComEditor.Focus();
        //    //}
        //    //else
        //    //{
        //    //    this.DefDispAddrGuide_uButton.Focus();
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.07.26 TAKAHASHI DELETE END
		//}
        // �� 20061205 18322 d

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.04</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (!SaveAllDefSet())
			{
				return;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.04</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                AllDefSet compareAllDefSet = new AllDefSet();

                compareAllDefSet = this._allDefSetClone.Clone();
                ScreenToAllDefSet(ref compareAllDefSet);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._allDefSetClone.Equals(compareAllDefSet))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        "SFCMN09080U", 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveAllDefSet())
                                {
                                    return;
                                }
                                return;
                            }

                        case DialogResult.No:
                            {
                                // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
                                // ��ʔ�\���C�x���g
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

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

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
			// ��ʔ�\���C�x���g
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            
            this.DialogResult = DialogResult.Cancel;
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
		/// Control.Enter �C�x���g(tNedit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@      : �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[���ɂȂ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer		: 23006�@���� ���q</br>
		/// <br>Date			: 2005.10.04</br>
		/// </remarks>
        private void TNedit_Enter(object sender, EventArgs e)
        {
            // �� 20061205 18322 d
            //this._changeFlg = false;
            // �� 20061205 18322 d
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.ValueChanged �C�x���g(tNedit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note		    : tNedit���̃f�[�^���ύX���ꂽ�ۂɔ������܂��B</br>
		/// <br>Programmer		: 23006�@���� ���q</br>
		/// <br>Date			: 2006.01.13</br>
		/// </remarks>
        private void TNedit_ValueChange(object sender, EventArgs e)
        {
            // �� 20061205 18322 d
            //// ���[�U�[�ɂ���ĕύX���ꂽ�ꍇ
            //if (((TNedit)sender).Modified)
            //{
            //    this._changeFlg = true;
            //}
            // �� 20061205 18322 d
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			: Control����A�N�e�B�u�ɂȂ����ۂɔ������܂��B</br>
		/// <br>Programmer		: 23006�@���� ���q</br>
		/// <br>Date			: 2005.10.04</br>
		/// </remarks>
        private void TNedit_Leave(object sender, EventArgs e)
        {
            // �� 20061205 18322 d �g�уV�X�e���ł͎g�p���Ȃ��̂�
            //                     �����\���Z���R�[�h�����́A���^�������ԍ����폜
            // // �����\���Z���R�[�h1
            //if (((TNedit)sender).Name == "DefDispAddrCd1_tNedit")
            //{
            //    if ((this._changeFlg == true) || (this.DefDispAddrCd1_tNedit.Text == ""))
            //    {
            //        this._changeFlg = false;
            //
            //        // �Z���R�[�h�ύX����
            //        EpAddrCdChange(1);
            //    }
            //}
            //
            // // �����\���Z���R�[�h2
            //if (((TNedit)sender).Name == "DefDispAddrCd2_tNedit")
            //{
            //    if (this._changeFlg == true)
            //    {
            //        this._changeFlg = false;
            //
            //        // �Z���R�[�h�ύX����
            //        EpAddrCdChange(2);
            //    }
            //}
            //
            // // �����\���Z���R�[�h3
            //if (((TNedit)sender).Name == "DefDispAddrCd3_tNedit")
            //{
            //    if (this._changeFlg == true)
            //    {
            //        this._changeFlg = false;
            //
            //        // �Z���R�[�h�ύX����
            //        EpAddrCdChange(3);
            //    }
            //}
            //
            // // ���^�������ԍ�
            //if (((TNedit)sender).Name == "LandTransBranchCd_tNedit")
            //{
            //    if (this.LandTransBranchCd_tNedit.GetInt() == 0)
            //    {
            //        this.LandTransBranchCd_tEdit.Clear();
            //    }
            //    else if (this._changeFlg == true)
            //    {
            //        string landTransBranchNm = "";
            //
            //        this._changeFlg = false;
            //
            //        // ���^���������̎擾
            //        if (this.GetLandTransBranchName(0, this.LandTransBranchCd_tNedit.GetInt(), out landTransBranchNm) != 0)
            //        {
            //            this.LandTransBranchCd_tNedit.Focus();
            //        }
            //
            //        this.LandTransBranchCd_tEdit.Text = landTransBranchNm;
            //    }
            //}
            // �� 20061205 18322 d
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		///	Control.Leave �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�[���</param>
		/// <remarks>
		/// <br>Note			: Control����A�N�e�B�u�ɂȂ����ۂɔ������܂��B</br>
		/// <br>Programmer		: 23006�@���� ���q</br>
		/// <br>Date			: 2005.10.04</br>
		/// </remarks>
		private void Day_Leave(object sender, System.EventArgs e)
		{
			// ���Ӑ����
			if (((TNedit)sender).Name == "DefDspCustTtlDay_tNedit")
			{
				if (DefDspCustTtlDay_tNedit.DataText == "0")
				{
					DefDspCustTtlDay_tNedit.DataText = "";
				}
			}

			// ���Ӑ�W����
			if (((TNedit)sender).Name == "DefDspCustClctMnyDay_tNedit")
			{
				if (DefDspCustClctMnyDay_tNedit.DataText == "0")
				{
					DefDspCustClctMnyDay_tNedit.DataText = "";
				}
			}
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Control.Click �C�x���g(LandTransBranchCd_uButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���^�������K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2006.09.13</br>
        /// </remarks>
        private void LandTransBranchCd_uButton_Click(object sender, EventArgs e)
        {
            // �� 20061205 18322 d �g�уV�X�e���ł́A���^�������͂���Ȃ��̂ō폜
            // // ���^�x�ǖ���
            //LandTrnsNm landTrnsNm = new LandTrnsNm();
            //
            //switch (this._landTrnsNmAcs.ExecuteGuid(2, this._enterpriseCode, out landTrnsNm))
            //{
            //    case 0:
            //        {
            //            this.LandTransBranchCd_tNedit.SetInt(landTrnsNm.NumberPlate1Code);
            //            this.LandTransBranchCd_tEdit.DataText = landTrnsNm.NumberPlate1Name;
            //
            //            this.DefDispAddrCd1_tNedit.Focus();
            //
            //            break;
            //        }
            //
            //    default:
            //        {
            //            break;
            //        }
            //}
            // �� 20061205 18322 d
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Timer.Tick �C�x���g(timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer	: 23006  ���� ���q</br>
		/// <br>Date		: 2005.10.04</br>
		/// </remarks>
		private void Timer_Tick(object sender, System.EventArgs e)
		{
			Timer.Enabled = false;

			ScreenReconstruction();
		}
		#endregion

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
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
                    this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.DefDspCustTtlDay_tNedit.Focus();

                    // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                    // �V�K���[�h���烂�[�h�ύX�Ή�
                    //if (this.DataIndex < 0 )// DEL 2011/07/28
                    if (this.DataIndex < 0 && !string.IsNullOrEmpty (this.tEdit_SectionCodeAllowZero2.Text.TrimEnd()))// ADD 2011/07/28
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                    // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                "SFCMN09080U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
			Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            AllDefSet allDefSet = (AllDefSet)this._allDefSetTable[guid];

			// ���_���_���폜����
            int status = this._allDefSetAcs.Delete(allDefSet);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                    this._allDefSetTable.Remove(allDefSet.FileHeaderGuid);

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return;
				}
				default:
				{
					// �����폜
					TMsgDisp.Show( 
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
						"SFCMN09080U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text, 				            // �v���O��������
						"Delete_Button_Click", 				// ��������
						TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
						"�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
						status, 							// �X�e�[�^�X�l
                        this._allDefSetAcs, 				// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK, 				// �\������{�^��
						MessageBoxDefaultButton.Button1 );	// �����\���{�^��
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
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            AllDefSet allDefSet = ((AllDefSet)this._allDefSetTable[guid]).Clone();

            // ����
            status = this._allDefSetAcs.Revival(ref allDefSet);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // DataSet�W�J����
                        AllDefSetToDataSet(allDefSet, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            "SFCMN09080U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ReviveWarehouse",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._allDefSetAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
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
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero2)
            {
                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                // ���_���̎擾
                //this.SectionName_tEdit.DataText = GetSectionName(sectionCode); // DEL 2011/09/07
                // ----- // ADD 2011/09/07 ------------------->>>>>
                string sectionName = GetSectionName(sectionCode);
                if (sectionCode == "0" || sectionCode == "00")
                {
                    sectionName = "�S�Ћ���";
                }
                isError = false;
                if (!string.IsNullOrEmpty(sectionCode))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = sectionCode.PadLeft(2, '0');
                }
                this.SectionName_tEdit.DataText = sectionName;
                // ----- // ADD 2011/09/07 -------------------<<<<<

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // �t�H�[�J�X�ݒ�
                            e.NextCtrl = this.SectionGuide_Button;
                        }
                    }
                }

                
                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                // �V�K���[�h���烂�[�h�ύX�Ή�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                // ADD 2009/04/17 ------>>>
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // �ŐV���{�^���͍X�V�`�F�b�N����O��
                    ;
                }
                // ADD 2009/04/17 ------<<<
                //else if (this.DataIndex < 0 )// DEL 2011/07/28
                else if (this.DataIndex < 0 && !string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text.TrimEnd()))// ADD 2011/07/28
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
                // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            }
            // ADD 2009/04/17 ------>>>
            else if (e.PrevCtrl == Renewal_Button)
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
                // else if (this.DataIndex < 0 )// DEL 2011/07/28
                else if (this.DataIndex < 0 && !string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text.TrimEnd()))// ADD 2011/07/28
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            // ADD 2009/04/17 ------<<<
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/07 -------------------------------->>>>>
            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionName_tEdit.Clear();
                return false;
            }
            // --- ADD 2011/09/07 --------------------------------<<<<<
            string msg = "���͂��ꂽ�R�[�h�̑S�̏����\���ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "SFCMN09080U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̑S�̏����\���ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        isError = true; // ADD 2011/09/08
                        // ���_�R�[�h�A���̂̃N���A
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == "00")
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h�̑S�̏����\���ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        "SFCMN09080U",                          // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    isError = true; // ADD 2011/09/08
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
                                SectionName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        // ADD 2009/04/17 ------>>>
        /// <summary>
        /// �ŐV���{�^���N���b�N
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          "SFCMN09080U",						// �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // ADD 2009/04/17 ------<<<        
	}
}
