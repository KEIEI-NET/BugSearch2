//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������}�X�^�A�N�Z�X�N���X
// �v���O�����T�v   : ���������}�X�^�@���i�Z�o���s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 �������q
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/25  �C�����e : ���[�J�[���i�擾���@�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/03/26  �C�����e : �i��Redmine#3247
//                                  PM���i�}�X�^(���[�U�[�o�^)����擾�������[�J�[���i�ɑ΂��ė����ݒ肪���f�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �X �V ��  2015/04/01  �C�����e : �V�X�e���e�X�g��Q ��62
//                                  �񋟕i�Ԃ����i�݌Ƀ}�X�^�ɓo�^���A���i���폜����ƃ��[�J�[���i���\������Ȃ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Library.Resources;
// --- ADD 2015/03/25 Y.Wakita ---------->>>>>
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
// --- ADD 2015/03/25 Y.Wakita ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�Z�o�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Z�o���s���܂��B</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class Calculator
    {
        #region public const
        /// <summary>�������[�J�[�ő�R�[�h</summary>
        public const int PURE_GOODS_MAKER_CODE_MAX = 1000;
        /// <summary>�[�������Ώۋ��z�敪�i������z�j</summary>
        public const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        public const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        /// <summary>�[�������Ώۋ��z�敪�i�����P���j</summary>
        public const int ctFracProcMoneyDiv_SalesUnitCost = 2;
        /// <summary>�[�������Ώۋ��z�敪�i�������z�j</summary>
        public const int ctFracProcMoneyDiv_Cost = 0;
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif

        #endregion

        #region Private Members

        /// <summary>�P���Z�o�N���X</summary>
        private UnitPriceCalculation _unitPriceCalculation; 
        /// <summary>���Аݒ�}�X�^</summary>
        private CompanyInf _companyInf;
        /// <summary>���Ӑ�}�X�^�A�N�Z�X�N���X</summary>
        private CustomerInfoAcs _customerInfoAcs;
        /// <summary>�d����}�X�^�̃A�N�Z�T</summary>
        private SupplierAcs _supplierAcs;
        /// <summary>����S�̐ݒ�}�X�^�̃A�N�Z�T</summary>
        private SalesTtlStAgent _salesTtlStAgent;
        /// <summary>�L�����y�[���Ώۏ��i�ݒ�A�N�Z�X�N���X</summary>
        private CampaignObjGoodsStAcs _campaignObjGoodsStAcs;
        /// <summary>���Ӑ�|���O���[�v�}�X�^�A�N�Z�X�N���X</summary>
        private CustRateGroupAcs _custRateGroupAcs;
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>���Ӑ�|���O���[�v���X�g</summary>
        private List<CustRateGroup> _custRateGroupList;
        /// <summary>�ŗ��ݒ���</summary>
        private TaxRateSet _taxRateSet;
        /// <summary>�L�����y�[���Ώۏ��i�ݒ�}�X�^</summary>
        private CampaignObjGoodsSt _campaignObjGoodsSt;
        /// <summary>���Ӑ���</summary>
        private CustomerInfo _customerInfo;
        /// <summary>������z�[�������敪���X�g</summary>
        private List<SalesProcMoney> _salesProcMoneyList = null;
        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
        /// <summary>MAKHN04112A)BL�R�[�h�E�i�Ԍ���</summary>
        private GoodsAcs _goodsAcs;
        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
        #endregion

        #region Construcstor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public Calculator()
        {
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._salesTtlStAgent = new SalesTtlStAgent();
            this._custRateGroupAcs = new CustRateGroupAcs();
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            this._goodsAcs = new GoodsAcs();
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
        }
        #endregion

        #region Property
        #endregion

        #region Public Method

        #region Ұ����]�������i�A�艿�A�����̎擾
        /// <summary>
        ///  ���i�����Ұ����]�������i�A�艿�A�������擾���܂�
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsUnitData">���i���</param>
        /// <param name="startDate">�J�n��</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="mkrSuggestRtPric">Ұ����]�������i</param>
        /// <param name="listPrice">�艿</param>
        /// <param name="unitPrice">����</param>
        /// <returns></returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //public void GetUnitPrice(
        //    int customerCode,
        //    GoodsUnitData goodsUnitData,
        //    DateTime startDate,
        //    string sectionCode,
        //    out long mkrSuggestRtPric,
        //    out long listPrice,
        //    out long unitPrice
        public void GetUnitPrice(
            int customerCode,
            GoodsUnitData goodsUnitData,
            DateTime startDate,
            string sectionCode,
            Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList,
            out bool uPricDiv,  // ADD 2015/03/26 Y.Wakita
            out long mkrSuggestRtPric,
            out long listPrice,
            out long unitPrice
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        )
        {
            List<UnitPriceCalcRet> unitPriceList = null;
            mkrSuggestRtPric = 0;
            listPrice = 0;
            unitPrice = 0;
            uPricDiv = false;   // ADD 2015/03/26 Y.Wakita

            #region <Guard Phrase>

            //// ���Ӑ��񂪃[���̎��͏����I��
            //if (customerCode == 0) return;
            // ���i��񂪋�̎��͏����I��
            if (goodsUnitData == null) return;
            // �J�n���������l�̎��͏����I��
            if (startDate == DateTime.MinValue) return;

            #endregion // </Guard Phrase>

            {
                // ���i�Z�o�p�����[�^�ݒ�
                UnitPriceCalcParam condition = new UnitPriceCalcParam();
                {
                    condition.BLGoodsCode = goodsUnitData.BLGoodsCode;  // BL�R�[�h 
                    condition.BLGoodsName = goodsUnitData.BLGoodsName;  // BL�R�[�h����
                    condition.BLGroupCode = goodsUnitData.BLGroupCode;  // BL�O���[�v�R�[�h
                    condition.CountFl = 1;                              // ����
                    condition.CustomerCode = customerCode;              // ���Ӑ�R�[�h

                    // ���Ӑ���擾
                    if (customerCode != 0)
                    {
                        GetCustomerInfo(customerCode);
                    }

                    // ������z�����敪���X�g�擾
                    GetSalesProcMoney();

                    // ���Ӑ�|���O���[�v�R�[�h
                    condition.CustRateGrpCode = this.GetCustomerRateGroupCode(
                        this._enterpriseCode,
                        customerCode,
                        goodsUnitData.GoodsMakerCd
                    );

                    condition.GoodsMakerCd = goodsUnitData.GoodsMakerCd;            // ���[�J�[�R�[�h
                    condition.GoodsNo = goodsUnitData.GoodsNo;                      // �i��
                    condition.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;    // ���i�|���O���[�v�R�[�h
                    condition.GoodsRateRank = goodsUnitData.GoodsRateRank;          // ���i�|�������N

                    condition.PriceApplyDate = startDate;                           // �K�p��

                    // �������Œ[�������R�[�h
                    condition.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
                    // ����P���[�������R�[�h
                    condition.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);

                    condition.SectionCode = sectionCode;                            // ���_�R�[�h

                    // �d������Œ[�������R�[�h
                    condition.StockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                    // �d���P���[�������R�[�h
                    condition.StockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);

                    condition.SupplierCd = goodsUnitData.SupplierCd;                // �d����R�[�h
                    condition.TaxationDivCd = goodsUnitData.TaxationDivCd;          // �ېŋ敪
                    condition.TaxRate = this.GetTaxRate(startDate);                 // �ŗ�

                    // ��������擾
                    CustomerInfo claim = ClaimInfo(customerCode);
                    if (claim != null)
                    {
                        // ������擾���͐�������̏���œ]�ŕ�����ݒ肷��
                        condition.ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? this._taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                    }
                    else
                    {
                        // �����悪�擾�ł��Ȃ��ꍇ�́A�ŗ��ݒ�}�X�^�̏���œ]�ŕ�����ݒ�
                        condition.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
                    }

                    condition.TotalAmountDispWayCd = 0; // ���z�\�����@�敪
                    condition.TtlAmntDspRateDivCd = 0;  // ���z�\���|���K�p�敪 0:(�ō����z�~�|��) 1:(�Ŕ����z�~�|��)�������ł����ߍ��Z(����ŎZ�o������ł̒[������������)
                }

                this._unitPriceCalculation.RatePriorityDiv = GetCompanyInf(this._enterpriseCode).RatePriorityDiv; //���Аݒ襊|���D�揇��
                
                this._unitPriceCalculation.CacheSalesProcMoneyList(this._salesProcMoneyList); // ������z�����敪���X�g�L���b�V��

                // �P���v�Z
                this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(condition, goodsUnitData, out unitPriceList);

                // �P���v�Z�̌��ʂ��߂�l��ݒ�
                if (unitPriceList != null && unitPriceList.Count != 0)
                {
                    // --- DEL 2015/04/01 Y.Wakita �V�X�e���e�X�g��Q ��62 ---------->>>>>
                    //// Ұ����]�������i�擾
                    //// --- UPD 2015/03/26 Y.Wakita ---------->>>>>
                    ////// --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                    //////mkrSuggestRtPric = this.GetmkrSuggestRtPric(startDate, goodsUnitData);
                    ////mkrSuggestRtPric = this.GetmkrSuggestRtPric(startDate, goodsUnitData, mkrSuggestRtPricList, mkrSuggestRtPricUList);
                    ////// --- UPD 2015/03/25 Y.Wakita ----------<<<<<
                    //mkrSuggestRtPric = this.GetmkrSuggestRtPric(out uPricDiv, startDate, goodsUnitData, mkrSuggestRtPricList, mkrSuggestRtPricUList);
                    // --- UPD 2015/03/26 Y.Wakita ---------->>>>>
                    // --- DEL 2015/04/01 Y.Wakita �V�X�e���e�X�g��Q ��62 ----------<<<<<
                    // �艿�擾
                    listPrice = (long)this.GetListPrice(unitPriceList);
                    // �����擾
                    unitPrice = (long)this.GetUnitPrice(unitPriceList, goodsUnitData, customerCode, startDate, condition, sectionCode);
                }

                // --- ADD 2015/04/01 Y.Wakita �V�X�e���e�X�g��Q ��62 ---------->>>>>
                // Ұ����]�������i�擾
                mkrSuggestRtPric = this.GetmkrSuggestRtPric(out uPricDiv, startDate, goodsUnitData, mkrSuggestRtPricList, mkrSuggestRtPricUList);
                // --- ADD 2015/04/01 Y.Wakita �V�X�e���e�X�g��Q ��62 ----------<<<<<
            }
        }
        #endregion

        #endregion

        #region Private Method

        #region ���Аݒ�}�X�^
        /// <summary>
        ///  ���Аݒ�}�X�^�擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private CompanyInf GetCompanyInf(string enterpriseCode)
        {
            if (_companyInf == null)
            {
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
            }
            return _companyInf;
        }
        #endregion

        #region ���Ӑ�}�X�^
        /// <summary>
        ///  ���Ӑ�}�X�^�擾
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private void GetCustomerInfo(int customerCode)
        {
            if (this._customerInfo == null)
            {
                this._customerInfo = new CustomerInfo();
            }

            this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, out this._customerInfo);
        }
        #endregion

        #region ���Ӑ�|���O���[�v
        /// <summary>
        /// ���Ӑ�|���O���[�v���擾���܂��B
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v</returns>
        private List<CustRateGroup> GetCustomerRateGroupList(
            string enterpriseCode,
            int customerCode
        )
        {
            if (this._custRateGroupList == null)
            {
                if (customerCode != 0)
                {
                    ArrayList custRateGroupList;
                    this._custRateGroupAcs.Search(out custRateGroupList, this._enterpriseCode, customerCode, ConstantManagement.LogicalMode.GetData0);
                    if ((custRateGroupList != null) && (custRateGroupList.Count != 0))
                    {
                        this._custRateGroupList = new List<CustRateGroup>((CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
                    }
                    else
                    {
                        this._custRateGroupList = new List<CustRateGroup>();
                    }
                }
                else
                {
                    this._custRateGroupList = new List<CustRateGroup>();
                }
            }
            return this._custRateGroupList;
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�R�[�h�擾����
        /// </summary>
        /// <remarks>
        /// MAHNB01012AB.cs l.9693 SalesSlipInputAcs.GetCustRateGroupCode() ���Q�l<br/>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v�R�[�h</returns>
        private int GetCustomerRateGroupCode(
            string enterpriseCode,
            int customerCode,
            int goodsMakerCode
        )
        {
            int pureCode = (goodsMakerCode <= PURE_GOODS_MAKER_CODE_MAX ? 0 : 1);    // 0:���� 1:�D��

            // �P�ƃL�[
            CustRateGroup foundCustomerRateGroup = GetCustomerRateGroupList(enterpriseCode, customerCode).Find(
                delegate(CustRateGroup customerRateGroup)
                {
                    return customerRateGroup.GoodsMakerCd.Equals(goodsMakerCode) && customerRateGroup.PureCode.Equals(pureCode);
                }
            );
            if (foundCustomerRateGroup != null) return foundCustomerRateGroup.CustRateGrpCode;

            // ���ʃL�[
            foundCustomerRateGroup = GetCustomerRateGroupList(enterpriseCode, customerCode).Find(
                delegate(CustRateGroup customerRateGroup)
                {
                    return customerRateGroup.GoodsMakerCd.Equals(0) && customerRateGroup.PureCode.Equals(pureCode);
                }
            );
            if (foundCustomerRateGroup != null) return foundCustomerRateGroup.CustRateGrpCode;
            return -1;
        }
        #endregion

        #region ������
        /// <summary>
        /// ��������̎擾
        /// �@���Ӑ�R�[�h���琿��������擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�������� �擾�ł��Ȃ��ꍇ��null</returns>
        private CustomerInfo ClaimInfo(int customerCode)
        {
            CustomerInfo claim = null;

            if (this._customerInfo != null)
            {
                if (this._customerInfo.CustomerCode.Equals(this._customerInfo.ClaimCode))
                {
                    // ���Ӑ�Ɛ����悪�����ꍇ
                    claim = this._customerInfo.Clone();
                }
                else
                {
                    // �������񂪎擾����Ă��Ȃ��ꍇ
                    this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,  this._customerInfo.ClaimCode, out claim);
                }
            }

            return claim;
        }
        #endregion

        #region �ŗ��ݒ�}�X�^
        /// <summary>
        /// �ŗ��ݒ�����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�ŗ�</returns>
        private void GetTaxRateSet(string enterpriseCode)
        {
            TaxRateSet taxRateSet = null;
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);

                this._taxRateSet = new TaxRateSet();
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._taxRateSet = taxRateSet;
                }
            }
        }
        
        /// <summary>
        /// �ŗ����擾���܂��B
        /// </summary>
        /// <param name="taxRateDate">�ŗ����</param>
        /// <returns>�ŗ�</returns>
        private double GetTaxRate(DateTime taxRateDate)
        {
            double taxRate = 0;

            if (this._taxRateSet == null)
            {
                this.GetTaxRateSet(this._enterpriseCode);
            }
            if (taxRateDate != DateTime.MinValue)
            {
                taxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, taxRateDate);
            }
            return taxRate;
        }
        #endregion

        #region ������z�����敪�ݒ�}�X�^
        /// <summary>
        ///  ������z�[�������敪���X�g�擾
        /// </summary>
        private void GetSalesProcMoney()
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            salesProcMoneyAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesProcMoneyAcs.Search(out aList, this._enterpriseCode);
            this._salesProcMoneyList = new List<SalesProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }
        }
        #endregion

        #region �L�����y�[�����i�ݒ�
        /// <summary>
        /// �L�����y�[���K�p����
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="blGroupCode"> BL�O���[�v�R�[�h</param>
        /// <param name="salesCode">�̔��敪</param>
        /// <param name="applyDate">���i�K�p��</param>
        /// <param name="price">�Ώۋ��z</param>
        private void ReflectCampaign(int taxationCode, int customerCode, int blGoodsCode, int goodsMakerCd, string goodsNo, int blGroupCode, int salesCode, DateTime applyDate, string sectionCode)
        {
            this._campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();

            CampaignObjGoodsSt campaignObjGoodsSt;
            this._campaignObjGoodsStAcs.GetRatePriceOfCampaignMng(out campaignObjGoodsSt, this._enterpriseCode, sectionCode.Trim(), customerCode, goodsMakerCd, blGroupCode, blGoodsCode, salesCode, goodsNo, applyDate);
            this._campaignObjGoodsSt = campaignObjGoodsSt;

            this._campaignObjGoodsStAcs = null;

            if (campaignObjGoodsSt == null) return;
        }
        #endregion

        #region Ұ����]�������i
        /// <summary>
        /// ���i��񂩂�Ұ����]�������i���擾���܂�
        /// </summary>
        /// <param name="targetDay">�Ώۓ�</param>
        /// <param name="GoodsUnitData">���i���</param>
        /// <param name="goodsPrice">���i���I�u�W�F�N�g</param>
        /// <returns></returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //private long GetmkrSuggestRtPric(DateTime targetDay, GoodsUnitData goodsUnitData)
        private long GetmkrSuggestRtPric(
            out bool uPricDiv,   // ADD 2015/03/26 Y.Wakita
            DateTime targetDay, 
            GoodsUnitData goodsUnitData,
            Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {
            long mkrSuggestRtPric = 0;
            uPricDiv = false;   // ADD 2015/03/26 Y.Wakita

            // --- DEL 2015/03/25 Y.Wakita ---------->>>>>
            #region �폜
            //GoodsPrice goodsPrice = null;

            //#region <Guard Phrase>
            //// ���i����Ұ����]�������i��񃊃X�g�����݂��Ȃ����̓[��
            //if ((goodsUnitData == null) || (goodsUnitData.MkrSuggestRtPricList == null)) return mkrSuggestRtPric;
            //#endregion

            //List<GoodsPrice> goodsPriceList = goodsUnitData.MkrSuggestRtPricList;
            //DateTime dateWk = DateTime.MinValue;
            
            //foreach (GoodsPrice goodsPriceWk in goodsPriceList)
            //{
            //    if ((goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk))
            //    {
            //        dateWk = goodsPriceWk.PriceStartDate;
            //        goodsPrice = goodsPriceWk.Clone();
            //    }
            //}
            //if (goodsPrice != null)
            //{
            //    mkrSuggestRtPric = (long)goodsPrice.ListPrice;
            //}
            #endregion
            // --- DEL 2015/03/25 Y.Wakita ----------<<<<<

            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            long listPrice = 0;
            if (mkrSuggestRtPricList != null && mkrSuggestRtPricList.Count != 0)
            {
                // ���[�J�[��]�������i�擾
                GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
                if (mkrSuggestRtPricList.ContainsKey(goodsInfoKey))
                {
                    // ���[�J�[��]�������i���X�g������ɊY�����鉿�i���擾
                    List<GoodsPrice> _mkrSuggestRtPricList = mkrSuggestRtPricList[goodsInfoKey];
                    // �񋟃f�[�^�̉��i��񂪂Ȃ����[�U�[�o�^�i�Ԃ̎��A�񋟃f�[�^���Ď擾����
                    if ((mkrSuggestRtPricList == null || mkrSuggestRtPricList.Count == 0) && IsUserRegistAtOfferKubun(goodsUnitData))
                    {
                        this.GetOfferGoodsPrice(goodsUnitData, out _mkrSuggestRtPricList);
                    }
                    object obj = null;
                    if (mkrSuggestRtPricList != null && mkrSuggestRtPricList.Count != 0)
                    {
                        obj = this.GetGoodsPrice(targetDay, _mkrSuggestRtPricList);
                    }
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        // �擾�������i��񂪃I�[�v�����i�̎��A���[�J�[��]�������i���X�g�i���[�U�[�o�^���j�̉��i�����擾����
                        if (goodsPrice.OpenPriceDiv == 1)
                        {
                            if (mkrSuggestRtPricUList.ContainsKey(goodsInfoKey))
                            {
                                _mkrSuggestRtPricList = mkrSuggestRtPricUList[goodsInfoKey];
                                object objU = null;
                                if (_mkrSuggestRtPricList != null && _mkrSuggestRtPricList.Count != 0)
                                {
                                    objU = this.GetGoodsPrice(targetDay, _mkrSuggestRtPricList);
                                }
                                if ((objU != null) && (objU is GoodsPrice))
                                {
                                    GoodsPrice goodsPriceU = (GoodsPrice)objU;
                                    listPrice = (long)goodsPriceU.ListPrice;
                                    uPricDiv = true;    // ADD 2015/03/26 Y.Wakita
                                }
                            }
                        }
                        else
                        {
                            listPrice = (long)goodsPrice.ListPrice;
                        }
                    }
                    else
                    {
                        // �p�i�̎��A���[�J�[��]�������i���X�g�i���[�U�[�o�^���j�̉��i�����擾����
                        if (mkrSuggestRtPricUList.ContainsKey(goodsInfoKey))
                        {
                            _mkrSuggestRtPricList = mkrSuggestRtPricUList[goodsInfoKey];
                            object objU = null;
                            if (_mkrSuggestRtPricList != null && _mkrSuggestRtPricList.Count != 0)
                            {
                                objU = this.GetGoodsPrice(targetDay, _mkrSuggestRtPricList);
                            }
                            if ((objU != null) && (objU is GoodsPrice))
                            {
                                GoodsPrice goodsPriceU = (GoodsPrice)objU;
                                listPrice = (long)goodsPriceU.ListPrice;
                                uPricDiv = true;    // ADD 2015/03/26 Y.Wakita
                            }
                        }
                    }
                    mkrSuggestRtPric = listPrice; // ���[�J�[��]�������i
                }
            }
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            return mkrSuggestRtPric;
        }
        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
        /// <summary>�񋟕��i�����R���g���[���[</summary>
        private static IOfferPartsInfo _iOfferPartsInfo;

        /// <summary>
        ///  �񋟋敪�����[�U�[�o�^�̒񋟃f�[�^�����肵�܂�
        /// </summary>
        /// <param name="goodsUnitData">���i���</param>
        /// <returns>true:���[�U�[�o�^�̒񋟃f�[�^ false:�񋟃f�[�^�E���[�U�[�o�^�̂�</returns>
        private bool IsUserRegistAtOfferKubun(GoodsUnitData goodsUnitData)
        {
            if (goodsUnitData == null) return false;

            switch (goodsUnitData.OfferKubun)
            {
                case 0:                 // ���[�U�[�o�^
                    {
                        // 0:���[�U�[�o�^
                        if (goodsUnitData.OfferDataDiv == 0)
                        {
                            return false;
                        }
                        // 1:�񋟃f�[�^
                        else if (goodsUnitData.OfferDataDiv == 1)
                        {
                            return true;
                        }
                        return false;
                    }
                case 1: return true;    // 1:�񋟏����ҏW
                case 2: return true;    // 2:�񋟗D�ǕҏW
                case 3: return false;   // 3:�񋟏���
                case 4: return false;   // 4:�񋟗D��
                case 5: return false;   // 5:TBO
                case 7: return false;   // 7:�I���W�i�����i
                default:
                    return false;
            }
        }
        /// <summary>
        /// �񋟃f�[�^���i���擾
        /// </summary>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns></returns>
        public void GetOfrPriceDataList(
            PartsInfoDataSet partsInfoDataSet,
            List<GoodsUnitData> goodsUnitDataList, 
            out Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            out Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList)
        {
            this.GetOfrPriceDataListProc(partsInfoDataSet, goodsUnitDataList, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, false);
        }

        /// <summary>
        /// �񋟃f�[�^���i���擾
        /// </summary>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">�X�V�t���O</param>
        /// <returns></returns>
        private void GetOfrPriceDataListProc(
            PartsInfoDataSet partsInfoDataSet, 
            List<GoodsUnitData> goodsUnitDataList, 
            out Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList, 
            out Dictionary<GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList, 
            bool isUpdate)
        {
            GoodsInfoKey goodsInfoKey;
            List<GoodsPrice> _mkrSuggestRtPricUList = null;
            List<GoodsPrice> _mkrSuggestRtPricList = null;

            mkrSuggestRtPricList = new Dictionary<GoodsInfoKey, List<GoodsPrice>>();  // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή�
            mkrSuggestRtPricUList = new Dictionary<GoodsInfoKey, List<GoodsPrice>>();  // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή�

            if (partsInfoDataSet == null || goodsUnitDataList == null || goodsUnitDataList.Count <= 0)
            {
                // �p�����[�^�s���̂��ߏI��
                return;
            }

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // �����L�[�쐬
                goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);

                // ���[�J�[��]�������i���쐬
                PartsInfoDataSet.UsrGoodsPriceRow[] usrGoodsPriceRows =
                    (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfoDataSet.UsrGoodsPrice.Select(
                        string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                        goodsUnitData.GoodsMakerCd,
                        goodsUnitData.GoodsNo));

                // �񋟃f�[�^���i���f�[�^�e�[�u�����牿�i�ꗗ���쐬
                _mkrSuggestRtPricUList = GetGoodsPriceList(usrGoodsPriceRows);

                // ���[�J�[��]�������i���i���[�U�[�o�^���j�o�^�ς݃`�F�b�N
                if (mkrSuggestRtPricUList.ContainsKey(goodsInfoKey))
                {
                    // �o�^�ς�
                    // �X�V�t���O��true�̏ꍇ�A���f�[�^���폜���V�f�[�^��ǉ�����
                    // �X�V�t���O��false�̏ꍇ�A�f�[�^�ǉ����s��Ȃ�
                    if (isUpdate)
                    {
                        mkrSuggestRtPricUList.Remove(goodsInfoKey);
                        mkrSuggestRtPricUList.Add(goodsInfoKey, _mkrSuggestRtPricUList);
                    }
                }
                else
                {
                    // ���o�^
                    mkrSuggestRtPricUList.Add(goodsInfoKey, _mkrSuggestRtPricUList);
                }

                // ���[�J�[��]�������i���쐬
                PartsInfoDataSet.UsrGoodsPriceRow[] ofrPriceRows =
                    (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfoDataSet.OfrPriceDataTable.Select(
                        string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                        goodsUnitData.GoodsMakerCd,
                        goodsUnitData.GoodsNo));

                // �񋟃f�[�^���i���f�[�^�e�[�u�����牿�i�ꗗ���쐬
                _mkrSuggestRtPricList = GetGoodsPriceList(ofrPriceRows);

                // ���[�J�[��]�������i���o�^�ς݃`�F�b�N
                if (mkrSuggestRtPricList.ContainsKey(goodsInfoKey))
                {
                    // �o�^�ς�
                    // �X�V�t���O��true�̏ꍇ�A���f�[�^���폜���V�f�[�^��ǉ�����
                    // �X�V�t���O��false�̏ꍇ�A�f�[�^�ǉ����s��Ȃ�
                    if (isUpdate)
                    {
                        mkrSuggestRtPricUList.Remove(goodsInfoKey);
                        mkrSuggestRtPricList.Add(goodsInfoKey, _mkrSuggestRtPricList);
                    }
                }
                else
                {
                    // ���o�^
                    mkrSuggestRtPricList.Add(goodsInfoKey, _mkrSuggestRtPricList);
                }
            }
        }

        private List<GoodsPrice> GetGoodsPriceList(PartsInfoDataSet.UsrGoodsPriceRow[] priceRows)
        {
            List<GoodsPrice> retList = new List<GoodsPrice>();

            if (priceRows != null)
            {
                // ���[�J�[��]�������i���쐬
                for (int j = 0; j < priceRows.Length; j++)
                {
                    GoodsPrice prc = new GoodsPrice();
                    prc.CreateDateTime = new DateTime(priceRows[j].CreateDateTime);
                    prc.UpdateDateTime = new DateTime(priceRows[j].UpdateDateTime);
                    prc.EnterpriseCode = priceRows[j].EnterpriseCode;
                    if (priceRows[j].IsFileHeaderGuidNull() == false)
                        prc.FileHeaderGuid = priceRows[j].FileHeaderGuid;
                    prc.UpdAssemblyId1 = priceRows[j].UpdAssemblyId1;
                    prc.UpdAssemblyId2 = priceRows[j].UpdAssemblyId2;
                    prc.UpdEmployeeCode = priceRows[j].UpdEmployeeCode;
                    prc.LogicalDeleteCode = priceRows[j].LogicalDeleteCode;

                    prc.GoodsMakerCd = priceRows[j].GoodsMakerCd;
                    prc.GoodsNo = priceRows[j].GoodsNo;
                    prc.ListPrice = priceRows[j].ListPrice;
                    prc.OpenPriceDiv = priceRows[j].OpenPriceDiv;
                    prc.PriceStartDate = priceRows[j].PriceStartDate;
                    prc.SalesUnitCost = priceRows[j].SalesUnitCost;
                    prc.StockRate = priceRows[j].StockRate;
                    if (priceRows[j].IsUpdateDateNull() == false)
                    {
                        prc.UpdateDate = priceRows[j].UpdateDate;
                    }
                    else
                    {
                        prc.UpdateDate = DateTime.MinValue;
                    }
                    prc.OfferDate = priceRows[j].OfferDate;
                    retList.Add(prc);
                }
            }
            return retList;
        }
        /// <summary>
        /// �w��������Y�����i���f�[�^�I�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="targetDateTime">���i�J�n��</param>
        /// <param name="goodsPriceList">���i���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>���i���f�[�^�I�u�W�F�N�g</returns>
        public GoodsPrice GetGoodsPrice(DateTime targetDateTime, List<GoodsPrice> goodsPriceList)
        {
            return this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDateTime, goodsPriceList);
        }

        /// <summary>
        ///  �񋟃f�[�^�̉��i�����擾���܂�
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="mkrSuggestRtPricList"></param>
        private void GetOfferGoodsPrice(GoodsUnitData goodsUnitData, out List<GoodsPrice> mkrSuggestRtPricList)
        {
            mkrSuggestRtPricList = null;

            if (goodsUnitData == null) return;

            // ���[�J�[�R�[�h�A�i�Ԃ��񋟃f�[�^�̉��i�����擾
            ArrayList goodsPriceUWorkList = new ArrayList();
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
            ArrayList lstCond = new ArrayList();
            ArrayList lstRst;
            ArrayList lstRstPrm;
            ArrayList lstPrmPrice;

            OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
            work.MakerCode = goodsUnitData.GoodsMakerCd;
            work.PrtsNo = goodsUnitData.GoodsNo;
            lstCond.Add(work);

            if (_iOfferPartsInfo == null) _iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
            int status = _iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if ((lstPrmPrice != null) && (lstPrmPrice.Count != 0))
                {
                    // �D�ǉ��i
                    foreach (OfferJoinPriceRetWork retWork in lstPrmPrice)
                    {
                        goodsPriceUWork = new GoodsPriceUWork();
                        goodsPriceUWork.GoodsMakerCd = retWork.PartsMakerCd;
                        goodsPriceUWork.GoodsNo = retWork.PrimePartsNoWithH;
                        goodsPriceUWork.ListPrice = retWork.NewPrice;
                        goodsPriceUWork.OfferDate = retWork.OfferDate;
                        goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
                        goodsPriceUWork.PriceStartDate = retWork.PriceStartDate;

                        goodsPriceUWorkList.Add(goodsPriceUWork);
                    }
                }
                if ((lstRst != null) && (lstRst.Count != 0))
                {
                    // �������i
                    foreach (RetPartsInf retWork in lstRst)
                    {
                        goodsPriceUWork = new GoodsPriceUWork();
                        goodsPriceUWork.GoodsMakerCd = retWork.CatalogPartsMakerCd;
                        goodsPriceUWork.GoodsNo = retWork.ClgPrtsNoWithHyphen;
                        // �������i�𔽉f���Ȃ�
                        goodsPriceUWork.ListPrice = retWork.PartsPrice;
                        goodsPriceUWork.OfferDate = retWork.OfferDate;
                        goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
                        goodsPriceUWork.PriceStartDate = retWork.PartsPriceStDate;

                        goodsPriceUWorkList.Add(goodsPriceUWork);
                    }
                }
            }

            if (goodsPriceUWorkList != null && goodsPriceUWorkList.Count != 0)
            {
                // ���i��񃊃X�g(ArrayList)��GoodsPrice�̃��X�g�ɕϊ�
                this.GetGoodsPriceListFromGoodsPriceUWorkList(goodsPriceUWorkList, out mkrSuggestRtPricList);
            }
        }

        /// <summary>
        /// ���i���f�[�^�I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="goodsPriceWorkList">���i���f�[�^���[�N�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsPriceList">���i���f�[�^�I�u�W�F�N�g���X�g</param>
        private void GetGoodsPriceListFromGoodsPriceUWorkList(ArrayList goodsPriceWorkList, out List<GoodsPrice> goodsPriceList)
        {
            goodsPriceList = new List<GoodsPrice>();

            foreach (GoodsPriceUWork goodsPriceUWork in goodsPriceWorkList)
            {
                GoodsPrice goodsPrice = new GoodsPrice();

                goodsPrice.CreateDateTime = goodsPriceUWork.CreateDateTime; // �쐬����
                goodsPrice.UpdateDateTime = goodsPriceUWork.UpdateDateTime; // �X�V����
                goodsPrice.EnterpriseCode = goodsPriceUWork.EnterpriseCode; // ��ƃR�[�h
                goodsPrice.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid; // GUID
                goodsPrice.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                goodsPrice.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                goodsPrice.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                goodsPrice.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode; // �_���폜�敪
                goodsPrice.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
                goodsPrice.GoodsNo = goodsPriceUWork.GoodsNo; // ���i�ԍ�
                goodsPrice.PriceStartDate = goodsPriceUWork.PriceStartDate; // ���i�J�n��
                goodsPrice.ListPrice = goodsPriceUWork.ListPrice; // �艿�i�����j
                goodsPrice.SalesUnitCost = goodsPriceUWork.SalesUnitCost; // �����P��
                goodsPrice.StockRate = goodsPriceUWork.StockRate; // �d����
                goodsPrice.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv; // �I�[�v�����i�敪
                goodsPrice.OfferDate = goodsPriceUWork.OfferDate; // �񋟓��t
                goodsPrice.UpdateDate = goodsPriceUWork.UpdateDate; // �X�V�N����

                goodsPriceList.Add(goodsPrice);
            }
        }
        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
        #endregion

        #region �艿
        /// <summary>
        /// �艿���擾���܂��B
        /// </summary>
        /// <returns>�艿</returns>
        private double GetListPrice(List<UnitPriceCalcRet> unitPriceList)
        {
            double retListPrice = 0;

            #region <Guard Phrase>

            if (unitPriceList == null || unitPriceList.Count == 0) return retListPrice;

            #endregion // </Guard Phrase>

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_ListPrice))
                {
                    retListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;
                    break;
                }
            }
            return retListPrice;
        }
        #endregion

        #region ����
        /// <summary>
        /// �P�����擾���܂��B
        /// </summary>
        /// <returns>�P��</returns>
        public double GetUnitPrice(List<UnitPriceCalcRet> unitPriceList, GoodsUnitData goodsUnitData, int customerCode, DateTime startDate, UnitPriceCalcParam condition, string sectionCode)
        {
            double retUnitPrice = 0;

            #region <Guard Phrase>

            if (unitPriceList == null || unitPriceList.Count == 0) return retUnitPrice;
            if (goodsUnitData == null) return retUnitPrice;

            #endregion // </Guard Phrase>

            double unitPrice = 0;
            UnitPriceCalcRet sellingPriceResult = null;

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice))
                {
                    sellingPriceResult = new UnitPriceCalcRet();
                    sellingPriceResult = unitPriceCalcRet;
                    break;
                }
            }

            if (sellingPriceResult != null)
            {
                unitPrice = sellingPriceResult.UnitPriceTaxExcFl;  // �P���͒P��(�Ŕ�, ����)
            }
            else
            {
                // �������ݒ�敪���u1:�艿�\���v�̏ꍇ�A�艿���g�p
                if (this._salesTtlStAgent.UsesListPriceIfSalesPriceIsNone(
                    this._enterpriseCode,
                    sectionCode
                ))
                {
                    unitPrice = this.GetListPrice(unitPriceList);
                }
            }

            double listPrice = this.GetListPrice(unitPriceList); // �艿
            double price = unitPrice; // ����
            double priceTaxExc = 0; // �����i�Ŕ��j
            double priceTaxInc = 0; // �����i�ō��j

            // �L�����y�[�����擾
            ReflectCampaign(goodsUnitData.TaxationDivCd, customerCode, goodsUnitData.BLGoodsCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo.Trim(), goodsUnitData.BLGroupCode, 0, startDate, sectionCode);

            if (this._campaignObjGoodsSt != null)
            {
                // �L�����y�[�����i�K�p
                if (this._campaignObjGoodsSt.PriceFl != 0)
                {
                    price = this._campaignObjGoodsSt.PriceFl;
                }
                // �L�����y�[���������K�p
                if (this._campaignObjGoodsSt.RateVal != 0)
                {
                    this.CalclatePriceByRate(goodsUnitData.TaxationDivCd, this._campaignObjGoodsSt.RateVal, condition.SalesCnsTaxFrcProcCd, condition.SalesUnPrcFrcProcCd, condition.TotalAmountDispWayCd, condition.TaxRate, ref listPrice);
                    price = listPrice;
                }
                // �L�����y�[���l�����K�p
                if (this._campaignObjGoodsSt.DiscountRate != 0)
                {
                    this.CalclatePriceByRate(goodsUnitData.TaxationDivCd, 100 - this._campaignObjGoodsSt.DiscountRate, condition.SalesCnsTaxFrcProcCd, condition.SalesUnPrcFrcProcCd, condition.TotalAmountDispWayCd, condition.TaxRate, ref price);
                }
            }
            // ���i�Čv�Z
            this.CalcTaxExcAndTaxInc(condition.TaxationDivCd, customerCode, condition.TaxRate, condition.TotalAmountDispWayCd, price, out priceTaxExc, out priceTaxInc);
            retUnitPrice = priceTaxExc;

            return retUnitPrice;
        }

        /// <summary>
        /// �|�������z�擾
        /// </summary>
        /// <param name="taxationDivCd"></param>
        /// <param name="autoCooperatDis"></param>
        /// <param name="price"></param>
        private void CalclatePriceByRate(int taxationDivCd, double autoCooperatDis, int salesCnsTaxFrcProcCd, int frcProcCd, int totalAmountDispWayCd, double taxRate, ref double price)
        {
            double unitPriceTaxExc = 0;
            double unitPriceTaxInc = 0;

            // ����Œ[������
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // ����P���[������
            double fracProcUnit = 0;
            int fracProcDiv = 0;
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_SalesUnitPrice, salesCnsTaxFrcProcCd, 0, out fracProcUnit, out fracProcDiv);
            // �|���ɂ��P���v�Z
            this._unitPriceCalculation.CalculateUnitPriceByRate(UnitPriceCalculation.UnitPriceKind.SalesUnitPrice,
                                            UnitPriceCalculation.UnitPrcCalcDiv.RateVal,
                                            0,
                                            0,
                                            frcProcCd,
                                            taxationDivCd,
                                            price,
                                            taxRate,
                                            taxFracProcUnit,
                                            taxFracProcCd,
                                            autoCooperatDis,
                                            ref fracProcUnit,
                                            ref fracProcDiv,
                                            out unitPriceTaxExc,
                                            out unitPriceTaxInc);

            if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
            {
                price = unitPriceTaxInc;
            }
            else
            {
                price = unitPriceTaxExc;
            }
        }

        #region �P���v�Z
        /// <summary>
        /// �Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z���܂��B
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="displayPrice">�Ώۋ��z</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        private void CalcTaxExcAndTaxInc(int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // ���Ӑ�}�X�^�������Œ[�����������擾
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
            double fracProcUnit;
            int fracProcCd;
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // ���ŕi
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // �O�ŕi
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // ���z�\�����Ă���ꍇ�͐ō��݉��i
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // ��ېŕi
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }
        #endregion 

        #region ������z�����敪�ݒ�}�X�^ �f�[�^�擾�����֘A
        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        private void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // �����l
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // �P����0.01�~�P��
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                    break;
            }
            fractionProcCd = 1;     // �؎̂�

            //-----------------------------------------------------------------------------
            // �R�[�h�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �\�[�g�i������z�i�����j�j
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // �߂�l�ݒ�
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// ������z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
        #endregion

        #endregion

        #region Ұ����]�������i�A�艿�A�����̎擾
        /// <summary>
        ///  ���i�����Ұ����]�������i�A�艿�A�������擾���܂�
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="mkrSuggestRtPric">Ұ����]�������i</param>
        /// <param name="rateVal">������</param>
        /// <param name="goodsUnitData">���i���</param>
        /// <param name="startDate">�J�n��</param>
        /// <param name="listPrice">�艿</param>
        /// <param name="unitPrice">����</param>
        public void GetUnitPriceFromRate(
            string sectionCode,
            int customerCode,
            long mkrSuggestRtPric,
            double rateVal,
            GoodsUnitData goodsUnitData,
            DateTime startDate,
            out double listPrice,
            out double unitPrice
        )
        {
            unitPrice = 0.0;
            listPrice = 0.0;

            #region <Guard Phrase>

            // ���i��񂪋�̎��͏����I��
            if (goodsUnitData == null) return;
            // �J�n���������l�̎��͏����I��
            if (startDate == DateTime.MinValue) return;

            #endregion // </Guard Phrase>

            {
                // ���i�Z�o�p�����[�^�ݒ�
                UnitPriceCalcParam condition = new UnitPriceCalcParam();
                {
                    condition.BLGoodsCode = goodsUnitData.BLGoodsCode;  // BL�R�[�h 
                    condition.BLGoodsName = goodsUnitData.BLGoodsName;  // BL�R�[�h����
                    condition.BLGroupCode = goodsUnitData.BLGroupCode;  // BL�O���[�v�R�[�h
                    condition.CountFl = 1;                              // ����
                    condition.CustomerCode = customerCode;              // ���Ӑ�R�[�h

                    // ���Ӑ���擾
                    if (customerCode != 0)
                    {
                        GetCustomerInfo(customerCode);
                    }

                    // ������z�����敪���X�g�擾
                    GetSalesProcMoney();

                    // ���Ӑ�|���O���[�v�R�[�h
                    condition.CustRateGrpCode = this.GetCustomerRateGroupCode(
                        this._enterpriseCode,
                        customerCode,
                        goodsUnitData.GoodsMakerCd
                    );

                    condition.GoodsMakerCd = goodsUnitData.GoodsMakerCd;            // ���[�J�[�R�[�h
                    condition.GoodsNo = goodsUnitData.GoodsNo;                      // �i��
                    condition.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;    // ���i�|���O���[�v�R�[�h
                    condition.GoodsRateRank = goodsUnitData.GoodsRateRank;          // ���i�|�������N

                    condition.PriceApplyDate = startDate;                           // �K�p��

                    // �������Œ[�������R�[�h
                    condition.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
                    // ����P���[�������R�[�h
                    condition.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);

                    condition.SectionCode = sectionCode;                            // ���_�R�[�h

                    // �d������Œ[�������R�[�h
                    condition.StockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                    // �d���P���[�������R�[�h
                    condition.StockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);

                    condition.SupplierCd = goodsUnitData.SupplierCd;                // �d����R�[�h
                    condition.TaxationDivCd = goodsUnitData.TaxationDivCd;          // �ېŋ敪
                    condition.TaxRate = this.GetTaxRate(startDate);                 // �ŗ�

                    // ��������擾
                    CustomerInfo claim = ClaimInfo(customerCode);
                    if (claim != null)
                    {
                        // ������擾���͐�������̏���œ]�ŕ�����ݒ肷��
                        condition.ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? this._taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                    }
                    else
                    {
                        // �����悪�擾�ł��Ȃ��ꍇ�́A�ŗ��ݒ�}�X�^�̏���œ]�ŕ�����ݒ�
                        condition.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;
                    }

                    condition.TotalAmountDispWayCd = 0; // ���z�\�����@�敪
                    condition.TtlAmntDspRateDivCd = 0;  // ���z�\���|���K�p�敪 0:(�ō����z�~�|��) 1:(�Ŕ����z�~�|��)�������ł����ߍ��Z(����ŎZ�o������ł̒[������������)
                }

                this._unitPriceCalculation.RatePriorityDiv = GetCompanyInf(this._enterpriseCode).RatePriorityDiv; //���Аݒ襊|���D�揇��

                this._unitPriceCalculation.CacheSalesProcMoneyList(this._salesProcMoneyList); // ������z�����敪���X�g�L���b�V��

                // �����擾
                this.GetUnitPriceFromRate(sectionCode, customerCode, mkrSuggestRtPric, rateVal, goodsUnitData, condition, out listPrice, out unitPrice);
            }
        }


        /// <summary>
        /// �P�����擾���܂��B
        /// </summary>
        /// <returns>�P��</returns>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="mkrSuggestRtPric">Ұ����]�������i</param>
        /// <param name="rateVal">������</param>
        /// <param name="goodsUnitData">���i���</param>
        /// <param name="condition"></param>
        /// <param name="listPrice">�艿</param>
        /// <param name="unitPrice">����</param>
        public void GetUnitPriceFromRate(
            string sectionCode,
            int customerCode,
            long mkrSuggestRtPric,
            double rateVal,
            GoodsUnitData goodsUnitData,
            UnitPriceCalcParam condition,
            out double listPrice,
            out double unitPrice)
        {
            unitPrice = 0.0;
            listPrice = 0.0;
            double retUnitPrice = unitPrice;
            double retListPrice = listPrice;

            double price = unitPrice;   // ����
            double priceTaxExc = 0;     // �����i�Ŕ��j
            double priceTaxInc = 0;     // �����i�ō��j

            retListPrice = mkrSuggestRtPric; // Ұ����]�������i

            // �������K�p
            this.CalclatePriceByRate(
                goodsUnitData.TaxationDivCd,
                rateVal,
                condition.SalesCnsTaxFrcProcCd,
                condition.SalesUnPrcFrcProcCd,
                condition.TotalAmountDispWayCd,
                condition.TaxRate,
                ref retListPrice);

            // ���i�Čv�Z
            this.CalcTaxExcAndTaxInc(
                condition.TaxationDivCd,
                customerCode,
                condition.TaxRate,
                condition.TotalAmountDispWayCd,
                retListPrice,
                out priceTaxExc,
                out priceTaxInc);

            listPrice = retListPrice;
            unitPrice = priceTaxExc;

        }
        #endregion

        #endregion

        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
        /// <summary>
        /// ���i�����o�^�f�[�^�L�[�\����
        /// </summary>
        public struct GoodsInfoKey
        {
            string _goodsNo;
            int _goodsMakerCd;

            /// <summary>
            /// ���i�����o�^�f�[�^�L�[�\���̃R���X�g���N�^
            /// </summary>
            /// <param name="goodsNo"></param>
            /// <param name="goodsMakeCd"></param>
            internal GoodsInfoKey(string goodsNo, int goodsMakeCd)
            {
                this._goodsNo = goodsNo;
                this._goodsMakerCd = goodsMakeCd;
            }

            /// <summary>�i�ԃv���p�e�B</summary>
            internal string GoodsNo
            {
                get { return this._goodsNo; }
                set { this._goodsNo = value; }
            }

            /// <summary>���[�J�[�v���p�e�B</summary>
            internal int GoodsMakerCd
            {
                get { return this._goodsMakerCd; }
                set { this._goodsMakerCd = value; }
            }
        }
        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
    }
}
