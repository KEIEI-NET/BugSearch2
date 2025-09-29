using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

// --- ADD 2012/10/02 ---------->>>>>
// �I�v�V�����R�[�h�擾�ɕK�v
using Broadleaf.Application.Resources;
// --- ADD 2012/10/02 ----------<<<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �d���挳���Ɖ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note        : �d���挳���ɃA�N�Z�X����N���X�ł��B</br>
	/// <br>Programer   : 20081 �D�c �E�l</br>
	/// <br>Date        : 2007.11.26</br>
	/// <br></br>
    /// <br>UpdateNote	: </br>
    /// <br>Programer   : 30365 �{�� �⎟�Y</br>
    /// <br>Date        : 2009.1.28 DC�d���挳������PM.NS�Ή��B</br>
    /// <br>            :           �K�v�����Ɖ�@�\���폜�B�e�[�u�����d�l�ɍ��킹���ρB</br>
    /// <br></br>
    /// <br>UpdateNote	: </br>
    /// <br>Programer   : FSI�֓� �a�G</br>
    /// <br>Date        : 2012/10/02 �d���摍���Ή��B</br>
    /// <br>            :            �d���摍���p�I�v�V�����R�[�h�擾�����̒ǉ��B</br>
    /// <br>UpdateNote	: </br>
    /// <br>Programer   : FSI�֓� �a�G</br>
    /// <br>Date        : 2012/11/01 �x���f�[�^�ɒl���z�E�萔���z�����f����Ă��Ȃ����Ή��B</br>
    /// <br>            :            ����œ]�ŕ��������f���ꂸ�ɕ\���������Ή��B</br>
    /// <br>Update Note : 2014/02/26 �c����</br>
    /// <br>            : Redmine#42188 �o�͋��z�敪�ǉ�</br>
    /// <br>UpdateNote  : 2015/10/21 �c�v�t</br>
    /// <br>�Ǘ��ԍ�    : 11170187-00</br>
    /// <br>            : Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br>
    /// <br>UpdateNote  : 2015/12/10 �c�v�t</br>
    /// <br>�Ǘ��ԍ�    : 11170204-00</br>
    /// <br>            : Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�</br>
    /// </remarks>
	public class SupplierLedgerAcs
	{
		#region Constructor
		/// <summary>
		/// �d���挳���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public SupplierLedgerAcs()
		{
		}
		#endregion

		#region Static Constructor
		/// <summary>
		/// �d���挳���A�N�Z�X�N���X�ÓI�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// <br>Update Date: xxxx.xx.xx</br>
		/// </remarks>
		static SupplierLedgerAcs()
		{
			// ���_���擾���i
			_secInfoAcs = new SecInfoAcs();

            _suplierPayInfGetDB = (ISuplierPayInfGetDB)MediationSuplierPayInfGetDB.GetSuplierPayInfGetDB();
            _suplAccInfGetDB = (ISuplAccInfGetDB)MediationSuplAccInfGetDB.GetSuplAccInfGetDB();

			//���͈�
			_startTtlAddUpDateSpan	= new DateTime(1, 1, 1);
			_endTtlAddUpDateSpan	= new DateTime(1, 1, 1);

			// �f�[�^�Z�b�g�쐬
			SettingDataSet();

			// �g�p����e�[�u��������
			_stockLedgerSupplierInfoTable = new Hashtable();          
			_sectionTable = new Hashtable();
			_secCodeList = new ArrayList();
            _paymentSlpTable = new Hashtable();

			// ���O�C�����_�擾
			Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
			if (loginEmployee != null)
			{
				_mySectionCode = loginEmployee.BelongSectionCode;
			}
		}
		#endregion

		#region Public enum
		/// <summary>�����̉�ʃ��[�h�̗񋓌^�ł��B</summary>
		public enum Mode : int
		{
			/// <summary>�x��</summary>
			Shr	= 0,
			/// <summary>���|</summary>
			Kai	= 1,
		}

		/// <summary>�������ׂ̃��R�[�h�敪�̗񋓌^�ł��B</summary>
		public enum RecordCode : int
		{
			/// <summary>�x�����|</summary>
			AccPay		= 0,
			/// <summary>�x���`�[</summary>
			PaymentSlp	= 1,
		}

        /// <summary>�d���`��</summary>
		public enum SupplierFormal : int
		{
			/// <summary>���|(�d��)</summary>
			TypeStock		= 0,
			/// <summary>����</summary>
			Arrive	= 1,
            /// <summary>����</summary>
            SalesOrder = 2,
		}

        /// <summary>���|�敪</summary>
		public enum AccPayDiv : int
		{
			/// <summary>0:���|����</summary>
			NotAccPay	= 0,
			/// <summary>1:���|</summary>
			JustAccPay	= 1,
		}
     
		/// <summary>�������ׂ̑O�c�J�z�敪�̗񋓌^�ł��B</summary>
		public enum BalanceCode : int
		{
			/// <summary>�O�c</summary>
			Balance	= 0,
			/// <summary>���̑�(�x�����| or �x���`�[)</summary>
			Others	= 1,
			/// <summary>�����(�����P�ʂ̏ꍇ�̂�)</summary>
			ConsTax	= 2,
			/// <summary>�J�z</summary>
			Carried	= 3,
		}

        /// <summary>�d���`�[�敪(10:�d��,20:�ԕi)</summary>
		public enum  SupplierLedgerSlipCdDiv : int
		{
			/// <summary>�d��</summary>
			Stock = 10,
			/// <summary>�ԕi</summary>
			Back = 20,		
		}

        /// <summary>�ԓ`�敪(0:��,1:��,2:���E�ςݍ�)</summary>
		public enum SupplierLedgerDtlDebitNoteDiv : int
		{
			/// <summary>���`</summary>
			Black = 0,
			/// <summary>�ԓ`</summary>
			Red = 1,
			/// <summary>����</summary>
			OffsetBlack = 2,
		}

        /// <summary>���t���O�敪(0:����,1:����)</summary>
		public enum CloseFlagState : int
		{
			/// <summary>����</summary>
			NotClose = 0,
			/// <summary>����</summary>
			Close = 1,
		}

		#endregion
		#region Public Const

        #region �e�[�u����
        /// <summary>�x���w�b�_</summary>
        public const string TABLE_SuplierPay = "TABLE_SuplierPay";

        /// <summary>�����`�[�f�[�^�e�[�u����</summary>
        public const string TABLE_SplLedger = "TABLE_SplLedger";

        /// <summary>�������׃f�[�^�e�[�u����</summary>
        public const string TABLE_DtlLedger = "TABLE_DtlLedger";

        /// <summary>�����x���`�[�e�[�u����</summary>
        public const string TABLE_PaymentLedger = "TABLE_PaymentLedger";
        #endregion

        #region �x���̊�
        /// <summary> ��ƃR�[�h </summary>
        public const string COL_Spl_EnterpriseCode = "EnterpriseCode";
        /// <summary> �v�㋒�_�R�[�h </summary>
        public const string COL_Spl_AddUpSecCode = "AddUpSecCode";
        /// <summary> �v�㋒�_�� </summary>
        public const string COL_Spl_AddUpSecName = "AddUpSecName";
        /// <summary> �x����R�[�h </summary>
        public const string COL_Spl_PayeeCode = "PayeeCode";
        /// <summary> �x���於�� </summary>
        public const string COL_Spl_PayeeName = "PayeeName";
        /// <summary> �x���於��2 </summary>
        public const string COL_Spl_PayeeName2 = "PayeeName2";
        /// <summary> �x���旪�� </summary>
        public const string COL_Spl_PayeeSnm = "PayeeSnm";
        /// <summary> ���ы��_�R�[�h </summary>
        public const string COL_Spl_ResultsSectCd = "ResultsSectCd";
        /// <summary> �d����R�[�h </summary>
        public const string COL_Spl_SupplierCd = "SupplierCd";
        /// <summary> �d���於1 </summary>
        public const string COL_Spl_SupplierNm1 = "SupplierNm1";
        /// <summary> �d���於2 </summary>
        public const string COL_Spl_SupplierNm2 = "SupplierNm2";
        /// <summary> �d���旪�� </summary>
        public const string COL_Spl_SupplierSnm = "SupplierSnm";
        /// <summary> �v��N���� </summary>
        public const string COL_Spl_AddUpDate = "AddUpDate";
        /// <summary> �v��N�� </summary>
        public const string COL_Spl_AddUpYearMonth = "AddUpYearMonth";
        /// <summary> �O��x�����z </summary>
        public const string COL_Spl_LastTimePayment = "LastTimePayment";
        /// <summary> �d��2��O�c���i�x���v�j </summary>
        public const string COL_Spl_StockTtl2TmBfBlPay = "StockTtl2TmBfBlPay";
        /// <summary> �d��3��O�c���i�x���v�j </summary>
        public const string COL_Spl_StockTtl3TmBfBlPay = "StockTtl3TmBfBlPay";
        /// <summary> ����x�����z�i�ʏ�x���j </summary>
        public const string COL_Spl_ThisTimePayNrml = "ThisTimePayNrml";
        /// <summary> ����J�z�c���i�x���v�j </summary>
        public const string COL_Spl_ThisTimeTtlBlcPay = "ThisTimeTtlBlcPay";
        /// <summary> ���E�㍡��d�����z </summary>
        public const string COL_Spl_OfsThisTimeStock = "OfsThisTimeStock";
        /// <summary> ���E�㍡��d������� </summary>
        public const string COL_Spl_OfsThisStockTax = "OfsThisStockTax";
        /// <summary> �ō��d���z </summary>
        public const string COL_Spl_OfsThisTimeStockTax = "OfsThisTimeStockTax";
        /// <summary> ����ԕi���z </summary>
        public const string COL_Spl_ThisStckPricRgds = "ThisStckPricRgds";
        /// <summary> ����ԕi����� </summary>
        public const string COL_Spl_ThisStcPrcTaxRgds = "ThisStcPrcTaxRgds";
        /// <summary> ����l�����z </summary>
        public const string COL_Spl_ThisStckPricDis = "ThisStckPricDis";
        /// <summary> ����l������� </summary>
        public const string COL_Spl_ThisStcPrcTaxDis = "ThisStcPrcTaxDis";
        /// <summary> ����ԕi�E�l�����z </summary>
        public const string COL_Spl_ThisStckPricRgdsDis = "ThisStckPricRgdsDis";
        /// <summary> ����Œ����z </summary>
        public const string COL_Spl_TaxAdjust = "TaxAdjust";
        /// <summary> �c�������z </summary>
        public const string COL_Spl_BalanceAdjust = "BalanceAdjust";
        /// <summary> �d�����v�c���i�x���v�j </summary>
        public const string COL_Spl_StockTotalPayBalance = "StockTotalPayBalance";
        /// <summary> �����X�V���s�N���� </summary>
        public const string COL_Spl_CAddUpUpdExecDate = "CAddUpUpdExecDate";
        /// <summary> �����X�V�J�n�N���� </summary>
        public const string COL_Spl_StartCAddUpUpdDate = "StartCAddUpUpdDate";
        /// <summary> �O������X�V�N���� </summary>
        public const string COL_Spl_LastCAddUpUpdDate = "LastCAddUpUpdDate";
        /// <summary> �d���`�[���� </summary>
        public const string COL_Spl_StockSlipCount = "StockSlipCount";
        /// <summary> ���ς݃t���O </summary>
        public const string COL_Spl_CloseFlg = "CloseFlg";
        /// <summary> ����p �x���c�E���|�c </summary>
        public const string COL_Spl_SlitTitle = "SlitTitle";
        // 2009.02.24 30413 ���� ����d�����z�̒ǉ� >>>>>>START
        /// <summary> ����d�����z </summary>
        public const string COL_Spl_ThisTimeStockPrice = "ThisTimeStockPrice";
        // 2009.02.24 30413 ���� ����d�����z�̒ǉ� <<<<<<END
        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary> ����œ]�ŕ��� </summary>
        public const string COL_Spl_SuppCTaxLayCd = "SuppCTaxLayCd";
        // --- ADD 2012/11/01 ----------<<<<<

        #endregion
        #region ���|�̊�
        /// <summary> ��ƃR�[�h </summary>
        public const string COL_Acc_EnterpriseCode = "EnterpriseCode";
        /// <summary> �v�㋒�_�R�[�h </summary>
        public const string COL_Acc_AddUpSecCode = "AddUpSecCode";
        /// <summary> �v�㋒�_�� </summary>
        public const string COL_Acc_AddUpSecName = "AddUpSecName";
        /// <summary> �x����R�[�h </summary>
        public const string COL_Acc_PayeeCode = "PayeeCode";
        /// <summary> �x���於�� </summary>
        public const string COL_Acc_PayeeName = "PayeeName";
        /// <summary> �x���於��2 </summary>
        public const string COL_Acc_PayeeName2 = "PayeeName2";
        /// <summary> �x���旪�� </summary>
        public const string COL_Acc_PayeeSnm = "PayeeSnm";
        /// <summary> �d����R�[�h </summary>
        public const string COL_Acc_SupplierCd = "SupplierCd";
        /// <summary> �d���於1 </summary>
        public const string COL_Acc_SupplierNm1 = "SupplierNm1";
        /// <summary> �d���於2 </summary>
        public const string COL_Acc_SupplierNm2 = "SupplierNm2";
        /// <summary> �d���旪�� </summary>
        public const string COL_Acc_SupplierSnm = "SupplierSnm";
        /// <summary> �v��N���� </summary>
        public const string COL_Acc_AddUpDate = "AddUpDate";
        /// <summary> �v��N�� </summary>
        public const string COL_Acc_AddUpYearMonth = "AddUpYearMonth";
        /// <summary> �O�񔃊|���z </summary>
        public const string COL_Acc_LastTimeAccPay = "LastTimeAccPay";
        /// <summary> �d��2��O�c���i���|�v�j </summary>
        public const string COL_Acc_StckTtl2TmBfBlAccPay = "StckTtl2TmBfBlAccPay";
        /// <summary> �d��3��O�c���i���|�v�j </summary>
        public const string COL_Acc_StckTtl3TmBfBlAccPay = "StckTtl3TmBfBlAccPay";
        /// <summary> ����x�����z�i�ʏ�x���j </summary>
        public const string COL_Acc_ThisTimePayNrml = "ThisTimePayNrml";
        /// <summary> ����J�z�c���i���|�v�j </summary>
        public const string COL_Acc_ThisTimeTtlBlcAcPay = "ThisTimeTtlBlcAcPay";
        /// <summary> ���E�㍡��d�����z </summary>
        public const string COL_Acc_OfsThisTimeStock = "OfsThisTimeStock";
        /// <summary> ���E�㍡��d������� </summary>
        public const string COL_Acc_OfsThisStockTax = "OfsThisStockTax";
        /// <summary> ����ԕi���z </summary>
        public const string COL_Acc_ThisStckPricRgds = "ThisStckPricRgds";
        /// <summary> ����ԕi����� </summary>
        public const string COL_Acc_ThisStcPrcTaxRgds = "ThisStcPrcTaxRgds";
        /// <summary> ����l�����z </summary>
        public const string COL_Acc_ThisStckPricDis = "ThisStckPricDis";
        /// <summary> ����l������� </summary>
        public const string COL_Acc_ThisStcPrcTaxDis = "ThisStcPrcTaxDis";
        /// <summary> ����Œ����z </summary>
        public const string COL_Acc_TaxAdjust = "TaxAdjust";
        /// <summary> �c�������z </summary>
        public const string COL_Acc_BalanceAdjust = "BalanceAdjust";
        /// <summary> �d�����v�c���i���|�v�j </summary>
        public const string COL_Acc_StckTtlAccPayBalance = "StckTtlAccPayBalance";
        /// <summary> �����X�V���s�N���� </summary>
        public const string COL_Acc_MonthAddUpExpDate = "MonthAddUpExpDate";
        /// <summary> �����X�V�J�n�N���� </summary>
        public const string COL_Acc_StMonCAddUpUpdDate = "StMonCAddUpUpdDate";
        /// <summary> �O�񌎎��X�V�N���� </summary>
        public const string COL_Acc_LaMonCAddUpUpdDate = "LaMonCAddUpUpdDate";
        /// <summary> �d���`�[���� </summary>
        public const string COL_Acc_StockSlipCount = "StockSlipCount";
        /// <summary> ���ς݃t���O </summary>
        public const string COL_Acc_CloseFlg = "CloseFlg";
        /// <summary> ����p �x���c�E���|�c </summary>
        public const string COL_Acc_SlitTitle = "SlitTitle";
        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary> ����œ]�ŕ��� </summary>
        public const string COL_Acc_SuppCTaxLayCd = "SuppCTaxLayCd";
        // --- ADD 2012/11/01 ----------<<<<<
        #endregion

        #region �������׃J�������(�`�[)
        /// <summary> ��ƃR�[�h </summary>
        public const string CT_SplLedger_EnterpriseCode = "EnterpriseCode";
        /// <summary> �v����t(���) </summary>
        public const string CT_SplLedger_AddUpDate = "AddUpDate";
        /// <summary> �d���`�� </summary>
        public const string CT_SplLedger_SupplierFormal = "SupplierFormal";
        /// <summary> �d���`�[�ԍ� </summary>
        public const string CT_SplLedger_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> �d���`�[��� </summary>
        public const string CT_SplLedger_SlipKindNm = "SlipKindNm";
        /// <summary> ���_�R�[�h </summary>
        public const string CT_SplLedger_SectionCode = "SectionCode";
        /// <summary> �ԓ`�敪 </summary>
        public const string CT_SplLedger_DebitNoteDiv = "DebitNoteDiv";
        /// <summary> �ԍ��A���d���`�[�ԍ� </summary>
        public const string CT_SplLedger_DebitNLnkSuppSlipNo = "DebitNLnkSuppSlipNo";
        /// <summary> �d���`�[�敪 </summary>
        public const string CT_SplLedger_SupplierSlipCd = "SupplierSlipCd";
        /// <summary> �d�����i�敪 </summary>
        public const string CT_SplLedger_StockGoodsCd = "StockGoodsCd";
        /// <summary> �d�����_�R�[�h </summary>
        public const string CT_SplLedger_StockSectionCd = "StockSectionCd";
        /// <summary> �d���v�㋒�_�R�[�h </summary>
        public const string CT_SplLedger_StockAddUpSectionCd = "StockAddUpSectionCd";
        /// <summary> ���͓� </summary>
        public const string CT_SplLedger_InputDay = "InputDay";
        /// <summary> ���ד� </summary>
        public const string CT_SplLedger_ArrivalGoodsDay = "ArrivalGoodsDay";
        /// <summary> �d���� </summary>
        public const string CT_SplLedger_StockDate = "StockDate";
        /// <summary> �d���v����t </summary>
        public const string CT_SplLedger_StockAddUpADate = "StockAddUpADate";
        /// <summary> �d�����R�[�h�敪 </summary>
        public const string CT_SplLedger_StockRecordCd = "StockRecordCd";
        /// <summary> �d�����͎҃R�[�h </summary>
        public const string CT_SplLedger_StockInputCode = "StockInputCode";
        /// <summary> �d�����͎Җ��� </summary>
        public const string CT_SplLedger_StockInputName = "StockInputName";
        /// <summary> �d���S���҃R�[�h </summary>
        public const string CT_SplLedger_StockAgentCode = "StockAgentCode";
        /// <summary> �d���S���Җ��� </summary>
        public const string CT_SplLedger_StockAgentName = "StockAgentName";
        /// <summary> �x����R�[�h </summary>
        public const string CT_SplLedger_PayeeCode = "PayeeCode";
        /// <summary> �x���旪�� </summary>
        public const string CT_SplLedger_PayeeSnm = "PayeeSnm";
        /// <summary> �d����R�[�h </summary>
        public const string CT_SplLedger_SupplierCd = "SupplierCd";
        /// <summary> �d���於1 </summary>
        public const string CT_SplLedger_SupplierNm1 = "SupplierNm1";
        /// <summary> �d���於2 </summary>
        public const string CT_SplLedger_SupplierNm2 = "SupplierNm2";
        /// <summary> �d���旪�� </summary>
        public const string CT_SplLedger_SupplierSnm = "SupplierSnm";
        /// <summary> �d�����z���v </summary>
        public const string CT_SplLedger_StockTotalPrice = "StockTotalPrice";
        /// <summary> �d�����z���v </summary>
        public const string CT_SplLedger_StockSubttlPrice = "StockSubttlPrice";
        /// <summary> �d�����z����Ŋz </summary>
        public const string CT_SplLedger_StockPriceConsTax = "StockPriceConsTax";
        /// <summary> �����`�[�ԍ� </summary>
        public const string CT_SplLedger_PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary> �d���`�[���l1 </summary>
        public const string CT_SplLedger_SupplierSlipNote1 = "SupplierSlipNote1";
        /// <summary> �d���`�[���l2 </summary>
        public const string CT_SplLedger_SupplierSlipNote2 = "SupplierSlipNote2";
        /// <summary> �t�n�d���}�[�N�P </summary>
        public const string CT_SplLedger_UoeRemark1 = "UoeRemark1";
        /// <summary> �t�n�d���}�[�N�Q </summary>
        public const string CT_SplLedger_UoeRemark2 = "UoeRemark2";
        //�ȉ��͎x���`�[�̃f�[�^
        /// <summary> �x�����z </summary>
        public const string CT_SplLedger_Payment = "Payment";
        /// <summary> �L������ </summary>
        public const string CT_SplLedger_ValidityTerm = "ValidityTerm";
        //�ȉ�����p
        /// <summary> �x���cor���|�cstring </summary>
        public const string CT_SplLedger_SlitTitle = "SlitTitle";
        /// <summary> �d�����z����Ŋz </summary>
        public const string CT_SplLedger_Balance = "Balance";
        /// <summary> �x���p���z�敪�� </summary>
        public const string CT_SplLedger_GoodsName = "GoodsNameMny";
        /// <summary> �x���p���z�敪 </summary>
        public const string CT_SplLedger_GoodsDiv = "GoodsDivMny";
        #endregion

        #region �������׃J�������(����)
        /// <summary> ��ƃR�[�h </summary>
        public const string CT_DtlLedger_EnterpriseCode = "EnterpriseCode";
        /// <summary> �v���(���) </summary>
        public const string CT_DtlLedger_AddUpDate = "AddUpDate";
        /// <summary> �d���`�� </summary>
        public const string CT_DtlLedger_SupplierFormal = "SupplierFormal";
        /// <summary> �d���`�[�ԍ� </summary>
        public const string CT_DtlLedger_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> �d���`�[��� </summary>
        public const string CT_DtlLedger_SlipKindNm = "SlipKindNm";
        /// <summary> ���_�R�[�h </summary>
        public const string CT_DtlLedger_SectionCode = "SectionCode";
        /// <summary> �ԓ`�敪 </summary>
        public const string CT_DtlLedger_DebitNoteDiv = "DebitNoteDiv";
        /// <summary> �ԍ��A���d���`�[�ԍ� </summary>
        public const string CT_DtlLedger_DebitNLnkSuppSlipNo = "DebitNLnkSuppSlipNo";
        /// <summary> �d���`�[�敪 </summary>
        public const string CT_DtlLedger_SupplierSlipCd = "SupplierSlipCd";
        /// <summary> �d�����i�敪 </summary>
        public const string CT_DtlLedger_StockGoodsCd = "StockGoodsCd";
        /// <summary> �d�����_�R�[�h </summary>
        public const string CT_DtlLedger_StockSectionCd = "StockSectionCd";
        /// <summary> �d���v�㋒�_�R�[�h </summary>
        public const string CT_DtlLedger_StockAddUpSectionCd = "StockAddUpSectionCd";
        /// <summary> ���͓� </summary>
        public const string CT_DtlLedger_InputDay = "InputDay";
        /// <summary> ���ד� </summary>
        public const string CT_DtlLedger_ArrivalGoodsDay = "ArrivalGoodsDay";
        /// <summary> �d���� </summary>
        public const string CT_DtlLedger_StockDate = "StockDate";
        /// <summary> �d���v����t </summary>
        public const string CT_DtlLedger_StockAddUpADate = "StockAddUpADate";
        /// <summary> �d�����͎҃R�[�h </summary>
        public const string CT_DtlLedger_StockInputCode = "StockInputCode";
        /// <summary> �d�����͎Җ��� </summary>
        public const string CT_DtlLedger_StockInputName = "StockInputName";
        /// <summary> �d���S���҃R�[�h </summary>
        public const string CT_DtlLedger_StockAgentCode = "StockAgentCode";
        /// <summary> �d���S���Җ��� </summary>
        public const string CT_DtlLedger_StockAgentName = "StockAgentName";
        /// <summary> �x����R�[�h </summary>
        public const string CT_DtlLedger_PayeeCode = "PayeeCode";
        /// <summary> �x���旪�� </summary>
        public const string CT_DtlLedger_PayeeSnm = "PayeeSnm";
        /// <summary> �d����R�[�h </summary>
        public const string CT_DtlLedger_SupplierCd = "SupplierCd";
        /// <summary> �d���惌�R�[�h�敪 </summary>
        public const string CT_DtlLedger_StockRecordCd = "StockRecordCd";
        /// <summary> �d���於1 </summary>
        public const string CT_DtlLedger_SupplierNm1 = "SupplierNm1";
        /// <summary> �d���於2 </summary>
        public const string CT_DtlLedger_SupplierNm2 = "SupplierNm2";
        /// <summary> �d���旪�� </summary>
        public const string CT_DtlLedger_SupplierSnm = "SupplierSnm";
        /// <summary> �d�����z���v </summary>
        public const string CT_DtlLedger_StockTotalPrice = "StockTotalPrice";
        /// <summary> �d�����z���v </summary>
        public const string CT_DtlLedger_StockSubttlPrice = "StockSubttlPrice";
        /// <summary> �d�����z����Ŋz </summary>
        public const string CT_DtlLedger_StockPriceConsTax = "StockPriceConsTax";
        /// <summary> �����`�[�ԍ� </summary>
        public const string CT_DtlLedger_PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary> �d���`�[���l1 </summary>
        public const string CT_DtlLedger_SupplierSlipNote1 = "SupplierSlipNote1";
        /// <summary> �d���`�[���l2 </summary>
        public const string CT_DtlLedger_SupplierSlipNote2 = "SupplierSlipNote2";
        /// <summary> �t�n�d���}�[�N�P </summary>
        public const string CT_DtlLedger_UoeRemark1 = "UoeRemark1";
        /// <summary> �t�n�d���}�[�N�Q </summary>
        public const string CT_DtlLedger_UoeRemark2 = "UoeRemark2";
        /// <summary> �d���s�ԍ� </summary>
        public const string CT_DtlLedger_StockRowNo = "StockRowNo";
        /// <summary> ���ʒʔ� </summary>
        public const string CT_DtlLedger_CommonSeqNo = "CommonSeqNo";
        /// <summary> �d�����גʔ� </summary>
        public const string CT_DtlLedger_StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary> ���i�ԍ� </summary>
        public const string CT_DtlLedger_GoodsNo = "GoodsNo";
        /// <summary> ���i���� </summary>
        public const string CT_DtlLedger_GoodsName = "GoodsName";
        /// <summary> ���i���̃J�i </summary>
        public const string CT_DtlLedger_GoodsNameKana = "GoodsNameKana";
        /// <summary> �̔���R�[�h </summary>
        public const string CT_DtlLedger_SalesCustomerCode = "SalesCustomerCode";
        /// <summary> �̔��旪�� </summary>
        public const string CT_DtlLedger_SalesCustomerSnm = "SalesCustomerSnm";
        /// <summary> �d���� </summary>
        public const string CT_DtlLedger_StockCount = "StockCount";
        /// <summary> �d���P���i�Ŕ��C�����j </summary>
        public const string CT_DtlLedger_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> �d�����z�i�Ŕ����j </summary>
        public const string CT_DtlLedger_StockPriceTaxExc = "StockPriceTaxExc";
        /// <summary> �d�����z����Ŋz </summary>
        public const string CT_DtlLedger_Dtl_StockPriceConsTax = "Dtl_StockPriceConsTax";
        //�ȉ��x���`�[
        /// <summary> �x�����z </summary>
        public const string CT_DtlLedger_Payment = "Payment";
        /// <summary> �L������ </summary>
        public const string CT_DtlLedger_ValidityTerm = "ValidityTerm";
        //�ȉ�����p
        /// <summary> �x���cor���|�cstring </summary>
        public const string CT_DtlLedger_SlitTitle = "SlitTitle";
        /// <summary> �c�� </summary>
        public const string CT_DtlLedger_Balance = "Balance";
        #endregion

        # endregion
        #region Private Static Member
        /// <summary>�x���cor���|�c���[�h</summary>
        private static int _imode = 0;
        /// <summary>����敪</summary>
        private static int _printDiv = 0;

        ///// <summary>�x���c�������f�[�^�Z�b�g</summary>
        //private static DataSet _payBalanceDs;

        ///// <summary>���|�c�������f�[�^�Z�b�g</summary>
        //private static DataSet _accPayBalanceDs;

        /// <summary>�����f�[�^�Z�b�g</summary>
		private static DataSet _stockLedgerDataSet = null;

		/// <summary>�����`�[�f�[�^�e�[�u��</summary>
		private static DataTable _stockLedgerSlipDataTable = null;

		/// <summary>�����`�[��ʗp�f�[�^�r���[</summary>
		private static DataView _stockLedgerSlipDataView = null;

        /// <summary>�������׃f�[�^�e�[�u��</summary>
        private static DataTable _stockLedgerDtlDataTable = null;

        /// <summary>�������׉�ʗp�f�[�^�r���[</summary>
        private static DataView _stockLedgerDtlDataView = null;

        /// <summary>�����x���`�[�f�[�^�e�[�u��</summary>
        private static DataTable _stockLedgerPaymentDataTable = null;

        ///// <summary>�����x���`�[��ʗp�f�[�^�r���[</summary>
        //private static DataView _stockLedgerPaymentDataView = null;

        ///// <summary>�����c���f�[�^�e�[�u��</summary>
        //private static DataTable _stockLedgerBlanceDataTable = null;

        ///// <summary>�����c����ʗp�f�[�^�r���[</summary>
        //private static DataView _stockLedgerBlanceDataView = null;

		/// <summary>�d������z�f�[�^�e�[�u��</summary>
		private static DataTable _suplierPayDataTable = null;

        ///// <summary>�d������z�f�[�^�e�[�u��(����p)</summary>
        //private static DataTable _suplierPayPrintDataTable = null;

		/// <summary>�d������z�f�[�^�r���[</summary>
        private static DataView _suplierPayDataView = null;

        /// <summary>�d������z�f�[�^�r���[(����p)</summary>
        private static DataView _suplierPayPrintDataView = null;

        /// <summary>�x���`�[�e�[�u��</summary>
        private static Hashtable _paymentSlpTable = null;

		/// <summary>�������Ӑ���</summary>
		private static Hashtable _stockLedgerSupplierInfoTable = null;
       
		/// <summary>���͈�(�J�n)</summary>
		private static DateTime _startTtlAddUpDateSpan = DateTime.MinValue;

		/// <summary>���͈�(�I��)</summary>
		private static DateTime _endTtlAddUpDateSpan = DateTime.MinValue;

		/// <summary>�v��N����(�J�n)</summary>
		private static DateTime _startAddUpDate = DateTime.MinValue;

		/// <summary>�v��N����(�I��)</summary>
		private static DateTime _endAddUpDate = DateTime.MinValue;

		/// <summary>���_�e�[�u���擾�p</summary>
		private static Hashtable _sectionTable = null;

		/// <summary>���_�R�[�h���X�g</summary>
		private static ArrayList _secCodeList = null;
      
		/// <summary>�����_�R�[�h</summary>
		private static string _mySectionCode = string.Empty;

		/// <summary>�{�Ћ@�\�L��[true:�{�Ћ@�\,false:���_�@�\]</summary>
		private static bool _isMainOfficeFunc = false;

		/// <summary>�\���Ώۋ��_�R�[�h</summary>
		private static string _targetSectionCode = string.Empty;

		/// <summary>���_���擾���i</summary>
		private static SecInfoAcs _secInfoAcs = null;

		/// <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
		private static PrtOutSet _prtOutSet = null;

		/// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
		private static PrtOutSetAcs _prtOutSetAcs = null;

		/// <summary>�S�̍��ڕ\���ݒ�f�[�^�N���X</summary>
		private static AlItmDspNm _alItmDspNmData = null;

		/// <summary>�S�̍��ڕ\���ݒ�f�[�^�N���X</summary>
		private static AlItmDspNmAcs _alItmDspNmAcs = null;

        /// <summary>�d����x�����擾�A�N�Z�X�N���X</summary>
		private static GetSuplierPayAcs _getSuplierPayAcs = null;

        /// <summary>�d���攃�|���擾�A�N�Z�X�N���X</summary>
		private static GetSuplAccAcs _getSuplAccAcs = null;

        /// <summary>�x�������擾�����[�g</summary>
        private static ISuplierPayInfGetDB _suplierPayInfGetDB = null;

        /// <summary>���|�����擾�����[�g</summary>
        private static ISuplAccInfGetDB _suplAccInfGetDB = null;

        ///// <summary>�d���挳���i�d���`�[�j���o���ʃf�[�^�e�[�u��(����p)</summary>
        //private static DataTable _suplierPayInfGetDt = null;

        ///// <summary>�d���挳���i�d���`�[�j���o���ʃf�[�^�r���[(����p)</summary>
        //private static DataView _suplierPayInfGetDv = null;

		#endregion
        //�Ƃ肠����ok�B��ŏC������\��
		#region Property
        ///// <summary>�x���c�������f�[�^�Z�b�g(�ǂݎ���p)</summary>
        //public DataSet PayBalanceDs
        //{
        //    get { return _payBalanceDs; }
        //}

        ///// <summary>���|�c�������f�[�^�Z�b�g(�ǂݎ���p)</summary>
        //public DataSet AccPayBalanceDs
        //{
        //    get { return _accPayBalanceDs; }
        //}

		/// <summary>�����f�[�^�Z�b�g�v���p�e�B</summary>
		public DataSet CsLedgerDataSet
		{
			get { return _stockLedgerDataSet; }
		}

		/// <summary>�����`�[�f�[�^�e�[�u���v���p�e�B</summary>
		public DataTable CsLedgerSlipDataTable
		{
			get { return _stockLedgerSlipDataTable; }
		}

		/// <summary>�����`�[�f�[�^�r���[�v���p�e�B</summary>
		public DataView CsLedgerSlipDataView
		{
			get { return _stockLedgerSlipDataView; }
		}

        /// <summary>�������׃f�[�^�e�[�u���v���p�e�B</summary>
        public DataTable CsLedgerDtlDataTable
        {
            get { return _stockLedgerDtlDataTable; }
        }

        /// <summary>�������׃f�[�^�r���[�v���p�e�B</summary>
        public DataView CsLedgerDtlDataView
        {
            get { return _stockLedgerDtlDataView; }
        }

        /// <summary>�������׃f�[�^�e�[�u���v���p�e�B</summary>
        public DataTable CsLedgerPaymentDataTable
        {
            get { return _stockLedgerPaymentDataTable; }
        }

        ///// <summary>�������׃f�[�^�r���[�v���p�e�B</summary>
        //public DataView CsLedgerPaymentDataView
        //{
        //    get { return _stockLedgerPaymentDataView; }
        //}

        ///// <summary>�����c���f�[�^�e�[�u���v���p�e�B</summary>
        //public DataTable CsLedgerBlanceDataTable
        //{
        //    get { return _stockLedgerBlanceDataTable; }
        //}

        ///// <summary>�����c���f�[�^�r���[�v���p�e�B</summary>
        //public DataView CsLedgerBlanceDataView
        //{
        //    get { return _stockLedgerBlanceDataView; }
        //}

		/// <summary>�d������z�f�[�^�e�[�u���v���p�e�B</summary>
		public DataTable SuplierPayDataTable
		{
			get { return _suplierPayDataTable; }
		}

        ///// <summary>�d������z�f�[�^�e�[�u��(����p)�v���p�e�B</summary>
        //public DataTable SuplierPayPrintDataTable
        //{
        //    get { return _suplierPayPrintDataTable; }
        //}

        /// <summary>�x���`�[�f�[�^�e�[�u���v���p�e�B</summary>
        public Hashtable PaymentSlpTable
        {
            get { return _paymentSlpTable; }
        }

		/// <summary>�d������z�f�[�^�r���[�v���p�e�B</summary>
		public DataView SuplierPayDataView
		{
			get { return _suplierPayDataView; }
		}

        /// <summary>�d������z�f�[�^�r���[(����p)�v���p�e�B</summary>
        public DataView SuplierPayPrintDataView
        {
            get { return _suplierPayPrintDataView; }
        }

		/// <summary>���͈́i�J�n�j</summary>
		public DateTime TtlAddUpDateSpanStart
		{
			get { return _startTtlAddUpDateSpan; }
		}

		/// <summary>���͈́i�I���j</summary>
		public DateTime TtlAddUpDateSpanEnd
		{
			get { return _endTtlAddUpDateSpan; }
		}

		/// <summary>�v��N�����i�J�n�j</summary>
		public DateTime AddUpDateStrart
		{
			get { return _startAddUpDate; }
		}

		/// <summary>�v��N�����i�I���j</summary>
		public DateTime AddUpDateEnd
		{
			get { return _endAddUpDate; }
		}

		/// <summary>���_��񃊃X�g</summary>
		public Hashtable SectionTable
		{
			get { return _sectionTable; }
		}

		/// <summary>���_�R�[�h���X�g</summary>
		public ArrayList SecCodeList
		{
			get { return _secCodeList; }
		}

        ///// <summary>�d���挳���i�d�����ׁj�f�[�^�r���[�v���p�e�B</summary>
        //public DataView SuplierPayInfGetDataView
        //{
        //    get { return _suplierPayInfGetDv; }
        //}

		#endregion

		#region Public Method

        #region �����ݒ���Ǎ�
        /// <summary>
		/// �����ݒ���Ǎ�
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ���̓Ǎ����s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public int InitSettingDataRead(string enterpriseCode, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = string.Empty;

			try
			{
			    	// �����_�R�[�h���ݒ肳��Ă��Ȃ��ꍇ
				if (_mySectionCode == string.Empty)
				{
					message = "���O�C���S���҂̏������_���ݒ肳��Ă��܂���\n\r���_�ݒ���s���ċN�����Ă�������";
					return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
				}

				// ���_���擾
				_sectionTable.Clear();
				_secCodeList.Clear();

				foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
				{			
					_sectionTable.Add(secInfoSet.SectionCode, secInfoSet.Clone());
					_secCodeList.Add(secInfoSet.SectionCode);
				}
				_secCodeList.Sort(new SecInfoKey0());

				// �x���c���\�����_�擾
				status = GetOwnSeCtrlCode(_mySectionCode, SecInfoAcs.CtrlFuncCode.PayBlcDispSecCd, out _targetSectionCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						message = String.Format("���_�R�[�h �u{0}�v�̎x���c���\�����_���ݒ肳��Ă��܂���", _mySectionCode)
											+ "\n\r���_����ݒ���s���ċN�����Ă�������";
						return status;
					}
					default:
					{
						message = String.Format("���_�R�[�h �u{0}�v�̋��_������̎擾�Ɏ��s���܂���", _mySectionCode)
											+ "\n\r���_����ݒ���s���ċN�����Ă�������";
						return status;
					}
				}

				// �{�Ћ@�\�L��
				_isMainOfficeFunc = (_secInfoAcs.GetMainOfficeFuncFlag(_mySectionCode) == 1);
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return status;
        }

        #endregion

        #region ���[�o�͐ݒ�Ǎ�
        /// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			prtOutSet = null;
			message = string.Empty;

			// Static�ɕێ��ς݂̏ꍇ
			if (_prtOutSet != null)
			{
				prtOutSet = _prtOutSet.Clone();
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			try
			{
				// ���[�o�͐ݒ�A�N�Z�X�N���X
				if (_prtOutSetAcs == null) _prtOutSetAcs = new PrtOutSetAcs();

				status = _prtOutSetAcs.Read(out _prtOutSet, LoginInfoAcquisition.EnterpriseCode, _mySectionCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						prtOutSet = _prtOutSet.Clone();
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						prtOutSet = new PrtOutSet();
						break;
					}
					default:
					{
						prtOutSet = new PrtOutSet();
						message = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return status;
        }

        #endregion

        #region �S�̍��ڕ\���ݒ�Ǎ�
        /// <summary>
		/// �S�̍��ڕ\���ݒ�f�[�^�N���X�擾
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�S�̍��ڕ\���ݒ�f�[�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : �S�̍��ڕ\���ݒ�f�[�^�N���X�̎擾���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public AlItmDspNm GetAlItmDspNm(string enterpriseCode)
		{
			AlItmDspNm alItmDspNm = null;

			// Static�ɂ��łɂ���΂����Ԃ�
			if (_alItmDspNmData != null)
			{
				alItmDspNm = _alItmDspNmData.Clone();
			}
			else
			{
				this.ReadAlItmDspNm(out alItmDspNm, enterpriseCode);
			}

			return alItmDspNm;
		}

		/// <summary>
		/// �S�̍��ڕ\���ݒ�Ǎ���
		/// </summary>
		/// <param name="alItmDspNm">�S�̍��ڕ\���ݒ�f�[�^�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>0:����,4:�f�[�^����,���̑�:�ُ�</returns>
		/// <remarks>
		/// <br>Note       : �S�̍��ڕ\���ݒ�f�[�^�N���X�̎擾���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private int ReadAlItmDspNm(out AlItmDspNm alItmDspNm, string enterpriseCode)
		{
			if (_alItmDspNmAcs == null) _alItmDspNmAcs = new AlItmDspNmAcs();
			
			// �S�̍��ڕ\���ݒ�̎擾 
			int status = _alItmDspNmAcs.ReadStatic(out alItmDspNm, enterpriseCode);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					break;
				}
				default:
				{
					break;
				}
			}
			return status;
        }

        #endregion

        #region ���_���擾
        /// <summary>
		/// �{�Ћ@�\�L���擾
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>true: �{��,false: ���_</returns>
		/// <remarks>
		/// <br>Note       : �{�Ћ@�\�L���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public bool CheckMainOfficeFunc(string sectionCode)
		{
			return (_secInfoAcs.GetMainOfficeFuncFlag(sectionCode) == 1);
		}

		/// <summary>
		/// ����@�\���_�擾
		/// </summary>
		/// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
		/// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
		/// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �Y�����_�̋��_������̓Ǎ����s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode)
		{
			// �Ώې��䋒�_�̏����l�͎����_		
			ctrlSectionCode = sectionCode;				

			SecInfoSet secInfoSet;
			int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (secInfoSet != null)
				{
					ctrlSectionCode = secInfoSet.SectionCode;
				}
				else
				{
					// ���_����ݒ肪����Ă��Ȃ�
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}

			return status;
        }

        #endregion
        #region �����f�[�^����������
        /// <summary>
		/// �����f�[�^����������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static�������������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
			_startAddUpDate			= new DateTime(1, 1, 1);
			_endAddUpDate			= new DateTime(1, 1, 1);
			_startTtlAddUpDateSpan	= new DateTime(1, 1, 1);
			_endTtlAddUpDateSpan	= new DateTime(1, 1, 1);

			// �e�[�u���s������
			_stockLedgerSupplierInfoTable.Clear();
            //_stockLedgerBlanceDataTable.Rows.Clear();
			_stockLedgerSlipDataTable.Rows.Clear();
            _stockLedgerDtlDataTable.Rows.Clear();
			_suplierPayDataTable.Rows.Clear();
			//_suplierPayPrintDataTable.Rows.Clear();
            _paymentSlpTable.Clear();

			// �t�B���^�[����������
			_suplierPayDataView.RowFilter		= string.Empty;
			//_suplierPayPrintDataView.RowFilter	= string.Empty;
			_stockLedgerSlipDataView.RowFilter	= string.Empty;
            //_stockLedgerBlanceDataView.RowFilter = string.Empty;
            _stockLedgerDtlDataView.RowFilter   = string.Empty;
            //_stockLedgerPaymentDataView.RowFilter = string.Empty;

			// �����\�[�g�����ݒ�
            _suplierPayDataView.Sort = COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;
            //_suplierPayPrintDataView.Sort	= COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;
            //_stockLedgerBlanceDataView.Sort = COL_BlanceLedger_AddUpSecCode + "," + COL_BlanceLedger_PayeeCode + "," + COL_BlanceLedger_AddUpDate;
            _stockLedgerSlipDataView.Sort = CT_SplLedger_PayeeCode + "," + CT_SplLedger_StockRecordCd + "," + CT_SplLedger_StockAddUpADate + "," + CT_SplLedger_SupplierSlipNo;
            _stockLedgerDtlDataView.Sort = CT_DtlLedger_PayeeCode + "," + CT_DtlLedger_StockAddUpADate + "," + CT_DtlLedger_StockRecordCd + "," + CT_DtlLedger_SupplierSlipNo;
 
        }

        #endregion

        #region �����f�[�^�擾����(Read)
        /// <summary>
		/// �����f�[�^�擾����
		/// </summary>
		/// <param name="mode">�Ǎ����[�h[0:�x��,1:���|]</param>
        /// <param name="printDiv">������[�h[1:����,1:�`�[]</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="startCustomerCode">�J�n���Ӑ�R�[�h</param>
        /// <param name="endCustomerCode">�I�����Ӑ�R�[�h</param>
        /// <param name="startYearMonth">�����͈�(�J�n)</param>
		/// <param name="endYearMonth">�����͈�(�I��)</param>
		/// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
        /// <param name="sectionCodeList">�Ώۋ��_�R�[�h���X�g(�S�Е��i�[)</param>
        /// <param name="isBufferClear">StaticMemory�������t���O[True:����������, False:���������Ȃ�]</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �Ώۓ��Ӑ�̌����f�[�^���擾���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2014/02/26 �c����</br>
        /// <br>           : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// </remarks>
        //public int Read(int mode, int realMode, string enterpriseCode, int supplierCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, bool isBufferClear, out string message)
        //public int Read(int mode,int printDiv, string enterpriseCode, int supplierCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, bool isBufferClear,out string message)
        public int Read(int mode,int printDiv, string enterpriseCode, int supplierCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, bool isBufferClear, int outMoneyDiv, out string message)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            message = string.Empty;

            _imode = mode;
            _printDiv = printDiv;

            // �S�Ђ�I��
            if ((sectionCodeList.Count == 1) && (sectionCodeList[0].ToString() == "0"))
            {
                sectionCodeList = null;
            }

            try
            {
                // �ÓI�̈擯��������
                lock (typeof(SupplierLedgerAcs))
                {
                    // StaticMemory������
                    if (isBufferClear)
                    {
                        InitializeCustomerLedger();
                    }

                    // --- ADD 2012/10/02 ---------->>>>>
                    // �I�v�V�����R�[�h�̎d���摍�����p�ۂ��擾
                    Broadleaf.Application.Remoting.ParamData.PurchaseStatus sumSuppPs;
                    sumSuppPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
                    // --- ADD 2012/10/02 ----------<<<<<

                    if (mode == (int)Mode.Shr)
                    {
                        // �f�[�^�擾�����A�p�����[�^�[�ݒ�
                        Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetParameter param = new Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetParameter();
                        param.AddUpSecCodeList = sectionCodeList;
                        param.EnterpriseCode = enterpriseCode;
                        param.StartAddUpYearMonth = TDateTime.LongDateToDateTime(int.Parse(startYearMonth.ToString() + "02"));
                        param.EndAddUpYearMonth = TDateTime.LongDateToDateTime(int.Parse(endYearMonth.ToString() + "01"));
                        param.SupplierCd = supplierCode;
                        param.StartSupplierCd = startCustomerCode;
                        param.EndSupplierCd = endCustomerCode;

                        // --- ADD 2012/10/02 ---------->>>>>
                        if (sumSuppPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                        {
                            // �d���摍�����p�ۂ𗘗p��
                            param.SumSuppEnable = 1;
                        }
                        else
                        {
                            // �d���摍�����p�ۂ𗘗p�s��
                            param.SumSuppEnable = 0;
                        }
                        // --- ADD 2012/10/02 ----------<<<<<
                        // �d����x���֘A�f�[�^�擾                      
                        //status = GetSupplierPayInfo(printDiv, param);// DEL 2014/02/26 �c���� Redmine#42188
                        status = GetSupplierPayInfo(printDiv, param, outMoneyDiv);// ADD 2014/02/26 �c���� Redmine#42188
                    }
                    else
                        if (mode == (int)Mode.Kai)
                        {
                            // �f�[�^�擾�����A�p�����[�^�[�ݒ�
                            Broadleaf.Application.Remoting.ParamData.SuplAccInfGetParameter�@param = new Broadleaf.Application.Remoting.ParamData.SuplAccInfGetParameter();
                            param.AddUpSecCodeList = sectionCodeList;
                            param.EnterpriseCode = enterpriseCode;
                            param.StartAddUpYearMonth = TDateTime.LongDateToDateTime(int.Parse(startYearMonth.ToString() + "02"));
                            param.EndAddUpYearMonth = TDateTime.LongDateToDateTime(int.Parse(endYearMonth.ToString() + "01"));
                            param.SupplierCd = supplierCode;
                            param.StartSupplierCd = startCustomerCode;
                            param.EndSupplierCd = endCustomerCode;

                            // --- ADD 2012/10/02 ---------->>>>>
                            if (sumSuppPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                            {
                                // �d���摍�����p�ۂ𗘗p��
                                param.SumSuppEnable = 1;
                            }
                            else
                            {
                                // �d���摍�����p�ۂ𗘗p�s��
                                param.SumSuppEnable = 0;
                            }
                            // --- ADD 2012/10/02 ----------<<<<<

                            // �d���攃�|�֘A�f�[�^�擾
                            //status = GetSupplierAccPayInfo(printDiv,param);// DEL 2014/02/26 �c���� Redmine#42188
                            status = GetSupplierAccPayInfo(printDiv, param, outMoneyDiv);// ADD 2014/02/26 �c���� Redmine#42188
                        }
                }
            }

            #region [���̂��]
            //try
            //{
            //    // �ÓI�̈擯��������
            //    lock (typeof(SupplierLedgerAcs))
            //    {
            //        // StaticMemory������
            //        if (isBufferClear)
            //        {
            //            InitializeCustomerLedger();
            //        }

            //        if (mode == (int)Mode.Shr)
            //        {
            //            // �d����x���֘A�f�[�^�擾                      
            //            status = GetSupplierPayInfo(enterpriseCode, customerCode, startCustomerCode, endCustomerCode, startYearMonth, endYearMonth, sectionCode, sectionCodeList, realMode);
            //        }
            //        else
            //            if (mode == (int)Mode.Kai)
            //            {
            //                // �d���攃�|�֘A�f�[�^�擾
            //                status = GetSupplierAccPayInfo(enterpriseCode, customerCode, startCustomerCode, endCustomerCode, startYearMonth, endYearMonth, sectionCode, sectionCodeList, realMode);
            //            }
            //    }
            //}
            #endregion

            catch (CsLedgerException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            
			return status;
        }

        #endregion

        #region �����d������(���Ӑ斈)(static memory)�̎擾
        /// <summary>
		/// �����d������(static memory)�̎擾
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>�����d������f�[�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : �d��������擾���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public StockLedgerSupplier SupplierInfo(int customerCode)
		{
			if (_stockLedgerSupplierInfoTable.Contains(customerCode))
			{
				StockLedgerSupplier cs = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[customerCode];
				return cs.Clone();
			}
			else
			{
				return new StockLedgerSupplier();
			}
        }

        #endregion

        #region �����d������(���Ӑ� + �v��� + ���_��)(static memory)�̎擾

        /// <summary>
		/// �����d������(static memory)�̎擾
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="addUpdate">�v���</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>�����d������f�[�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : �d��������擾���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public StockLedgerSupplier SupplierInfo(int customerCode,int addUpdate,string sectionCode)
		{
            //�L�[�쐬(���Ӑ�+�v���+���_)
            string key = customerCode.ToString() + "_" + addUpdate.ToString() + "_" + sectionCode;
			if (_stockLedgerSupplierInfoTable.Contains(key))
			{
				StockLedgerSupplier supInfo = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[key];
				return supInfo.Clone();
			}
			else
			{
				return new StockLedgerSupplier();
			}
        }

        #endregion

        #region �����d������z���v���(static memory)�̎擾
        /// <summary>
        /// �����d������z���v���(static memory)�̎擾
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="sectionCode">�w�苒�_�R�[�h</param>
        /// <param name="stockLedgerPay">�d���挳���x�����z���v���</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �d������z�̍��v�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool GetTotalSuplierPay(int customerCode, string sectionCode, out StockLedgerPay stockLedgerPay, out string msg)
        {
            msg = string.Empty;
            stockLedgerPay = null;
            int totalCleateCounter = 0;
            ArrayList suplierPaysList;

            if (SearchSuplierPayToArray(customerCode, sectionCode, out suplierPaysList, out msg))
            {
                stockLedgerPay = new StockLedgerPay();

                for (int index = 0; index < suplierPaysList.Count; index++)
                {
                    StockLedgerPay wkStockLedgePay = (StockLedgerPay)suplierPaysList[index];

                    // �����f�[�^�͊ӂɉ����Ȃ�
                    if (wkStockLedgePay.CloseFlag == (int)CloseFlagState.NotClose)
                        continue;

                    // ���v�^�u�쐬���f�J�E���^�[
                    totalCleateCounter++;

                    if (index == 0)
                    {
                        //���_�R�[�h���Ԃ�
                        stockLedgerPay.AddUpSecCode = wkStockLedgePay.AddUpSecCode;
                        stockLedgerPay.PayeeCode = wkStockLedgePay.PayeeCode;
                        stockLedgerPay.CustomerCode = wkStockLedgePay.CustomerCode;

                        // ���Ӑ�R�[�h
                        // 3��O�c��,2��O�c��,�O��c���͐擪���R�[�h�̋��z���
                        stockLedgerPay.StockTtl3TmBfBlPay = wkStockLedgePay.StockTtl3TmBfBlPay;	        // �d��3��O�c��
                        stockLedgerPay.StockTtl2TmBfBlPay = wkStockLedgePay.StockTtl2TmBfBlPay;	        // �d��2��O�c��
                        stockLedgerPay.LastTimePayment = wkStockLedgePay.LastTimePayment;	            // �d���O���c��
                    }

                    stockLedgerPay.StockSlipCount += wkStockLedgePay.StockSlipCount;		        // �d���`�[����
                    stockLedgerPay.ReturnGoodsSlipCount += wkStockLedgePay.ReturnGoodsSlipCount;        // �ԕi�`�[����
                    stockLedgerPay.TotalSlipCount += wkStockLedgePay.TotalSlipCount;		        // �`�[�������v

                    stockLedgerPay.ThisTimeStockPrice += wkStockLedgePay.ThisTimeStockPrice;	        // ����d���z
                    stockLedgerPay.ThisTimeStockPrcTax += wkStockLedgePay.ThisTimeStockPrcTax;	        // ����d�������
                    stockLedgerPay.OfsThisTimeStock += wkStockLedgePay.OfsThisTimeStock;            // ���E��z    
                    stockLedgerPay.OfsThisStockTax += wkStockLedgePay.OfsThisStockTax;	            // ���E�����Ŋz
                    stockLedgerPay.ThisTimeStockPriceRgds += wkStockLedgePay.ThisTimeStockPriceRgds;	    // ����ԕi�z
                    stockLedgerPay.ThisTimeStockPriceTaxRgds += wkStockLedgePay.ThisTimeStockPriceTaxRgds;	// ����ԕi�����
                    stockLedgerPay.ThisTimePayNrml += wkStockLedgePay.ThisTimePayNrml;		        // �x���z

                }

                if (totalCleateCounter < 2)
                {
                    return false;
                }

                int listCount = suplierPaysList.Count;
                int afCalDemandIndex = 1;
                if (((StockLedgerPay)suplierPaysList[listCount - afCalDemandIndex]).CloseFlag == (int)CloseFlagState.NotClose &&
                    listCount > 1)
                    afCalDemandIndex = 2;
                else
                    // �ŏI���R�[�h�������߂̏ꍇ
                    // �ŏI���R�[�h�̈��O�̌v�Z�㐿�����z�����v�^�u�̌v�Z�㐿�����z�ɂȂ�
                    // �����������̈ꌬ�����Ȃ��ꍇ�͍Ō�̃��R�[�h���Ƃ邵���Ȃ�
                    afCalDemandIndex = 1;

                // �c��
                stockLedgerPay.StockTotalPayBalance = ((StockLedgerPay)suplierPaysList[listCount - afCalDemandIndex]).StockTotalPayBalance;
                //�ŏI�̌v�����߂�(���v�^�u���I�����ꂽ���Ɋӂɕ\�������]�ŕ����͂��̌��̐ݒ�ɂȂ�)
                stockLedgerPay.AddUpDate = ((StockLedgerPay)suplierPaysList[listCount - afCalDemandIndex]).AddUpDate; //�v���

                stockLedgerPay.StartDateSpan = TDateTime.DateTimeToLongDate(_startTtlAddUpDateSpan);		    // ���Ώۓ��t�͈́i�J�n�j
                stockLedgerPay.EndDateSpan = TDateTime.DateTimeToLongDate(_endTtlAddUpDateSpan);		    // ���Ώۓ��t�͈́i�I���j
                stockLedgerPay.CloseFlag = (int)CloseFlagState.Close;

                return true;
            }
            else
            {
                return false;

            }
        }

        #endregion

        #region �d���挳���p�Ӄf�[�^�z��擾
        /// <summary>
        /// �d���挳���p�Ӄf�[�^�z��擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockLedgerPays">�d���挳���p�Ӄf�[�^�z��</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �d���挳���p�Ӄf�[�^���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool SearchSuplierPayToList(string sectionCode, out StockLedgerPay[] stockLedgerPays, out string msg)
        {
            return SearchSuplierPayToList(0, sectionCode, out stockLedgerPays, out msg);
        }

        #endregion

        #region  �d���挳���p�Ӄf�[�^�z��擾(���Ӑ�w��)
        /// <summary>
        /// �d���挳���p�Ӄf�[�^�z��擾(���Ӑ�w��)
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockLedgerPays">�d���挳���p�Ӄf�[�^�z��</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �d���挳���p�Ӄf�[�^���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool SearchSuplierPayToList(int customerCode, string sectionCode, out StockLedgerPay[] stockLedgerPays, out string msg)
        {
            stockLedgerPays = null;
            ArrayList stockLedgerPayList;
            bool exist = SearchSuplierPayToArray(customerCode, sectionCode, out stockLedgerPayList, out msg);
            if (exist)
            {
                stockLedgerPays = (StockLedgerPay[])stockLedgerPayList.ToArray(typeof(StockLedgerPay));
            }
            return exist;
        }

        #endregion

        #region �d���挳���p�Ӄf�[�^�z��擾
        /// <summary>
        /// �d���挳���p�Ӄf�[�^���X�g�擾
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockLedgerPayList">�d���挳���p�Ӄf�[�^���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �d���挳���p�Ӄf�[�^���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool SearchSuplierPayToArray(string sectionCode, out ArrayList stockLedgerPayList, out string msg)
        {
            return SearchSuplierPayToArray(0, sectionCode, out stockLedgerPayList, out msg);
        }

        #endregion

        #region �d���挳���p�Ӄf�[�^���X�g�擾(���Ӑ�w��)
        /// <summary>
        /// �d���挳���p�Ӄf�[�^���X�g�擾(���Ӑ�w��)
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockLedgerPayList">�d���挳���p�Ӄf�[�^���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �d���挳���p�Ӄf�[�^���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool SearchSuplierPayToArray(int customerCode, string sectionCode, out ArrayList stockLedgerPayList, out string msg)
        {
            stockLedgerPayList = null;
            msg = string.Empty;

            //�d������z(��)�e�[�u��
            if (_suplierPayDataTable.Rows.Count > 0)
            {
                StringBuilder filter = new StringBuilder(String.Format("{0}='{1}'", COL_Spl_AddUpSecCode, sectionCode));

                // ���Ӑ�R�[�h���w�肳��Ă���ꍇ
                if (customerCode != 0) filter.Append(String.Format(" AND {0}={1}", COL_Spl_PayeeCode, customerCode));

                string sort = COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;

                // �d���挳���p�Ӄf�[�^���z��񃊃X�g�擾
                stockLedgerPayList = this.GetStockLedgerPayList(filter.ToString(), sort);

                return true;
            }
            else
            {
                msg = "���������܂���B";
                return false;
            }
        }

        #endregion

        #region �d���挳���p�Ӄf�[�^DataView�擾
        /// <summary>
		/// �d���挳���p�Ӄf�[�^DataView�擾
		/// </summary>
		/// <param name="sectionCode">�w�苒�_�R�[�h</param>
		/// <param name="dv">�d������zDataView</param>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : �d���挳���p�Ӄf�[�^���擾���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public bool GetStaticSuplierPayToDataView(string sectionCode, out DataView dv, out string msg)
		{
			dv = null;
			msg = "���������܂���B";

            //�d������z(��)�e�[�u��
			if (_suplierPayDataTable.Rows.Count > 0)
			{
				string filter = String.Format("{0}='{1}'", COL_Spl_AddUpSecCode, sectionCode);
				string sort = COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;

				dv = new DataView(_suplierPayDataTable, filter, sort, DataViewRowState.CurrentRows);

				if (dv.Count > 0) return true;
			}

			return false;
        }

        #endregion

        #region �������׏��t�B���^�����O����
        ///// <summary>
        ///// �������׏��t�B���^�����O����
        ///// </summary>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="startDate">�v��N����(�J�n)</param>
        ///// <param name="endDate">�v��N����(�I��)</param>
        ///// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : �������ׂ��w��̌v��N�����Ńt�B���^�����O���܂��B</br>
        ///// <br>Programmer : 20081 �D�c �E�l</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public void FilterAddUpDateCsLedgerSlip(int customerCode, int startDate, int endDate, string sectionCode)
        //{
        //    FilterAddUpDateCsLedgerSlip(customerCode, startDate, endDate, sectionCode, ref _stockLedgerSlipDataView);
        //}

        ///// <summary>
        ///// �������׏��t�B���^�����O����
        ///// </summary>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="startDate">�v��N����(�J�n)</param>
        ///// <param name="endDate">�v��N����(�I��)</param>
        ///// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : �������ׂ��w��̌v��N�����Ńt�B���^�����O���܂��B</br>
        ///// <br>Programmer : 20081 �D�c �E�l</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public void FilterAddUpDateCsLedgerDtl(int customerCode, int startDate, int endDate, string sectionCode)
        //{
        //    FilterAddUpDateCsLedgerDtl(customerCode, startDate, endDate, sectionCode, ref _stockLedgerDtlDataView);
        //}

        ///// <summary>
        ///// �������׏��t�B���^�����O����
        ///// </summary>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="startDate">�v��N����(�J�n)</param>
        ///// <param name="endDate">�v��N����(�I��)</param>
        ///// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        ///// <param name="dv">�f�[�^�r���[</param>
        ///// <remarks>
        ///// <br>Note       : �������ׂ��w��̌v��N�����Ńt�B���^�����O���܂��B</br>
        ///// <br>Programmer : 20081 �D�c �E�l</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public void FilterAddUpDateCsLedgerSlip(int customerCode, int startDate, int endDate, string sectionCode, ref DataView dv)
        //{
        //    StringBuilder filter = new StringBuilder();

        //    // ���Ӑ�R�[�h
        //    filter.Append(String.Format("{0}={1}", CT_SplLedger_PayeeCode, customerCode));

        //    // ���t�͈͂ɂ�锻�f
        //    if (startDate == endDate)
        //    {

        //        // �P���̏ꍇ
        //        filter.Append(String.Format(" AND {0}={1}", CT_SplLedger_AddUpDate, startDate));
        //        // ���_�w��
        //        filter.Append(String.Format(" AND {0}='{1}'", CT_SplLedger_AddUpSecCode, sectionCode));

        //    }
        //    else
        //    {
        //        // �������̏ꍇ
        //        //�������̏ꍇ�͊J�n���̑O��c���̂ݕ\������悤�ɂ���
        //        filter.Append(String.Format(" AND (({0}={1} AND {2}={3} AND {4}='{5}') OR ({6} IN ({7},{8}) AND {9}='{10}' AND {11} <= {12})",
        //            CT_SplLedger_BalanceCode, (int)BalanceCode.Balance,
        //            CT_SplLedger_AddUpDate, startDate.ToString(),
        //            CT_SplLedger_AddUpSecCode, sectionCode,
        //            CT_SplLedger_BalanceCode, (int)BalanceCode.Others, (int)BalanceCode.Carried,
        //            CT_SplLedger_AddUpSecCode, sectionCode,
        //            CT_SplLedger_AddUpADateInt, endDate));

        //        filter.Append(String.Format(" OR ({0}={1} AND {2}='{3}' AND {4} <= {5})",
        //                CT_SplLedger_BalanceCode, (int)BalanceCode.ConsTax,
        //                CT_SplLedger_AddUpSecCode, sectionCode,
        //                CT_SplLedger_AddUpADateInt, endDate));

        //        filter.Append(")");
        //    }

        //    dv.RowFilter = filter.ToString();
        //    // �c���v�Z����
        //    CalcBalance(ref dv);
        //}

        ///// <summary>
        ///// �������׏��t�B���^�����O����
        ///// </summary>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <param name="startDate">�v��N����(�J�n)</param>
        ///// <param name="endDate">�v��N����(�I��)</param>
        ///// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        ///// <param name="dv">�f�[�^�r���[</param>
        ///// <remarks>
        ///// <br>Note       : �������ׂ��w��̌v��N�����Ńt�B���^�����O���܂��B</br>
        ///// <br>Programmer : 20081 �D�c �E�l</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public void FilterAddUpDateCsLedgerDtl(int customerCode, int startDate, int endDate, string sectionCode, ref DataView dv)
        //{
        //    StringBuilder filter = new StringBuilder();

        //    // ���Ӑ�R�[�h
        //    filter.Append(String.Format("{0}={1}", CT_DtlLedger_PayeeCode, customerCode));

        //    // ���t�͈͂ɂ�锻�f
        //    if (startDate == endDate)
        //    {

        //        // �P���̏ꍇ
        //        filter.Append(String.Format(" AND {0}={1}", CT_DtlLedger_AddUpDate, startDate));
        //        // ���_�w��
        //        filter.Append(String.Format(" AND {0}='{1}'", CT_DtlLedger_AddUpSecCode, sectionCode));

        //    }
        //    else
        //    {
        //        // �������̏ꍇ
        //        //�������̏ꍇ�͊J�n���̑O��c���̂ݕ\������悤�ɂ���
        //        filter.Append(String.Format(" AND (({0}={1} AND {2}={3} AND {4}='{5}') OR ({6} IN ({7},{8}) AND {9}='{10}' AND {11} <= {12})",
        //            CT_DtlLedger_BalanceCode, (int)BalanceCode.Balance,
        //            CT_DtlLedger_AddUpDate, startDate.ToString(),
        //            CT_DtlLedger_AddUpSecCode, sectionCode,
        //            CT_DtlLedger_BalanceCode, (int)BalanceCode.Others, (int)BalanceCode.Carried,
        //            CT_DtlLedger_AddUpSecCode, sectionCode,
        //            CT_DtlLedger_AddUpADateInt, endDate));

        //        filter.Append(String.Format(" OR ({0}={1} AND {2}='{3}' AND {4} <= {5})",
        //                CT_DtlLedger_BalanceCode, (int)BalanceCode.ConsTax,
        //                CT_DtlLedger_AddUpSecCode, sectionCode,
        //                CT_DtlLedger_AddUpADateInt, endDate));

        //        filter.Append(")");
        //    }

        //    dv.RowFilter = filter.ToString();
        //}
        #endregion

        #endregion

        #region Private Method

        #region �d���挳���p�Ӄf�[�^���X�g�擾
        /// <summary>
        /// �d���挳���p�Ӄf�[�^���X�g�擾
        /// </summary>
        /// <param name="filter">�t�B���^</param>
        /// <param name="sort">�\�[�g</param>
        /// <returns>�d���挳���p�Ӄf�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note       : �����ɍ������d���挳���p�Ӄf�[�^�����X�g�ŕԂ��܂��B
        ///					 �����ɍ������̂��P���������ꍇ�ɂ͋󃌃R�[�h���P���ǉ����ĕԂ��܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private ArrayList GetStockLedgerPayList(string filter, string sort)
        {
            ArrayList stockLedgerPayList = new ArrayList();

            //_suplierPayDataTable���d������z(��)�e�[�u��
            DataView dv = new DataView(_suplierPayDataTable, filter, sort, DataViewRowState.CurrentRows);
            if (dv.Count == 0)
            {
                // �󃌃R�[�h�쐬
                stockLedgerPayList.Add(new StockLedgerPay());
            }
            else
            {
                for (int index = 0; index < dv.Count; index++)
                {
                    stockLedgerPayList.Add(GetStockLedgerPayFromDataRow(dv[index].Row));
                }
            }

            return stockLedgerPayList;
        }

        #endregion

        #endregion

        #region Private Static Method

        #region �f�[�^�s���d���挳���p�Ӄf�[�^�N���X�擾(StockLedgerPay)
        /// <summary>
        /// �f�[�^�s���d���挳���p�Ӄf�[�^�N���X�擾
        /// </summary>
        /// <param name="dr">�f�[�^�s</param>
        /// <returns>�d���挳���p�Ӄf�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�s���d���挳���p�Ӄf�[�^�N���X���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private static StockLedgerPay GetStockLedgerPayFromDataRow(DataRow dr)
        {
            StockLedgerPay stockLedgerPay = new StockLedgerPay();

            stockLedgerPay.AddUpSecCode = GetCellString(dr[COL_Spl_AddUpSecCode]);	// �v�㋒�_�R�[�h
            stockLedgerPay.PayeeCode = GetCellInt32(dr[COL_Spl_PayeeCode]);	// �x����R�[�h
            stockLedgerPay.CustomerCode = GetCellInt32(dr[COL_Spl_SupplierCd]);	// ���Ӑ�R�[�h
            stockLedgerPay.AddUpDate = TDateTime.LongDateToDateTime(GetCellInt32(dr[COL_Spl_AddUpDate]));	// �v��N����
            //stockLedgerPay.AddUpYearMonth = GetCellInt32(dr[COL_Spl_AddUpYearMonth]);	// �v��N��                     
            //stockLedgerPay.LastTimePayment = GetCellInt64(dr[COL_Spl_LastTimePayment]); // �O��x�����z(�O���c��)
            //stockLedgerPay.ThisTimePayNrml = GetCellInt64(dr[COL_Spl_ThisTimePayNrml]); // ����x���z(�ʏ�x��)
            //stockLedgerPay.ThisTimeFeePayNrml = GetCellInt64(dr[COL_Spl_ThisTimeFeePayNrml]); // ����萔��(�ʏ�x��)
            //stockLedgerPay.ThisTimeDisPayNrml = GetCellInt64(dr[COL_Spl_ThisTimeDisPayNrml]); // ����l���z(�ʏ�x��)
            //stockLedgerPay.ThisTimeTtlBlcPay = GetCellInt64(dr[COL_Spl_ThisTimeTtlBlcPay]); // ����J�z�c���i�x���v�j
            //stockLedgerPay.OfsThisTimeStock = GetCellInt64(dr[COL_Spl_OfsThisTimeStock]); // ���E�㍡��d�����z
            //stockLedgerPay.OfsThisStockTax = GetCellInt64(dr[COL_Spl_OfsThisStockTax]); // ���E�㍡��d�������
            //stockLedgerPay.ThisTimeStockPrice = GetCellInt64(dr[COL_Spl_ThisTimeStockPrice]);	// ����d���z
            //stockLedgerPay.ThisTimeStockPrcTax = GetCellInt64(dr[COL_Spl_ThisStcPrcTax]);	// ����d������Ŋz
            //stockLedgerPay.ThisTimeStockPriceRgds = GetCellInt64(dr[COL_Spl_ThisStckPricRgds]);	// ����ԕi�z
            //stockLedgerPay.ThisTimeStockPriceTaxRgds = GetCellInt64(dr[COL_Spl_ThisStcPrcTaxRgds]);	// ����ԕi����Ŋz
            //stockLedgerPay.StockTotalPayBalance = GetCellInt64(dr[COL_Spl_StockTotalPayBalance]);	// �d�����v�c��
            //stockLedgerPay.StockTtl2TmBfBlPay = GetCellInt64(dr[COL_Spl_StockTtl2TmBfBlPay]);	// �d��2��O�c��
            //stockLedgerPay.StockTtl3TmBfBlPay = GetCellInt64(dr[COL_Spl_StockTtl3TmBfBlPay]);	// �d��3��O�c��
            //stockLedgerPay.StartDateSpan = GetCellInt32(dr[COL_Spl_StartDateSpan]);	// ���t�͈́i�J�n�j
            //stockLedgerPay.EndDateSpan = GetCellInt32(dr[COL_Spl_EndDateSpan]);	// ���t�͈́i�I���j
            //stockLedgerPay.StockSlipCount = GetCellInt32(dr[COL_Spl_StockSlipCount]);	// �d���`�[����
            //stockLedgerPay.ReturnGoodsSlipCount = GetCellInt32(dr[COL_Spl_ReturnGoodsSlipCount]);	// �ԕi�`�[����
            //stockLedgerPay.CloseFlag = GetCellInt32(dr[COL_Spl_CloseFlag]); // ���σt���O

            return stockLedgerPay;
        }
        #endregion
        #region �f�[�^�s���d���挳���p�Ӄf�[�^�N���X�擾
        /// <summary>
		/// �f�[�^�s���d���挳���p�Ӄf�[�^�N���X�擾
		/// </summary>
		/// <param name="dr">�f�[�^�s</param>
		/// <returns>�d���挳���p�Ӄf�[�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�s���d���挳���p�Ӄf�[�^�N���X���擾���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private static SuplierPayInfGet GetSuplierPayInfGetFromDataRow(DataRow dr)
		{
            SuplierPayInfGet suplierPayInfGet = new SuplierPayInfGet();
            
            suplierPayInfGet.EnterpriseCode = GetCellString(dr[COL_Spl_EnterpriseCode]); // ��ƃR�[�h
            suplierPayInfGet.AddUpSecCode = GetCellString(dr[COL_Spl_AddUpSecCode]); // �v�㋒�_�R�[�h
            suplierPayInfGet.AddUpSecName = GetCellString(dr[COL_Spl_AddUpSecName]); // �v�㋒�_��
            suplierPayInfGet.PayeeCode = GetCellInt32(dr[COL_Spl_PayeeCode]); // �x����R�[�h
            suplierPayInfGet.PayeeName = GetCellString(dr[COL_Spl_PayeeName]); // �x���於��
            suplierPayInfGet.PayeeName2 = GetCellString(dr[COL_Spl_PayeeName2]); // �x���於��2
            suplierPayInfGet.PayeeSnm = GetCellString(dr[COL_Spl_PayeeSnm]); // �x���旪��
            suplierPayInfGet.ResultsSectCd = GetCellString(dr[COL_Spl_ResultsSectCd]); // ���ы��_�R�[�h
            suplierPayInfGet.SupplierCd = GetCellInt32(dr[COL_Spl_SupplierCd]); // �d����R�[�h
            suplierPayInfGet.SupplierNm1 = GetCellString(dr[COL_Spl_SupplierNm1]); // �d���於1
            suplierPayInfGet.SupplierNm2 = GetCellString(dr[COL_Spl_SupplierNm2]); // �d���於2
            suplierPayInfGet.SupplierSnm = GetCellString(dr[COL_Spl_SupplierSnm]); // �d���旪��
            suplierPayInfGet.AddUpDate = GetCellDateTime(dr[COL_Spl_AddUpDate]); // �v��N���� 
            suplierPayInfGet.AddUpYearMonth = GetCellDateTime(dr[COL_Spl_AddUpYearMonth]); // �v��N��
            suplierPayInfGet.LastTimePayment = GetCellInt64(dr[COL_Spl_LastTimePayment]); // �O��x�����z
            suplierPayInfGet.StockTtl2TmBfBlPay = GetCellInt64(dr[COL_Spl_StockTtl2TmBfBlPay]); // �d��2��O�c���i�x���v�j
            suplierPayInfGet.StockTtl3TmBfBlPay = GetCellInt64(dr[COL_Spl_StockTtl3TmBfBlPay]); // �d��3��O�c���i�x���v�j
            suplierPayInfGet.ThisTimePayNrml = GetCellInt64(dr[COL_Spl_ThisTimePayNrml]); // ����x�����z�i�ʏ�x���j
            suplierPayInfGet.ThisTimeTtlBlcPay = GetCellInt64(dr[COL_Spl_ThisTimeTtlBlcPay]); // ����J�z�c���i�x���v�j
            suplierPayInfGet.OfsThisTimeStock = GetCellInt64(dr[COL_Spl_OfsThisTimeStock]); // ���E�㍡��d�����z
            suplierPayInfGet.OfsThisStockTax = GetCellInt64(dr[COL_Spl_OfsThisStockTax]); // ���E�㍡��d�������
            suplierPayInfGet.ThisStckPricRgds = GetCellInt64(dr[COL_Spl_ThisStckPricRgds]); // ����ԕi���z
            suplierPayInfGet.ThisStcPrcTaxRgds = GetCellInt64(dr[COL_Spl_ThisStcPrcTaxRgds]); // ����ԕi�����
            suplierPayInfGet.ThisStckPricDis = GetCellInt64(dr[COL_Spl_ThisStckPricDis]); // ����l�����z
            suplierPayInfGet.ThisStcPrcTaxDis = GetCellInt64(dr[COL_Spl_ThisStcPrcTaxDis]); // ����l�������
            suplierPayInfGet.ThisStckPricRgdsDis = GetCellInt64(dr[COL_Spl_ThisStckPricRgdsDis]); // ����ԕi�E�l�����z
            suplierPayInfGet.TaxAdjust = GetCellInt64(dr[COL_Spl_TaxAdjust]); // ����Œ����z
            suplierPayInfGet.BalanceAdjust = GetCellInt64(dr[COL_Spl_BalanceAdjust]); // �c�������z
            suplierPayInfGet.StockTotalPayBalance = GetCellInt64(dr[COL_Spl_StockTotalPayBalance]); // �d�����v�c���i�x���v�j
            suplierPayInfGet.CAddUpUpdExecDate = GetCellDateTime(dr[COL_Spl_CAddUpUpdExecDate]); // �����X�V���s�N�����@
            suplierPayInfGet.StartCAddUpUpdDate = GetCellDateTime(dr[COL_Spl_StartCAddUpUpdDate]); // �����X�V�J�n�N�����@
            suplierPayInfGet.LastCAddUpUpdDate = GetCellDateTime(dr[COL_Spl_LastCAddUpUpdDate]); // �O������X�V�N����
            suplierPayInfGet.StockSlipCount = GetCellInt32(dr[COL_Spl_StockSlipCount]); // �d���`�[����
            suplierPayInfGet.CloseFlg = GetCellInt32(dr[COL_Spl_CloseFlg]); // ���ς݃t���O


            return suplierPayInfGet;
        }
        #endregion

        #region �f�[�^�Z�����f�[�^�擾����
        /// <summary>
		/// �f�[�^�Z����������擾
		/// </summary>
		/// <param name="cell">�f�[�^�Z��</param>
		/// <returns>�擾������</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static string GetCellString(object cell)
		{
			return (cell != DBNull.Value) ? (string)cell : string.Empty;
		}

		/// <summary>
		/// �f�[�^�Z����Int32�擾
		/// </summary>
		/// <param name="cell">�f�[�^�Z��</param>
		/// <returns>�擾���l</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static Int32 GetCellInt32(object cell)
		{
			return (cell != DBNull.Value) ? (Int32)cell : 0;
		}

		/// <summary>
		/// �f�[�^�Z����Int64�擾
		/// </summary>
		/// <param name="cell">�f�[�^�Z��</param>
		/// <returns>�擾���l</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static Int64 GetCellInt64(object cell)
		{
			return (cell != DBNull.Value) ? (Int64)cell : 0;
		}

		/// <summary>
		/// �f�[�^�Z����DateTime�擾
		/// </summary>
		/// <param name="cell">�f�[�^�Z��</param>
		/// <returns>�擾DateTime</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static DateTime GetCellDateTime(object cell)
		{
			return (cell != DBNull.Value) ? (DateTime)cell : new DateTime(1, 1, 1);
        }

        #endregion

        #region DataSet,DataTable����
        /// <summary>
		/// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static void SettingDataSet()
		{
			if (_stockLedgerDataSet == null)
			{
				_stockLedgerDataSet = new DataSet();
                ////�d������z�e�[�u��(��)�쐬
				CreateSuplierPayTable(ref _stockLedgerDataSet);
                //�d���挳���`�[�e�[�u���쐬
                CreateSlipLedgerTable(ref _stockLedgerDataSet);
                //�d���挳�����׃e�[�u���쐬
                CreateDtlLedgerTable(ref _stockLedgerDataSet);
			}
		}

		/// <summary>
		/// �d������z�e�[�u��(��)���쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static void CreateSuplierPayTable(ref DataSet ds)
		{
			DataTable  dt = new DataTable(TABLE_SuplierPay);

            #region �J�����ݒ�
            // ��ƃR�[�h
            dt.Columns.Add(COL_Spl_EnterpriseCode, typeof(string));
            dt.Columns[COL_Spl_EnterpriseCode].Caption = "��ƃR�[�h";
            // �v�㋒�_�R�[�h
            dt.Columns.Add(COL_Spl_AddUpSecCode, typeof(string));
            dt.Columns[COL_Spl_AddUpSecCode].Caption = "�v�㋒�_�R�[�h";
            // �v�㋒�_��
            dt.Columns.Add(COL_Spl_AddUpSecName, typeof(string));
            dt.Columns[COL_Spl_AddUpSecName].Caption = "�v�㋒�_��";
            // �x����R�[�h
            dt.Columns.Add(COL_Spl_PayeeCode, typeof(Int32));
            dt.Columns[COL_Spl_PayeeCode].Caption = "�x����R�[�h";
            // �x���於��
            dt.Columns.Add(COL_Spl_PayeeName, typeof(string));
            dt.Columns[COL_Spl_PayeeName].Caption = "�x���於��";
            // �x���於��2
            dt.Columns.Add(COL_Spl_PayeeName2, typeof(string));
            dt.Columns[COL_Spl_PayeeName2].Caption = "�x���於��2";
            // �x���旪��
            dt.Columns.Add(COL_Spl_PayeeSnm, typeof(string));
            dt.Columns[COL_Spl_PayeeSnm].Caption = "�x���旪��";
            // ���ы��_�R�[�h
            dt.Columns.Add(COL_Spl_ResultsSectCd, typeof(string));
            dt.Columns[COL_Spl_ResultsSectCd].Caption = "���ы��_�R�[�h";
            // �d����R�[�h
            dt.Columns.Add(COL_Spl_SupplierCd, typeof(Int32));
            dt.Columns[COL_Spl_SupplierCd].Caption = "�d����R�[�h";
            // �d���於1
            dt.Columns.Add(COL_Spl_SupplierNm1, typeof(string));
            dt.Columns[COL_Spl_SupplierNm1].Caption = "�d���於1";
            // �d���於2
            dt.Columns.Add(COL_Spl_SupplierNm2, typeof(string));
            dt.Columns[COL_Spl_SupplierNm2].Caption = "�d���於2";
            // �d���旪��
            dt.Columns.Add(COL_Spl_SupplierSnm, typeof(string));
            dt.Columns[COL_Spl_SupplierSnm].Caption = "�d���旪��";
            // �v��N����
            dt.Columns.Add(COL_Spl_AddUpDate, typeof(Int32));
            dt.Columns[COL_Spl_AddUpDate].Caption = "�v��N����";
            // �v��N��
            dt.Columns.Add(COL_Spl_AddUpYearMonth, typeof(Int32));
            dt.Columns[COL_Spl_AddUpYearMonth].Caption = "�v��N��";
            // �O��x�����z
            dt.Columns.Add(COL_Spl_LastTimePayment, typeof(Int64));
            dt.Columns[COL_Spl_LastTimePayment].Caption = "�O��x�����z";
            // �d��2��O�c���i�x���v�j
            dt.Columns.Add(COL_Spl_StockTtl2TmBfBlPay, typeof(Int64));
            dt.Columns[COL_Spl_StockTtl2TmBfBlPay].Caption = "�d��2��O�c���i�x���v�j";
            // �d��3��O�c���i�x���v�j
            dt.Columns.Add(COL_Spl_StockTtl3TmBfBlPay, typeof(Int64));
            dt.Columns[COL_Spl_StockTtl3TmBfBlPay].Caption = "�d��3��O�c���i�x���v�j";
            // ����x�����z�i�ʏ�x���j
            dt.Columns.Add(COL_Spl_ThisTimePayNrml, typeof(Int64));
            dt.Columns[COL_Spl_ThisTimePayNrml].Caption = "����x�����z�i�ʏ�x���j";
            // ����J�z�c���i�x���v�j
            dt.Columns.Add(COL_Spl_ThisTimeTtlBlcPay, typeof(Int64));
            dt.Columns[COL_Spl_ThisTimeTtlBlcPay].Caption = "����J�z�c���i�x���v�j";
            // ���E�㍡��d�����z
            dt.Columns.Add(COL_Spl_OfsThisTimeStock, typeof(Int64));
            dt.Columns[COL_Spl_OfsThisTimeStock].Caption = "���E�㍡��d�����z";
            // �ō��d���z
            dt.Columns.Add(COL_Spl_OfsThisTimeStockTax, typeof(Int64));
            dt.Columns[COL_Spl_OfsThisTimeStockTax].Caption = "�ō��d���z";
            // ���E�㍡��d�������
            dt.Columns.Add(COL_Spl_OfsThisStockTax, typeof(Int64));
            dt.Columns[COL_Spl_OfsThisStockTax].Caption = "���E�㍡��d�������";
            // ����ԕi���z
            dt.Columns.Add(COL_Spl_ThisStckPricRgds, typeof(Int64));
            dt.Columns[COL_Spl_ThisStckPricRgds].Caption = "����ԕi���z";
            // ����ԕi�����
            dt.Columns.Add(COL_Spl_ThisStcPrcTaxRgds, typeof(Int64));
            dt.Columns[COL_Spl_ThisStcPrcTaxRgds].Caption = "����ԕi�����";
            // ����l�����z
            dt.Columns.Add(COL_Spl_ThisStckPricDis, typeof(Int64));
            dt.Columns[COL_Spl_ThisStckPricDis].Caption = "����l�����z";
            // ����l�������
            dt.Columns.Add(COL_Spl_ThisStcPrcTaxDis, typeof(Int64));
            dt.Columns[COL_Spl_ThisStcPrcTaxDis].Caption = "����l�������";
            // ����ԕi�E�l�����z
            dt.Columns.Add(COL_Spl_ThisStckPricRgdsDis, typeof(Int64));
            dt.Columns[COL_Spl_ThisStckPricRgdsDis].Caption = "����ԕi�E�l�����z";
            // ����Œ����z
            dt.Columns.Add(COL_Spl_TaxAdjust, typeof(Int64));
            dt.Columns[COL_Spl_TaxAdjust].Caption = "����Œ����z";
            // �c�������z
            dt.Columns.Add(COL_Spl_BalanceAdjust, typeof(Int64));
            dt.Columns[COL_Spl_BalanceAdjust].Caption = "�c�������z";
            // �d�����v�c���i�x���v�j
            dt.Columns.Add(COL_Spl_StockTotalPayBalance, typeof(Int64));
            dt.Columns[COL_Spl_StockTotalPayBalance].Caption = "�d�����v�c���i�x���v�j";
            // �����X�V���s�N����
            dt.Columns.Add(COL_Spl_CAddUpUpdExecDate, typeof(Int32));
            dt.Columns[COL_Spl_CAddUpUpdExecDate].Caption = "�����X�V���s�N����";
            // �����X�V�J�n�N����
            dt.Columns.Add(COL_Spl_StartCAddUpUpdDate, typeof(Int32));
            dt.Columns[COL_Spl_StartCAddUpUpdDate].Caption = "�����X�V�J�n�N����";
            // �O������X�V�N����
            dt.Columns.Add(COL_Spl_LastCAddUpUpdDate, typeof(Int32));
            dt.Columns[COL_Spl_LastCAddUpUpdDate].Caption = "�O������X�V�N����";
            // �d���`�[����
            dt.Columns.Add(COL_Spl_StockSlipCount, typeof(Int32));
            dt.Columns[COL_Spl_StockSlipCount].Caption = "�d���`�[����";
            // ���ς݃t���O
            dt.Columns.Add(COL_Spl_CloseFlg, typeof(Int32));
            dt.Columns[COL_Spl_CloseFlg].Caption = "���ς݃t���O";
            // ����p �x���E���|
            dt.Columns.Add(COL_Spl_SlitTitle, typeof(String));
            dt.Columns[COL_Spl_SlitTitle].Caption = "����p �x���c�E���|�c";

            // 2009.02.24 30413 ���� ����d�����z�̒ǉ� >>>>>>START
            // �ō��d���z
            dt.Columns.Add(COL_Spl_ThisTimeStockPrice, typeof(Int64));
            dt.Columns[COL_Spl_ThisTimeStockPrice].Caption = "����d�����z";
            // 2009.02.24 30413 ���� ����d�����z�̒ǉ� <<<<<<END

            // --- ADD 2012/11/01 ---------->>>>>
            // ����œ]�ŕ���
            dt.Columns.Add(COL_Spl_SuppCTaxLayCd, typeof(Int32));
            dt.Columns[COL_Spl_SuppCTaxLayCd].Caption = "����œ]�ŕ���";
            // --- ADD 2012/11/01 ----------<<<<<
            #endregion

            ds.Tables.Add(dt);

            //�\�[�g
            //�v�㋒�_�R�[�h�����Ӑ�R�[�h���v��N����(���)
			string sort = COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;

			//�d������z(��)�f�[�^�e�[�u��
			_suplierPayDataTable	= dt;
			_suplierPayDataView		= new DataView(_suplierPayDataTable, string.Empty, sort, DataViewRowState.CurrentRows);

			// �d������zDataTable(����p)
            //_suplierPayPrintDataTable	= dt.Clone();
            //_suplierPayPrintDataView	= new DataView(_suplierPayPrintDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
		}

        /// <summary>
        /// �d���挳���`�[�e�[�u�����쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private static void CreateSlipLedgerTable(ref DataSet ds)
        {
            //�O���b�h�p
            DataTable dt = new DataTable(TABLE_SplLedger);

            #region [�J�����ݒ�]
            // ��ƃR�[�h
            dt.Columns.Add(CT_SplLedger_EnterpriseCode, typeof(string));
            dt.Columns[CT_SplLedger_EnterpriseCode].Caption = "��ƃR�[�h";
            // ��ƃR�[�h
            dt.Columns.Add(CT_SplLedger_AddUpDate, typeof(Int32));
            dt.Columns[CT_SplLedger_AddUpDate].Caption = "��ƃR�[�h";
            // �d���`��
            dt.Columns.Add(CT_SplLedger_SupplierFormal, typeof(Int32));
            dt.Columns[CT_SplLedger_SupplierFormal].Caption = "�d���`��";
            // �d���`�[�ԍ�
            dt.Columns.Add(CT_SplLedger_SupplierSlipNo, typeof(Int32));
            dt.Columns[CT_SplLedger_SupplierSlipNo].Caption = "�d���`�[�ԍ�";
            // �d���`�[���
            dt.Columns.Add(CT_SplLedger_SlipKindNm, typeof(String));
            dt.Columns[CT_SplLedger_SlipKindNm].Caption = "�d���`�[���";
            // ���_�R�[�h
            dt.Columns.Add(CT_SplLedger_SectionCode, typeof(string));
            dt.Columns[CT_SplLedger_SectionCode].Caption = "���_�R�[�h";
            // �ԓ`�敪
            dt.Columns.Add(CT_SplLedger_DebitNoteDiv, typeof(Int32));
            dt.Columns[CT_SplLedger_DebitNoteDiv].Caption = "�ԓ`�敪";
            // �ԍ��A���d���`�[�ԍ�
            dt.Columns.Add(CT_SplLedger_DebitNLnkSuppSlipNo, typeof(Int32));
            dt.Columns[CT_SplLedger_DebitNLnkSuppSlipNo].Caption = "�ԍ��A���d���`�[�ԍ�";
            // �d���`�[�敪
            dt.Columns.Add(CT_SplLedger_SupplierSlipCd, typeof(Int32));
            dt.Columns[CT_SplLedger_SupplierSlipCd].Caption = "�d���`�[�敪";
            // �d�����i�敪
            dt.Columns.Add(CT_SplLedger_StockGoodsCd, typeof(Int32));
            dt.Columns[CT_SplLedger_StockGoodsCd].Caption = "�d�����i�敪";
            // �d�����_�R�[�h
            dt.Columns.Add(CT_SplLedger_StockSectionCd, typeof(string));
            dt.Columns[CT_SplLedger_StockSectionCd].Caption = "�d�����_�R�[�h";
            // �d���v�㋒�_�R�[�h
            dt.Columns.Add(CT_SplLedger_StockAddUpSectionCd, typeof(string));
            dt.Columns[CT_SplLedger_StockAddUpSectionCd].Caption = "�d���v�㋒�_�R�[�h";
            // ���͓�
            dt.Columns.Add(CT_SplLedger_InputDay, typeof(Int32));
            dt.Columns[CT_SplLedger_InputDay].Caption = "���͓�";
            // ���ד�
            dt.Columns.Add(CT_SplLedger_ArrivalGoodsDay, typeof(Int32));
            dt.Columns[CT_SplLedger_ArrivalGoodsDay].Caption = "���ד�";
            // �d����
            dt.Columns.Add(CT_SplLedger_StockDate, typeof(Int32));
            dt.Columns[CT_SplLedger_StockDate].Caption = "�d����";
            // �d���v����t
            dt.Columns.Add(CT_SplLedger_StockAddUpADate, typeof(Int32));
            dt.Columns[CT_SplLedger_StockAddUpADate].Caption = "�d���v����t";
            // �d�����R�[�h�敪
            dt.Columns.Add(CT_SplLedger_StockRecordCd, typeof(Int32));
            dt.Columns[CT_SplLedger_StockRecordCd].Caption = "�d�����R�[�h�敪";
            // �d�����͎҃R�[�h
            dt.Columns.Add(CT_SplLedger_StockInputCode, typeof(string));
            dt.Columns[CT_SplLedger_StockInputCode].Caption = "�d�����͎҃R�[�h";
            // �d�����͎Җ���
            dt.Columns.Add(CT_SplLedger_StockInputName, typeof(string));
            dt.Columns[CT_SplLedger_StockInputName].Caption = "�d�����͎Җ���";
            // �d���S���҃R�[�h
            dt.Columns.Add(CT_SplLedger_StockAgentCode, typeof(string));
            dt.Columns[CT_SplLedger_StockAgentCode].Caption = "�d���S���҃R�[�h";
            // �d���S���Җ���
            dt.Columns.Add(CT_SplLedger_StockAgentName, typeof(string));
            dt.Columns[CT_SplLedger_StockAgentName].Caption = "�d���S���Җ���";
            // �x����R�[�h
            dt.Columns.Add(CT_SplLedger_PayeeCode, typeof(Int32));
            dt.Columns[CT_SplLedger_PayeeCode].Caption = "�x����R�[�h";
            // �x���旪��
            dt.Columns.Add(CT_SplLedger_PayeeSnm, typeof(string));
            dt.Columns[CT_SplLedger_PayeeSnm].Caption = "�x���旪��";
            // �d����R�[�h
            dt.Columns.Add(CT_SplLedger_SupplierCd, typeof(Int32));
            dt.Columns[CT_SplLedger_SupplierCd].Caption = "�d����R�[�h";
            // �d���於1
            dt.Columns.Add(CT_SplLedger_SupplierNm1, typeof(string));
            dt.Columns[CT_SplLedger_SupplierNm1].Caption = "�d���於1";
            // �d���於2
            dt.Columns.Add(CT_SplLedger_SupplierNm2, typeof(string));
            dt.Columns[CT_SplLedger_SupplierNm2].Caption = "�d���於2";
            // �d���旪��
            dt.Columns.Add(CT_SplLedger_SupplierSnm, typeof(string));
            dt.Columns[CT_SplLedger_SupplierSnm].Caption = "�d���旪��";
            // �d�����z���v
            dt.Columns.Add(CT_SplLedger_StockTotalPrice, typeof(Int64));
            dt.Columns[CT_SplLedger_StockTotalPrice].Caption = "�d�����z���v";
            // �d�����z���v
            dt.Columns.Add(CT_SplLedger_StockSubttlPrice, typeof(Int64));
            dt.Columns[CT_SplLedger_StockSubttlPrice].Caption = "�d�����z���v";
            // �d�����z����Ŋz
            dt.Columns.Add(CT_SplLedger_StockPriceConsTax, typeof(Int64));
            dt.Columns[CT_SplLedger_StockPriceConsTax].Caption = "�d�����z����Ŋz";
            // �����`�[�ԍ�
            dt.Columns.Add(CT_SplLedger_PartySaleSlipNum, typeof(string));
            dt.Columns[CT_SplLedger_PartySaleSlipNum].Caption = "�����`�[�ԍ�";
            // �d���`�[���l1
            dt.Columns.Add(CT_SplLedger_SupplierSlipNote1, typeof(string));
            dt.Columns[CT_SplLedger_SupplierSlipNote1].Caption = "�d���`�[���l1";
            // �d���`�[���l2
            dt.Columns.Add(CT_SplLedger_SupplierSlipNote2, typeof(string));
            dt.Columns[CT_SplLedger_SupplierSlipNote2].Caption = "�d���`�[���l2";
            // �t�n�d���}�[�N�P
            dt.Columns.Add(CT_SplLedger_UoeRemark1, typeof(string));
            dt.Columns[CT_SplLedger_UoeRemark1].Caption = "�t�n�d���}�[�N�P";
            // �t�n�d���}�[�N�Q
            dt.Columns.Add(CT_SplLedger_UoeRemark2, typeof(string));
            dt.Columns[CT_SplLedger_UoeRemark2].Caption = "�t�n�d���}�[�N�Q";
            //�ȉ��͎x���`�[
            // �x�����z
            dt.Columns.Add(CT_SplLedger_Payment, typeof(Int64));
            dt.Columns[CT_SplLedger_Payment].Caption = "�x�����z";
            // �L������
            dt.Columns.Add(CT_SplLedger_ValidityTerm, typeof(Int32));
            dt.Columns[CT_SplLedger_ValidityTerm].Caption = "�L������";
            // �x���p���z�敪��
            dt.Columns.Add(CT_SplLedger_GoodsName, typeof(string));
            dt.Columns[CT_SplLedger_GoodsName].Caption = "�x���p���z�敪��";
            // �x���p���z�敪
            dt.Columns.Add(CT_SplLedger_GoodsDiv, typeof(Int32));
            dt.Columns[CT_SplLedger_GoodsDiv].Caption = "�x���p���z�敪";


            #endregion

            ds.Tables.Add(dt);

            //�\�[�g
            string sort = CT_SplLedger_SectionCode + "," + CT_SplLedger_PayeeCode + "," + CT_SplLedger_SupplierCd + "," + CT_SplLedger_StockAddUpADate + "," + CT_SplLedger_SupplierSlipNo;

            _stockLedgerSlipDataTable = dt;
            _stockLedgerSlipDataView = new DataView(_stockLedgerSlipDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// �d���挳�����׃e�[�u�����쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private static void CreateDtlLedgerTable(ref DataSet ds)
        {
            //�O���b�h�p
            DataTable dt = new DataTable(TABLE_DtlLedger);

            #region �J�����ݒ�
            // ��ƃR�[�h
            dt.Columns.Add(CT_DtlLedger_EnterpriseCode, typeof(string));
            dt.Columns[CT_DtlLedger_EnterpriseCode].Caption = "��ƃR�[�h";
            // �v����t(���)
            dt.Columns.Add(CT_DtlLedger_AddUpDate, typeof(Int32));
            dt.Columns[CT_DtlLedger_AddUpDate].Caption = "�v����t(���)";
            // �d���`��
            dt.Columns.Add(CT_DtlLedger_SupplierFormal, typeof(Int32));
            dt.Columns[CT_DtlLedger_SupplierFormal].Caption = "�d���`��";
            // �d���`�[�ԍ�
            dt.Columns.Add(CT_DtlLedger_SupplierSlipNo, typeof(Int32));
            dt.Columns[CT_DtlLedger_SupplierSlipNo].Caption = "�d���`�[�ԍ�";
            // �d���`�[���
            dt.Columns.Add(CT_DtlLedger_SlipKindNm, typeof(String));
            dt.Columns[CT_DtlLedger_SlipKindNm].Caption = "�d���`�[���";
            // ���_�R�[�h
            dt.Columns.Add(CT_DtlLedger_SectionCode, typeof(string));
            dt.Columns[CT_DtlLedger_SectionCode].Caption = "���_�R�[�h";
            // �ԓ`�敪
            dt.Columns.Add(CT_DtlLedger_DebitNoteDiv, typeof(Int32));
            dt.Columns[CT_DtlLedger_DebitNoteDiv].Caption = "�ԓ`�敪";
            // �ԍ��A���d���`�[�ԍ�
            dt.Columns.Add(CT_DtlLedger_DebitNLnkSuppSlipNo, typeof(Int32));
            dt.Columns[CT_DtlLedger_DebitNLnkSuppSlipNo].Caption = "�ԍ��A���d���`�[�ԍ�";
            // �d���`�[�敪
            dt.Columns.Add(CT_DtlLedger_SupplierSlipCd, typeof(Int32));
            dt.Columns[CT_DtlLedger_SupplierSlipCd].Caption = "�d���`�[�敪";
            // �d�����i�敪
            dt.Columns.Add(CT_DtlLedger_StockGoodsCd, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockGoodsCd].Caption = "�d�����i�敪";
            // �d�����_�R�[�h
            dt.Columns.Add(CT_DtlLedger_StockSectionCd, typeof(string));
            dt.Columns[CT_DtlLedger_StockSectionCd].Caption = "�d�����_�R�[�h";
            // �d���v�㋒�_�R�[�h
            dt.Columns.Add(CT_DtlLedger_StockAddUpSectionCd, typeof(string));
            dt.Columns[CT_DtlLedger_StockAddUpSectionCd].Caption = "�d���v�㋒�_�R�[�h";
            // ���͓�
            dt.Columns.Add(CT_DtlLedger_InputDay, typeof(Int32));
            dt.Columns[CT_DtlLedger_InputDay].Caption = "���͓�";
            // ���ד�
            dt.Columns.Add(CT_DtlLedger_ArrivalGoodsDay, typeof(Int32));
            dt.Columns[CT_DtlLedger_ArrivalGoodsDay].Caption = "���ד�";
            // �d����
            dt.Columns.Add(CT_DtlLedger_StockDate, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockDate].Caption = "�d����";
            // �d���v����t
            dt.Columns.Add(CT_DtlLedger_StockAddUpADate, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockAddUpADate].Caption = "�d���v����t";
            // �d�����͎҃R�[�h
            dt.Columns.Add(CT_DtlLedger_StockInputCode, typeof(string));
            dt.Columns[CT_DtlLedger_StockInputCode].Caption = "�d�����͎҃R�[�h";
            // �d�����͎Җ���
            dt.Columns.Add(CT_DtlLedger_StockInputName, typeof(string));
            dt.Columns[CT_DtlLedger_StockInputName].Caption = "�d�����͎Җ���";
            // �d���S���҃R�[�h
            dt.Columns.Add(CT_DtlLedger_StockAgentCode, typeof(string));
            dt.Columns[CT_DtlLedger_StockAgentCode].Caption = "�d���S���҃R�[�h";
            // �d���S���Җ���
            dt.Columns.Add(CT_DtlLedger_StockAgentName, typeof(string));
            dt.Columns[CT_DtlLedger_StockAgentName].Caption = "�d���S���Җ���";
            // �x����R�[�h
            dt.Columns.Add(CT_DtlLedger_PayeeCode, typeof(Int32));
            dt.Columns[CT_DtlLedger_PayeeCode].Caption = "�x����R�[�h";
            // �x���旪��
            dt.Columns.Add(CT_DtlLedger_PayeeSnm, typeof(string));
            dt.Columns[CT_DtlLedger_PayeeSnm].Caption = "�x���旪��";
            // �d����R�[�h
            dt.Columns.Add(CT_DtlLedger_SupplierCd, typeof(Int32));
            dt.Columns[CT_DtlLedger_SupplierCd].Caption = "�d����R�[�h";
            // �d���惌�R�[�h�敪
            dt.Columns.Add(CT_DtlLedger_StockRecordCd, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockRecordCd].Caption = "�d���惌�R�[�h�敪";
            // �d���於1
            dt.Columns.Add(CT_DtlLedger_SupplierNm1, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierNm1].Caption = "�d���於1";
            // �d���於2
            dt.Columns.Add(CT_DtlLedger_SupplierNm2, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierNm2].Caption = "�d���於2";
            // �d���旪��
            dt.Columns.Add(CT_DtlLedger_SupplierSnm, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierSnm].Caption = "�d���旪��";
            // �d�����z���v
            dt.Columns.Add(CT_DtlLedger_StockTotalPrice, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockTotalPrice].Caption = "�d�����z���v";
            // �d�����z���v
            dt.Columns.Add(CT_DtlLedger_StockSubttlPrice, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockSubttlPrice].Caption = "�d�����z���v";
            // �d�����z����Ŋz
            dt.Columns.Add(CT_DtlLedger_StockPriceConsTax, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockPriceConsTax].Caption = "�d�����z����Ŋz";
            // �����`�[�ԍ�
            dt.Columns.Add(CT_DtlLedger_PartySaleSlipNum, typeof(string));
            dt.Columns[CT_DtlLedger_PartySaleSlipNum].Caption = "�����`�[�ԍ�";
            // �d���`�[���l1
            dt.Columns.Add(CT_DtlLedger_SupplierSlipNote1, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierSlipNote1].Caption = "�d���`�[���l1";
            // �d���`�[���l2
            dt.Columns.Add(CT_DtlLedger_SupplierSlipNote2, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierSlipNote2].Caption = "�d���`�[���l2";
            // �t�n�d���}�[�N�P
            dt.Columns.Add(CT_DtlLedger_UoeRemark1, typeof(string));
            dt.Columns[CT_DtlLedger_UoeRemark1].Caption = "�t�n�d���}�[�N�P";
            // �t�n�d���}�[�N�Q
            dt.Columns.Add(CT_DtlLedger_UoeRemark2, typeof(string));
            dt.Columns[CT_DtlLedger_UoeRemark2].Caption = "�t�n�d���}�[�N�Q";
            // �d���s�ԍ�
            dt.Columns.Add(CT_DtlLedger_StockRowNo, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockRowNo].Caption = "�d���s�ԍ�";
            // ���ʒʔ�
            dt.Columns.Add(CT_DtlLedger_CommonSeqNo, typeof(Int64));
            dt.Columns[CT_DtlLedger_CommonSeqNo].Caption = "���ʒʔ�";
            // �d�����גʔ�
            dt.Columns.Add(CT_DtlLedger_StockSlipDtlNum, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockSlipDtlNum].Caption = "�d�����גʔ�";
            // ���i�ԍ�
            dt.Columns.Add(CT_DtlLedger_GoodsNo, typeof(string));
            dt.Columns[CT_DtlLedger_GoodsNo].Caption = "���i�ԍ�";
            // ���i����
            dt.Columns.Add(CT_DtlLedger_GoodsName, typeof(string));
            dt.Columns[CT_DtlLedger_GoodsName].Caption = "���i����";
            // ���i���̃J�i
            dt.Columns.Add(CT_DtlLedger_GoodsNameKana, typeof(string));
            dt.Columns[CT_DtlLedger_GoodsNameKana].Caption = "���i���̃J�i";
            // �̔���R�[�h
            dt.Columns.Add(CT_DtlLedger_SalesCustomerCode, typeof(Int32));
            dt.Columns[CT_DtlLedger_SalesCustomerCode].Caption = "�̔���R�[�h";
            // �̔��旪��
            dt.Columns.Add(CT_DtlLedger_SalesCustomerSnm, typeof(string));
            dt.Columns[CT_DtlLedger_SalesCustomerSnm].Caption = "�̔��旪��";
            // �d����
            dt.Columns.Add(CT_DtlLedger_StockCount, typeof(Double));
            dt.Columns[CT_DtlLedger_StockCount].Caption = "�d����";
            // �d���P���i�Ŕ��C�����j
            dt.Columns.Add(CT_DtlLedger_StockUnitPriceFl, typeof(Double));
            dt.Columns[CT_DtlLedger_StockUnitPriceFl].Caption = "�d���P���i�Ŕ��C�����j";
            // �d�����z�i�Ŕ����j
            dt.Columns.Add(CT_DtlLedger_StockPriceTaxExc, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockPriceTaxExc].Caption = "�d�����z�i�Ŕ����j";
            // �d�����z����Ŋz
            dt.Columns.Add(CT_DtlLedger_Dtl_StockPriceConsTax, typeof(Int64));
            dt.Columns[CT_DtlLedger_Dtl_StockPriceConsTax].Caption = "�d�����z����Ŋz";
            //�ȉ��x���`�[
            // �x�����z
            dt.Columns.Add(CT_DtlLedger_Payment, typeof(Int64));
            dt.Columns[CT_DtlLedger_Payment].Caption = "�x�����z";
            // �L������
            dt.Columns.Add(CT_DtlLedger_ValidityTerm, typeof(Int32));
            dt.Columns[CT_DtlLedger_ValidityTerm].Caption = "�L������";
            //�ȉ�����p
            // �x���cor���|�cstring
            dt.Columns.Add(CT_DtlLedger_SlitTitle, typeof(String));
            dt.Columns[CT_DtlLedger_SlitTitle].Caption = "�x���cor���|�cstring";
            // �c��
            dt.Columns.Add(CT_DtlLedger_Balance, typeof(Int64));
            dt.Columns[CT_DtlLedger_Balance].Caption = "�c��";
            #endregion

            ds.Tables.Add(dt);

            //�\�[�g
            //���Ӑ�R�[�h���v��N����(���)���O�c�J�z�敪���v����t?�����R�[�h�敪���`�[�ԍ�
            string sort = CT_DtlLedger_PayeeCode + "," + CT_DtlLedger_StockAddUpADate + "," + CT_DtlLedger_SupplierSlipNo;

            _stockLedgerDtlDataTable = dt;
            _stockLedgerDtlDataView = new DataView(_stockLedgerDtlDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
        }

        #endregion

        #region �d����x�����z�f�[�^�擾����(�����[�g�ڑ�)
        /// <summary>
		/// �d����x�����z�f�[�^�擾����
		/// </summary>
		/// <param name="printDiv">����敪</param>
		/// <param name="param">�p�����[�^</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : �d����x�����z�f�[�^���擾���܂�</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
        /// <br>Update Note : 2014/02/26 �c����</br>
        /// <br>            : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// <br>UpdateNote  : 2015/12/10 �c�v�t</br>
        /// <br>�Ǘ��ԍ�    : 11170204-00</br>
        /// <br>            : Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�</br>
        /// </remarks>
        //private static int GetSupplierPayInfo(string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, int mode)
        //private static int GetSupplierPayInfo(int printDiv, Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetParameter param)// DEL 2014/02/27 ���N�n��
        private static int GetSupplierPayInfo(int printDiv, Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetParameter param, int outMoneyDiv)// ADD 2014/02/27 ���N�n��
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList supplierPayList       = null;     // �d����x�����z�}�X�^�pList
            //Hashtable accBlanceTable        = null;     // �c��(�d��)�f�[�^�pHashTable
            Hashtable supplierSlpInf = null;     // ���|(�d��)�f�[�^�pHashTable
            Hashtable supplierDtlInf = null;     // ���|(�d��)���׃f�[�^�pHashTable
            Hashtable paymentSlpTable = null;     // �x���f�[�^�pHashTable

            ArrayList supplierSlpInfAry = null;     // ���|(�d��)�f�[�^�pArrayList
            ArrayList supplierDtlInfAry = null;     // ���|(�d��)���׃f�[�^�pArrayList 
            ArrayList paymentSlpTableAry = null;     // �x���f�[�^�pArrayList
            object supplierPayWorkList = null;
            object supplierSlpInfWork = null;
            object supplierDtlInfWork = null;
            object supplierPaymentInfWork = null;

            SuplierPayInfGetWork suplierPayInfGetWork = new SuplierPayInfGetWork();  // �d����x�����z�}�X�^���[�N

            try
            {
                // �d����x�����擾�A�N�Z�X�N���X
                if (_getSuplierPayAcs == null)
                {
                    _getSuplierPayAcs = new GetSuplierPayAcs();
                    _getSuplierPayAcs.ThroughException = true;
                }

                //  ��������
                switch (printDiv)
                {
                case 1: // ���׃��[�h
                    {
                        status = _suplierPayInfGetDB.SearchDtl(out supplierPayWorkList, out supplierDtlInfWork, out supplierPaymentInfWork, param);
                        supplierPayList = supplierPayWorkList as ArrayList;
                        supplierSlpInfAry = supplierSlpInfWork as ArrayList;
                        supplierDtlInfAry = supplierDtlInfWork as ArrayList;
                        paymentSlpTableAry = supplierPaymentInfWork as ArrayList;
                        //gatherUpSupPay(ref supplierPayList); // �_�u��ɑΉ�����r������
                        ArrayInfoToHashTable(out supplierSlpInf, out supplierDtlInf, out paymentSlpTable,
                            //supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry);// DEL 2014/02/26 �c���� Redmine#42188
                        // ---ADD 2014/02/26 �c���� Redmine#42188--------------------->>>>>
                            //ref supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv);// DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
                            ref supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv, param.SumSuppEnable);// ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
                        if (supplierPayList == null || supplierPayList.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        // ---ADD 2014/02/26 �c���� Redmine#42188---------------------<<<<<
                        break;
                    }
                case 2: // �`�[���[�h
                    {
                        status = _suplierPayInfGetDB.SearchSlip(out supplierPayWorkList, out supplierSlpInfWork, out supplierPaymentInfWork, param);
                        supplierPayList = supplierPayWorkList as ArrayList;
                        supplierSlpInfAry = supplierSlpInfWork as ArrayList;
                        supplierDtlInfAry = supplierDtlInfWork as ArrayList;
                        paymentSlpTableAry = supplierPaymentInfWork as ArrayList;
                        //gatherUpSupPay(ref supplierPayList); // �_�u��ɑΉ�����r������
                        ArrayInfoToHashTable(out supplierSlpInf, out supplierDtlInf, out paymentSlpTable,
                            //supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry);// DEL 2014/02/26 �c���� Redmine#42188
                        // ---ADD 2014/02/26 �c���� Redmine#42188--------------------->>>>>    
                            //ref supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv);// DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
                            ref supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv, param.SumSuppEnable);// ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
                        if (supplierPayList == null || supplierPayList.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        // ---ADD 2014/02/26 �c���� Redmine#42188---------------------<<<<<
                        break;
                    }
                default:
                    {
                        throw new CsLedgerException("����敪���s���ł��B", status);
                    }
                } 

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�d����x�����f�[�^���X�g��StaticMemory�ݒ�
                    SetStaticFromSupplierPayList(supplierPayList);

                    //�d����ʌv��N�����͈͎擾
                    SetCustomerAddUpDateSpanAndAddUpDate(param.SupplierCd);

                    // �x�����|�E�x���`�[�f�[�^�e�[�u���ݒ�
                    AccPayAndPaymentSlpToDataTable(param.SupplierCd, supplierSlpInf, supplierDtlInf, paymentSlpTable);

                    // �Ɖ�p���Ǝv����̂ŏ����B
                    //// �x���`�[���[�N������ێ��p�ɐݒ�
                    ////foreach (DictionaryEntry de in paymentSlpTable)
                    //foreach (ArrayList paymentSlpList in paymentSlpTable)
                    //{
                    //    //ArrayList paymentSlpList = (ArrayList)de.Value;

                    //    if (paymentSlpList != null)
                    //    {
                    //        foreach (LedgerPaymentSlpWork wk in paymentSlpList)
                    //        {
                    //            if (wk != null)
                    //            {
                    //                string key = string.Empty;
                    //                //key = wk.AddUpSecCode + "_" + wk.PayeeCode.ToString() + "_" + wk.CustomerCode.ToString() + "_" + String.Format("{0:D9}", wk.PaymentSlipNo);
                    //                key = wk.AddUpSecCode + "_" + wk.PayeeCode.ToString() + "_" + wk.SupplierCd.ToString() + "_" + String.Format("{0:D9}", wk.PaymentSlipNo);
                    //                if (!_paymentSlpTable.ContainsKey(key))
                    //                {
                    //                    _paymentSlpTable.Add(key, wk);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
                else
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        //
                    }
                    else
                    {
                        throw new CsLedgerException("�x�����̎擾�Ɏ��s���܂����B", status);
                    }
            }
            catch (Exception ex)
            {
                throw new CsLedgerException(ex.Message, status);
            }
            finally
            {
                if (supplierPayList != null) supplierPayList = null;
                if (supplierSlpInf != null) supplierSlpInf = null;
                if (supplierDtlInf != null) supplierDtlInf = null;
                if (paymentSlpTable != null) paymentSlpTable = null;
            }

			return status;
        }
    
        #endregion

        #region �� ���Ӑ�ʌv��N�����͈͎擾����
        /// <summary>
		/// ���Ӑ�ʌv��N�����͈͎擾����
		/// </summary>
		/// <param name="cutomerCode">���Ӑ�R�[�h</param>
		/// <remarks>
		/// <br>Note       : ���\�b�h���e��������܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public static void SetCustomerAddUpDateSpanAndAddUpDate(int cutomerCode)
		{
			//���꓾�Ӑ�A����v�㋒�_�̃��R�[�h���i�荞��(���_���Ɛ�p�̓��Ӑ��ݒ肵�Ă�̂ŋ��_�͍i�荞�܂Ȃ�)
            string filter	= String.Format("{0}={1}", COL_Spl_SupplierCd, cutomerCode);
            string sort		= COL_Spl_PayeeCode + "," + COL_Spl_AddUpSecCode + "," + COL_Spl_AddUpDate;

            DataView dv = new DataView(_suplierPayDataTable, filter, sort, DataViewRowState.CurrentRows);

            if (dv.Count > 0)
            {
                //�d���挳���p�Ӄf�[�^�N���X
                StockLedgerPay stockLedgerPay;

                // �J�n�擾
                stockLedgerPay = GetStockLedgerPayFromDataRow(dv[0].Row);
                _startTtlAddUpDateSpan = TDateTime.LongDateToDateTime(stockLedgerPay.StartDateSpan);
                _startAddUpDate = stockLedgerPay.AddUpDate;

                // �I���擾
                stockLedgerPay = GetStockLedgerPayFromDataRow(dv[dv.Count-1].Row);

                if ( ( stockLedgerPay.CloseFlag == (int)CloseFlagState.NotClose ) &&  ( dv.Count > 1 ))
				{
					stockLedgerPay = GetStockLedgerPayFromDataRow(dv[dv.Count - 2].Row);
				}

                _endTtlAddUpDateSpan = TDateTime.LongDateToDateTime(stockLedgerPay.EndDateSpan);
                _endAddUpDate = stockLedgerPay.AddUpDate;
            }
        }

        #endregion

        #region �� �������׃e�[�u���s�쐬����
        /// <summary>
		/// �������׃e�[�u���s�쐬����
		/// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="supplierSlpInf">�d���`�[���</param>
        /// <param name="supplierDtlInf">�d�����׏��</param>
        /// <param name="paymentSlpTable">�x���`�[�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �x�����|�E�x���`�[���X�g��茳�����׃e�[�u���ɖ��ׂ�ݒ肵�܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
        private static void AccPayAndPaymentSlpToDataTable(int supplierCode, Hashtable supplierSlpInf, Hashtable supplierDtlInf, Hashtable paymentSlpTable)
        {
            if (_suplierPayDataView.Count != 0)
            {
                // ���z�f�[�^��(�ӕ�)�ɑO��c���s�E�J�z�c���s���쐬���� 
                for (int index = 0; index < _suplierPayDataView.Count; index++)
                {
                    // DataRow �� �x�����z�N���X
                    StockLedgerPay stockLedgerPay = GetStockLedgerPayFromDataRow(_suplierPayDataView[index].Row);

                    //�e�����Ƃ̊ӏ������Ƃɖ��׍s���쐬
                    //�d������e�[�u���������擾
                    StockLedgerSupplier csLedgerSupplier = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[stockLedgerPay.PayeeCode.ToString() + "_" + TDateTime.DateTimeToLongDate(stockLedgerPay.AddUpDate).ToString() + "_" + stockLedgerPay.AddUpSecCode];

                    // KEY���̐ݒ�
                    int keyDate = TDateTime.DateTimeToLongDate(stockLedgerPay.AddUpDate);
                    string addUpSecCd = stockLedgerPay.AddUpSecCode;

                    #region �c�����Ă̂��Ɖ�p���Ɗ���������B�ꎞ����
                    //// �O��c�����L��ꍇ�O��c���s�쐬
                    //if (stockLedgerPay.LastTimePayment != 0)
                    //{
                    //    //�ʏ�Search�Ŗ����f�[�^�̏ꍇ�ɏ�����ԂőO��c���s�͍쐬���Ȃ�
                    //    if (stockLedgerPay.CloseFlag == (int)CloseFlagState.Close)
                    //    {
                    //        // �O��c���s�쐬
                    //        _stockLedgerSlipDataTable.Rows.Add(
                    //            SetDataRowBalance((int)BalanceCode.Balance, stockLedgerPay, addUpSecCd, keyDate));
                    //    }
                    //}
                    #endregion
                }
                // �x�����|�E�x���`�[���׍s���쐬����
                SettingDataSlpLedgerTable(supplierSlpInf, supplierDtlInf, paymentSlpTable);
            }
        }

        #endregion

        #region �������׃f�[�^�ݒ菈��
        /// <summary>
		/// �������׃f�[�^�ݒ菈��
		/// </summary>
        /// <param name="supplierSlpInf">�d���`�[���</param>
        /// <param name="supplierDtlInf">�d�����׏��</param>
        /// <param name="paymentSlpTable">�x���`�[�e�[�u��</param>
        /// <remarks>
		/// <br>Note       : �x�����z���R�[�h�̌v��͈͂̔���E�x���`�[�f�[�^���������׃e�[�u���ɐݒ肵�܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
        private static void SettingDataSlpLedgerTable(Hashtable supplierSlpInf, Hashtable supplierDtlInf, Hashtable paymentSlpTable)
        {
            if (supplierSlpInf != null)
            {
                // �d���`�[�s�쐬(HashTable Key: �v��N����(int),Value: �Y���v��N�����̔��ヌ�R�[�h���X�g)
                foreach (DictionaryEntry de in supplierSlpInf)
                {
                    int addUpDate = (int)de.Key;

                    ArrayList accPayList = (ArrayList)de.Value;

                    foreach (LedgerStockSlipWork accPayWork in accPayList)
                    {
                        // �x�����[�h�ŏ���Œ���(���|�p)�܂��͎c������(���|�p)�̏ꍇ�͎��f�[�^
                        if ((_imode == 0) && ((accPayWork.StockGoodsCd == 4) || (accPayWork.StockGoodsCd == 5))) continue;

                        //���׃e�[�u����Row��Add
                        _stockLedgerSlipDataTable.Rows.Add(SetDataRowFromAccPay(addUpDate, accPayWork));
                    }
                }
            }

            if (supplierDtlInf != null)
            {
                // �d�����ד`�[���׍s�쐬(HashTable Key: �v��N����(int),Value: �Y���v��N�����̎x���`�[���R�[�h���X�g)
                foreach (DictionaryEntry de in supplierDtlInf)
                {
                    int addUpDate = (int)de.Key;
                    ArrayList accPayDtlList = (ArrayList)de.Value;

                    foreach (LedgerStockDetailWork accPayDtlWork in accPayDtlList)
                    {
                        // �x�����[�h�ŏ���Œ���(���|�p)�܂��͎c������(���|�p)�̏ꍇ�͎��f�[�^
                        if ((_imode == 0) && ((accPayDtlWork.StockGoodsCd == 4) || (accPayDtlWork.StockGoodsCd == 5))) continue;

                        _stockLedgerDtlDataTable.Rows.Add(SetDataRowFromAccPayDtl(addUpDate, accPayDtlWork));
                    }
                }

            }

            if (paymentSlpTable != null)
            {
                // �x���`�[�s�쐬(HashTable Key: �v��N����(int),Value: �Y���v��N�����̎x���`�[���R�[�h���X�g)
                foreach (DictionaryEntry de in paymentSlpTable)
                {
                    int addUpDate = (int)de.Key;
                    ArrayList paymentSlpList = (ArrayList)de.Value;

                    // --- DEL 2012/11/01 ---------->>>>>
                    //foreach (LedgerPaymentSlpWork paymentSlpWork in paymentSlpList)
                    //{
                    //    _stockLedgerSlipDataTable.Rows.Add(SetDataRowFromPaymentSlp(addUpDate, paymentSlpWork));
                    //    _stockLedgerDtlDataTable.Rows.Add(SetDataRowFromPaymentDtl(addUpDate, paymentSlpWork));
                    //}
                    // --- DEL 2012/11/01 ----------<<<<<

                    // --- ADD 2012/11/01 ---------->>>>>
                    for (int index = 0; index < paymentSlpList.Count; index++)
                    {
                        // ���ݏ������̃f�[�^
                        LedgerPaymentSlpWork paymentSlpWork = (LedgerPaymentSlpWork)paymentSlpList[index];
                        // ���s�̃f�[�^
                        LedgerPaymentSlpWork nextPaymentSlpWork = null;
                        
                        if (index + 1 < paymentSlpList.Count)
                        {
                            // ���s�̃f�[�^�Z�b�g
                            nextPaymentSlpWork = (LedgerPaymentSlpWork)paymentSlpList[index + 1];
                        }

                        if (paymentSlpWork.MoneyKindDiv != 0)
                        {
                            // ���킪�o�^����Ă���Βʏ�̃f�[�^�s�𐶐�
                            _stockLedgerSlipDataTable.Rows.Add(SetDataRowFromPaymentSlp(addUpDate, paymentSlpWork));
                            _stockLedgerDtlDataTable.Rows.Add(SetDataRowFromPaymentDtl(addUpDate, paymentSlpWork));
                        }

                        // �ŏI�s�܂��͌��ݏ������s�Ǝ��s�̓`�[No���قȂ�ꍇ
                        if (nextPaymentSlpWork == null || paymentSlpWork.PaymentSlipNo != nextPaymentSlpWork.PaymentSlipNo)
                        {
                            // ���ݏ������s�萔���s�ƒl���s��ǉ�����
                            if (paymentSlpWork.FeePayment != 0)
                            {
                                _stockLedgerSlipDataTable.Rows.Add(SetDataFeeRowFromPaymentSlp(addUpDate, paymentSlpWork));
                                _stockLedgerDtlDataTable.Rows.Add(SetDataFeeRowFromPaymentDtl(addUpDate, paymentSlpWork));
                            }
                            if (paymentSlpWork.DiscountPayment != 0)
                            {
                                _stockLedgerSlipDataTable.Rows.Add(SetDataDiscountRowFromPaymentSlp(addUpDate, paymentSlpWork));
                                _stockLedgerDtlDataTable.Rows.Add(SetDataDiscountRowFromPaymentDtl(addUpDate, paymentSlpWork));
                            }
                        }
                    }
                    // --- ADD 2012/11/01 ----------<<<<<
                }
            }
        }
        #endregion

        #region �d����x�����z�}�X�^�f�[�^���X�g��StaticMemory�ݒ菈��

        /// <summary>
		/// �d����x�����z�}�X�^�f�[�^���X�g��StaticMemory�ݒ菈��
		/// </summary>
		/// <param name="supplierPayList">�d����x�����z�}�X�^�f�[�^���X�g</param>
		/// <remarks>
		/// <br>Note        : �d����x�����z�}�X�^�̎d�������StaticMemory�֐ݒ肵�܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static void SetStaticFromSupplierPayList(ArrayList supplierPayList)
		{
			foreach (SuplierPayInfGetWork suplierPayInfGetWork in supplierPayList)
			{
                ////�L�[��(�x���� + �v��� + ���_)�ɕύX
                //string key = suplierPayInfGetWork.PayeeCode.ToString() + "_" + TDateTime.DateTimeToLongDate(suplierPayInfGetWork.AddUpDate).ToString() + "_" + suplierPayInfGetWork.AddUpSecCode;
                //// �d������ݒ�
                //if (!_stockLedgerSupplierInfoTable.Contains(key))
                //{

                //    //�d����x�����z�}�X�^�f�[�^���d���� + �v��� + ���_���̃f�[�^���쐬���܂��B
                //    _stockLedgerSupplierInfoTable.Add(key, CopyToStockLedgerSupplier(suplierPayInfGetWork));
                //}

				//�d������z(��)�e�[�u���쐬
                DataRow row = GetDataRowFromSuplierPayInfGetWork(suplierPayInfGetWork);
				_suplierPayDataTable.Rows.Add(row);
			}
        }

        #endregion       
        
        #region �d����x�����z���f�[�^�s�ݒ菈��(�x��)
		/// <summary>
		/// �d����x�����z���f�[�^�s�ݒ菈��(�x��)
		/// </summary>
        /// <param name="suplierPayInfGetWork">�d����x�����z���p�����[�^</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : �d����x�����z�����f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.07.26</br>
		/// </remarks>
		private static DataRow GetDataRowFromSuplierPayInfGetWork(SuplierPayInfGetWork suplierPayInfGetWork)
		{
			DataRow newRow = _suplierPayDataTable.NewRow();

			GetDataRowFromSuplierPayInfGetWork( ref newRow, suplierPayInfGetWork );

			return newRow;
		}
		#endregion

        #region �d����x�����z�p�����[�^���d������z���f�[�^�s�ݒ菈��
        /// <summary>
		/// �d����x�����z�p�����[�^���d������z���f�[�^�s�ݒ菈��
		/// </summary>
        /// <param name="dr">�f�[�^Row</param>
		/// <param name="work"> �d����x�����z�p�����[�^</param>
		/// <returns>�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        :  �d����x�����z�p�����[�^���d������z�f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
        /// <br>UpdateNote  :  ����œ]�ŕ��������f����Ă��Ȃ����Ή��B</br>
        /// <br>Programmer  : FSI�֓� �a�G</br>
        /// <br>Date        : 2012/11/01</br>
        /// 
		/// </remarks>
        //private static void GetDataRowFromSuplierPayInfGetWork(ref DataRow dr, SuplierPayInfGetWork work)
		private static void GetDataRowFromSuplierPayInfGetWork(ref DataRow dr, SuplierPayInfGetWork work)
        {
            //dr[COL_Spl_EnterpriseCode] = work.EnterpriseCode; // ��ƃR�[�h
            dr[COL_Spl_AddUpSecCode] = work.AddUpSecCode; // �v�㋒�_�R�[�h
            dr[COL_Spl_AddUpSecName] = GetSectionName(work.AddUpSecCode); // �v�㋒�_�R�[�h
            dr[COL_Spl_PayeeCode] = work.PayeeCode; // �x����R�[�h
            //dr[COL_Spl_PayeeName] = work.PayeeName; // �x���於��
            //dr[COL_Spl_PayeeName2] = work.PayeeName2; // �x���於��2
            dr[COL_Spl_PayeeSnm] = work.PayeeSnm; // �x���旪��
            //dr[COL_Spl_ResultsSectCd] = work.ResultsSectCd; // ���ы��_�R�[�h
            //dr[COL_Spl_SupplierCd] = work.SupplierCd; // �d����R�[�h
            //dr[COL_Spl_SupplierNm1] = work.SupplierNm1; // �d���於1
            //dr[COL_Spl_SupplierNm2] = work.SupplierNm2; // �d���於2
            //dr[COL_Spl_SupplierSnm] = work.SupplierSnm; // �d���旪��
            dr[COL_Spl_AddUpDate] = TDateTime.DateTimeToLongDate(work.AddUpDate); // �v��N����
            dr[COL_Spl_AddUpYearMonth] = TDateTime.DateTimeToLongDate(work.AddUpYearMonth); // �v��N��
            dr[COL_Spl_LastTimePayment] = work.LastTimePayment; // �O��x�����z
            dr[COL_Spl_StockTtl2TmBfBlPay] = work.StockTtl2TmBfBlPay; // �d��2��O�c���i�x���v�j
            dr[COL_Spl_StockTtl3TmBfBlPay] = work.StockTtl3TmBfBlPay; // �d��3��O�c���i�x���v�j
            dr[COL_Spl_ThisTimePayNrml] = work.ThisTimePayNrml; // ����x�����z�i�ʏ�x���j
            dr[COL_Spl_ThisTimeTtlBlcPay] = work.ThisTimeTtlBlcPay; // ����J�z�c���i�x���v�j
            dr[COL_Spl_OfsThisTimeStock] = work.OfsThisTimeStock; // ���E�㍡��d�����z
            dr[COL_Spl_OfsThisStockTax] = work.OfsThisStockTax; // ���E�㍡��d�������
            dr[COL_Spl_ThisStckPricRgds] = work.ThisStckPricRgds; // ����ԕi���z
            dr[COL_Spl_ThisStcPrcTaxRgds] = work.ThisStcPrcTaxRgds; // ����ԕi�����
            dr[COL_Spl_ThisStckPricDis] = work.ThisStckPricDis; // ����l�����z
            dr[COL_Spl_ThisStcPrcTaxDis] = work.ThisStcPrcTaxDis; // ����l�������
            // 2009.03.02 30413 ���� �ԕi�l���̕����𔽓]������ >>>>>>START
            //dr[COL_Spl_ThisStckPricRgdsDis] = work.ThisStckPricRgds + work.ThisStckPricDis; // ����ԕi���z
            dr[COL_Spl_ThisStckPricRgdsDis] = -(work.ThisStckPricRgds + work.ThisStckPricDis); // ����ԕi�l�����z
            // 2009.03.02 30413 ���� �ԕi�A�l���̕����𔽓]������ <<<<<<END
            dr[COL_Spl_OfsThisTimeStockTax] = work.ThisTimePayNrml + work.ThisStckPricRgds + work.ThisStckPricDis; // �ō��d���z
            //dr[COL_Spl_TaxAdjust] = work.TaxAdjust; // ����Œ����z
            //dr[COL_Spl_BalanceAdjust] = work.BalanceAdjust; // �c�������z
            dr[COL_Spl_StockTotalPayBalance] = work.StockTotalPayBalance; // �d�����v�c���i�x���v�j
            dr[COL_Spl_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(work.CAddUpUpdExecDate); // �����X�V���s�N����
            dr[COL_Spl_StartCAddUpUpdDate] = TDateTime.DateTimeToLongDate(work.StartCAddUpUpdDate); // �����X�V�J�n�N����
            //dr[COL_Spl_LastCAddUpUpdDate] = work.LastCAddUpUpdDate; // �O������X�V�N����
            dr[COL_Spl_StockSlipCount] = work.StockSlipCount; // �d���`�[����
            //dr[COL_Spl_CloseFlg] = work.CloseFlg; // ���ς݃t���O
            if (_imode == (int)Mode.Shr) { dr[COL_Spl_SlitTitle] = "�x���c"; }
            else if (_imode == (int)Mode.Kai) { dr[COL_Spl_SlitTitle] = "���|�c"; }// ����p �x���c�E���|�c

            // 2009.02.24 30413 ���� ����d�����z�̒ǉ� >>>>>>START
            dr[COL_Spl_ThisTimeStockPrice] = work.ThisTimeStockPrice;   // ����d�����z
            // 2009.02.24 30413 ���� ����d�����z�̒ǉ� <<<<<<END

            // --- ADD 2012/11/01 ---------->>>>>
            dr[COL_Spl_SuppCTaxLayCd] = work.SuppCTaxLayCd;   // ����œ]�ŕ���
            // --- ADD 2012/11/01 ----------<<<<<

        }

        #endregion    
            
        // >>> danger
        #region ���d���f�[�^���������׏��f�[�^�s�ݒ菈��
        /// <summary>
		/// �d���f�[�^���������׏��f�[�^�s�ݒ菈��
		/// </summary>
		/// <param name="addUpDate">�v��N����</param>
        /// <param name="stockSlipWork">�d���f�[�^�N���X</param>
		/// <returns>�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        :�d���f�[�^���������׏��f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static DataRow SetDataRowFromAccPay(int addUpDate, LedgerStockSlipWork stockSlipWork/*, ArrayList paymentSlpTable*/)
		{
			DataRow dr = _stockLedgerSlipDataTable.NewRow();

            //�e�[�u���̃L�[��ύX
            //StockLedgerSupplier csLedgerSupplier = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[stockSlipWork.PayeeCode.ToString() + "_" + addUpDate.ToString()+ "_" + stockSlipWork.SectionCode];

            #region [��D��Table�i�[����]
            ////�\������
            //dr[CT_SplLedger_AddUpADateDisp	] = TDateTime.DateTimeToString("yyyy.mm.dd", stockSlipWork.StockAddUpADate);	// �v����t(�\���p)
            //dr[CT_SplLedger_SlipNo] = GetSupplierSlipNo(stockSlipWork);					                        // �d���`�[�ԍ��E�x���`�[�ԍ�
            //dr[CT_SplLedger_SlipKindNm] = GetSlipKindNm(stockSlipWork.SupplierSlipCd);		                                // �d���`�[�敪����

            //string slipDetail = "";
            
            //switch (stockSlipWork.StockGoodsCd)
            //{ 
            //    case 0:
            //        slipDetail = "���i";
            //        break;
            //    case 1:
            //        slipDetail = "�� �i �O";
            //        break;
            //    case 2:
            //        slipDetail = "����Œ���";
            //        break;
            //    case 3:
            //        slipDetail = "�c������";
            //        break;
            //    case 4:
            //        slipDetail = "���|�p����Œ���";
            //        break;
            //    case 5:
            //        slipDetail = "���|�p�c������";
            //        break;
            //}
            //dr[CT_SplLedger_Detail] = slipDetail;

            //if ((stockSlipWork.StockGoodsCd == 3) || (stockSlipWork.StockGoodsCd == 5))
            //{
            //    dr[CT_SplLedger_StockPrice] = stockSlipWork.StockTotalPrice;
            //    dr[CT_SplLedger_StockPrice1] = stockSlipWork.StockTotalPrice;
            //}
            //else
            //{
            //    dr[CT_SplLedger_StockPrice] = stockSlipWork.StockSubttlPrice;						                        // �d�����z(�d�����z���v(�Ŕ�)���g�p)
            //    dr[CT_SplLedger_StockPrice1] = 0;
            //}

            //dr[CT_SplLedger_ConsTax] = stockSlipWork.StockPriceConsTax;                                                     // ����Ŋz

            //if ((stockSlipWork.StockGoodsCd == 2) || (stockSlipWork.StockGoodsCd == 4))
            //{
            //    dr[CT_SplLedger_ConsTax1] = stockSlipWork.StockPriceConsTax;                                                // ����Ŋz
            //}
            //else
            //{
            //    dr[CT_SplLedger_ConsTax1] = 0;
            //}

            //dr[CT_SplLedger_StockTotalPrice	] = stockSlipWork.StockTotalPrice;		                                        // �d�����z
            
            //dr[CT_SplLedger_Payment			] = DBNull.Value;										                        // �x�����z
            //dr[CT_SplLedger_Balance			] = 0;													                        // �c��(�c���v�Z�͎d���E�x���f�[�^���Z�b�g������Ōv�Z���܂�)
            
            //if(stockSlipWork.SupplierSlipCd == (int)SupplierLedgerSlipCdDiv.Back)
            //{
            //    //�ԕi�`�[���͕ԕi���R����(�������������̂œr�؂�邪�B)
            //    dr[CT_SplLedger_Note        ] = stockSlipWork.SupplierSlipNote1;    //�ԕi���R������炵��������ȍ��ڂ̓N���X�ɖ����B
            //}
            //else if(stockSlipWork.SupplierSlipCd == (int)SupplierLedgerSlipCdDiv.Stock)
            //{
            //    //�d���`�[���͓`�[���l�P����(�������������̂Ő؂�邪�ǂ����邩)
            //    dr[CT_SplLedger_Note            ] = stockSlipWork.SupplierSlipNote1;
            //}

            //dr[CT_SplLedger_PayeeCode	] = stockSlipWork.PayeeCode;						        // �x����R�[�h
            //dr[CT_SplLedger_CustomerCode	] = stockSlipWork.SupplierCd;						    // ���Ӑ�R�[�h
            //dr[CT_SplLedger_AddUpDate		] = addUpDate;											// �v��N����
            //dr[CT_SplLedger_RecordCode		] = (int)RecordCode.AccPay;								// ���R�[�h�敪(0:�x�����|,1:�x���`�[)			
            //dr[CT_SplLedger_BalanceCode		] = (int)BalanceCode.Others;							// �O�c�J�z�敪(0:�O�c,1:���̑�(�x�����| or �x���`�[),2:�����(�����P�ʂ̏ꍇ�̂�),3:�J�z)
            //dr[CT_SplLedger_DebitNoteDiv	] = stockSlipWork.DebitNoteDiv;                         // �ԓ`�敪(0:��,1:��,2���E�ςݍ�)           
            ////�ԓ`�敪�����`���ԓ`�A���d���`�[�ԍ����O�Ŗ���
            //if (stockSlipWork.DebitNoteDiv == 0 && stockSlipWork.DebitNLnkSuppSlipNo != 0)
            //{
            //    //����
            //    dr[CT_SplLedger_DebitNoteDiv] = 2;
            //}		
            //dr[CT_SplLedger_AddUpADate		] = stockSlipWork.StockAddUpADate;						// �v����t	
            //dr[CT_SplLedger_AddUpADateInt	] = TDateTime.DateTimeToLongDate(stockSlipWork.StockAddUpADate);
            //dr[CT_SplLedger_SupplierSlipCd	] = stockSlipWork.SupplierSlipCd;						// �d���`�[�敪(10:�d��,20:�ԕi)           
            //dr[CT_SplLedger_AddUpSecCode	] = stockSlipWork.StockAddUpSectionCd;					// �v�㋒�_�R�[�h
            //dr[CT_SplLedger_AddUpSecName	] = GetSectionName(stockSlipWork.StockAddUpSectionCd);	// �v�㋒�_����
            //dr[CT_SplLedger_PartySaleSlipNum] = stockSlipWork.PartySaleSlipNum;		                // �����`�[�ԍ�
            //dr[CT_SplLedger_SupplierFormal	] = stockSlipWork.SupplierFormal;	                    // �d���`��
            //dr[CT_SplLedger_SupplierSlipNote1] = stockSlipWork.SupplierSlipNote1;		            // �d���`�[���l1
            //dr[CT_SplLedger_SupplierSlipNote2] = stockSlipWork.SupplierSlipNote2;		            // �d���`�[���l2
            //dr[CT_SplLedger_DraftPayTimeLimit] = "";		                                        // ��`�x������
            //dr[CT_SplLedger_PrtDiv] = 1;                                                            // �󎚋敪 
            #endregion

            dr[CT_SplLedger_EnterpriseCode] = stockSlipWork.EnterpriseCode; // ��ƃR�[�h
            dr[CT_SplLedger_AddUpDate] = addUpDate; // �v����t(���)
            dr[CT_SplLedger_SupplierFormal] = stockSlipWork.SupplierFormal; // �d���`��
            dr[CT_SplLedger_SupplierSlipNo] = stockSlipWork.SupplierSlipNo; // �d���`�[�ԍ�
            dr[CT_SplLedger_SlipKindNm] = "�d��"; // �d���`�[���
            dr[CT_SplLedger_SectionCode] = stockSlipWork.SectionCode; // ���_�R�[�h
            dr[CT_SplLedger_DebitNoteDiv] = stockSlipWork.DebitNoteDiv; // �ԓ`�敪
            dr[CT_SplLedger_DebitNLnkSuppSlipNo] = stockSlipWork.DebitNLnkSuppSlipNo; // �ԍ��A���d���`�[�ԍ�
            dr[CT_SplLedger_SupplierSlipCd] = stockSlipWork.SupplierSlipCd; // �d���`�[�敪
            dr[CT_SplLedger_StockGoodsCd] = stockSlipWork.StockGoodsCd; // �d�����i�敪
            dr[CT_SplLedger_StockSectionCd] = stockSlipWork.StockSectionCd; // �d�����_�R�[�h
            dr[CT_SplLedger_StockAddUpSectionCd] = stockSlipWork.StockAddUpSectionCd; // �d���v�㋒�_�R�[�h
            dr[CT_SplLedger_InputDay] = TDateTime.DateTimeToLongDate(stockSlipWork.InputDay); // ���͓�
            dr[CT_SplLedger_ArrivalGoodsDay] = TDateTime.DateTimeToLongDate(stockSlipWork.ArrivalGoodsDay); // ���ד�
            dr[CT_SplLedger_StockDate] = TDateTime.DateTimeToLongDate(stockSlipWork.StockDate); // �d����
            dr[CT_SplLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate(stockSlipWork.StockAddUpADate); // �d���v����t
            dr[CT_SplLedger_StockRecordCd] = (int)RecordCode.AccPay; // �d�����R�[�h�敪
            dr[CT_SplLedger_StockInputCode] = stockSlipWork.StockInputCode; // �d�����͎҃R�[�h
            dr[CT_SplLedger_StockInputName] = stockSlipWork.StockInputName; // �d�����͎Җ���
            dr[CT_SplLedger_StockAgentCode] = stockSlipWork.StockAgentCode; // �d���S���҃R�[�h
            dr[CT_SplLedger_StockAgentName] = stockSlipWork.StockAgentName; // �d���S���Җ���
            dr[CT_SplLedger_PayeeCode] = stockSlipWork.PayeeCode; // �x����R�[�h
            dr[CT_SplLedger_PayeeSnm] = stockSlipWork.PayeeSnm; // �x���旪��
            dr[CT_SplLedger_SupplierCd] = stockSlipWork.SupplierCd; // �d����R�[�h
            dr[CT_SplLedger_SupplierNm1] = stockSlipWork.SupplierNm1; // �d���於1
            dr[CT_SplLedger_SupplierNm2] = stockSlipWork.SupplierNm2; // �d���於2
            dr[CT_SplLedger_SupplierSnm] = stockSlipWork.SupplierSnm; // �d���旪��
            dr[CT_SplLedger_StockTotalPrice] = stockSlipWork.StockTotalPrice; // �d�����z���v
            dr[CT_SplLedger_StockSubttlPrice] = stockSlipWork.StockSubttlPrice; // �d�����z���v
            dr[CT_SplLedger_StockPriceConsTax] = stockSlipWork.StockPriceConsTax; // �d�����z����Ŋz
            dr[CT_SplLedger_PartySaleSlipNum] = stockSlipWork.PartySaleSlipNum; // �����`�[�ԍ�
            dr[CT_SplLedger_SupplierSlipNote1] = stockSlipWork.SupplierSlipNote1; // �d���`�[���l1
            dr[CT_SplLedger_SupplierSlipNote2] = stockSlipWork.SupplierSlipNote2; // �d���`�[���l2
            dr[CT_SplLedger_UoeRemark1] = stockSlipWork.UoeRemark1; // �t�n�d���}�[�N�P
            dr[CT_SplLedger_UoeRemark2] = stockSlipWork.UoeRemark2; // �t�n�d���}�[�N�Q
            dr[CT_SplLedger_StockRecordCd] = RecordCode.AccPay;

            return dr;
        }
        #endregion

        #region �x���`�[��񁨌����`�[���f�[�^�s�ݒ菈��
        /// <summary>
		/// �x���`�[��񁨌����`�[���f�[�^�s�ݒ菈��
		/// </summary>
		/// <param name="addUpDate">�v��N����(���P��)</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : �x���`�[��񂩂猳�����׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
        /// <br>UpdateNote	: �x���f�[�^�ɒl���z�E�萔���z�����f����Ă��Ȃ����Ή��B</br>
        /// <br>Programer   : FSI�֓� �a�G</br>
        /// <br>Date        : 2012/11/01</br>
		/// </remarks>
		private static DataRow SetDataRowFromPaymentSlp(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
		{
			DataRow dr = _stockLedgerSlipDataTable.NewRow();
            ////�\������
            dr[CT_SplLedger_AddUpDate] = addUpDate;
            dr[CT_SplLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// �v����t(�\���p)
            dr[CT_SplLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // �d���`�[�ԍ��E�x���`�[�ԍ�
            dr[CT_SplLedger_SlipKindNm] = "�x��";                                                                       // �`�[��ʖ���
            //dr[CT_SplLedger] = string.Format("�x���y{0}�z", paymentSlpWork.MoneyKindName);
            dr[CT_SplLedger_StockSubttlPrice] = DBNull.Value;										                    // �d�����z
            dr[CT_SplLedger_StockPriceConsTax] = DBNull.Value;										                    // ����Ŋz
            dr[CT_SplLedger_StockTotalPrice] = DBNull.Value;										                    // �d�����z���v
            dr[CT_SplLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_SplLedger_Payment] = paymentSlpWork.Payment;						                    // �x�����z
            
            //dr[CT_SplLedger_Balance] = 0;													                    // �c��			
            dr[CT_SplLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // ���l(�`�[�K�p)
            dr[CT_SplLedger_GoodsName] = paymentSlpWork.MoneyKindName;							                        // �x�����z�敪��
            dr[CT_SplLedger_GoodsDiv] = paymentSlpWork.MoneyKindDiv;							                        // �x�����z�敪

            //��\������
            dr[CT_SplLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // �ԓ`�敪(0:��,1:��,2���E�ςݍ�)        
            dr[CT_SplLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // �x����R�[�h
            dr[CT_SplLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // ���Ӑ�R�[�h
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // �v��N����
            dr[CT_SplLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // ���R�[�h�敪(0:�x�����|,1:�x���`�[)
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // �d���`�[�敪(10:�d��,20:�ԕi)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // �O�c�J�z�敪(0:�O�c,1:���̑�(�x�����| or �x���`�[),2:�����(�����P�ʂ̏ꍇ�̂�),3:�J�z)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // �v����t
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // �v����t
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // �d���`�[���			
            dr[CT_SplLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // �v�㋒�_�R�[�h
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // �v�㋒�_����
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // �v�㋒�_����
            dr[CT_SplLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // ��`�x������	
            //dr[CT_SplLedger_] = 1;                                                                                     // �󎚋敪 

            return dr;
        }

        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary>
        /// �x���`�[��񁨌����`�[���f�[�^�s�ݒ菈��(�萔��)
        /// </summary>
        /// <param name="addUpDate">�v��N����(���P��)</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note	: �x���f�[�^�����Ɏ萔���z�s�E�l���z�s�𐶐�����</br>
        /// <br>Programer   : FSI�֓� �a�G</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataFeeRowFromPaymentSlp(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerSlipDataTable.NewRow();
            ////�\������
            dr[CT_SplLedger_AddUpDate] = addUpDate;
            dr[CT_SplLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// �v����t(�\���p)
            dr[CT_SplLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // �d���`�[�ԍ��E�x���`�[�ԍ�
            dr[CT_SplLedger_SlipKindNm] = "�x��";                                                                       // �`�[��ʖ���
            //dr[CT_SplLedger] = string.Format("�x���y{0}�z", paymentSlpWork.MoneyKindName);
            dr[CT_SplLedger_StockSubttlPrice] = DBNull.Value;										                    // �d�����z
            dr[CT_SplLedger_StockPriceConsTax] = DBNull.Value;										                    // ����Ŋz
            dr[CT_SplLedger_StockTotalPrice] = DBNull.Value;										                    // �d�����z���v
            dr[CT_SplLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_SplLedger_Payment] = paymentSlpWork.FeePayment;						                    // �x�����z(�萔���z)

            //dr[CT_SplLedger_Balance] = 0;													                    // �c��			
            dr[CT_SplLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // ���l(�`�[�K�p)
            dr[CT_SplLedger_GoodsName] = "�萔��";							                        // �x�����z�敪��(�萔��)
            dr[CT_SplLedger_GoodsDiv] = 998;      						                        // �x�����z�敪(PMKOU02033P_02A4C_Detail.cs�ƍ��킹��)

            //��\������
            dr[CT_SplLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // �ԓ`�敪(0:��,1:��,2���E�ςݍ�)        
            dr[CT_SplLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // �x����R�[�h
            dr[CT_SplLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // ���Ӑ�R�[�h
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // �v��N����
            dr[CT_SplLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // ���R�[�h�敪(0:�x�����|,1:�x���`�[)
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // �d���`�[�敪(10:�d��,20:�ԕi)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // �O�c�J�z�敪(0:�O�c,1:���̑�(�x�����| or �x���`�[),2:�����(�����P�ʂ̏ꍇ�̂�),3:�J�z)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // �v����t
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // �v����t
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // �d���`�[���			
            dr[CT_SplLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // �v�㋒�_�R�[�h
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // �v�㋒�_����
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // �v�㋒�_����
            //dr[CT_SplLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // ��`�x������	
            //dr[CT_SplLedger_] = 1;                                                                                     // �󎚋敪 

            return dr;
        }

        /// <summary>
        /// �x���`�[��񁨌����`�[���f�[�^�s�ݒ菈��(�l��)
        /// </summary>
        /// <param name="addUpDate">�v��N����(���P��)</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note	: �x���f�[�^�����Ɏ萔���z�s�𐶐�����</br>
        /// <br>Programer   : FSI�֓� �a�G</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataDiscountRowFromPaymentSlp(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerSlipDataTable.NewRow();
            ////�\������
            dr[CT_SplLedger_AddUpDate] = addUpDate;
            dr[CT_SplLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// �v����t(�\���p)
            dr[CT_SplLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // �d���`�[�ԍ��E�x���`�[�ԍ�
            dr[CT_SplLedger_SlipKindNm] = "�x��";                                                                       // �`�[��ʖ���
            //dr[CT_SplLedger] = string.Format("�x���y{0}�z", paymentSlpWork.MoneyKindName);
            dr[CT_SplLedger_StockSubttlPrice] = DBNull.Value;										                    // �d�����z
            dr[CT_SplLedger_StockPriceConsTax] = DBNull.Value;										                    // ����Ŋz
            dr[CT_SplLedger_StockTotalPrice] = DBNull.Value;										                    // �d�����z���v
            dr[CT_SplLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_SplLedger_Payment] = paymentSlpWork.DiscountPayment;						                    // �x�����z(�l���z)

            //dr[CT_SplLedger_Balance] = 0;													                    // �c��			
            dr[CT_SplLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // ���l(�`�[�K�p)
            dr[CT_SplLedger_GoodsName] = "�l��";							                        // �x�����z�敪��(�l��)
            dr[CT_SplLedger_GoodsDiv] = 999;      						                        // �x�����z�敪(PMKOU02033P_02A4C_Detail.cs�ƍ��킹��)

            //��\������
            dr[CT_SplLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // �ԓ`�敪(0:��,1:��,2���E�ςݍ�)        
            dr[CT_SplLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // �x����R�[�h
            dr[CT_SplLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // ���Ӑ�R�[�h
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // �v��N����
            dr[CT_SplLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // ���R�[�h�敪(0:�x�����|,1:�x���`�[)
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // �d���`�[�敪(10:�d��,20:�ԕi)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // �O�c�J�z�敪(0:�O�c,1:���̑�(�x�����| or �x���`�[),2:�����(�����P�ʂ̏ꍇ�̂�),3:�J�z)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // �v����t
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // �v����t
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // �d���`�[���			
            dr[CT_SplLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // �v�㋒�_�R�[�h
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // �v�㋒�_����
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // �v�㋒�_����
            //dr[CT_SplLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // ��`�x������	
            //dr[CT_SplLedger_] = 1;                                                                                     // �󎚋敪 

            return dr;
        }
        // --- ADD 2012/11/01 ----------<<<<<
        #endregion

        #region �x���`�[��񁨌������׏��f�[�^�s�ݒ菈��
        /// <summary>
        /// �x���`�[��񁨌������׏��f�[�^�s�ݒ菈��
        /// </summary>
        /// <param name="addUpDate">�v��N����(���P��)</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note	: �x���f�[�^�����ɒl���z�s�𐶐�����</br>
        /// <br>Programer   : FSI�֓� �a�G</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataRowFromPaymentDtl(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerDtlDataTable.NewRow();

            ////�\������
            dr[CT_DtlLedger_AddUpDate] = addUpDate;
            dr[CT_DtlLedger_GoodsName] = paymentSlpWork.MoneyKindName;
            dr[CT_DtlLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// �v����t(�\���p)
            dr[CT_DtlLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // �d���`�[�ԍ��E�x���`�[�ԍ�
            dr[CT_DtlLedger_SlipKindNm] = "�x��";                                                                       // �`�[��ʖ���
            //dr[CT_SplLedger_Detail] = string.Format("�x���y{0}�z", paymentSlpWork.MoneyKindName);
            dr[CT_DtlLedger_StockSubttlPrice] = DBNull.Value;										                    // �d�����z
            dr[CT_DtlLedger_StockPriceConsTax] = DBNull.Value;										                    // ����Ŋz
            dr[CT_DtlLedger_StockTotalPrice] = DBNull.Value;										                    // �d�����z���v
            dr[CT_DtlLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_DtlLedger_Payment] = paymentSlpWork.Payment;						                    // �x�����z
            
            //dr[CT_SplLedger_Balance] = 0;													                    // �c��			
            dr[CT_DtlLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // ���l(�`�[�K�p)

            //��\������
            dr[CT_DtlLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // �ԓ`�敪(0:��,1:��,2���E�ςݍ�)        
            dr[CT_DtlLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // �x����R�[�h
            dr[CT_DtlLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // ���Ӑ�R�[�h
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // �v��N����
            dr[CT_DtlLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // ���R�[�h�敪(0:�x�����|,1:�x���`�[)
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // �d���`�[�敪(10:�d��,20:�ԕi)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // �O�c�J�z�敪(0:�O�c,1:���̑�(�x�����| or �x���`�[),2:�����(�����P�ʂ̏ꍇ�̂�),3:�J�z)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // �v����t
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // �v����t
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // �d���`�[���			
            dr[CT_DtlLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // �v�㋒�_�R�[�h
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // �v�㋒�_����
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // �v�㋒�_����
            dr[CT_DtlLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // ��`�x������	
            //dr[CT_SplLedger_] = 1;                                                                                     // �󎚋敪 

            return dr;
        }
        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary>
        /// �x���`�[��񁨌������׏��f�[�^�s�ݒ菈��(�萔��)
        /// </summary>
        /// <param name="addUpDate">�v��N����(���P��)</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note	: �x���f�[�^�����Ɏ萔���z�s�𐶐�����</br>
        /// <br>Programer   : FSI�֓� �a�G</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataFeeRowFromPaymentDtl(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerDtlDataTable.NewRow();

            ////�\������
            dr[CT_DtlLedger_AddUpDate] = addUpDate;
            dr[CT_DtlLedger_GoodsName] = "�萔��";
            dr[CT_DtlLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// �v����t(�\���p)
            dr[CT_DtlLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // �d���`�[�ԍ��E�x���`�[�ԍ�
            dr[CT_DtlLedger_SlipKindNm] = "�x��";                                                                       // �`�[��ʖ���
            //dr[CT_SplLedger_Detail] = string.Format("�x���y{0}�z", paymentSlpWork.MoneyKindName);
            dr[CT_DtlLedger_StockSubttlPrice] = DBNull.Value;										                    // �d�����z
            dr[CT_DtlLedger_StockPriceConsTax] = DBNull.Value;										                    // ����Ŋz
            dr[CT_DtlLedger_StockTotalPrice] = DBNull.Value;										                    // �d�����z���v
            dr[CT_DtlLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_DtlLedger_Payment] = paymentSlpWork.FeePayment;						                    // �x�����z(�萔���z)

            //dr[CT_SplLedger_Balance] = 0;													                    // �c��			
            dr[CT_DtlLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // ���l(�`�[�K�p)

            //��\������
            dr[CT_DtlLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // �ԓ`�敪(0:��,1:��,2���E�ςݍ�)        
            dr[CT_DtlLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // �x����R�[�h
            dr[CT_DtlLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // ���Ӑ�R�[�h
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // �v��N����
            dr[CT_DtlLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // ���R�[�h�敪(0:�x�����|,1:�x���`�[)
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // �d���`�[�敪(10:�d��,20:�ԕi)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // �O�c�J�z�敪(0:�O�c,1:���̑�(�x�����| or �x���`�[),2:�����(�����P�ʂ̏ꍇ�̂�),3:�J�z)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // �v����t
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // �v����t
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // �d���`�[���			
            dr[CT_DtlLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // �v�㋒�_�R�[�h
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // �v�㋒�_����
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // �v�㋒�_����
            //dr[CT_DtlLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // ��`�x������	
            //dr[CT_SplLedger_] = 1;                                                                                     // �󎚋敪 

            return dr;
        }

        /// <summary>
        /// �x���`�[��񁨌������׏��f�[�^�s�ݒ菈��(�l��)
        /// </summary>
        /// <param name="addUpDate">�v��N����(���P��)</param>
        /// <param name="paymentSlpWork">�x���`�[�f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note	: �x���f�[�^�����ɒl���z�s�𐶐�����</br>
        /// <br>Programer   : FSI�֓� �a�G</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataDiscountRowFromPaymentDtl(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerDtlDataTable.NewRow();

            ////�\������
            dr[CT_DtlLedger_AddUpDate] = addUpDate;
            dr[CT_DtlLedger_GoodsName] = "�l��";
            dr[CT_DtlLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// �v����t(�\���p)
            dr[CT_DtlLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // �d���`�[�ԍ��E�x���`�[�ԍ�
            dr[CT_DtlLedger_SlipKindNm] = "�x��";                                                                       // �`�[��ʖ���
            //dr[CT_SplLedger_Detail] = string.Format("�x���y{0}�z", paymentSlpWork.MoneyKindName);
            dr[CT_DtlLedger_StockSubttlPrice] = DBNull.Value;										                    // �d�����z
            dr[CT_DtlLedger_StockPriceConsTax] = DBNull.Value;										                    // ����Ŋz
            dr[CT_DtlLedger_StockTotalPrice] = DBNull.Value;										                    // �d�����z���v
            dr[CT_DtlLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_DtlLedger_Payment] = paymentSlpWork.DiscountPayment;						                    // �x�����z(�l���z)

            //dr[CT_SplLedger_Balance] = 0;													                    // �c��			
            dr[CT_DtlLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // ���l(�`�[�K�p)

            //��\������
            dr[CT_DtlLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // �ԓ`�敪(0:��,1:��,2���E�ςݍ�)        
            dr[CT_DtlLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // �x����R�[�h
            dr[CT_DtlLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // ���Ӑ�R�[�h
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // �v��N����
            dr[CT_DtlLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // ���R�[�h�敪(0:�x�����|,1:�x���`�[)
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // �d���`�[�敪(10:�d��,20:�ԕi)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // �O�c�J�z�敪(0:�O�c,1:���̑�(�x�����| or �x���`�[),2:�����(�����P�ʂ̏ꍇ�̂�),3:�J�z)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // �v����t
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // �v����t
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // �d���`�[���			
            dr[CT_DtlLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // �v�㋒�_�R�[�h
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // �v�㋒�_����
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // �v�㋒�_����
            //dr[CT_DtlLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // ��`�x������	
            //dr[CT_SplLedger_] = 1;                                                                                     // �󎚋敪 

            return dr;
        }
        // --- ADD 2012/11/01 ----------<<<<<

        #endregion

        #region ���d�����׃f�[�^���������׏��f�[�^�s�ݒ菈��
        /// <summary>
        /// �d�����׃f�[�^���������׏��f�[�^�s�ݒ菈��
        /// </summary>
        /// <param name="addUpDate">�v��N����</param>
        /// <param name="stockDtlWork">�d�����׃f�[�^�N���X</param>
        /// <returns>�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note        :�d�����׃f�[�^���������׏��f�[�^�s�֐ݒ肵�܂��B</br>
        /// <br>Programmer  : 20081 �D�c �E�l</br>
        /// <br>Date        : 2007.11.26</br>
        /// </remarks>
        private static DataRow SetDataRowFromAccPayDtl(int addUpDate, LedgerStockDetailWork stockDtlWork)
        {
            DataRow dr = _stockLedgerDtlDataTable.NewRow();

            //�e�[�u���̃L�[��ύX
            //StockLedgerSupplier csLedgerSupplier = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[stockDtlWork.PayeeCode.ToString() + "_" + addUpDate.ToString() + "_" + stockDtlWork.SectionCode];

            #region [�e�[�u���Ɍ��ʂ��i�[]
            dr[CT_DtlLedger_EnterpriseCode] = stockDtlWork.EnterpriseCode; // ��ƃR�[�h
            dr[CT_DtlLedger_AddUpDate] = addUpDate; // �v����t(���)
            dr[CT_DtlLedger_SupplierFormal] = stockDtlWork.SupplierFormal; // �d���`��
            dr[CT_DtlLedger_SupplierSlipNo] = stockDtlWork.SupplierSlipNo; // �d���`�[�ԍ�
            dr[CT_DtlLedger_SlipKindNm] = "�d��"; // �d���`�[���
            dr[CT_DtlLedger_SectionCode] = stockDtlWork.SectionCode; // ���_�R�[�h
            dr[CT_DtlLedger_DebitNoteDiv] = stockDtlWork.DebitNoteDiv; // �ԓ`�敪
            dr[CT_DtlLedger_DebitNLnkSuppSlipNo] = stockDtlWork.DebitNLnkSuppSlipNo; // �ԍ��A���d���`�[�ԍ�
            dr[CT_DtlLedger_SupplierSlipCd] = stockDtlWork.SupplierSlipCd; // �d���`�[�敪
            dr[CT_DtlLedger_StockGoodsCd] = stockDtlWork.StockGoodsCd; // �d�����i�敪
            dr[CT_DtlLedger_StockSectionCd] = stockDtlWork.StockSectionCd; // �d�����_�R�[�h
            dr[CT_DtlLedger_StockAddUpSectionCd] = stockDtlWork.StockAddUpSectionCd; // �d���v�㋒�_�R�[�h
            dr[CT_DtlLedger_InputDay] = TDateTime.DateTimeToLongDate(stockDtlWork.InputDay); // ���͓�
            dr[CT_DtlLedger_ArrivalGoodsDay] = TDateTime.DateTimeToLongDate(stockDtlWork.ArrivalGoodsDay); // ���ד�
            dr[CT_DtlLedger_StockDate] = TDateTime.DateTimeToLongDate(stockDtlWork.StockDate); // �d����
            dr[CT_DtlLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate(stockDtlWork.StockAddUpADate); // �d���v����t
            dr[CT_DtlLedger_StockInputCode] = stockDtlWork.StockInputCode; // �d�����͎҃R�[�h
            dr[CT_DtlLedger_StockInputName] = stockDtlWork.StockInputName; // �d�����͎Җ���
            dr[CT_DtlLedger_StockAgentCode] = stockDtlWork.StockAgentCode; // �d���S���҃R�[�h
            dr[CT_DtlLedger_StockAgentName] = stockDtlWork.StockAgentName; // �d���S���Җ���
            dr[CT_DtlLedger_PayeeCode] = stockDtlWork.PayeeCode; // �x����R�[�h
            dr[CT_DtlLedger_PayeeSnm] = stockDtlWork.PayeeSnm; // �x���旪��
            dr[CT_DtlLedger_SupplierCd] = stockDtlWork.SupplierCd; // �d����R�[�h
            dr[CT_DtlLedger_SupplierNm1] = stockDtlWork.SupplierNm1; // �d���於1
            dr[CT_DtlLedger_SupplierNm2] = stockDtlWork.SupplierNm2; // �d���於2
            dr[CT_DtlLedger_SupplierSnm] = stockDtlWork.SupplierSnm; // �d���旪��
            dr[CT_DtlLedger_StockTotalPrice] = stockDtlWork.StockTotalPrice; // �d�����z���v
            dr[CT_DtlLedger_StockSubttlPrice] = stockDtlWork.StockSubttlPrice; // �d�����z���v
            dr[CT_DtlLedger_StockPriceConsTax] = stockDtlWork.StockPriceConsTax; // �d�����z����Ŋz
            dr[CT_DtlLedger_PartySaleSlipNum] = stockDtlWork.PartySaleSlipNum; // �����`�[�ԍ�
            dr[CT_DtlLedger_SupplierSlipNote1] = stockDtlWork.SupplierSlipNote1; // �d���`�[���l1
            dr[CT_DtlLedger_SupplierSlipNote2] = stockDtlWork.SupplierSlipNote2; // �d���`�[���l2
            dr[CT_DtlLedger_UoeRemark1] = stockDtlWork.UoeRemark1; // �t�n�d���}�[�N�P
            dr[CT_DtlLedger_UoeRemark2] = stockDtlWork.UoeRemark2; // �t�n�d���}�[�N�Q
            dr[CT_DtlLedger_StockRowNo] = stockDtlWork.StockRowNo; // �d���s�ԍ�
            dr[CT_DtlLedger_CommonSeqNo] = stockDtlWork.CommonSeqNo; // ���ʒʔ�
            dr[CT_DtlLedger_StockSlipDtlNum] = stockDtlWork.StockSlipDtlNum; // �d�����גʔ�
            dr[CT_DtlLedger_GoodsNo] = stockDtlWork.GoodsNo; // ���i�ԍ�
            dr[CT_DtlLedger_GoodsName] = stockDtlWork.GoodsName; // ���i����
            dr[CT_DtlLedger_GoodsNameKana] = stockDtlWork.GoodsNameKana; // ���i���̃J�i
            dr[CT_DtlLedger_SalesCustomerCode] = stockDtlWork.SalesCustomerCode; // �̔���R�[�h
            dr[CT_DtlLedger_SalesCustomerSnm] = stockDtlWork.SalesCustomerSnm; // �̔��旪��
            dr[CT_DtlLedger_StockCount] = stockDtlWork.StockCount; // �d����
            dr[CT_DtlLedger_StockUnitPriceFl] = stockDtlWork.StockUnitPriceFl; // �d���P���i�Ŕ��C�����j
            dr[CT_DtlLedger_StockPriceTaxExc] = stockDtlWork.StockPriceTaxExc; // �d�����z�i�Ŕ����j
            dr[CT_DtlLedger_Dtl_StockPriceConsTax] = stockDtlWork.Dtl_StockPriceConsTax; // �d�����z����Ŋz
            dr[CT_DtlLedger_StockRecordCd] = RecordCode.AccPay;

            #endregion
            return dr;
        }
        #endregion

        // <<< danger

        // >>> �X���[
        #region ���t�ҏW����
        /// <summary>
		/// ���t�ҏW����
		/// </summary>
		/// <param name="day">���t</param>
		/// <returns>�ҏW�㕶����</returns>
		private static string GetFormatDay(int day)
		{
			return (day != 0) ? String.Format("{0,2}��", day) : "  ��";
        }

        #endregion
        
        #region �v��N���i����p�j������ϊ�����
        /// <summary>
		/// �v��N���i����p�j������ϊ�����
		/// </summary>
		/// <param name="addUpYearMonth">�v��N��</param>
		/// <returns>�擾������</returns>
		/// <remarks>
		/// <br>Note        : �w��̌v��N���𕶎���ɕϊ����܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetPrintAddUpYearMonth(Int32 addUpYearMonth)
		{
			string result = string.Empty;

			int yy = 0;
			int mm = 0;
			int dd = 0;
			string gen = string.Empty;

			int status = TDateTime.SplitDate("GGYYMMDD", addUpYearMonth * 100 + 1, ref gen, ref yy, ref mm, ref dd);
			if (status == 0)
			{
				result = String.Format("{0,2}�N{1,2}��", yy, mm);
			}

			return result;
        }

        #endregion
        
        #region �v��N�����i����p�j������ϊ�����
        /// <summary>
		/// �v��N�����i����p�j������ϊ�����
		/// </summary>
		/// <param name="addUpDate">�v��N����</param>
		/// <returns>�擾������</returns>
		/// <remarks>
		/// <br>Note        : �w��̌v��N�����𕶎���ɕϊ����܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetPrintAddUpDate(DateTime addUpDate)
		{
			string result = string.Empty;

			int yy = 0;
			int mm = 0;
			int dd = 0;
			string gen = string.Empty;

			int status = TDateTime.SplitDate("YYYYMMDD", addUpDate, ref gen, ref yy, ref mm, ref dd);
			if (status == 0)
			{
				result = String.Format("({0,2}�N{1,2}��{2,2}���v��)", yy, mm, dd);
			}

			return result;
        }

        #endregion
        
        #region �d���`�[�ԍ��擾����
        /// <summary>
		/// �d���`�[�ԍ��擾����
		/// </summary>
        /// <param name="stockSlipWork"></param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note        : �f�[�^�s�ɃZ�b�g����d���`�[�ԍ����擾���܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetSupplierSlipNo(LedgerStockSlipWork stockSlipWork)
		{
			if (stockSlipWork.SupplierSlipNo == 0)
			{
				return string.Empty;
			}
			else
			{
                return string.Format("{0:D9}", stockSlipWork.SupplierSlipNo);
			}
        }
        #endregion
        
        #region �d���`�[�ԍ��擾����
        /// <summary>
        /// �d���`�[�ԍ��擾����
        /// </summary>
        /// <param name="stockDtlWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : �f�[�^�s�ɃZ�b�g����d���`�[�ԍ����擾���܂��B</br>
        /// <br>Programmer  : 20081 �D�c �E�l</br>
        /// <br>Date        : 2007.11.26</br>
        /// </remarks>
        private static string GetSupplierSlipNo(LedgerStockDetailWork stockDtlWork)
        {
            if (stockDtlWork.SupplierSlipNo == 0)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:D9}", stockDtlWork.SupplierSlipNo);
            }
        }
        #endregion
        
        #region �d���`�[�敪���̎擾����
        /// <summary>
		/// �x�����|��� �d���`�[�敪���̎擾����
		/// </summary>
		/// <param name="slipCd">�d���`�[�敪</param>      
		/// <returns>�d���`�[�敪����</returns>
		/// <remarks>
		/// <br>Note        : �d���`�[�敪�̖��̂��擾���܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetSlipKindNm(int slipCd)
		{
            //�d���`�[�敪-20�Őԓ`�敪��0�̃f�[�^���ԕi
			string name = string.Empty;
			
            if(slipCd == 20)
            {
                name = "�ԕi";
            }
			else
			{
				name = "�d��";
			}
			
			return name;
        }

        #endregion
        
        #region �`�[�敪���̎擾����
        /// <summary>
		/// �`�[�敪���̎擾
		/// </summary>
        /// <param name="stockSlipWork">�d���f�[�^</param>
		/// <returns>�`�[�敪����</returns>
		/// <remarks>
		/// <br>Note        : �`�[�敪���̂��擾���܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetSupplierSlipNm(LedgerStockSlipWork stockSlipWork)
		{
			string name = string.Empty;

            switch(stockSlipWork.SupplierSlipCd)
            {
                case (int)SupplierLedgerSlipCdDiv.Stock:
                    {
                        name = "�d��";
                        break;
                    }
                case (int)SupplierLedgerSlipCdDiv.Back:
                    {
                        name = "�ԕi";
                        break;
                    }
            }       
			return name;
        }

        #endregion
        
        #region �x�����|��� ����ŃZ�����e�擾����
        /// <summary>
		/// �x�����|��� ����ŃZ�����e�擾����
		/// </summary>
        /// <param name="stockSlipWork">�x�����|���</param>
		/// <param name="stockLedgerSupplier">�d���挳���d������</param>
		/// <returns>����ŃZ���ɕ\������l</returns>
		/// <remarks>
		/// <br>Note        : ����ŃZ���ɕ\������l���擾���܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static object GetConsTax(LedgerStockSlipWork stockSlipWork, StockLedgerSupplier stockLedgerSupplier)
		{
			// ����œ]�ŕ���
			if (stockLedgerSupplier.SuppCTaxLayCd == 2)	
				return DBNull.Value;
			else
                return stockSlipWork.StockPriceConsTax;	// ����Ŋz
        }

        #endregion
        
        #region �x�����|��� ����ŃZ�����e�擾����
        /// <summary>
        /// �x�����|��� ����ŃZ�����e�擾����
        /// </summary>
        /// <param name="stockDtlWork">�x�����|���</param>
        /// <param name="stockLedgerSupplier">�d���挳���d������</param>
        /// <returns>����ŃZ���ɕ\������l</returns>
        /// <remarks>
        /// <br>Note        : ����ŃZ���ɕ\������l���擾���܂��B</br>
        /// <br>Programmer  : 20081 �D�c �E�l</br>
        /// <br>Date        : 2007.11.26</br>
        /// </remarks>
        private static object GetConsTax(LedgerStockDetailWork stockDtlWork, StockLedgerSupplier stockLedgerSupplier)
        {
            // ����œ]�ŕ���
            if (stockLedgerSupplier.SuppCTaxLayCd == 2)
                return DBNull.Value;
            else
                return stockDtlWork.StockPriceConsTax;	// ����Ŋz
        }

        #endregion
        
        #region ���_���̎擾����
        /// <summary>
		/// ���_���̎擾����
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>���_����</returns>
		/// <remarks>
		/// <br>Note        : ���_���̂��擾���܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetSectionName(string sectionCode)
		{
			string name = string.Empty;
			if (_sectionTable.Contains(sectionCode))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionTable[sectionCode];
				name = secInfoSet.SectionGuideNm;
			}
			return name;
        }

        #endregion

        #endregion

        #region �d���攃�|���z�f�[�^�擾����(�����[�g�ڑ�)
        /// <summary>
		/// �d���攃�|���z�f�[�^�擾����
		/// </summary>
        /// <param name="printDiv">����敪</param>
		/// <param name="param">�p�����[�^</param>
        /// <param name="outMoneyDiv">outMoneyDiv</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : �d���攃�|���z�f�[�^���擾���܂�</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
        /// <br>Update Note : 2014/02/26 �c����</br>
        /// <br>            : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// <br>UpdateNote  : 2015/12/10 �c�v�t</br>
        /// <br>�Ǘ��ԍ�    : 11170204-00</br>
        /// <br>            : Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�</br>
        /// </remarks>
        //private static int GetSupplierAccPayInfo(string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, int mode)
        //private static int GetSupplierAccPayInfo(int printDiv, Broadleaf.Application.Remoting.ParamData.SuplAccInfGetParameter param)// DEL 2014/02/26 �c���� Redmine#42188
        private static int GetSupplierAccPayInfo(int printDiv, Broadleaf.Application.Remoting.ParamData.SuplAccInfGetParameter param, int outMoneyDiv)// ADD 2014/02/26 �c���� Redmine#42188
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            ArrayList suplAccPayList = null;
            Hashtable supplierSlpInf = null;     // ���|(�d��)�f�[�^�pHashTable
            Hashtable supplierDtlInf = null;     // ���|(�d��)���׃f�[�^�pHashTable
            Hashtable paymentSlpTable = null;     // �x���f�[�^�pHashTable
            ArrayList supplierSlpInfAry = null;     // ���|(�d��)�f�[�^�pArrayList
            ArrayList supplierDtlInfAry = null;     // ���|(�d��)���׃f�[�^�pArrayList 
            ArrayList paymentSlpTableAry = null;     // �x���f�[�^�pArrayList
            object suplAccPayWorkList = null;
            object supplierSlpInfWork = null;
            object supplierDtlInfWork = null;
            object supplierPaymentInfWork = null;


            SuplAccInfGetWork suplAccInfGetWork = new SuplAccInfGetWork(); //�d���攃�|���z�}�X�^�p�����[�^

            try
            {
                // �d���攃�|����擾�A�N�Z�X�N���X
                if (_getSuplAccAcs == null)
                {
                    _getSuplAccAcs = new GetSuplAccAcs();
                    _getSuplAccAcs.ThroughException = true;
                }

                //  ��������
                switch (printDiv)
                {
                case 1: // ���׃��[�h
                    {
                        status = _suplAccInfGetDB.SearchDtl(out suplAccPayWorkList, out supplierDtlInfWork, out supplierPaymentInfWork, param);
                        suplAccPayList = suplAccPayWorkList as ArrayList;
                        supplierDtlInfAry = supplierDtlInfWork as ArrayList;
                        paymentSlpTableAry = supplierPaymentInfWork as ArrayList;
                        ArrayInfoToHashTableAcc(out supplierSlpInf, out supplierDtlInf, out paymentSlpTable,
                            //suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry);// DEL 2014/02/26 �c���� Redmine#42188
                        // ----ADD 2014/02/26 �c���� Redmine#42188 ---->>>>>
                            //ref suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv); // DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
                            ref suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv, param.SumSuppEnable); // ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
                        if (suplAccPayList == null || suplAccPayList.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        // ----ADD 2014/02/26 �c���� Redmine#42188 ----<<<<<
                        break;
                    }
                case 2: // �`�[���[�h
                    {
                        status = _suplAccInfGetDB.SearchSlip(out suplAccPayWorkList, out supplierSlpInfWork, out supplierPaymentInfWork, param);
                        suplAccPayList = suplAccPayWorkList as ArrayList;
                        supplierSlpInfAry = supplierSlpInfWork as ArrayList;
                        paymentSlpTableAry = supplierPaymentInfWork as ArrayList;
                        ArrayInfoToHashTableAcc(out supplierSlpInf, out supplierDtlInf, out paymentSlpTable,
                            //suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry);// DEL 2014/02/26 �c���� Redmine#42188
                        // ----ADD 2014/02/26 �c���� Redmine#42188 ---->>>>>
                            //ref suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv); // DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
                            ref suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv, param.SumSuppEnable); // ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
                        if (suplAccPayList == null || suplAccPayList.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        // ----ADD 2014/02/26 �c���� Redmine#42188 ----<<<<<
                        break;
                    }
                default:
                    {
                        throw new CsLedgerException("����敪���s���ł��B", status);
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //�d����x�����f�[�^���P���ȏ゠��
                    if(suplAccPayList.Count > 0)
                    {
                        //�d����敪���擾(List���̂��̂͑S�ē����l�ɂȂ�̂ŁA�O�Ԗڂ��擾)
                        SuplAccInfGetWork workFirst = (SuplAccInfGetWork)suplAccPayList[0];
                    }
                    //�d����x�����f�[�^���X�g��StaticMemory�ݒ�
                    SetStaticFromSuplAccPayWorkList(suplAccPayList);

                    //���Ӑ�ʌv��N�����͈͎擾
                    SetCustomerAddUpDateSpanAndAddUpDate(param.SupplierCd);

                    // �x�����|�E�x���`�[�f�[�^�e�[�u���ݒ�
                    AccPayAndPaymentSlpToDataTable(param.SupplierCd, supplierSlpInf, supplierDtlInf, paymentSlpTable);

                    // �x���`�[���[�N������ێ��p�ɐݒ�
                    foreach (ArrayList paymentSlpList in paymentSlpTable)
                    {
                        //ArrayList paymentSlpList = (ArrayList)de.Value;

                        if (paymentSlpList != null)
                        {
                            foreach (LedgerPaymentSlpWork wk in paymentSlpList)
                            {
                                if (wk != null)
                                {
                                    string key = string.Empty;
                                    key = wk.AddUpSecCode + "_" + wk.PayeeCode.ToString() + "_" + wk.SupplierCd.ToString() + "_" + String.Format("{0:D9}", wk.PaymentSlipNo);
                                    if (!_paymentSlpTable.ContainsKey(key))
                                    {
                                        _paymentSlpTable.Add(key, wk);
                                    }
                                }
                            }
                        }
                    }          
                }
                else
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    //
                }
                else
                {
                    throw new CsLedgerException("�x�����̎擾�Ɏ��s���܂����B", status);
                }
            }
            catch (Exception ex)
            {
                throw new CsLedgerException(ex.Message, status);
            }
            finally
            {
                if (paymentSlpTable != null) paymentSlpTable = null;
                if (supplierSlpInf != null) supplierSlpInf = null;
                if (supplierDtlInf != null) supplierDtlInf = null;
                if (suplAccPayList != null) suplAccPayList = null;
            }
			return status;             
        }
    
        #endregion

        #region �d���攃�|���z�}�X�^�f�[�^���X�g��StaticMemory�ݒ菈��
        /// <summary>
		/// �d���攃�|���z�}�X�^�f�[�^���X�g��StaticMemory�ݒ菈��
		/// </summary>
		/// <param name="suplAccPayWorkList">���|KINGET�f�[�^���X�g</param>
		/// <remarks>
		/// <br>Note        : �d���攃�|���z�}�X�^�p�����[�^�̎d�������StaticMemory�֐ݒ肵�܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static void SetStaticFromSuplAccPayWorkList(ArrayList suplAccPayWorkList)
		{
            foreach (SuplAccInfGetWork suplAccInfGetWork in suplAccPayWorkList)
            {
                ////�e�[�u����key��(���Ӑ� + �v��� + ���_)�ɕύX���A�v������̊Ӄf�[�^�����Ă���
                //string key = suplAccInfGetWork.PayeeCode.ToString() + "_" + TDateTime.DateTimeToLongDate(suplAccInfGetWork.AddUpDate).ToString() + "_" + suplAccInfGetWork.AddUpSecCode;
                //// �d������ݒ�
                //if (!_stockLedgerSupplierInfoTable.Contains(key))
                //{
                //    //�d����x�����z�}�X�^�f�[�^���d���� + �v��� + ���_���̃f�[�^���쐬���܂��B
                //    //�e�����Ƃɏ���œ]�ŕ������قȂ�f�[�^���쐬�\�Ȃ���
                //    _stockLedgerSupplierInfoTable.Add(key, CopySuplAccInfGetWork(suplAccInfGetWork));
                //}
             
                // �f�[�^�e�[�u���ݒ�
                _suplierPayDataTable.Rows.Add(GetDataRowFromSuplierAccPayInfGetWork(suplAccInfGetWork));
            }
        }

        #endregion

        #region �d���攃�|���z���f�[�^�s�ݒ菈��(���|)
		/// <summary>
		/// �d���攃�|���z���f�[�^�s�ݒ菈��(���|)
		/// </summary>
		/// <param name="suplAccInfGetWork">�d���攃�|���z���p�����[�^</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : �d���攃�|���z�����f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static DataRow GetDataRowFromSuplierAccPayInfGetWork(SuplAccInfGetWork suplAccInfGetWork)
		{
			DataRow newRow = _suplierPayDataTable.NewRow();

			GetDataRowFromSuplAccPayWork( ref newRow, suplAccInfGetWork );

			return newRow;
		}
		#endregion

        #region �d���攃�|���z�p�����[�^���d������z���f�[�^�s�ݒ菈��
        /// <summary>
		/// �d���攃�|���z�p�����[�^���d������z���f�[�^�s�ݒ菈��
		/// </summary>
        /// <param name="dr">�f�[�^�s</param>
		/// <param name="work">�d���攃�|���z�p�����[�^</param>
		/// <remarks>
		/// <br>Note        : �d���攃�|���z�p�����[�^���d������z�f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
        private static void GetDataRowFromSuplAccPayWork(ref DataRow dr ,SuplAccInfGetWork work)
        {
            //dr[COL_Spl_EnterpriseCode] = work.EnterpriseCode; // ��ƃR�[�h
            dr[COL_Spl_AddUpSecCode] = work.AddUpSecCode; // �v�㋒�_�R�[�h
            dr[COL_Spl_AddUpSecName] = GetSectionName(work.AddUpSecCode); // �v�㋒�_�R�[�h
            dr[COL_Spl_PayeeCode] = work.PayeeCode; // �x����R�[�h
            //dr[COL_Spl_PayeeName] = work.PayeeName; // �x���於��
            //dr[COL_Spl_PayeeName2] = work.PayeeName2; // �x���於��2
            dr[COL_Spl_PayeeSnm] = work.PayeeSnm; // �x���旪��
            //dr[COL_Spl_ResultsSectCd] = work.ResultsSectCd; // ���ы��_�R�[�h
            //dr[COL_Spl_SupplierCd] = work.SupplierCd; // �d����R�[�h
            //dr[COL_Spl_SupplierNm1] = work.SupplierNm1; // �d���於1
            //dr[COL_Spl_SupplierNm2] = work.SupplierNm2; // �d���於2
            //dr[COL_Spl_SupplierSnm] = work.SupplierSnm; // �d���旪��
            dr[COL_Spl_AddUpDate] = TDateTime.DateTimeToLongDate(work.AddUpDate); // �v��N����
            dr[COL_Spl_AddUpYearMonth] = TDateTime.DateTimeToLongDate(work.AddUpYearMonth); // �v��N��
            dr[COL_Spl_LastTimePayment] = work.LastTimeAccPay; // �O��x�����z
            dr[COL_Spl_StockTtl2TmBfBlPay] = work.StckTtl2TmBfBlAccPay; // �d��2��O�c���i�x���v�j
            dr[COL_Spl_StockTtl3TmBfBlPay] = work.StckTtl3TmBfBlAccPay; // �d��3��O�c���i�x���v�j
            dr[COL_Spl_ThisTimePayNrml] = work.ThisTimePayNrml; // ����x�����z�i�ʏ�x���j
            dr[COL_Spl_ThisTimeTtlBlcPay] = work.ThisTimeTtlBlcAcPay; // ����J�z�c���i�x���v�j
            dr[COL_Spl_OfsThisTimeStock] = work.OfsThisTimeStock; // ���E�㍡��d�����z
            dr[COL_Spl_OfsThisStockTax] = work.OfsThisStockTax; // ���E�㍡��d�������
            dr[COL_Spl_ThisStckPricRgds] = work.ThisStckPricRgds; // ����ԕi���z
            dr[COL_Spl_ThisStcPrcTaxRgds] = work.ThisStcPrcTaxRgds; // ����ԕi�����
            dr[COL_Spl_ThisStckPricDis] = work.ThisStckPricDis; // ����l�����z
            dr[COL_Spl_ThisStcPrcTaxDis] = work.ThisStcPrcTaxDis; // ����l�������
            // 2009.03.02 30413 ���� �ԕi�l���̕����𔽓]������ >>>>>>START
            //dr[COL_Spl_ThisStckPricRgdsDis] = work.ThisStckPricRgds + work.ThisStckPricDis; // ����ԕi���z+����l�����z
            dr[COL_Spl_ThisStckPricRgdsDis] = -(work.ThisStckPricRgds + work.ThisStckPricDis); // ����ԕi�l�����z
            // 2009.03.02 30413 ���� �ԕi�l���̕����𔽓]������ <<<<<<END
            //dr[COL_Spl_TaxAdjust] = work.TaxAdjust; // ����Œ����z
            //dr[COL_Spl_BalanceAdjust] = work.BalanceAdjust; // �c�������z
            dr[COL_Spl_StockTotalPayBalance] = work.StckTtlAccPayBalance; // �d�����v�c���i�x���v�j
            dr[COL_Spl_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(work.MonthAddUpExpDate); // �����X�V���s�N����
            dr[COL_Spl_StartCAddUpUpdDate] = TDateTime.DateTimeToLongDate(work.StMonCAddUpUpdDate); // �����X�V�J�n�N����
            //dr[COL_Spl_LastCAddUpUpdDate] = work.LastCAddUpUpdDate; // �O������X�V�N����
            dr[COL_Spl_StockSlipCount] = work.StockSlipCount; // �d���`�[����
            //dr[COL_Spl_CloseFlg] = work.CloseFlg; // ���ς݃t���O
            if (_imode == (int)Mode.Shr) { dr[COL_Spl_SlitTitle] = "�x���c"; }
            else if (_imode == (int)Mode.Kai) { dr[COL_Spl_SlitTitle] = "���|�c"; }// ����p �x���c�E���|�c

            // 2009.02.24 30413 ���� ����d�����z�̒ǉ� >>>>>>START
            dr[COL_Spl_ThisTimeStockPrice] = work.ThisTimeStockPrice;   // ����d�����z
            // 2009.02.24 30413 ���� ����d�����z�̒ǉ� <<<<<<END

            // --- ADD 2012/11/01 ---------->>>>>
            dr[COL_Spl_SuppCTaxLayCd] = work.SuppCTaxLayCd;         // ����œ]�ŕ���
            // --- ADD 2012/11/01 ----------<<<<<
        }

        #endregion  
      
        #region ��O�N���X
        private class CsLedgerException : ApplicationException
		{
			private int _status;

			#region constructor
			public CsLedgerException(string message, int status)
				: base(message)
			{
				this._status = status;
			}
			#endregion

			#region public property
			public int Status
			{
				get { return this._status; }
			}
			#endregion
		}
		#endregion

		#region InnerClass DateTime �� Int32�ϊ��N���X
		private class DateConverter
		{
			/// <summary>
			/// DateTime�l�擾(Int32 YYYYMMDD���)
			/// </summary>
			/// <param name="dateInt32">YYYYMMDD(Int32)</param>
			/// <returns>DateTime�l</returns>
			public static DateTime GetDateTimeFromYYYYMMDD(Int32 dateInt32)
			{
				if (dateInt32 == 0) return DateTime.MinValue;
				else
				{
					try
					{
						if (dateInt32 == 0) return DateTime.MinValue;
						else if (dateInt32 == 99999999) return DateTime.MaxValue;
						else
						{
							int yyyy = dateInt32 / 10000;
							int mm = (dateInt32 % 10000) / 100;
							int dd = dateInt32 % 100;
							DateTime retDate = new DateTime(yyyy, mm, dd);
							return retDate;
						}
					}
					//����͈͓��t�Ŗ�����΍ŏ��l���Z�b�g
					catch (Exception)
					{
						return DateTime.MinValue;
					}
				}
			}

			/// <summary>
			/// DateTime�l�擾(Int32 YYYYMM���)
			/// </summary>
			/// <param name="dateInt32">YYYYMM(Int32)</param>
			/// <returns>DateTime�l</returns>
			public static DateTime GetDateTimeFromYYYYMM(Int32 dateInt32)
			{
				if (dateInt32 == 0) return DateTime.MinValue;
				else
				{
					try
					{
						if (dateInt32 == 0) return DateTime.MinValue;
						else if (dateInt32 == 999999) return DateTime.MaxValue;
						else
						{
							int yyyy = dateInt32 / 100;
							int mm = dateInt32 % 100;
							int dd = DateTime.DaysInMonth(yyyy, mm);
							DateTime retDate = new DateTime(yyyy, mm, dd);
							return retDate;
						}
					}
					//����͈͓��t�Ŗ�����΍ŏ��l���Z�b�g
					catch (Exception)
					{
						return DateTime.MinValue;
					}
				}
			}
		}
		#endregion

		#region ICompare �̎�����
		/// <summary>
		/// ���_�R�[�h���בւ��pKEY
		/// </summary>
		class SecInfoKey0 : IComparer
		{
			public int Compare(object x, object y)
			{
				string cx = x.ToString();
				string cy = y.ToString();
				return cx.CompareTo(cy);
			}
		}
		#endregion

        #region [�x���cArray��HashTable�ɓ����]
        /// <remarks>
        /// <br>UpdateNote : 2015/10/21 �c�v�t</br>
        /// <br>�Ǘ��ԍ�   : 11170187-00</br>
        /// <br>           : Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br> 
        /// <br>UpdateNote : 2015/12/10 �c�v�t</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00</br>
        /// <br>           : Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�</br>
        /// </remarks>
        private static void ArrayInfoToHashTable(out Hashtable supplierSlpInf, out Hashtable supplierDtlInf, out Hashtable paymentSlpTable,
            //ArrayList suplierPayInfGetWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList)// DEL 2014/02/27 ���N�n��
            //ref ArrayList suplierPayInfGetWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList, int outMoneyDiv)// ADD 2014/02/27 ���N�n�� // DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
            ref ArrayList suplierPayInfGetWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList, int outMoneyDiv, int sumSuppEnable) // ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
        {
            try
            {
                supplierSlpInf = new Hashtable();
                supplierDtlInf = new Hashtable();
                paymentSlpTable = new Hashtable();

                // �d����x�����z��񃊃X�g���������͔�����
                if (suplierPayInfGetWorkList == null) return;

                // ---ADD 2014/02/26 �c���� Redmine#42188--->>>>>
                List<SuplierPayInfGetWork> suplierPayInfGetDelList = new List<SuplierPayInfGetWork>();
                bool stockSlipFlag = false;
                bool stockDtlFlag = false;
                bool paymentSlpFlag = false;
                // ---ADD 2014/02/26 �c���� Redmine#42188---<<<<<

                // �擾�����d����x�����z��񃊃X�g���܂킷
                foreach (SuplierPayInfGetWork suplierPayInfGetWork in suplierPayInfGetWorkList)
                {
                    // ---ADD 2014/02/26 �c���� Redmine#42188--->>>>>
                    stockSlipFlag = false;
                    stockDtlFlag = false;
                    paymentSlpFlag = false;
                    // ---ADD 2014/02/26 �c���� Redmine#42188---<<<<<

                    // �d���f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerStockSlipWorkList != null) && (ledgerStockSlipWorkList.Count > 0))
                    {
                        // �擾�����d���f�[�^���܂킷
                        foreach (ArrayList ledgerStockSlipWorkAry in ledgerStockSlipWorkList)
                        {
                            foreach (LedgerStockSlipWork ledgerStockSlipWork in ledgerStockSlipWorkAry)
                            {
                                // �d���f�[�^�̌v����t���擾
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerStockSlipWork.StockAddUpADate);

                                // �d���f�[�^�̌v����t���d����x�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplierPayInfGetWork.StartCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplierPayInfGetWork.AddUpDate) &&
                                    // --- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
                                    //(ledgerStockSlipWork.StockAddUpSectionCd.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    // --- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
                                    // --- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή� ---------->>>>>
                                    ((ledgerStockSlipWork.StockAddUpSectionCd.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) || (sumSuppEnable == 0)) && // �d�������I�v�V����ON�̎��A�d���f�[�^�̎d���v�㋒�_�R�[�h���d���x�����z���̌v�㋒�_�R�[�h�Ɠ��l�̏ꍇ�A���邢�́A�d�������I�v�V����OFF�̏ꍇ
                                    // --- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή� ----------<<<<<
                                    (ledgerStockSlipWork.PayeeCode == suplierPayInfGetWork.PayeeCode)) // �d���f�[�^�̎x����R�[�h���d���x�����z���̎x����R�[�h�Ɠ��l(�d�������I�v�V����ON�̎��A�����[�g����PayeeCode�Ɏd����(SupplierCd)���i�[����Ă���)
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplierPayInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!supplierSlpInf.Contains(addUpDate)) supplierSlpInf.Add(addUpDate, new ArrayList());

                                    // �d����x�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�Ɏd���f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)supplierSlpInf[addUpDate];
                                    //list.Add(ledgerStockSlipWork.Clone());
                                    LedgerStockSlipWork ledgerStockSlipWorkClone = new LedgerStockSlipWork();
                                    ledgerStockSlipWorkClone.ArrivalGoodsDay = ledgerStockSlipWork.ArrivalGoodsDay;
                                    ledgerStockSlipWorkClone.DebitNLnkSuppSlipNo = ledgerStockSlipWork.DebitNLnkSuppSlipNo;
                                    ledgerStockSlipWorkClone.DebitNoteDiv = ledgerStockSlipWork.DebitNoteDiv;
                                    ledgerStockSlipWorkClone.EnterpriseCode = ledgerStockSlipWork.EnterpriseCode;
                                    ledgerStockSlipWorkClone.InputDay = ledgerStockSlipWork.InputDay;
                                    ledgerStockSlipWorkClone.PartySaleSlipNum = ledgerStockSlipWork.PartySaleSlipNum;
                                    ledgerStockSlipWorkClone.PayeeCode = ledgerStockSlipWork.PayeeCode;
                                    ledgerStockSlipWorkClone.PayeeSnm = ledgerStockSlipWork.PayeeSnm;
                                    ledgerStockSlipWorkClone.SectionCode = ledgerStockSlipWork.SectionCode;
                                    ledgerStockSlipWorkClone.StockAddUpADate = ledgerStockSlipWork.StockAddUpADate;
                                    ledgerStockSlipWorkClone.StockAddUpSectionCd = ledgerStockSlipWork.StockAddUpSectionCd;
                                    ledgerStockSlipWorkClone.StockAgentCode = ledgerStockSlipWork.StockAgentCode;
                                    ledgerStockSlipWorkClone.StockAgentName = ledgerStockSlipWork.StockAgentName;
                                    ledgerStockSlipWorkClone.StockDate = ledgerStockSlipWork.StockDate;
                                    ledgerStockSlipWorkClone.StockGoodsCd = ledgerStockSlipWork.StockGoodsCd;
                                    ledgerStockSlipWorkClone.StockInputCode = ledgerStockSlipWork.StockInputCode;
                                    ledgerStockSlipWorkClone.StockInputName = ledgerStockSlipWork.StockInputName;
                                    ledgerStockSlipWorkClone.StockPriceConsTax = ledgerStockSlipWork.StockPriceConsTax;
                                    ledgerStockSlipWorkClone.StockSectionCd = ledgerStockSlipWork.StockSectionCd;
                                    ledgerStockSlipWorkClone.StockSubttlPrice = ledgerStockSlipWork.StockSubttlPrice;
                                    ledgerStockSlipWorkClone.StockTotalPrice = ledgerStockSlipWork.StockTotalPrice;
                                    ledgerStockSlipWorkClone.SupplierCd = ledgerStockSlipWork.SupplierCd;
                                    ledgerStockSlipWorkClone.SupplierFormal = ledgerStockSlipWork.SupplierFormal;
                                    ledgerStockSlipWorkClone.SupplierNm1 = ledgerStockSlipWork.SupplierNm1;
                                    ledgerStockSlipWorkClone.SupplierNm2 = ledgerStockSlipWork.SupplierNm2;
                                    ledgerStockSlipWorkClone.SupplierSlipCd = ledgerStockSlipWork.SupplierSlipCd;
                                    ledgerStockSlipWorkClone.SupplierSlipNo = ledgerStockSlipWork.SupplierSlipNo;
                                    ledgerStockSlipWorkClone.SupplierSlipNote1 = ledgerStockSlipWork.SupplierSlipNote1;
                                    ledgerStockSlipWorkClone.SupplierSlipNote2 = ledgerStockSlipWork.SupplierSlipNote2;
                                    ledgerStockSlipWorkClone.SupplierSnm = ledgerStockSlipWork.SupplierSnm;
                                    ledgerStockSlipWorkClone.UoeRemark1 = ledgerStockSlipWork.UoeRemark1;
                                    ledgerStockSlipWorkClone.UoeRemark2 = ledgerStockSlipWork.UoeRemark2;
                                    list.Add(ledgerStockSlipWorkClone);
                                    stockSlipFlag = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // �d�����׃f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerStockDtlWorkList != null) && (ledgerStockDtlWorkList.Count > 0))
                    {
                        // �擾�����d�����ד`�[�f�[�^���܂킷
                        foreach (ArrayList ledgerStockDetailWorkAry in ledgerStockDtlWorkList)
                        {
                            foreach (LedgerStockDetailWork ledgerStockDetailWork in ledgerStockDetailWorkAry)
                            {
                                // �d���`�[�f�[�^�̌v����t���擾
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerStockDetailWork.StockAddUpADate);

                                // �d���`�[�f�[�^�̌v����t���d����x�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplierPayInfGetWork.StartCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplierPayInfGetWork.AddUpDate) &&
                                    // --- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
                                    //(ledgerStockDetailWork.StockAddUpSectionCd.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    // --- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
                                    // --- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή� ---------->>>>>
                                    ((ledgerStockDetailWork.StockAddUpSectionCd.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) || (sumSuppEnable == 0)) && // �d�������I�v�V����ON�̎��A�d���f�[�^�̎d���v�㋒�_�R�[�h���d���x�����z���̌v�㋒�_�R�[�h�Ɠ��l�̏ꍇ�A���邢�́A�d�������I�v�V����OFF�̏ꍇ
                                    // --- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή� ----------<<<<<
                                    (ledgerStockDetailWork.PayeeCode == suplierPayInfGetWork.PayeeCode)) // �d���f�[�^�̎x����R�[�h���d���x�����z���̎x����R�[�h�Ɠ��l(�d�������I�v�V����ON�̎��A�����[�g����PayeeCode�Ɏd����(SupplierCd)���i�[����Ă���)
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplierPayInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!supplierDtlInf.Contains(addUpDate)) supplierDtlInf.Add(addUpDate, new ArrayList());

                                    // �d����x�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�Ɏx�����ד`�[�f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)supplierDtlInf[addUpDate];
                                    //list.Add(ledgerStockDetailWork.Clone());
                                    LedgerStockDetailWork ledgerStockDetailWorkClone = new LedgerStockDetailWork();
                                    ledgerStockDetailWorkClone.ArrivalGoodsDay = ledgerStockDetailWork.ArrivalGoodsDay;
                                    ledgerStockDetailWorkClone.CommonSeqNo = ledgerStockDetailWork.CommonSeqNo;
                                    ledgerStockDetailWorkClone.DebitNLnkSuppSlipNo = ledgerStockDetailWork.DebitNLnkSuppSlipNo;
                                    ledgerStockDetailWorkClone.DebitNoteDiv = ledgerStockDetailWork.DebitNoteDiv;
                                    ledgerStockDetailWorkClone.Dtl_StockPriceConsTax = ledgerStockDetailWork.Dtl_StockPriceConsTax;
                                    ledgerStockDetailWorkClone.EnterpriseCode = ledgerStockDetailWork.EnterpriseCode;
                                    ledgerStockDetailWorkClone.GoodsName = ledgerStockDetailWork.GoodsName;
                                    ledgerStockDetailWorkClone.GoodsNameKana = ledgerStockDetailWork.GoodsNameKana;
                                    ledgerStockDetailWorkClone.GoodsNo = ledgerStockDetailWork.GoodsNo;
                                    ledgerStockDetailWorkClone.InputDay = ledgerStockDetailWork.InputDay;
                                    ledgerStockDetailWorkClone.PartySaleSlipNum = ledgerStockDetailWork.PartySaleSlipNum;
                                    ledgerStockDetailWorkClone.PayeeCode = ledgerStockDetailWork.PayeeCode;
                                    ledgerStockDetailWorkClone.PayeeSnm = ledgerStockDetailWork.PayeeSnm;
                                    ledgerStockDetailWorkClone.SalesCustomerCode = ledgerStockDetailWork.SalesCustomerCode;
                                    ledgerStockDetailWorkClone.SalesCustomerSnm = ledgerStockDetailWork.SalesCustomerSnm;
                                    ledgerStockDetailWorkClone.SectionCode = ledgerStockDetailWork.SectionCode;
                                    ledgerStockDetailWorkClone.StockAddUpADate = ledgerStockDetailWork.StockAddUpADate;
                                    ledgerStockDetailWorkClone.StockAddUpSectionCd = ledgerStockDetailWork.StockAddUpSectionCd;
                                    ledgerStockDetailWorkClone.StockAgentCode = ledgerStockDetailWork.StockAgentCode;
                                    ledgerStockDetailWorkClone.StockAgentName = ledgerStockDetailWork.StockAgentName;
                                    ledgerStockDetailWorkClone.StockCount = ledgerStockDetailWork.StockCount;
                                    ledgerStockDetailWorkClone.StockDate = ledgerStockDetailWork.StockDate;
                                    ledgerStockDetailWorkClone.StockGoodsCd = ledgerStockDetailWork.StockGoodsCd;
                                    ledgerStockDetailWorkClone.StockInputCode = ledgerStockDetailWork.StockInputCode;
                                    ledgerStockDetailWorkClone.StockInputName = ledgerStockDetailWork.StockInputName;
                                    ledgerStockDetailWorkClone.StockPriceConsTax = ledgerStockDetailWork.StockPriceConsTax;
                                    ledgerStockDetailWorkClone.StockPriceTaxExc = ledgerStockDetailWork.StockPriceTaxExc;
                                    ledgerStockDetailWorkClone.StockRowNo = ledgerStockDetailWork.StockRowNo;
                                    ledgerStockDetailWorkClone.StockSectionCd = ledgerStockDetailWork.StockSectionCd;
                                    ledgerStockDetailWorkClone.StockSlipDtlNum = ledgerStockDetailWork.StockSlipDtlNum;
                                    ledgerStockDetailWorkClone.StockSubttlPrice = ledgerStockDetailWork.StockSubttlPrice;
                                    ledgerStockDetailWorkClone.StockTotalPrice = ledgerStockDetailWork.StockTotalPrice;
                                    ledgerStockDetailWorkClone.StockUnitPriceFl = ledgerStockDetailWork.StockUnitPriceFl;
                                    ledgerStockDetailWorkClone.SupplierCd = ledgerStockDetailWork.SupplierCd;
                                    ledgerStockDetailWorkClone.SupplierFormal = ledgerStockDetailWork.SupplierFormal;
                                    ledgerStockDetailWorkClone.SupplierNm1 = ledgerStockDetailWork.SupplierNm1;
                                    ledgerStockDetailWorkClone.SupplierNm2 = ledgerStockDetailWork.SupplierNm2;
                                    ledgerStockDetailWorkClone.SupplierSlipCd = ledgerStockDetailWork.SupplierSlipCd;
                                    ledgerStockDetailWorkClone.SupplierSlipNo = ledgerStockDetailWork.SupplierSlipNo;
                                    ledgerStockDetailWorkClone.SupplierSlipNote1 = ledgerStockDetailWork.SupplierSlipNote1;
                                    ledgerStockDetailWorkClone.SupplierSlipNote2 = ledgerStockDetailWork.SupplierSlipNote2;
                                    ledgerStockDetailWorkClone.SupplierSnm = ledgerStockDetailWork.SupplierSnm;
                                    ledgerStockDetailWorkClone.UoeRemark1 = ledgerStockDetailWork.UoeRemark1;
                                    ledgerStockDetailWorkClone.UoeRemark2 = ledgerStockDetailWork.UoeRemark2;
                                    list.Add(ledgerStockDetailWorkClone);;
                                    stockDtlFlag = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // �x���`�[�f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerPaymentSlpWorkList != null) && (ledgerPaymentSlpWorkList.Count > 0))
                    {
                        // �擾�����x���`�[�f�[�^���܂킷
                        foreach (ArrayList ledgerPaymentSlpWorkAry in ledgerPaymentSlpWorkList)
                        {
                            foreach (LedgerPaymentSlpWork ledgerPaymentSlpWork in ledgerPaymentSlpWorkAry)
                            {
                                // �x���`�[�f�[�^�̌v����t���擾
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerPaymentSlpWork.AddUpADate);

                                // �x���`�[�f�[�^�̌v����t���d����x�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplierPayInfGetWork.StartCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplierPayInfGetWork.AddUpDate) &&
                                    (ledgerPaymentSlpWork.AddUpSecCode.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    (ledgerPaymentSlpWork.PayeeCode == suplierPayInfGetWork.PayeeCode))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplierPayInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!paymentSlpTable.Contains(addUpDate)) paymentSlpTable.Add(addUpDate, new ArrayList());

                                    // �d����x�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�Ɏx���`�[�f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)paymentSlpTable[addUpDate];
                                    //list.Add(ledgerPaymentSlpWork.Clone());
                                    LedgerPaymentSlpWork ledgerPaymentSlpWorkClone = new LedgerPaymentSlpWork();
                                    ledgerPaymentSlpWorkClone.AddUpADate = ledgerPaymentSlpWork.AddUpADate;
                                    ledgerPaymentSlpWorkClone.AddUpSecCode = ledgerPaymentSlpWork.AddUpSecCode;
                                    ledgerPaymentSlpWorkClone.DebitNoteDiv = ledgerPaymentSlpWork.DebitNoteDiv;
                                    ledgerPaymentSlpWorkClone.EnterpriseCode = ledgerPaymentSlpWork.EnterpriseCode;
                                    ledgerPaymentSlpWorkClone.MoneyKindCode = ledgerPaymentSlpWork.MoneyKindCode;
                                    ledgerPaymentSlpWorkClone.MoneyKindDiv = ledgerPaymentSlpWork.MoneyKindDiv;
                                    ledgerPaymentSlpWorkClone.MoneyKindName = ledgerPaymentSlpWork.MoneyKindName;
                                    ledgerPaymentSlpWorkClone.Outline = ledgerPaymentSlpWork.Outline;
                                    ledgerPaymentSlpWorkClone.PayeeCode = ledgerPaymentSlpWork.PayeeCode;
                                    ledgerPaymentSlpWorkClone.PayeeName = ledgerPaymentSlpWork.PayeeName;
                                    ledgerPaymentSlpWorkClone.PayeeName2 = ledgerPaymentSlpWork.PayeeName2;
                                    ledgerPaymentSlpWorkClone.PayeeSnm = ledgerPaymentSlpWork.PayeeSnm;
                                    ledgerPaymentSlpWorkClone.Payment = ledgerPaymentSlpWork.Payment;
                                    // --- ADD 2012/11/01 ---------->>>>>
                                    ledgerPaymentSlpWorkClone.FeePayment = ledgerPaymentSlpWork.FeePayment;
                                    ledgerPaymentSlpWorkClone.DiscountPayment = ledgerPaymentSlpWork.DiscountPayment;
                                    // --- ADD 2012/11/01 ----------<<<<<
                                    ledgerPaymentSlpWorkClone.PaymentAgentCode = ledgerPaymentSlpWork.PaymentAgentCode;
                                    ledgerPaymentSlpWorkClone.PaymentAgentName = ledgerPaymentSlpWork.PaymentAgentName;
                                    ledgerPaymentSlpWorkClone.PaymentDate = ledgerPaymentSlpWork.PaymentDate;
                                    ledgerPaymentSlpWorkClone.PaymentInpSectionCd = ledgerPaymentSlpWork.PaymentInpSectionCd;
                                    ledgerPaymentSlpWorkClone.PaymentInputAgentCd = ledgerPaymentSlpWork.PaymentInputAgentCd;
                                    ledgerPaymentSlpWorkClone.PaymentInputAgentNm = ledgerPaymentSlpWork.PaymentInputAgentNm;
                                    ledgerPaymentSlpWorkClone.PaymentRowNo = ledgerPaymentSlpWork.PaymentRowNo;
                                    ledgerPaymentSlpWorkClone.PaymentSlipNo = ledgerPaymentSlpWork.PaymentSlipNo;
                                    ledgerPaymentSlpWorkClone.SupplierCd = ledgerPaymentSlpWork.SupplierCd;
                                    ledgerPaymentSlpWorkClone.SupplierFormal = ledgerPaymentSlpWork.SupplierFormal;
                                    ledgerPaymentSlpWorkClone.SupplierNm1 = ledgerPaymentSlpWork.SupplierNm1;
                                    ledgerPaymentSlpWorkClone.SupplierNm2 = ledgerPaymentSlpWork.SupplierNm2;
                                    ledgerPaymentSlpWorkClone.SupplierSlipNo = ledgerPaymentSlpWork.SupplierSlipNo;
                                    ledgerPaymentSlpWorkClone.SupplierSnm = ledgerPaymentSlpWork.SupplierSnm;
                                    ledgerPaymentSlpWorkClone.UpdateSecCd = ledgerPaymentSlpWork.UpdateSecCd;
                                    ledgerPaymentSlpWorkClone.ValidityTerm = ledgerPaymentSlpWork.ValidityTerm;
                                    list.Add(ledgerPaymentSlpWorkClone);
                                    paymentSlpFlag = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // ---ADD 2014/02/26 �c���� Redmine#42188 ------>>>>>
                    if (stockSlipFlag == false
                       && stockDtlFlag == false
                       && paymentSlpFlag == false
                       && outMoneyDiv == 1
                       && suplierPayInfGetWork.LastTimePayment == 0     //�O��x�����z
                       && suplierPayInfGetWork.StockTtl2TmBfBlPay == 0  //�d��2��O�c���i�x���v�j
                       && suplierPayInfGetWork.StockTtl3TmBfBlPay == 0) //�d��3��O�c���i�x���v�j
                    {

                        suplierPayInfGetDelList.Add(suplierPayInfGetWork);
                    }
                    // ---ADD 2014/02/26 �c���� Redmine#42188 ------<<<<<

                }

                // ---ADD 2014/02/26 �c���� Redmine#42188 ------>>>>>
                if (outMoneyDiv == 0) return;
                // �S�ċ��z0�̏ꍇ�A������Ȃ�
                foreach (SuplierPayInfGetWork wkSuplierPayInfGet in suplierPayInfGetDelList)
                {
                    if (suplierPayInfGetWorkList.Contains(wkSuplierPayInfGet))
                    {
                        suplierPayInfGetWorkList.Remove(wkSuplierPayInfGet);
                    }
                }
                // ---ADD 2014/02/26 �c���� Redmine#42188 ------<<<<<

                return ;
            }
            catch (Exception)
            {
                suplierPayInfGetWorkList = null;
                supplierSlpInf = null;
                supplierDtlInf = null;
                paymentSlpTable = null;

                
                //if (this._throughException) throw (e);

                ////�I�t���C������null���Z�b�g
                //this._iSuplierPayInfGetDB = null;
                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "DCKAK02623A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                //return -1;
            }
        }
        #endregion
        #region [���|�cArray��HashTable�ɓ����]
        /// <remarks>
        /// <br>UpdateNote : 2015/10/21 �c�v�t</br>
        /// <br>�Ǘ��ԍ�   : 11170187-00</br>
        /// <br>           : Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br>
        /// <br>UpdateNote  : 2015/12/10 �c�v�t</br>
        /// <br>�Ǘ��ԍ�    : 11170204-00</br>
        /// <br>            : Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�</br>
        /// </remarks>
        private static void ArrayInfoToHashTableAcc(out Hashtable supplierSlpInf, out Hashtable supplierDtlInf, out Hashtable paymentSlpTable,
            //ArrayList suplAccPayWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList)// DEL 2014/02/26 �c���� Redmine#42188
            //ref ArrayList suplAccPayWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList, int outMoneyDiv)// ADD 2014/02/26 �c���� Redmine#42188 // DEL 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
            ref ArrayList suplAccPayWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList, int outMoneyDiv, int sumSuppEnable) // ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή�
        {
            try
            {
                supplierSlpInf = new Hashtable();
                supplierDtlInf = new Hashtable();
                paymentSlpTable = new Hashtable();

                // �d����x�����z��񃊃X�g���������͔�����
                if (suplAccPayWorkList == null) return;

                // ------ADD 2014/02/26 �c���� Redmine#42188------------------------>>>>>
                List<SuplAccInfGetWork> suplAccInfGetDelList = new List<SuplAccInfGetWork>();

                bool stockSlipFlag = false;
                bool stockDtlFlag = false;
                bool paymentSlpFlag = false;
                // ------ADD 2014/02/26 �c���� Redmine#42188------------------------<<<<<

                // �擾�����d����x�����z��񃊃X�g���܂킷
                foreach (SuplAccInfGetWork suplAccPayWork in suplAccPayWorkList)
                {
                    // --ADD 2014/02/26 �c���� Redmine#42188-->>>>>
                    stockSlipFlag = false;
                    stockDtlFlag = false;
                    paymentSlpFlag = false;
                    // --ADD 2014/02/26 �c���� Redmine#42188--<<<<<


                    // �d���f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerStockSlipWorkList != null) && (ledgerStockSlipWorkList.Count > 0))
                    {
                        // �擾�����d���f�[�^���܂킷
                        foreach (ArrayList ledgerStockSlipWorkAry in ledgerStockSlipWorkList)
                        {
                            foreach (LedgerStockSlipWork ledgerStockSlipWork in ledgerStockSlipWorkAry)
                            {
                                // �d���f�[�^�̌v����t���擾
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerStockSlipWork.StockAddUpADate);

                                // �d���f�[�^�̌v����t���d����x�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplAccPayWork.StMonCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplAccPayWork.AddUpDate) &&
                                    // --- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
                                    //(ledgerStockSlipWork.StockAddUpSectionCd.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) &&
                                    // --- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
                                    // --- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή� ---------->>>>>
                                    ((ledgerStockSlipWork.StockAddUpSectionCd.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) || (sumSuppEnable == 0)) && // �d�������I�v�V����ON�̎��A�d���f�[�^�̎d���v�㋒�_�R�[�h���d���x�����z���̌v�㋒�_�R�[�h�Ɠ��l�̏ꍇ�A���邢�́A�d�������I�v�V����OFF�̏ꍇ
                                    // --- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή� ----------<<<<<
                                    (ledgerStockSlipWork.PayeeCode == suplAccPayWork.PayeeCode)) // �d���f�[�^�̎x����R�[�h���d���x�����z���̎x����R�[�h�Ɠ��l(�d�������I�v�V����ON�̎��A�����[�g����PayeeCode�Ɏd����(SupplierCd)���i�[����Ă���)
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplAccPayWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!supplierSlpInf.Contains(addUpDate)) supplierSlpInf.Add(addUpDate, new ArrayList());

                                    // �d����x�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�Ɏd���f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)supplierSlpInf[addUpDate];
                                    //list.Add(ledgerStockSlipWork.Clone());
                                    LedgerStockSlipWork ledgerStockSlipWorkClone = new LedgerStockSlipWork();
                                    ledgerStockSlipWorkClone.ArrivalGoodsDay = ledgerStockSlipWork.ArrivalGoodsDay;
                                    ledgerStockSlipWorkClone.DebitNLnkSuppSlipNo = ledgerStockSlipWork.DebitNLnkSuppSlipNo;
                                    ledgerStockSlipWorkClone.DebitNoteDiv = ledgerStockSlipWork.DebitNoteDiv;
                                    ledgerStockSlipWorkClone.EnterpriseCode = ledgerStockSlipWork.EnterpriseCode;
                                    ledgerStockSlipWorkClone.InputDay = ledgerStockSlipWork.InputDay;
                                    ledgerStockSlipWorkClone.PartySaleSlipNum = ledgerStockSlipWork.PartySaleSlipNum;
                                    ledgerStockSlipWorkClone.PayeeCode = ledgerStockSlipWork.PayeeCode;
                                    ledgerStockSlipWorkClone.PayeeSnm = ledgerStockSlipWork.PayeeSnm;
                                    ledgerStockSlipWorkClone.SectionCode = ledgerStockSlipWork.SectionCode;
                                    ledgerStockSlipWorkClone.StockAddUpADate = ledgerStockSlipWork.StockAddUpADate;
                                    ledgerStockSlipWorkClone.StockAddUpSectionCd = ledgerStockSlipWork.StockAddUpSectionCd;
                                    ledgerStockSlipWorkClone.StockAgentCode = ledgerStockSlipWork.StockAgentCode;
                                    ledgerStockSlipWorkClone.StockAgentName = ledgerStockSlipWork.StockAgentName;
                                    ledgerStockSlipWorkClone.StockDate = ledgerStockSlipWork.StockDate;
                                    ledgerStockSlipWorkClone.StockGoodsCd = ledgerStockSlipWork.StockGoodsCd;
                                    ledgerStockSlipWorkClone.StockInputCode = ledgerStockSlipWork.StockInputCode;
                                    ledgerStockSlipWorkClone.StockInputName = ledgerStockSlipWork.StockInputName;
                                    ledgerStockSlipWorkClone.StockPriceConsTax = ledgerStockSlipWork.StockPriceConsTax;
                                    ledgerStockSlipWorkClone.StockSectionCd = ledgerStockSlipWork.StockSectionCd;
                                    ledgerStockSlipWorkClone.StockSubttlPrice = ledgerStockSlipWork.StockSubttlPrice;
                                    ledgerStockSlipWorkClone.StockTotalPrice = ledgerStockSlipWork.StockTotalPrice;
                                    ledgerStockSlipWorkClone.SupplierCd = ledgerStockSlipWork.SupplierCd;
                                    ledgerStockSlipWorkClone.SupplierFormal = ledgerStockSlipWork.SupplierFormal;
                                    ledgerStockSlipWorkClone.SupplierNm1 = ledgerStockSlipWork.SupplierNm1;
                                    ledgerStockSlipWorkClone.SupplierNm2 = ledgerStockSlipWork.SupplierNm2;
                                    ledgerStockSlipWorkClone.SupplierSlipCd = ledgerStockSlipWork.SupplierSlipCd;
                                    ledgerStockSlipWorkClone.SupplierSlipNo = ledgerStockSlipWork.SupplierSlipNo;
                                    ledgerStockSlipWorkClone.SupplierSlipNote1 = ledgerStockSlipWork.SupplierSlipNote1;
                                    ledgerStockSlipWorkClone.SupplierSlipNote2 = ledgerStockSlipWork.SupplierSlipNote2;
                                    ledgerStockSlipWorkClone.SupplierSnm = ledgerStockSlipWork.SupplierSnm;
                                    ledgerStockSlipWorkClone.UoeRemark1 = ledgerStockSlipWork.UoeRemark1;
                                    ledgerStockSlipWorkClone.UoeRemark2 = ledgerStockSlipWork.UoeRemark2;
                                    list.Add(ledgerStockSlipWorkClone);
                                    stockSlipFlag = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // �d�����׃f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerStockDtlWorkList != null) && (ledgerStockDtlWorkList.Count > 0))
                    {
                        // �擾�����d�����ד`�[�f�[�^���܂킷
                        foreach (ArrayList ledgerStockDetailWorkAry in ledgerStockDtlWorkList)
                        {
                            foreach (LedgerStockDetailWork ledgerStockDetailWork in ledgerStockDetailWorkAry)
                            {
                                // �d���`�[�f�[�^�̌v����t���擾
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerStockDetailWork.StockAddUpADate);

                                // �d���`�[�f�[�^�̌v����t���d����x�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplAccPayWork.StMonCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplAccPayWork.AddUpDate) &&
                                    // --- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
                                    //(ledgerStockDetailWork.StockAddUpSectionCd.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) &&
                                    // --- DEL 2015/10/21 �c�v�t For Redmine#47545 �d���挳���̖��ו��Ɏd����q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
                                    // --- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή� ---------->>>>>
                                    ((ledgerStockDetailWork.StockAddUpSectionCd.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) || (sumSuppEnable == 0)) && // �d�������I�v�V����ON�̎��A�d���f�[�^�̎d���v�㋒�_�R�[�h���d���x�����z���̌v�㋒�_�R�[�h�Ɠ��l�̏ꍇ�A���邢�́A�d�������I�v�V����OFF�̏ꍇ
                                    // --- ADD 2015/12/10 �c�v�t For Redmine#47545 ��Q�Q �d�������I�v�V�����L�����A���ו��̎d�����z�����ےl�̂Q�{�ň󎚂����̏�Q�Ή� ----------<<<<<
                                    (ledgerStockDetailWork.PayeeCode == suplAccPayWork.PayeeCode)) // �d���f�[�^�̎x����R�[�h���d���x�����z���̎x����R�[�h�Ɠ��l(�d�������I�v�V����ON�̎��A�����[�g����PayeeCode�Ɏd����(SupplierCd)���i�[����Ă���)
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplAccPayWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!supplierDtlInf.Contains(addUpDate)) supplierDtlInf.Add(addUpDate, new ArrayList());

                                    // �d����x�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�Ɏx�����ד`�[�f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)supplierDtlInf[addUpDate];
                                    //list.Add(ledgerStockDetailWork.Clone());
                                    LedgerStockDetailWork ledgerStockDetailWorkClone = new LedgerStockDetailWork();
                                    ledgerStockDetailWorkClone.ArrivalGoodsDay = ledgerStockDetailWork.ArrivalGoodsDay;
                                    ledgerStockDetailWorkClone.CommonSeqNo = ledgerStockDetailWork.CommonSeqNo;
                                    ledgerStockDetailWorkClone.DebitNLnkSuppSlipNo = ledgerStockDetailWork.DebitNLnkSuppSlipNo;
                                    ledgerStockDetailWorkClone.DebitNoteDiv = ledgerStockDetailWork.DebitNoteDiv;
                                    ledgerStockDetailWorkClone.Dtl_StockPriceConsTax = ledgerStockDetailWork.Dtl_StockPriceConsTax;
                                    ledgerStockDetailWorkClone.EnterpriseCode = ledgerStockDetailWork.EnterpriseCode;
                                    ledgerStockDetailWorkClone.GoodsName = ledgerStockDetailWork.GoodsName;
                                    ledgerStockDetailWorkClone.GoodsNameKana = ledgerStockDetailWork.GoodsNameKana;
                                    ledgerStockDetailWorkClone.GoodsNo = ledgerStockDetailWork.GoodsNo;
                                    ledgerStockDetailWorkClone.InputDay = ledgerStockDetailWork.InputDay;
                                    ledgerStockDetailWorkClone.PartySaleSlipNum = ledgerStockDetailWork.PartySaleSlipNum;
                                    ledgerStockDetailWorkClone.PayeeCode = ledgerStockDetailWork.PayeeCode;
                                    ledgerStockDetailWorkClone.PayeeSnm = ledgerStockDetailWork.PayeeSnm;
                                    ledgerStockDetailWorkClone.SalesCustomerCode = ledgerStockDetailWork.SalesCustomerCode;
                                    ledgerStockDetailWorkClone.SalesCustomerSnm = ledgerStockDetailWork.SalesCustomerSnm;
                                    ledgerStockDetailWorkClone.SectionCode = ledgerStockDetailWork.SectionCode;
                                    ledgerStockDetailWorkClone.StockAddUpADate = ledgerStockDetailWork.StockAddUpADate;
                                    ledgerStockDetailWorkClone.StockAddUpSectionCd = ledgerStockDetailWork.StockAddUpSectionCd;
                                    ledgerStockDetailWorkClone.StockAgentCode = ledgerStockDetailWork.StockAgentCode;
                                    ledgerStockDetailWorkClone.StockAgentName = ledgerStockDetailWork.StockAgentName;
                                    ledgerStockDetailWorkClone.StockCount = ledgerStockDetailWork.StockCount;
                                    ledgerStockDetailWorkClone.StockDate = ledgerStockDetailWork.StockDate;
                                    ledgerStockDetailWorkClone.StockGoodsCd = ledgerStockDetailWork.StockGoodsCd;
                                    ledgerStockDetailWorkClone.StockInputCode = ledgerStockDetailWork.StockInputCode;
                                    ledgerStockDetailWorkClone.StockInputName = ledgerStockDetailWork.StockInputName;
                                    ledgerStockDetailWorkClone.StockPriceConsTax = ledgerStockDetailWork.StockPriceConsTax;
                                    ledgerStockDetailWorkClone.StockPriceTaxExc = ledgerStockDetailWork.StockPriceTaxExc;
                                    ledgerStockDetailWorkClone.StockRowNo = ledgerStockDetailWork.StockRowNo;
                                    ledgerStockDetailWorkClone.StockSectionCd = ledgerStockDetailWork.StockSectionCd;
                                    ledgerStockDetailWorkClone.StockSlipDtlNum = ledgerStockDetailWork.StockSlipDtlNum;
                                    ledgerStockDetailWorkClone.StockSubttlPrice = ledgerStockDetailWork.StockSubttlPrice;
                                    ledgerStockDetailWorkClone.StockTotalPrice = ledgerStockDetailWork.StockTotalPrice;
                                    ledgerStockDetailWorkClone.StockUnitPriceFl = ledgerStockDetailWork.StockUnitPriceFl;
                                    ledgerStockDetailWorkClone.SupplierCd = ledgerStockDetailWork.SupplierCd;
                                    ledgerStockDetailWorkClone.SupplierFormal = ledgerStockDetailWork.SupplierFormal;
                                    ledgerStockDetailWorkClone.SupplierNm1 = ledgerStockDetailWork.SupplierNm1;
                                    ledgerStockDetailWorkClone.SupplierNm2 = ledgerStockDetailWork.SupplierNm2;
                                    ledgerStockDetailWorkClone.SupplierSlipCd = ledgerStockDetailWork.SupplierSlipCd;
                                    ledgerStockDetailWorkClone.SupplierSlipNo = ledgerStockDetailWork.SupplierSlipNo;
                                    ledgerStockDetailWorkClone.SupplierSlipNote1 = ledgerStockDetailWork.SupplierSlipNote1;
                                    ledgerStockDetailWorkClone.SupplierSlipNote2 = ledgerStockDetailWork.SupplierSlipNote2;
                                    ledgerStockDetailWorkClone.SupplierSnm = ledgerStockDetailWork.SupplierSnm;
                                    ledgerStockDetailWorkClone.UoeRemark1 = ledgerStockDetailWork.UoeRemark1;
                                    ledgerStockDetailWorkClone.UoeRemark2 = ledgerStockDetailWork.UoeRemark2;
                                    list.Add(ledgerStockDetailWorkClone);
                                    stockDtlFlag = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // �x���`�[�f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerPaymentSlpWorkList != null) && (ledgerPaymentSlpWorkList.Count > 0))
                    {
                        // �擾�����x���`�[�f�[�^���܂킷
                        foreach (ArrayList ledgerPaymentSlpWorkAry in ledgerPaymentSlpWorkList)
                        {
                            foreach (LedgerPaymentSlpWork ledgerPaymentSlpWork in ledgerPaymentSlpWorkAry)
                            {
                                // �x���`�[�f�[�^�̌v����t���擾
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerPaymentSlpWork.AddUpADate);

                                // �x���`�[�f�[�^�̌v����t���d����x�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplAccPayWork.StMonCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplAccPayWork.AddUpDate) &&
                                    (ledgerPaymentSlpWork.AddUpSecCode.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) &&
                                    (ledgerPaymentSlpWork.PayeeCode == suplAccPayWork.PayeeCode))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplAccPayWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!paymentSlpTable.Contains(addUpDate)) paymentSlpTable.Add(addUpDate, new ArrayList());

                                    // �d����x�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�Ɏx���`�[�f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)paymentSlpTable[addUpDate];
                                    //list.Add(ledgerPaymentSlpWork.Clone());
                                    LedgerPaymentSlpWork ledgerPaymentSlpWorkClone = new LedgerPaymentSlpWork();
                                    ledgerPaymentSlpWorkClone.AddUpADate = ledgerPaymentSlpWork.AddUpADate;
                                    ledgerPaymentSlpWorkClone.AddUpSecCode = ledgerPaymentSlpWork.AddUpSecCode;
                                    ledgerPaymentSlpWorkClone.DebitNoteDiv = ledgerPaymentSlpWork.DebitNoteDiv;
                                    ledgerPaymentSlpWorkClone.EnterpriseCode = ledgerPaymentSlpWork.EnterpriseCode;
                                    ledgerPaymentSlpWorkClone.MoneyKindCode = ledgerPaymentSlpWork.MoneyKindCode;
                                    ledgerPaymentSlpWorkClone.MoneyKindDiv = ledgerPaymentSlpWork.MoneyKindDiv;
                                    ledgerPaymentSlpWorkClone.MoneyKindName = ledgerPaymentSlpWork.MoneyKindName;
                                    ledgerPaymentSlpWorkClone.Outline = ledgerPaymentSlpWork.Outline;
                                    ledgerPaymentSlpWorkClone.PayeeCode = ledgerPaymentSlpWork.PayeeCode;
                                    ledgerPaymentSlpWorkClone.PayeeName = ledgerPaymentSlpWork.PayeeName;
                                    ledgerPaymentSlpWorkClone.PayeeName2 = ledgerPaymentSlpWork.PayeeName2;
                                    ledgerPaymentSlpWorkClone.PayeeSnm = ledgerPaymentSlpWork.PayeeSnm;
                                    ledgerPaymentSlpWorkClone.Payment = ledgerPaymentSlpWork.Payment;
                                    // --- ADD 2012/11/01 ---------->>>>>
                                    ledgerPaymentSlpWorkClone.FeePayment = ledgerPaymentSlpWork.FeePayment;
                                    ledgerPaymentSlpWorkClone.DiscountPayment = ledgerPaymentSlpWork.DiscountPayment;
                                    // --- ADD 2012/11/01 ----------<<<<<
                                    ledgerPaymentSlpWorkClone.PaymentAgentCode = ledgerPaymentSlpWork.PaymentAgentCode;
                                    ledgerPaymentSlpWorkClone.PaymentAgentName = ledgerPaymentSlpWork.PaymentAgentName;
                                    ledgerPaymentSlpWorkClone.PaymentDate = ledgerPaymentSlpWork.PaymentDate;
                                    ledgerPaymentSlpWorkClone.PaymentInpSectionCd = ledgerPaymentSlpWork.PaymentInpSectionCd;
                                    ledgerPaymentSlpWorkClone.PaymentInputAgentCd = ledgerPaymentSlpWork.PaymentInputAgentCd;
                                    ledgerPaymentSlpWorkClone.PaymentInputAgentNm = ledgerPaymentSlpWork.PaymentInputAgentNm;
                                    ledgerPaymentSlpWorkClone.PaymentRowNo = ledgerPaymentSlpWork.PaymentRowNo;
                                    ledgerPaymentSlpWorkClone.PaymentSlipNo = ledgerPaymentSlpWork.PaymentSlipNo;
                                    ledgerPaymentSlpWorkClone.SupplierCd = ledgerPaymentSlpWork.SupplierCd;
                                    ledgerPaymentSlpWorkClone.SupplierFormal = ledgerPaymentSlpWork.SupplierFormal;
                                    ledgerPaymentSlpWorkClone.SupplierNm1 = ledgerPaymentSlpWork.SupplierNm1;
                                    ledgerPaymentSlpWorkClone.SupplierNm2 = ledgerPaymentSlpWork.SupplierNm2;
                                    ledgerPaymentSlpWorkClone.SupplierSlipNo = ledgerPaymentSlpWork.SupplierSlipNo;
                                    ledgerPaymentSlpWorkClone.SupplierSnm = ledgerPaymentSlpWork.SupplierSnm;
                                    ledgerPaymentSlpWorkClone.UpdateSecCd = ledgerPaymentSlpWork.UpdateSecCd;
                                    ledgerPaymentSlpWorkClone.ValidityTerm = ledgerPaymentSlpWork.ValidityTerm;
                                    list.Add(ledgerPaymentSlpWorkClone);
                                    paymentSlpFlag = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // ---ADD 2014/02/26 �c���� Redmine#42188 ------>>>>>
                    if (stockSlipFlag == false
                       && stockDtlFlag == false
                       && paymentSlpFlag == false
                       && outMoneyDiv == 1
                       && suplAccPayWork.LastTimeAccPay == 0        //�O�񔃊|���z
                       && suplAccPayWork.StckTtl2TmBfBlAccPay == 0  //�d��2��O�c���i���|�v�j
                       && suplAccPayWork.StckTtl3TmBfBlAccPay == 0) //�d��3��O�c���i���|�v�j
                    {

                        suplAccInfGetDelList.Add(suplAccPayWork);
                    }
                    // ---ADD 2014/02/26 �c���� Redmine#42188 ------<<<<<

                }

                // ---ADD 2014/02/26 �c���� Redmine#42188 ------>>>>>
                if (outMoneyDiv == 0) return;
                // �S�ċ��z0�̏ꍇ�A������Ȃ�
                foreach (SuplAccInfGetWork wkSuplAccInfGet in suplAccInfGetDelList)
                {
                    if (suplAccPayWorkList.Contains(wkSuplAccInfGet))
                    {
                        suplAccPayWorkList.Remove(wkSuplAccInfGet);
                    }
                }
                // ---ADD 2014/02/26 �c���� Redmine#42188 ------<<<<<

                return;
            }
            catch (Exception)
            {
                suplAccPayWorkList = null;
                supplierSlpInf = null;
                supplierDtlInf = null;
                paymentSlpTable = null;

                //if (this._throughException) throw (e);

                ////�I�t���C������null���Z�b�g
                //this._iSuplierPayInfGetDB = null;
                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "DCKAK02623A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                //return -1;
            }
        }
        #endregion
    }
   
}

