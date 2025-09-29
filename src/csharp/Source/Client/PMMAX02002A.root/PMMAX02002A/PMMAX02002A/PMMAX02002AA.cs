//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�E���ח\��
// �v���O�����T�v   : �o�i�E���ח\�� �A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : ���O
// �� �� �� : 2016/01/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �o�i�ꊇ�X�V �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �o�i�ꊇ�X�V�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2016/01/21</br>
    /// </remarks>
    public class MoveDataExportAcs
    {
        #region �� Private Member(�����E�������v�Z)
        // ���ׂĎd�����񃊃X�g
        Dictionary<int, Supplier> _allSupplierDic;

        // ���Ӑ�|���A�N�Z�X
        CustRateGroupAcs _custRateGroupAcs;

        // ���Ӑ�̓��Ӑ�|���O���[�vDictionary
        Dictionary<int, List<CustRateGroup>> _gustRateGroupList = new Dictionary<int, List<CustRateGroup>>();

        // �P���Z�o�������s��
        UnitPriceCalculation _unitPriceCalculation = new UnitPriceCalculation();

        // ���Ӑ���
        CustomerInfo _customerInfo;

        // ��������
        CustomerInfo _claimInfo;

        // �ŗ��ݒ�
        TaxRateSet _taxRateSet;

        // �ŗ�
        double _taxRateOfNow = 0;

        // ����S�̏����ݒ�A�N�Z�X
        SalesTtlStAcs _salesTtlStAcs = new SalesTtlStAcs();

        // ����S�̏����ݒ���
        SalesTtlSt _salesTtlSt = null;

        // �d����A�N�Z�X
        SupplierAcs _supplierAcs;

        // �������[�J�[�ő�R�[�h
        private static readonly Int32 ctPureGoodsMakerCode = 999;
        #endregion

        #region �� Constructor
        /// <summary>
        /// �o�i�E���ח\��A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �o�i�E���ח\��A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public MoveDataExportAcs()
        {
            this._iPartsMaxStockArrivalDB = (IPartsMaxStockArrivalDB)MediationPartsMaxStockArrivalDB.GetPartsMaxStockArrivalDB();

            #region �� �����Z�o�p�f�[�^������
            // �S�Ďd�����擾
            GetAllSuppInfo();
            
            // ������z�����敪�ݒ�Ǝ��Џ����擾
            GetSalesProcMoneyInfo();

            // �ŗ����擾
            GetTaxInfo();

            // ����S�̏����l�擾
            GetSalesTtlStInfo();
            #endregion
        }
        #endregion �� Constructor

        #region �� Private Member
        private IPartsMaxStockArrivalDB _iPartsMaxStockArrivalDB;
        private const string M_022 = "�֘A���ڎ擾���ɃG���[���������܂����B\r\n[����={0}�A�X�e�[�^�X={1},���b�Z�[�W={2}]";
        #endregion �� Private Member

        #region �� Public Method

        /// <summary>
        /// �����擾
        /// </summary>
        /// <param name="moveCount">�ړ��f�[�^��������</param>
        /// <param name="dayDataExportCond">���o����</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : �������擾����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public int SearchCount(out int moveCount, PartsMaxStockArrivalCondt dayDataExportCond, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            moveCount = 0; // �ړ��f�[�^��������

            //-----------------------------------------------------------------------------
            // �f�[�^����
            //-----------------------------------------------------------------------------
            errMessage = string.Empty;

            try
            {
                // �f�[�^�����擾����
                status = this._iPartsMaxStockArrivalDB.SearchCount(out moveCount, (object)dayDataExportCond, out errMessage);

            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �f�[�^���o����
        /// </summary>
        /// <param name="retMoveDataList">�ړ��f�[�^��������</param>
        /// <param name="dayDataExportCond">���o����</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <param name="loopIndex">����index</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : �e�L�X�g�o�̓f�[�^���擾����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public int SearchDayDataExportMain(out ArrayList retMoveDataList, PartsMaxStockArrivalCondt dayDataExportCond, out string errMessage, int loopIndex)
        {
            return this.SearchDayDataExportProc(out retMoveDataList, dayDataExportCond, out errMessage, loopIndex);
        }

        #endregion �� Public Method

        #region �� Private Method
        #region �� �f�[�^�擾
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="retMoveDataList">�ړ��f�[�^��������</param>
        /// <param name="dayDataExportCond">���o����</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <param name="loopIndex">����index</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : �e�L�X�g�o�̓f�[�^���擾����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private int SearchDayDataExportProc(out ArrayList retMoveDataList, PartsMaxStockArrivalCondt dayDataExportCond, out string errMessage, int loopIndex)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retMoveDataList = null; // �ړ��f�[�^��������
            errMessage = string.Empty;
            //-----------------------------------------------------------------------------
            // �f�[�^����
            //-----------------------------------------------------------------------------
            object moveExportResultWork = null; // �ړ��f�[�^
            errMessage = string.Empty;

            try
            {
                // �f�[�^�擾����
                status = this._iPartsMaxStockArrivalDB.Search(out moveExportResultWork, (object)dayDataExportCond, out errMessage, loopIndex);

                // ����̏ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retMoveDataList = (ArrayList)moveExportResultWork;
                    if (retMoveDataList.Count == 0)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        return status;
                    }

                    // ���P���E�̔��P���v�Z����
                    status = PriceCalculation(ref retMoveDataList, dayDataExportCond);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errMessage = string.Format(M_022, "�������A�̔��P��", - 1, "�������A�̔��P���̎擾�Ɏ��s���܂����B");
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ���Ӑ摊�֏��擾�i���Ӑ�|���O���[�v���Ȃǁj
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <remarks>
        /// <br>Note        : ���Ӑ摊�֏��擾����i���Ӑ�|���O���[�v���Ȃǁj</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        public void InitCustomerInfo(PartsMaxStockArrivalCondt cndtnWork)
        {
            // ���Ӑ�|���O���[�v��񃊃X�g�擾����
            GetAllCustomRateGroupList(cndtnWork);

            // ���Ӑ���擾
            GetCustomerInfo(cndtnWork);
        }
        #endregion

        #region �� �̔��P���Ɣ������̌v�Z����
        /// <summary>
        /// �̔��P���Ɣ������̌v�Z����
        /// </summary>
        /// <param name="retDataList">�̔��P���Ɣ������̒l</param>
        /// <param name="cndtnWork">���o����</param>
        /// <remarks>
        /// <br>Note        : �̔��P���Ɣ������̌v�Z����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private int PriceCalculation(ref ArrayList retDataList,
                    PartsMaxStockArrivalCondt cndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList tempAl = (ArrayList)retDataList;
            //�@�t�B���^�[�������s���܂�
            ArrayList retList = new ArrayList();

            string enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            string message = string.Empty;
            try
            {
                for (int i = 0; i < tempAl.Count; i++)
                {
                    PartsMaxStockArrivalWork tempWork = (PartsMaxStockArrivalWork)tempAl[i];

                    List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();

                    // �P���v�Z
                    GetPriceMain(cndtnWork, tempWork, out unitPriceCalcRetList);

                    if ((null != unitPriceCalcRetList) && (unitPriceCalcRetList.Count > 0))
                    {

                        for (int j = 0; j < unitPriceCalcRetList.Count; j++)
                        {
                            UnitPriceCalcRet unitPriceInfo = unitPriceCalcRetList[j];

                            switch (unitPriceInfo.UnitPriceKind)
                            {
                                case UnitPriceCalculation.ctUnitPriceKind_ListPrice: // �艿
                                    ((PartsMaxStockArrivalWork)tempAl[i]).ListPrice = unitPriceInfo.UnitPriceTaxExcFl;
                                    break;

                                case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice: // ����P��
                                    ((PartsMaxStockArrivalWork)tempAl[i]).SalesUnitCost = unitPriceInfo.UnitPriceTaxExcFl;

                                    // �̔��P�������������Z�o�����ꍇ�̂ݔ��������擾�A����ȊO(�����z�A����UP���A�e���m�ۗ�)�̏ꍇ�͔��������[���Ƃ���
                                    if (unitPriceInfo.UnitPrcCalcDiv == (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal)
                                    {
                                        ((PartsMaxStockArrivalWork)tempAl[i]).SalesRate = unitPriceInfo.RateVal;
                                    }

                                    break;
                            }
                        }
                    }

                    // ����S�̐ݒ�̔����[���\���敪�ɂ��A�������Ȃ��ꍇ�A�艿��ݒ肷��
                    if (((PartsMaxStockArrivalWork)tempAl[i]).SalesUnitCost == 0)
                    {
                        // 0:�[����\���@1:�艿��\��
                        if (_salesTtlSt.UnPrcNonSettingDiv == 0)
                        {
                            ((PartsMaxStockArrivalWork)tempAl[i]).SalesUnitCost = 0;
                        }
                        else
                        {
                            ((PartsMaxStockArrivalWork)tempAl[i]).SalesUnitCost = ((PartsMaxStockArrivalWork)tempAl[i]).ListPrice;
                        }
                    }
                }
            }
            catch
            {

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
            
        }

        /// <summary>
        /// �S�Ďd�����񌟍�
        /// </summary>
        /// <remarks>
        /// <br>Note        : �S�Ďd�����񌟍�����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void GetAllSuppInfo()
        {
            // �������S�Ďd����Dictionary
            _allSupplierDic = new Dictionary<int, Supplier>();

            // �S�Ďd��������擾����
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }
            ArrayList retList = new ArrayList();
            int status = _supplierAcs.Search(out retList, LoginInfoAcquisition.EnterpriseCode);

            if (0 == status)
            {
                foreach (Supplier supplierWork in retList)
                {
                    if (!_allSupplierDic.ContainsKey(supplierWork.SupplierCd))
                    {
                        _allSupplierDic.Add(supplierWork.SupplierCd, supplierWork);
                    }
                }
            }

        }

        /// <summary>
        /// ���Ӑ�|���O���[�v��񃊃X�g�擾����
        /// </summary>
        /// <param name="cndtnWork">��������</param>
        /// <returns>���Ӑ�|���O���[�v��񃊃X�g</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v��񃊃X�g�擾�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void GetAllCustomRateGroupList(PartsMaxStockArrivalCondt cndtnWork)
        {
            // ���Ӑ�|���O���[�v���
            ArrayList custRateGroupList;

            if (null == _custRateGroupAcs)
            {
                _custRateGroupAcs = new CustRateGroupAcs();
            }

            int status = _custRateGroupAcs.Search(out custRateGroupList, LoginInfoAcquisition.EnterpriseCode, cndtnWork.CustomerCode,
                    ConstantManagement.LogicalMode.GetData0);

            if (status == 0)
            {
                foreach (CustRateGroup tempCustRateGroup in custRateGroupList)
                {
                    if (_gustRateGroupList.ContainsKey(tempCustRateGroup.CustomerCode))
                    {
                        _gustRateGroupList[tempCustRateGroup.CustomerCode].Add(tempCustRateGroup);
                    }
                    else
                    {
                        List<CustRateGroup> tempCustRateGroupList = new List<CustRateGroup>();
                        tempCustRateGroupList.Add(tempCustRateGroup);
                        _gustRateGroupList.Add(tempCustRateGroup.CustomerCode, tempCustRateGroupList);
                    }
                }
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ�Ǝ��Џ����擾
        /// </summary>
        /// <remarks>
        /// <br>Note        : ������z�����敪�ݒ�Ǝ��Џ����擾����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void GetSalesProcMoneyInfo()
        {
            // ������z�����敪�ݒ���擾
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            ArrayList aList;
            salesProcMoneyAcs.IsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
            int status_SalesProcMoneyAcs = salesProcMoneyAcs.Search(out aList, LoginInfoAcquisition.EnterpriseCode);
            List<SalesProcMoney> _salesProcMoneyList = new List<SalesProcMoney>();
            if (status_SalesProcMoneyAcs == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) _salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }

            _unitPriceCalculation.CacheSalesProcMoneyList(_salesProcMoneyList);
            CompanyInf companyInf;
            int status_CompanyInf = GetCompanyInf(out companyInf, LoginInfoAcquisition.EnterpriseCode);
            //���Аݒ�̊|���D�揇�ʐݒ�敪���擾����(�P���Z�o�p)
            if (status_CompanyInf == (int)ConstantManagement.DB_Status.ctDB_NORMAL && companyInf != null)
            {
                _unitPriceCalculation.RatePriorityDiv = companyInf.RatePriorityDiv;
            }
        }

        /// <summary>
        /// ������莩�Џ��ݒ�}�X�^�擾����
        /// </summary>
        /// <param name="companyInf">���Џ��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ������莩�Џ��ݒ�}�X�^�擾�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private int GetCompanyInf(out CompanyInf companyInf, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();

            status = companyInfAcs.Read(out companyInf, enterpriseCode);
            return status;
        }

        /// <summary>
        /// ���Ӑ�Ɛ�������̎擾
        /// </summary>
        /// <param name="cndtnWork">�o�͏���</param>
        /// <remarks>
        /// <br>Note        : ������z�����敪�ݒ�Ǝ��Џ����擾����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void GetCustomerInfo(PartsMaxStockArrivalCondt cndtnWork)
        {
            // ���Ӑ於�̎擾
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            _customerInfo = new CustomerInfo();

            customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, cndtnWork.CustomerCode, out _customerInfo);


            _claimInfo = new CustomerInfo();

            if (null != _customerInfo && _customerInfo.ClaimCode != 0)
            {
                customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, _customerInfo.ClaimCode, out _claimInfo);
            }
        }

        /// <summary>
        /// ���t�t�H�[�}�b�g
        /// </summary>
        /// <returns>���t�t�H�[�}�b�g</returns>
        /// <remarks>
        /// <br>Note       : ���t�̓��t�t�H�[�}�b�g�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private DateTime GetDateTimeFormInt(int dataTime)
        {
            DateTime tempDate = DateTime.MinValue;
            try
            {
                if (0 != dataTime)
                {
                    tempDate = DateTime.ParseExact(dataTime.ToString(),
                                        "yyyyMMdd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                }
            }
            catch
            {
                tempDate = DateTime.MinValue;
            }

            return tempDate;
        }

        /// <summary>
        /// �P���Z�o����
        /// </summary>
        /// <param name="cndtnWork">�o�͏���</param>
        /// <param name="resultWork">����</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o�����f�[�^</param>
        /// <remarks>
        /// <br>Note        : �P���Z�o�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void GetPriceMain(
            PartsMaxStockArrivalCondt cndtnWork,
            PartsMaxStockArrivalWork resultWork,
            out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {

            // ���i�v�Z�p���i�A���f�[�^���X�g
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            // ���i�v�Z�p�p�����[�^���X�g
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            // ���Ӑ�R�[�h�擾
            int customerCode = cndtnWork.CustomerCode;

            #region 1 ���i�A���f�[�^�I�u�W�F�N�g�ݒ�
            // ���i�A���f�[�^�I�u�W�F�N�g������
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            // ���[�J�[�R�[�h  	
            goodsUnitData.GoodsMakerCd = resultWork.GoodsMakerCd;

            // �i��   
            goodsUnitData.GoodsNo = resultWork.GoodsNo;

            #region ���i���X�g�擾
            // ���i���X�g�擾
            goodsUnitData.GoodsPriceList = new List<GoodsPrice>();
            GoodsPrice tempGoodsPrice = new GoodsPrice();
            tempGoodsPrice.GoodsMakerCd = resultWork.GoodsMakerCd;
            tempGoodsPrice.GoodsNo = resultWork.GoodsNo;
            tempGoodsPrice.PriceStartDate = GetDateTimeFormInt(resultWork.PriceStartDate);
            tempGoodsPrice.ListPrice = resultWork.ListPrice;
            tempGoodsPrice.SalesUnitCost = resultWork.GpuSalesUnitCost; // ���i�}�X�^�̌����P��
            tempGoodsPrice.StockRate = resultWork.StockRate;
            tempGoodsPrice.OpenPriceDiv = resultWork.OpenPriceDiv;
            tempGoodsPrice.OfferDate = GetDateTimeFormInt(resultWork.OfferDate);
            tempGoodsPrice.UpdateDate = GetDateTimeFormInt(resultWork.UpdateDate);

            goodsUnitData.GoodsPriceList.Add(tempGoodsPrice);
            #endregion

            // �ېŋ敪
            goodsUnitData.TaxationDivCd = resultWork.TaxationDivCd;

            // ���X�g�ǉ�
            goodsUnitDataList.Add(goodsUnitData);
            #endregion 1 ���i�A���f�[�^�I�u�W�F�N�g�ݒ�

            #region 2 �P���v�Z�p�����[�^�ݒ�
            // �P���v�Z�p�����[�^
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            // BL�R�[�h
            unitPriceCalcParam.BLGoodsCode = resultWork.BLGoodsCod;
            // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = resultWork.BLGroupCode;
            // ����
            unitPriceCalcParam.CountFl = 1;
            // ���Ӑ�R�[�h
            unitPriceCalcParam.CustomerCode = cndtnWork.CustomerCode;

            #region ���Ӑ�|���O���[�v��񃊃X�g
            List<CustRateGroup> tempCustRateGroupList = new List<CustRateGroup>();
            // ���Ӑ�|���O���[�v��񃊃X�g�擾����
            tempCustRateGroupList = GetCustomRateGroupList(LoginInfoAcquisition.EnterpriseCode, cndtnWork.CustomerCode);

            // ���Ӑ�|���O���[�v�f�[�^�擾
            CustRateGroup tempCustRateGroup = this.GetCustRateGroup(ref tempCustRateGroupList, resultWork.GoodsMakerCd);
            if (null == tempCustRateGroup)
            {
                // ���Ӑ�|���O���[�v�R�[�h
                unitPriceCalcParam.CustRateGrpCode = -1;
            }
            else
            {
                // ���Ӑ�|���O���[�v�R�[�h
                unitPriceCalcParam.CustRateGrpCode = tempCustRateGroup.CustRateGrpCode;
            }
            #endregion

            // ���[�J�[�R�[�h
            unitPriceCalcParam.GoodsMakerCd = resultWork.GoodsMakerCd;
            // �i��
            unitPriceCalcParam.GoodsNo = resultWork.GoodsNo;
            // ���i�|���O���[�v�R�[�h(�a�k���i�R�[�h�}�X�^)
            unitPriceCalcParam.GoodsRateGrpCode = resultWork.GoodsRateGrpCode;
            // �w��(���i�}�X�^)
            unitPriceCalcParam.GoodsRateRank = resultWork.GoodsRateRank;
            // �K�p��:�V�X�e�����t
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;
            // ���Ӑ�̔������Œ[�������R�[�h
            unitPriceCalcParam.SalesCnsTaxFrcProcCd = _customerInfo.SalesCnsTaxFrcProcCd;
            // ���Ӑ�̔���P���[�������R�[�h
            unitPriceCalcParam.SalesUnPrcFrcProcCd = _customerInfo.SalesUnPrcFrcProcCd;
            // �Ǘ����_�R�[�h(�q�Ƀ}�X�^)
            unitPriceCalcParam.SectionCode = resultWork.SectionCode;
            // �d����R�[�h(�݌Ɉړ��f�[�^)
            unitPriceCalcParam.SupplierCd = resultWork.SupplierCd;
            // ���i�}�X�^�̉ېŋ敪
            unitPriceCalcParam.TaxationDivCd = resultWork.TaxationDivCd;
            // ���z�\�����@�敪
            unitPriceCalcParam.TotalAmountDispWayCd = 0;
            // ���z�\���|���K�p�敪 0:(�ō����z�~�|��) 1:(�Ŕ����z�~�|��)�������ł����ߍ��Z(����ŎZ�o������ł̒[������������)  
            unitPriceCalcParam.TtlAmntDspRateDivCd = 0;

            if (resultWork.SupplierCd != 0)
            {
                if (_allSupplierDic.ContainsKey(resultWork.SupplierCd))
                {
                    Supplier supplierWork = _allSupplierDic[resultWork.SupplierCd];
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = supplierWork.StockCnsTaxFrcProcCd;                     // �d������Œ[�������R�[�h   
                    unitPriceCalcParam.StockUnPrcFrcProcCd = supplierWork.StockUnPrcFrcProcCd;                      // �d���P���[�������R�[�h    
                }
            }

            #region ����œ]�ŕ���
            // ����œ]�ŕ���
            if (cndtnWork.CustomerCode == 0)
            {
                // ����Őݒ�̏���œ]�ŕ���
                unitPriceCalcParam.ConsTaxLayMethod = _taxRateSet.ConsTaxLayMethod;
            }
            else
            {
                // ������̏���œ]�ŕ���
                unitPriceCalcParam.ConsTaxLayMethod = (_customerInfo.CustCTaXLayRefCd == 0) ? _taxRateSet.ConsTaxLayMethod : _claimInfo.ConsTaxLayMethod;
            }
            #endregion

            unitPriceCalcParamList.Add(unitPriceCalcParam);

            #endregion 2 �P���v�Z�p�����[�^�ݒ�

            // �艿
            List<UnitPriceCalcRet> listPriceList = new List<UnitPriceCalcRet>();
            // ���P��
            List<UnitPriceCalcRet> salesUnitPriceList = new List<UnitPriceCalcRet>();
            // �艿
            _unitPriceCalculation.CalculateListPrice(unitPriceCalcParamList, goodsUnitDataList, out listPriceList);
            // ���P��
            _unitPriceCalculation.CalculateSalesUnitPrice(unitPriceCalcParamList, goodsUnitDataList, out salesUnitPriceList);

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            if ((null != listPriceList) && (listPriceList.Count > 0))
            {
                unitPriceCalcRetList.AddRange(listPriceList.ToArray());
            }

            if ((null != salesUnitPriceList) && (salesUnitPriceList.Count > 0))
            {
                unitPriceCalcRetList.AddRange(salesUnitPriceList.ToArray());
            }
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v��񃊃X�g�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v��񃊃X�g</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v��񃊃X�g�擾�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private List<CustRateGroup> GetCustomRateGroupList(string enterpriseCode, int customerCode)
        {
            List<CustRateGroup> custRateGroupList = new List<CustRateGroup>();
            // ���Ӑ悪����̏ꍇ
            if (customerCode != 0)
            {
                // ���Ӑ�̓��Ӑ�|���O���[�v��񂪑��݂���ꍇ�B
                if (_gustRateGroupList.ContainsKey(customerCode))
                {
                    custRateGroupList = _gustRateGroupList[customerCode];
                }
            }

            return custRateGroupList;
        }

        /// <summary>
        ///  ���Ӑ�|���O���[�v�擾����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�|���O���[�v��񃊃X�g</param>
        /// <param name="goodsMakerCode">���i���[�J�[�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�擾�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private CustRateGroup GetCustRateGroup(ref List<CustRateGroup> custRateGroupList, int goodsMakerCode)
        {
            int pureCode = (goodsMakerCode <= ctPureGoodsMakerCode) ? 0 : 1; // 0:���� 1:�D��

            // �P�ƃL�[
            CustRateGroup custRateGroup = custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == goodsMakerCode) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup;

            // ���ʃL�[
            custRateGroup = custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == 0) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (custRateGroup != null)
            {

                return custRateGroup;
            }


            return null;
        }

        /// <summary>
        /// �ŗ����擾
        /// </summary>
        /// <remarks>
        /// <br>Note        : �ŗ����擾���s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void GetTaxInfo()
        {
            // �ŗ��ݒ���擾
            if (null == _taxRateSet)
            {
                _taxRateSet = GetTaxRateSet(LoginInfoAcquisition.EnterpriseCode);

                // �ŗ����擾
                _taxRateOfNow = GetTaxRate(_taxRateSet, DateTime.Now);
            }
        }

        /// <summary>
        /// �ŗ��ݒ�����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�ŗ��ݒ���</returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ�����擾�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private static TaxRateSet GetTaxRateSet(string enterpriseCode)
        {
            TaxRateSet _taxRateSet = null;
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                if (_taxRateSet == null)
                {
                    int status = taxRateSetAcs.Read(out _taxRateSet, enterpriseCode, 0);
                }

                if (_taxRateSet == null)
                {
                    _taxRateSet = new TaxRateSet();
                }

                return _taxRateSet;
            }
        }

        /// <summary>
        /// �ŗ����擾����
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ���</param>
        /// <param name="targetDate">�ŗ��K�p��</param>
        /// <returns>�ŗ�</returns>
        /// <remarks>
        /// <br>Note       : �ŗ����擾�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private static double GetTaxRate(
            TaxRateSet taxRateSet,
            DateTime targetDate)
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }

        /// <summary>
        /// ����S�̏����l�擾
        /// </summary>
        /// <returns>����S�̏����l</returns>
        /// <remarks>
        /// <br>Note       : ����S�̏����l�擾�������s���B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2016/01/21</br>
        /// </remarks>
        private void GetSalesTtlStInfo()
        {
            _salesTtlSt = new SalesTtlSt();
            int status = _salesTtlStAcs.Read(out _salesTtlSt, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = _salesTtlStAcs.Read(out _salesTtlSt, LoginInfoAcquisition.EnterpriseCode, "00");
            }
        }

        #endregion

        #endregion �� Private Method
    }
}
