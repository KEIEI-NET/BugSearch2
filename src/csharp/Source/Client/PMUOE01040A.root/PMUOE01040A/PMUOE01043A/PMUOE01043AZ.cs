//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d����M���䏉�����A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d����M���䏉�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : ���� 
// �C �� ��  2014/09/19  �C�����e : Redmine#43265 �C�X�R�@UOE���M�����񓚉�ʂɂă��[�J�[�Ⴂ�̓���i�ԑI���E�B���h�E���\�������
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading; 
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// �t�n�d����M���䏉�����A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �t�n�d����M���䏉�����A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
    /// <br>Update Note: 2014/09/19 ����</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>             Redmine#43265�̑Ή� �C�X�R�@UOE���M�����񓚉�ʂɂă��[�J�[�Ⴂ�̓���i�ԑI���E�B���h�E���\�������</br>
	/// </remarks>
	public partial class UoeSndRcvCtlInitAcs
	{
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructors
        public UoeSndRcvCtlInitAcs()
		{
            try
            {
                //��ƃR�[�h���擾����
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                //���O�C�����_�R�[�h
                this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

                //�t�n�d����M�i�m�k�A�N�Z�X�N���X
                this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

                this._acptAnOdrTtlStAcs = new AcptAnOdrTtlStAcs();  // �󔭒��S�̐ݒ�}�X�^
                this._taxRateSetAcs = new TaxRateSetAcs();          // �ŗ��ݒ�}�X�^
                this._allDefSetAcs = new AllDefSetAcs();            // �S�̏����l�ݒ�}�X�^
                this._salesTtlStAcs = new SalesTtlStAcs();          // ����S�̐ݒ�}�X�^
                this._estimateDefSetAcs = new EstimateDefSetAcs();  // ���Ϗ����l�ݒ�}�X�^
                this._slipPrtSetAcs = new SlipPrtSetAcs();          // �`�[����ݒ�}�X�^
                this._custSlipMngAcs = new CustSlipMngAcs();        // ���Ӑ�}�X�^�i�`�[�Ǘ��j
                this._supplierAcs = new SupplierAcs();              // �d����}�X�^
                this._userGuideAcs = new UserGuideAcs();            // ���[�U�[�K�C�h

                this._acptAnOdrTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
                this._salesTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
                this._slipPrtSetAcs.IsLocalDBRead = ctIsLocalDBRead;
                this._custSlipMngAcs.IsLocalDBRead = ctIsLocalDBRead;

                ReadInitData(_enterpriseCode, _loginSectionCd);
            }
            catch (Exception)
            {
                throw;
            }
		}

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns></returns>
        public static UoeSndRcvCtlInitAcs GetInstance()
        {
            if (_uoeSndRcvCtlInitAcs == null)
            {
                _uoeSndRcvCtlInitAcs = new UoeSndRcvCtlInitAcs();
            }
            return _uoeSndRcvCtlInitAcs;
        }
		# endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		# region Private Members

		# region �A�N�Z�X�N���X
        /// <summary>
        /// �A�N�Z�X�N���X
        /// </summary>

        //�A�N�Z�X�N���X �C���X�^���X
        private static UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs = null;

        //�A�N�Z�X�N���X �C���X�^���X
        private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        private AcptAnOdrTtlStAcs _acptAnOdrTtlStAcs = null;
        private TaxRateSetAcs _taxRateSetAcs = null;
        private AllDefSetAcs _allDefSetAcs = null;
        private SalesTtlStAcs _salesTtlStAcs = null;
        private EstimateDefSetAcs _estimateDefSetAcs = null;
        private SlipPrtSetAcs _slipPrtSetAcs = null;
        private CustSlipMngAcs _custSlipMngAcs = null;
        private SupplierAcs _supplierAcs = null;           // �d���� �A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;

        # endregion

		# region �擾�N���X
        /// <summary>
        /// �擾�N���X
        /// </summary>
        private string _enterpriseCode = String.Empty;  //��ƃR�[�h
        private string _loginSectionCd = String.Empty;  //���O�C�����_�R�[�h
        private EstimateDefSet _estimateDefSet;     // ���Ϗ����l�ݒ�}�X�^
        private TaxRateSet _taxRateSet = null;      // �ŗ��ݒ�}�X�^
        private AllDefSet _allDefSet;               // �S�̏����l�ݒ�}�X�^
        private AcptAnOdrTtlSt _acptAnOdrTtlSt;     // �󔭒��S�̊Ǘ��ݒ�}�X�^
        private CompanyInf _companyInf;             // ���Џ��
        private double _taxRate = 0;
        private ArrayList _acptAnOdrTtlStList;      // �󔭒��S�̊Ǘ��ݒ�}�X�^���X�g
        private SalesTtlSt _salesTtlSt;             // ����S�̐ݒ�}�X�^
        private ArrayList _estimateDefSetList;      // ���Ϗ����l�ݒ�}�X�^���X�g
        private ArrayList _salesTtlStList;          // ����S�̐ݒ�}�X�^���X�g
        
        private Dictionary<int, Supplier> _supplierDictionary = null;// �d����}�X�^
        private Dictionary<string, UserGdBd> _userGdBdDictionary = null;// ���[�U�[�K�C�h

        # endregion

		# endregion

		// ===================================================================================== //
		// �萔
		// ===================================================================================== //
		# region Const Members
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif

        /// <summary>���_�R�[�h(�S��)</summary>
        public const string ctSectionCode = "00";
        # endregion

		// ===================================================================================== //
		// �f���Q�[�g
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// �C�x���g
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		# region Properties
        # region ���i�}�X�^ �A�N�Z�X�N���X
        /// <summary>
        /// ���i�}�X�^ �A�N�Z�X�N���X
        /// </summary>
        public GoodsAcs _goodsAcs
        {
            get { return _uoeSndRcvJnlAcs.goodsAcs; }
            set { _uoeSndRcvJnlAcs.goodsAcs = value; }
        }
        # endregion

        /// <summary>�ŗ�</summary>
        public double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }
        # endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		# region Public Methods
        # region �������f�[�^���c�a���擾
        /// <summary>
        /// �����f�[�^���c�a���擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        public void ReadInitData(string enterpriseCode, string sectionCode)
        {
            try
            {
                ArrayList al;
                int status = 0;

                #region ���󔭒��Ǘ��S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                // �󔭒��Ǘ��S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                al = null;
                status = _acptAnOdrTtlStAcs.SearchAll(out al, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (al != null)
                    {
                        this.CacheAcptAnOdrTtlSt(al);
                        this.CacheAcptAnOdrTtlSt(enterpriseCode, sectionCode);
                    }
                }
                #endregion

                #region ������S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                // ����S�̐ݒ�}�X�^
                //-----------------------------------------------------------
                al = null;
                status = _salesTtlStAcs.SearchAll(out al, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (al != null)
                    {
                        this.CacheSalesTtlSt(al);
                        this.CacheSalesTtlSt(enterpriseCode, sectionCode);
                    }
                }
                #endregion

                #region �����Ϗ����l�ݒ�}�X�^
                //-----------------------------------------------------------
                // ���Ϗ����l�ݒ�}�X�^
                //-----------------------------------------------------------
                al = null;
                status = _estimateDefSetAcs.Search(out al, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (al != null)
                    {
                        this.CacheEstimateDefSet(al);
                        this.CacheEstimateDefSet(enterpriseCode, sectionCode);
                    }
                }
                #endregion

                #region ���S�̏����l�ݒ�}�X�^
                //-----------------------------------------------------------
                // �S�̏����l�ݒ�}�X�^
                //-----------------------------------------------------------
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                if (ctIsLocalDBRead == true)
                {
                    allDefSetSearchMode = AllDefSetAcs.SearchMode.Local;
                }
                else
                {
                    allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                }
                ArrayList retAllDefSetList;
                status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���O�C���S���҂̏������_�������͑S�Аݒ���擾
                    this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
                }
                else
                {
                    this._allDefSet = null;
                }
                #endregion

                #region �����Џ��ݒ�}�X�^
                //-----------------------------------------------------------
                // ���Џ��ݒ�}�X�^
                //-----------------------------------------------------------
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
                #endregion

                #region ���ŗ��ݒ�}�X�^
                //-----------------------------------------------------------
                // �ŗ��ݒ�}�X�^
                //-----------------------------------------------------------
                TaxRateSet taxRateSet;
                if (ctIsLocalDBRead == true)
                {
                    status = this._taxRateSetAcs.Search(out al, enterpriseCode, TaxRateSetAcs.SearchMode.Local);
                }
                else
                {
                    status = this._taxRateSetAcs.Search(out al, enterpriseCode, TaxRateSetAcs.SearchMode.Remote);
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        taxRateSet = (TaxRateSet)al[0];
                        this.CacheTaxRateSet(taxRateSet);

                        _taxRate = taxRateSet.TaxRate;

                        DateTime today = DateTime.Today;

                        if ((today > taxRateSet.TaxRateStartDate) &&
                            (today <= taxRateSet.TaxRateEndDate))
                        {
                            _taxRate = taxRateSet.TaxRate;
                        }
                        else if ((today > taxRateSet.TaxRateStartDate2) &&
                            (today <= taxRateSet.TaxRateEndDate2))
                        {
                            _taxRate = taxRateSet.TaxRate2;
                        }
                        else if ((today > taxRateSet.TaxRateStartDate3) &&
                       (today <= taxRateSet.TaxRateEndDate3))
                        {
                            _taxRate = taxRateSet.TaxRate3;
                        }
                        else
                        {
                            //TMsgDisp.Show(
                            //null,
                            //emErrorLevel.ERR_LEVEL_INFO,
                            //ctPGID,
                            //"�ŗ��ݒ�̓��t�͈͓��ɑΏۓ����Y�����܂���B\n�ŗ��ݒ���s���Ă��������B",
                            //status,   
                            //MessageBoxButtons.OK);
                            //break;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        break;
                }
                #endregion

                //-----------------------------------------------------------
                // �d������L���b�V�����䏈��
                //-----------------------------------------------------------
                CacheSupplier();

                //-----------------------------------------------------------
                // ���[�U�[�K�C�h�}�X�^�{�f�B�����X�g�擾����
                //-----------------------------------------------------------
                CacheUserGdBdList();
            }
            finally
            {
            }
        }
        # endregion

        # region �����[�U�[�K�C�h�֘A
        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�{�f�B���L���b�V������
        /// </summary>
        /// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
        private int CacheUserGdBdList()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                _userGdBdDictionary = new Dictionary<string, UserGdBd>();
                ArrayList userGdBdList = null;
                status = this._userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.MergeBodyData);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //_userGdBdListStc.AddRange((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));

                    foreach (UserGdBd userGdBd in userGdBdList)
                    {
                        string keyUserGdB = userGdBd.UserGuideDivCd.ToString("d3") + userGdBd.GuideCode.ToString("d4");

                        if (_userGdBdDictionary.ContainsKey(keyUserGdB) != true)
                        {
                            _userGdBdDictionary.Add(keyUserGdB, userGdBd);
                        }
                    }
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

                _userGdBdDictionary = null;
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�{�f�B���̎擾
        /// </summary>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
        /// <param name="guideCode">�K�C�h�R�[�h</param>
        /// <returns>���[�U�[�K�C�h�}�X�^�{�f�B��</returns>
        public UserGdBd GetUserGdBdList(int userGuideDivCd, int guideCode)
        {
            UserGdBd userGdBd = null;

            try
            {
                string keyUserGdB = userGuideDivCd.ToString("d3") + guideCode.ToString("d4");

                if (_userGdBdDictionary.ContainsKey(keyUserGdB))
                {
                    userGdBd = _userGdBdDictionary[keyUserGdB];
                }
            
            }
            catch (Exception)
            {
                userGdBd = null;
            }
            return userGdBd;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�{�f�B�����̂̎擾
        /// </summary>
        /// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
        /// <param name="guideCode">�K�C�h�R�[�h</param>
        /// <returns>�K�C�h����</returns>
        public string GetUserGdBdString(int userGuideDivCd, int guideCode)
        {
            string userGdBdString = "";

            try
            {
                UserGdBd userGdBd = GetUserGdBdList(userGuideDivCd, guideCode);
                if (userGdBd != null)
                {
                    userGdBdString = userGdBd.GuideName.Trim();
                }
            }
            catch (Exception)
            {
                userGdBdString = "";
            }
            return userGdBdString;
        }
        # endregion

        # region ���d������L���b�V�����䏈��
        /// <summary>
        /// �d������L���b�V�����䏈��
        /// </summary>
        public void CacheSupplier()
        {
            try
            {
                ArrayList retList = null;

                int status = _supplierAcs.Search(out retList, _enterpriseCode);
                if (status != 0) return;

                _supplierDictionary = new Dictionary<int, Supplier>();
                foreach (Supplier supplier in retList)
                {
                    if (_supplierDictionary.ContainsKey(supplier.SupplierCd) != true)
                    {
                        _supplierDictionary.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            catch (ConstraintException)
            {
                _supplierDictionary = null;
            }
        }

        /// <summary>
        /// �d����N���X�擾
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <returns>�d����N���X</returns>
        public Supplier GetSupplier(int supplierCd)
        {
            Supplier supplier = null;
            try
            {
                if (_supplierDictionary.ContainsKey(supplierCd))
                {
                    supplier = _supplierDictionary[supplierCd];
                }
            }
            catch (ConstraintException)
            {
                supplier = null;
            }
            return supplier;
        }

        /// <summary>
        /// �d���摶�݃`�F�b�N
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        public bool SupplierExists(int supplierCd)
        {
            Supplier supplier = GetSupplier(supplierCd);
            return (supplier != null);
        }
        # endregion

        # region ���󔭒��Ǘ��S�̐ݒ�}�X�^�L���b�V�����䏈��
        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�}�X�^���X�g�L���b�V��
        /// </summary>
        /// <param name="acptAnOdrTtlStList"></param>
        internal void CacheAcptAnOdrTtlSt(ArrayList acptAnOdrTtlStList)
        {
            this._acptAnOdrTtlStList = acptAnOdrTtlStList;
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        internal void CacheAcptAnOdrTtlSt(string enterpriseCode, string sectionCode)
        {
            if (_acptAnOdrTtlStList != null)
            {
                // �w���ƃR�[�h�����_�R�[�h�ň�v
                foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in _acptAnOdrTtlStList)
                {
                    if ((acptAnOdrTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                        (acptAnOdrTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                    {
                        this._acptAnOdrTtlSt = acptAnOdrTtlSt;
                        return;
                    }
                }
                // �w��R�[�h�ň�v���Ȃ��ꍇ�A�S�̐ݒ�L���b�V��
                foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in _acptAnOdrTtlStList)
                {
                    if ((acptAnOdrTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                        (acptAnOdrTtlSt.SectionCode.Trim() == ctSectionCode.Trim()))
                    {
                        this._acptAnOdrTtlSt = acptAnOdrTtlSt;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// �󔭒��Ǘ��S�̐ݒ�}�X�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <returns></returns>
        public AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
        {
            return this._acptAnOdrTtlSt;
        }
        # endregion

        # region ������S�̐ݒ�}�X�^�L���b�V�����䏈��
        /// <summary>
        /// ����S�̐ݒ�}�X�^���X�g�L���b�V��
        /// </summary>
        /// <param name="salesTtlStList"></param>
        internal void CacheSalesTtlSt(ArrayList salesTtlStList)
        {
            this._salesTtlStList = salesTtlStList;
        }

        /// <summary>
        /// ����S�̐ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheSalesTtlSt(string enterpriseCode, string sectionCode)
        {
            if (_salesTtlStList != null)
            {
                // �w���ƃR�[�h�����_�R�[�h�ň�v
                foreach (SalesTtlSt salesTtlSt in _salesTtlStList)
                {
                    if ((salesTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                        (salesTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                    {
                        this._salesTtlSt = salesTtlSt;
                        return;
                    }
                }
                // �w��R�[�h�ň�v���Ȃ��ꍇ�A�S�̐ݒ�L���b�V��
                foreach (SalesTtlSt salesTtlSt in _salesTtlStList)
                {
                    if ((salesTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                        (salesTtlSt.SectionCode.Trim() == ctSectionCode.Trim()))
                    {
                        this._salesTtlSt = salesTtlSt;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ����S�̐ݒ�}�X�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <returns></returns>
        public SalesTtlSt GetSalesTtlSt()
        {
            return this._salesTtlSt;
        }
        # endregion

        # region �����Ϗ����l�ݒ�}�X�^�L���b�V�����䏈��
        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^���X�g�L���b�V��
        /// </summary>
        /// <param name="estimateDefSetList"></param>
        internal void CacheEstimateDefSet(ArrayList estimateDefSetList)
        {
            this._estimateDefSetList = estimateDefSetList;
        }

        /// <summary>
        /// ���Ϗ����l�ݒ�}�X�^�L���b�V��
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheEstimateDefSet(string enterpriseCode, string sectionCode)
        {
            if (_estimateDefSetList != null)
            {
                // �w���ƃR�[�h�����_�R�[�h�ň�v
                foreach (EstimateDefSet estimateDefSet in _estimateDefSetList)
                {
                    if ((estimateDefSet.EnterpriseCode.Trim() == enterpriseCode) &&
                        (estimateDefSet.SectionCode.Trim() == sectionCode))
                    {
                        this._estimateDefSet = estimateDefSet;
                        return;
                    }
                }
                // �w��R�[�h�ň�v���Ȃ��ꍇ�A�S�̐ݒ�L���b�V��
                foreach (EstimateDefSet estimateDefSet in _estimateDefSetList)
                {
                    if ((estimateDefSet.EnterpriseCode.Trim() == enterpriseCode) &&
                        (estimateDefSet.SectionCode.Trim() == ctSectionCode))
                    {
                        this._estimateDefSet = estimateDefSet;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���Ϗ����l�ݒ�}�X  �^�擾����
        /// </summary>
        /// <returns></returns>
        public EstimateDefSet GetEstimateDefSet()
        {
            return this._estimateDefSet;
        }
        # endregion

        # region ���S�̏����l�ݒ�}�X�^�L���b�V�����䏈��
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            AllDefSet allSecAllDefSet = null;

            foreach (AllDefSet allDefSet in allDefSetArrayList)
            {
                if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
                {
                    return allDefSet;
                }
                else if (allDefSet.SectionCode.Trim() == ctSectionCode.Trim())
                {
                    allSecAllDefSet = allDefSet;
                }
            }

            return allSecAllDefSet;
        }

        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�擾����
        /// </summary>
        /// <returns></returns>
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }
        # endregion

        # region ���ŗ��ݒ�}�X�^�L���b�V�����䏈��
        /// <summary>
        /// �ŗ��ݒ�}�X�^�L���b�V������
        /// </summary>
        /// <param name="taxRateSetWork">�ŗ��ݒ�}�X�^���[�N�N���X</param>
        internal void CacheTaxRateSet(TaxRateSet taxRateSet)
        {
#if False
            try
            {
                this._taxRateSet = taxRateSet;
                _dataSet.TaxRateSet.AddTaxRateSetRow(this.RowFromUIData(taxRateSet));
            }
            catch (ConstraintException)
            {
                SalesInputInitialDataSet.TaxRateSetRow row = this._dataSet.TaxRateSet.FindByTaxRateCode(taxRateSet.TaxRateCode);
                this.SetRowFromUIData(ref row, taxRateSet);
            }
#endif
        }


        /// <summary>
        /// �ŗ��ݒ�}�X�^�擾����
        /// </summary>
        /// <returns></returns>
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }

        # endregion

        # region ���i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// <summary>
        /// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <param name="list">�������ʃN���X</param>
        /// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, UOESupplier uOESupplier, out List<GoodsUnitData> list)
        {
            List<Int32> makerCdList = GetMakerCdList(uOESupplier);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, true));
        }
        /// <summary>
        /// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <param name="list">�������ʃN���X</param>
        /// <param name="samePartsNoWindowDiv">����i�ԑI������E�Ȃ�</param>
        /// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, UOESupplier uOESupplier, out List<GoodsUnitData> list, bool samePartsNoWindowDiv)
        {
            List<Int32> makerCdList = GetMakerCdList(uOESupplier);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, samePartsNoWindowDiv));
        }

        /// <summary>
        /// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <param name="list">�������ʃN���X</param>
        /// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, int uOESupplierCd, out List<GoodsUnitData> list)
        {
            UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uOESupplierCd);
            List<Int32> makerCdList = GetMakerCdList(uOESupplier);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, true));
        }
        /// <summary>
        /// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <param name="list">�������ʃN���X</param>
        /// <param name="samePartsNoWindowDiv">����i�ԑI������E�Ȃ�</param>
        /// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, int uOESupplierCd, out List<GoodsUnitData> list, bool samePartsNoWindowDiv)
        {
            UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uOESupplierCd);
            List<Int32> makerCdList = GetMakerCdList(uOESupplier);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, samePartsNoWindowDiv));
        }

        // ------ ADD START 2014/09/19 ���� FOR Redmine#43265 ------>>>>>
        /// <summary>
        /// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <param name="uOESupplier">UOE������I�u�W�F�N�g</param>
        /// <param name="list">�������ʃN���X</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, UOESupplier uOESupplier, out List<GoodsUnitData> list, int goodsMakerCd)
        {
            List<Int32> makerCdList = new List<int>();
            makerCdList.Add(goodsMakerCd);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, true));
        }
        // ------ ADD END 2014/09/19 ���� FOR Redmine#43265 ------<<<<<
        # endregion

        /// <summary>
        /// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="list">�������ʃN���X</param>
        /// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
        public int SearchPartsFromGoodsNoForMstInf(int goodsMakerCd, string goodsNo, out List<GoodsUnitData> list)
        {
            string msg = "";
            int status = 0;
            list = null;

            try
            {
                GoodsCndtn cndtn = new GoodsCndtn();

                cndtn.EnterpriseCode = _enterpriseCode;
                cndtn.SectionCode = _loginSectionCd;
                cndtn.GoodsNo = goodsNo;
                cndtn.GoodsMakerCd = goodsMakerCd;

                status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out list, out msg);
            }
            catch (ConstraintException)
            {
                status = -1;
            }
            return (status);
        }

        /// <summary>
        /// ���[�J�[���擾
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="makerUMnt">���[�J�[���N���X</param>
        /// <returns>0:����I�� 0�ȊO:�G���[�I��</returns>
        public int GetMakerInf(int makerCode, out MakerUMnt makerUMnt)
        {
            int status = 0;
            makerUMnt = null;   

            try
            {
                status = _goodsAcs.GetMaker(_enterpriseCode, makerCode, out makerUMnt);
            }
            catch (ConstraintException)
            {
                status = -1;
            }
            return (status);
        }

        // ------ ADD START 2014/09/19 ���� FOR Redmine#43265 ------>>>>>
        /// <summary>
        /// �����Ώۃ��[�J�[���X�g�̎擾
        /// </summary>
        /// <param name="uOESupplier">�t�n�d������N���X</param>
        /// <returns>�����Ώۃ��[�J�[���X�g</returns>
        public List<Int32> GetMakerCdLt(UOESupplier uOESupplier)
        {
            return GetMakerCdList(uOESupplier);
        }
        // ------ ADD END 2014/09/19 ���� FOR Redmine#43265 ------<<<<<
        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �����Ώۃ��[�J�[���X�g�̎擾
        /// <summary>
        /// �����Ώۃ��[�J�[���X�g�̎擾
        /// </summary>
        /// <param name="uOESupplier">1�t�n�d������N���X</param>
        /// <returns>�����Ώۃ��[�J�[���X�g</returns>
        private List<Int32> GetMakerCdList(UOESupplier uOESupplier)
        {
            List<Int32> makerCdList = new List<int>();

            try
            {
                makerCdList.Clear();
                int enableOdrMakerCd = 0;
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd1;
                            break;
                        case 1:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd2;
                            break;
                        case 2:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd3;
                            break;
                        case 3:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd4;
                            break;
                        case 4:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd5;
                            break;
                        case 5:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd6;
                            break;
                    }
                    if (enableOdrMakerCd == 0) continue;
                    makerCdList.Add(enableOdrMakerCd);
                }
            }
            catch (Exception)
            {
                makerCdList = null;
            }

            return (makerCdList);
        }
        # endregion

        # region �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// <summary>
        /// �i�Ԍ��� ������������(�}�X�����p)(���[�U�[�{��)
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <param name="makerCdList">�����Ώۂ̃��[�J�[�R�[�h���X�g</param>
        /// <param name="list">�������ʃN���X</param>
        /// <param name="samePartsNoWindowDiv">����i�ԑI������E�Ȃ�</param>
        /// <returns>0:�Y������ -1:�I���Ȃ� 1:�Y���Ȃ�</returns>
        private int SearchPartsFromGoodsNoForMstInf(string goodsNo, List<Int32> makerCdList, out List<GoodsUnitData> list, bool samePartsNoWindowDiv)
        {
            string msg = "";
            int status = 0;
            list = null;

            try
            {
                GoodsCndtn cndtn = new GoodsCndtn();

                cndtn.EnterpriseCode = this._enterpriseCode;
                cndtn.SectionCode = this._loginSectionCd;
                cndtn.GoodsNo = goodsNo;

                int serchMode = 0;
                if (makerCdList != null)
                {
                    if (makerCdList.Count != 0)
                    {
                        serchMode = 1;
                    }
                }

                if (serchMode == 0)
                {
                    status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, true, out list, out msg);
                }
                else
                {
                    status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, true, makerCdList, out list, out msg);
                }
            }
            catch (ConstraintException)
            {
                status = -1;
            }
            return (status);
        }
        # endregion

        # endregion
	}
}
