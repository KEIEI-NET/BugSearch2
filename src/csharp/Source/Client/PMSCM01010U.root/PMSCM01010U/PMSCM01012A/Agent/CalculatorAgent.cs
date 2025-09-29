//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS wangqx
// �� �� ��  2011/09/19  �C�����e : ReadMine#25267
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS wangqx
// �� �� ��  2011/10/08  �C�����e : ReadMine#25800
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/10/12  �C�����e : ReadMine#25768
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/08  �C�����e : 2012/11/14�z�M �V�X�e���e�X�g��Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902175-00 �쐬�S�� : �{�{ ����
// �� �� ��  2013/08/07  �C�����e : Redmine#39620(��#128)�Ή�
//                                  ���Аݒ�̊|���D�揇�ʂ��Q�Ƃ���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/10/25  �C�����e : 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/11/19  �C�����e : 201312xx�z�M�\�輽��ýď�Q��22�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/01/30  �C�����e : Redmine#41771 ��Q��13�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/02/05  �C�����e : SCM�d�|�ꗗ��10627�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2014/02/05  �C�����e : �d�|�ꗗ��10631 �����񓚑��x���P �|���}�X�^�L���b�V��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ����
// �� �� ��  2015/01/07  �C�����e : ���[�J�[��]�������i�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ����
// �� �� ��  2015/03/10  �C�����e : SCM�Г���Q�ꗗ��98�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ����
// �� �� ��  2015/03/18  �C�����e : SCM������ ���[�J�[��]�������i�Ή� 2015/01/07�Ή��������O
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = UnitPriceCalculation;
    using RecordType        = IList<UnitPriceCalcRet>;

    /// <summary>
    /// ���i�Z�o�n�N���X�̑㗝�l�N���X
    /// </summary>
    public sealed class CalculatorAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        // --- ADD 2013/08/07 T.Miyamoto ------------------------------>>>>>
        #region <���Аݒ�>
        private CompanyInf _companyInf;
        /// <summary>
        /// ���Аݒ���擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���Аݒ���</returns>
        public CompanyInf GetCompanyInf(string enterpriseCode)
        {
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
            if (_companyInf == null)
            {
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
            }
            // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<
            return _companyInf;
        }
        #endregion // </���Аݒ�>
        // --- ADD 2013/08/07 T.Miyamoto ------------------------------<<<<<

        #region <���Ӑ�}�X�^>

        /// <summary>���Ӑ�}�X�^�̃A�N�Z�T</summary>
        private CustomerAgent _customerDB;
        /// <summary>���Ӑ�}�X�^�̃A�N�Z�T���擾���܂��B</summary>
        public CustomerAgent CustomerDB
        {
            get
            {
                if (_customerDB == null)
                {
                    _customerDB = new CustomerAgent();
                }
                return _customerDB;
            }
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <c>SCMPriceCalculator.CurrentCustomerRateGroupList</c>
        /// �Ɠ��������ƂȂ�̂ŁA��������̂��]�܂����B
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v</returns>
        private List<CustRateGroup> GetCustomerRateGroupList(
            string enterpriseCode,
            int customerCode
        )
        {
            if (CustomerDB.CustomerRateGroupMap.ContainsKey(customerCode))
            {
                return CustomerDB.CustomerRateGroupMap[customerCode];
            }
            else
            {
                CustomerDB.TakeCustomerInfo(enterpriseCode, customerCode);
                if (CustomerDB.CustomerRateGroupMap.ContainsKey(customerCode))
                {
                    return CustomerDB.CustomerRateGroupMap[customerCode];
                }
                else
                {
                    return new List<CustRateGroup>();
                }
            }
        }

        // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
        /// <summary>
        /// ��������̎擾
        /// �@���Ӑ�R�[�h���琿��������擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�������� �擾�ł��Ȃ��ꍇ��null</returns>
        public CustomerInfo ClaimInfo(int customerCode)
        {
            CustomerInfo claim = null;
            CustomerInfo customerInfo = CustomerDB.CustomerInfoMap[customerCode];
            if (customerInfo != null)
            {
                if (customerInfo.CustomerCode.Equals(customerInfo.ClaimCode))
                {
                    // ���Ӑ�Ɛ����悪�����ꍇ
                    claim = customerInfo.Clone();
                }
                else if (CustomerDB.CustomerInfoMap.ContainsKey(customerInfo.ClaimCode))
                {
                    // �������񂪂��łɎ擾�ς݂̏ꍇ
                    claim = CustomerDB.CustomerInfoMap[customerInfo.ClaimCode];
                }
                else
                {
                    // �������񂪎擾����Ă��Ȃ��ꍇ
                    CustomerDB.TakeCustomerInfo(customerInfo.EnterpriseCode, customerInfo.ClaimCode);
                    if (CustomerDB.CustomerInfoMap.ContainsKey(customerInfo.ClaimCode))
                    {
                        claim = CustomerDB.CustomerInfoMap[customerInfo.ClaimCode];
                    }
                }
            }

            return claim;
        }
        // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

        #endregion // </���Ӑ�}�X�^>

        #region <�d����}�X�^>

        /// <summary>�d����}�X�^�̃A�N�Z�T</summary>
        private SupplierAgent _supplierDB;
        /// <summary>�d����}�X�^�̃A�N�Z�T���擾���܂��B</summary>
        public SupplierAgent SupplierDB
        {
            get
            {
                if (_supplierDB == null)
                {
                    _supplierDB = new SupplierAgent();
                }
                return _supplierDB;
            }
        }

        #endregion // </�d����}�X�^>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public CalculatorAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �P�����擾���܂��B
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="detailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="cancelDiv">�L�����Z���敪</param>
        /// <param name="inquiryDate">�⍇����</param>
        /// <returns>�P���Z�o���ʂ̃��X�g</returns>
        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
        //public IList<UnitPriceCalcRet> GetUnitPrice(
        //    int customerCode,
        //    ISCMOrderDetailRecord detailRecord,
        //    GoodsUnitData goodsUnitData
        //)
        public IList<UnitPriceCalcRet> GetUnitPrice(
            int customerCode,
            ISCMOrderDetailRecord detailRecord,
            GoodsUnitData goodsUnitData,
            short cancelDiv,
            DateTime inquiryDate
        )
        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
        {
            List<UnitPriceCalcRet> unitPriceList = null;
            {
                UnitPriceCalcParam condition = new UnitPriceCalcParam();
                {
                    //condition.BLGoodsCode = goodsUnitData.BLGroupCode;  // BL�R�[�h // DEL 2011/10/12
                    condition.BLGoodsCode = goodsUnitData.BLGoodsCode;  // BL�R�[�h // ADD 2011/10/12
                    condition.BLGoodsName = goodsUnitData.BLGoodsName;  // BL�R�[�h����
                    condition.BLGroupCode = goodsUnitData.BLGroupCode;  // BL�O���[�v�R�[�h

                    condition.CountFl = detailRecord.SalesOrderCount;   // ����
                    condition.CustomerCode = customerCode;              // ���Ӑ�R�[�h

                    // ���Ӑ�|���O���[�v�R�[�h
                    condition.CustRateGrpCode = GetCustomerRateGroupCode(
                        detailRecord.InqOtherEpCd,
                        customerCode,
                        goodsUnitData.GoodsMakerCd
                    );

                    condition.GoodsMakerCd      = goodsUnitData.GoodsMakerCd;       // ���[�J�[�R�[�h
                    condition.GoodsNo           = goodsUnitData.GoodsNo;            // �i��
                    condition.GoodsRateGrpCode  = goodsUnitData.GoodsRateGrpCode;   // ���i�|���O���[�v�R�[�h
                    condition.GoodsRateRank     = goodsUnitData.GoodsRateRank;      // ���i�|�������N

                    condition.PriceApplyDate = DateTime.Today;  // �K�p��

                    // �������Œ[�������R�[�h
                    condition.SalesCnsTaxFrcProcCd = CustomerDB.GetSalesFractionProcCdOfTax(customerCode, goodsUnitData);
                    // ����P���[�������R�[�h
                    condition.SalesUnPrcFrcProcCd = CustomerDB.GetSalesFractionProcCdOfUnit(customerCode, goodsUnitData);

                    condition.SectionCode = goodsUnitData.SectionCode;  // ���_�R�[�h

                    // �d������Œ[�������R�[�h
                    condition.StockCnsTaxFrcProcCd = SupplierDB.GetStockFractionProcCdOfTax(goodsUnitData);
                    // �d���P���[�������R�[�h
                    condition.StockUnPrcFrcProcCd = SupplierDB.GetStockFractionProcCdOfUnit(goodsUnitData);

                    condition.SupplierCd    = goodsUnitData.SupplierCd;     // �d����R�[�h
                    condition.TaxationDivCd = goodsUnitData.TaxationDivCd;  // �ېŋ敪

                    // HACK:condition.TaxRate = 0;              // �ŗ�
                    // HACK:condition.TotalAmountDispWayCd = 0; // ���z�\�����@�敪
                    // HACK:condition.TtlAmntDspRateDivCd = 0;  // ���z�\���|���K�p�敪 0:(�ō����z�~�|��) 1:(�Ŕ����z�~�|��)�������ł����ߍ��Z(����ŎZ�o������ł̒[������������)
                    // HACK:condition.ConsTaxLayMethod = 0;     // ����œ]�ŕ���
                    // -- ADD 2011/09/19   ------ >>>>>>
                    // DEL 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� -------------------------------->>>>> 
                    //// ���Ӑ���
                    //CustomerInfo customerInfo = CustomerDB.CustomerInfoMap[customerCode];
                    //if (customerInfo != null)
                    //{
                    //    condition.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod; // 072.����œ]�ŕ����c���Ӑ�}�X�^ or �ŗ��ݒ�}�X�^
                    //}
                    // DEL 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� -------------------------------->>>>> 
                    TaxRateSetAgent taxRateSet = new TaxRateSetAgent(detailRecord.InqOtherEpCd);
                    {
                        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                        //condition.TaxRate = taxRateSet.TaxRateOfNow;    // 073.����Őŗ��c�ŗ��ݒ�}�X�^
                        taxRateSet.CancelDiv = cancelDiv;       // �L�����Z���敪
                        taxRateSet.TaxRateDate = inquiryDate;   // �ŗ�������t
                        condition.TaxRate = (taxRateSet.CancelDiv == 1) ? taxRateSet.TaxRateOfSlesDate : taxRateSet.TaxRateOfNow; // 073.����Őŗ��c�ŗ��ݒ�}�X�^
                        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
                    }

                    // DEL 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
                    #region ���\�[�X
                    ////// ADD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� -------------------------------->>>>> 
                    ////CustomerInfo claim;
                    ////// ���Ӑ���擾
                    ////CustomerInfo customerInfo = CustomerDB.CustomerInfoMap[customerCode];
                    ////if (customerInfo != null)
                    ////{
                    ////    // ��������擾
                    ////    int status = CustomerDB.RealAccesser.ReadDBData(Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0, customerInfo.EnterpriseCode, customerInfo.ClaimCode, true, false, out claim);
                    ////    if (status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                    ////    {
                    ////        claim = new CustomerInfo();
                    ////    }

                    ////    if (claim != null)
                    ////    {
                    ////        condition.ConsTaxLayMethod = (claim.CustCTaXLayRefCd == 0) ? taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                    ////    }
                    ////}
                    ////// ADD 2013/10/25 201311XX�z�M�\��V�X�e���e�X�g��Q��13,14�Ή� --------------------------------<<<<< 
                    #endregion
                    // DEL 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

                    // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� ----------------------------------->>>>>
                    CustomerInfo claim = ClaimInfo(customerCode);
                    if (claim != null)
                    {
                        condition.ConsTaxLayMethod = claim.CustCTaXLayRefCd == 0 ? taxRateSet.ConsTaxLayMethod : claim.ConsTaxLayMethod;
                    }
                    else
                    {
                        // �����悪�擾�ł��Ȃ��ꍇ�́A�}�X�^�̐ŗ��ݒ���Z�b�g
                        condition.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;
                    }
                    // ADD 2014/02/05 SCM�d�|�ꗗ��10627�Ή� -----------------------------------<<<<<

                    condition.TotalAmountDispWayCd = 0; // ���z�\�����@�敪
                    condition.TtlAmntDspRateDivCd = 0;  // ���z�\���|���K�p�敪 0:(�ō����z�~�|��) 1:(�Ŕ����z�~�|��)�������ł����ߍ��Z(����ŎZ�o������ł̒[������������)
                    // -- ADD 2011/09/19   ------ <<<<<<
                    #region �����R�[�h

                    //condition.SectionCode = "25";
                    //condition.GoodsMakerCd = 2;
                    //condition.GoodsNo = "11044-42L00";
                    //condition.GoodsRateRank = "A";
                    //condition.GoodsRateGrpCode = 20;
                    //condition.BLGroupCode = 9;
                    //condition.BLGoodsCode = 1;
                    //condition.CustomerCode = 2000;
                    //condition.CustRateGrpCode = 0;
                    //condition.SupplierCd = 200;
                    //condition.PriceApplyDate = new DateTime(2009, 6, 10);
                    //condition.CountFl = 1;
                    //condition.TaxationDivCd = 0;
                    //condition.TaxRate = 0.05;
                    //condition.SalesCnsTaxFrcProcCd = 26;
                    //condition.StockCnsTaxFrcProcCd = 1801;
                    //condition.TotalAmountDispWayCd = 0;
                    //condition.TtlAmntDspRateDivCd = 0;
                    //condition.SalesUnPrcFrcProcCd = 26;
                    //condition.StockUnPrcFrcProcCd = 0;
                    //condition.ConsTaxLayMethod = 0;
                    //condition.BLGoodsName = "�w�b�h�K�X�P�b�g�i�}�[�W�e�X�g�Q�j";

                    //goodsUnitData.GoodsMakerCd = 2;
                    //goodsUnitData.MakerName = "�j�b�T��";
                    //goodsUnitData.MakerShortName = "";
                    //goodsUnitData.MakerKanaName = "Ư��";
                    //goodsUnitData.GoodsNo = "11044-42L00";
                    //goodsUnitData.GoodsName = "�w�b�h�f�^�j";
                    //goodsUnitData.GoodsNameKana = "ͯ��G/K";
                    //goodsUnitData.Jan = "";
                    //goodsUnitData.BLGoodsCode = 1;
                    //goodsUnitData.BLGoodsFullName = "�w�b�h�K�X�P�b�g�i�}�[�W�e�X�g�Q�j";
                    //goodsUnitData.DisplayOrder = 0;
                    //goodsUnitData.GoodsLGroup = 1;
                    //goodsUnitData.GoodsLGroupName = "�啪�ނP";
                    //goodsUnitData.GoodsMGroup = 9000;
                    //goodsUnitData.GoodsMGroupName = "�e�X�g�f�[�^";
                    //goodsUnitData.BLGroupCode = 9;
                    //goodsUnitData.BLGroupName = "�I�C���p���h�����R�b�N";
                    //goodsUnitData.GoodsRateRank = "A";
                    //goodsUnitData.TaxationDivCd = 0;
                    //goodsUnitData.GoodsNoNoneHyphen = "1104442L00";
                    //goodsUnitData.OfferDate = new DateTime(2008, 11, 7);
                    //goodsUnitData.GoodsKindCode = 0;
                    //goodsUnitData.GoodsNote1 = "";
                    //goodsUnitData.GoodsNote2 = "";
                    //goodsUnitData.GoodsSpecialNote = "";
                    //goodsUnitData.EnterpriseGanreCode = 0;
                    //goodsUnitData.EnterpriseGanreName = "";
                    //goodsUnitData.UpdateDate = DateTime.MinValue;
                    //goodsUnitData.UpdateDateJpFormal = "";
                    //goodsUnitData.UpdateDateJpInFormal = "";
                    //goodsUnitData.UpdateDateAdFormal = "";
                    //goodsUnitData.UpdateDateAdInFormal = "";
                    //goodsUnitData.GoodsRateGrpCode = 20;
                    //goodsUnitData.GoodsRateGrpName = "�u���[�L�p�[�c�a";
                    //goodsUnitData.SalesCode = 0;
                    //goodsUnitData.SalesCodeName = "";
                    //goodsUnitData.SupplierCd = 200;
                    //goodsUnitData.SupplierNm1 = "���Y";
                    //goodsUnitData.SupplierNm2 = "";
                    //goodsUnitData.SuppHonorificTitle = "�l";
                    //goodsUnitData.SupplierKana = "Ư�ݶ�";
                    //goodsUnitData.SupplierSnm = "���Y��";
                    //goodsUnitData.StockUnPrcFrcProcCd = 0;
                    //goodsUnitData.StockCnsTaxFrcProcCd = 0;
                    //goodsUnitData.SupplierLot = 0;
                    //goodsUnitData.SecretCode = 0;
                    //goodsUnitData.PrimePartsDisplayOrder = 0;
                    //goodsUnitData.PrmSetDtlNo1 = 0;
                    //goodsUnitData.PrmSetDtlName1 = "";
                    //goodsUnitData.PrmSetDtlNo2 = 0;
                    //goodsUnitData.PrmSetDtlName2 = "";
                    //goodsUnitData.SectionCode = "25";
                    //

                    #endregion // �����R�[�h
                }
                // --- ADD 2013/08/07 T.Miyamoto ------------------------------>>>>>
                RealAccesser.RatePriorityDiv = GetCompanyInf(detailRecord.EnterpriseCode).RatePriorityDiv; //���Аݒ襊|���D�揇��
                // --- ADD 2013/08/07 T.Miyamoto ------------------------------<<<<<

                // UPD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� ------->>>>>>>>>>>>>>>>>>>
                // RealAccesser.CalculateSalesRelevanceUnitPrice(condition, goodsUnitData, out unitPriceList);
                RealAccesser.CalculateSalesRelevanceUnitPriceRateCache(condition, goodsUnitData, out unitPriceList);
                // UPD 2014/02/05 ��10631 �g�� �|���}�X�^�L���b�V�� -------<<<<<<<<<<<<<<<<<<<

            }
            return unitPriceList ?? new List<UnitPriceCalcRet>();
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�R�[�h�擾����
        /// </summary>
        /// <remarks>
        /// MAHNB01012AB.cs l.9693 SalesSlipInputAcs.GetCustRateGroupCode() ���Q�l<br/>
        /// <c>SCMPriceCalcurator.GetCustomerRateGroupCode()</c>
        /// �Ɠ��������ƂȂ�̂ŁA��������̂��]�܂����B
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
            int pureCode = (goodsMakerCode <= SCMPriceCalculator.PURE_GOODS_MAKER_CODE_MAX ? 0 : 1);    // 0:���� 1:�D��

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
            // --- DELETE 2011/09/19 ---------->>>>>
            //return 0;
            // --- DELETE 2011/09/19 ----------<<<<<
            // --- ADD 2011/09/19 ---------->>>>>
            return -1;
            // --- ADD 2011/09/19 ----------<<<<<
        }

        // ADD 2012/11/08 2012/11/14�z�M �V�X�e���e�X�g��Q�Ή��F���� ------------------>>>>>
        #region <���i���i���>

        /// <summary>
        /// ���i�������ʂ��牿�i�����擾���܂�
        /// </summary>
        /// <param name="targetDay">�Ώۓ�</param>
        /// <param name="scmGoodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="goodsPrice">���i���I�u�W�F�N�g</param>
        /// <returns></returns>
        public static void GetPrice(DateTime targetDay, SCMGoodsUnitData scmGoodsUnitData, out GoodsPrice goodsPrice)
        {
            goodsPrice = null;
            if ((scmGoodsUnitData == null) || (scmGoodsUnitData.RealGoodsUnitData.GoodsPriceList == null)) return;

            List<GoodsPrice> goodsPriceList = scmGoodsUnitData.RealGoodsUnitData.GoodsPriceList;

            DateTime dateWk = DateTime.MinValue;
            foreach (GoodsPrice goodsPriceWk in goodsPriceList)
            {
                if ((goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk))
                {
                    dateWk = goodsPriceWk.PriceStartDate;
                    goodsPrice = goodsPriceWk.Clone();
                }
            }
        }

        #endregion // </���i���i���>
        // ADD 2012/11/08 2012/11/14�z�M �V�X�e���e�X�g��Q�Ή��F���� ------------------<<<<<


        // ADD 2015/01/07 ���[�J�[��]�������i�Ή� --------------------->>>>>
        #region ���[�J�[��]�������i
        // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
        #region �폜
        ///// <summary>
        ///// ���i�������ʂ��烁�[�J�[��]�������i���擾���܂�
        ///// </summary>
        ///// <param name="targetDay">�Ώۓ�</param>
        ///// <param name="scmGoodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        ///// <param name="goodsPrice">���i���I�u�W�F�N�g</param>
        ///// <returns></returns>
        //public static void GetMkrSuggestRtPric(DateTime targetDay, SCMGoodsUnitData scmGoodsUnitData, out GoodsPrice goodsPrice)
        //{
        //    goodsPrice = null;
        //    if ((scmGoodsUnitData == null) || (scmGoodsUnitData.RealGoodsUnitData.MkrSuggestRtPricList == null)) return;

        //    List<GoodsPrice> goodsPriceList = scmGoodsUnitData.RealGoodsUnitData.MkrSuggestRtPricList;

        //    DateTime dateWk = DateTime.MinValue;
        //    foreach (GoodsPrice goodsPriceWk in goodsPriceList)
        //    {
        //        if ((goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk))
        //        {
        //            dateWk = goodsPriceWk.PriceStartDate;
        //            goodsPrice = goodsPriceWk.Clone();
        //        }
        //    }
        //}
        #endregion
        // DEL 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

        // ADD 2015/03/10 SCM�Г���Q�ꗗ��98�Ή� ---------------------------------->>>>>
        /// <summary>
        /// ���i��񃊃X�g���烁�[�J�[��]�������i���擾���܂�
        /// </summary>
        /// <param name="targetDay">�Ώۓ�</param>
        /// <param name="mkrSuggestRtPricList">���i��񃊃X�g</param>
        /// <param name="goodsPrice">���i���I�u�W�F�N�g</param>
        /// <returns></returns>
        public static void GetMkrSuggestRtPric(DateTime targetDay, List<GoodsPrice> mkrSuggestRtPricList, out GoodsPrice goodsPrice)
        {
            goodsPrice = null;
            if ((mkrSuggestRtPricList == null) || (mkrSuggestRtPricList.Count == 0)) return;

            DateTime dateWk = DateTime.MinValue;
            foreach (GoodsPrice goodsPriceWk in mkrSuggestRtPricList)
            {
                if ((goodsPriceWk.PriceStartDate <= targetDay) && (goodsPriceWk.PriceStartDate > dateWk))
                {
                    dateWk = goodsPriceWk.PriceStartDate;
                    goodsPrice = goodsPriceWk.Clone();
                }
            }
        }
        // ADD 2015/03/10 SCM�Г���Q�ꗗ��98�Ή� ----------------------------------<<<<<
        #endregion
        // ADD 2015/01/07 ���[�J�[��]�������i�Ή� ---------------------<<<<<


        #region <�艿>

        /// <summary>
        /// �艿�̎Z�o���ʂ��擾���܂�
        /// </summary>
        /// <param name="unitPriceCalcRetList">���i�Z�o����</param>
        /// <returns>�艿�̎Z�o���ʁ@���艿�̎Z�o���ʂ����݂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        public static UnitPriceCalcRet GetListPriceResult(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            #region <Guard Phrase>

            if (unitPriceCalcRetList == null || unitPriceCalcRetList.Count.Equals(0)) return null;

            #endregion // </Guard Phrase>

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_ListPrice))
                {
                    return unitPriceCalcRet;
                }
            }
            return null;
        }

        #endregion // </�艿>

        #region <����>

        /// <summary>
        /// �����̎Z�o���ʂ��擾���܂�
        /// </summary>
        /// <param name="unitPriceCalcRetList">���i�Z�o����</param>
        /// <returns>�����̎Z�o���ʁ@�������̎Z�o���ʂ����݂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        public static UnitPriceCalcRet GetSellingPriceResult(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            #region <Guard Phrase>

            if (unitPriceCalcRetList == null || unitPriceCalcRetList.Count.Equals(0)) return null;

            #endregion // </Guard Phrase>

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice))
                {
                    return unitPriceCalcRet;
                }
            }
            return null;
        }

        #endregion // </����>

        #region <����>

        /// <summary>
        /// �����̎Z�o���ʂ��擾���܂�
        /// </summary>
        /// <param name="unitPriceCalcRetList">���i�Z�o����</param>
        /// <returns>�����̎Z�o���ʁ@�������̎Z�o���ʂ����݂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        public static UnitPriceCalcRet GetCostPriceResult(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            #region <Guard Phrase>

            if (unitPriceCalcRetList == null || unitPriceCalcRetList.Count.Equals(0)) return null;

            #endregion // </Guard Phrase>

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_UnitCost))
                {
                    return unitPriceCalcRet;
                }
            }
            return null;
        }

        #endregion // </����>

        #region <�e��>

        /// <summary>
        /// �e���z���擾���܂��B
        /// </summary>
        /// <param name="unitPriceCalcRetList">���i�Z�o���ʃ��X�g</param>
        /// <param name="priseIsNone">�������ݒ�敪</param>
        /// <returns>���� - ����</returns>
        // UPD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� ----------------------->>>>>
        //public static long GetRoughProfit(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        public static long GetRoughProfit(IList<UnitPriceCalcRet> unitPriceCalcRetList, bool priseIsNone)
        // UPD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� -----------------------<<<<<
        {
            // ����
            double salesPrice = 0.0;
            UnitPriceCalcRet salesResult = GetSellingPriceResult(unitPriceCalcRetList);
            if (salesResult != null)
            {
                // -- DEL 2011/10/08   ------ >>>>>>
                //salesPrice = salesResult.UnitPriceTaxIncFl;
                // -- DEL 2011/10/08   ------ <<<<<<
                // -- ADD 2011/10/08   ------ >>>>>>
                salesPrice = salesResult.UnitPriceTaxExcFl;
                // -- ADD 2011/10/08   ------ <<<<<<
            }
            // ADD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� ----------------------->>>>>
            else
            {
                // �������ݒ�敪���u1:�艿�\���v�̏ꍇ�A�艿���g�p
                if (priseIsNone)
                {
                    salesResult = GetListPriceResult(unitPriceCalcRetList);
                    if (salesResult != null)
                    {
                        salesPrice = salesResult.UnitPriceTaxExcFl;
                    }
                }
            }
            // ADD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� -----------------------<<<<<

            // ����
            double costPrice = 0.0;
            UnitPriceCalcRet costResult = GetCostPriceResult(unitPriceCalcRetList);
            if (costResult != null)
            {
                // -- DEL 2011/10/08   ------ >>>>>>
                //costPrice = costResult.UnitPriceTaxIncFl;
                // -- DEL 2011/10/08   ------ <<<<<<
                // -- ADD 2011/10/08   ------ >>>>>>
                costPrice = costResult.UnitPriceTaxExcFl;
                // -- ADD 2011/10/08   ------ <<<<<<
            }

            return (long)(salesPrice - costPrice);
        }

        /// <summary>
        /// �e�������擾���܂��B
        /// </summary>
        /// <param name="unitPriceCalcRetList">���i�Z�o���ʃ��X�g</param>
        /// <param name="priseIsNone">�������ݒ�敪</param>
        /// <returns>(���� - ����) / ���� * 100.0</returns>
        // UPD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� ----------------------->>>>>
        //public static double GetRoughRate(IList<UnitPriceCalcRet> unitPriceCalcRetList)
        public static double GetRoughRate(IList<UnitPriceCalcRet> unitPriceCalcRetList, bool priseIsNone)
        // UPD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� -----------------------<<<<<
        {
            // ����
            double salesPrice = 0.0;
            UnitPriceCalcRet salesResult = GetSellingPriceResult(unitPriceCalcRetList);
            if (salesResult != null)
            {
                // -- DEL 2011/10/08   ------ >>>>>>
                //salesPrice = salesResult.UnitPriceTaxIncFl;
                // -- DEL 2011/10/08   ------ <<<<<<
                // -- ADD 2011/10/08   ------ >>>>>>
                salesPrice = salesResult.UnitPriceTaxExcFl;
                // -- ADD 2011/10/08   ------ <<<<<<
            }
            // ADD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� ----------------------->>>>>
            else
            {
                // �������ݒ�敪���u1:�艿�\���v�̏ꍇ�A�艿���g�p
                if (priseIsNone)
                {
                    salesResult = GetListPriceResult(unitPriceCalcRetList);
                    if (salesResult != null)
                    {
                        salesPrice = salesResult.UnitPriceTaxExcFl;
                    }
                }
            }
            // ADD 2013/11/19 201312xx�z�M�\�輽��ýď�Q��22�Ή� -----------------------<<<<<

            // ����
            double costPrice = 0.0;
            UnitPriceCalcRet costResult = GetCostPriceResult(unitPriceCalcRetList);
            if (costResult != null)
            {
                // -- DEL 2011/10/08   ------ >>>>>>
                //costPrice = costResult.UnitPriceTaxIncFl;
                // -- DEL 2011/10/08   ------ <<<<<<
                // -- ADD 2011/10/08   ------ >>>>>>
                costPrice = costResult.UnitPriceTaxExcFl;
                // -- ADD 2011/10/08   ------ <<<<<<
            }

            if (salesPrice > 0.0)
            {
                return (salesPrice - costPrice) / salesPrice * 100.0;
            }
            else
            {
                return 0.0;
            }
        }

        #endregion // <�e��>

        /// <summary> 
        /// �w��l���w�肳�ꂽ���x�̐��l�Ɏl�̌ܓ����܂��B 
        /// </summary> 
        /// <param name="roundValue">�w��l</param> 
        /// <param name="digits">���x�i<c>0</c> �̏ꍇ�͐����ɂȂ�܂��j</param> 
        /// <returns>�w�肳�ꂽ���x�Ɏl�̌ܓ����ꂽ���l</returns> 
        public static double RoundOff(
            double roundValue,
            int digits
        )
        {
            double shift = Math.Pow(10, (double)digits);
            return Math.Floor(roundValue * shift + 0.5) / shift;
        }
    }
}
