//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d����}�X�^
// �v���O�����T�v   : �d����̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �� �� ��  2008/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2008/12/12  �C�����e : ��QID:8248,9161�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2008/12/24  �C�����e : ��QID:9452�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2009/01/20  �C�����e : ��QID:9164,9163�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2009/01/29  �C�����e : ��QID:10723�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/27  �C�����e : MANTIS�y13319�z �q�d����̎x����񂪍X�V����Ȃ��s����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/26  �C�����e : MANTIS�y13296�z �d���於�Ǝd���旪�̂̕K�{�`�F�b�N���珜�O
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N
// �� �� ��  2012/10/22  �C�����e : 2012/11/14�z�M���ARedmine#32861 
//                                  �d����K�C�h�́A�d���`�[���͂Ɠ��l�̃K�C�h���g�p����悤�ɏC��
//----------------------------------------------------------------------------//

# region ��using
using Infragistics.Win.Misc;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using System.Collections.Generic;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �d����}�X�^ �t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note         : �d����}�X�^���̐ݒ���s���܂��B</br>
	/// <br>               IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer   : 22018 ��ؐ��b</br>
	/// <br>Date         : 2008.04.28</br>
    /// <br>Update Note  : 2008/12/12 30414 �E �K�j�@��QID:8248,9161�Ή�</br>
    /// <br>Update Note  : 2008/12/24 30414 �E �K�j�@��QID:9452�Ή�</br>
    /// <br>Update Note  : 2009/01/20 30414 �E �K�j�@��QID:9164,9163�Ή�</br>
    /// <br>Update Note  : 2009/01/29 30414 �E �K�j�@��QID:10723�Ή�</br>
    /// <br>Update Note  : 2012/10/22  ���N</br>
    /// <br>�Ǘ��ԍ�     : 2012/11/14�z�M��</br>
    /// <br>               Redmine#32861 �d����K�C�h�́A�d���`�[���͂Ɠ��l�̃K�C�h���g�p����悤�ɏC��</br>
    /// </remarks>
    public class PMKHN09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region ��Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private System.Windows.Forms.Timer Initial_Timer;
        private Broadleaf.Library.Windows.Forms.TImeControl tImeControl1;
        private TEdit tEdit_SupplierName1;
        private Infragistics.Win.Misc.UltraLabel BLGoodsFullName_Title_Label;
        private Infragistics.Win.Misc.UltraLabel BLGoodsCode_Title_Label;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TNedit tNedit_SupplierCd;
		private UiSetControl uiSetControl1;
        private UltraLabel uLabel_CustomerNameTitle;
        private UltraLabel ultraLabel61;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl SubInfo_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage SubInfo_UTabSharedControlsPage;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo2_UTabPageControl;
        private Panel SubInfo2_Panel;
        private UltraButton uButton_Note4Guide;
        private TEdit tEdit_SupplierNote4;
        private UltraButton uButton_Note3Guide;
        private TEdit tEdit_SupplierNote3;
        private UltraButton uButton_Note2Guide;
        private TEdit tEdit_SupplierNote2;
        private UltraLabel Note2Title_ULabel;
        private UltraButton uButton_Note1Guide;
        private TEdit tEdit_SupplierNote1;
        private UltraLabel Note1Title_ULabel;
        private UltraLabel Note4Title_ULabel;
        private UltraLabel Note3Title_ULabel;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo0_UTabPageControl;
        private Panel SubInfo0_Panel;
        private UltraLabel ultraLabel25;
        private UltraLabel ultraLabel24;
        private TEdit tEdit_SupplierPostNo;
        private UltraLabel ultraLabel14;
        private TEdit tEdit_SupplierAddr1;
        private TEdit tEdit_SupplierAddr3;
        private TEdit tEdit_SupplierAddr4;
        private UltraLabel ultraLabel5;
        private UltraButton uButton_AddressGuide;
        private TEdit tEdit_SupplierTelNo;
        private UltraLabel HomeTelNoDspName_ULabel;
        private TEdit tEdit_SupplierTelNo1;
        private UltraLabel MobileTelNoDspName_ULabel;
        private TEdit tEdit_SupplierTelNo2;
        private UltraLabel uLabel_Payment;
        private UltraLabel uLabel_Detail;
        private UltraLabel ultraLabel2;
        private UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo5_UTabPageControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo4_UTabPageControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo1_UTabPageControl;
        private UltraLabel ultraLabel8;
        private UltraButton uButton_StockAgentGuide;
        private TEdit tEdit_StockAgentNm;
        private UltraButton uButton_MngSectionNmGuide;
        private TEdit tEdit_MngSectionNm;
        private UltraLabel ultraLabel57;
        private UltraLabel ultraLabel39;
        private TComboEditor tComboEditor_PureCode;
        private TComboEditor tComboEditor_SupplierAttributeDiv;
        private UltraLabel ultraLabel28;
        private TComboEditor tComboEditor_SalesAreaCode;
        private UltraLabel ultraLabel7;
        private TComboEditor tComboEditor_BusinessTypeCode;
        private UltraLabel BusinessTypeCodeTitle_ULabel;
        private UltraLabel ultraLabel6;
        private UltraLabel ultraLabel27;
        private TEdit tEdit_SupplierSnm;
        private UltraLabel ultraLabel34;
        private UltraLabel ultraLabel12;
        private TEdit tEdit_SupplierKana;
        private TEdit tEdit_SupplierName2;
        private TNedit tNedit_StockCnsTaxFrcProcCd;
        private TNedit tNedit_StockMoneyFrcProcCd;
        private TNedit tNedit_StockUnPrcFrcProcCd;
        private UltraButton uButton_SalesCnsTaxFrcProcCdGuide;
        private UltraButton uButton_SalesMoneyFrcProcCdGuide;
        private UltraButton uButton_SalesUnPrcFrcProcCdGuide;
        private UltraLabel ultraLabel44;
        private UltraLabel ultraLabel47;
        private UltraLabel ultraLabel45;
        private UltraLabel ultraLabel46;
        private UltraLabel ultraLabel18;
        private UltraLabel ultraLabel19;
        private UltraLabel ultraLabel54;
        private UltraLabel ultraLabel52;
        private TComboEditor tComboEditor_SuppCTaXLayRefCd;
        private UltraLabel ultraLabel13;
        private TComboEditor tComboEditor_SuppTaxLayMethod;
        private UltraLabel ultraLabel17;
        private UltraLabel ultraLabel9;
        private UltraButton uButton_PaymentSectionGuide;
        private TEdit tEdit_PaymentSectionCode;
        private UltraLabel ultraLabel60;
        private TNedit tNedit_NTimeCalcStDate;
        private UltraLabel ultraLabel58;
        private UltraLabel uLabel_PayeeName1;
        private TNedit tNedit_PayeeCode;
        private UltraLabel ultraLabel55;
        private UltraLabel ultraLabel53;
        private UltraLabel uLabel_PayeeSnm;
        private TNedit tNedit_PaymentSight;
        private UltraLabel ultraLabel29;
        private TComboEditor tComboEditor_PaymentCond;
        private UltraLabel uLabel_PayeeName2;
        private TComboEditor tComboEditor_PaymentMonthCode;
        private UltraButton uButton_PayeeNameGuide;
        private UltraLabel ultraLabel59;
        private TNedit tNedit_PaymentDay;
        private UltraLabel CollectMoneyCodeTitle_ULabel;
        private UltraLabel CollectMoneyDayTitle_ULabel;
        private TNedit tNedit_PaymentTotalDay;
        private UltraLabel TotalDayTitle_ULabel;
        private UltraLabel ultraLabel20;
        private TImeControl NameToKana_TImeControl;
        private ContextMenuStrip contextMenuStrip1;
        private TEdit tEdit_SuppHonorificTitle;
        private TEdit tEdit_OrderHonorificTtl;
        private UltraButton uButton_OfrSupplierGuide;
        private UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		# endregion

		# region ��Constructor
		/// <summary>
        /// �d����}�X�^ �t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �d����}�X�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
        public PMKHN09020UA()
		{
			InitializeComponent();

			// �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// �f�t�H���g:true�Œ�
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            if ( _paraEnterpriseCode == string.Empty )
            {
                //�@��ƃR�[�h�擾
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

			// �ϐ�������
			this._dataIndex = -1;
			this._secInfoAcs = new SecInfoAcs();
			this._supplierAcs = new SupplierAcs();
            this._ofrSupplierAcs = new OfrSupplierAcs();
            //this._userGuideAcs = new UserGuideAcs();  // iitani d 2007.05.18
			 
			this._totalCount = 0;
            this._supplierDic = new Dictionary<Guid, Supplier>();

			//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			// ���_OP�̔���
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // UI��\���f�[�^
            _noDispData = new NoDispData();

            // �S�̏����l�ݒ�}�X�^�ǂݍ��݁i�S�̐ݒ�Q�Ƃ̑Ή��j
            // (���_=00�F���ʐݒ���܂߂Ď擾)
            _allDefSetDic = new Dictionary<string, AllDefSet>();
            AllDefSetAcs addDefSetAcs = new AllDefSetAcs();
            ArrayList retList;
            addDefSetAcs.Search( out retList, this._enterpriseCode );
            if (retList != null)
            {
                foreach (AllDefSet allDefSet in retList)
	            {
                    _allDefSetDic.Add( allDefSet.SectionCode.TrimEnd(), allDefSet );
	            }
            }

            // �ŗ��ݒ�}�X�^�ǂݍ��݁i�S�̐ݒ�Q�Ƃ̑Ή��j
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            taxRateSetAcs.Read( out _taxRateSet, this._enterpriseCode, 0 ); // 0:���
            if ( _taxRateSet == null ) _taxRateSet = new TaxRateSet();

            // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
            this._paymentSetAcs = new PaymentSetAcs();
            this._moneyKindAcs = new MoneyKindAcs();
            // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<
		}
        /// <summary>
        /// �d����}�X�^ �t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �X���C�_����̃}�X�����P�ƋN���@�\��񋟂��܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        /// <param name="mode">(�����g�p)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        public PMKHN09020UA( int mode, string enterpriseCode, int supplierCode )
            : this()
        {
            // �P�ƋN�����[�h=true
            _singleExecute = true;
            // ��ƃR�[�h
            _paraEnterpriseCode = enterpriseCode;
            // �d����R�[�h
            _paraSupplierCode = supplierCode;

            // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
            this._paymentSetAcs = new PaymentSetAcs();
            this._moneyKindAcs = new MoneyKindAcs();
            // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<
        }
		# endregion

        # region ��Dispose
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

		#region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance219 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance220 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance221 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance241 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance242 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance243 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance237 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance261 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance197 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance227 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance228 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance229 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance231 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance232 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance233 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance230 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance244 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09020UA));
            this.SubInfo0_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo0_Panel = new System.Windows.Forms.Panel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierPostNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierAddr1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SupplierAddr3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SupplierAddr4 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_AddressGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierTelNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.HomeTelNoDspName_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierTelNo1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MobileTelNoDspName_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierTelNo2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SubInfo2_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo2_Panel = new System.Windows.Forms.Panel();
            this.uButton_Note4Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierNote4 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note3Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierNote3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note2Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierNote2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Note2Title_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_Note1Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierNote1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Note1Title_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Note4Title_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Note3Title_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.tEdit_SupplierName1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.BLGoodsCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsFullName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uLabel_CustomerNameTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel61 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Detail = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Payment = new Infragistics.Win.Misc.UltraLabel();
            this.SubInfo5_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo4_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo1_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo_UTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.SubInfo_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierSnm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierKana = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SupplierName2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_MngSectionNmGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_MngSectionNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PureCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_SupplierAttributeDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SalesAreaCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_BusinessTypeCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BusinessTypeCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_StockAgentNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_StockAgentGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel60 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_NTimeCalcStDate = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel58 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_PayeeName1 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PayeeCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel55 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel53 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_PayeeSnm = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PaymentSight = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PaymentCond = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_PayeeName2 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PaymentMonthCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uButton_PayeeNameGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel59 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PaymentDay = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CollectMoneyCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.CollectMoneyDayTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PaymentTotalDay = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TotalDayTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PaymentSectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_PaymentSectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel54 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel52 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SuppCTaXLayRefCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SuppTaxLayMethod = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_StockCnsTaxFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_StockMoneyFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_StockUnPrcFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SalesCnsTaxFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_SalesMoneyFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_SalesUnPrcFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel44 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel47 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel45 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel46 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.NameToKana_TImeControl = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tEdit_SuppHonorificTitle = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_OrderHonorificTtl = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_OfrSupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.SubInfo0_UTabPageControl.SuspendLayout();
            this.SubInfo0_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierPostNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo2)).BeginInit();
            this.SubInfo2_UTabPageControl.SuspendLayout();
            this.SubInfo2_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubInfo_UTabControl)).BeginInit();
            this.SubInfo_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierKana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MngSectionNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PureCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierAttributeDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_BusinessTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_NTimeCalcStDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentSight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PaymentCond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PaymentMonthCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentTotalDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PaymentSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SuppCTaXLayRefCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SuppTaxLayMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockCnsTaxFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockMoneyFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockUnPrcFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SuppHonorificTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OrderHonorificTtl)).BeginInit();
            this.SuspendLayout();
            // 
            // SubInfo0_UTabPageControl
            // 
            this.SubInfo0_UTabPageControl.Controls.Add(this.SubInfo0_Panel);
            this.SubInfo0_UTabPageControl.Location = new System.Drawing.Point(1, 1);
            this.SubInfo0_UTabPageControl.Name = "SubInfo0_UTabPageControl";
            this.SubInfo0_UTabPageControl.Size = new System.Drawing.Size(1009, 126);
            // 
            // SubInfo0_Panel
            // 
            this.SubInfo0_Panel.Controls.Add(this.ultraLabel25);
            this.SubInfo0_Panel.Controls.Add(this.ultraLabel24);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierPostNo);
            this.SubInfo0_Panel.Controls.Add(this.ultraLabel14);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierAddr1);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierAddr3);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierAddr4);
            this.SubInfo0_Panel.Controls.Add(this.ultraLabel5);
            this.SubInfo0_Panel.Controls.Add(this.uButton_AddressGuide);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierTelNo);
            this.SubInfo0_Panel.Controls.Add(this.HomeTelNoDspName_ULabel);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierTelNo1);
            this.SubInfo0_Panel.Controls.Add(this.MobileTelNoDspName_ULabel);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierTelNo2);
            this.SubInfo0_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubInfo0_Panel.Location = new System.Drawing.Point(0, 0);
            this.SubInfo0_Panel.Name = "SubInfo0_Panel";
            this.SubInfo0_Panel.Size = new System.Drawing.Size(1009, 126);
            this.SubInfo0_Panel.TabIndex = 0;
            // 
            // ultraLabel25
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance3;
            this.ultraLabel25.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel25.Location = new System.Drawing.Point(584, 4);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(105, 22);
            this.ultraLabel25.TabIndex = 1128;
            this.ultraLabel25.Text = "�d�b�ԍ��EFAX";
            // 
            // ultraLabel24
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel24.Appearance = appearance4;
            this.ultraLabel24.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel24.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel24.Location = new System.Drawing.Point(38, 3);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel24.TabIndex = 1127;
            this.ultraLabel24.Text = "�Z�@��";
            // 
            // tEdit_SupplierPostNo
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierPostNo.ActiveAppearance = appearance5;
            appearance57.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierPostNo.Appearance = appearance57;
            this.tEdit_SupplierPostNo.AutoSelect = true;
            this.tEdit_SupplierPostNo.DataText = "";
            this.tEdit_SupplierPostNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierPostNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SupplierPostNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierPostNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SupplierPostNo.Location = new System.Drawing.Point(115, 26);
            this.tEdit_SupplierPostNo.MaxLength = 10;
            this.tEdit_SupplierPostNo.Name = "tEdit_SupplierPostNo";
            this.tEdit_SupplierPostNo.Size = new System.Drawing.Size(80, 22);
            this.tEdit_SupplierPostNo.TabIndex = 0;
            // 
            // ultraLabel14
            // 
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance6;
            this.ultraLabel14.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel14.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel14.Location = new System.Drawing.Point(27, 26);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel14.TabIndex = 328;
            this.ultraLabel14.Text = "�X�֔ԍ�";
            // 
            // tEdit_SupplierAddr1
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierAddr1.ActiveAppearance = appearance7;
            appearance58.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierAddr1.Appearance = appearance58;
            this.tEdit_SupplierAddr1.AutoSelect = true;
            this.tEdit_SupplierAddr1.DataText = "";
            this.tEdit_SupplierAddr1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierAddr1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierAddr1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierAddr1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierAddr1.Location = new System.Drawing.Point(115, 50);
            this.tEdit_SupplierAddr1.MaxLength = 30;
            this.tEdit_SupplierAddr1.Name = "tEdit_SupplierAddr1";
            this.tEdit_SupplierAddr1.Size = new System.Drawing.Size(430, 22);
            this.tEdit_SupplierAddr1.TabIndex = 2;
            // 
            // tEdit_SupplierAddr3
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierAddr3.ActiveAppearance = appearance10;
            appearance59.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierAddr3.Appearance = appearance59;
            this.tEdit_SupplierAddr3.AutoSelect = true;
            this.tEdit_SupplierAddr3.DataText = "";
            this.tEdit_SupplierAddr3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierAddr3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 22, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierAddr3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierAddr3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierAddr3.Location = new System.Drawing.Point(115, 74);
            this.tEdit_SupplierAddr3.MaxLength = 22;
            this.tEdit_SupplierAddr3.Name = "tEdit_SupplierAddr3";
            this.tEdit_SupplierAddr3.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierAddr3.TabIndex = 3;
            // 
            // tEdit_SupplierAddr4
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierAddr4.ActiveAppearance = appearance11;
            appearance60.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierAddr4.Appearance = appearance60;
            this.tEdit_SupplierAddr4.AutoSelect = true;
            this.tEdit_SupplierAddr4.DataText = "";
            this.tEdit_SupplierAddr4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierAddr4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierAddr4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierAddr4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierAddr4.Location = new System.Drawing.Point(115, 98);
            this.tEdit_SupplierAddr4.MaxLength = 30;
            this.tEdit_SupplierAddr4.Name = "tEdit_SupplierAddr4";
            this.tEdit_SupplierAddr4.Size = new System.Drawing.Size(430, 22);
            this.tEdit_SupplierAddr4.TabIndex = 4;
            // 
            // ultraLabel5
            // 
            appearance12.TextHAlignAsString = "Center";
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance12;
            this.ultraLabel5.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(27, 50);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel5.TabIndex = 326;
            this.ultraLabel5.Text = "�Z�@��";
            // 
            // uButton_AddressGuide
            // 
            this.uButton_AddressGuide.Location = new System.Drawing.Point(197, 25);
            this.uButton_AddressGuide.Name = "uButton_AddressGuide";
            this.uButton_AddressGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_AddressGuide.TabIndex = 1;
            this.uButton_AddressGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_AddressGuide.Click += new System.EventHandler(this.uButton_AddressGuide_Click);
            // 
            // tEdit_SupplierTelNo
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierTelNo.ActiveAppearance = appearance14;
            appearance64.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierTelNo.Appearance = appearance64;
            this.tEdit_SupplierTelNo.AutoSelect = true;
            this.tEdit_SupplierTelNo.DataText = "";
            this.tEdit_SupplierTelNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SupplierTelNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierTelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SupplierTelNo.Location = new System.Drawing.Point(678, 26);
            this.tEdit_SupplierTelNo.MaxLength = 16;
            this.tEdit_SupplierTelNo.Name = "tEdit_SupplierTelNo";
            this.tEdit_SupplierTelNo.Size = new System.Drawing.Size(121, 22);
            this.tEdit_SupplierTelNo.TabIndex = 5;
            // 
            // HomeTelNoDspName_ULabel
            // 
            appearance15.TextHAlignAsString = "Center";
            appearance15.TextVAlignAsString = "Middle";
            this.HomeTelNoDspName_ULabel.Appearance = appearance15;
            this.HomeTelNoDspName_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HomeTelNoDspName_ULabel.Location = new System.Drawing.Point(584, 26);
            this.HomeTelNoDspName_ULabel.Name = "HomeTelNoDspName_ULabel";
            this.HomeTelNoDspName_ULabel.Size = new System.Drawing.Size(88, 22);
            this.HomeTelNoDspName_ULabel.TabIndex = 337;
            this.HomeTelNoDspName_ULabel.Text = "�d�b";
            // 
            // tEdit_SupplierTelNo1
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierTelNo1.ActiveAppearance = appearance17;
            appearance63.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierTelNo1.Appearance = appearance63;
            this.tEdit_SupplierTelNo1.AutoSelect = true;
            this.tEdit_SupplierTelNo1.DataText = "";
            this.tEdit_SupplierTelNo1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierTelNo1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SupplierTelNo1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierTelNo1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SupplierTelNo1.Location = new System.Drawing.Point(678, 50);
            this.tEdit_SupplierTelNo1.MaxLength = 16;
            this.tEdit_SupplierTelNo1.Name = "tEdit_SupplierTelNo1";
            this.tEdit_SupplierTelNo1.Size = new System.Drawing.Size(121, 22);
            this.tEdit_SupplierTelNo1.TabIndex = 6;
            // 
            // MobileTelNoDspName_ULabel
            // 
            appearance18.TextHAlignAsString = "Center";
            appearance18.TextVAlignAsString = "Middle";
            this.MobileTelNoDspName_ULabel.Appearance = appearance18;
            this.MobileTelNoDspName_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MobileTelNoDspName_ULabel.Location = new System.Drawing.Point(584, 74);
            this.MobileTelNoDspName_ULabel.Name = "MobileTelNoDspName_ULabel";
            this.MobileTelNoDspName_ULabel.Size = new System.Drawing.Size(88, 22);
            this.MobileTelNoDspName_ULabel.TabIndex = 339;
            this.MobileTelNoDspName_ULabel.Text = "�e�`�w";
            // 
            // tEdit_SupplierTelNo2
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierTelNo2.ActiveAppearance = appearance20;
            appearance62.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierTelNo2.Appearance = appearance62;
            this.tEdit_SupplierTelNo2.AutoSelect = true;
            this.tEdit_SupplierTelNo2.DataText = "";
            this.tEdit_SupplierTelNo2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierTelNo2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SupplierTelNo2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierTelNo2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SupplierTelNo2.Location = new System.Drawing.Point(678, 74);
            this.tEdit_SupplierTelNo2.MaxLength = 16;
            this.tEdit_SupplierTelNo2.Name = "tEdit_SupplierTelNo2";
            this.tEdit_SupplierTelNo2.Size = new System.Drawing.Size(121, 22);
            this.tEdit_SupplierTelNo2.TabIndex = 7;
            // 
            // SubInfo2_UTabPageControl
            // 
            this.SubInfo2_UTabPageControl.Controls.Add(this.SubInfo2_Panel);
            this.SubInfo2_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo2_UTabPageControl.Name = "SubInfo2_UTabPageControl";
            this.SubInfo2_UTabPageControl.Size = new System.Drawing.Size(1009, 126);
            // 
            // SubInfo2_Panel
            // 
            this.SubInfo2_Panel.Controls.Add(this.uButton_Note4Guide);
            this.SubInfo2_Panel.Controls.Add(this.tEdit_SupplierNote4);
            this.SubInfo2_Panel.Controls.Add(this.uButton_Note3Guide);
            this.SubInfo2_Panel.Controls.Add(this.tEdit_SupplierNote3);
            this.SubInfo2_Panel.Controls.Add(this.uButton_Note2Guide);
            this.SubInfo2_Panel.Controls.Add(this.tEdit_SupplierNote2);
            this.SubInfo2_Panel.Controls.Add(this.Note2Title_ULabel);
            this.SubInfo2_Panel.Controls.Add(this.uButton_Note1Guide);
            this.SubInfo2_Panel.Controls.Add(this.tEdit_SupplierNote1);
            this.SubInfo2_Panel.Controls.Add(this.Note1Title_ULabel);
            this.SubInfo2_Panel.Controls.Add(this.Note4Title_ULabel);
            this.SubInfo2_Panel.Controls.Add(this.Note3Title_ULabel);
            this.SubInfo2_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubInfo2_Panel.Location = new System.Drawing.Point(0, 0);
            this.SubInfo2_Panel.Name = "SubInfo2_Panel";
            this.SubInfo2_Panel.Size = new System.Drawing.Size(1009, 126);
            this.SubInfo2_Panel.TabIndex = 1110;
            // 
            // uButton_Note4Guide
            // 
            appearance32.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance32.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note4Guide.Appearance = appearance32;
            this.uButton_Note4Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note4Guide.Location = new System.Drawing.Point(440, 85);
            this.uButton_Note4Guide.Name = "uButton_Note4Guide";
            this.uButton_Note4Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note4Guide.TabIndex = 7;
            this.uButton_Note4Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note4Guide.Visible = false;
            // 
            // tEdit_SupplierNote4
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierNote4.ActiveAppearance = appearance34;
            appearance68.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierNote4.Appearance = appearance68;
            this.tEdit_SupplierNote4.AutoSelect = true;
            this.tEdit_SupplierNote4.AutoSize = false;
            this.tEdit_SupplierNote4.DataText = "";
            this.tEdit_SupplierNote4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierNote4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierNote4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierNote4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierNote4.Location = new System.Drawing.Point(115, 86);
            this.tEdit_SupplierNote4.MaxLength = 20;
            this.tEdit_SupplierNote4.Name = "tEdit_SupplierNote4";
            this.tEdit_SupplierNote4.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierNote4.TabIndex = 6;
            // 
            // uButton_Note3Guide
            // 
            appearance37.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance37.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note3Guide.Appearance = appearance37;
            this.uButton_Note3Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note3Guide.Location = new System.Drawing.Point(440, 59);
            this.uButton_Note3Guide.Name = "uButton_Note3Guide";
            this.uButton_Note3Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note3Guide.TabIndex = 5;
            this.uButton_Note3Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note3Guide.Visible = false;
            // 
            // tEdit_SupplierNote3
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierNote3.ActiveAppearance = appearance39;
            appearance67.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierNote3.Appearance = appearance67;
            this.tEdit_SupplierNote3.AutoSelect = true;
            this.tEdit_SupplierNote3.AutoSize = false;
            this.tEdit_SupplierNote3.DataText = "";
            this.tEdit_SupplierNote3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierNote3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierNote3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierNote3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierNote3.Location = new System.Drawing.Point(115, 60);
            this.tEdit_SupplierNote3.MaxLength = 20;
            this.tEdit_SupplierNote3.Name = "tEdit_SupplierNote3";
            this.tEdit_SupplierNote3.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierNote3.TabIndex = 4;
            // 
            // uButton_Note2Guide
            // 
            appearance42.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance42.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note2Guide.Appearance = appearance42;
            this.uButton_Note2Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note2Guide.Location = new System.Drawing.Point(440, 33);
            this.uButton_Note2Guide.Name = "uButton_Note2Guide";
            this.uButton_Note2Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note2Guide.TabIndex = 3;
            this.uButton_Note2Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note2Guide.Visible = false;
            // 
            // tEdit_SupplierNote2
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierNote2.ActiveAppearance = appearance44;
            appearance66.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierNote2.Appearance = appearance66;
            this.tEdit_SupplierNote2.AutoSelect = true;
            this.tEdit_SupplierNote2.AutoSize = false;
            this.tEdit_SupplierNote2.DataText = "";
            this.tEdit_SupplierNote2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierNote2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierNote2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierNote2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierNote2.Location = new System.Drawing.Point(115, 34);
            this.tEdit_SupplierNote2.MaxLength = 20;
            this.tEdit_SupplierNote2.Name = "tEdit_SupplierNote2";
            this.tEdit_SupplierNote2.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierNote2.TabIndex = 2;
            // 
            // Note2Title_ULabel
            // 
            appearance47.TextHAlignAsString = "Center";
            appearance47.TextVAlignAsString = "Middle";
            this.Note2Title_ULabel.Appearance = appearance47;
            this.Note2Title_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note2Title_ULabel.Location = new System.Drawing.Point(7, 32);
            this.Note2Title_ULabel.Name = "Note2Title_ULabel";
            this.Note2Title_ULabel.Size = new System.Drawing.Size(100, 24);
            this.Note2Title_ULabel.TabIndex = 494;
            this.Note2Title_ULabel.Text = "�d������l�Q";
            // 
            // uButton_Note1Guide
            // 
            appearance48.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance48.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note1Guide.Appearance = appearance48;
            this.uButton_Note1Guide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note1Guide.Location = new System.Drawing.Point(440, 7);
            this.uButton_Note1Guide.Name = "uButton_Note1Guide";
            this.uButton_Note1Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note1Guide.TabIndex = 1;
            this.uButton_Note1Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note1Guide.Visible = false;
            // 
            // tEdit_SupplierNote1
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierNote1.ActiveAppearance = appearance50;
            appearance65.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierNote1.Appearance = appearance65;
            this.tEdit_SupplierNote1.AutoSelect = true;
            this.tEdit_SupplierNote1.AutoSize = false;
            this.tEdit_SupplierNote1.DataText = "";
            this.tEdit_SupplierNote1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierNote1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierNote1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierNote1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierNote1.Location = new System.Drawing.Point(115, 8);
            this.tEdit_SupplierNote1.MaxLength = 20;
            this.tEdit_SupplierNote1.Name = "tEdit_SupplierNote1";
            this.tEdit_SupplierNote1.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierNote1.TabIndex = 0;
            // 
            // Note1Title_ULabel
            // 
            appearance51.TextHAlignAsString = "Center";
            appearance51.TextVAlignAsString = "Middle";
            this.Note1Title_ULabel.Appearance = appearance51;
            this.Note1Title_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note1Title_ULabel.Location = new System.Drawing.Point(7, 6);
            this.Note1Title_ULabel.Name = "Note1Title_ULabel";
            this.Note1Title_ULabel.Size = new System.Drawing.Size(100, 24);
            this.Note1Title_ULabel.TabIndex = 493;
            this.Note1Title_ULabel.Text = "�d������l�P";
            // 
            // Note4Title_ULabel
            // 
            appearance53.TextHAlignAsString = "Center";
            appearance53.TextVAlignAsString = "Middle";
            this.Note4Title_ULabel.Appearance = appearance53;
            this.Note4Title_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note4Title_ULabel.Location = new System.Drawing.Point(7, 84);
            this.Note4Title_ULabel.Name = "Note4Title_ULabel";
            this.Note4Title_ULabel.Size = new System.Drawing.Size(100, 24);
            this.Note4Title_ULabel.TabIndex = 499;
            this.Note4Title_ULabel.Text = "�d������l�S";
            // 
            // Note3Title_ULabel
            // 
            appearance54.TextHAlignAsString = "Center";
            appearance54.TextVAlignAsString = "Middle";
            this.Note3Title_ULabel.Appearance = appearance54;
            this.Note3Title_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note3Title_ULabel.Location = new System.Drawing.Point(7, 58);
            this.Note3Title_ULabel.Name = "Note3Title_ULabel";
            this.Note3Title_ULabel.Size = new System.Drawing.Size(100, 24);
            this.Note3Title_ULabel.TabIndex = 495;
            this.Note3Title_ULabel.Text = "�d������l�R";
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(756, 605);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 9993;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 648);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(1018, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Mode_Label
            // 
            appearance43.ForeColor = System.Drawing.Color.White;
            appearance43.TextHAlignAsString = "Center";
            appearance43.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance43;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(915, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(631, 605);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 9990;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(756, 605);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 9991;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(882, 605);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 9999;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = this.tEdit_SupplierName1;
            this.tImeControl1.OutControl = null;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 30;
            // 
            // tEdit_SupplierName1
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierName1.ActiveAppearance = appearance45;
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierName1.Appearance = appearance88;
            this.tEdit_SupplierName1.AutoSelect = true;
            this.tEdit_SupplierName1.DataText = "";
            this.tEdit_SupplierName1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierName1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SupplierName1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierName1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierName1.Location = new System.Drawing.Point(120, 72);
            this.tEdit_SupplierName1.MaxLength = 30;
            this.tEdit_SupplierName1.Name = "tEdit_SupplierName1";
            this.tEdit_SupplierName1.Size = new System.Drawing.Size(430, 22);
            this.tEdit_SupplierName1.TabIndex = 2;
            this.tEdit_SupplierName1.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // BLGoodsCode_Title_Label
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.BLGoodsCode_Title_Label.Appearance = appearance52;
            this.BLGoodsCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsCode_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGoodsCode_Title_Label.Location = new System.Drawing.Point(30, 46);
            this.BLGoodsCode_Title_Label.Name = "BLGoodsCode_Title_Label";
            this.BLGoodsCode_Title_Label.Size = new System.Drawing.Size(87, 24);
            this.BLGoodsCode_Title_Label.TabIndex = 10;
            this.BLGoodsCode_Title_Label.Text = "�d����R�[�h";
            // 
            // BLGoodsFullName_Title_Label
            // 
            appearance49.TextHAlignAsString = "Center";
            appearance49.TextVAlignAsString = "Middle";
            this.BLGoodsFullName_Title_Label.Appearance = appearance49;
            this.BLGoodsFullName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsFullName_Title_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGoodsFullName_Title_Label.Location = new System.Drawing.Point(32, 74);
            this.BLGoodsFullName_Title_Label.Name = "BLGoodsFullName_Title_Label";
            this.BLGoodsFullName_Title_Label.Size = new System.Drawing.Size(87, 24);
            this.BLGoodsFullName_Title_Label.TabIndex = 11;
            this.BLGoodsFullName_Title_Label.Text = "�d���於";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // tNedit_SupplierCd
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.ActiveAppearance = appearance38;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance40.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance40.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance40.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.Appearance = appearance40;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(120, 46);
            this.tNedit_SupplierCd.MaxLength = 6;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(53, 22);
            this.tNedit_SupplierCd.TabIndex = 0;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // uLabel_CustomerNameTitle
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance35.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance35.ForeColor = System.Drawing.Color.White;
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance35.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance35.TextHAlignAsString = "Center";
            appearance35.TextVAlignAsString = "Middle";
            this.uLabel_CustomerNameTitle.Appearance = appearance35;
            this.uLabel_CustomerNameTitle.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_CustomerNameTitle.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerNameTitle.Location = new System.Drawing.Point(4, 41);
            this.uLabel_CustomerNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_CustomerNameTitle.Name = "uLabel_CustomerNameTitle";
            this.uLabel_CustomerNameTitle.Size = new System.Drawing.Size(25, 172);
            this.uLabel_CustomerNameTitle.TabIndex = 1128;
            this.uLabel_CustomerNameTitle.Text = "���O";
            // 
            // ultraLabel61
            // 
            this.ultraLabel61.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel61.Location = new System.Drawing.Point(29, 41);
            this.ultraLabel61.Margin = new System.Windows.Forms.Padding(0);
            this.ultraLabel61.Name = "ultraLabel61";
            this.ultraLabel61.Size = new System.Drawing.Size(535, 172);
            this.ultraLabel61.TabIndex = 0;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel1.Location = new System.Drawing.Point(29, 219);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(535, 229);
            this.ultraLabel1.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel2.Location = new System.Drawing.Point(591, 41);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(424, 407);
            this.ultraLabel2.TabIndex = 2;
            // 
            // uLabel_Detail
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance61.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.ForeColor = System.Drawing.Color.White;
            appearance61.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance61.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.uLabel_Detail.Appearance = appearance61;
            this.uLabel_Detail.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_Detail.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Detail.Location = new System.Drawing.Point(4, 219);
            this.uLabel_Detail.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_Detail.Name = "uLabel_Detail";
            this.uLabel_Detail.Size = new System.Drawing.Size(25, 229);
            this.uLabel_Detail.TabIndex = 1132;
            this.uLabel_Detail.Text = "�ڍ׏��";
            // 
            // uLabel_Payment
            // 
            appearance219.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance219.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance219.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance219.ForeColor = System.Drawing.Color.White;
            appearance219.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance219.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance219.TextHAlignAsString = "Center";
            appearance219.TextVAlignAsString = "Middle";
            this.uLabel_Payment.Appearance = appearance219;
            this.uLabel_Payment.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_Payment.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Payment.Location = new System.Drawing.Point(566, 41);
            this.uLabel_Payment.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_Payment.Name = "uLabel_Payment";
            this.uLabel_Payment.Size = new System.Drawing.Size(25, 407);
            this.uLabel_Payment.TabIndex = 1133;
            this.uLabel_Payment.Text = "�x�����";
            // 
            // SubInfo5_UTabPageControl
            // 
            this.SubInfo5_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo5_UTabPageControl.Name = "SubInfo5_UTabPageControl";
            this.SubInfo5_UTabPageControl.Size = new System.Drawing.Size(977, 149);
            // 
            // SubInfo4_UTabPageControl
            // 
            this.SubInfo4_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo4_UTabPageControl.Name = "SubInfo4_UTabPageControl";
            this.SubInfo4_UTabPageControl.Size = new System.Drawing.Size(977, 149);
            // 
            // SubInfo1_UTabPageControl
            // 
            this.SubInfo1_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo1_UTabPageControl.Name = "SubInfo1_UTabPageControl";
            this.SubInfo1_UTabPageControl.Size = new System.Drawing.Size(977, 149);
            // 
            // SubInfo_UTabSharedControlsPage
            // 
            this.SubInfo_UTabSharedControlsPage.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo_UTabSharedControlsPage.Name = "SubInfo_UTabSharedControlsPage";
            this.SubInfo_UTabSharedControlsPage.Size = new System.Drawing.Size(1009, 126);
            // 
            // SubInfo_UTabControl
            // 
            appearance220.BackColor = System.Drawing.Color.White;
            appearance220.BackColor2 = System.Drawing.Color.Pink;
            this.SubInfo_UTabControl.ActiveTabAppearance = appearance220;
            appearance221.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            appearance221.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.SubInfo_UTabControl.ClientAreaAppearance = appearance221;
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo_UTabSharedControlsPage);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo2_UTabPageControl);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo0_UTabPageControl);
            this.SubInfo_UTabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SubInfo_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(2);
            this.SubInfo_UTabControl.Location = new System.Drawing.Point(4, 451);
            this.SubInfo_UTabControl.Name = "SubInfo_UTabControl";
            this.SubInfo_UTabControl.SharedControlsPage = this.SubInfo_UTabSharedControlsPage;
            this.SubInfo_UTabControl.Size = new System.Drawing.Size(1011, 148);
            this.SubInfo_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubInfo_UTabControl.TabIndex = 1134;
            this.SubInfo_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.BottomLeft;
            ultraTab1.Key = "SubInfo0";
            ultraTab1.TabPage = this.SubInfo0_UTabPageControl;
            ultraTab1.Text = "(&1)�A������";
            ultraTab2.Key = "SubInfo2";
            ultraTab2.TabPage = this.SubInfo2_UTabPageControl;
            ultraTab2.Text = "(&2)���l���";
            this.SubInfo_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.SubInfo_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraLabel27
            // 
            appearance165.TextHAlignAsString = "Center";
            appearance165.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance165;
            this.ultraLabel27.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel27.Location = new System.Drawing.Point(31, 127);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel27.TabIndex = 1225;
            this.ultraLabel27.Text = "�d���旪��";
            // 
            // tEdit_SupplierSnm
            // 
            appearance166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierSnm.ActiveAppearance = appearance166;
            appearance167.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierSnm.Appearance = appearance167;
            this.tEdit_SupplierSnm.AutoSelect = true;
            this.tEdit_SupplierSnm.DataText = "";
            this.tEdit_SupplierSnm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierSnm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierSnm.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierSnm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierSnm.Location = new System.Drawing.Point(120, 128);
            this.tEdit_SupplierSnm.MaxLength = 20;
            this.tEdit_SupplierSnm.Name = "tEdit_SupplierSnm";
            this.tEdit_SupplierSnm.Size = new System.Drawing.Size(293, 22);
            this.tEdit_SupplierSnm.TabIndex = 4;
            this.tEdit_SupplierSnm.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // ultraLabel34
            // 
            appearance33.TextHAlignAsString = "Center";
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance33;
            this.ultraLabel34.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel34.Location = new System.Drawing.Point(33, 181);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel34.TabIndex = 1223;
            this.ultraLabel34.Text = "�h�@��";
            // 
            // ultraLabel12
            // 
            appearance241.TextHAlignAsString = "Center";
            appearance241.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance241;
            this.ultraLabel12.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(31, 152);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel12.TabIndex = 1222;
            this.ultraLabel12.Text = "�d���於(��)";
            // 
            // tEdit_SupplierKana
            // 
            appearance242.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierKana.ActiveAppearance = appearance242;
            appearance243.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance243.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierKana.Appearance = appearance243;
            this.tEdit_SupplierKana.AutoSelect = true;
            this.tEdit_SupplierKana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SupplierKana.DataText = "";
            this.tEdit_SupplierKana.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierKana.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_SupplierKana.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.tEdit_SupplierKana.Location = new System.Drawing.Point(120, 153);
            this.tEdit_SupplierKana.MaxLength = 30;
            this.tEdit_SupplierKana.Name = "tEdit_SupplierKana";
            this.tEdit_SupplierKana.Size = new System.Drawing.Size(217, 22);
            this.tEdit_SupplierKana.TabIndex = 5;
            this.tEdit_SupplierKana.ValueChanged += new System.EventHandler(this.tEdit_SupplierKana_ValueChanged);
            // 
            // tEdit_SupplierName2
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierName2.ActiveAppearance = appearance2;
            appearance31.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierName2.Appearance = appearance31;
            this.tEdit_SupplierName2.AutoSelect = true;
            this.tEdit_SupplierName2.DataText = "";
            this.tEdit_SupplierName2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierName2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierName2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierName2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierName2.Location = new System.Drawing.Point(120, 100);
            this.tEdit_SupplierName2.MaxLength = 30;
            this.tEdit_SupplierName2.Name = "tEdit_SupplierName2";
            this.tEdit_SupplierName2.Size = new System.Drawing.Size(430, 22);
            this.tEdit_SupplierName2.TabIndex = 3;
            this.tEdit_SupplierName2.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // ultraLabel6
            // 
            appearance237.TextHAlignAsString = "Center";
            appearance237.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance237;
            this.ultraLabel6.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(221, 181);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel6.TabIndex = 1227;
            this.ultraLabel6.Text = "�������h��";
            // 
            // uButton_MngSectionNmGuide
            // 
            this.uButton_MngSectionNmGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MngSectionNmGuide.Location = new System.Drawing.Point(485, 225);
            this.uButton_MngSectionNmGuide.Name = "uButton_MngSectionNmGuide";
            this.uButton_MngSectionNmGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_MngSectionNmGuide.TabIndex = 9;
            this.uButton_MngSectionNmGuide.Tag = "0";
            this.uButton_MngSectionNmGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MngSectionNmGuide.Click += new System.EventHandler(this.uButton_MngSectionNmGuide_Click);
            // 
            // tEdit_MngSectionNm
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MngSectionNm.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_MngSectionNm.Appearance = appearance24;
            this.tEdit_MngSectionNm.AutoSelect = true;
            this.tEdit_MngSectionNm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_MngSectionNm.DataText = "";
            this.tEdit_MngSectionNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MngSectionNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MngSectionNm.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MngSectionNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_MngSectionNm.Location = new System.Drawing.Point(120, 226);
            this.tEdit_MngSectionNm.MaxLength = 30;
            this.tEdit_MngSectionNm.Name = "tEdit_MngSectionNm";
            this.tEdit_MngSectionNm.Size = new System.Drawing.Size(362, 22);
            this.tEdit_MngSectionNm.TabIndex = 8;
            // 
            // ultraLabel57
            // 
            appearance26.TextHAlignAsString = "Center";
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel57.Appearance = appearance26;
            this.ultraLabel57.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel57.Location = new System.Drawing.Point(30, 226);
            this.ultraLabel57.Name = "ultraLabel57";
            this.ultraLabel57.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel57.TabIndex = 1290;
            this.ultraLabel57.Text = "�Ǘ����_";
            // 
            // ultraLabel39
            // 
            appearance132.TextHAlignAsString = "Center";
            appearance132.TextVAlignAsString = "Middle";
            this.ultraLabel39.Appearance = appearance132;
            this.ultraLabel39.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel39.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel39.Location = new System.Drawing.Point(30, 280);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel39.TabIndex = 1289;
            this.ultraLabel39.Text = "�����敪";
            // 
            // tComboEditor_PureCode
            // 
            appearance138.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PureCode.ActiveAppearance = appearance138;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_PureCode.Appearance = appearance16;
            this.tComboEditor_PureCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PureCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_PureCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance139.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PureCode.ItemAppearance = appearance139;
            this.tComboEditor_PureCode.Location = new System.Drawing.Point(120, 281);
            this.tComboEditor_PureCode.Name = "tComboEditor_PureCode";
            this.tComboEditor_PureCode.Size = new System.Drawing.Size(100, 22);
            this.tComboEditor_PureCode.TabIndex = 12;
            // 
            // tComboEditor_SupplierAttributeDiv
            // 
            appearance162.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierAttributeDiv.ActiveAppearance = appearance162;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SupplierAttributeDiv.Appearance = appearance19;
            this.tComboEditor_SupplierAttributeDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SupplierAttributeDiv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SupplierAttributeDiv.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance163.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierAttributeDiv.ItemAppearance = appearance163;
            this.tComboEditor_SupplierAttributeDiv.Location = new System.Drawing.Point(120, 309);
            this.tComboEditor_SupplierAttributeDiv.Name = "tComboEditor_SupplierAttributeDiv";
            this.tComboEditor_SupplierAttributeDiv.Size = new System.Drawing.Size(185, 22);
            this.tComboEditor_SupplierAttributeDiv.TabIndex = 13;
            // 
            // ultraLabel28
            // 
            appearance164.TextHAlignAsString = "Center";
            appearance164.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance164;
            this.ultraLabel28.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel28.Location = new System.Drawing.Point(30, 309);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(84, 22);
            this.ultraLabel28.TabIndex = 1287;
            this.ultraLabel28.Text = "�d���摮��";
            // 
            // tComboEditor_SalesAreaCode
            // 
            appearance182.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesAreaCode.ActiveAppearance = appearance182;
            appearance56.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SalesAreaCode.Appearance = appearance56;
            this.tComboEditor_SalesAreaCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SalesAreaCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance183.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesAreaCode.ItemAppearance = appearance183;
            this.tComboEditor_SalesAreaCode.Location = new System.Drawing.Point(120, 365);
            this.tComboEditor_SalesAreaCode.Name = "tComboEditor_SalesAreaCode";
            this.tComboEditor_SalesAreaCode.Size = new System.Drawing.Size(185, 22);
            this.tComboEditor_SalesAreaCode.TabIndex = 15;
            // 
            // ultraLabel7
            // 
            appearance184.TextHAlignAsString = "Center";
            appearance184.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance184;
            this.ultraLabel7.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel7.Location = new System.Drawing.Point(30, 365);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel7.TabIndex = 1284;
            this.ultraLabel7.Text = "�n�@��";
            // 
            // tComboEditor_BusinessTypeCode
            // 
            appearance201.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_BusinessTypeCode.ActiveAppearance = appearance201;
            appearance46.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_BusinessTypeCode.Appearance = appearance46;
            this.tComboEditor_BusinessTypeCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_BusinessTypeCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance202.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_BusinessTypeCode.ItemAppearance = appearance202;
            this.tComboEditor_BusinessTypeCode.Location = new System.Drawing.Point(120, 337);
            this.tComboEditor_BusinessTypeCode.Name = "tComboEditor_BusinessTypeCode";
            this.tComboEditor_BusinessTypeCode.Size = new System.Drawing.Size(185, 22);
            this.tComboEditor_BusinessTypeCode.TabIndex = 14;
            // 
            // BusinessTypeCodeTitle_ULabel
            // 
            appearance261.TextHAlignAsString = "Center";
            appearance261.TextVAlignAsString = "Middle";
            this.BusinessTypeCodeTitle_ULabel.Appearance = appearance261;
            this.BusinessTypeCodeTitle_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BusinessTypeCodeTitle_ULabel.Location = new System.Drawing.Point(30, 337);
            this.BusinessTypeCodeTitle_ULabel.Name = "BusinessTypeCodeTitle_ULabel";
            this.BusinessTypeCodeTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.BusinessTypeCodeTitle_ULabel.TabIndex = 1282;
            this.BusinessTypeCodeTitle_ULabel.Text = "�Ɓ@��";
            // 
            // tEdit_StockAgentNm
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentNm.ActiveAppearance = appearance85;
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance86.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_StockAgentNm.Appearance = appearance86;
            this.tEdit_StockAgentNm.AutoSelect = true;
            this.tEdit_StockAgentNm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_StockAgentNm.DataText = "";
            this.tEdit_StockAgentNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_StockAgentNm.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_StockAgentNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentNm.Location = new System.Drawing.Point(120, 254);
            this.tEdit_StockAgentNm.MaxLength = 30;
            this.tEdit_StockAgentNm.Name = "tEdit_StockAgentNm";
            this.tEdit_StockAgentNm.Size = new System.Drawing.Size(362, 22);
            this.tEdit_StockAgentNm.TabIndex = 10;
            // 
            // uButton_StockAgentGuide
            // 
            this.uButton_StockAgentGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_StockAgentGuide.Location = new System.Drawing.Point(485, 253);
            this.uButton_StockAgentGuide.Name = "uButton_StockAgentGuide";
            this.uButton_StockAgentGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_StockAgentGuide.TabIndex = 11;
            this.uButton_StockAgentGuide.Tag = "0";
            this.uButton_StockAgentGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_StockAgentGuide.Click += new System.EventHandler(this.uButton_StockAgentGuide_Click);
            // 
            // ultraLabel8
            // 
            appearance87.TextHAlignAsString = "Center";
            appearance87.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance87;
            this.ultraLabel8.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(30, 254);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel8.TabIndex = 1295;
            this.ultraLabel8.Text = "�d���S��";
            // 
            // ultraLabel60
            // 
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel60.Appearance = appearance80;
            this.ultraLabel60.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel60.Location = new System.Drawing.Point(711, 228);
            this.ultraLabel60.Name = "ultraLabel60";
            this.ultraLabel60.Size = new System.Drawing.Size(62, 22);
            this.ultraLabel60.TabIndex = 1316;
            this.ultraLabel60.Text = "���`����";
            // 
            // tNedit_NTimeCalcStDate
            // 
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_NTimeCalcStDate.ActiveAppearance = appearance81;
            appearance82.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance82.TextHAlignAsString = "Right";
            this.tNedit_NTimeCalcStDate.Appearance = appearance82;
            this.tNedit_NTimeCalcStDate.AutoSelect = true;
            this.tNedit_NTimeCalcStDate.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_NTimeCalcStDate.DataText = "";
            this.tNedit_NTimeCalcStDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_NTimeCalcStDate.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_NTimeCalcStDate.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_NTimeCalcStDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_NTimeCalcStDate.Location = new System.Drawing.Point(683, 228);
            this.tNedit_NTimeCalcStDate.MaxLength = 2;
            this.tNedit_NTimeCalcStDate.Name = "tNedit_NTimeCalcStDate";
            this.tNedit_NTimeCalcStDate.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_NTimeCalcStDate.Size = new System.Drawing.Size(25, 22);
            this.tNedit_NTimeCalcStDate.TabIndex = 28;
            // 
            // ultraLabel58
            // 
            appearance83.TextHAlignAsString = "Center";
            appearance83.TextVAlignAsString = "Middle";
            this.ultraLabel58.Appearance = appearance83;
            this.ultraLabel58.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel58.Location = new System.Drawing.Point(593, 228);
            this.ultraLabel58.Name = "ultraLabel58";
            this.ultraLabel58.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel58.TabIndex = 1314;
            this.ultraLabel58.Text = "���񊨒�";
            // 
            // uLabel_PayeeName1
            // 
            appearance84.BackColor = System.Drawing.Color.Gainsboro;
            appearance84.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance84.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance84.TextHAlignAsString = "Left";
            appearance84.TextVAlignAsString = "Middle";
            this.uLabel_PayeeName1.Appearance = appearance84;
            this.uLabel_PayeeName1.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_PayeeName1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_PayeeName1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PayeeName1.Location = new System.Drawing.Point(683, 100);
            this.uLabel_PayeeName1.Name = "uLabel_PayeeName1";
            this.uLabel_PayeeName1.Size = new System.Drawing.Size(326, 22);
            this.uLabel_PayeeName1.TabIndex = 20;
            this.uLabel_PayeeName1.WrapText = false;
            // 
            // tNedit_PayeeCode
            // 
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PayeeCode.ActiveAppearance = appearance89;
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance90.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance90.TextHAlignAsString = "Right";
            this.tNedit_PayeeCode.Appearance = appearance90;
            this.tNedit_PayeeCode.AutoSelect = true;
            this.tNedit_PayeeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_PayeeCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PayeeCode.DataText = "";
            this.tNedit_PayeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PayeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PayeeCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_PayeeCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PayeeCode.Location = new System.Drawing.Point(683, 76);
            this.tNedit_PayeeCode.MaxLength = 6;
            this.tNedit_PayeeCode.Name = "tNedit_PayeeCode";
            this.tNedit_PayeeCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_PayeeCode.Size = new System.Drawing.Size(53, 22);
            this.tNedit_PayeeCode.TabIndex = 18;
            // 
            // ultraLabel55
            // 
            appearance91.TextHAlignAsString = "Center";
            appearance91.TextVAlignAsString = "Middle";
            this.ultraLabel55.Appearance = appearance91;
            this.ultraLabel55.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel55.Location = new System.Drawing.Point(592, 78);
            this.ultraLabel55.Name = "ultraLabel55";
            this.ultraLabel55.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel55.TabIndex = 1311;
            this.ultraLabel55.Text = "�x����R�[�h";
            // 
            // ultraLabel53
            // 
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.ultraLabel53.Appearance = appearance102;
            this.ultraLabel53.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel53.Location = new System.Drawing.Point(593, 148);
            this.ultraLabel53.Name = "ultraLabel53";
            this.ultraLabel53.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel53.TabIndex = 1310;
            this.ultraLabel53.Text = "�x���旪��";
            // 
            // uLabel_PayeeSnm
            // 
            appearance103.BackColor = System.Drawing.Color.Gainsboro;
            appearance103.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance103.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance103.TextHAlignAsString = "Left";
            appearance103.TextVAlignAsString = "Middle";
            this.uLabel_PayeeSnm.Appearance = appearance103;
            this.uLabel_PayeeSnm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_PayeeSnm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_PayeeSnm.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PayeeSnm.Location = new System.Drawing.Point(683, 148);
            this.uLabel_PayeeSnm.Name = "uLabel_PayeeSnm";
            this.uLabel_PayeeSnm.Size = new System.Drawing.Size(326, 22);
            this.uLabel_PayeeSnm.TabIndex = 22;
            this.uLabel_PayeeSnm.WrapText = false;
            // 
            // tNedit_PaymentSight
            // 
            appearance151.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PaymentSight.ActiveAppearance = appearance151;
            appearance152.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance152.TextHAlignAsString = "Right";
            this.tNedit_PaymentSight.Appearance = appearance152;
            this.tNedit_PaymentSight.AutoSelect = true;
            this.tNedit_PaymentSight.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PaymentSight.DataText = "";
            this.tNedit_PaymentSight.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PaymentSight.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PaymentSight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_PaymentSight.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PaymentSight.Location = new System.Drawing.Point(976, 203);
            this.tNedit_PaymentSight.MaxLength = 3;
            this.tNedit_PaymentSight.Name = "tNedit_PaymentSight";
            this.tNedit_PaymentSight.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_PaymentSight.Size = new System.Drawing.Size(32, 22);
            this.tNedit_PaymentSight.TabIndex = 27;
            // 
            // ultraLabel29
            // 
            appearance153.TextHAlignAsString = "Center";
            appearance153.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance153;
            this.ultraLabel29.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel29.Location = new System.Drawing.Point(593, 203);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel29.TabIndex = 1307;
            this.ultraLabel29.Text = "�x������";
            // 
            // tComboEditor_PaymentCond
            // 
            appearance154.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PaymentCond.ActiveAppearance = appearance154;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_PaymentCond.Appearance = appearance29;
            this.tComboEditor_PaymentCond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PaymentCond.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_PaymentCond.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_PaymentCond.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PaymentCond.ItemAppearance = appearance155;
            this.tComboEditor_PaymentCond.Location = new System.Drawing.Point(683, 203);
            this.tComboEditor_PaymentCond.Name = "tComboEditor_PaymentCond";
            this.tComboEditor_PaymentCond.Size = new System.Drawing.Size(204, 22);
            this.tComboEditor_PaymentCond.TabIndex = 26;
            // 
            // uLabel_PayeeName2
            // 
            appearance197.BackColor = System.Drawing.Color.Gainsboro;
            appearance197.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance197.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance197.TextHAlignAsString = "Left";
            appearance197.TextVAlignAsString = "Middle";
            this.uLabel_PayeeName2.Appearance = appearance197;
            this.uLabel_PayeeName2.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_PayeeName2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_PayeeName2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PayeeName2.Location = new System.Drawing.Point(683, 124);
            this.uLabel_PayeeName2.Name = "uLabel_PayeeName2";
            this.uLabel_PayeeName2.Size = new System.Drawing.Size(326, 22);
            this.uLabel_PayeeName2.TabIndex = 21;
            this.uLabel_PayeeName2.WrapText = false;
            // 
            // tComboEditor_PaymentMonthCode
            // 
            appearance209.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PaymentMonthCode.ActiveAppearance = appearance209;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance30.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_PaymentMonthCode.Appearance = appearance30;
            this.tComboEditor_PaymentMonthCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PaymentMonthCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_PaymentMonthCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance210.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PaymentMonthCode.ItemAppearance = appearance210;
            this.tComboEditor_PaymentMonthCode.Location = new System.Drawing.Point(796, 177);
            this.tComboEditor_PaymentMonthCode.Name = "tComboEditor_PaymentMonthCode";
            this.tComboEditor_PaymentMonthCode.Size = new System.Drawing.Size(91, 22);
            this.tComboEditor_PaymentMonthCode.TabIndex = 24;
            // 
            // uButton_PayeeNameGuide
            // 
            this.uButton_PayeeNameGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_PayeeNameGuide.Location = new System.Drawing.Point(738, 75);
            this.uButton_PayeeNameGuide.Name = "uButton_PayeeNameGuide";
            this.uButton_PayeeNameGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_PayeeNameGuide.TabIndex = 19;
            this.uButton_PayeeNameGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_PayeeNameGuide.Click += new System.EventHandler(this.uButton_PayeeNameGuide_Click);
            // 
            // ultraLabel59
            // 
            appearance218.TextHAlignAsString = "Center";
            appearance218.TextVAlignAsString = "Middle";
            this.ultraLabel59.Appearance = appearance218;
            this.ultraLabel59.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel59.Location = new System.Drawing.Point(593, 100);
            this.ultraLabel59.Name = "ultraLabel59";
            this.ultraLabel59.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel59.TabIndex = 1305;
            this.ultraLabel59.Text = "�x���於";
            // 
            // tNedit_PaymentDay
            // 
            appearance227.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PaymentDay.ActiveAppearance = appearance227;
            appearance228.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance228.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance228.TextHAlignAsString = "Right";
            this.tNedit_PaymentDay.Appearance = appearance228;
            this.tNedit_PaymentDay.AutoSelect = true;
            this.tNedit_PaymentDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_PaymentDay.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PaymentDay.DataText = "";
            this.tNedit_PaymentDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PaymentDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PaymentDay.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_PaymentDay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PaymentDay.Location = new System.Drawing.Point(976, 177);
            this.tNedit_PaymentDay.MaxLength = 2;
            this.tNedit_PaymentDay.Name = "tNedit_PaymentDay";
            this.tNedit_PaymentDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_PaymentDay.Size = new System.Drawing.Size(25, 22);
            this.tNedit_PaymentDay.TabIndex = 25;
            // 
            // CollectMoneyCodeTitle_ULabel
            // 
            appearance229.TextHAlignAsString = "Center";
            appearance229.TextVAlignAsString = "Middle";
            this.CollectMoneyCodeTitle_ULabel.Appearance = appearance229;
            this.CollectMoneyCodeTitle_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CollectMoneyCodeTitle_ULabel.Location = new System.Drawing.Point(743, 177);
            this.CollectMoneyCodeTitle_ULabel.Name = "CollectMoneyCodeTitle_ULabel";
            this.CollectMoneyCodeTitle_ULabel.Size = new System.Drawing.Size(50, 22);
            this.CollectMoneyCodeTitle_ULabel.TabIndex = 1304;
            this.CollectMoneyCodeTitle_ULabel.Text = "�x����";
            // 
            // CollectMoneyDayTitle_ULabel
            // 
            appearance55.TextHAlignAsString = "Center";
            appearance55.TextVAlignAsString = "Middle";
            this.CollectMoneyDayTitle_ULabel.Appearance = appearance55;
            this.CollectMoneyDayTitle_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CollectMoneyDayTitle_ULabel.Location = new System.Drawing.Point(921, 177);
            this.CollectMoneyDayTitle_ULabel.Name = "CollectMoneyDayTitle_ULabel";
            this.CollectMoneyDayTitle_ULabel.Size = new System.Drawing.Size(50, 22);
            this.CollectMoneyDayTitle_ULabel.TabIndex = 1303;
            this.CollectMoneyDayTitle_ULabel.Text = "�x����";
            // 
            // tNedit_PaymentTotalDay
            // 
            appearance231.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PaymentTotalDay.ActiveAppearance = appearance231;
            appearance232.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance232.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance232.TextHAlignAsString = "Right";
            this.tNedit_PaymentTotalDay.Appearance = appearance232;
            this.tNedit_PaymentTotalDay.AutoSelect = true;
            this.tNedit_PaymentTotalDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_PaymentTotalDay.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PaymentTotalDay.DataText = "";
            this.tNedit_PaymentTotalDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PaymentTotalDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PaymentTotalDay.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_PaymentTotalDay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PaymentTotalDay.Location = new System.Drawing.Point(683, 176);
            this.tNedit_PaymentTotalDay.MaxLength = 2;
            this.tNedit_PaymentTotalDay.Name = "tNedit_PaymentTotalDay";
            this.tNedit_PaymentTotalDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_PaymentTotalDay.Size = new System.Drawing.Size(25, 22);
            this.tNedit_PaymentTotalDay.TabIndex = 23;
            // 
            // TotalDayTitle_ULabel
            // 
            appearance233.TextHAlignAsString = "Center";
            appearance233.TextVAlignAsString = "Middle";
            this.TotalDayTitle_ULabel.Appearance = appearance233;
            this.TotalDayTitle_ULabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalDayTitle_ULabel.Location = new System.Drawing.Point(593, 176);
            this.TotalDayTitle_ULabel.Name = "TotalDayTitle_ULabel";
            this.TotalDayTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.TotalDayTitle_ULabel.TabIndex = 1302;
            this.TotalDayTitle_ULabel.Text = "���@��";
            // 
            // tEdit_PaymentSectionCode
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PaymentSectionCode.ActiveAppearance = appearance9;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance13.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_PaymentSectionCode.Appearance = appearance13;
            this.tEdit_PaymentSectionCode.AutoSelect = true;
            this.tEdit_PaymentSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_PaymentSectionCode.DataText = "";
            this.tEdit_PaymentSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PaymentSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_PaymentSectionCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_PaymentSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_PaymentSectionCode.Location = new System.Drawing.Point(683, 48);
            this.tEdit_PaymentSectionCode.MaxLength = 30;
            this.tEdit_PaymentSectionCode.Name = "tEdit_PaymentSectionCode";
            this.tEdit_PaymentSectionCode.Size = new System.Drawing.Size(293, 22);
            this.tEdit_PaymentSectionCode.TabIndex = 16;
            // 
            // uButton_PaymentSectionGuide
            // 
            this.uButton_PaymentSectionGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_PaymentSectionGuide.Location = new System.Drawing.Point(979, 47);
            this.uButton_PaymentSectionGuide.Name = "uButton_PaymentSectionGuide";
            this.uButton_PaymentSectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_PaymentSectionGuide.TabIndex = 17;
            this.uButton_PaymentSectionGuide.Tag = "0";
            this.uButton_PaymentSectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_PaymentSectionGuide.Click += new System.EventHandler(this.uButton_MngSectionNmGuide_Click);
            // 
            // ultraLabel9
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance1;
            this.ultraLabel9.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(592, 48);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel9.TabIndex = 1319;
            this.ultraLabel9.Text = "�x�����_";
            // 
            // ultraLabel54
            // 
            appearance98.TextHAlignAsString = "Center";
            appearance98.TextVAlignAsString = "Middle";
            this.ultraLabel54.Appearance = appearance98;
            this.ultraLabel54.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel54.Location = new System.Drawing.Point(592, 305);
            this.ultraLabel54.Name = "ultraLabel54";
            this.ultraLabel54.Size = new System.Drawing.Size(88, 20);
            this.ultraLabel54.TabIndex = 1331;
            this.ultraLabel54.Text = "�Q�Ƌ敪";
            // 
            // ultraLabel52
            // 
            appearance99.TextHAlignAsString = "Center";
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLabel52.Appearance = appearance99;
            this.ultraLabel52.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel52.Location = new System.Drawing.Point(592, 288);
            this.ultraLabel52.Name = "ultraLabel52";
            this.ultraLabel52.Size = new System.Drawing.Size(87, 20);
            this.ultraLabel52.TabIndex = 1330;
            this.ultraLabel52.Text = "�]�ŕ���";
            // 
            // tComboEditor_SuppCTaXLayRefCd
            // 
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SuppCTaXLayRefCd.ActiveAppearance = appearance100;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SuppCTaXLayRefCd.Appearance = appearance21;
            this.tComboEditor_SuppCTaXLayRefCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SuppCTaXLayRefCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SuppCTaXLayRefCd.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_SuppCTaXLayRefCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SuppCTaXLayRefCd.ItemAppearance = appearance101;
            this.tComboEditor_SuppCTaXLayRefCd.Location = new System.Drawing.Point(683, 295);
            this.tComboEditor_SuppCTaXLayRefCd.MaxDropDownItems = 18;
            this.tComboEditor_SuppCTaXLayRefCd.Name = "tComboEditor_SuppCTaXLayRefCd";
            this.tComboEditor_SuppCTaXLayRefCd.Size = new System.Drawing.Size(120, 22);
            this.tComboEditor_SuppCTaXLayRefCd.TabIndex = 31;
            this.tComboEditor_SuppCTaXLayRefCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SuppCTaXLayRefCd_SelectionChangeCommitted);
            // 
            // ultraLabel13
            // 
            appearance172.TextHAlignAsString = "Center";
            appearance172.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance172;
            this.ultraLabel13.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel13.Location = new System.Drawing.Point(804, 307);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(81, 20);
            this.ultraLabel13.TabIndex = 1326;
            this.ultraLabel13.Text = "�]�ŕ���";
            // 
            // tComboEditor_SuppTaxLayMethod
            // 
            appearance173.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SuppTaxLayMethod.ActiveAppearance = appearance173;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance28.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SuppTaxLayMethod.Appearance = appearance28;
            this.tComboEditor_SuppTaxLayMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SuppTaxLayMethod.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SuppTaxLayMethod.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_SuppTaxLayMethod.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance174.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SuppTaxLayMethod.ItemAppearance = appearance174;
            this.tComboEditor_SuppTaxLayMethod.Location = new System.Drawing.Point(889, 296);
            this.tComboEditor_SuppTaxLayMethod.MaxDropDownItems = 18;
            this.tComboEditor_SuppTaxLayMethod.Name = "tComboEditor_SuppTaxLayMethod";
            this.tComboEditor_SuppTaxLayMethod.Size = new System.Drawing.Size(120, 22);
            this.tComboEditor_SuppTaxLayMethod.TabIndex = 32;
            // 
            // ultraLabel17
            // 
            appearance181.TextHAlignAsString = "Center";
            appearance181.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance181;
            this.ultraLabel17.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel17.Location = new System.Drawing.Point(804, 290);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(81, 20);
            this.ultraLabel17.TabIndex = 1320;
            this.ultraLabel17.Text = "�����";
            // 
            // tNedit_StockCnsTaxFrcProcCd
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance92.TextHAlignAsString = "Right";
            this.tNedit_StockCnsTaxFrcProcCd.ActiveAppearance = appearance92;
            appearance93.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance93.TextHAlignAsString = "Right";
            this.tNedit_StockCnsTaxFrcProcCd.Appearance = appearance93;
            this.tNedit_StockCnsTaxFrcProcCd.AutoSelect = true;
            this.tNedit_StockCnsTaxFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_StockCnsTaxFrcProcCd.DataText = "";
            this.tNedit_StockCnsTaxFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_StockCnsTaxFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_StockCnsTaxFrcProcCd.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_StockCnsTaxFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_StockCnsTaxFrcProcCd.Location = new System.Drawing.Point(683, 402);
            this.tNedit_StockCnsTaxFrcProcCd.MaxLength = 8;
            this.tNedit_StockCnsTaxFrcProcCd.Name = "tNedit_StockCnsTaxFrcProcCd";
            this.tNedit_StockCnsTaxFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_StockCnsTaxFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_StockCnsTaxFrcProcCd.TabIndex = 37;
            // 
            // tNedit_StockMoneyFrcProcCd
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance94.TextHAlignAsString = "Right";
            this.tNedit_StockMoneyFrcProcCd.ActiveAppearance = appearance94;
            appearance95.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance95.TextHAlignAsString = "Right";
            this.tNedit_StockMoneyFrcProcCd.Appearance = appearance95;
            this.tNedit_StockMoneyFrcProcCd.AutoSelect = true;
            this.tNedit_StockMoneyFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_StockMoneyFrcProcCd.DataText = "";
            this.tNedit_StockMoneyFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_StockMoneyFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_StockMoneyFrcProcCd.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_StockMoneyFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_StockMoneyFrcProcCd.Location = new System.Drawing.Point(683, 365);
            this.tNedit_StockMoneyFrcProcCd.MaxLength = 8;
            this.tNedit_StockMoneyFrcProcCd.Name = "tNedit_StockMoneyFrcProcCd";
            this.tNedit_StockMoneyFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_StockMoneyFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_StockMoneyFrcProcCd.TabIndex = 35;
            // 
            // tNedit_StockUnPrcFrcProcCd
            // 
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance96.TextHAlignAsString = "Right";
            this.tNedit_StockUnPrcFrcProcCd.ActiveAppearance = appearance96;
            appearance97.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance97.TextHAlignAsString = "Right";
            this.tNedit_StockUnPrcFrcProcCd.Appearance = appearance97;
            this.tNedit_StockUnPrcFrcProcCd.AutoSelect = true;
            this.tNedit_StockUnPrcFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_StockUnPrcFrcProcCd.DataText = "";
            this.tNedit_StockUnPrcFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_StockUnPrcFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_StockUnPrcFrcProcCd.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_StockUnPrcFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_StockUnPrcFrcProcCd.Location = new System.Drawing.Point(683, 329);
            this.tNedit_StockUnPrcFrcProcCd.MaxLength = 8;
            this.tNedit_StockUnPrcFrcProcCd.Name = "tNedit_StockUnPrcFrcProcCd";
            this.tNedit_StockUnPrcFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_StockUnPrcFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_StockUnPrcFrcProcCd.TabIndex = 33;
            // 
            // uButton_SalesCnsTaxFrcProcCdGuide
            // 
            this.uButton_SalesCnsTaxFrcProcCdGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesCnsTaxFrcProcCdGuide.Location = new System.Drawing.Point(752, 401);
            this.uButton_SalesCnsTaxFrcProcCdGuide.Name = "uButton_SalesCnsTaxFrcProcCdGuide";
            this.uButton_SalesCnsTaxFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesCnsTaxFrcProcCdGuide.TabIndex = 38;
            this.uButton_SalesCnsTaxFrcProcCdGuide.Tag = "1";
            this.uButton_SalesCnsTaxFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesCnsTaxFrcProcCdGuide.Click += new System.EventHandler(this.uButton_SalesUnPrcFrcProcCdGuide_Click);
            // 
            // uButton_SalesMoneyFrcProcCdGuide
            // 
            this.uButton_SalesMoneyFrcProcCdGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesMoneyFrcProcCdGuide.Location = new System.Drawing.Point(752, 364);
            this.uButton_SalesMoneyFrcProcCdGuide.Name = "uButton_SalesMoneyFrcProcCdGuide";
            this.uButton_SalesMoneyFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesMoneyFrcProcCdGuide.TabIndex = 36;
            this.uButton_SalesMoneyFrcProcCdGuide.Tag = "0";
            this.uButton_SalesMoneyFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesMoneyFrcProcCdGuide.Click += new System.EventHandler(this.uButton_SalesUnPrcFrcProcCdGuide_Click);
            // 
            // uButton_SalesUnPrcFrcProcCdGuide
            // 
            this.uButton_SalesUnPrcFrcProcCdGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesUnPrcFrcProcCdGuide.Location = new System.Drawing.Point(752, 328);
            this.uButton_SalesUnPrcFrcProcCdGuide.Name = "uButton_SalesUnPrcFrcProcCdGuide";
            this.uButton_SalesUnPrcFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesUnPrcFrcProcCdGuide.TabIndex = 34;
            this.uButton_SalesUnPrcFrcProcCdGuide.Tag = "2";
            this.uButton_SalesUnPrcFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesUnPrcFrcProcCdGuide.Click += new System.EventHandler(this.uButton_SalesUnPrcFrcProcCdGuide_Click);
            // 
            // ultraLabel44
            // 
            appearance119.TextHAlignAsString = "Center";
            appearance119.TextVAlignAsString = "Middle";
            this.ultraLabel44.Appearance = appearance119;
            this.ultraLabel44.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel44.Location = new System.Drawing.Point(592, 341);
            this.ultraLabel44.Name = "ultraLabel44";
            this.ultraLabel44.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel44.TabIndex = 1340;
            this.ultraLabel44.Text = "�[������";
            // 
            // ultraLabel47
            // 
            appearance120.TextHAlignAsString = "Center";
            appearance120.TextVAlignAsString = "Middle";
            this.ultraLabel47.Appearance = appearance120;
            this.ultraLabel47.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel47.Location = new System.Drawing.Point(592, 324);
            this.ultraLabel47.Name = "ultraLabel47";
            this.ultraLabel47.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ultraLabel47.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel47.TabIndex = 1339;
            this.ultraLabel47.Text = "�P��";
            // 
            // ultraLabel45
            // 
            appearance121.TextHAlignAsString = "Center";
            appearance121.TextVAlignAsString = "Middle";
            this.ultraLabel45.Appearance = appearance121;
            this.ultraLabel45.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel45.Location = new System.Drawing.Point(592, 374);
            this.ultraLabel45.Name = "ultraLabel45";
            this.ultraLabel45.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel45.TabIndex = 1338;
            this.ultraLabel45.Text = "�[������";
            // 
            // ultraLabel46
            // 
            appearance122.TextHAlignAsString = "Center";
            appearance122.TextVAlignAsString = "Middle";
            this.ultraLabel46.Appearance = appearance122;
            this.ultraLabel46.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel46.Location = new System.Drawing.Point(593, 359);
            this.ultraLabel46.Name = "ultraLabel46";
            this.ultraLabel46.Size = new System.Drawing.Size(84, 20);
            this.ultraLabel46.TabIndex = 1337;
            this.ultraLabel46.Text = "���z";
            // 
            // ultraLabel18
            // 
            appearance168.TextHAlignAsString = "Center";
            appearance168.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance168;
            this.ultraLabel18.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel18.Location = new System.Drawing.Point(592, 408);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(84, 20);
            this.ultraLabel18.TabIndex = 1333;
            this.ultraLabel18.Text = "�[������";
            // 
            // ultraLabel19
            // 
            appearance169.TextHAlignAsString = "Center";
            appearance169.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance169;
            this.ultraLabel19.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            this.ultraLabel19.Location = new System.Drawing.Point(592, 392);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(84, 20);
            this.ultraLabel19.TabIndex = 1332;
            this.ultraLabel19.Text = "�����";
            // 
            // ultraLabel20
            // 
            appearance230.TextHAlignAsString = "Center";
            appearance230.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance230;
            this.ultraLabel20.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel20.Location = new System.Drawing.Point(893, 203);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(77, 22);
            this.ultraLabel20.TabIndex = 1347;
            this.ultraLabel20.Text = "�x���T�C�g";
            this.ultraLabel20.Click += new System.EventHandler(this.ultraLabel20_Click);
            // 
            // NameToKana_TImeControl
            // 
            this.NameToKana_TImeControl.InControl = this.tEdit_SupplierName1;
            this.NameToKana_TImeControl.OutControl = this.tEdit_SupplierKana;
            this.NameToKana_TImeControl.OwnerForm = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tEdit_SuppHonorificTitle
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SuppHonorificTitle.ActiveAppearance = appearance8;
            appearance36.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SuppHonorificTitle.Appearance = appearance36;
            this.tEdit_SuppHonorificTitle.AutoSelect = true;
            this.tEdit_SuppHonorificTitle.DataText = "";
            this.tEdit_SuppHonorificTitle.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SuppHonorificTitle.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SuppHonorificTitle.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SuppHonorificTitle.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SuppHonorificTitle.Location = new System.Drawing.Point(120, 181);
            this.tEdit_SuppHonorificTitle.MaxLength = 4;
            this.tEdit_SuppHonorificTitle.Name = "tEdit_SuppHonorificTitle";
            this.tEdit_SuppHonorificTitle.Size = new System.Drawing.Size(73, 22);
            this.tEdit_SuppHonorificTitle.TabIndex = 6;
            // 
            // tEdit_OrderHonorificTtl
            // 
            appearance244.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_OrderHonorificTtl.ActiveAppearance = appearance244;
            appearance41.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_OrderHonorificTtl.Appearance = appearance41;
            this.tEdit_OrderHonorificTtl.AutoSelect = true;
            this.tEdit_OrderHonorificTtl.DataText = "";
            this.tEdit_OrderHonorificTtl.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OrderHonorificTtl.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_OrderHonorificTtl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_OrderHonorificTtl.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_OrderHonorificTtl.Location = new System.Drawing.Point(312, 181);
            this.tEdit_OrderHonorificTtl.MaxLength = 4;
            this.tEdit_OrderHonorificTtl.Name = "tEdit_OrderHonorificTtl";
            this.tEdit_OrderHonorificTtl.Size = new System.Drawing.Size(73, 22);
            this.tEdit_OrderHonorificTtl.TabIndex = 7;
            // 
            // uButton_OfrSupplierGuide
            // 
            this.uButton_OfrSupplierGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_OfrSupplierGuide.Location = new System.Drawing.Point(175, 45);
            this.uButton_OfrSupplierGuide.Name = "uButton_OfrSupplierGuide";
            this.uButton_OfrSupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_OfrSupplierGuide.TabIndex = 1;
            this.uButton_OfrSupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_OfrSupplierGuide.Click += new System.EventHandler(this.uButton_OfrSupplierGuide_Click);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(631, 605);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 9990;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // PMKHN09020UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1018, 671);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.uButton_OfrSupplierGuide);
            this.Controls.Add(this.tEdit_OrderHonorificTtl);
            this.Controls.Add(this.tEdit_SuppHonorificTitle);
            this.Controls.Add(this.ultraLabel20);
            this.Controls.Add(this.tNedit_StockCnsTaxFrcProcCd);
            this.Controls.Add(this.tNedit_StockMoneyFrcProcCd);
            this.Controls.Add(this.tNedit_StockUnPrcFrcProcCd);
            this.Controls.Add(this.ultraLabel44);
            this.Controls.Add(this.ultraLabel47);
            this.Controls.Add(this.uButton_SalesCnsTaxFrcProcCdGuide);
            this.Controls.Add(this.uButton_SalesMoneyFrcProcCdGuide);
            this.Controls.Add(this.uButton_SalesUnPrcFrcProcCdGuide);
            this.Controls.Add(this.ultraLabel45);
            this.Controls.Add(this.ultraLabel46);
            this.Controls.Add(this.ultraLabel18);
            this.Controls.Add(this.ultraLabel19);
            this.Controls.Add(this.ultraLabel54);
            this.Controls.Add(this.ultraLabel52);
            this.Controls.Add(this.tComboEditor_SuppCTaXLayRefCd);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.tComboEditor_SuppTaxLayMethod);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.tEdit_PaymentSectionCode);
            this.Controls.Add(this.uButton_PaymentSectionGuide);
            this.Controls.Add(this.ultraLabel60);
            this.Controls.Add(this.tNedit_NTimeCalcStDate);
            this.Controls.Add(this.ultraLabel58);
            this.Controls.Add(this.uLabel_PayeeName1);
            this.Controls.Add(this.tNedit_PayeeCode);
            this.Controls.Add(this.ultraLabel55);
            this.Controls.Add(this.ultraLabel53);
            this.Controls.Add(this.uLabel_PayeeSnm);
            this.Controls.Add(this.tNedit_PaymentSight);
            this.Controls.Add(this.ultraLabel29);
            this.Controls.Add(this.tComboEditor_PaymentCond);
            this.Controls.Add(this.uLabel_PayeeName2);
            this.Controls.Add(this.tComboEditor_PaymentMonthCode);
            this.Controls.Add(this.uButton_PayeeNameGuide);
            this.Controls.Add(this.ultraLabel59);
            this.Controls.Add(this.tNedit_PaymentDay);
            this.Controls.Add(this.CollectMoneyCodeTitle_ULabel);
            this.Controls.Add(this.CollectMoneyDayTitle_ULabel);
            this.Controls.Add(this.tNedit_PaymentTotalDay);
            this.Controls.Add(this.TotalDayTitle_ULabel);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel57);
            this.Controls.Add(this.uButton_StockAgentGuide);
            this.Controls.Add(this.tEdit_StockAgentNm);
            this.Controls.Add(this.uButton_MngSectionNmGuide);
            this.Controls.Add(this.tEdit_MngSectionNm);
            this.Controls.Add(this.ultraLabel39);
            this.Controls.Add(this.ultraLabel28);
            this.Controls.Add(this.tComboEditor_PureCode);
            this.Controls.Add(this.tComboEditor_SupplierAttributeDiv);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.tComboEditor_SalesAreaCode);
            this.Controls.Add(this.BusinessTypeCodeTitle_ULabel);
            this.Controls.Add(this.tComboEditor_BusinessTypeCode);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel27);
            this.Controls.Add(this.tEdit_SupplierSnm);
            this.Controls.Add(this.ultraLabel34);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.tEdit_SupplierKana);
            this.Controls.Add(this.tEdit_SupplierName2);
            this.Controls.Add(this.SubInfo_UTabControl);
            this.Controls.Add(this.uLabel_Payment);
            this.Controls.Add(this.uLabel_Detail);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.uLabel_CustomerNameTitle);
            this.Controls.Add(this.tNedit_SupplierCd);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.BLGoodsFullName_Title_Label);
            this.Controls.Add(this.tEdit_SupplierName1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.BLGoodsCode_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.ultraLabel61);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.ultraLabel2);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09020UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�d����}�X�^";
            this.Load += new System.EventHandler(this.PMKHN09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09020UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09020UA_Closing);
            this.SubInfo0_UTabPageControl.ResumeLayout(false);
            this.SubInfo0_Panel.ResumeLayout(false);
            this.SubInfo0_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierPostNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo2)).EndInit();
            this.SubInfo2_UTabPageControl.ResumeLayout(false);
            this.SubInfo2_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubInfo_UTabControl)).EndInit();
            this.SubInfo_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierKana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MngSectionNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PureCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierAttributeDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_BusinessTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_NTimeCalcStDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentSight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PaymentCond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PaymentMonthCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentTotalDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PaymentSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SuppCTaXLayRefCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SuppTaxLayMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockCnsTaxFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockMoneyFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockUnPrcFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SuppHonorificTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OrderHonorificTtl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ��IMasterMaintenanceArrayType�����o�[

		# region ��Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ��Properties
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
			}
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{
				return this._canLogicalDeleteDataExtraction;
			}
		}

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

		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
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

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{
				return this._defaultAutoFillToColumn;
			}
		}
		# endregion

		# region ��Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 22018 ��ؐ��b</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
            bindDataSet = this._dataSet;
            tableName = _supplierDataTable.TableName;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList retList = null;


            // ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
            status = this._supplierAcs.SearchAll( out retList, this._enterpriseCode );

            this._totalCount = retList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach ( Supplier supplier in retList )
                        {
                            if ( ExistsInCache( supplier ) == false )
                            {
                                CopyToDataSet( supplier, index );
                                ++index;
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
                        TMsgDisp.Show(
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Search",							  // ��������
                            TMsgDisp.OPE_GET,					  // �I�y���[�V����
                            ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._supplierAcs,				  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                        break;
                    }
            }

            totalCount = this._totalCount;
            
            return status;
		}

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        public int SearchNext( int readCount )
        {
            // �l�N�X�g�f�[�^���������i�������j
            return 0;
        }

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;

            // �w�肳�ꂽDataTable���R�[�h�ɑΉ�����f�[�^���擾
            Supplier supplier = GetFromCache( _supplierDataTable.Rows[this._dataIndex] );
            if ( supplier == null ) return 0;

            // --- ADD 2008/12/24 [��QID:9452�Ή�]----------------------------------------------------------->>>>>
            for (int index = 0; index < _supplierDataTable.Rows.Count; index++)
            {
                Supplier supplierWk = GetFromCache(_supplierDataTable.Rows[index]);

                // �폜�Ώۂ̎d����Ɠ������R�[�h�̏ꍇ
                if (supplier.Equals(supplierWk))
                {
                    continue;
                }

                // �폜�Ώۂ̎d���悪�e�d����Ƃ��Đݒ肳��Ă���ꍇ
                if (supplier.SupplierCd == supplierWk.PayeeCode)
                {
                    TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "���̃��R�[�h�͐e�d����Ƃ��Đݒ肳��Ă��邽�ߍ폜�ł��܂���",
                            status,
                            MessageBoxButtons.OK);
                    return (-1);
                }
            }
            // --- ADD 2008/12/24 [��QID:9452�Ή�]-----------------------------------------------------------<<<<<

            status = this._supplierAcs.LogicalDelete( ref supplier );
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction( status, TMsgDisp.OPE_DELETE, this._supplierAcs );
                        return status;
                    }
                case -2:
                    {
                        //���Ɛݒ�Ŏg�p��
                        TMsgDisp.Show( this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
                            status,
                            MessageBoxButtons.OK );
                        this.Hide();

                        return status;
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
                            this._supplierAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1 );	// �����\���{�^��

                        return status;
                    }
            }

            // �f�[�^�Z�b�g�W�J����
            CopyToDataSet( supplier, this._dataIndex );
			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
		{
            string supplierFormat = GetSupplierCdFormat();

			Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add( DELETE_DATE, new GridColAppearance( MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red ) ); // �폜��
            appearanceTable.Add( GUID_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) ); // GUID
            appearanceTable.Add( SUPPLIERCD_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, supplierFormat, Color.Black ) ); // �d����R�[�h
            appearanceTable.Add( SUPPLIERNM1_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �d���於1
            appearanceTable.Add( SUPPLIERNM2_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �d���於2
            appearanceTable.Add( SUPPHONORIFICTITLE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �d����h��
            appearanceTable.Add( SUPPLIERKANA_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �d����J�i
            appearanceTable.Add( SUPPLIERSNM_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �d���旪��
            appearanceTable.Add( MNGSECTIONCODE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black ) ); // �Ǘ����_�R�[�h
            appearanceTable.Add( MNGSECTIONNAME_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �Ǘ����_����
            appearanceTable.Add( PURECODE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �����敪
            appearanceTable.Add( PAYMENTSECTIONCODE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black ) ); // �x�����_�R�[�h
            appearanceTable.Add( PAYMENTSECTIONNAME_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �x�����_����
            appearanceTable.Add( PAYEECODE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, supplierFormat, Color.Black ) ); // �x����R�[�h
            appearanceTable.Add( PAYEESNM_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // �x���旪��

            return appearanceTable;
		}
        /// <summary>
        /// �d����R�[�h�t�H�[�}�b�g�擾
        /// </summary>
        /// <returns></returns>
        private string GetSupplierCdFormat()
        {
            UiSet uiset;
            uiSetControl1.ReadUISet( out uiset, this.tNedit_SupplierCd.Name );

            if ( uiset != null )
            {
                return new string( '0', uiset.Column );
            }
            else
            {
                return string.Empty;
            }
        }
		# endregion

		# endregion

		#region ��Private Menbers
        private DataSet _dataSet;
        private DataTable _supplierDataTable;
		private SupplierAcs _supplierAcs;
        private OfrSupplierAcs _ofrSupplierAcs;
		private SecInfoAcs _secInfoAcs;
		private int _totalCount;
		private string _enterpriseCode;
        private Dictionary<Guid, Supplier> _supplierDic;
        private NoDispData _noDispData;
        // �K�C�h�E�ǂݍ���
        private SecInfoSetAcs _secInfoSetAcs;
        private EmployeeAcs _employeeAcs;
        private StockProcMoneyAcs _stockProcMoneyAcs;
        List<StockProcMoneyKey> _stockProcMoneyCdList;
        private AddressGuide _addressGuide;
        private static List<UserGdBd> _userGdBdListStc;
        private UserGuideAcs _userGuideAcs;
        private Dictionary<string, AllDefSet> _allDefSetDic;
        private TaxRateSet _taxRateSet;
        // �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private Supplier _supplier;

        // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
        PaymentSetAcs _paymentSetAcs;
        MoneyKindAcs _moneyKindAcs;
        // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;
		/// <summary>���_�I�v�V�����t���O</summary>
		private bool _optSection = false;

        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
		# endregion

		# region ��Consts
		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private const string DELETE_DATE = "�폜��";
        //private const string SECTIONNAME_TITLE = "�������_";
		
        //private const string BLGoodsCode_TITLE			= "BL���i�R�[�h";
        //private const string BLGoodsCdDerivedNo_TITLE	= "�}��";
        //private const string BLGoodsFullName_TITLE		= "BL���i����";
        //private const string BLGoodsHalfName_TITLE		= "BL���i����(�J�i)";
        //private const string BLGoodsGenreCode_TITLE	= "BL���i����";
        //private const string LargeGoodsGanreCode_TITLE	= "���i�敪�O���[�v";
        //private const string LargeGoodsGanreName_TITLE	= "���i�敪�O���[�v����";
        //private const string MediumGoodsGanreCode_TITLE	= "���i�敪";
        //private const string MediumGoodsGanreName_TITLE	= "���i�敪����";
        //private const string DetailGoodsGanreCode_TITLE	= "���i�敪�ڍ�";
        //private const string DetailGoodsGanreName_TITLE	= "���i�敪�ڍז���";
        //private const string DIVISION_TITLE = "�f�[�^�敪�R�[�h";
        //private const string DIVISIONNAME_TITLE = "�f�[�^�敪";

        //private const string GUID_TITLE = "GUID";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // �e�[�u����
        private const string SUPPLIER_TABLE = "SUPPLIER";

        // �e�[�u���J������
        private const string DELETE_DATE = "�폜���@�@�@�@�@";
        private const string GUID_TITLE = "GUID";

        private const string SUPPLIERCD_TITLE = "�d����R�[�h";
        private const string SUPPLIERNM1_TITLE = "�d���於1";
        private const string SUPPLIERNM2_TITLE = "�d���於2";
        private const string SUPPHONORIFICTITLE_TITLE = "�d����h��";
        private const string SUPPLIERKANA_TITLE = "�d���於(��)";
        private const string SUPPLIERSNM_TITLE = "�d���旪��";

        private const string MNGSECTIONCODE_TITLE = "�Ǘ����_�R�[�h";
        private const string MNGSECTIONNAME_TITLE = "�Ǘ����_��";

        private const string PURECODE_TITLE = "�����敪";

        private const string PAYMENTSECTIONCODE_TITLE = "�x�����_�R�[�h";
        private const string PAYMENTSECTIONNAME_TITLE = "�x�����_��";
        private const string PAYEECODE_TITLE = "�x����R�[�h";
        private const string PAYEESNM_TITLE = "�x���旪��";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //private const string MAKERU_TABLE = "LGOODSGANRE";

		//�f�[�^�敪
		private const int DIVISION_USR = 0;
		private const int DIVISION_OFR = 1;

		private const string DIVISION_USR_NAME = "0";
		private const string DIVISION_OFR_NAME = "1";

		private const string DIVISION_USR_NAME_TITLE = "���[�U�[�f�[�^";
		private const string DIVISION_OFR_NAME_TITLE = "�񋟃f�[�^";	

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";
		private const string REFERENCE_MODE = "�Q�ƃ��[�h";

		// �R���g���[������
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";

		// Message�֘A��`
		private const string ASSEMBLY_ID	= "PMKHN09020U";
		private const string PG_NM			= "�d����}�X�^";
		private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG	= "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
		private const string ERR_RDEL_MSG	= "�폜�Ɏ��s���܂����B";
		private const string ERR_UPDT_MSG	= "�o�^�Ɏ��s���܂����B";
		private const string ERR_RVV_MSG	= "�����Ɏ��s���܂����B";
		private const string ERR_800_MSG	= "���ɑ��[�����X�V����Ă��܂�";
		private const string ERR_801_MSG	= "���ɑ��[�����폜����Ă��܂�";
		private const string SDC_RDEL_MSG	= "�}�X�^����폜����Ă��܂�";
		#endregion
    
		# region ��Main
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMKHN09020UA());
		}
		# endregion

		#region ��IMasterMaintenanceInputStart Members
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paraTable"></param>
		/// <returns></returns>
		public DialogResult ShowDialog(Hashtable paraTable)
		{
			this.ShowDialog();
			return this.DialogResult;
		}
		#endregion

		# region ��Private Methods

        // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �x���ݒ�}�X�^����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �x���ݒ�}�X�^���擾���܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/12/12</br>
        /// </remarks>
        private int ReadPaymentSet(out PaymentSet paymentSet)
        {
            paymentSet = new PaymentSet();
            int status = this._paymentSetAcs.Read(out paymentSet, this._enterpriseCode, 0);

            return (status);
        }

        /// <summary>
        /// ���z��ʐݒ�}�X�^����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���z��ʐݒ�}�X�^���擾���܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/12/12</br>
        /// </remarks>
        private int ReadMoneyKind(out Dictionary<int, MoneyKind> moneyKindDic)
        {
            moneyKindDic = new Dictionary<int, MoneyKind>();

            int status;
            ArrayList retList = new ArrayList();

            status = this._moneyKindAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (MoneyKind moneyKind in retList)
                {
                    // ���z�ݒ�敪���u0:�����v���g�p
                    if ((moneyKind.LogicalDeleteCode == 0) && (moneyKind.PriceStCode == 0))
                    {
                        moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                    }
                }
            }

            return (status);
        }
        // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<

        # region [�X���C�_����̒P�ƋN���Ή�]
        /// <summary>�P�ƋN���t���O</summary>
        private bool _singleExecute = false;
        /// <summary>��ƃR�[�h</summary>
        private string _paraEnterpriseCode = string.Empty;
        /// <summary>�d����R�[�h</summary>
        private int _paraSupplierCode = 0;
        # endregion

        # region [�L���b�V������]
        /// <summary>
        /// �L���b�V������̑Ή��f�[�^�擾����
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Supplier GetFromCache( DataRow row )
        {
            try
            {
                Guid key = (Guid)row[GUID_TITLE];

                if ( _supplierDic.ContainsKey( key ) )
                {
                    return _supplierDic[key];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// �L���b�V���p�f�B�N�V���i�������ݔ��菈��
        /// </summary>
        /// <param name="supplier"></param>
        private bool ExistsInCache( Supplier supplier )
        {
            // GUID���L�[�ɂ��đ��ݔ���
            return this._supplierDic.ContainsKey( supplier.FileHeaderGuid );
        }
        /// <summary>
        /// �L���b�V���p�f�B�N�V���i���X�V����
        /// </summary>
        /// <param name="supplier"></param>
        private void UpdateCache( Supplier supplier )
        {
            // GUID���L�[�ɂ��đ��ݔ���
            if ( this._supplierDic.ContainsKey( supplier.FileHeaderGuid ) )
            {
                // �����Ȃ狌�f�[�^���폜
                this._supplierDic.Remove( supplier.FileHeaderGuid );
            }
            // �f�B�N�V���i���ɒǉ�
            this._supplierDic.Add( supplier.FileHeaderGuid, supplier );
        }
        /// <summary>
        /// �L���b�V���p�f�B�N�V���i�����폜����
        /// </summary>
        /// <param name="supplier"></param>
        private void DeleteFromCache( Supplier supplier )
        {
            // GUID���L�[�ɂ��đ��ݔ���
            if ( this._supplierDic.ContainsKey( supplier.FileHeaderGuid ) )
            {
                // �폜
                this._supplierDic.Remove( supplier.FileHeaderGuid );
            }
        }
        # endregion
        # region [�f�[�^�N���X���f�[�^�e�[�u���s]
        /// <summary>
        /// �d����}�X�^ �I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="supplier">�d����}�X�^ �I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : �d����}�X�^ �N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void CopyToDataSet(Supplier supplier, int index)
		{
            DataRow row;

            if ( (index < 0) || (_supplierDataTable.Rows.Count <= index) )
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                _supplierDataTable.Rows.Add( _supplierDataTable.NewRow() );

                // index���s�̍ŏI�s�ԍ�����
                index = _supplierDataTable.Rows.Count - 1;
            }
            // �s�擾
            row = _supplierDataTable.Rows[index];


            // �폜���t
            if ( supplier.LogicalDeleteCode == 0 )
            {
                row[DELETE_DATE] = "";
            }
            else
            {
                row[DELETE_DATE] = supplier.UpdateDateTimeJpInFormal;
            }

            row[GUID_TITLE] = supplier.FileHeaderGuid; // GUID
            row[SUPPLIERCD_TITLE] = supplier.SupplierCd; // �d����R�[�h
            row[SUPPLIERNM1_TITLE] = supplier.SupplierNm1; // �d���於1
            row[SUPPLIERNM2_TITLE] = supplier.SupplierNm2; // �d���於2
            row[SUPPHONORIFICTITLE_TITLE] = supplier.SuppHonorificTitle; // �d����h��
            row[SUPPLIERKANA_TITLE] = supplier.SupplierKana; // �d����J�i
            row[SUPPLIERSNM_TITLE] = supplier.SupplierSnm; // �d���旪��
            row[MNGSECTIONCODE_TITLE] = supplier.MngSectionCode; // �Ǘ����_�R�[�h
            row[MNGSECTIONNAME_TITLE] = supplier.MngSectionName; // �Ǘ����_����
            row[PURECODE_TITLE] = GetPureCodeName( supplier.PureCode ); // �����敪
            row[PAYMENTSECTIONCODE_TITLE] = supplier.PaymentSectionCode; // �x�����_�R�[�h
            row[PAYMENTSECTIONNAME_TITLE] = supplier.PaymentSectionName; // �x�����_����
            row[PAYEECODE_TITLE] = supplier.PayeeCode; // �x����R�[�h
            row[PAYEESNM_TITLE] = supplier.PayeeSnm; // �x���旪��

            // �L���b�V���X�V
            UpdateCache( supplier );
        }

        // ADD 2009/05/27 ------>>>
        /// <summary>
        /// �q�d����}�X�^ �I�u�W�F�N�g�f�[�^�Z�b�g�X�V����
        /// </summary>
        /// <param name="childSupplier">�q�d����}�X�^ �I�u�W�F�N�g</param>
        /// <param name="parentSupplier">�e�d����}�X�^ �I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �d����}�X�^ �N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// </remarks>
        private void ReflectChildSupplierToDataSet(Supplier childSupplier, Supplier parentSupplier)
        {
            DataRow row;

            int index;
            for (index = 0; index < _supplierDataTable.Rows.Count; index++)
            {
                if ((int)_supplierDataTable.Rows[index][SUPPLIERCD_TITLE] == childSupplier.SupplierCd)
                {
                    break;
                }
            }

            if (index == _supplierDataTable.Rows.Count)
            {
                return;
            }

            // �s�擾
            row = _supplierDataTable.Rows[index];

            // �폜���t
            if (childSupplier.LogicalDeleteCode == 0)
            {
                row[DELETE_DATE] = "";
            }
            else
            {
                row[DELETE_DATE] = childSupplier.UpdateDateTimeJpInFormal;
            }

            row[GUID_TITLE] = childSupplier.FileHeaderGuid; // GUID
            row[SUPPLIERCD_TITLE] = childSupplier.SupplierCd; // �d����R�[�h
            row[SUPPLIERNM1_TITLE] = childSupplier.SupplierNm1; // �d���於1
            row[SUPPLIERNM2_TITLE] = childSupplier.SupplierNm2; // �d���於2
            row[SUPPHONORIFICTITLE_TITLE] = childSupplier.SuppHonorificTitle; // �d����h��
            row[SUPPLIERKANA_TITLE] = childSupplier.SupplierKana; // �d����J�i
            row[SUPPLIERSNM_TITLE] = childSupplier.SupplierSnm; // �d���旪��
            row[MNGSECTIONCODE_TITLE] = childSupplier.MngSectionCode; // �Ǘ����_�R�[�h
            row[MNGSECTIONNAME_TITLE] = childSupplier.MngSectionName; // �Ǘ����_����
            row[PURECODE_TITLE] = GetPureCodeName(childSupplier.PureCode); // �����敪
            row[PAYMENTSECTIONCODE_TITLE] = childSupplier.PaymentSectionCode; // �x�����_�R�[�h
            row[PAYMENTSECTIONNAME_TITLE] = childSupplier.PaymentSectionName; // �x�����_����
            row[PAYEECODE_TITLE] = childSupplier.PayeeCode; // �x����R�[�h
            row[PAYEESNM_TITLE] = parentSupplier.SupplierSnm; // �e�d����̎d���旪��

            // �L���b�V���X�V
            UpdateCache(childSupplier);
        }
        // ADD 2009/05/27 ------<<<

        /// <summary>
        /// �����敪����
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetPureCodeName( int p )
        {
            switch ( p )
            {
                case 0: return "����";
                case 1: return "�D��";
            }
            return string.Empty;
        }
        # endregion
        # region [�e�[�u������]
        /// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
            // DataSet��������ΐ���
            if ( _dataSet == null )
            {
                _dataSet = new DataSet();
            }
            // DataTable��������ΐ���
            if ( _supplierDataTable == null )
            {
                _supplierDataTable = new DataTable( SUPPLIER_TABLE );

                _supplierDataTable.Columns.Add( DELETE_DATE, typeof( string ) ); // �폜��
                _supplierDataTable.Columns.Add( GUID_TITLE, typeof( Guid ) ); // GUID
                _supplierDataTable.Columns.Add( SUPPLIERCD_TITLE, typeof( Int32 ) ); // �d����R�[�h
                _supplierDataTable.Columns.Add( SUPPLIERNM1_TITLE, typeof( string ) ); // �d���於1
                _supplierDataTable.Columns.Add( SUPPLIERNM2_TITLE, typeof( string ) ); // �d���於2
                _supplierDataTable.Columns.Add( SUPPHONORIFICTITLE_TITLE, typeof( string ) ); // �d����h��
                _supplierDataTable.Columns.Add( SUPPLIERKANA_TITLE, typeof( string ) ); // �d����J�i
                _supplierDataTable.Columns.Add( SUPPLIERSNM_TITLE, typeof( string ) ); // �d���旪��
                _supplierDataTable.Columns.Add( MNGSECTIONCODE_TITLE, typeof( string ) ); // �Ǘ����_�R�[�h
                _supplierDataTable.Columns.Add( MNGSECTIONNAME_TITLE, typeof( string ) ); // �Ǘ����_����
                _supplierDataTable.Columns.Add( PURECODE_TITLE, typeof( string ) ); // �����敪
                _supplierDataTable.Columns.Add( PAYMENTSECTIONCODE_TITLE, typeof( string ) ); // �x�����_�R�[�h
                _supplierDataTable.Columns.Add( PAYMENTSECTIONNAME_TITLE, typeof( string ) ); // �x�����_����
                _supplierDataTable.Columns.Add( PAYEECODE_TITLE, typeof( Int32 ) ); // �x����R�[�h
                _supplierDataTable.Columns.Add( PAYEESNM_TITLE, typeof( string ) ); // �x���旪��

                _dataSet.Tables.Add( _supplierDataTable );
            }
        }
        # endregion
        # region [��ʐ���]
        /// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ScreenInitialSetting()
        {
            # region [�R���{�{�b�N�X�A�C�e���i�Œ�l�j]
            //// �h��
            //AddComboEditorItem( tComboEditor_SuppHonorificTitle, 0, Supplier.CST_HonorificTitle_0 );
            //AddComboEditorItem( tComboEditor_SuppHonorificTitle, 1, Supplier.CST_HonorificTitle_1 );
            //AddComboEditorItem( tComboEditor_SuppHonorificTitle, 2, Supplier.CST_HonorificTitle_2 );
            //// �������h��
            //AddComboEditorItem( tComboEditor_OrderHonorificTtl, 0, Supplier.CST_HonorificTitle_0 );
            //AddComboEditorItem( tComboEditor_OrderHonorificTtl, 1, Supplier.CST_HonorificTitle_1 );
            //AddComboEditorItem( tComboEditor_OrderHonorificTtl, 2, Supplier.CST_HonorificTitle_2 );
            // �����敪
            AddComboEditorItem( tComboEditor_PureCode, 0, Supplier.CST_PureCode_0 );
            AddComboEditorItem( tComboEditor_PureCode, 1, Supplier.CST_PureCode_1 );
            // �x�����敪
            AddComboEditorItem( tComboEditor_PaymentMonthCode, 0, Supplier.CST_PaymentMonthCode_0 );
            AddComboEditorItem( tComboEditor_PaymentMonthCode, 1, Supplier.CST_PaymentMonthCode_1 );
            AddComboEditorItem( tComboEditor_PaymentMonthCode, 2, Supplier.CST_PaymentMonthCode_2 );
            AddComboEditorItem( tComboEditor_PaymentMonthCode, 3, Supplier.CST_PaymentMonthCode_3 );
            // ����œ]�ŕ����Q�Ƌ敪
            AddComboEditorItem( tComboEditor_SuppCTaXLayRefCd, 0, Supplier.CST_SuppCTaxLayRefCd_0 );
            AddComboEditorItem( tComboEditor_SuppCTaXLayRefCd, 1, Supplier.CST_SuppCTaxLayRefCd_1 );
            // ����œ]�ŕ����敪
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 0, Supplier.CST_SuppCTaxLayCd_0 );
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 1, Supplier.CST_SuppCTaxLayCd_1 );
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 2, Supplier.CST_SuppCTaxLayCd_2 );
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 3, Supplier.CST_SuppCTaxLayCd_3 );
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 9, Supplier.CST_SuppCTaxLayCd_9 );
            // �d���摮���敪
            AddComboEditorItem( tComboEditor_SupplierAttributeDiv, 0, Supplier.CST_SupplierAttributeDiv_0 );
            AddComboEditorItem( tComboEditor_SupplierAttributeDiv, 8, Supplier.CST_SupplierAttributeDiv_8 );
            AddComboEditorItem( tComboEditor_SupplierAttributeDiv, 9, Supplier.CST_SupplierAttributeDiv_9 );

            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            // ���z�\���敪
            AddComboEditorItem( tComboEditor_SuppTtlAmountDispWayCd, 0, Supplier.CST_SuppTtlAmntDspWayCd_0 );
            AddComboEditorItem( tComboEditor_SuppTtlAmountDispWayCd, 1, Supplier.CST_SuppTtlAmntDspWayCd_1 );
            // ���z�\���Q�Ƌ敪
            AddComboEditorItem( tComboEditor_StckTtlAmntDspWayRef, 0, Supplier.CST_StckTtlAmntDspWayRef_0 );
            AddComboEditorItem( tComboEditor_StckTtlAmntDspWayRef, 1, Supplier.CST_StckTtlAmntDspWayRef_1 );
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

            // �x������
            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
            //AddComboEditorItem( tComboEditor_PaymentCond, 10, Supplier.CST_PaymentCond_10 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 20, Supplier.CST_PaymentCond_20 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 30, Supplier.CST_PaymentCond_30 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 40, Supplier.CST_PaymentCond_40 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 50, Supplier.CST_PaymentCond_50 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 60, Supplier.CST_PaymentCond_60 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 70, Supplier.CST_PaymentCond_70 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 80, Supplier.CST_PaymentCond_80 );

            // �x���ݒ�}�X�^�Ǎ�
            PaymentSet paymentSet;
            int status = ReadPaymentSet(out paymentSet);
            if (status == 0)
            {
                // ���z��ʐݒ�}�X�^�Ǎ�
                Dictionary<int, MoneyKind> moneyKindDic;
                status = ReadMoneyKind(out moneyKindDic);
                if (status == 0)
                {
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd1))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd1, moneyKindDic[paymentSet.PayStMoneyKindCd1].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd2))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd2, moneyKindDic[paymentSet.PayStMoneyKindCd2].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd3))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd3, moneyKindDic[paymentSet.PayStMoneyKindCd3].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd4))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd4, moneyKindDic[paymentSet.PayStMoneyKindCd4].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd5))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd5, moneyKindDic[paymentSet.PayStMoneyKindCd5].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd6))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd6, moneyKindDic[paymentSet.PayStMoneyKindCd6].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd7))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd7, moneyKindDic[paymentSet.PayStMoneyKindCd7].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd8))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd8, moneyKindDic[paymentSet.PayStMoneyKindCd8].MoneyKindName);
                    }
                }
            }
            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
            # endregion

            # region [�R���{�{�b�N�X�A�C�e���i���[�U�[�K�C�h�j]
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            int status;
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            ArrayList retList;

            // �Ǝ�i���[�U�[�K�C�h�}�X�^���擾�j
            status = this.GetDivCodeBodyList( 33, out retList );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                retList.Sort();

                AddComboEditorItem( this.tComboEditor_BusinessTypeCode, 0, " " );
                int count = 1;
                foreach ( ComboEditorItemSupplier ci in retList )
                {
                    count++;
                    AddComboEditorItem( this.tComboEditor_BusinessTypeCode, ci.Code, ci.Name );
                }
            }
            // �̔��G���A�i���[�U�[�K�C�h�}�X�^���擾�j
            status = this.GetDivCodeBodyList( 21, out retList );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                retList.Sort();

                AddComboEditorItem( this.tComboEditor_SalesAreaCode, 0, " " );
                int count = 1;
                foreach ( ComboEditorItemSupplier ci in retList )
                {
                    count++;
                    AddComboEditorItem( this.tComboEditor_SalesAreaCode, ci.Code, ci.Name );
                }
            }

            # endregion

        }
        /// <summary>
        /// �V���R�[�h�쐬���������͏���
        /// </summary>
        private void SetNewRecordFirstInput( ref Supplier supplier)
        {
            // �h��
            tEdit_SuppHonorificTitle.Text = "�l";
            tEdit_OrderHonorificTtl.Text = "�l";

            // �Ǘ����_
            SecInfoSet secInfoSet;
            if ( _secInfoAcs == null )
            {
                _secInfoAcs = new SecInfoAcs();
            }
            secInfoSet = _secInfoAcs.SecInfoSet;

            _noDispData.MngSectionCode = secInfoSet.SectionCode;
            _noDispData.PrevMngSectionName = secInfoSet.SectionGuideNm;
            tEdit_MngSectionNm.Text = secInfoSet.SectionGuideNm;

            // �d���S����
            _noDispData.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
            _noDispData.PrevStockAgentName = LoginInfoAcquisition.Employee.Name;
            tEdit_StockAgentNm.Text = LoginInfoAcquisition.Employee.Name;

            // �x�����_
            _noDispData.PaymentSectionCode = secInfoSet.SectionCode;
            _noDispData.PrevPaymentSectionName = secInfoSet.SectionGuideNm;
            tEdit_PaymentSectionCode.Text = secInfoSet.SectionGuideNm;

            // �ޔ�p�f�[�^���X�V����
            supplier.SuppHonorificTitle = "�l";
            supplier.OrderHonorificTtl = "�l";
            supplier.MngSectionCode = secInfoSet.SectionCode;
            supplier.MngSectionName = secInfoSet.SectionGuideNm;
            supplier.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
            supplier.StockAgentName = LoginInfoAcquisition.Employee.Name;
            supplier.PaymentSectionCode = secInfoSet.SectionCode;
            supplier.PaymentSectionName = secInfoSet.SectionGuideNm;
        }
        /// <summary>
        /// �R���{�G�f�B�^�A�C�e���ǉ�����
        /// </summary>
        /// <param name="sender">�ΏۃR���{�G�f�B�^</param>
        /// <param name="dataValue">�A�C�e���f�[�^</param>
        /// <param name="displayText">�A�C�e���\���e�L�X�g</param>
        private static void AddComboEditorItem( TComboEditor sender, int dataValue, string displayText )
        {
            Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
            item.DataValue = dataValue;
            item.DisplayText = displayText;

            sender.Items.Add( item );
        }
        /// <summary>
        /// �R���{�G�f�B�^�A�C�e���C���f�b�N�X�ݒ菈��
        /// </summary>
        /// <param name="sender">�ΏۂƂȂ�R���{�G�f�B�^</param>
        /// <param name="dataValue">�ݒ�l</param>
        private static void SetComboEditorItemIndex( TComboEditor sender, int dataValue )
        {
            int index = -1;

            if ( dataValue != 0 )
            {
                for ( int i = 0; i < sender.Items.Count; i++ )
                {
                    if ( (sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue) )
                    {
                        index = i;
                        break;
                    }
                }
            }
            else
            {
                //if ( (sender.Items.Count > 0) && ((int)sender.Items[0].DataValue == 0) )
                if ( sender.Items.Count > 0 )
                {
                    index = dataValue;
                }
            }
            sender.SelectedIndex = index;
        }


		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ScreenClear()
		{
            // ���O
            tNedit_SupplierCd.SetInt( 0 );
            tEdit_SupplierName1.Clear();
            tEdit_SupplierName2.Clear();
            tEdit_SupplierSnm.Clear();
            tEdit_SupplierKana.Clear();
            //tComboEditor_SuppHonorificTitle.SelectedIndex = 0;
            //tComboEditor_OrderHonorificTtl.SelectedIndex = 0;
            tEdit_SuppHonorificTitle.Text = string.Empty;
            tEdit_OrderHonorificTtl.Text = string.Empty;

            // �ڍ׏��
            tEdit_MngSectionNm.Clear();
            tEdit_StockAgentNm.Clear();
            tComboEditor_PureCode.SelectedIndex = 0;
            tComboEditor_SupplierAttributeDiv.SelectedIndex = 0;
            tComboEditor_BusinessTypeCode.SelectedIndex = 0;
            tComboEditor_SalesAreaCode.SelectedIndex = 0;

            // �x�����
            tEdit_PaymentSectionCode.Clear();
            tNedit_PayeeCode.SetInt( 0 );
            uLabel_PayeeName1.Text = string.Empty;
            uLabel_PayeeName2.Text = string.Empty;
            uLabel_PayeeSnm.Text = string.Empty;
            tNedit_PaymentTotalDay.SetInt( 0 );
            tComboEditor_PaymentMonthCode.SelectedIndex = 0;
            tNedit_PaymentDay.SetInt( 0 );
            tComboEditor_PaymentCond.SelectedIndex = 0;
            tNedit_PaymentSight.SetInt( 0 );
            tNedit_NTimeCalcStDate.SetInt( 0 );
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            tComboEditor_StckTtlAmntDspWayRef.SelectedIndex = 0;
            tComboEditor_SuppTtlAmountDispWayCd.SelectedIndex = 0;
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            tComboEditor_SuppCTaXLayRefCd.SelectedIndex = 0;
            tComboEditor_SuppTaxLayMethod.SelectedIndex = 0;
            tNedit_StockUnPrcFrcProcCd.SetInt( 0 );
            tNedit_StockMoneyFrcProcCd.SetInt( 0 );
            tNedit_StockCnsTaxFrcProcCd.SetInt( 0 );

            // �A������
            tEdit_SupplierPostNo.Clear();
            tEdit_SupplierAddr1.Clear();
            tEdit_SupplierAddr3.Clear();
            tEdit_SupplierAddr4.Clear();
            tEdit_SupplierTelNo.Clear();
            tEdit_SupplierTelNo1.Clear();
            tEdit_SupplierTelNo2.Clear();
            
            // ���l���
            tEdit_SupplierNote1.Clear();
            tEdit_SupplierNote2.Clear();
            tEdit_SupplierNote3.Clear();
            tEdit_SupplierNote4.Clear();

            // UI��\���f�[�^
            _noDispData.Clear();
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
            Supplier supplier = null;

            if ( this.DataIndex >= 0 )
            {
                supplier = GetFromCache( _supplierDataTable.Rows[this._dataIndex] );
                // (���L���b�V�����ɑΉ�����f�[�^���������null���Ԃ����)
            }

            if ( supplier == null )
            {
                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // �{�^���ݒ�
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = true;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                //_dataIndex�o�b�t�@�ێ�
                this._indexBuf = this._dataIndex;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl( INSERT_MODE );

                // �V�K�f�[�^�������͏���
                this._supplier = new Supplier();
                SetNewRecordFirstInput( ref this._supplier );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                // ��ʓW�J����
                DataToScreen( this._supplier );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD

                // �t�H�[�J�X�ݒ�
                this.tNedit_SupplierCd.Focus();
            }
            else
            {
                if ( supplier.LogicalDeleteCode == 0 )
                {
                    // �X�V���[�h
                    this.Mode_Label.Text = UPDATE_MODE;

                    // �{�^���ݒ�
                    this.Ok_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl( UPDATE_MODE );

                    // ��ʓW�J����
                    DataToScreen( supplier );

                    //�N���[���쐬
                    this._supplier = supplier.Clone();
                    DispToSupplier( ref this._supplier );
                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;

                    // �t�H�[�J�X�ݒ�
                    this.tEdit_SupplierName1.Focus();
                    this.tEdit_SupplierName1.SelectAll();
                }
                else
                {
                    // �폜���[�h
                    this.Mode_Label.Text = DELETE_MODE;

                    // �{�^���ݒ�
                    this.Ok_Button.Visible = false;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = false;
                    // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

                    //_dataIndex�o�b�t�@�ێ�
                    this._indexBuf = this._dataIndex;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl( DELETE_MODE );

                    // ��ʓW�J����
                    DataToScreen( supplier );

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

            }
            //�I�����̔�r�̂��߁A���݂̃t�H�[�����͏�Ԃ�ێ�
            this._supplier = new Supplier();
            DispToSupplier(ref this._supplier);
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="mode">�ҏW���[�h</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ScreenInputPermissionControl(string mode)
		{
            // �S�R���g���[�����X�g
            # region [allControlList]
            List<Control> allControlList = new List<Control>( new Control[]
                {
                    tNedit_SupplierCd,
                    tEdit_SupplierName1,
                    tEdit_SupplierName2,
                    tEdit_SupplierSnm,
                    tEdit_SupplierKana,
                    //tComboEditor_SuppHonorificTitle,
                    tEdit_SuppHonorificTitle,
                    //tComboEditor_OrderHonorificTtl,
                    tEdit_OrderHonorificTtl,
                    tEdit_MngSectionNm,
                    tEdit_StockAgentNm,
                    tComboEditor_PureCode,
                    tComboEditor_SupplierAttributeDiv,
                    tComboEditor_BusinessTypeCode,
                    tComboEditor_SalesAreaCode,
                    tEdit_PaymentSectionCode,
                    tNedit_PayeeCode,
                    tNedit_PaymentTotalDay,
                    tComboEditor_PaymentMonthCode,
                    tNedit_PaymentDay,
                    tComboEditor_PaymentCond,
                    tNedit_PaymentSight,
                    tNedit_NTimeCalcStDate,
                    /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                    tComboEditor_StckTtlAmntDspWayRef,
                    tComboEditor_SuppTtlAmountDispWayCd,
                       --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                    tComboEditor_SuppCTaXLayRefCd,
                    tComboEditor_SuppTaxLayMethod,
                    tNedit_StockUnPrcFrcProcCd,
                    tNedit_StockMoneyFrcProcCd,
                    tNedit_StockCnsTaxFrcProcCd,
                    tEdit_SupplierPostNo,
                    tEdit_SupplierAddr1,
                    tEdit_SupplierAddr3,
                    tEdit_SupplierAddr4,
                    tEdit_SupplierTelNo,
                    tEdit_SupplierTelNo1,
                    tEdit_SupplierTelNo2,
                    tEdit_SupplierNote1,
                    tEdit_SupplierNote2,
                    tEdit_SupplierNote3,
                    tEdit_SupplierNote4,
                    uButton_OfrSupplierGuide,
                    uButton_MngSectionNmGuide,
                    uButton_StockAgentGuide,
                    uButton_PaymentSectionGuide,
                    uButton_PayeeNameGuide,
                    uButton_SalesUnPrcFrcProcCdGuide,
                    uButton_SalesMoneyFrcProcCdGuide,
                    uButton_SalesCnsTaxFrcProcCdGuide,
                    uButton_AddressGuide,
                    uButton_Note1Guide,
                    uButton_Note2Guide,
                    uButton_Note3Guide,
                    uButton_Note4Guide
                } );
            # endregion

            // ���͉\�R���g���[�����X�g
            List<Control> enableControlList = new List<Control>();

			switch(mode)
			{
				case INSERT_MODE:		// �V�K
                    {
                        # region [enableControlList]
                        enableControlList.AddRange( new Control[]
                            {
                                tNedit_SupplierCd,
                                tEdit_SupplierName1,
                                tEdit_SupplierName2,
                                tEdit_SupplierSnm,
                                tEdit_SupplierKana,
                                //tComboEditor_SuppHonorificTitle,
                                tEdit_SuppHonorificTitle,
                                //tComboEditor_OrderHonorificTtl,
                                tEdit_OrderHonorificTtl,
                                tEdit_MngSectionNm,
                                tEdit_StockAgentNm,
                                tComboEditor_PureCode,
                                tComboEditor_SupplierAttributeDiv,
                                tComboEditor_BusinessTypeCode,
                                tComboEditor_SalesAreaCode,
                                tEdit_PaymentSectionCode,
                                tNedit_PayeeCode,
                                tNedit_PaymentTotalDay,
                                tComboEditor_PaymentMonthCode,
                                tNedit_PaymentDay,
                                tComboEditor_PaymentCond,
                                tNedit_PaymentSight,
                                tNedit_NTimeCalcStDate,
                                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                tComboEditor_StckTtlAmntDspWayRef,
                                tComboEditor_SuppTtlAmountDispWayCd,
                                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                tComboEditor_SuppCTaXLayRefCd,
                                tComboEditor_SuppTaxLayMethod,
                                tNedit_StockUnPrcFrcProcCd,
                                tNedit_StockMoneyFrcProcCd,
                                tNedit_StockCnsTaxFrcProcCd,
                                tEdit_SupplierPostNo,
                                tEdit_SupplierAddr1,
                                tEdit_SupplierAddr3,
                                tEdit_SupplierAddr4,
                                tEdit_SupplierTelNo,
                                tEdit_SupplierTelNo1,
                                tEdit_SupplierTelNo2,
                                tEdit_SupplierNote1,
                                tEdit_SupplierNote2,
                                tEdit_SupplierNote3,
                                tEdit_SupplierNote4,
                                uButton_OfrSupplierGuide,
                                uButton_MngSectionNmGuide,
                                uButton_StockAgentGuide,
                                uButton_PaymentSectionGuide,
                                uButton_PayeeNameGuide,
                                uButton_SalesUnPrcFrcProcCdGuide,
                                uButton_SalesMoneyFrcProcCdGuide,
                                uButton_SalesCnsTaxFrcProcCdGuide,
                                uButton_AddressGuide,
                                uButton_Note1Guide,
                                uButton_Note2Guide,
                                uButton_Note3Guide,
                                uButton_Note4Guide
                            } );
                        # endregion
                        break;
					}
				case UPDATE_MODE:		// �X�V
					{
                        # region [enableControlList]
                        enableControlList.AddRange( new Control[]
                            {
                                //tNedit_SupplierCd,
                                tEdit_SupplierName1,
                                tEdit_SupplierName2,
                                tEdit_SupplierSnm,
                                tEdit_SupplierKana,
                                //tComboEditor_SuppHonorificTitle,
                                tEdit_SuppHonorificTitle,
                                //tComboEditor_OrderHonorificTtl,
                                tEdit_OrderHonorificTtl,
                                tEdit_MngSectionNm,
                                tEdit_StockAgentNm,
                                tComboEditor_PureCode,
                                tComboEditor_SupplierAttributeDiv,
                                tComboEditor_BusinessTypeCode,
                                tComboEditor_SalesAreaCode,
                                tEdit_PaymentSectionCode,
                                tNedit_PayeeCode,
                                tNedit_PaymentTotalDay,
                                tComboEditor_PaymentMonthCode,
                                tNedit_PaymentDay,
                                tComboEditor_PaymentCond,
                                tNedit_PaymentSight,
                                tNedit_NTimeCalcStDate,
                                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                tComboEditor_StckTtlAmntDspWayRef,
                                tComboEditor_SuppTtlAmountDispWayCd,
                                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                tComboEditor_SuppCTaXLayRefCd,
                                tComboEditor_SuppTaxLayMethod,
                                tNedit_StockUnPrcFrcProcCd,
                                tNedit_StockMoneyFrcProcCd,
                                tNedit_StockCnsTaxFrcProcCd,
                                tEdit_SupplierPostNo,
                                tEdit_SupplierAddr1,
                                tEdit_SupplierAddr3,
                                tEdit_SupplierAddr4,
                                tEdit_SupplierTelNo,
                                tEdit_SupplierTelNo1,
                                tEdit_SupplierTelNo2,
                                tEdit_SupplierNote1,
                                tEdit_SupplierNote2,
                                tEdit_SupplierNote3,
                                tEdit_SupplierNote4,
                                //uButton_OfrSupplierGuide,
                                uButton_MngSectionNmGuide,
                                uButton_StockAgentGuide,
                                uButton_PaymentSectionGuide,
                                uButton_PayeeNameGuide,
                                uButton_SalesUnPrcFrcProcCdGuide,
                                uButton_SalesMoneyFrcProcCdGuide,
                                uButton_SalesCnsTaxFrcProcCdGuide,
                                uButton_AddressGuide,
                                uButton_Note1Guide,
                                uButton_Note2Guide,
                                uButton_Note3Guide,
                                uButton_Note4Guide
                            } );
                        # endregion
						break;
					}
				case DELETE_DATE:		// �폜
				case REFERENCE_MODE:	// �Q��
					{
                        # region [enableControlList]
                        //enableControlList.Clear();
                        # endregion
                        break;
					}
			}

            // �e�R���g���[����enabled��K�p
            foreach ( Control control in allControlList )
            {
                if ( enableControlList.Contains( control ) )
                {
                    control.Enabled = true;
                }
                else
                {
                    control.Enabled = false;
                }
            }
        }
        #endregion

        # region [��ʁ����f�[�^�@���ݕϊ�]
        /// <summary>
        /// �d����}�X�^ �N���X��ʓW�J����
		/// </summary>
		/// <param name="supplier">�d����}�X�^ �I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �d����}�X�^ �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void DataToScreen(Supplier supplier)
        {
            # region [Supplier��Screen]
            // ���O
            tNedit_SupplierCd.SetInt( supplier.SupplierCd );
            tEdit_SupplierName1.Text = supplier.SupplierNm1;
            tEdit_SupplierName2.Text = supplier.SupplierNm2;
            tEdit_SupplierSnm.Text = supplier.SupplierSnm;
            tEdit_SupplierKana.Text = supplier.SupplierKana;
            //tComboEditor_SuppHonorificTitle.Text = supplier.SuppHonorificTitle;
            tEdit_SuppHonorificTitle.Text = supplier.SuppHonorificTitle;
            //tComboEditor_OrderHonorificTtl.Text = supplier.OrderHonorificTtl;
            tEdit_OrderHonorificTtl.Text = supplier.OrderHonorificTtl;

            // �ڍ׏��
            tEdit_MngSectionNm.Text = supplier.MngSectionName;
            tEdit_StockAgentNm.Text = supplier.StockAgentName;
            SetComboEditorItemIndex( tComboEditor_PureCode, supplier.PureCode );
            SetComboEditorItemIndex( tComboEditor_SupplierAttributeDiv, supplier.SupplierAttributeDiv );
            SetComboEditorItemIndex( tComboEditor_BusinessTypeCode, supplier.BusinessTypeCode );
            SetComboEditorItemIndex( tComboEditor_SalesAreaCode, supplier.SalesAreaCode );

            // �x�����
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            tEdit_PaymentSectionCode.Text = supplier.PaymentSectionName;
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            tNedit_PayeeCode.SetInt( supplier.PayeeCode );
            uLabel_PayeeName1.Text = supplier.PayeeName;
            uLabel_PayeeName2.Text = supplier.PayeeName2;
            uLabel_PayeeSnm.Text = supplier.PayeeSnm;
            tNedit_PaymentTotalDay.SetInt( supplier.PaymentTotalDay );
            SetComboEditorItemIndex( tComboEditor_PaymentMonthCode, supplier.PaymentMonthCode );
            tNedit_PaymentDay.SetInt( supplier.PaymentDay );
            SetComboEditorItemIndex( tComboEditor_PaymentCond, supplier.PaymentCond );
            tNedit_PaymentSight.SetInt( supplier.PaymentSight );
            tNedit_NTimeCalcStDate.SetInt( supplier.NTimeCalcStDate );
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            SetComboEditorItemIndex( tComboEditor_StckTtlAmntDspWayRef, supplier.StckTtlAmntDspWayRef );
            SetComboEditorItemIndex( tComboEditor_SuppTtlAmountDispWayCd, supplier.SuppTtlAmntDspWayCd );
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            SetComboEditorItemIndex( tComboEditor_SuppCTaXLayRefCd, supplier.SuppCTaxLayRefCd );
            SetComboEditorItemIndex( tComboEditor_SuppTaxLayMethod, supplier.SuppCTaxLayCd );
            tNedit_StockUnPrcFrcProcCd.SetInt( supplier.StockUnPrcFrcProcCd );
            tNedit_StockMoneyFrcProcCd.SetInt( supplier.StockMoneyFrcProcCd );
            tNedit_StockCnsTaxFrcProcCd.SetInt( supplier.StockCnsTaxFrcProcCd );

            // �A������
            tEdit_SupplierPostNo.Text = supplier.SupplierPostNo;
            tEdit_SupplierAddr1.Text = supplier.SupplierAddr1;
            tEdit_SupplierAddr3.Text = supplier.SupplierAddr3;
            tEdit_SupplierAddr4.Text = supplier.SupplierAddr4;
            tEdit_SupplierTelNo.Text = supplier.SupplierTelNo;
            tEdit_SupplierTelNo1.Text = supplier.SupplierTelNo1;
            tEdit_SupplierTelNo2.Text = supplier.SupplierTelNo2;

            // ���l���
            tEdit_SupplierNote1.Text = supplier.SupplierNote1;
            tEdit_SupplierNote2.Text = supplier.SupplierNote2;
            tEdit_SupplierNote3.Text = supplier.SupplierNote3;
            tEdit_SupplierNote4.Text = supplier.SupplierNote4;

            // UI��\���f�[�^
            _noDispData.SetFromData( supplier );


            // �x������X�V
            if (supplier.SupplierCd != supplier.PayeeCode)
            {
                Supplier payee;
                if (ReadSupplier(supplier.PayeeCode, out payee))
                {
                    SettingPayeeToScreen(payee);
                }

                // --- ADD 2008/12/24 [��QID:9452�Ή�]----------------------------------------------------------->>>>>
                SettingEnableBySuppTtlAmountDispWayCd(payee.SuppTtlAmntDspWayCd);
                SettingEnableBySuppCTaXLayRefCd(payee.SuppCTaxLayRefCd);
                // --- ADD 2008/12/24 [��QID:9452�Ή�]-----------------------------------------------------------<<<<<
            }
            // --- ADD 2008/12/24 [��QID:9452�Ή�]----------------------------------------------------------->>>>>
            else
            {
                SettingEnableBySuppTtlAmountDispWayCd(supplier.SuppTtlAmntDspWayCd);
                SettingEnableBySuppCTaXLayRefCd(supplier.SuppCTaxLayRefCd);
            }
            // --- ADD 2008/12/24 [��QID:9452�Ή�]-----------------------------------------------------------<<<<<

            // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
            tEdit_PaymentSectionCode.Text = supplier.PaymentSectionName;
            // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<

            // �S�̐ݒ�Q�Ƌ敪�n
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            SettingEnableByStckTtlAmntDspWayRef( supplier.StckTtlAmntDspWayRef );
            SettingEnableBySuppTtlAmountDispWayCd( supplier.SuppTtlAmntDspWayCd );
            SettingEnableBySuppCTaXLayRefCd( supplier.SuppCTaxLayRefCd );
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

            # endregion
        }

        /// <summary>
		/// Value�`�F�b�N�����iint�j
		/// </summary>
		/// <param name="sorce">tCombo��Value</param>
		/// <returns>�`�F�b�N��̒l</returns>
		/// <remarks>
		/// <br>Note       : tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private int ValueToInt(object sorce)
		{
			int dest = 0;
			try
			{
				dest = Convert.ToInt32(sorce);
			}
			catch
			{
				return dest;
			}
			return dest;
		}

		/// <summary>
        /// ��ʏ��d����}�X�^ �N���X�i�[����
		/// </summary>
		/// <param name="supplier">�d����}�X�^ �I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʏ�񂩂�d����}�X�^ �I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void DispToSupplier(ref Supplier supplier)
		{
            if ( supplier == null )
            {
                // �V�K�̏ꍇ
                supplier = new Supplier();
            }

            # region [Screen��Supplier]

            // UI��\���f�[�^���Z�b�g
            _noDispData.SetToData( ref supplier );

            // ���O
            supplier.SupplierCd = tNedit_SupplierCd.GetInt();
            supplier.SupplierNm1 = tEdit_SupplierName1.Text;
            supplier.SupplierNm2 = tEdit_SupplierName2.Text;
            supplier.SupplierSnm = tEdit_SupplierSnm.Text;
            supplier.SupplierKana = tEdit_SupplierKana.Text;
            //supplier.SuppHonorificTitle = tComboEditor_SuppHonorificTitle.Text;
            supplier.SuppHonorificTitle = tEdit_SuppHonorificTitle.Text;
            //supplier.OrderHonorificTtl = tComboEditor_OrderHonorificTtl.Text;
            supplier.OrderHonorificTtl = tEdit_OrderHonorificTtl.Text;

            // �ڍ׏��
            supplier.MngSectionName = tEdit_MngSectionNm.Text;
            supplier.StockAgentName = tEdit_StockAgentNm.Text;
            supplier.PureCode = GetValue( tComboEditor_PureCode );
            supplier.SupplierAttributeDiv = GetValue( tComboEditor_SupplierAttributeDiv );
            supplier.BusinessTypeCode = GetValue( tComboEditor_BusinessTypeCode );
            supplier.BusinessTypeName = tComboEditor_BusinessTypeCode.Text;
            supplier.SalesAreaCode = GetValue( tComboEditor_SalesAreaCode );
            supplier.SalesAreaName = tComboEditor_SalesAreaCode.Text;

            // �x�����
            supplier.PaymentSectionName = tEdit_PaymentSectionCode.Text;
            supplier.PayeeCode = tNedit_PayeeCode.GetInt();
            supplier.PayeeName = uLabel_PayeeName1.Text;
            supplier.PayeeName2 = uLabel_PayeeName2.Text;
            supplier.PayeeSnm = uLabel_PayeeSnm.Text;
            supplier.PaymentTotalDay = tNedit_PaymentTotalDay.GetInt();
            supplier.PaymentMonthCode = GetValue( tComboEditor_PaymentMonthCode );
            supplier.PaymentMonthName = tComboEditor_PaymentMonthCode.Text;
            supplier.PaymentDay = tNedit_PaymentDay.GetInt();
            supplier.PaymentCond = GetValue( tComboEditor_PaymentCond );
            supplier.PaymentSight = tNedit_PaymentSight.GetInt();
            supplier.NTimeCalcStDate = tNedit_NTimeCalcStDate.GetInt();
            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
            //supplier.StckTtlAmntDspWayRef = GetValue( tComboEditor_StckTtlAmntDspWayRef );
            //supplier.SuppTtlAmntDspWayCd = GetValue( tComboEditor_SuppTtlAmountDispWayCd );
            supplier.StckTtlAmntDspWayRef = 0;
            supplier.SuppTtlAmntDspWayCd = 0;
            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
            supplier.SuppCTaxLayRefCd = GetValue(tComboEditor_SuppCTaXLayRefCd);
            supplier.SuppCTaxLayCd = GetValue( tComboEditor_SuppTaxLayMethod );
            supplier.SuppCTaxLayMethodNm = tComboEditor_SuppTaxLayMethod.Text;
            supplier.StockUnPrcFrcProcCd = tNedit_StockUnPrcFrcProcCd.GetInt();
            supplier.StockMoneyFrcProcCd = tNedit_StockMoneyFrcProcCd.GetInt();
            supplier.StockCnsTaxFrcProcCd = tNedit_StockCnsTaxFrcProcCd.GetInt();

            // �A������
            supplier.SupplierPostNo = tEdit_SupplierPostNo.Text;
            supplier.SupplierAddr1 = tEdit_SupplierAddr1.Text;
            supplier.SupplierAddr3 = tEdit_SupplierAddr3.Text;
            supplier.SupplierAddr4 = tEdit_SupplierAddr4.Text;
            supplier.SupplierTelNo = tEdit_SupplierTelNo.Text;
            supplier.SupplierTelNo1 = tEdit_SupplierTelNo1.Text;
            supplier.SupplierTelNo2 = tEdit_SupplierTelNo2.Text;

            // ���l���
            supplier.SupplierNote1 = tEdit_SupplierNote1.Text;
            supplier.SupplierNote2 = tEdit_SupplierNote2.Text;
            supplier.SupplierNote3 = tEdit_SupplierNote3.Text;
            supplier.SupplierNote4 = tEdit_SupplierNote4.Text;

            // �ېŋ敪�i�]�ŕ����Ɉˑ��j
            if ( supplier.SuppCTaxLayCd == 9 )
            {
                supplier.SuppCTaxationCd = 1;   // 1:��ې�
            }
            else
            {
                supplier.SuppCTaxationCd = 0;   // 0:�ې�
            }


            # endregion
        }
        /// <summary>
        /// �R���{�G�f�B�^�l�擾����
        /// </summary>
        /// <param name="tComboEditor"></param>
        /// <returns></returns>
        private static int GetValue( TComboEditor tComboEditor )
        {
            try
            {
                return (int)tComboEditor.SelectedItem.DataValue;
            }
            catch
            {
                try
                {
                    return (int)tComboEditor.Items[0].DataValue;
                }
                catch
                {
                    return 0;
                }
            }
        }
        # endregion
        # region [���̓`�F�b�N]
        /// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="loginID">���O�C��ID</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
		{
			bool result = true;

            // �d����R�[�h
            if ( this.tNedit_SupplierCd.GetInt() == 0 )
            {
                control = this.tNedit_SupplierCd;
                message = "�d����R�[�h����͂��ĉ������B";
                result = false;
            }
            // DEL 2009/06/26 ------>>>
            //// �d���於�̂P
            //else if ( this.tEdit_SupplierName1.Text.Trim() == string.Empty )
            //{
            //    control = this.tEdit_SupplierName1;
            //    message = "�d���於����͂��ĉ������B";
            //    result = false;
            //}
            //// �d���旪��
            //else if ( this.tEdit_SupplierSnm.Text.Trim() == string.Empty )
            //{
            //    control = this.tEdit_SupplierSnm;
            //    message = "�d���旪�̂���͂��ĉ������B";
            //    result = false;
            //}
            // DEL 2009/06/26 ------<<<
            // �d����J�i
            else if ( this.tEdit_SupplierKana.Text.Trim() == string.Empty )
            {
                control = this.tEdit_SupplierKana;
                message = "�d���於(��)����͂��ĉ������B";
                result = false;
            }
            else if ( !uiSetControl1.CheckMatchingSet( tEdit_SupplierKana ) )
            {
                control = this.tEdit_SupplierKana;
                message = "�d���於(��)���s���ł��B";
                result = false;
            }
            // �Ǘ����_
            else if ( _noDispData.MngSectionCode == string.Empty )
            {
                control = this.tEdit_MngSectionNm;
                message = "�Ǘ����_����͂��ĉ������B";
                result = false;
            }
            // �d���S����
            else if ( _noDispData.StockAgentCode == string.Empty )
            {
                control = this.tEdit_StockAgentNm;
                message = "�d���S���҂���͂��ĉ������B";
                result = false;
            }
            // �x�����_
            else if ( _noDispData.PaymentSectionCode == string.Empty )
            {
                control = this.tEdit_PaymentSectionCode;
                message = "�x�����_����͂��ĉ������B";
                result = false;
            }
            // �x����
            else if ( this.tNedit_PayeeCode.GetInt() == 0 )
            {
                control = this.tNedit_PayeeCode;
                message = "�x�������͂��ĉ������B";
                result = false;
            }
            // �x������
            else if ( this.tNedit_PaymentTotalDay.GetInt() == 0 )
            {
                control = this.tNedit_PaymentTotalDay;
                message = "�x����������͂��ĉ������B";
                result = false;
            }
            else if ( !uiSetControl1.CheckMatchingSet( tNedit_PaymentTotalDay ) || this.tNedit_PaymentTotalDay.GetInt() > 31 )
            {
                control = this.tNedit_PaymentTotalDay;
                message = "�x���������s���ł��B";
                result = false;
            }
            // �x����
            else if ( this.tNedit_PaymentDay.GetInt() == 0 )
            {
                control = this.tNedit_PaymentDay;
                message = "�x��������͂��ĉ������B";
                result = false;
            }
            else if ( !uiSetControl1.CheckMatchingSet( tNedit_PaymentDay ) || this.tNedit_PaymentDay.GetInt() > 31 )
            {
                control = this.tNedit_PaymentDay;
                message = "�x�������s���ł��B";
                result = false;
            }
            // ���񊨒�J�n��
            else if ( !uiSetControl1.CheckMatchingSet( tNedit_NTimeCalcStDate ) || this.tNedit_NTimeCalcStDate.GetInt() > 31 )
            {
                control = this.tNedit_NTimeCalcStDate;
                message = "���񊨒�J�n�����s���ł��B";
                result = false;
            }
            // �x���T�C�g
            else if ( !uiSetControl1.CheckMatchingSet( tNedit_PaymentSight ) )
            {
                control = this.tNedit_PaymentSight;
                message = "�x���T�C�g���s���ł��B";
                result = false;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            // �P���[�������R�[�h
            else if ( !ExistsStockProcMoney( 2, tNedit_StockUnPrcFrcProcCd.GetInt() ) )
            {
                control = this.tNedit_StockUnPrcFrcProcCd;
                message = "�P���[�������R�[�h���s���ł��B";
                result = false;
            }
            // ���z�[�������R�[�h
            else if ( !ExistsStockProcMoney( 0, tNedit_StockMoneyFrcProcCd.GetInt() ) )
            {
                control = this.tNedit_StockMoneyFrcProcCd;
                message = "���z�[�������R�[�h���s���ł��B";
                result = false;
            }
            // ����Œ[�������R�[�h
            else if ( !ExistsStockProcMoney( 1, tNedit_StockCnsTaxFrcProcCd.GetInt() ) )
            {
                control = this.tNedit_StockCnsTaxFrcProcCd;
                message = "����Œ[�������R�[�h���s���ł��B";
                result = false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD

			return result;
        }
        # endregion

        # region [�r�������֘A]
        /// <summary>
		/// �r�������i���b�Z�[�W�\���̂݁j
		/// </summary>
		/// <param name="operation">�I�y���[�V����</param>
		/// <param name="erObject">�G���[�I�u�W�F�N�g</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
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
        # endregion
        # endregion

        #region ��Control Events
        /// <summary>
		/// Form.Load �C�x���g(PMKHN09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        private void PMKHN09020UA_Load(object sender, System.EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/26 ADD
            // �P�ƋN���̏ꍇ�̏���
            # region [�X���C�_����̒P�ƋN���Ή�]
            if ( _singleExecute )
            {
                // �\���O�̌�������
                int totalCount = 0;
                int readCount = 0;
                this.Search( ref totalCount, readCount );

                // �\������sindex�擾
                this.DataIndex = -1;
                for ( int index = 0; index < _supplierDataTable.Rows.Count; index++ )
                {
                    if ( (int)_supplierDataTable.Rows[index][SUPPLIERCD_TITLE] == _paraSupplierCode )
                    {
                        this.DataIndex = index;
                        break;
                    }
                }

                // �v���p�e�B�ݒ�
                //fm.CanClose = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                // ���Skin�ݒ�
                ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
                _controlScreenSkin.LoadSkin();
                _controlScreenSkin.SettingScreenSkin( this );

            }
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/26 ADD

            //---------------------------------------------
            // �{�^���A�C�R��
            //---------------------------------------------
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

            //---------------------------------------------
            // �K�C�h�{�^��
            //---------------------------------------------
            UltraButton[] guideButtons = new UltraButton[]
                {
                    uButton_OfrSupplierGuide,
                    uButton_MngSectionNmGuide,
                    uButton_StockAgentGuide,
                    uButton_PaymentSectionGuide,
                    uButton_PayeeNameGuide,
                    uButton_SalesUnPrcFrcProcCdGuide,
                    uButton_SalesMoneyFrcProcCdGuide,
                    uButton_SalesCnsTaxFrcProcCdGuide,
                    uButton_AddressGuide,
                    uButton_Note1Guide,
                    uButton_Note2Guide,
                    uButton_Note3Guide,
                    uButton_Note4Guide
                };
            foreach ( UltraButton button in guideButtons )
            {
                button.ImageList = imageList16;
                button.Appearance.Image = Size16_Index.STAR1;
            }
            //---------------------------------------------
            // �^�u�A�C�R��
            //---------------------------------------------
            this.SubInfo_UTabControl.ImageList = imageList16;
            this.SubInfo_UTabControl.Tabs[0].Appearance.Image = (int)Size16_Index.MAIN;
            this.SubInfo_UTabControl.Tabs[1].Appearance.Image = (int)Size16_Index.CUSTOMERNOTE;


			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
        /// Form.Closing �C�x���g(PMKHN09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        private void PMKHN09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
        /// Control.VisibleChanged �C�x���g(PMKHN09020UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        private void PMKHN09020UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (SaveProc() == false)
			{
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

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = true;
                // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

				ScreenInputPermissionControl(INSERT_MODE);

				// �V�K�f�[�^�쐬
                this._supplier = new Supplier();
                // �V�K�f�[�^�������͏���
                SetNewRecordFirstInput( ref this._supplier );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                // ��ʓW�J����
                DataToScreen( this._supplier );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
				DispToSupplier(ref this._supplier);

				this.tNedit_SupplierCd.Focus();
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
		}

		/// <summary>
        /// �d����}�X�^ ���o�^����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
        /// <br>Note       : �d����}�X�^ ���o�^���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private bool SaveProc()
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";

            Supplier supplier = null;

            // �����C���Ȃ�΃L���b�V�����狌�f�[�^����x�擾
            if ( this.DataIndex >= 0 )
            {
                supplier = GetFromCache( _supplierDataTable.Rows[_dataIndex] );
            }

            // ���̓`�F�b�N
            if ( !ScreenDataCheck( ref control, ref message, loginID ) )
            {
                TMsgDisp.Show(
                    this,								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                    ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message,							// �\�����郁�b�Z�[�W 
                    0,									// �X�e�[�^�X�l
                    MessageBoxButtons.OK );				// �\������{�^��

                control.Focus();
                return false;
            }

            // ��ʓ��͂���f�[�^�擾
            this.DispToSupplier( ref supplier );

            // ADD 2009/05/27 ------>>>
            // �q�d�����񂪕Ԃ��Ă���̂Ń��X�g�̕ύX
            ArrayList supplierList = new ArrayList();
            supplierList.Add(supplier);
            // ADD 2009/05/27 ------<<<
            
            // ��������
            //status = this._supplierAcs.Write( ref supplier );     // DEL 2009/05/27
            status = this._supplierAcs.Write(ref supplierList);     // ADD 2009/05/27

            // ���ʕ���
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            MessageBoxButtons.OK );				// �\������{�^��

                        this.tNedit_SupplierCd.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._supplierAcs );

                        if ( UnDisplaying != null )
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                            UnDisplaying( this, me );
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if ( CanClose == true )
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
                            this.Text,							// �v���O��������
                            "SaveProc",							// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._supplierAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1 );	// �����\���{�^��

                        if ( UnDisplaying != null )
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                            UnDisplaying( this, me );
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if ( CanClose == true )
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
            //CopyToDataSet( supplier, this.DataIndex );    // DEL 2009/05/27

            // ADD 2009/05/27 ------>>>
            // �e�̎d�������DataSet�W�J����
            Supplier parentSupplier = supplierList[0] as Supplier;
            CopyToDataSet(parentSupplier, this.DataIndex);

            // �q�̎d�������DataSet�X�V����
            for (int i = 1; i < supplierList.Count; i++)
            {
                Supplier childSupplier = supplierList[i] as Supplier;
                ReflectChildSupplierToDataSet(childSupplier, parentSupplier);
            }
            // ADD 2009/05/27 ------<<<
            
			return true;
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{   
            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
			{
				//�ۑ��m�F
				Supplier compareSupplier = new Supplier();
				compareSupplier = this._supplier.Clone();
                //���݂̉�ʏ����擾����
                DispToSupplier(ref compareSupplier);

				//�ŏ��Ɏ擾������ʏ��Ɣ�r
				if (!(this._supplier.Equals(compareSupplier)))	
				{
					//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					DialogResult res = TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						"",									// �\�����郁�b�Z�[�W 
						0,									// �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel);		// �\������{�^��

					switch(res)
					{
						case DialogResult.Yes:
						{
							if (SaveProc() == false)
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
                            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tNedit_SupplierCd.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
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
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
                ASSEMBLY_ID,											// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
                0,														// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,								// �\������{�^��
                MessageBoxDefaultButton.Button2 );						// �����\���{�^��


            if ( result == DialogResult.OK )
            {
                // �I�����R�[�h�ɑΉ�����f�[�^���擾
                Supplier supplier = GetFromCache( _supplierDataTable.Rows[this._dataIndex] );

                // ���S�폜
                status = this._supplierAcs.Delete( supplier );

                // ���ʕ���
                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // �e�[�u������폜
                            _supplierDataTable.Rows[this._dataIndex].Delete();
                            // �L���b�V������폜
                            DeleteFromCache( supplier );

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction( status, TMsgDisp.OPE_DELETE, this._supplierAcs );

                            if ( UnDisplaying != null )
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                                UnDisplaying( this, me );
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if ( CanClose == true )
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
                                this,								  // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                                ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Text,							  // �v���O��������
                                "Delete_Button_Click",				  // ��������
                                TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
                                ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
                                status,								  // �X�e�[�^�X�l
                                this._supplierAcs,					  // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				  // �\������{�^��
                                MessageBoxDefaultButton.Button1 );	  // �����\���{�^��

                            if ( UnDisplaying != null )
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                                UnDisplaying( this, me );
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if ( CanClose == true )
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
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if ( UnDisplaying != null )
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                UnDisplaying( this, me );
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
		/// Control.Click �C�x���g(Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note �@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �I�����R�[�h�ɑΉ�����f�[�^���擾
            Supplier supplier = GetFromCache( _supplierDataTable.Rows[this._dataIndex] );
            if ( supplier == null ) return;

            // ����
            status = this._supplierAcs.Revival( ref supplier );

            // ���ʕ���
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._supplierAcs );

                        if ( UnDisplaying != null )
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                            UnDisplaying( this, me );
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if ( CanClose == true )
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
                            this,								  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							  // �v���O��������
                            "Revive_Button_Click",				  // ��������
                            TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
                            ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
                            status,								  // �X�e�[�^�X�l
                            this._supplierAcs,					  // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				  // �\������{�^��
                            MessageBoxDefaultButton.Button1 );	  // �����\���{�^��

                        if ( UnDisplaying != null )
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                            UnDisplaying( this, me );
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if ( CanClose == true )
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

            // DataSet�W�J����
            CopyToDataSet( supplier, this.DataIndex );

            if ( UnDisplaying != null )
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                UnDisplaying( this, me );
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
		/// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br>Programmer  : 22018 ��ؐ��b</br>
        /// <br>Date        : 2008.04.30</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		/// TRetKeyControl.ChangeFocus �C�x���g �C�x���g(tRetKeyControl1)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�J�X���J�ڂ���ۂɔ������܂��B</br>
        /// <br>Programmer  : 22018 ��ؐ��b</br>
        /// <br>Date        : 2008.04.30</br>
        /// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            if ( e == null || e.PrevCtrl == null ) return;

            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            
            # region [OnChangeFocus]
            switch ( e.PrevCtrl.Name )
            {
                // �d����R�[�h
                case "tNedit_SupplierCd":
                    {
                        bool status = true;
                        int supplierCode = tNedit_SupplierCd.GetInt();

                        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                        //if ( supplierCode != _noDispData.PrevSupplierCd )
                        //{
                        //    int code;
                        //    string name1;
                        //    string name2;
                        //    string snm;

                        //    if ( supplierCode == 0 )
                        //    {
                        //    }
                        //    else if ( ReadSupplier( supplierCode, out code, out name1, out name2, out snm ) )
                        //    {
                        //        TMsgDisp.Show(
                        //            this,
                        //            emErrorLevel.ERR_LEVEL_INFO,
                        //            this.Name,
                        //            "���͂��ꂽ�R�[�h�̎d�����񂪊��ɓo�^����Ă��܂��B",
                        //            -1,
                        //            MessageBoxButtons.OK );
                        //        e.NextCtrl = e.PrevCtrl;
                        //        tNedit_SupplierCd.SetInt( 0 );
                        //        _noDispData.PrevSupplierCd = 0;
                                
                        //        status = false;
                        //    }
                        //    else
                        //    {
                        //        // �x����R�[�h�i�[
                        //        if ( tNedit_PayeeCode.GetInt() == 0 || tNedit_PayeeCode.GetInt() == supplierCode )
                        //        {
                        //            tNedit_PayeeCode.SetInt( supplierCode );
                        //            _noDispData.PrevSupplierCd = supplierCode;
                        //        }

                        //        // �񋟎d����ǂݍ���
                        //        OfrSupplier ofrSupplier;
                        //        if ( _ofrSupplierAcs.Read( out ofrSupplier, supplierCode ) == 0 )
                        //        {
                        //            // ���e�Z�b�g
                        //            tNedit_SupplierCd.SetInt( ofrSupplier.SupplierCd );
                        //            tEdit_SupplierName1.Text = ofrSupplier.SupplierNm1;
                        //            tEdit_SupplierSnm.Text = ofrSupplier.SupplierSnm;
                        //            tEdit_SupplierKana.Text = ofrSupplier.SupplierKana;

                        //            // �x����ɂ��R�s�[
                        //            # region [�x����]
                        //            tNedit_PayeeCode.SetInt( ofrSupplier.SupplierCd );
                        //            uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                        //            uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                        //            uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                        //            _noDispData.PrevPayeeCode = ofrSupplier.SupplierCd;

                        //            SettingScreenEnableForChild( false );

                        //            // �S�̐ݒ�͎x�����_�ˑ�
                        //            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                        //            //SettingEnableByStckTtlAmntDspWayRef((int)tComboEditor_StckTtlAmntDspWayRef.Value);
                        //            //SettingEnableBySuppTtlAmountDispWayCd((int)tComboEditor_SuppTtlAmountDispWayCd.Value);
                        //            SettingEnableBySuppTtlAmountDispWayCd(0);
                        //            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                        //            SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                        //            # endregion
                        //        }
                        //    }
                        //}
                        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                        
                        if ( status )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if ( supplierCode == 0 )
                                            {
                                                e.NextCtrl = uButton_OfrSupplierGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_SupplierName1;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // �J�ڐ悪����{�^��
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tNedit_SupplierCd;
                            }
                            else
                            {
                                // �񋟎d����ǂݍ���
                                OfrSupplier ofrSupplier;
                                if (_ofrSupplierAcs.Read(out ofrSupplier, supplierCode) == 0)
                                {
                                    // ���e�Z�b�g
                                    tNedit_SupplierCd.SetInt(ofrSupplier.SupplierCd);
                                    tEdit_SupplierName1.Text = ofrSupplier.SupplierNm1;
                                    tEdit_SupplierSnm.Text = ofrSupplier.SupplierSnm;
                                    tEdit_SupplierKana.Text = ofrSupplier.SupplierKana;

                                    // �x����ɂ��R�s�[
                                    # region [�x����]
                                    tNedit_PayeeCode.SetInt(ofrSupplier.SupplierCd);
                                    uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                                    uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                                    uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                                    _noDispData.PrevPayeeCode = ofrSupplier.SupplierCd;

                                    SettingScreenEnableForChild(false);

                                    // �S�̐ݒ�͎x�����_�ˑ�
                                    SettingEnableBySuppTtlAmountDispWayCd(0);
                                    SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                                    # endregion
                                }
                            }
                        }
                        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
                    }
                    break;
                // �d���於�̂P
                case "tEdit_SupplierName1":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        if ( tNedit_SupplierCd.Enabled )
                                        {
                                            e.NextCtrl = tNedit_SupplierCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                            }
                        }

                        //tNedit_SupplierCd
                    }
                    break;
                // �h��
                case "tComboEditor_SuppHonorificTitle":
                    {
                        //string inputText = tComboEditor_SuppHonorificTitle.Text;
                        //// �R���{�G�f�B�^�A�C�e���I��
                        //if ( SelectComboEdit( tComboEditor_SuppHonorificTitle, inputText ) )
                        //{
                        //}
                        //else
                        //{
                        //    // �Y���Ȃ���Β��ړ��͂Ƃ݂Ȃ�
                        //    tComboEditor_SuppHonorificTitle.SelectedIndex = -1;
                        //    tComboEditor_SuppHonorificTitle.Text = inputText;
                        //}
                    }
                    break;
                // �������h��
                case "tComboEditor_OrderHonorificTtl":
                    {
                        //string inputText = tComboEditor_OrderHonorificTtl.Text;
                        //// �R���{�G�f�B�^�A�C�e���I��
                        //if ( SelectComboEdit( tComboEditor_OrderHonorificTtl, inputText ) )
                        //{
                        //}
                        //else
                        //{
                        //    // �Y���Ȃ���Β��ړ��͂Ƃ݂Ȃ�
                        //    tComboEditor_OrderHonorificTtl.SelectedIndex = -1;
                        //    tComboEditor_OrderHonorificTtl.Text = inputText;
                        //}
                    }
                    break;
                // �Ǘ����_�R�[�h
                case "tEdit_MngSectionNm":
                    {
                        bool status;

                        if ( tEdit_MngSectionNm.Text == _noDispData.PrevMngSectionName )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            string msgSectionCode = this.GetInputCode( tEdit_MngSectionNm );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // ���_�ǂݍ���
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                            //status = ReadSection( tEdit_MngSectionNm.Text, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            status = ReadSection( msgSectionCode, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // �R�[�h�E���̂��X�V
                            _noDispData.MngSectionCode = code;
                            _noDispData.PrevMngSectionName = name;
                            tEdit_MngSectionNm.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl����
                                switch ( e.Key )
                                {
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = tEdit_SuppHonorificTitle;
                                            break;
                                        }
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _noDispData.MngSectionCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_MngSectionNmGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_StockAgentNm;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                // �Ǘ����_�{�^��
                case "uButton_MngSectionNmGuide":
                    {
                        // NextCtrl����
                        switch ( e.Key )
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = tEdit_SuppHonorificTitle;
                                    break;
                                }
                        }
                    }
                    break;
                // �d���S���҃R�[�h
                case "tEdit_StockAgentNm":
                    {
                        bool status;

                        if ( tEdit_StockAgentNm.Text == _noDispData.PrevStockAgentName )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            // ���̓R�[�h�擾
                            string stockAgentCode = GetInputCode( tEdit_StockAgentNm );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // �]�ƈ��ǂݍ���
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                            //status = ReadEmployee( tEdit_StockAgentNm.Text, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            status = ReadEmployee( stockAgentCode, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // �R�[�h�E���̂��X�V
                            _noDispData.StockAgentCode = code;
                            _noDispData.PrevStockAgentName = name;
                            tEdit_StockAgentNm.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl����
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _noDispData.StockAgentCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_StockAgentGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_PureCode;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                    }
                    break;
                // �d���S���҃K�C�h�{�^��
                case "uButton_StockAgentGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tComboEditor_PureCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �����敪
                case "tComboEditor_PureCode":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_PureCode, tComboEditor_PureCode.Text );
                    }
                    break;
                // �d���摮��
                case "tComboEditor_SupplierAttributeDiv":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_SupplierAttributeDiv, tComboEditor_SupplierAttributeDiv.Text );
                    }
                    break;
                // �Ǝ�
                case "tComboEditor_BusinessTypeCode":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_BusinessTypeCode, tComboEditor_BusinessTypeCode.Text );
                    }
                    break;
                // �̔��G���A
                case "tComboEditor_SalesAreaCode":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_SalesAreaCode, tComboEditor_SalesAreaCode.Text );
                    }
                    break;
                // �x�����_�R�[�h
                case "tEdit_PaymentSectionCode":
                    {
                        bool status;

                        if ( tEdit_PaymentSectionCode.Text == _noDispData.PrevPaymentSectionName )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            // ���̓R�[�h�擾
                            string paymentSectionCode = GetInputCode( tEdit_PaymentSectionCode );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // ���_�ǂݍ���
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                            //status = ReadSection( tEdit_PaymentSectionCode.Text, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            status = ReadSection( paymentSectionCode, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // �R�[�h�E���̂��X�V
                            _noDispData.PaymentSectionCode = code;
                            _noDispData.PrevPaymentSectionName = name;
                            tEdit_PaymentSectionCode.Text = name;

                            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                            // �S�̐ݒ�͎x�����_�ˑ�
                            SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl����
                                switch ( e.Key )
                                {
                                    case Keys.Down:
                                        {
                                            e.NextCtrl = tNedit_PayeeCode;
                                            break;
                                        }
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _noDispData.PaymentSectionCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_PaymentSectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_PayeeCode;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                // �x�����_�K�C�h�{�^��
                case "uButton_PaymentSectionGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_PayeeCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �x����R�[�h
                case "tNedit_PayeeCode":
                    {
                        bool status;

                        int payeeCode = tNedit_PayeeCode.GetInt();
                        if ( payeeCode == _noDispData.PrevPayeeCode )
                        {
                            status = true;
                        }
                        else
                        {
                            // �d���恁�x����̏ꍇ
                            if ( payeeCode == tNedit_SupplierCd.GetInt() )
                            {
                                tNedit_PayeeCode.SetInt( payeeCode );
                                uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                                uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                                uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                                _noDispData.PrevPayeeCode = payeeCode;

                                status = true;

                                SettingScreenEnableForChild( false );

                                // �S�̐ݒ�͎x�����_�ˑ�
                                // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                                //SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                                //SettingEnableBySuppTtlAmountDispWayCd((int)tComboEditor_SuppTtlAmountDispWayCd.Value);
                                SettingEnableBySuppTtlAmountDispWayCd(0);
                                // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                                SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                            }
                            else
                            {
                                // �x����ǂݍ���
                                Supplier payee;
                                bool bStatus = ReadSupplier( payeeCode, out payee );
                                if (bStatus)
                                {
                                    _noDispData.PrevPayeeCode = payee.SupplierCd;

                                    // ��ʂɕ\��
                                    status = SettingPayeeToScreen(payee);
                                }
                                // --- ADD 2009/01/20 ��QID:9164�Ή�------------------------------------------------------>>>>>
                                else
                                {
                                    payeeCode = this.tNedit_SupplierCd.GetInt();
                                    tNedit_PayeeCode.SetInt(payeeCode);
                                    uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                                    uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                                    uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                                    _noDispData.PrevPayeeCode = payeeCode;

                                    status = true;

                                    SettingScreenEnableForChild(false);

                                    // �S�̐ݒ�͎x�����_�ˑ�
                                    SettingEnableBySuppTtlAmountDispWayCd(0);
                                    SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                                }
                                // --- ADD 2009/01/20 ��QID:9164�Ή�------------------------------------------------------<<<<<
                            }
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl����
                                switch ( e.Key )
                                {
                                    case Keys.Down:
                                        {
                                            if ( tNedit_PaymentTotalDay.Enabled == false )
                                            {
                                                e.NextCtrl = tEdit_SupplierTelNo;
                                            }
                                            break;
                                        }
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _noDispData.PrevPayeeCode == 0 )
                                            {
                                                e.NextCtrl = this.uButton_PayeeNameGuide;
                                            }
                                            else
                                            {
                                                if ( tNedit_PaymentTotalDay.Enabled )
                                                {
                                                    e.NextCtrl = this.tNedit_PaymentTotalDay;
                                                }
                                                else
                                                {
                                                    if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                                    {
                                                        e.NextCtrl = tEdit_SupplierPostNo;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = tEdit_SupplierNote1;
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }

                    }
                    break;
                // �x����K�C�h�{�^��
                case "uButton_PayeeNameGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Right:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if ( tNedit_PaymentTotalDay.Enabled )
                                        {
                                            e.NextCtrl = tNedit_PaymentTotalDay;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_SupplierTelNo;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( tNedit_PaymentTotalDay.Enabled )
                                        {
                                            e.NextCtrl = tNedit_PaymentTotalDay;
                                        }
                                        else
                                        {
                                            if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                            {
                                                e.NextCtrl = tEdit_SupplierPostNo;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_SupplierNote1;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // ����
                case "tNedit_PaymentTotalDay":
                    {
                        int date = tNedit_PaymentTotalDay.GetInt();
                        if ( date < 1 ) tNedit_PaymentTotalDay.SetInt( 1 );
                        if ( date >= 28 ) tNedit_PaymentTotalDay.SetInt( 31 );
                    }
                    break;
                // �x�����敪
                case "tComboEditor_PaymentMonthCode":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_PaymentMonthCode, tComboEditor_PaymentMonthCode.Text );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tNedit_PayeeCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �x����
                case "tNedit_PaymentDay":
                    {
                        int date = tNedit_PaymentDay.GetInt();
                        if ( date < 1 ) tNedit_PaymentDay.SetInt( 1 );
                        if ( date >= 28 ) tNedit_PaymentDay.SetInt( 31 );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tNedit_PayeeCode;
                                    }
                                    break;
                                case Keys.Right:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_PaymentSight;
                                    }
                                    break;
                            }
                        }
                        
                    }
                    break;
                // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
                // �x������
                case "tComboEditor_PaymentCond":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tNedit_PaymentTotalDay;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<
                // �x���T�C�g
                case "tNedit_PaymentSight":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_NTimeCalcStDate;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // ���񊨒�J�n��
                case "tNedit_NTimeCalcStDate":
                    {
                        int date = tNedit_NTimeCalcStDate.GetInt();
                        //if ( date < 1 ) tNedit_NTimeCalcStDate.SetInt( 1 );
                        // --- CHG 2009/01/29 ��QID:10723�Ή�------------------------------------------------------>>>>>
                        //if ( date >= 28 ) tNedit_NTimeCalcStDate.SetInt( 31 );
                        if (date > 31)
                        {
                            DialogResult res = TMsgDisp.Show(this,								
                                                             emErrorLevel.ERR_LEVEL_EXCLAMATION,	
                                                             ASSEMBLY_ID,						
                                                             "���񊨒�� 1�`31 �͈̔͂œ��͂��Ă��������B",									
                                                             0,									
                                                             MessageBoxButtons.OK);
                            e.NextCtrl = tNedit_NTimeCalcStDate;
                        }
                        // --- CHG 2009/01/29 ��QID:10723�Ή�------------------------------------------------------<<<<<
                    }
                    break;
                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                // ���z�\���Q��
                case "tComboEditor_StckTtlAmntDspWayRef":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_StckTtlAmntDspWayRef, tComboEditor_StckTtlAmntDspWayRef.Text );
                        SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Right:
                                    {
                                        if ( tComboEditor_SuppTtlAmountDispWayCd.Enabled == false )
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if ( tComboEditor_SuppCTaXLayRefCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( tComboEditor_SuppTtlAmountDispWayCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppTtlAmountDispWayCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // ���z�\�����@
                case "tComboEditor_SuppTtlAmountDispWayCd":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_SuppTtlAmountDispWayCd, tComboEditor_SuppTtlAmountDispWayCd.Text );
                        SettingEnableBySuppTtlAmountDispWayCd( (int)tComboEditor_SuppTtlAmountDispWayCd.Value );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tNedit_NTimeCalcStDate;
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if ( tComboEditor_SuppTaxLayMethod.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppTaxLayMethod;
                                        }
                                        else if (tComboEditor_SuppCTaXLayRefCd.Enabled)
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( tComboEditor_SuppCTaXLayRefCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                // �]�ŕ����Q��
                case "tComboEditor_SuppCTaXLayRefCd":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_SuppCTaXLayRefCd, tComboEditor_SuppCTaXLayRefCd.Text );
                        SettingEnableBySuppCTaXLayRefCd( (int)tComboEditor_SuppCTaXLayRefCd.Value );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Right:
                                    {
                                        if ( tComboEditor_SuppTaxLayMethod.Enabled == false )
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (tComboEditor_SuppTaxLayMethod.Enabled)
                                        {
                                            e.NextCtrl = tComboEditor_SuppTaxLayMethod;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �]�ŕ���
                case "tComboEditor_SuppTaxLayMethod":
                    {
                        // �R���{�I��
                        SelectComboEdit( tComboEditor_SuppTaxLayMethod, tComboEditor_SuppTaxLayMethod.Text );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                        if ( tComboEditor_SuppTtlAmountDispWayCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppTtlAmountDispWayCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tComboEditor_StckTtlAmntDspWayRef;
                                        }
                                           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �d���P���[������
                case "tNedit_StockUnPrcFrcProcCd":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                        //if ( ExistsStockProcMoney( 1, tNedit_StockUnPrcFrcProcCd.GetInt() ) )
                        //{
                        //}
                        //else
                        //{
                        //    tNedit_StockUnPrcFrcProcCd.SetInt( 0 );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                        if ( tNedit_StockUnPrcFrcProcCd.GetInt() == 0 )
                        {
                            tNedit_StockUnPrcFrcProcCd.DataText = string.Format( "{0}", 0 );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �t�H�[�J�X
                                        if ( tNedit_StockUnPrcFrcProcCd.Text != string.Empty )
                                        {
                                            e.NextCtrl = tNedit_StockMoneyFrcProcCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_SalesUnPrcFrcProcCdGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �d���P���[�������K�C�h�{�^��
                case "uButton_SalesUnPrcFrcProcCdGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        if ( tComboEditor_SuppCTaXLayRefCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                        else if ( tComboEditor_StckTtlAmntDspWayRef.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_StckTtlAmntDspWayRef;
                                        }
                                           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                        else
                                        {
                                            e.NextCtrl = tNedit_PayeeCode;
                                        }
                                    }
                                    break;
                                case Keys.Right:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �d�����z�[������
                case "tNedit_StockMoneyFrcProcCd":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                        //if ( ExistsStockProcMoney( 0, tNedit_StockMoneyFrcProcCd.GetInt() ) )
                        //{
                        //}
                        //else
                        //{
                        //    tNedit_StockMoneyFrcProcCd.SetInt( 0 );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                        if ( tNedit_StockMoneyFrcProcCd.GetInt() == 0 )
                        {
                            tNedit_StockMoneyFrcProcCd.DataText = string.Format( "{0}", 0 );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �t�H�[�J�X
                                        if ( tNedit_StockMoneyFrcProcCd.Text != string.Empty )
                                        {
                                            e.NextCtrl = tNedit_StockCnsTaxFrcProcCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_SalesMoneyFrcProcCdGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �d������Œ[������
                case "tNedit_StockCnsTaxFrcProcCd":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                        //if ( ExistsStockProcMoney( 0, tNedit_StockCnsTaxFrcProcCd.GetInt() ) )
                        //{
                        //}
                        //else
                        //{
                        //    tNedit_StockCnsTaxFrcProcCd.SetInt( 0 );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                        if ( tNedit_StockCnsTaxFrcProcCd.GetInt() == 0 )
                        {
                            tNedit_StockCnsTaxFrcProcCd.DataText = string.Format( "{0}", 0 );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                        {
                                            e.NextCtrl = tEdit_SupplierTelNo;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_SupplierNote1;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // �t�H�[�J�X
                                        if ( tNedit_StockCnsTaxFrcProcCd.Text != string.Empty )
                                        {
                                            if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                            {
                                                e.NextCtrl = tEdit_SupplierPostNo;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_SupplierNote1;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_SalesCnsTaxFrcProcCdGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �d������Œ[�������K�C�h�{�^��
                case "uButton_SalesCnsTaxFrcProcCdGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                        {
                                            e.NextCtrl = tEdit_SupplierTelNo;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_SupplierNote1;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                        {
                                            e.NextCtrl = tEdit_SupplierPostNo;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_SupplierNote1;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �X�֔ԍ�
                case "tEdit_SupplierPostNo":
                    {
                        if ( tEdit_SupplierPostNo.Text != _noDispData.PrevPostNo )
                        {
                            ReadAddress( tEdit_SupplierPostNo.Text );
                        }
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tComboEditor_SalesAreaCode;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( tEdit_SupplierPostNo.Text != string.Empty )
                                        {
                                            // �t�H�[�J�X
                                            e.NextCtrl = tEdit_SupplierAddr1;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        if ( uButton_SalesCnsTaxFrcProcCdGuide.Enabled )
                                        {
                                            e.NextCtrl = uButton_SalesCnsTaxFrcProcCdGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_PayeeNameGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �X�֔ԍ��K�C�h
                case "uButton_AddressGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tComboEditor_SalesAreaCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �Z���P
                case "tEdit_SupplierAddr1":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tEdit_SupplierPostNo;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �d�b�ԍ��P
                case "tEdit_SupplierTelNo":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        if ( tNedit_StockCnsTaxFrcProcCd.Enabled )
                                        {
                                            e.NextCtrl = tNedit_StockCnsTaxFrcProcCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_PayeeCode;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // �e�`�w�ԍ�
                case "tEdit_SupplierTelNo2":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                //case Keys.Down:
                                //    {
                                //        e.NextCtrl = Ok_Button;
                                //    }
                                //    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        SubInfo_UTabControl.SelectedTab = SubInfo_UTabControl.Tabs[1];
                                        e.NextCtrl = tEdit_SupplierNote1;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // ���l�P
                case "tEdit_SupplierNote1":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tComboEditor_SalesAreaCode;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        SubInfo_UTabControl.SelectedTab = SubInfo_UTabControl.Tabs[0];
                                        e.NextCtrl = tEdit_SupplierTelNo2;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // ���l�S
                case "tEdit_SupplierNote4":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                //case Keys.Down:
                                //    {
                                //        e.NextCtrl = Ok_Button;
                                //    }
                                //    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                // ���̑�
                default:
                    {
                    }
                    break;
            }
            # endregion
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
        /// <summary>
        /// �����񍀖ڂ̃R�[�h�ϊ�����(��ۋl�ߑΉ�)
        /// </summary>
        /// <param name="targetEdit"></param>
        /// <returns></returns>
        private string GetInputCode( TEdit targetEdit )
        {
            UiSet uiset;
            if ( uiSetControl1.ReadUISet( out uiset, targetEdit.Name ) == 0 )
            {
                // �ݒ�Ɋ�Â��[���l��
                // �i�{�����̏�����s�v�ɂ���ׂ̃R���|�[�l���g�����A���͕���������Ȃ̂Ŏ蓮�Ή�����j

                return targetEdit.Text.TrimEnd().PadLeft( uiset.Column, '0' );
            }
            else
            {
                // �ݒ���擾�ł��Ȃ������ꍇ�͂��̂܂ܕԂ��B
                return targetEdit.Text.TrimEnd();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

        /// <summary>
        /// ����Value�ύX�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_Name_ValueChanged( object sender, System.EventArgs e )
        {
            if ( !(sender is TEdit) )
            {
                return;
            }

            if ( ((TEdit)sender).Modified == false )
            {
                return;
            }

            if ( ((TEdit)sender) == this.tEdit_SupplierName1 )
            {
                if ( ((TEdit)sender).Text == "" )
                {
                    this.tEdit_SupplierKana.Clear();
                }
            }

            if ( (TEdit)sender != tEdit_SupplierSnm )
            {
                // ���̂̓��͕⏕�Ή�
                if ( _noDispData.PrevSupplierName.Length < this.tEdit_SupplierName1.DataText.Length )
                {
                    if ( this.tEdit_SupplierName1.DataText.StartsWith( _noDispData.PrevSupplierName ) )
                    {
                        this.tEdit_SupplierSnm.DataText += this.tEdit_SupplierName1.DataText.Substring( _noDispData.PrevSupplierName.Length );
                    }
                }
                _noDispData.PrevSupplierName = this.tEdit_SupplierName1.DataText;
                if ( this.tEdit_SupplierName1.Text == string.Empty )
                {
                    this.tEdit_SupplierSnm.DataText = string.Empty;
                }
                // ���̕␳
                this.tEdit_SupplierSnm.DataText = this.tEdit_SupplierSnm.DataText.Substring( 0, Math.Min( tEdit_SupplierSnm.ExtEdit.Column, tEdit_SupplierSnm.Text.Length ) );
            }

            // �x���恁�d����Ȃ�΁A�x���於�̗������A���ōX�V����
            if ( this.tNedit_SupplierCd.GetInt() == this.tNedit_PayeeCode.GetInt())
            {
                this.uLabel_PayeeName1.Text = this.tEdit_SupplierName1.DataText;
                this.uLabel_PayeeName2.Text = this.tEdit_SupplierName2.DataText;
                this.uLabel_PayeeSnm.Text = this.tEdit_SupplierSnm.DataText;
            }
        }

        # region [���[�U�[�K�C�h�֘A]
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�{�f�B�����X�g�擾����
        /// </summary>
        /// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
        private int GetUserGdBdListToStatic()
        {
            if ( _userGdBdListStc != null )
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            
            _userGdBdListStc = new List<UserGdBd>();

            ArrayList userGdBdList = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                // ���[�U�[�K�C�h�i�w�b�_�j���S���������i�_���폜�����j
                if ( _userGuideAcs == null )
                {
                    _userGuideAcs = new UserGuideAcs();
                }
                status = this._userGuideAcs.SearchBody( out userGdBdList, this._enterpriseCode, UserGuideAcsData.MergeBodyData );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    _userGdBdListStc.AddRange( (UserGdBd[])userGdBdList.ToArray( typeof( UserGdBd ) ) );
                }
            }
            catch ( Exception e )
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.ToString(),
                    "���[�U�[�K�C�h�i�w�b�_�j���̎擾�Ɏ��s���܂����B" + "\r\n" + e.Message,
                    -1,
                    MessageBoxButtons.OK );

                status = -1;
            }


            return status;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^���X�g�擾����
        /// </summary>
        /// <param name="guideDivCode">���[�U�[�K�C�h�敪</param>
        /// <param name="retList">�߂�l���X�g</param>
        /// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
        private int GetDivCodeBodyList( int guideDivCode, out ArrayList retList )
        {
            if ( _userGdBdListStc == null )
            {
                // ���[�U�[�K�C�h�}�X�^�{�f�B�����X�g�擾����
                this.GetUserGdBdListToStatic();
            }

            retList = new ArrayList();

            foreach ( UserGdBd ugb in _userGdBdListStc )
            {
                if (( ugb.UserGuideDivCd == guideDivCode ) && (ugb.LogicalDeleteCode == 0))
                {
                    ComboEditorItemSupplier comboEditorItem = new ComboEditorItemSupplier( ugb.GuideCode, ugb.GuideName );
                    retList.Add( comboEditorItem );
                }
            }

            if ( retList.Count > 0 )
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        # region [�R���{�G�f�B�^�A�C�e���N���X]
        private class ComboEditorItemSupplier : IComparable
        {
            # region [private �t�B�[���h]
            /// <summary>�R�[�h</summary>
            private int _code = 0;
            /// <summary>����</summary>
            private string _name = "";
            # endregion

            # region [public �v���p�e�B]
            /// <summary>
            /// �R�[�h�@�v���p�e�B
            /// </summary>
            public int Code
            {
                get { return this._code; }
                set { this._code = value; }
            }
            /// <summary>
            /// ���́@�v���p�e�B
            /// </summary>
            public string Name
            {
                get { return this._name; }
                set { this._name = value; }
            }
            # endregion

            # region [�R���X�g���N�^]
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public ComboEditorItemSupplier()
            {
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="code"></param>
            /// <param name="name"></param>
            public ComboEditorItemSupplier( int code, string name )
            {
                this._code = code;
                this._name = name;
            }
            # endregion

            # region [Comparable]
            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public int CompareTo( object obj )
            {
                if ( obj == null ) return 1;

                ComboEditorItemSupplier comboEditorItemCustomer = obj as ComboEditorItemSupplier;
                if ( comboEditorItemCustomer == null ) return 1;

                return this.Code.CompareTo( comboEditorItemCustomer.Code );
            }
            # endregion
        }
        # endregion

        # endregion

        # region [ChangeFocus���ǂݍ��ݏ���]
        /// <summary>
        /// �R���{�G�f�B�b�g�I������
        /// </summary>
        /// <param name="tComboEditor"></param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        private bool SelectComboEdit( TComboEditor tComboEditor, string inputText )
        {
            // �\��Text�ŒT��
            for ( int index = 0; index < tComboEditor.Items.Count; index++ )
            {
                if ( tComboEditor.Items[index].DisplayText.Trim() == inputText.Trim() )
                {
                    // �I������
                    tComboEditor.SelectedIndex = index;
                    return true;
                }
            }

            // ������΃A�C�e���ԍ��Ƃ݂Ȃ��ĒT��
            int inputIndex = ToInt( inputText );
            if ( 0 < inputIndex && inputIndex <= tComboEditor.Items.Count )
            {
                tComboEditor.SelectedIndex = inputIndex - 1;
                return true;
            }

            // ����ł��Ȃ���΍ŏ��̃A�C�e�����f�t�H���g�\������(�A������=false�ɂ���)
            if ( tComboEditor.Items.Count > 0 )
            {
                tComboEditor.SelectedIndex = 0;
            }
            else
            {
                // �A�C�e�����P���Ȃ���΋󔒂ɖ߂�
                tComboEditor.Text = string.Empty;
            }

            return false;
        }
        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// �Ǘ����_�ǂݍ���
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="code">(�o��)�R�[�h</param>
        /// <param name="name">(�o��)����</param>
        /// <returns>���͌�t�H�[�J�X�ړ�����</returns>
        private bool ReadSection( string sectionCode, out string code, out string name )
        {
            bool result = false;

            // �����͔���
            if ( sectionCode != string.Empty )
            {
                // �ǂݍ���
                if ( _secInfoSetAcs == null )
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, sectionCode );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //if ( status == 0 && secInfoSet != null )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                if ( status == 0 && secInfoSet != null && secInfoSet.LogicalDeleteCode == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                {
                    // �Y�����聨�\��
                    code = secInfoSet.SectionCode;
                    name = secInfoSet.SectionGuideNm;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// �d���S���ғǂݍ���
        /// </summary>
        /// <param name="employeeCode">�S���҃R�[�h</param>
        /// <param name="code">(�o��)�R�[�h</param>
        /// <param name="name">(�o��)����</param>
        /// <returns></returns>
        private bool ReadEmployee( string employeeCode, out string code, out string name )
        {
            bool result = false;

            // �����͔���
            if ( employeeCode != string.Empty )
            {
                // �ǂݍ���
                if ( _employeeAcs == null )
                {
                    _employeeAcs = new EmployeeAcs();
                }
                Employee employee;
                int status = _employeeAcs.Read( out employee, this._enterpriseCode, employeeCode );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //if ( status == 0 && employee != null )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                if ( status == 0 && employee != null && employee.LogicalDeleteCode == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                {
                    // �Y�����聨�\��
                    code = employee.EmployeeCode;
                    name = employee.Name;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        /// <summary>
        /// �d����ǂݍ���
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="code">(�o��)�R�[�h</param>
        /// <param name="name1">(�o��)����1</param>
        /// <param name="name2">(�o��)����2</param>
        /// <param name="snm">(�o��)����</param>
        /// <returns>���͌�t�H�[�J�X�ړ�����</returns>
        private bool ReadSupplier( int supplierCode, out int code, out string name1, out string name2, out string snm )
        {
            bool result = false;

            // �����͔���
            if ( supplierCode != 0 )
            {
                // �ǂݍ���
                Supplier supplier;
                int status = _supplierAcs.Read( out supplier, this._enterpriseCode, supplierCode );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //if ( status == 0 && supplier != null )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 2008.11.21 modify start [8199]
                // �_���폜�敪�Ŏg�p���Ă���̂�0=�L��, 1=�_���폜�̂�(2,9�͊��Ă̕K�v�Ȃ�)
                //if (status == 0 && supplier != null && supplier.LogicalDeleteCode == 0 )
                if ( status == 0 && supplier != null && (supplier.LogicalDeleteCode == 0 || supplier.LogicalDeleteCode == 1))
                // 2008.11.21 modify end [8199]
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                {
                    // �Y�����聨�\��
                    code = supplier.SupplierCd;
                    name1 = supplier.SupplierNm1;
                    name2 = supplier.SupplierNm2;
                    snm = supplier.SupplierSnm;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = 0;
                    name1 = string.Empty;
                    name2 = string.Empty;
                    snm = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = 0;
                name1 = string.Empty;
                name2 = string.Empty;
                snm = string.Empty;

                result = true;
            }

            return result;
        }
        /// <summary>
        /// �d����ǂݍ���
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="supplier">�d����</param>
        /// <returns>���͌�t�H�[�J�X�ړ�����</returns>
        private bool ReadSupplier( int supplierCode, out Supplier supplier )
        {
            bool result = false;

            // �����͔���
            if ( supplierCode != 0 )
            {
                // �ǂݍ���
                int status = _supplierAcs.Read( out supplier, this._enterpriseCode, supplierCode );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //if ( status == 0 && supplier != null )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                if ( status == 0 && supplier != null && supplier.LogicalDeleteCode == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                {
                    // �Y�����聨�\��

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    supplier = new Supplier();

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                supplier = new Supplier();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// �d�����z�[���������݃`�F�b�N
        /// </summary>
        /// <param name="fracProcMoneyDiv"></param>
        /// <param name="fractionProcCode"></param>
        /// <returns></returns>
        private bool ExistsStockProcMoney( int fracProcMoneyDiv, int fractionProcCode )
        {
            if ( _stockProcMoneyCdList == null )
            {
                _stockProcMoneyCdList = new List<StockProcMoneyKey>();

                ArrayList stockProcMoneyList;
                if ( _stockProcMoneyAcs == null )
                {
                    _stockProcMoneyAcs = new StockProcMoneyAcs();
                }
                this._stockProcMoneyAcs.Search( out stockProcMoneyList, this._enterpriseCode );
                foreach ( object obj in stockProcMoneyList )
                {
                    if ( obj is StockProcMoney )
                    {
                        StockProcMoney stockProcMoney = (obj as StockProcMoney);
                        _stockProcMoneyCdList.Add( new StockProcMoneyKey( stockProcMoney.FracProcMoneyDiv, stockProcMoney.FractionProcCode ) );
                    }
                }
            }

            return _stockProcMoneyCdList.Contains( new StockProcMoneyKey( fracProcMoneyDiv, fractionProcCode ) );
        }
        /// <summary>
        /// �Z������
        /// </summary>
        /// <param name="postNo"></param>
        private void ReadAddress( string postNo )
        {
            AddressGuideResult agResult;
            int status = GetAddressFromPostNo( postNo, out agResult );
            if ( status == 0 )
            {
                // �X�֔ԍ�
                tEdit_SupplierPostNo.Text = agResult.PostNo.TrimEnd();
                _noDispData.PrevPostNo = agResult.PostNo.TrimEnd();

                // �Z�����̕�������
                string address1;
                string address2;
                DivisionAddressName( 30, agResult.AddressName, out address1, out address2 );
                tEdit_SupplierAddr1.Text = address1.TrimEnd();
                tEdit_SupplierAddr3.Text = address2.TrimEnd();

                // �t�H�[�J�X
                tEdit_SupplierAddr1.Focus();
            }
        }

        # endregion
        # endregion

        # region �K�C�h����
        /// <summary>
        /// ���_�K�C�h�{�^���@�N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_MngSectionNmGuide_Click( object sender, EventArgs e )
        {
            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out secInfoSet );

            if ( status == 0 && secInfoSet != null )
            {
                if ( sender == uButton_MngSectionNmGuide )
                {
                    // �Ǘ����_���Z�b�g
                    _noDispData.MngSectionCode = secInfoSet.SectionCode;
                    _noDispData.PrevMngSectionName = secInfoSet.SectionGuideNm;
                    tEdit_MngSectionNm.Text = secInfoSet.SectionGuideNm;

                    // �t�H�[�J�X
                    tEdit_StockAgentNm.Focus();
                }
                else if ( sender == uButton_PaymentSectionGuide )
                {
                    // �x�����_���Z�b�g
                    _noDispData.PaymentSectionCode = secInfoSet.SectionCode;
                    _noDispData.PrevPaymentSectionName = secInfoSet.SectionGuideNm;
                    tEdit_PaymentSectionCode.Text = secInfoSet.SectionGuideNm;

                    /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                    // �x�����_���ς������S�̐ݒ���ς��
                    SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                       --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

                    // �t�H�[�J�X
                    tNedit_PayeeCode.Focus();
                }
            }
        }
        /// <summary>
        /// �S���҃K�C�h�{�^���@�N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_StockAgentGuide_Click( object sender, EventArgs e )
        {
            if ( _employeeAcs == null )
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid( this._enterpriseCode, true, _noDispData.MngSectionCode, out employee );

            if ( status == 0 && employee != null )
            {
                // �d���S���҂��Z�b�g
                _noDispData.StockAgentCode = employee.EmployeeCode;
                _noDispData.PrevStockAgentName = employee.Name;
                tEdit_StockAgentNm.Text = employee.Name;

                // �t�H�[�J�X
                tComboEditor_PureCode.Focus();
            }
        }
        /// <summary>
        /// �x����K�C�h�{�^���@�N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_PayeeNameGuide_Click( object sender, EventArgs e )
        {
            Supplier supplier;
            int status = _supplierAcs.ExecuteGuid( out supplier, this._enterpriseCode, _noDispData.PaymentSectionCode );

            if ( status == 0 && supplier != null )
            {
                // ��ʂɎx�����K�p
                if ( SettingPayeeToScreen( supplier ) == true )
                {
                    // �t�H�[�J�X
                    if ( tNedit_PaymentTotalDay.Enabled )
                    {
                        // �e�̂Ƃ�
                        tNedit_PaymentTotalDay.Focus();
                    }
                    else
                    {
                        // �q�̂Ƃ�
                        if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                        {
                            tEdit_SupplierPostNo.Focus();
                        }
                        else
                        {
                            tEdit_SupplierNote1.Focus();
                        }
                    }
                }
                else
                {
                    tNedit_PayeeCode.Focus();
                }
            }
        }
        /// <summary>
        /// �x����ݒ菈��
        /// </summary>
        /// <param name="payee"></param>
        private bool SettingPayeeToScreen( Supplier payee )
        {
            bool status = false;

            if ( payee.SupplierCd == 0 || payee.SupplierCd == payee.PayeeCode || payee.SupplierCd == this.tNedit_SupplierCd.GetInt() )
            {
                try
                {
                    // �`���~�@����
                    this.SuspendLayout();

                    // --- ADD 2009/01/20 ��QID:9163�Ή�------------------------------------------------------>>>>>
                    //// �x�����_���Z�b�g
                    //_noDispData.PaymentSectionCode = payee.MngSectionCode.TrimEnd();
                    //_noDispData.PrevPaymentSectionName = payee.MngSectionName.TrimEnd();
                    //tEdit_PaymentSectionCode.Text = payee.MngSectionName.TrimEnd();
                    // --- ADD 2009/01/20 ��QID:9163�Ή�------------------------------------------------------<<<<<

                    // �x������Z�b�g
                    _noDispData.PrevPayeeCode = payee.SupplierCd;
                    tNedit_PayeeCode.SetInt( payee.SupplierCd );
                    uLabel_PayeeName1.Text = payee.SupplierNm1;
                    uLabel_PayeeName2.Text = payee.SupplierNm2;
                    uLabel_PayeeSnm.Text = payee.SupplierSnm;

                    tNedit_PaymentTotalDay.SetInt( payee.PaymentTotalDay );
                    SetComboEditorItemIndex( tComboEditor_PaymentMonthCode, payee.PaymentMonthCode );
                    tNedit_PaymentDay.SetInt( payee.PaymentDay );
                    SetComboEditorItemIndex( tComboEditor_PaymentCond, payee.PaymentCond );
                    tNedit_PaymentSight.SetInt( payee.PaymentSight );
                    tNedit_NTimeCalcStDate.SetInt( payee.NTimeCalcStDate );

                    /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                    SetComboEditorItemIndex( tComboEditor_StckTtlAmntDspWayRef, payee.StckTtlAmntDspWayRef );

                    SetComboEditorItemIndex( tComboEditor_SuppTtlAmountDispWayCd, payee.SuppTtlAmntDspWayCd );
                       --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                    SetComboEditorItemIndex( tComboEditor_SuppCTaXLayRefCd, payee.SuppCTaxLayRefCd );
                    SetComboEditorItemIndex( tComboEditor_SuppTaxLayMethod, payee.SuppCTaxLayCd );

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
                    tNedit_StockUnPrcFrcProcCd.SetInt( payee.StockUnPrcFrcProcCd );
                    tNedit_StockMoneyFrcProcCd.SetInt( payee.StockMoneyFrcProcCd );
                    tNedit_StockCnsTaxFrcProcCd.SetInt( payee.StockCnsTaxFrcProcCd );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD

                    if ( payee.SupplierCd != 0 )
                    {
                        // �x������� �� �d���悪�e/�q���肷��̂ŁA��ʂɔ��f
                        SettingScreenEnableForChild( payee.SupplierCd != this.tNedit_SupplierCd.GetInt() );
                    }
                    else
                    {
                        // �x���斢���� �� �x�����͓��͉�
                        SettingScreenEnableForChild( false );
                    }

                    // �S�̐ݒ�͎x�����_�ˑ�
                    // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                    //SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                    //SettingEnableBySuppTtlAmountDispWayCd((int)tComboEditor_SuppTtlAmountDispWayCd.Value);
                    SettingEnableBySuppTtlAmountDispWayCd(0);
                    // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                    SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);

                    status = true;
                }
                finally
                {
                    // �`��J�n�@����
                    this.ResumeLayout();
                }
                return status;
            }
            else
            {
                // �N���A����
                payee = new Supplier();
                SettingPayeeToScreen( payee );

                TMsgDisp.Show( this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    ASSEMBLY_ID,
                    "�I�����ꂽ�d����͎x����R�[�h���قȂ�ׁA�x����Ƃ��đI���ł��܂���",
                    0,
                    MessageBoxButtons.OK );

                // ���t�H�[�J�X
                tNedit_PayeeCode.Focus();

                return status;
            }
        }

        /// <summary>
        /// ��ʕ\���ݒ�
        /// </summary>
        /// <param name="isChild"></param>
        private void SettingScreenEnableForChild( bool isChild )
        {
            // �q�̂Ƃ����͕s���ڂ̐���
            tNedit_PaymentTotalDay.Enabled = !isChild;
            tComboEditor_PaymentMonthCode.Enabled = !isChild;
            tNedit_PaymentDay.Enabled = !isChild;
            tComboEditor_PaymentCond.Enabled = !isChild;
            tNedit_PaymentSight.Enabled = !isChild;
            tNedit_NTimeCalcStDate.Enabled = !isChild;
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            tComboEditor_StckTtlAmntDspWayRef.Enabled = !isChild;
            tComboEditor_SuppTtlAmountDispWayCd.Enabled = !isChild;
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            tComboEditor_SuppCTaXLayRefCd.Enabled = !isChild;
            tComboEditor_SuppTaxLayMethod.Enabled = !isChild;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
            tNedit_StockUnPrcFrcProcCd.Enabled = !isChild;
            uButton_SalesUnPrcFrcProcCdGuide.Enabled = !isChild;
            tNedit_StockMoneyFrcProcCd.Enabled = !isChild;
            uButton_SalesMoneyFrcProcCdGuide.Enabled = !isChild;
            tNedit_StockCnsTaxFrcProcCd.Enabled = !isChild;
            uButton_SalesCnsTaxFrcProcCdGuide.Enabled = !isChild;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
        }
        /// <summary>
        /// �d���[�������K�C�h�{�^���@�N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SalesUnPrcFrcProcCdGuide_Click( object sender, EventArgs e )
        {
            // �d���[�������A�N�Z�X�N���X��null�Ȃ琶��
            if ( _stockProcMoneyAcs == null )
            {
                _stockProcMoneyAcs = new StockProcMoneyAcs();
            }

            // �Ώ�Nedit
            TNedit targetNedit = null;
            // �ΏۂƂȂ鏈���敪
            int procDiv = 0;

            if ( sender == uButton_SalesMoneyFrcProcCdGuide )
            {
                // �d�����z
                targetNedit = tNedit_StockMoneyFrcProcCd;
                procDiv = 0;
            }
            else if ( sender == uButton_SalesCnsTaxFrcProcCdGuide )
            {
                // �����
                targetNedit = tNedit_StockCnsTaxFrcProcCd;
                procDiv = 1;
            }
            else if ( sender == uButton_SalesUnPrcFrcProcCdGuide )
            {
                // �d���P��
                targetNedit = tNedit_StockUnPrcFrcProcCd;
                procDiv = 2;
            }

            // �K�C�h�N��
            StockProcMoney stockProcMoney;
            int status = _stockProcMoneyAcs.ExecuteGuid( this._enterpriseCode, procDiv, -1, out stockProcMoney );

            // �Ώ�Edit�Ɋi�[
            if ( targetNedit != null && status == 0 )
            {
                targetNedit.SetInt( stockProcMoney.FractionProcCode );

                // �t�H�[�J�X
                switch ( targetNedit.Name )
                {
                    case "tNedit_StockUnPrcFrcProcCd":
                        {
                            tNedit_StockMoneyFrcProcCd.Focus();
                        }
                        break;
                    case "tNedit_StockMoneyFrcProcCd":
                        {
                            tNedit_StockCnsTaxFrcProcCd.Focus();
                        }
                        break;
                    case "tNedit_StockCnsTaxFrcProcCd":
                        {
                            if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                            {
                                tEdit_SupplierPostNo.Focus();
                            }
                            else
                            {
                                tEdit_SupplierNote1.Focus();
                            }

                        }
                        break;
                }
            }
        }
        /// <summary>
        /// �X�֔ԍ��K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_AddressGuide_Click( object sender, EventArgs e )
        {
            ReadAddress( tEdit_SupplierPostNo.Text );
        }
        /// <summary>
        /// �Z����������(�X�֔ԍ����)(SFTKD00426U.DLL)
        /// </summary>
        /// <param name="strPostNo">�X�֔ԍ�</param>
        /// <param name="agResult">�Z�����߂�l�N���X</param>
        /// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
        private int GetAddressFromPostNo( string strPostNo, out AddressGuideResult agResult )
        {
            if ( _addressGuide == null )
            {
                _addressGuide = new AddressGuide();
            }

            System.Windows.Forms.DialogResult result = this._addressGuide.ShowPostNoSearchGuide( strPostNo, out agResult );

            if ( (result == DialogResult.OK) || (result == DialogResult.Yes) )
            {
                if ( agResult.AddressName != "" )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// �Z�����̕�������
        /// </summary>
        /// <param name="length">����������</param>
        /// <param name="addressName">�Z������</param>
        /// <param name="addressName1">�Z�����̕������ʂP</param>
        /// <param name="addressName2">�Z�����̕������ʂQ</param>
        private static void DivisionAddressName( int length, string addressName, out string addressName1, out string addressName2 )
        {
            addressName1 = addressName;
            addressName2 = "";

            if ( addressName.Length > length )
            {
                addressName1 = addressName.Substring( 0, length );
                addressName2 = addressName.Substring( length, addressName.Length - length );
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// �S�p�����p �ϊ�
        /// </summary>
        /// <param name="text"></param>
        private static string ToHalf( string text )
        {
            return Microsoft.VisualBasic.Strings.StrConv( text, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
		# endregion

        # region [UI��\���f�[�^]
        /// <summary>
        /// UI��\���f�[�^
        /// </summary>
        private struct NoDispData
        {
            # region [private �t�B�[���h]
            /// <summary>�Ǘ����_�R�[�h</summary>
            private string _mngSectionCode;
            /// <summary>�d���S���҃R�[�h</summary>
            private string _stockAgentCode;
            /// <summary>�x�����_�R�[�h</summary>
            private string _paymentSectionCode;
            /// <summary>�O����� �Ǘ����_����</summary>
            private string _prevMngSectionName;
            /// <summary>�O����� �d���S���Җ���</summary>
            private string _prevStockAgentName;
            /// <summary>�O����� �x�����_����</summary>
            private string _prevPaymentSectionName;
            /// <summary>�O����� �d����R�[�h</summary>
            private int _prevSupplierCd;
            /// <summary>�O����� �x����R�[�h</summary>
            private int _prevPayeeCode;
            /// <summary>�O����� �X�֔ԍ�</summary>
            private string _prevPostNo;
            /// <summary>�O����� �d���於�̂P</summary>
            private string _prevSupplierName;
            # endregion

            # region [public �v���p�e�B]
            /// <summary>
            /// �Ǘ����_�R�[�h
            /// </summary>
            public string MngSectionCode
            {
                get { return _mngSectionCode; }
                set { _mngSectionCode = value; }
            }
            /// <summary>
            /// �d���S���҃R�[�h
            /// </summary>
            public string StockAgentCode
            {
                get { return _stockAgentCode; }
                set { _stockAgentCode = value; }
            }
            /// <summary>
            /// �x�����_�R�[�h
            /// </summary>
            public string PaymentSectionCode
            {
                get { return _paymentSectionCode; }
                set { _paymentSectionCode = value; }
            }
            /// <summary>
            /// �O����� �Ǘ����_����
            /// </summary>
            public string PrevMngSectionName
            {
                get { return _prevMngSectionName; }
                set { _prevMngSectionName = value; }
            }
            /// <summary>
            /// �O����� �d���S���Җ���
            /// </summary>
            public string PrevStockAgentName
            {
                get { return _prevStockAgentName; }
                set { _prevStockAgentName = value; }
            }
            /// <summary>
            /// �O����� �x�����_
            /// </summary>
            public string PrevPaymentSectionName
            {
                get { return _prevPaymentSectionName; }
                set { _prevPaymentSectionName = value; }
            }
            /// <summary>
            /// �O����� �d����R�[�h
            /// </summary>
            public int PrevSupplierCd
            {
                get { return _prevSupplierCd; }
                set { _prevSupplierCd = value; }
            }
            /// <summary>
            /// �O����� �x����R�[�h
            /// </summary>
            public int PrevPayeeCode
            {
                get { return _prevPayeeCode; }
                set { _prevPayeeCode = value; }
            }
            /// <summary>
            /// �O����� �X�֔ԍ�
            /// </summary>
            public string PrevPostNo
            {
                get { return _prevPostNo; }
                set { _prevPostNo = value; }
            }
            /// <summary>
            /// �O����� �d���於�̂P
            /// </summary>
            public string PrevSupplierName
            {
                get { return _prevSupplierName; }
                set { _prevSupplierName = value; }
            }
            # endregion

            # region [public ���\�b�h]
            /// <summary>
            /// �f�[�^�擾�����iSupplier��NoDispData�j
            /// </summary>
            /// <param name="supplier"></param>
            public void SetFromData( Supplier supplier )
            {
                // �R�[�h
                MngSectionCode = supplier.MngSectionCode.TrimEnd();
                StockAgentCode = supplier.StockAgentCode.TrimEnd();
                PaymentSectionCode = supplier.PaymentSectionCode.TrimEnd();
                // �O�����
                PrevMngSectionName = supplier.MngSectionName.TrimEnd();
                PrevStockAgentName = supplier.StockAgentName.TrimEnd();
                PrevPaymentSectionName = supplier.PaymentSectionName.TrimEnd();
                PrevSupplierCd = supplier.SupplierCd;
                PrevPayeeCode = supplier.PayeeCode;
                PrevSupplierName = supplier.SupplierNm1.TrimEnd();
                PrevPostNo = supplier.SupplierPostNo.TrimEnd();
            }
            /// <summary>
            /// �f�[�^�i�[�����iNoDispData��Supplier�j
            /// </summary>
            /// <param name="supplier"></param>
            public void SetToData( ref Supplier supplier )
            {
                // �R�[�h
                supplier.MngSectionCode = MngSectionCode;
                supplier.StockAgentCode = StockAgentCode;
                supplier.PaymentSectionCode = PaymentSectionCode;
            }
            /// <summary>
            /// �f�[�^�N���A����
            /// </summary>
            public void Clear()
            {
                // �R�[�h
                MngSectionCode = string.Empty;
                StockAgentCode = string.Empty;
                PaymentSectionCode = string.Empty;
                // �O�����
                PrevMngSectionName = string.Empty;
                PrevStockAgentName = string.Empty;
                PrevPaymentSectionName = string.Empty;
                PrevSupplierCd = 0;
                PrevPayeeCode = 0;
                PrevSupplierName = string.Empty;
                PrevPostNo = string.Empty;
            }
            # endregion
        }
        # endregion

        # region [�d�����z�[�������L�[]
        /// <summary>
        /// �d�����z�[�������L�[�\����
        /// </summary>
        private struct StockProcMoneyKey
        {
            private int _fracProcMoneyDiv;
            private int _fractionProcCode;

            /// <summary>�[�������敪</summary>
            public int FracProcMoneyDiv
            {
                get { return _fracProcMoneyDiv; }
                set { _fracProcMoneyDiv = value; }
            }
            /// <summary>�[�������R�[�h</summary>
            public int FractionProcCode
            {
                get { return _fractionProcCode; }
                set { _fractionProcCode = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="fracProcMoneyDiv"></param>
            /// <param name="fractionProcCode"></param>
            public StockProcMoneyKey( int fracProcMoneyDiv, int fractionProcCode )
            {
                this._fracProcMoneyDiv = fracProcMoneyDiv;
                this._fractionProcCode = fractionProcCode;
            }
        }
        # endregion

        /// <summary>
        /// �œ��e�ύX���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SupplierKana_ValueChanged( object sender, EventArgs e )
        {
            // TImeControl(�����̃R���|�[�l���g)�ł͑S�p�J�i�ɂȂ�ׁA�l�ύX���ɔ��p�łɕϊ�����{�K��̌����Ő؂�
            string kana = ToHalf( tEdit_SupplierKana.Text );
            tEdit_SupplierKana.Text = kana.Substring( 0, Math.Min( tEdit_SupplierKana.ExtEdit.Column, kana.Length ) );
        }

        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���z�\���Q�Ƌ敪�ύX���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_StckTtlAmntDspWayRef_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
        }
           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// �]�ŕ����Q�Ƌ敪�ύX���C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SuppCTaXLayRefCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SettingEnableBySuppCTaXLayRefCd( (int)tComboEditor_SuppCTaXLayRefCd.Value );
        }

        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���z�\��Enable�ݒ�
        /// </summary>
        /// <param name="value"></param>
        private void SettingEnableByStckTtlAmntDspWayRef( int value )
        {
            if ( value == 0 )
            {
                // 0:�S�̐ݒ�
                tComboEditor_SuppTtlAmountDispWayCd.Enabled = false;
                // �S�̏����l�ݒ�Œu��������(�x�����_�ˑ�)
                AllDefSet allDefSet = GetAllDefSet( _noDispData.PaymentSectionCode );
                SetComboEditorItemIndex( tComboEditor_SuppTtlAmountDispWayCd, allDefSet.TotalAmountDispWayCd );
                // �Z�b�g�����l�ɏ]��Enable����
                SettingEnableBySuppTtlAmountDispWayCd( (int)tComboEditor_SuppTtlAmountDispWayCd.Value );
            }
            else
            {
                // 1:�d����
                if ( tNedit_PaymentTotalDay.Enabled )
                {
                    tComboEditor_SuppTtlAmountDispWayCd.Enabled = true;
                }
            }
        }
           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// �]�ŕ���Enable�ݒ�
        /// </summary>
        /// <param name="value"></param>
        private void SettingEnableBySuppCTaXLayRefCd( int value )
        {
            if ( value == 0 )
            {
                // 0:�S�̐ݒ�
                tComboEditor_SuppTaxLayMethod.Enabled = false;
                // �ŗ��ݒ�Œu��������
                SetComboEditorItemIndex( tComboEditor_SuppTaxLayMethod, _taxRateSet.ConsTaxLayMethod );
            }
            else
            {
                // 1:�d����
                if ( tNedit_PaymentTotalDay.Enabled && tComboEditor_SuppCTaXLayRefCd.Enabled )
                {
                    tComboEditor_SuppTaxLayMethod.Enabled = true;
                }
            }
        }
        /// <summary>
        /// ���z�\�����@�敪Enable�ݒ�
        /// </summary>
        /// <param name="value"></param>
        private void SettingEnableBySuppTtlAmountDispWayCd( int value )
        {
            if ( value == 0 )
            {
                // 0:���Ȃ��i�Ŕ����j
                // ���]�ŕ�������͉\�ɂ���
                if ( tNedit_PaymentTotalDay.Enabled )
                {
                    tComboEditor_SuppCTaXLayRefCd.Enabled = true;
                }
                SettingEnableBySuppCTaXLayRefCd( (int)tComboEditor_SuppCTaXLayRefCd.Value );
            }
            else
            {
                // 1:����i�ō��݁j
                // ���]�ŕ�������͕s�ɂ��āA�u1:�d����Q�Ɓv�u1:���גP�ʁv�Œ�ɂ���
                tComboEditor_SuppCTaXLayRefCd.Enabled = false;
                tComboEditor_SuppTaxLayMethod.Enabled = false;
                tComboEditor_SuppCTaXLayRefCd.Value = 1;
                tComboEditor_SuppTaxLayMethod.Value = 1;
            }
        }
        /// <summary>
        /// �S�̏����l�ݒ�擾����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private AllDefSet GetAllDefSet( string sectionCode )
        {
            const string allSection = "00";

            
            // �␳
            sectionCode = sectionCode.TrimEnd();

            if ( _allDefSetDic.ContainsKey( sectionCode ) )
            {
                // ���_�ɑ΂���ݒ�
                return _allDefSetDic[sectionCode];
            }
            else if ( _allDefSetDic.ContainsKey( allSection ) )
            {
                // �S�Аݒ�
                return _allDefSetDic[allSection];
            }
            else
            {
                // ��̐ݒ�
                return new AllDefSet(); 
            }
        }

        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���z�\���敪�ύX�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SuppTtlAmountDispWayCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SettingEnableBySuppTtlAmountDispWayCd( (int)tComboEditor_SuppTtlAmountDispWayCd.Value );
        }
           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// �񋟎d����K�C�h�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2012/10/22  ���N</br>
        /// <br>�Ǘ��ԍ�   : 2012/11/14�z�M��</br>
        /// <br>             Redmine#32861 �d����K�C�h�́A�d���`�[���͂Ɠ��l�̃K�C�h���g�p����悤�ɏC��</br>
        /// </remarks>
        private void uButton_OfrSupplierGuide_Click( object sender, EventArgs e )
        {
            // --------- DEL ���N 2012/10/22 Redmine#32861----------->>>>>
            //if ( _ofrSupplierAcs == null )
            //{
            //    _ofrSupplierAcs = new OfrSupplierAcs();
            //}
            //OfrSupplier ofrSupplier;
            //int status = _ofrSupplierAcs.ExecuteGuid( out ofrSupplier );
            // --------- DEL ���N 2012/10/22 Redmine#32861-----------<<<<<
            // --------- ADD ���N 2012/10/22 Redmine#32861----------->>>>>
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }
            Supplier supplierInfo;
            int status = _supplierAcs.ExecuteGuid(out supplierInfo,this._enterpriseCode,string.Empty);
            // --------- ADD ���N 2012/10/22 Redmine#32861-----------<<<<<
            // �K�C�h���ʃZ�b�g
            //if (status == 0 && _ofrSupplierAcs != null) // DEL ���N 2012/10/22 Redmine#32861
            if (status == 0 && supplierInfo != null) // ADD ���N 2012/10/22 Redmine#32861
            {
                // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                // �d����o�^�ς݃`�F�b�N
                //int supplierCode = ofrSupplier.SupplierCd;

                //if ( supplierCode != _noDispData.PrevSupplierCd )
                //{
                //    int code;
                //    string name1;
                //    string name2;
                //    string snm;

                //    if (ReadSupplier(supplierCode, out code, out name1, out name2, out snm))
                //    {
                //        TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_INFO,
                //            this.Name,
                //            "���͂��ꂽ�R�[�h�̎d�����񂪊��ɓo�^����Ă��܂��B",
                //            -1,
                //            MessageBoxButtons.OK);

                //        tNedit_SupplierCd.SetInt(0);
                //        _noDispData.PrevSupplierCd = 0;

                //        // ���t�H�[�J�X
                //        uButton_OfrSupplierGuide.Focus();
                //    }
                //    else
                //    {
                //        // �I�����ʃZ�b�g
                //        tNedit_SupplierCd.SetInt( ofrSupplier.SupplierCd );
                //        tEdit_SupplierName1.Text = ofrSupplier.SupplierNm1;
                //        tEdit_SupplierSnm.Text = ofrSupplier.SupplierSnm;
                //        tEdit_SupplierKana.Text = ofrSupplier.SupplierKana;

                //        // �x����ɂ��R�s�[
                //        # region [�x����]
                //        tNedit_PayeeCode.SetInt( ofrSupplier.SupplierCd );
                //        uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                //        uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                //        uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                //        _noDispData.PrevPayeeCode = ofrSupplier.SupplierCd;

                //        SettingScreenEnableForChild( false );

                //        // �S�̐ݒ�͎x�����_�ˑ�
                //        // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                //        //SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                //        //SettingEnableBySuppTtlAmountDispWayCd((int)tComboEditor_SuppTtlAmountDispWayCd.Value);
                //        SettingEnableBySuppTtlAmountDispWayCd(0);
                //        // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                //        SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                //        # endregion

                //        // ���t�H�[�J�X
                //        tEdit_SupplierName1.Focus();
                //    }
                //}

                //tNedit_SupplierCd.SetInt(ofrSupplier.SupplierCd); // DEL ���N 2012/10/22 Redmine#32861
                tNedit_SupplierCd.SetInt(supplierInfo.SupplierCd);   // ADD ���N 2012/10/22 Redmine#32861
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Focus();
                    }
                    else
                    {
                        // --------- DEL ���N 2012/10/22 Redmine#32861------------------>>>>>
                        // �I�����ʃZ�b�g
                        //tNedit_SupplierCd.SetInt(ofrSupplier.SupplierCd);
                        //tEdit_SupplierName1.Text = ofrSupplier.SupplierNm1;
                        //tEdit_SupplierSnm.Text = ofrSupplier.SupplierSnm;
                        //tEdit_SupplierKana.Text = ofrSupplier.SupplierKana;

                        //// �x����ɂ��R�s�[
                        //# region [�x����]
                        //tNedit_PayeeCode.SetInt(ofrSupplier.SupplierCd);
                        //uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                        //uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                        //uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                        //_noDispData.PrevPayeeCode = ofrSupplier.SupplierCd;
                        // --------- DEL ���N 2012/10/22 Redmine#32861------------------<<<<<
                        // --------- ADD ���N 2012/10/22 Redmine#32861------------------>>>>>
                        // �I�����ʃZ�b�g
                        tNedit_SupplierCd.SetInt(supplierInfo.SupplierCd);
                        tEdit_SupplierName1.Text = supplierInfo.SupplierNm1;
                        tEdit_SupplierSnm.Text = supplierInfo.SupplierSnm;
                        tEdit_SupplierKana.Text = supplierInfo.SupplierKana;

                        // �x����ɂ��R�s�[
                        # region [�x����]
                        tNedit_PayeeCode.SetInt(supplierInfo.SupplierCd);  
                        uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                        uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                        uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;
                        _noDispData.PrevPayeeCode = supplierInfo.SupplierCd;
                        // --------- ADD ���N 2012/10/22 Redmine#32861------------------<<<<<
                        SettingScreenEnableForChild(false);

                        // �S�̐ݒ�͎x�����_�ˑ�
                        SettingEnableBySuppTtlAmountDispWayCd(0);
                        SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                        # endregion

                        // ���t�H�[�J�X
                        tEdit_SupplierName1.Focus();
                    }
                }
                // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
            }
        }

        private void ultraLabel20_Click(object sender, EventArgs e)
        {

        }

        // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            _userGdBdListStc = null;

            ArrayList retList;

            // �Ǝ�i���[�U�[�K�C�h�}�X�^���擾�j
            int status = this.GetDivCodeBodyList(33, out retList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retList.Sort();

                int index = 0;
                if (tComboEditor_BusinessTypeCode.Value != null)
                {
                    index = (int)tComboEditor_BusinessTypeCode.Value;
                }

                tComboEditor_BusinessTypeCode.Items.Clear();
                AddComboEditorItem(this.tComboEditor_BusinessTypeCode, 0, " ");
                int count = 1;
                foreach (ComboEditorItemSupplier ci in retList)
                {
                    count++;
                    AddComboEditorItem(this.tComboEditor_BusinessTypeCode, ci.Code, ci.Name);
                }

                tComboEditor_BusinessTypeCode.Value = index;
            }

            // �̔��G���A�i���[�U�[�K�C�h�}�X�^���擾�j
            status = this.GetDivCodeBodyList(21, out retList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retList.Sort();

                int index = 0;
                if (tComboEditor_SalesAreaCode.Value != null)
                {
                    index = (int)tComboEditor_SalesAreaCode.Value;
                }

                tComboEditor_SalesAreaCode.Items.Clear();
                AddComboEditorItem(this.tComboEditor_SalesAreaCode, 0, " ");
                int count = 1;
                foreach (ComboEditorItemSupplier ci in retList)
                {
                    count++;
                    AddComboEditorItem(this.tComboEditor_SalesAreaCode, ci.Code, ci.Name);
                }

                tComboEditor_SalesAreaCode.Value = index;
            }

            // �x���ݒ�}�X�^�Ǎ�
            PaymentSet paymentSet;
            status = ReadPaymentSet(out paymentSet);
            if (status == 0)
            {
                // ���z��ʐݒ�}�X�^�Ǎ�
                Dictionary<int, MoneyKind> moneyKindDic;
                status = ReadMoneyKind(out moneyKindDic);
                if (status == 0)
                {
                    int index = 0;
                    if (tComboEditor_PaymentCond.Value != null)
                    {
                        index = (int)tComboEditor_PaymentCond.Value;
                    }

                    tComboEditor_PaymentCond.Items.Clear();

                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd1))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd1, moneyKindDic[paymentSet.PayStMoneyKindCd1].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd2))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd2, moneyKindDic[paymentSet.PayStMoneyKindCd2].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd3))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd3, moneyKindDic[paymentSet.PayStMoneyKindCd3].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd4))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd4, moneyKindDic[paymentSet.PayStMoneyKindCd4].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd5))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd5, moneyKindDic[paymentSet.PayStMoneyKindCd5].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd6))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd6, moneyKindDic[paymentSet.PayStMoneyKindCd6].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd7))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd7, moneyKindDic[paymentSet.PayStMoneyKindCd7].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd8))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd8, moneyKindDic[paymentSet.PayStMoneyKindCd8].MoneyKindName);
                    }

                    tComboEditor_PaymentCond.Value = index;
                }
            }

            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            taxRateSetAcs.Read(out _taxRateSet, this._enterpriseCode, 0); // 0:���
            if (_taxRateSet == null) _taxRateSet = new TaxRateSet();

            this._stockProcMoneyAcs = new StockProcMoneyAcs();

            this._stockProcMoneyCdList = null;

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }
        // --- ADD 2009/03/23 �c�Č�No.14�Ή�------------------------------------------------------<<<<<

        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �d����R�[�h
            int supplierCd = tNedit_SupplierCd.GetInt();

            for (int i = 0; i < this._supplierDataTable.Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                int dsSupplierCd = (int)this._supplierDataTable.Rows[i][SUPPLIERCD_TITLE];
                if (supplierCd == dsSupplierCd)
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this._supplierDataTable.Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̎d������͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �d����R�[�h�̃N���A
                        tNedit_SupplierCd.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̎d�����񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",                                    // �\�����郁�b�Z�[�W
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
                                // �d����R�[�h�̃N���A
                                tNedit_SupplierCd.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.31 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
    }
}
