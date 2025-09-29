using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Ӑ��ʃA�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ��ʂ𑀍삷��ׂ̃N���X�ł��B</br>
    /// <br>Programmer : 22018 ��ؐ��b</br>
    /// <br>Date       : 2208.04.30</br>
    /// <br>UpdateNote : 2008/12/16 30462 �s�V�m���@�o�O�C��</br>
    /// <br>UpdateNote : 2009/03/06 30414 �E�K�j�@��QID:12199�Ή�[�ŗ��ݒ�}�X�^�̓��A���\���ɕύX]</br>
    /// <br>UpdateNote : 2009/03/10 30414 �E�K�j�@��QID:12253�Ή�[�����\���͐ŗ��ݒ�}�X�^���擾����悤�ύX]</br>
    /// <br>UpdateNote : 2009/12/02 30517 �Ė� �x��@MANTIS:14272�@�\���Ώۍ��ڂ�FAX�ԍ��ǉ�</br>
    /// <br>UpdateNote : 2009/01/04 30531 ��� �r���@MANTIS:14873  �������^�C�v���̏o�͋敪�ǉ�</br>
    /// </remarks>
	public class CustomerInputAcs
	{
		// ===================================================================================== //
		// �O���ɒ񋟂���萔�Q
		// ===================================================================================== //
		# region public static readonly
        /// <summary>���l�P</summary>
		public static readonly int NoteGd_DivCd_CUSTOMERNOTE1  = 1;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�P
        /// <summary>���l�Q</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE2 = 2;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�Q
        /// <summary>���l�R</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE3 = 3;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�R
        /// <summary>���l�S</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE4 = 4;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�S
        /// <summary>���l�T</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE5 = 5;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�T
        /// <summary>���l�U</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE6 = 6;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�U
        /// <summary>���l�V</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE7 = 7;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�V
        /// <summary>���l�W</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE8 = 8;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�W
        /// <summary>���l�X</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE9 = 9;			// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�X
        /// <summary>���l�P�O</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE10 = 10;		// ���l�K�C�h�}�X�^�敪�^���Ӑ���l�P�O
		# endregion

		// ===================================================================================== //
		// �X�^�e�B�b�N�ȕϐ��Q
		// ===================================================================================== //
		#region Static Fields
		private static ArrayList _userGdHdListStc;
        // --- CHG 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        //private static List<UserGdBd> _userGdBdListStc;
        /// <summary>���[�U�[�K�C�h(�{�f�B)���X�g</summary>
        public static List<UserGdBd> _userGdBdListStc;
        // --- CHG 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
        private static AllDefSet _allDefSetStc;			// �S�̏����l�ݒ�}�X�^
		private static ArrayList _noteGuidHdListStc;
        private static ArrayList _salesProcMoneyStc;    // ������z�����敪
        private static Dictionary<string,AllDefSet> stc_allDefSetDic;     // �S�̏����l�ݒ�}�X�^Dictionary
        private static TaxRateSet stc_taxRateSet;   // �ŗ��ݒ�}�X�^
        private static Dictionary<string, string> _sectionNameDic = null;              // ���_���̃f�B�N�V���i��
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members
		private string _key = string.Empty;												// ���j�[�N�L�[������
		private string _enterpriseCode = string.Empty;
		private string _loginSectionCode = string.Empty;									// ���O�C�����_�R�[�h
		private AddressGuide _addressGuide = null;								// �Z���K�C�h
		private UserGuideAcs _userGuideAcs = null;								// ���[�U�[�K�C�h�}�X�^�A�N�Z�X�N���X
		private EmployeeAcs _employeeAcs = null;								// �]�ƈ��}�X�^�A�N�Z�X�N���X
		private CustomerInfoAcs _customerInfoAcs = null;						// ���Ӑ���A�N�Z�X�N���X
		private UserGuideGuide _userGuideGuide = null;							// ���[�U�[�K�C�h�K�C�h
        private SalesProcMoneyAcs _salesProcMoneyAcs = null;                    // ������z�����敪�A�N�Z�X�N���X
        // --- CHG 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        //private List<SalesProcMoneyKey> _salesProcMoneyCdList;                  // ������z�����N���X�L�[���X�g
        /// <summary>������z�����L�[���X�g</summary>
        public List<SalesProcMoneyKey> _salesProcMoneyCdList;                  // ������z�����N���X�L�[���X�g
        // --- CHG 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
        private SecInfoSetAcs _secInfoSetAcs = null;                            // ���_�A�N�Z�X�N���X 
        private TaxRateSetAcs _taxRateSetAcs = null;                            // �ŗ��ݒ�}�X�^
        private AllDefSetAcs _allDefSetAcs = null;                              // �S�̏����l�ݒ�}�X�^
        private WarehouseAcs _warehouseAcs = null;                              // �q�Ƀ}�X�^�A�N�Z�X�N���X
		# endregion

        // ===================================================================================== //
        // Structure
        // ===================================================================================== //
        # region Struct
        /// <summary>
        /// ������z�[�������L�[�\����
        /// </summary>
        // --- CHG 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
        //private struct SalesProcMoneyKey
        public struct SalesProcMoneyKey
        // --- CHG 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
        {
            //fractionProcCode

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
            public SalesProcMoneyKey( int fracProcMoneyDiv, int fractionProcCode )
            {
                this._fracProcMoneyDiv = fracProcMoneyDiv;
                this._fractionProcCode = fractionProcCode;
            }
        }
        # endregion

        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// ���Ӑ���͗p�A�N�Z�X�N���X �f�t�H���g�R���X�g���N�^
		/// </summary>
        public CustomerInputAcs() : this(string.Empty)
        {
        }

		/// <summary>
		/// ���Ӑ���͗p�A�N�Z�X�N���X �f�t�H���g�R���X�g���N�^
		/// </summary>
		/// <param name="key">���j�[�N�L�[������</param>
		public CustomerInputAcs(string key)
		{
			this._key = key;

			// �ϐ�������
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            if (string.IsNullOrEmpty(key)) {
                this._customerInfoAcs = new CustomerInfoAcs();
            }
            else {
                this._customerInfoAcs = new CustomerInfoAcs(this._key);
            }
            this._userGuideAcs = new UserGuideAcs();
			this._addressGuide = new AddressGuide();
			this._employeeAcs = new EmployeeAcs();
			this._userGuideGuide = new UserGuideGuide();
            this._salesProcMoneyAcs = new SalesProcMoneyAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._allDefSetAcs = new AllDefSetAcs();
            this._warehouseAcs = new WarehouseAcs();
		}
		# endregion

		// ===================================================================================== //
		// Static�̈摀�상�\�b�h
		// ===================================================================================== //
		# region StaticMemory Control
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public string GetSectionName( string sectionCode )
        {
            if ( _sectionNameDic == null )
            {
                _sectionNameDic = new Dictionary<string, string>();
                SecInfoAcs acs = new SecInfoAcs();
                SecInfoSet[] sections = acs.SecInfoSetList;

                foreach ( SecInfoSet section in sections )
                {
                    if ( !_sectionNameDic.ContainsKey( section.SectionCode ) )
                    {
                        _sectionNameDic.Add( section.SectionCode, section.SectionGuideNm );
                    }
                }
            }

            if ( _sectionNameDic.ContainsKey( sectionCode ) )
            {
                return _sectionNameDic[sectionCode];
            }
            else
            {
                return string.Empty;
            }
        }
		/// <summary>
		/// Static���̕ύX����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerInfo">�ύX����f�[�^�i�߂�l�Ƃ��ĕύX��̃f�[�^�j</param>
		/// <returns>STATUS[0:�X�V����,1:�X�V�����I��]</returns>
		/// <remarks>
		/// <br>Note		: Static�ȃG���A�Ɏ��q����ݒ肵�܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int WriteStaticMemoryData(object sender, CustomerInfo customerInfo)
		{
			return this._customerInfoAcs.WriteStaticMemoryData(sender, customerInfo);
		}

		/// <summary>
		/// Static���̎擾����
		/// </summary>
		/// <param name="customerInfo">�擾����f�[�^</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS[0:�擾����,1:�擾�����I��]</returns>
		public int ReadStaticMemoryData(out CustomerInfo customerInfo, string enterpriseCode, int customerCode)
		{
			return this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, enterpriseCode, customerCode);
		}

		/// <summary>
		/// StaticMemory����������
		/// </summary>
		/// <param name="mode">���[�h[0:����,1:MainStaticMemory,2:UndoStaticMemory]</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="ownSectionCode">�����_�R�[�h</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <returns>0:����</returns>
		public int InitialStaticMemory(int mode, string enterpriseCode, int customerCode, string ownSectionCode, out CustomerInfo customerInfo)
		{
			CustomerInfo customerInfoBuff = new CustomerInfo();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
            //// �S�̏����l�ݒ�}�X�^�擾
            //this.ReadAllDefSet(enterpriseCode, this._loginSectionCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            // �S�̏����l�ݒ�}�X�^�擾
            _allDefSetStc = GetAllDefSet( this._enterpriseCode, this._loginSectionCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD


			// ���_

			// �����l�Z�b�g
			customerInfoBuff.EnterpriseCode = enterpriseCode;

			// �����l�Z�b�g
			customerInfoBuff.TotalDay = _allDefSetStc.DefDspCustTtlDay;				// ���Ӑ����
			customerInfoBuff.CollectMoneyDay = _allDefSetStc.DefDspCustClctMnyDay;	// �W����
			customerInfoBuff.CollectMoneyCode = _allDefSetStc.DefDspClctMnyMonthCd;	// �W�����敪�R�[�h
			customerInfoBuff.CorporateDivCode = _allDefSetStc.IniDspPrslOrCorpCd;	// �l�E�@�l�敪
			customerInfoBuff.DmOutCode = _allDefSetStc.InitDspDmDiv;				// �����\��DM�敪
			customerInfoBuff.BillOutputCode = _allDefSetStc.DefDspBillPrtDivCd;		// �����\���������o�͋敪
			customerInfoBuff.HonorificTitle = "�l";									// �h��
			customerInfoBuff.MngSectionCode = ownSectionCode;						// �Ǘ����_�R�[�h
            customerInfoBuff.ClaimSectionCode = ownSectionCode;                     // �������_�R�[�h
			customerInfoBuff.InpSectionCode = ownSectionCode;						// ���͋��_�R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
            //customerInfoBuff.TotalAmountDispWayCd = 1;								// ���z�\�����@�敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            customerInfoBuff.TotalAmountDispWayCd = _allDefSetStc.TotalAmountDispWayCd; // ���z�\�����@�敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
            customerInfoBuff.AccRecDivCd = 1; // ���|�敪 (1:���|)
            //customerInfoBuff.CustomerAgentCd = LoginInfoAcquisition.Employee.EmployeeCode;  // ���Ӑ�S���ҁ@�@���@���O�C���S���҂��Z�b�g // 2010/12/06
            //customerInfoBuff.CustomerAgentNm = LoginInfoAcquisition.Employee.Name;          // ���Ӑ�S���Җ��@���@���O�C���S���҂��Z�b�g // 2010/12/06
            customerInfoBuff.CustomerAgentCd = string.Empty;  // ADD 2010/12/06
            customerInfoBuff.CustomerAgentNm = string.Empty;  // ADD 2010/12/06

            // --- ADD 2009/03/10 ��QID:12253�Ή�------------------------------------------------------>>>>>
            // ����œ]�ŕ���
            customerInfoBuff.ConsTaxLayMethod = GetConsTaxLayMethod(this._enterpriseCode, 0);
            // --- ADD 2009/03/10 ��QID:12253�Ή�------------------------------------------------------<<<<<

            // ���_���̃Z�b�g
            customerInfoBuff.MngSectionName = GetSectionName( customerInfoBuff.MngSectionCode );
            customerInfoBuff.ClaimSectionName = GetSectionName( customerInfoBuff.ClaimSectionCode );
            customerInfoBuff.InpSectionName = GetSectionName( customerInfoBuff.InpSectionCode );

			// TEL�\�����̐ݒ菈��
			this._customerInfoAcs.SetDspName(ref customerInfoBuff);

            // ADD 2008/12/16 �s��Ή�[9270] ---------->>>>>
            //�D��q�ɂ̏����l�ݒ�
            customerInfoBuff.CustWarehouseCd = "";
            // ADD 2008/12/16 �s��Ή�[9270] ----------<<<<<

            // StaticMemory���������ۑ�����
			this._customerInfoAcs.WriteInitStaticMemory(mode, customerInfoBuff);
			
			customerInfo = customerInfoBuff.Clone();
			return 0;
		}
		# endregion

		// ===================================================================================== //
		// ���ʏ���
		// ===================================================================================== //
		# region Common
		/// <summary>
		/// �Z�����߂�l�N���X�����Ӑ���N���X�i�[����
		/// </summary>
		/// <param name="adResult">�Z�����߂�l�N���X</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		public void SetCustomerInfoOwnerAddressFromAddressGuideResult(AddressGuideResult adResult, ref CustomerInfo customerInfo)
		{
			customerInfo.PostNo = adResult.PostNo.TrimEnd();

			// �Z�����̕�������
			string address1;
			string address2;
			this.DivisionAddressName(30, adResult.AddressName, out address1, out address2);
			customerInfo.Address1 = address1.TrimEnd();
			customerInfo.Address3 = address2.TrimEnd();
		}

		/// <summary>
		/// �]�ƈ��N���X�����Ӑ���N���X�̓��Ӑ�S�����i�[����
		/// </summary>
		/// <param name="employee">�]�ƈ��N���X</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		public void SetCustomerInfoAgentFromEmployee(Employee employee, ref CustomerInfo customerInfo)
		{
			customerInfo.CustomerAgentCd = employee.EmployeeCode;
			customerInfo.CustomerAgentNm = employee.Name;
		}
        /// <summary>
        /// �]�ƈ��N���X�����Ӑ���N���X�̋����Ӑ�S�����i�[����
        /// </summary>
        /// <param name="employee">�]�ƈ��N���X</param>
        /// <param name="customerInfo">���Ӑ���N���X</param>
        public void SetOldCustomerInfoAgentFromEmployee ( Employee employee, ref CustomerInfo customerInfo )
        {
            customerInfo.OldCustomerAgentCd = employee.EmployeeCode;
            customerInfo.OldCustomerAgentNm = employee.Name;
        }

		/// <summary>
		/// �]�ƈ��N���X�����Ӑ���N���X�̏W���S�����i�[����
		/// </summary>
		/// <param name="employee">�]�ƈ��N���X</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		public void SetBillCollecterFromEmployee(Employee employee, ref CustomerInfo customerInfo)
		{
			customerInfo.BillCollecterCd = employee.EmployeeCode;
			customerInfo.BillCollecterNm = employee.Name;
		}

		/// <summary>
		/// ���Ӑ���N���X�����Ӑ���N���X�i��������j�i�[����
		/// </summary>
		/// <param name="customerSource">�i�[�����Ӑ���N���X</param>
		/// <param name="customerInfo">�i�[�擾�Ӑ���N���X</param>
		public void SetCustomerInfoClaimInfoFromCustomerInfo(CustomerInfo customerSource, ref CustomerInfo customerInfo)
		{
			customerInfo.ClaimCode = customerSource.CustomerCode;
			customerInfo.ClaimName = customerSource.Name;
			customerInfo.ClaimName2 = customerSource.Name2;
            customerInfo.ClaimSnm = customerSource.CustomerSnm;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            customerInfo.TotalDay = customerSource.TotalDay;
            customerInfo.CollectMoneyCode = customerSource.CollectMoneyCode;
            customerInfo.CollectMoneyDay = customerSource.CollectMoneyDay;
            customerInfo.CollectCond = customerSource.CollectCond;
            customerInfo.CollectSight = customerSource.CollectSight;
            customerInfo.NTimeCalcStDate = customerSource.NTimeCalcStDate;
            customerInfo.TotalAmntDspWayRef = customerSource.TotalAmntDspWayRef;
            customerInfo.TotalAmountDispWayCd = customerSource.TotalAmountDispWayCd;
            customerInfo.CustCTaXLayRefCd = customerSource.CustCTaXLayRefCd;
            customerInfo.ConsTaxLayMethod = customerSource.ConsTaxLayMethod;
            customerInfo.DepoDelCode = customerSource.DepoDelCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
            customerInfo.SalesUnPrcFrcProcCd = customerSource.SalesUnPrcFrcProcCd;
            customerInfo.SalesMoneyFrcProcCd = customerSource.SalesMoneyFrcProcCd;
            customerInfo.SalesCnsTaxFrcProcCd = customerSource.SalesCnsTaxFrcProcCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
		}

		/// <summary>
		/// ���Ӑ挟�����ʃN���X�����Ӑ���N���X�i��������j�i�[����
		/// </summary>
		/// <param name="customerSource">�i�[�����Ӑ挟�����ʃN���X</param>
		/// <param name="customerInfo">�i�[�擾�Ӑ���N���X</param>
		public void SetCustomerInfoClaimInfoFromCustomerInfo(CustomerSearchRet customerSource, ref CustomerInfo customerInfo)
		{
            customerInfo.ClaimCode = customerSource.CustomerCode;
            customerInfo.ClaimName = customerSource.Name;
            customerInfo.ClaimName2 = customerSource.Name2;
            customerInfo.ClaimSnm = customerSource.Snm;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            CustomerInfo custClaim;
            int status = this.GetCustomerInfoFromCustomerCode( ConstantManagement.LogicalMode.GetData0, customerSource.CustomerCode, out custClaim );
            if ( status == 0 )
            {
                customerInfo.TotalDay = custClaim.TotalDay;
                customerInfo.CollectMoneyCode = custClaim.CollectMoneyCode;
                customerInfo.CollectMoneyDay = custClaim.CollectMoneyDay;
                customerInfo.CollectCond = custClaim.CollectCond;
                customerInfo.CollectSight = custClaim.CollectSight;
                customerInfo.NTimeCalcStDate = custClaim.NTimeCalcStDate;
                customerInfo.TotalAmntDspWayRef = custClaim.TotalAmntDspWayRef;
                customerInfo.TotalAmountDispWayCd = custClaim.TotalAmountDispWayCd;
                customerInfo.CustCTaXLayRefCd = custClaim.CustCTaXLayRefCd;
                customerInfo.ConsTaxLayMethod = custClaim.ConsTaxLayMethod;
                customerInfo.DepoDelCode = custClaim.DepoDelCode;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
                customerInfo.SalesUnPrcFrcProcCd = custClaim.SalesUnPrcFrcProcCd;
                customerInfo.SalesMoneyFrcProcCd = custClaim.SalesMoneyFrcProcCd;
                customerInfo.SalesCnsTaxFrcProcCd = custClaim.SalesCnsTaxFrcProcCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/// <summary>
		/// ���Ӑ���N���X�i���Ӑ���j�����Ӑ���N���X�i��������j�i�[����
		/// </summary>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		public void CopyCustomerInfoClaimInfoFromCustomerInfo(ref CustomerInfo customerInfo)
		{
            customerInfo.ClaimCode = customerInfo.CustomerCode;
            customerInfo.ClaimName = customerInfo.Name;
            customerInfo.ClaimName2 = customerInfo.Name2;
            customerInfo.ClaimSnm = customerInfo.CustomerSnm;
		}

		/// <summary>
		/// ���l�K�C�h�{�f�B�N���X�����Ӑ���N���X�i�[����
		/// </summary>
		/// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
		/// <param name="noteGuidBd">���l�K�C�h�{�f�B�N���X</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		public void SetCustomerInfoFromNoteGuidBd(int noteGuideDivCode, NoteGuidBd noteGuidBd, ref CustomerInfo customerInfo)
		{
			// �����`�F�b�N
			if (noteGuidBd.NoteGuideName.Length > 20)
			{
				noteGuidBd.NoteGuideName = noteGuidBd.NoteGuideName.Remove(20, noteGuidBd.NoteGuideName.Length - 20);
			}

            // ���l�Z�b�g
            switch ( noteGuideDivCode )
            {
                case 1:
                    customerInfo.Note1 = noteGuidBd.NoteGuideName;
                    break;
                case 2:
                    customerInfo.Note2 = noteGuidBd.NoteGuideName;
                    break;
                case 3:
                    customerInfo.Note3 = noteGuidBd.NoteGuideName;
                    break;
                case 4:
                    customerInfo.Note4 = noteGuidBd.NoteGuideName;
                    break;
                case 5:
                    customerInfo.Note5 = noteGuidBd.NoteGuideName;
                    break;
                case 6:
                    customerInfo.Note6 = noteGuidBd.NoteGuideName;
                    break;
                case 7:
                    customerInfo.Note7 = noteGuidBd.NoteGuideName;
                    break;
                case 8:
                    customerInfo.Note8 = noteGuidBd.NoteGuideName;
                    break;
                case 9:
                    customerInfo.Note9 = noteGuidBd.NoteGuideName;
                    break;
                case 10:
                    customerInfo.Note10 = noteGuidBd.NoteGuideName;
                    break;
                default:
                    break;
            }
		}

		/// <summary>
		/// �Z�����̕�������
		/// </summary>
		/// <param name="length">����������</param>
		/// <param name="addressName">�Z������</param>
		/// <param name="addressName1">�Z�����̕������ʂP</param>
		/// <param name="addressName2">�Z�����̕������ʂQ</param>
		private void DivisionAddressName(int length, string addressName, out string addressName1, out string addressName2)
		{
			addressName1 = addressName;
			addressName2 = string.Empty;

			if (addressName.Length > length)
			{
				addressName1 = addressName.Substring(0, length);
				addressName2 = addressName.Substring(length, addressName.Length - length);
			}
			else
			{
				return;
			}
		}

		/// <summary>
		/// �����d�b�ԍ���������
		/// </summary>
        /// <param name="customerInfo">���Ӑ���N���X</param>
		/// <returns>�����d�b�ԍ�</returns>
		public string CreateSearchTelNo(CustomerInfo customerInfo)
		{
			string searchTelNo = customerInfo.SearchTelNo;

			switch (customerInfo.MainContactCode)
			{
				case 0:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.HomeTelNo);
					break;
				}
				case 1:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.OfficeTelNo);
					break;
				}
				case 2:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.PortableTelNo);
					break;
				}
				case 3:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.HomeFaxNo);
					break;
				}
				case 4:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.OfficeFaxNo);
					break;
				}
				case 5:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.OthersTelNo);
					break;
				}
			}

			return searchTelNo;
		}

		/// <summary>
		/// �����d�b�ԍ���������
		/// </summary>
        /// <param name="customerInfo">���Ӑ���N���X</param>
		/// <param name="targetContactCode">�ΏۘA����敪</param>
		/// <returns>�����d�b�ԍ�</returns>
		public string CreateSearchTelNo(CustomerInfo customerInfo, int targetContactCode)
		{
			if (customerInfo.MainContactCode != targetContactCode) return customerInfo.SearchTelNo;

			return CreateSearchTelNo(customerInfo);
		}

		/// <summary>
		/// �����d�b�ԍ���������
		/// </summary>
        /// <param name="telNo">���Ӑ���N���X</param>
		/// <returns>�����d�b�ԍ�</returns>
		public string CreateSearchTelNo(string telNo)
		{
			if ((telNo == null) || (telNo == "")) return string.Empty;

			StringBuilder telNoBuff = new StringBuilder();

			for (int i = telNo.Length; i > 0; i--)
			{
				string no = telNo.Substring(i - 1, 1);

				// ���l�ȊO�̏ꍇ�͏����I��
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
				if (!regex.IsMatch(no))
				{
					break;
				}

				telNoBuff.Insert(0, no);

				// 4�����ɂȂ������_�ŏ����I��
				if (telNoBuff.Length == 4)
				{
					break;
				}
			}

			return telNoBuff.ToString();
		}
		# endregion

        // ===================================================================================== //
		// �c�a�f�[�^�擾����
		// ===================================================================================== //
		# region DataBase Control
		/// <summary>
		/// ���[�U�[�K�C�h�}�X�^�w�b�_�����X�g�擾����
		/// </summary>
		/// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
		public int GetUserGdHdListToStatic()
		{
			if (_userGdHdListStc == null)
			{
				_userGdHdListStc = new ArrayList();
			}

			ArrayList userGdHdList = null;

			// ���[�U�[�K�C�h�i�w�b�_�j���S���������i�_���폜�����j
			int status = this._userGuideAcs.SearchHeader(out userGdHdList);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_userGdHdListStc = (ArrayList)userGdHdList.Clone();
			}

			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�w�b�_���̎擾����
		/// </summary>
		/// <param name="guideDivCode">���[�U�[�K�C�h�敪</param>
		/// <returns>���[�U�[�K�C�h�w�b�_����</returns>
		public string GetUserGdHd(int guideDivCode)
		{
			string userGdName = string.Empty;
			if (_userGdHdListStc == null)
			{
				return userGdName;
			}

			foreach (UserGdHd ugh in _userGdHdListStc)
			{
				if (ugh.UserGuideDivCd == guideDivCode)
				{
					userGdName = ugh.UserGuideDivNm;
					break;
				}
			}

			return userGdName;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�}�X�^�{�f�B�����X�g�擾����
		/// </summary>
		/// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
		public int GetUserGdBdListToStatic()
		{
			if (_userGdBdListStc == null)
			{
				_userGdBdListStc = new List<UserGdBd>();
			}
			else
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			ArrayList userGdBdList = null;

			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				// ���[�U�[�K�C�h�i�w�b�_�j���S���������i�_���폜�����j
				status = this._userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.MergeBodyData);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					_userGdBdListStc.AddRange((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));
				}
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.ToString(),
					"���[�U�[�K�C�h�i�w�b�_�j���̎擾�Ɏ��s���܂����B" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

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
		public int GetDivCodeBodyList(int guideDivCode, out ArrayList retList)
		{
			if (_userGdBdListStc == null)
			{
				// ���[�U�[�K�C�h�}�X�^�{�f�B�����X�g�擾����
				this.GetUserGdBdListToStatic();
			}

			retList = new ArrayList();

			foreach (UserGdBd ugb in _userGdBdListStc)
			{
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------>>>>>
                //if (ugb.UserGuideDivCd == guideDivCode)
                if ((ugb.UserGuideDivCd == guideDivCode) && (ugb.LogicalDeleteCode == 0))
                // --- ADD 2009/03/24 �c�Č�No.14�Ή�------------------------------------------------------<<<<<
                {
					ComboEditorItemCustomer comboEditorItem = new ComboEditorItemCustomer(ugb.GuideCode, ugb.GuideName);
					retList.Add(comboEditorItem);
				}
			}
			
			if (retList.Count > 0)
			{
				return 0;
			}
			else
			{
				return -1;
			}
		}

        /// <summary>
        /// ����[���������X�g�擾�����iSTATIC�ޔ��j
        /// </summary>
        /// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
        public int GetSalesProcMoneyListToStatic ()
        {
            if ( _salesProcMoneyStc == null ) {
                _salesProcMoneyStc = new ArrayList();
            }
            else {
                return ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            ArrayList saleProcMoneyList = null;

            int status = ( int ) ConstantManagement.DB_Status.ctDB_EOF;

            try {

                // ������z����
                status = this._salesProcMoneyAcs.SearchAll( out saleProcMoneyList, this._enterpriseCode );

                if ( status == ( int ) ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    _salesProcMoneyStc.AddRange(saleProcMoneyList);
                }
                
            }
            catch ( Exception e ) {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.ToString(),
                    "����[���������̎擾�Ɏ��s���܂����B" + "\r\n" + e.Message,
                    -1,
                    MessageBoxButtons.OK);

                status = -1;
            }

            return status;
        }
        /// <summary>
        /// ����[���������X�g�擾����
        /// </summary>
        /// <param name="retList">�߂�l���X�g</param>
        /// <param name="fracProcMoneyDiv">0:������z, 1:�����, 2:����P��</param>
        /// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
        public int GetSalesProcMoneyList ( out ArrayList retList, int fracProcMoneyDiv )
        {
            if ( _salesProcMoneyStc == null ) {
                // ����[���������X�g�擾����
                this.GetSalesProcMoneyListToStatic();
            }

            retList = new ArrayList();
            Hashtable hash = new Hashtable();

            foreach ( SalesProcMoney salesProcMoney in _salesProcMoneyStc ) {
                // �[�������Ώۋ��z�敪(FracProcMoneyDiv)���w�肳�ꂽ�l�Ɠ������̂����AretList�ɒǉ�����B
                // ����[�������R�[�h�ŏ�����z�Ⴂ�̃��R�[�h�����݂���ׁA
                // Hash�ŏd���`�F�b�N����B
                if ( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) {

                    // �d���`�F�b�N
                    if (hash.Contains( salesProcMoney.FractionProcCode ) ) continue;
                    hash.Add( salesProcMoney.FractionProcCode, salesProcMoney );

                    ComboEditorItemCustomer comboEditorItem = new ComboEditorItemCustomer(salesProcMoney.FractionProcCode, ( string ) salesProcMoney.FractionProcCode.ToString());
                    retList.Add(comboEditorItem);
                }
            }

            if ( retList.Count > 0 ) {
                return 0;
            }
            else {
                return -1;
            }
        }

		/// <summary>
		/// ���l�K�C�h�}�X�^�w�b�_�����X�g�擾����
		/// </summary>
		/// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
		public int GetNoteGuideHdListToStatic()
		{
			if (_noteGuidHdListStc == null)
			{
				_noteGuidHdListStc = new ArrayList();
			}

			ArrayList noteGuidHdList = null;
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			// ���l�K�C�h�i�w�b�_�j���S���������i�_���폜�����j
			NoteGuidAcs noteGuidAcs = new NoteGuidAcs();		// ���l�K�C�h�}�X�^�A�N�Z�X�N���X

			try
			{
				status = noteGuidAcs.SearchHeader(out noteGuidHdList, this._enterpriseCode);
			}
			catch (System.Net.WebException e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.ToString(),
					"���l�K�C�h�i�w�b�_�j���̎擾�Ɏ��s���܂����B" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

				status = -1;
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_noteGuidHdListStc = (ArrayList)noteGuidHdList.Clone();
			}

			return status;
		}

		/// <summary>
		/// ���l�K�C�h�w�b�_���̎擾����
		/// </summary>
		/// <param name="guideDivCode">���[�U�[�K�C�h�敪</param>
		/// <returns>���[�U�[�K�C�h�w�b�_����</returns>
		public string GetNoteGuideHd(int guideDivCode)
		{
			string noteGuideName = string.Empty;
			if (_noteGuidHdListStc == null)
			{
				return noteGuideName;
			}

			foreach (NoteGuidHd ngh in _noteGuidHdListStc)
			{
				if (ngh.NoteGuideDivCode == guideDivCode)
				{
					noteGuideName = ngh.NoteGuideDivName;
					break;
				}
			}

			return noteGuideName;
		}

		/// <summary>
		/// ���l�K�C�h�}�X�^���X�g�擾����
		/// </summary>
		/// <param name="guideDivCode">���[�U�[�K�C�h�敪</param>
		/// <param name="retList">�߂�l���X�g</param>
		/// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
		public int GetDivCodeNoteGuideBodyList(int guideDivCode, out ArrayList retList)
		{
			NoteGuidBd noteGuidBd = new NoteGuidBd();

			ArrayList noteGuidBdList = null;
			retList = new ArrayList();

			// ���l�K�C�h�敪�w����l�K�C�h�i�{�f�B�j��񌟍������i�_���폜�����j
			NoteGuidAcs noteGuidAcs = new NoteGuidAcs();		// ���l�K�C�h�}�X�^�A�N�Z�X�N���X
			int status = noteGuidAcs.SearchDivCodeBody(out noteGuidBdList, this._enterpriseCode, guideDivCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (NoteGuidBd ngb in noteGuidBdList)
				{
					ComboEditorItemCustomer comboEditorItem = new ComboEditorItemCustomer(ngb.NoteGuideCode, ngb.NoteGuideName);
					retList.Add(comboEditorItem);
				}
			}

			if (retList.Count > 0)
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// �Z���K�C�h�\������(SFTKD00426U.DLL)
		/// </summary>
		/// <param name="agResult">�Z�����߂�l�N���X</param>
		/// <returns>STATUS [0:�I�� 0�ȊO:���I��]</returns>
		public int ShowAddressGuide(out AddressGuideResult agResult)
		{
			return ShowAddressGuide(0, 0, 0, out agResult);
		}

		/// <summary>
		/// �Z���K�C�h�\������(SFTKD00426U.DLL)
		/// </summary>
		/// <param name="addressCode1">�Z���R�[�h�P</param>
		/// <param name="addressCode2">�Z���R�[�h�Q</param>
		/// <param name="addressCode3">�Z���R�[�h�R</param>
		/// <param name="agResult">�Z�����߂�l�N���X</param>
		/// <returns>STATUS [0:�I�� 0�ȊO:���I��]</returns>
		public int ShowAddressGuide(int addressCode1, int addressCode2, int addressCode3, out AddressGuideResult agResult)
		{
			System.Windows.Forms.DialogResult result = this._addressGuide.ShowAddressGuide(addressCode1, addressCode2, addressCode3, out agResult);

			if ((result == DialogResult.OK) || (result == DialogResult.Yes))
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// �Z����������(�Z���R�[�h���)(SFTKD00426U.DLL)
		/// </summary>
		/// <param name="addressCode1">�Z���R�[�h�P</param>
		/// <param name="addressCode2">�Z���R�[�h�Q</param>
		/// <param name="addressCode3">�Z���R�[�h�R</param>
		/// <param name="agResult">�Z�����߂�l�N���X</param>
		/// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
		public int GetAddressFromAddressCode(int addressCode1,int addressCode2,int addressCode3, out AddressGuideResult agResult)
		{
			agResult = new AddressGuideResult();

			System.Windows.Forms.DialogResult result = this._addressGuide.SearchAddressFromAddressCode(addressCode1, addressCode2, addressCode3,ref agResult);

			if ((result == DialogResult.OK) || (result == DialogResult.Yes))
			{
				if (agResult.AddressName != "")
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
		/// �Z����������(�X�֔ԍ����)(SFTKD00426U.DLL)
		/// </summary>
		/// <param name="strPostNo">�X�֔ԍ�</param>
		/// <param name="agResult">�Z�����߂�l�N���X</param>
		/// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
		public int GetAddressFromPostNo(string strPostNo, out AddressGuideResult agResult)
		{
			System.Windows.Forms.DialogResult result = this._addressGuide.ShowPostNoSearchGuide(strPostNo, out agResult);

			if ((result == DialogResult.OK) || (result == DialogResult.Yes))
			{
				if (agResult.AddressName != "")
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
		/// �]�ƈ��K�C�h�\������(SFTOK09382A.DLL)
		/// </summary>
        /// <param name="employee">�]�ƈ��N���X</param>
		/// <returns>STATUS [0:�I�� 0�ȊO:���I��]</returns>
		public int ShowEmployeeGuide(out Employee employee)
		{
			int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
			return status;
		}

		/// <summary>
		/// �]�ƈ���������(SFTOK09382A.DLL)
		/// </summary>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="employee">�]�ƈ��N���X</param>
		/// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
		public int GetEmployeeFromEmployeeCode(string employeeCode, out Employee employee)
		{
			int status = this._employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
            //if ( employee.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
            if ( status == 0 && employee != null && employee.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD
            {
                employee = null;
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
			return status;
		}
        /// <summary>
        /// ������z�[�������K�C�h�\��
        /// </summary>
        /// <param name="salesProcMoney">������z�[�������N���X</param>
        /// <param name="fracProcMoneyDiv">������z�[�������敪(0:������z/1:�����/2:����P��)</param>
        /// <returns>STATUS [0:�I�� 0�ȊO:���I��]</returns>
        public int ShowSalesProcMoneyGuide( out SalesProcMoney salesProcMoney, int fracProcMoneyDiv )
        {
            int status = this._salesProcMoneyAcs.ExecuteGuid( this._enterpriseCode, fracProcMoneyDiv, out salesProcMoney );
            return status;
        }
        /// <summary>
        /// ������z�[���������݃`�F�b�N
        /// </summary>
        /// <param name="fracProcMoneyDiv"></param>
        /// <param name="fractionProcCode"></param>
        /// <returns></returns>
        public bool ExistsSalesProcMoney( int fracProcMoneyDiv, int fractionProcCode )
        {
            if ( _salesProcMoneyCdList == null )
            {
                _salesProcMoneyCdList = new List<SalesProcMoneyKey>();

                ArrayList salesProcMoneyList;
                this._salesProcMoneyAcs.Search( out salesProcMoneyList, this._enterpriseCode );
                foreach ( object obj in salesProcMoneyList )
                {
                    if ( obj is SalesProcMoney )
                    {
                        SalesProcMoney salesProcMoney = (obj as SalesProcMoney);
                        _salesProcMoneyCdList.Add( new SalesProcMoneyKey( salesProcMoney.FracProcMoneyDiv, salesProcMoney.FractionProcCode ) );
                    }
                }
            }

            return _salesProcMoneyCdList.Contains( new SalesProcMoneyKey( fracProcMoneyDiv, fractionProcCode ) );
        }
        /// <summary>
        /// ���_�K�C�h�\��
        /// </summary>
        /// <param name="secInfoSet">���_�N���X</param>
        /// <returns>STATUS [0:�I�� 0�ȊO:���I��]</returns>
        public int ShowSectionGuide( out SecInfoSet secInfoSet )
        {
            int status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out secInfoSet );
            return status;
        }
        /// <summary>
        /// ���_�擾
        /// </summary>
        /// <param name="secInfoSet"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int GetSectionFromSectionCode( out SecInfoSet secInfoSet, string sectionCode )
        {
            int status = this._secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, sectionCode );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
            //if ( secInfoSet.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
            if ( status == 0 && secInfoSet != null && secInfoSet.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
            {
                secInfoSet = null;
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            return status;
        }
        /// <summary>
        /// �q�ɃK�C�h�\��
        /// </summary>
        /// <param name="warehouse">(�o��)�q��</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns></returns>
        public int ShowWarehouseGuide( out Warehouse warehouse, string sectionCode )
        {
            int status = this._warehouseAcs.ExecuteGuid( out warehouse, this._enterpriseCode, sectionCode );
            return status;
        }
        /// <summary>
        /// �q�Ɏ擾����
        /// </summary>
        /// <param name="warehouse">(�o��)�q��</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns></returns>
        public int GetWarehouseFromWarehouseCode( out Warehouse warehouse, string sectionCode, string warehouseCode)
        {
            int status = this._warehouseAcs.Read( out warehouse, this._enterpriseCode, sectionCode, warehouseCode );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
            //if ( warehouse.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
            if ( status == 0 && warehouse != null && warehouse.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
            {
                warehouse = null;
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            return status;
        }
		/// <summary>
		/// ���Ӑ挟�������i���Ӑ�R�[�h���j
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
		public int GetCustomerInfoFromCustomerCode(int customerCode, out CustomerInfo customerInfo)
		{
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, out customerInfo);
			return status;
		}
		/// <summary>
		/// ���Ӑ挟�������i���Ӑ�R�[�h���j
		/// </summary>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerInfo">���Ӑ���N���X</param>
		/// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
		public int GetCustomerInfoFromCustomerCode(ConstantManagement.LogicalMode logicalMode, int customerCode, out CustomerInfo customerInfo)
		{
			int status = this._customerInfoAcs.ReadDBData(logicalMode, this._enterpriseCode, customerCode, true, out customerInfo);
			return status;
		}
		/// <summary>
		/// ���[�U�[�K�C�h�K�C�h�\������(SFTKD00641U.DLL)
		/// </summary>
		/// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
		/// <param name="userGdBd">���[�U�[�K�C�h�{�f�B�N���X</param>
		/// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
		public int ShowUserGuideGuide(int userGuideDivCd, out UserGdBd userGdBd)
		{
			userGdBd = new UserGdBd();

			System.Windows.Forms.DialogResult result = this._userGuideGuide.UserGuideGuideShow(userGuideDivCd, 0, this._enterpriseCode, ref userGdBd);

			if ((result == DialogResult.OK) || (result == DialogResult.Yes))
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				return -1;
			}
		}
		/// <summary>
		/// ���l�K�C�h�K�C�h�\������(SFTOK09402A.DLL)
		/// </summary>
		/// <param name="noteGuideDivCode">���l�K�C�h�敪</param>
		/// <param name="noteGuidBd">���l�K�C�h�{�f�B�N���X</param>
		/// <returns>STATUS [0:�擾���� 0�ȊO:�擾���s]</returns>
		public int ShowNoteGuideGuide(int noteGuideDivCode, out NoteGuidBd noteGuidBd)
		{
			noteGuidBd = new NoteGuidBd();

			NoteGuidAcs noteGuidAcs = new NoteGuidAcs();

			int status =  noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, noteGuideDivCode);
			return status;
		}
		/// <summary>
		/// �ڋq�R�[�h�������ԋ敪�擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>�ڋq�R�[�h�������ԋ敪</returns>
		public int GetCustCdAutoNumbering(string enterpriseCode, string sectionCode)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int status = this.ReadAllDefSet(enterpriseCode, sectionCode);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return _allDefSetStc.CustCdAutoNumbering;
            //}
            //else
            //{
            //    return 0;
            //}
            return 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
        ///// <summary>
        ///// �S�̏����l�ݒ�}�X�^�擾����
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <returns>STATUS [0:���� 0�ȊO:���s]</returns>
        //private int ReadAllDefSet(string enterpriseCode, string sectionCode)
        //{
        //    if (_allDefSetStc == null)
        //    {
        //        _allDefSetStc = new AllDefSet();
        //    }
        //    else
        //    {
        //        if ((_allDefSetStc.SectionCode.Trim() != "") && (_allDefSetStc.SectionCode.Trim() == sectionCode.Trim()))
        //        {
        //            // ���łɏ����擾���Ă�Ɣ��f����B
        //            return 0;
        //        }
        //    }

        //    AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
        //    int status = allDefSetAcs.Read(out _allDefSetStc, enterpriseCode, sectionCode);

        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        _allDefSetStc = new AllDefSet();
        //    }

        //    return status;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL

        /// <summary>
        /// �S�̐ݒ�擾����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public AllDefSet GetAllDefSet( string enterpriseCode, string sectionCode )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            // Key�𒲐�
            sectionCode = sectionCode.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD

            if ( stc_allDefSetDic == null )
            {
                stc_allDefSetDic = new Dictionary<string, AllDefSet>();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                ArrayList retList;
                _allDefSetAcs.Search( out retList, enterpriseCode, AllDefSetAcs.SearchMode.Remote );
                if ( retList != null )
                {
                    foreach ( AllDefSet allDefSet in retList )
                    {
                        if ( allDefSet.LogicalDeleteCode != 0 ) continue;
                        stc_allDefSetDic.Add( allDefSet.SectionCode.TrimEnd(), allDefSet );
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
            }

            if (!stc_allDefSetDic.ContainsKey(sectionCode))
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                //AllDefSet allDefSet;
                //int status = _allDefSetAcs.Read( out allDefSet, enterpriseCode, sectionCode, AllDefSetAcs.SearchMode.Remote );

                //if ( status == 0 )
                //{
                //}
                //else
                //{
                //    allDefSet = new AllDefSet();
                //}
                //stc_allDefSetDic.Add( sectionCode, allDefSet );
                //return allDefSet;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                // �S�Аݒ�
                string ct_AllSection = "00";

                if ( !stc_allDefSetDic.ContainsKey( ct_AllSection ) )
                {
                    return new AllDefSet();
                }
                return stc_allDefSetDic[ct_AllSection];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
            }
            return stc_allDefSetDic[sectionCode];
        }
        /// <summary>
        /// �S�̐ݒ�̑��z�\���敪�擾����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int GetTotalAmountDispWayCd( string enterpriseCode, string sectionCode )
        {
            AllDefSet allDefSet = GetAllDefSet( enterpriseCode, sectionCode );
            return allDefSet.TotalAmountDispWayCd;
        }

        /// <summary>
        /// �ŗ��ݒ�擾����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public TaxRateSet GetTaxRateSet( string enterpriseCode, int taxRateCode )
        {
            // --- CHG 2009/03/06 ��QID:12199�Ή�------------------------------------------------------>>>>>
            //if ( stc_taxRateSet == null )
            //{
            //    TaxRateSet taxRateSet;
            //    int status = _taxRateSetAcs.Read( out taxRateSet, enterpriseCode, taxRateCode );
            //    if ( status == 0 )
            //    {
            //        stc_taxRateSet = taxRateSet;
            //    }
            //    else
            //    {
            //        stc_taxRateSet = new TaxRateSet();
            //    }
            //}

            TaxRateSet taxRateSet;
            int status = _taxRateSetAcs.Read(out taxRateSet, enterpriseCode, taxRateCode);
            if (status == 0)
            {
                stc_taxRateSet = taxRateSet;
            }
            else
            {
                stc_taxRateSet = new TaxRateSet();
            }
            // --- CHG 2009/03/06 ��QID:12199�Ή�------------------------------------------------------<<<<<

            return stc_taxRateSet;
        }
        /// <summary>
        /// �ŗ��ݒ�̓]�ŕ����擾����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public int GetConsTaxLayMethod( string enterpriseCode, int taxRateCode )
        {
            TaxRateSet taxRateSet = GetTaxRateSet( enterpriseCode, taxRateCode );
            return taxRateSet.ConsTaxLayMethod;
        }
		# endregion
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        /// <summary>
        /// ���Ӑ�}�X�^���R�[�h�����Ӑ挟�����R�[�h�ւ̕ϊ�����
        /// </summary>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public static CustomerSearchRet CopyToCustomerSearchRetFromCustomerInfo( CustomerInfo customerInfo )
        {
            CustomerSearchRet searchRet = new CustomerSearchRet();

            searchRet.AcceptWholeSale = customerInfo.AcceptWholeSale;
            searchRet.Address1 = customerInfo.Address1;
            searchRet.Address3 = customerInfo.Address3;
            searchRet.Address4 = customerInfo.Address4;
            searchRet.CustomerCode = customerInfo.CustomerCode;
            searchRet.CustomerSubCode = customerInfo.CustomerSubCode;
            searchRet.EnterpriseCode = customerInfo.EnterpriseCode;
            searchRet.EnterpriseName = customerInfo.EnterpriseName;
            searchRet.HomeTelNo = customerInfo.HomeTelNo;
            searchRet.HonorificTitle = customerInfo.HonorificTitle;
            searchRet.Kana = customerInfo.Kana;
            searchRet.LogicalDeleteCode = customerInfo.LogicalDeleteCode;
            searchRet.MngSectionCode = customerInfo.MngSectionCode;
            searchRet.Name = customerInfo.Name;
            searchRet.Name2 = customerInfo.Name2;
            searchRet.OfficeTelNo = customerInfo.OfficeTelNo;
            searchRet.PortableTelNo = customerInfo.PortableTelNo;

            // 2009/12/02 Add >>>
            searchRet.HomeFaxNo = customerInfo.HomeFaxNo;
            searchRet.OfficeFaxNo = customerInfo.OfficeFaxNo;
            // 2009/12/02 Add <<<

            searchRet.PostNo = customerInfo.PostNo;
            searchRet.SearchTelNo = customerInfo.SearchTelNo;
            searchRet.Snm = customerInfo.CustomerSnm;
            searchRet.TotalDay = customerInfo.TotalDay;
            searchRet.UpdateDate = customerInfo.UpdateDateTime;

            return searchRet;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
	}
}
