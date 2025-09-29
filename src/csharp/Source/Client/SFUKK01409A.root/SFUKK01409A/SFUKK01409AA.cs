//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �����`�[����
// �v���O�����T�v   : �����`�[���͂̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2008/06/26  �C�����e : Partsman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/05/15  �C�����e : MANTIS�y13286�A13287�z�����S�̐ݒ�̍ŐV���擾
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �C �� ��  2009/07/21  �C�����e : MANTIS�y13286�A13287�z�t�B�[�h�o�b�N�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00 �쐬�S�� : FSI����
// �C �� ��  K2012/07/13 �C�����e : �R�`���i�ʈ˗�
//                                : �U�����z���͎��͓Ǝ��̋�s�R�[�h�̓��͂��\�ɏC��
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Data;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �����`�[���͐ݒ�n�f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����`�[���͐ݒ�n�f�[�^�̎擾���s���܂��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br>Update Note: 18322 T.Kimura �g��.NS�p�ɕύX</br>
    /// <br>Update Note: 2008/06/26 30414 �E �K�j Partsman�p�ɕύX</br>
    /// <br>UpdateNote : K2012/07/13 FSI���� �R�`���i�ʈ˗�</br>
    /// <br>             �U�����z���͎��͓Ǝ��̋�s�R�[�h�̓��͂��\�ɏC��</br>
    /// <br></br>
	/// </remarks>
	public class DepositRelDataAcs
	{
		# region Constructor
		/// <summary>
		/// �����`�[���͐ݒ�n�f�[�^�A�N�Z�X�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		static DepositRelDataAcs()
		{
			try
			{
				// ���_���A�N�Z�X�N���X
				_secInfoAcs = new SecInfoAcs();

                // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
                // ����S�̐ݒ�}�X�^�A�N�Z�X�N���X
                _salesTtlStAcs = new SalesTtlStAcs();
                // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

                // ADD 2009/05/15 ------>>>
                // �����S�̐ݒ�}�X�^�A�N�Z�X�N���X
                _billAllStAcs = new BillAllStAcs();
                // ADD 2009/05/15 ------<<<
                
				// �����[�g�I�u�W�F�N�g�擾
				_iDepBillMonSecDB = (IDepBillMonSecDB)MediationDepBillMonSecDB.GetDepBillMonSecDB();
			}
			catch (Exception)
			{				
				// �I�t���C������null���Z�b�g
				_iDepBillMonSecDB = null;
			}
		}
		# endregion

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        # region public const Members

        //***************************************************************
        // ����������DataSet�p�萔�錾
        //***************************************************************
        /// <summary>����������Table����</summary>
        public const string ctDepositKindDataTable = "DepositKindTable";

        /// <summary>����敪</summary>
        public const string ctDepositKindDiv = "DepositKindDiv";

        /// <summary>����R�[�h</summary>
        public const string ctDepositKindCode = "DepositKindCode";

        /// <summary>���햼��(��������)</summary>
        public const string ctDepositKindName = "DepositKindName";

        /// <summary>�������z</summary>
        public const string ctDeposit = "Deposit";

        /// <summary>�N(����)</summary>
        public const string ctYear = "Year";

        /// <summary>��(����)</summary>
        public const string ctMonth = "Month";

        /// <summary>��(����)</summary>
        public const string ctDay = "Day";

        // --- ADD K2012/07/13 ---------->>>>>
        /// <summary>��s�R�[�h</summary>
        public const string ctBank = "Bank";
        // --- ADD K2012/07/13 ----------<<<<<

        #endregion public const Members
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        # region Private Menbers
        //***************************************************************
		// ���A�Z���u���N���X�����o�[
		//***************************************************************
		/// <summary>���_���A�N�Z�X�N���X</summary>
		private static SecInfoAcs _secInfoAcs;

		/// <summary>�����ݒ�n�����[�e�B���O�I�u�W�F�N�g</summary>
		private static IDepBillMonSecDB _iDepBillMonSecDB = null;

		//***************************************************************
		// �ێ��p�����o �����`�[���͂Ŏg�p���鋤�ʍ��ڂȂ�
		//***************************************************************
		/// <summary>��ʃ^�C�v���X�g</summary>
		private static SortedList _slDispType = new SortedList();

		/// <summary>�f�t�H���g��ʃ^�C�v</summary>
		private static int _defaultDispType = 0;

        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>��������R�[�h���X�g</summary>
        //private static SortedList _slMoneyKindCode = new SortedList();
        private static Dictionary<int, string> _dicMoneyKindCode = new Dictionary<int, string>();

        /// <summary>�����s�ԍ����X�g</summary>
        private static Dictionary<int, int> _dicDepositRowNo = new Dictionary<int, int>();

        private static DepositSt _depositSt = new DepositSt();

        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>��������敪���X�g</summary>
		private static Hashtable _htMoneyKindDiv = new Hashtable();

		/// <summary>�������햼�̃��X�g</summary>
		private static Hashtable _htMoneyKindName = new Hashtable();

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>�f�t�H���g��������R�[�h</summary>
		private static int _initSelMoneyKindCd = 0;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>���|����R�[�h���X�g</summary>
		private static SortedList _slSalesKindCode = new SortedList();

		/// <summary>���|����敪���X�g</summary>
		private static Hashtable _htSalesKindDiv = new Hashtable();

		/// <summary>���|���햼�̃��X�g</summary>
		private static Hashtable _htSalesKindName = new Hashtable();

		/// <summary>���_��񃊃X�g</summary>
		private static SortedList _slSection = new SortedList();

		/// <summary>����_�R�[�h</summary>
		private static string _sectionCode = "";

		/// <summary>�����v�㋒�_�R�[�h(���O�C�����_)</summary>
		private static string _demandAddUpSecCd = "";

		/// <summary>�{�Ћ@�\�t���O(���O�C�����_)</summary>
		public static int _mainOfficeFuncFlag = 0;
			
		/// <summary>�����`�[�ďo����</summary>
		private static int _depositCallMonths = 0;

		/// <summary>�����ϓ����`�[�ďo�敪</summary>
		private static int _alwcDepositCall = 0;

		/// <summary>���������敪</summary>
		private static int _allowanceProc = 0;

		/// <summary>�����`�[�C���敪</summary>
		private static int _depositSlipMnt = 0;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>����p�ʓ����I�v�V����</summary>
		private static bool _optSeparateCost = false;

		/// <summary>SF�V�X�e�������t���O</summary>
		private static bool _introducedSystemSF = false;

		/// <summary>BK�V�X�e�������t���O</summary>
		private static bool _introducedSystemBK = false;
		
		/// <summary>CS�V�X�e�������t���O</summary>
		private static bool _introducedSystemCS = false;

        // �� 20070116 18322 a
        /// <summary>MA�V�X�e�������t���O</summary>
        private static bool _introducedSystemMA = false;
        // �� 20070116 18322 a
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�����`�[���t�N���A�敪</summary>
        /// <value>0:�V�X�e�����t�ɖ߂��@1:���͓��t�̂܂�</value>
        private int _depoSlipDateClrDiv;

        /// <value>0:�����Ȃ��@1:���͕s��</value>
        private int _depoSlipDateAmbit;

        /// <summary>����S�̐ݒ�}�X�^�A�N�Z�X�N���X</summary>
        private static SalesTtlStAcs _salesTtlStAcs;
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // ADD 2009/05/15 ------>>>
        /// <summary>�����S�̐ݒ�}�X�^�A�N�Z�X�N���X</summary>
        private static BillAllStAcs _billAllStAcs;
        // ADD 2009/05/15 ------<<<
        
        # endregion

		# region public property
		/// <summary>��ʃ^�C�v���X�g(get)</summary>
		public SortedList SlDispType
		{
			get{return _slDispType;}
		}
		/// <summary>�f�t�H���g��ʃ^�C�v(get)(set)</summary>
		public int DefaultDispType
		{
			get{return _defaultDispType;}
			set{_defaultDispType = value;}
		}

        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>��������R�[�h���X�g(get)</summary>
        //public SortedList SlMoneyKindCode
        //{
        //    get{return _slMoneyKindCode;}
        //}
        public Dictionary<int, string> DicMoneyKindCode
        {
            get { return _dicMoneyKindCode; }
        }

        /// <summary>�����ݒ�}�X�^(get)</summary>
        public DepositSt DepositMaster
        {
            get { return _depositSt; }
        }
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>��������敪���X�g(get)</summary>
		public Hashtable HtMoneyKindDiv
		{
			get{return _htMoneyKindDiv;}
		}
		/// <summary>�������햼�̃��X�g(get)</summary>
		public Hashtable HtMoneyKindName
		{
			get{return _htMoneyKindName;}
		}

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>�f�t�H���g��������R�[�h(get)</summary>
		public int InitSelMoneyKindCd
		{
			get{return _initSelMoneyKindCd;}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>���|����R�[�h���X�g(get)</summary>
		public SortedList SlSalesKindCode
		{
			get{return _slSalesKindCode;}
		}
		/// <summary>���|����敪���X�g(get)</summary>
		public Hashtable HtSalesKindDiv
		{
			get{return _htSalesKindDiv;}
		}
		/// <summary>���|���햼�̃��X�g(get)</summary>
		public Hashtable HtSalesKindName
		{
			get{return _htSalesKindName;}
		}
		/// <summary>���_��񃊃X�g(get)</summary>
		public SortedList SlSection
		{
			get{return _slSection;}
		}
		/// <summary>�����v�㋒�_�R�[�h(���O�C�����_)(get)(set)</summary>
		public string DemandAddUpSecCd
		{
			get{return _demandAddUpSecCd;}
			set{_demandAddUpSecCd = value;}
		}
		/// <summary>�{�Ћ@�\�t���O(���O�C�����_)(get)</summary>
		public int MainOfficeFuncFlag
		{
			get{return _mainOfficeFuncFlag;}
		}
		/// <summary>�����`�[�ďo����(get)</summary>
		public int DepositCallMonths
		{
			get{return _depositCallMonths;}
		}
		/// <summary>�����ϓ����`�[�ďo�敪(get)</summary>
		public int AlwcDepositCall
		{
			get{return _alwcDepositCall;}
		}
		/// <summary>���������敪(get)</summary>
		public int AllowanceProc
		{
			get{return _allowanceProc;}
		}
		/// <summary>�����`�[�C���敪(get)</summary>
		public int DepositSlipMnt
		{
			get{return _depositSlipMnt;}
		}
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>����p�ʓ����I�v�V����(get)</summary>
		public bool OptSeparateCost
		{
			get{return _optSeparateCost;}
		}
		/// <summary>SF�V�X�e�������`�F�b�N(get)</summary>
		public bool IntroducedSystemSF
		{
			get{return _introducedSystemSF;}
		}
		/// <summary>BK�V�X�e�������`�F�b�N(get)</summary>
		public bool IntroducedSystemBK
		{
			get{return _introducedSystemBK;}
		}
		/// <summary>CS�V�X�e�������`�F�b�N(get)</summary>
		public bool IntroducedSystemCS
		{
			get{return _introducedSystemCS;}
		}

        // �� 20070116 18322 a
        /// <summary>MA�V�X�e�������`�F�b�N(get)</summary>
        public bool IntroducedSystemMA
        {
            get { return _introducedSystemMA; }
        }
        // �� 20070116 18322 a

        /// <summary>�V�X�e��������(get)</summary>
		public int IntroducedSystemCount
		{
			get{
				int cnt = 0;
				if (IntroducedSystemSF) ++cnt;
				if (IntroducedSystemBK) ++cnt;
				if (IntroducedSystemCS) ++cnt;
                // �� 20070116 18322 a
                if (IntroducedSystemMA) ++cnt;
                // �� 20070116 18322 a
                return cnt;
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�����`�[���t�N���A�敪</summary>
        /// <value>0:�V�X�e�����t�ɖ߂��@1:���͓��t�̂܂�</value>
        public int DepoSlipDateClrDiv
        {
            get { return _depoSlipDateClrDiv; }
        }

        /// <summary>�����`�[���t�͈͋敪</summary>
        /// <value>0:�����Ȃ��@1:���͕s��</value>
        public int DepoSlipDateAmbit
        {
            get { return _depoSlipDateAmbit; }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		# endregion

		# region public Methods

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ����S�̐ݒ�}�X�^�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ����S�̐ݒ�}�X�^���擾���܂��B
        ///         �@�@�@    ���_���ύX�����x�ɂ��̏������s���K�v������܂��B</br>
        /// <br>Programmer  : 30414 �E�@�K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int GetSalesTtlSt(string enterpriseCode, string sectionCode)
        {
            int status = 0;
            ArrayList retList = new ArrayList();

            // ADD 2009/05/15 ------>>>
            // �����ݒ�
            this._depoSlipDateClrDiv = 0;
            this._depoSlipDateAmbit = 0;
            // ADD 2009/05/15 ------<<<
            
            try
            {
                status = _salesTtlStAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (SalesTtlSt salesTtlSt in retList)
                    {
                        // ADD 2009/05/15 ------>>>
                        if ((salesTtlSt.LogicalDeleteCode == 0) && (salesTtlSt.SectionCode.Trim() == "00"))
                        {
                            // �����`�[���t�N���A�敪
                            this._depoSlipDateClrDiv = salesTtlSt.DepoSlipDateClrDiv;

                            // �����`�[���t�͈͋敪
                            this._depoSlipDateAmbit = salesTtlSt.DepoSlipDateAmbit;

                            continue;
                        }
                        // ADD 2009/05/15 ------<<<
            
                        if ((salesTtlSt.LogicalDeleteCode == 0) && (salesTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                        {
                            // �����`�[���t�N���A�敪
                            this._depoSlipDateClrDiv = salesTtlSt.DepoSlipDateClrDiv;
                            
                            // �����`�[���t�͈͋敪
                            this._depoSlipDateAmbit = salesTtlSt.DepoSlipDateAmbit;

                            return status;
                        }
                    }
                }
            }
            catch
            {

            }

            return status;
        }

        // ADD 2009/05/15 ------>>>
        /// <summary>
        /// �����S�̐ݒ�}�X�^�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �����S�̐ݒ�}�X�^���擾���܂��B
        ///         �@�@�@    ���_���ύX�����x�ɂ��̏������s���K�v������܂��B</br>
        /// <br></br>
        /// </remarks>
        public int GetBillAllSt(string enterpriseCode, string sectionCode)
        {
            int status = 0;
            ArrayList retList = new ArrayList();

            // �����ݒ�
            _depositSlipMnt = 0;
            
            try
            {
                status = _billAllStAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (BillAllSt billAllSt in retList)
                    {
                        if ((billAllSt.LogicalDeleteCode == 0) && (billAllSt.SectionCode.Trim() == "00"))
                        {
                            // �����`�[�C���敪
                            _depositSlipMnt = billAllSt.DepositSlipMntCd;

                            // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                            //���������敪
                            _allowanceProc = billAllSt.AllowanceProcCd;
                            // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            continue;
                        }
                        
                        if ((billAllSt.LogicalDeleteCode == 0) && (billAllSt.SectionCode.Trim() == sectionCode.Trim()))
                        {
                            // �����`�[�C���敪
                            _depositSlipMnt = billAllSt.DepositSlipMntCd;

                            // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                            //���������敪
                            _allowanceProc = billAllSt.AllowanceProcCd;
                            // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            return status;
                        }
                    }
                }
            }
            catch
            {

            }

            return status;
        }
        // ADD 2009/05/15 ------<<<

        /// <summary>
        /// �����s�ԍ��擾����
        /// </summary>
        /// <param name="moneyKindCode">����R�[�h</param>
        /// <returns>�����s�ԍ�</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �����s�ԍ����擾���܂��B</br>
        /// <br>Programmer  : 30414 �E�@�K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int GetDepositRowNo(int moneyKindCode)
        {
            int depositRowNo = 0;

            if (_dicDepositRowNo.ContainsKey(moneyKindCode))
            {
                depositRowNo = _dicDepositRowNo[moneyKindCode];
            }

            return depositRowNo;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// �����`�[���͊֘A�ݒ�f�[�^�擾����
		/// </summary>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �ݒ�f�[�^�֘A���擾���܂��B
		///         �@�@�@    ���O�C�����_�����ɂ��ē����܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int GetInitialSettingData(out string errmsg)
		{
			// ���O�C�����_�R�[�h�擾
			_sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

			return this.InitialSettingData(_sectionCode, out errmsg);
		}

		/// <summary>
		/// �����`�[���͊֘A�ݒ�f�[�^�擾����
		/// </summary>
		/// <param name="sectionCode">����_�R�[�h</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �ݒ�f�[�^�֘A���擾���܂��B
		///         �@�@�@    ���O�C�����_�ł͂Ȃ��p�����[�^�̊���_�R�[�h�����ɂ��ē����܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int GetInitialSettingData(string sectionCode, out string errmsg)
		{
			if ((sectionCode == null) || (sectionCode == ""))
			{
				// ���O�C�����_�R�[�h�擾
				_sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
			}
			else
			{
				// ����_�R�[�h�擾
				_sectionCode = sectionCode;
			}

			return this.InitialSettingData(_sectionCode, out errmsg);
		}

		# endregion

		# region private Methods
		/// <summary>
		/// �����`�[���͊֘A�ݒ�f�[�^�擾����
		/// </summary>
		/// <param name="sectionCode">����_�R�[�h</param>
		/// <param name="errmsg">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �ݒ�f�[�^�֘A���擾���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private int InitialSettingData(string sectionCode, out string errmsg)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			errmsg = "";
			int count;
			byte[] depositStWorkByte = null;
			byte[] billAllStWorkByte = null;
			object moneyKindWorkListObj = null;
            ArrayList test = new ArrayList();
            moneyKindWorkListObj = test;
			try
			{
				// �����ݒ�n�f�[�^�Ǎ���
                st = _iDepBillMonSecDB.Search(out count, 0, LoginInfoAcquisition.EnterpriseCode, out depositStWorkByte, out billAllStWorkByte, out moneyKindWorkListObj);
				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					errmsg = "�����ݒ�f�[�^�擾�����Ɏ��s���܂����B";
					return st;
				}
			}
			catch (Exception ex)
			{
				errmsg = ex.Message;
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				return st;
			}

			// �擾�f�[�^�̃f�V���A���C�Y
			DepositStWork depositStWork = (DepositStWork)XmlByteSerializer.Deserialize(depositStWorkByte, typeof(DepositStWork));
			BillAllStWork billAllStWork = (BillAllStWork)XmlByteSerializer.Deserialize(billAllStWorkByte, typeof(BillAllStWork));
			ArrayList moneyKindWorkList = (ArrayList)moneyKindWorkListObj;

            // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>
            //_iDepBillMonSecDB.Search�ł͑S�Аݒ肵���擾����Ă��Ȃ����߁A�����S�̐ݒ蒊�o���\�b�h���Ăяo��
            GetBillAllSt(LoginInfoAcquisition.EnterpriseCode, _sectionCode);
            // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<
            
			// ��ʃ^�C�v���X�g�̍쐬
			_slDispType.Clear();
			_slDispType.Add(1, "�����`�[����(�����^)");
            
            // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (billAllStWork.AllowanceProcCd != 2)				// �����s�^�C�v�̎��͎󒍎w��^�͖���
            if (_allowanceProc != 2)				// �����s�^�C�v�̎��͎󒍎w��^�͖���
            // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                // �� 20070130 18322 c MA.NS�p�ɕύX
				//_slDispType.Add(2, "�����`�[����(�󒍎w��^)");

				_slDispType.Add(2, "�����`�[����(����w��^)");
                // �� 20070130 18322 c
			}
			
			// -------------------------- //
			// --- �����ݒ�}�X�^��� --- //
			// -------------------------- //
			// �f�t�H���g��ʃ^�C�v
			_defaultDispType = depositStWork.DepositInitDspNo;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // �f�t�H���g��������R�[�h
            _initSelMoneyKindCd = depositStWork.InitSelMoneyKindCd;

            // �����`�[�ďo����
            _depositCallMonths = depositStWork.DepositCallMonths;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // �����ϓ����`�[�ďo�敪
			_alwcDepositCall = depositStWork.AlwcDepoCallMonthsCd;

			// �������햼�̃��X�g/��������敪���X�g
			_htMoneyKindName.Clear();
			_htMoneyKindDiv.Clear();
			foreach (MoneyKindWork moneyKindWork in moneyKindWorkList)
			{
                if ((moneyKindWork.LogicalDeleteCode == 0) && (moneyKindWork.PriceStCode == 0))
                {
                    _htMoneyKindName.Add(moneyKindWork.MoneyKindCode, moneyKindWork.MoneyKindName);
                    _htMoneyKindDiv.Add(moneyKindWork.MoneyKindCode, moneyKindWork.MoneyKindDiv);
                }
			}

			// �����ݒ����R�[�h
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //_slMoneyKindCode.Clear();
            //if ((depositStWork.DepositStKindCd1 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd1] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd1, _htMoneyKindName[depositStWork.DepositStKindCd1]);
            //if ((depositStWork.DepositStKindCd2 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd2] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd2, _htMoneyKindName[depositStWork.DepositStKindCd2]);
            //if ((depositStWork.DepositStKindCd3 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd3] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd3, _htMoneyKindName[depositStWork.DepositStKindCd3]);
            //if ((depositStWork.DepositStKindCd4 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd4] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd4, _htMoneyKindName[depositStWork.DepositStKindCd4]);
            //if ((depositStWork.DepositStKindCd5 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd5] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd5, _htMoneyKindName[depositStWork.DepositStKindCd5]);
            //if ((depositStWork.DepositStKindCd6 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd6] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd6, _htMoneyKindName[depositStWork.DepositStKindCd6]);
            //if ((depositStWork.DepositStKindCd7 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd7] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd7, _htMoneyKindName[depositStWork.DepositStKindCd7]);
            //if ((depositStWork.DepositStKindCd8 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd8] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd8, _htMoneyKindName[depositStWork.DepositStKindCd8]);
            //if ((depositStWork.DepositStKindCd9 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd9] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd9, _htMoneyKindName[depositStWork.DepositStKindCd9]);
            //if ((depositStWork.DepositStKindCd10 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd10] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd10, _htMoneyKindName[depositStWork.DepositStKindCd10]);

            _dicMoneyKindCode.Clear();
            _dicDepositRowNo.Clear();
            if ((depositStWork.DepositStKindCd1 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd1] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd1, (string)_htMoneyKindName[depositStWork.DepositStKindCd1]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd1, 1);
            }
            if ((depositStWork.DepositStKindCd2 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd2] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd2, (string)_htMoneyKindName[depositStWork.DepositStKindCd2]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd2, 2);
            }
            if ((depositStWork.DepositStKindCd3 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd3] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd3, (string)_htMoneyKindName[depositStWork.DepositStKindCd3]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd3, 3);
            }
            if ((depositStWork.DepositStKindCd4 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd4] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd4, (string)_htMoneyKindName[depositStWork.DepositStKindCd4]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd4, 4);
            }
            if ((depositStWork.DepositStKindCd5 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd5] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd5, (string)_htMoneyKindName[depositStWork.DepositStKindCd5]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd5, 5);
            }
            if ((depositStWork.DepositStKindCd6 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd6] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd6, (string)_htMoneyKindName[depositStWork.DepositStKindCd6]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd6, 6);
            }
            if ((depositStWork.DepositStKindCd7 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd7] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd7, (string)_htMoneyKindName[depositStWork.DepositStKindCd7]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd7, 7);
            }
            if ((depositStWork.DepositStKindCd8 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd8] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd8, (string)_htMoneyKindName[depositStWork.DepositStKindCd8]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd8, 8);
            }
            if ((depositStWork.DepositStKindCd9 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd9] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd9, (string)_htMoneyKindName[depositStWork.DepositStKindCd9]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd9, 9);
            }
            if ((depositStWork.DepositStKindCd10 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd10] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd10, (string)_htMoneyKindName[depositStWork.DepositStKindCd10]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd10, 10);
            }

            _depositSt.DepositStKindCd1 = depositStWork.DepositStKindCd1;
            _depositSt.DepositStKindCd2 = depositStWork.DepositStKindCd2;
            _depositSt.DepositStKindCd3 = depositStWork.DepositStKindCd3;
            _depositSt.DepositStKindCd4 = depositStWork.DepositStKindCd4;
            _depositSt.DepositStKindCd5 = depositStWork.DepositStKindCd5;
            _depositSt.DepositStKindCd6 = depositStWork.DepositStKindCd6;
            _depositSt.DepositStKindCd7 = depositStWork.DepositStKindCd7;
            _depositSt.DepositStKindCd8 = depositStWork.DepositStKindCd8;
            _depositSt.DepositStKindCd9 = depositStWork.DepositStKindCd9;
            _depositSt.DepositStKindCd10 = depositStWork.DepositStKindCd10;

            _depositSt.DepositStKindCdNm1 = (string)_htMoneyKindName[depositStWork.DepositStKindCd1];
            _depositSt.DepositStKindCdNm2 = (string)_htMoneyKindName[depositStWork.DepositStKindCd2];
            _depositSt.DepositStKindCdNm3 = (string)_htMoneyKindName[depositStWork.DepositStKindCd3];
            _depositSt.DepositStKindCdNm4 = (string)_htMoneyKindName[depositStWork.DepositStKindCd4];
            _depositSt.DepositStKindCdNm5 = (string)_htMoneyKindName[depositStWork.DepositStKindCd5];
            _depositSt.DepositStKindCdNm6 = (string)_htMoneyKindName[depositStWork.DepositStKindCd6];
            _depositSt.DepositStKindCdNm7 = (string)_htMoneyKindName[depositStWork.DepositStKindCd7];
            _depositSt.DepositStKindCdNm8 = (string)_htMoneyKindName[depositStWork.DepositStKindCd8];
            _depositSt.DepositStKindCdNm9 = (string)_htMoneyKindName[depositStWork.DepositStKindCd9];
            _depositSt.DepositStKindCdNm10 = (string)_htMoneyKindName[depositStWork.DepositStKindCd10];

            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

			// -------------------------- //
			// --- �����ݒ�}�X�^��� --- //
			// -------------------------- //
			// ���������敪
			//_allowanceProc = billAllStWork.AllowanceProcCd; // DEL 2009/07/21

			// �����`�[�C���敪
            //_depositSlipMnt = billAllStWork.DepositSlipMntCd;     // DEL 2009/05/15

			// -------------------------- //
			// --- ���_���}�X�^��� --- //
			// -------------------------- //
			_slSection.Clear();
			// �A�N�Z�X�N���X��苒�_�f�[�^���擾����
			foreach (SecInfoSet dt in _secInfoAcs.SecInfoSetList)
			{
				_slSection.Add(dt.SectionCode, dt.SectionGuideNm);

                if (dt.SectionCode.Trim() == sectionCode.Trim())
                {
                    _demandAddUpSecCd = sectionCode;
                }
			}

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// ����_�̐����v�㋒�_�̎擾
			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(sectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out secInfoSet);
			_demandAddUpSecCd = secInfoSet.SectionCode;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // �{�Ћ@�\�̂ݎg�p [9577]
            _mainOfficeFuncFlag = 1;

            //// �����I�v�V����/�V�X�e���`�F�b�N
            //PurchaseStatus purchaseSt;

            //// ���_�I�v�V������������
            //purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION);
            //if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
            //{
            //    // �{�Ћ@�\�t���O
            //    _mainOfficeFuncFlag = _secInfoAcs.GetMainOfficeFuncFlag(sectionCode);
            //}
            //else
            //{
            //    // �{�Ћ@�\�t���O
            //    _mainOfficeFuncFlag = 0;
            //}

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// ����p�ʓ����I�v�V�����͂��邩
			purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SeparatePayment);
			if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
				_optSeparateCost = true;
			// �����V�X�e�����邩�H
			purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF);
			if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
				_introducedSystemSF = true;
			// ����V�X�e�����邩�H
			purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK);
			if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
				_introducedSystemBK = true;
			// �Ԕ̃V�X�e�����邩�H
			purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS);
			if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
				_introducedSystemCS = true;

            // �� 20070116 18322 a
            // �g��.NS�L��
            purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_KT);
            if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
            {
                // �_��ς݂����p�ł̂Ƃ�
                _introducedSystemMA = true;
            }
            // �� 20070116 18322 a
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            return st;
		}
		# endregion
	}
}
