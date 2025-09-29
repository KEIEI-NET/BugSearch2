//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ȒP�⍇��CTI �A�N�Z�X�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/06  �C�����e : IAAE�ł��琻�i�ł֕ύX(�s�v���W�b�N�폜)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ȒP�⍇��CTI �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/06</br>
    /// </remarks>
    public class SimpleInqCTIAcs
    {
        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region �� Public Enum

        /// <summary>
        /// �W�J����`�[�敪
        /// </summary>
        public enum ExtractSlipCdType : int
        {
            /// <summary>�S��</summary>
            All = 0,
            /// <summary>����</summary>
            Sales = 1,
            /// <summary>�ԕi</summary>
            Return = 2,
        }
        #endregion // Public Enum

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region �� Private Member

        ISearchSalesSlipDB _iSearchSalesSlipDB;
        private const string ct_DateFormat = "yyyy/MM/dd";
        private SimpleInqCTIDataSet _dataSet;
        private EmployeeAcs _employeeAcs;
        private int _rowNo = 0;

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �� Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SimpleInqCTIAcs()
        {
            this._dataSet = new SimpleInqCTIDataSet();
            this._employeeAcs = new EmployeeAcs();

            if (_employeeList == null) _employeeList = new List<Employee>();
        }

        #endregion // Constructor

        // ===================================================================================== //
        // �v���C�x�[�g�X�^�e�B�b�N�ϐ�
        // ===================================================================================== //
        #region �� Private Static Member

        private static List<Employee> _employeeList;

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region �� Property

        /// <summary>�f�[�^�Z�b�g</summary>
        public SimpleInqCTIDataSet DataSet
        {
            get { return _dataSet; }
        }

        /// <summary>�f�[�^�r���[</summary>
        public DataView DataView
        {
            get { return _dataSet.SalesSlip.DefaultView; }
        }
        #endregion // Property

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region �� Public Method

        /// <summary>
        /// ����f�[�^���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="para">�����p�����[�^</param>
        /// <param name="extractSlipCdType"></param>
        /// <param name="showEstimateInput"></param>
        /// <returns>STATUS</returns>
        public int Search(SalesSlipSearch para, int extractSlipCdType, bool showEstimateInput)
        {
            this._dataSet.SalesSlip.Rows.Clear();

            object returnSalesSlipSearchResult = null;
            SalesSlipSearchWork workPara = CreateParamDataFromUIData(para, extractSlipCdType, showEstimateInput);

            if (this._iSearchSalesSlipDB == null) this._iSearchSalesSlipDB = MediationSearchSalesSlipDB.GetSearchSalesSlipDB();
            int status = this._iSearchSalesSlipDB.Search(out returnSalesSlipSearchResult, workPara, 0, ConstantManagement.LogicalMode.GetData0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnSalesSlipSearchResult is ArrayList)
                {
                    this._rowNo = 0;

                    foreach (SalesSlipSearchResultWork data in (ArrayList)returnSalesSlipSearchResult)
                    {
                        SimpleInqCTIDataSet.SalesSlipRow row = _dataSet.SalesSlip.FindByEnterpriseCodeSearchSlipNumAcptAnOdrStatus(data.EnterpriseCode, data.SalesSlipNum, data.AcptAnOdrStatus);
                        if (row == null)
                        {
                            // �`�[�ԍ��Ɠ`�[��ʂ̏d���Ȃ�
                            this._rowNo++;
                            this.CacheSalesSlipSearchResult(data);
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// ����f�[�^(����)���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public int SearchDetail(SalesSlipDetailSearch para, SalesSlipSearchResult slip)
        {
            int status = 0;
            this._dataSet.SalesDetail.Rows.Clear();

            object returnSalesSlipDetailSearchResult = null;
            SalesSlipDetailSearchWork workPara = CreateDetailParamDataFromUIData(para);


            if (this._iSearchSalesSlipDB == null) this._iSearchSalesSlipDB = MediationSearchSalesSlipDB.GetSearchSalesSlipDB();
            status = this._iSearchSalesSlipDB.SearchDetail(out returnSalesSlipDetailSearchResult, workPara, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (returnSalesSlipDetailSearchResult is ArrayList)
                {
                    foreach (SalesSlipDetailSearchResultWork data in (ArrayList)returnSalesSlipDetailSearchResult)
                    {
                        this.CacheSalesSlipDetailSearchResult(data, slip);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// ����f�[�^�e�[�u���̍s�����������܂��B
        /// </summary>
        public void Clear()
        {
            this._dataSet.SalesSlip.Rows.Clear();
        }

        /// <summary>
        /// �]�ƈ������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="data">�]�ƈ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        public int GetEmployee(string enterpriseCode, string employeeCode, out Employee data)
        {
            int status = 0;

            if (_employeeList == null)
            {
                _employeeList = new List<Employee>();
            }

            if (_employeeList.Count == 0)
            {
                ArrayList aList;
                ArrayList aList2;
                status = this._employeeAcs.SearchOnlyEmployeeInfo(out aList, out aList2, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (aList != null) _employeeList = new List<Employee>((Employee[])aList.ToArray(typeof(Employee)));
                }
            }

            data = SearchStatic(employeeCode);

            if (data == null) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            return status;
        }


        /// <summary>
        /// ���z��ʐݒ�}�X�^����
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���z��ʐݒ�}�X�^���擾���܂��B</br>
        /// <br>Programmer	: 30414 �E �K�j</br>
        /// <br>Date		: 2008/12/12</br>
        /// </remarks>
        public int ReadMoneyKind(string enterprisecode, out Dictionary<int, MoneyKind> moneyKindDic)
        {

            MoneyKindAcs _moneyKindAcs = new MoneyKindAcs();

            moneyKindDic = new Dictionary<int, MoneyKind>();

            int status;
            ArrayList retList = new ArrayList();

            status = _moneyKindAcs.SearchAll(out retList, enterprisecode);
            if (status == 0)
            {
                foreach (MoneyKind moneyKind in retList)
                {
                    // ���z�ݒ�敪���u0:�����v���g�p
                    if (( moneyKind.LogicalDeleteCode == 0 ) && ( moneyKind.PriceStCode == 0 ))
                    {
                        moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                    }
                }
            }

            return ( status );
        }

        #endregion // Public Method

        // ===================================================================================== //
        // �p�u���b�N�X�^�e�B�b�N���\�b�h
        // ===================================================================================== //
        #region �� Public Static Method


        /// <summary>
        /// �p�����[�^�I�u�W�F�N�g����UI�f�[�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="data">�p�����[�^�I�u�W�F�N�g</param>
        /// <returns>UI�f�[�^�I�u�W�F�N�g</returns>
        public static SalesSlipSearchResult CreateUIDataFromParamData(SalesSlipSearchResultWork work)
        {
            SalesSlipSearchResult data = new SalesSlipSearchResult();

            #region �R�s�[
            data.AccRecConsTax = work.AccRecConsTax;
            data.AccRecDivCd = work.AccRecDivCd;
            data.AcptAnOdrStatus = work.AcptAnOdrStatus;
            data.AddresseeAddr1 = work.AddresseeAddr1;
            data.AddresseeAddr3 = work.AddresseeAddr3;
            data.AddresseeAddr4 = work.AddresseeAddr4;
            data.AddresseeCode = work.AddresseeCode;
            data.AddresseeFaxNo = work.AddresseeFaxNo;
            data.AddresseeName = work.AddresseeName;
            data.AddresseeName2 = work.AddresseeName2;
            data.AddresseePostNo = work.AddresseePostNo;
            data.AddresseeTelNo = work.AddresseeTelNo;
            data.AddUpADate = work.AddUpADate;
            data.AutoDepositCd = work.AutoDepositCd;
            data.AutoDepositSlipNo = work.AutoDepositSlipNo;
            data.BusinessTypeCode = work.BusinessTypeCode;
            data.BusinessTypeName = work.BusinessTypeName;
            data.CarMngCode = work.CarMngCode;
            data.CashRegisterNo = work.CashRegisterNo;
            data.CategoryNo = work.CategoryNo;
            data.ClaimCode = work.ClaimCode;
            data.ClaimSnm = work.ClaimSnm;
            data.CompleteCd = work.CompleteCd;
            data.ConsTaxLayMethod = work.ConsTaxLayMethod;
            data.ConsTaxRate = work.ConsTaxRate;
            data.CustomerCode = work.CustomerCode;
            data.CustomerName = work.CustomerName;
            data.CustomerName2 = work.CustomerName2;
            data.CustomerSnm = work.CustomerSnm;
            data.CustSlipNo = work.CustSlipNo;
            data.DebitNLnkSalesSlNum = work.DebitNLnkSalesSlNum;
            data.DebitNoteDiv = work.DebitNoteDiv;
            data.DelayPaymentDiv = work.DelayPaymentDiv;
            data.DeliveredGoodsDiv = work.DeliveredGoodsDiv;
            data.DeliveredGoodsDivNm = work.DeliveredGoodsDivNm;
            data.DemandAddUpSecCd = work.DemandAddUpSecCd;
            data.DepositAllowanceTtl = work.DepositAllowanceTtl;
            data.DepositAlwcBlnce = work.DepositAlwcBlnce;
            data.DetailRowCount = work.DetailRowCount;
            data.EdiSendDate = work.EdiSendDate;
            data.EdiTakeInDate = work.EdiTakeInDate;
            data.EnterpriseCode = work.EnterpriseCode;
            data.EraNameDispCd1 = work.EraNameDispCd1;
            data.EstimaTaxDivCd = work.EstimaTaxDivCd;
            data.EstimateDivide = work.EstimateDivide;
            data.EstimateFormNo = work.EstimateFormNo;
            data.EstimateFormPrtCd = work.EstimateFormPrtCd;
            data.EstimateNote1 = work.EstimateNote1;
            data.EstimateNote2 = work.EstimateNote2;
            data.EstimateNote3 = work.EstimateNote3;
            data.EstimateNote4 = work.EstimateNote4;
            data.EstimateNote5 = work.EstimateNote5;
            data.EstimateSubject = work.EstimateSubject;
            data.EstimateTitle1 = work.EstimateTitle1;
            data.EstimateTitle2 = work.EstimateTitle2;
            data.EstimateTitle3 = work.EstimateTitle3;
            data.EstimateTitle4 = work.EstimateTitle4;
            data.EstimateTitle5 = work.EstimateTitle5;
            data.EstimateValidityDate = work.EstimateValidityDate;
            data.Footnotes1 = work.Footnotes1;
            data.Footnotes2 = work.Footnotes2;
            data.FractionProcCd = work.FractionProcCd;
            data.FrontEmployeeCd = work.FrontEmployeeCd;
            data.FrontEmployeeNm = work.FrontEmployeeNm;
            data.FullModel = work.FullModel;
            data.HonorificTitle = work.HonorificTitle;
            data.InputAgenCd = work.InputAgenCd;
            data.InputAgenNm = work.InputAgenNm;
            data.ItdedPartsDisInTax = work.ItdedPartsDisInTax;
            data.ItdedPartsDisOutTax = work.ItdedPartsDisOutTax;
            data.ItdedSalesDisInTax = work.ItdedSalesDisInTax;
            data.ItdedSalesDisOutTax = work.ItdedSalesDisOutTax;
            data.ItdedSalesDisTaxFre = work.ItdedSalesDisTaxFre;
            data.ItdedSalesInTax = work.ItdedSalesInTax;
            data.ItdedSalesOutTax = work.ItdedSalesOutTax;
            data.ItdedWorkDisInTax = work.ItdedWorkDisInTax;
            data.ItdedWorkDisOutTax = work.ItdedWorkDisOutTax;
            data.ListPricePrintDiv = work.ListPricePrintDiv;
            data.LogicalDeleteCode = work.LogicalDeleteCode;
            data.MakerFullName = work.MakerFullName;
            data.ModelDesignationNo = work.ModelDesignationNo;
            data.ModelFullName = work.ModelFullName;
            data.OptionPringDivCd = work.OptionPringDivCd;
            data.OrderNumber = work.OrderNumber;
            data.OutputName = work.OutputName;
            data.PartsDiscountRate = work.PartsDiscountRate;
            data.PartsNoPrtCd = work.PartsNoPrtCd;
            data.PartySaleSlipNum = work.PartySaleSlipNum;
            data.PosReceiptNo = work.PosReceiptNo;
            data.PureGoodsTtlTaxExc = work.PureGoodsTtlTaxExc;
            data.RateUseCode = work.RateUseCode;
            data.RavorDiscountRate = work.RavorDiscountRate;
            data.ReconcileFlag = work.ReconcileFlag;
            data.RegiProcDate = work.RegiProcDate;
            data.ResultsAddUpSecCd = work.ResultsAddUpSecCd;
            data.RetGoodsReason = work.RetGoodsReason;
            data.RetGoodsReasonDiv = work.RetGoodsReasonDiv;
            data.SalAmntConsTaxInclu = work.SalAmntConsTaxInclu;
            data.SalesAreaCode = work.SalesAreaCode;
            data.SalesAreaName = work.SalesAreaName;
            data.SalesDate = work.SalesDate;
            data.SalesDisOutTax = work.SalesDisOutTax;
            data.SalesDisTtlTaxExc = work.SalesDisTtlTaxExc;
            data.SalesDisTtlTaxInclu = work.SalesDisTtlTaxInclu;
            data.SalesEmployeeCd = work.SalesEmployeeCd;
            data.SalesEmployeeNm = work.SalesEmployeeNm;
            data.SalesGoodsCd = work.SalesGoodsCd;
            data.SalesInpSecCd = work.SalesInpSecCd;
            data.SalesInputCode = work.SalesInputCode;
            data.SalesInputName = work.SalesInputName;
            data.SalesNetPrice = work.SalesNetPrice;
            data.SalesOutTax = work.SalesOutTax;
            data.SalesPriceFracProcCd = work.SalesPriceFracProcCd;
            data.SalesPrtSubttlExc = work.SalesPrtSubttlExc;
            data.SalesPrtSubttlInc = work.SalesPrtSubttlInc;
            data.SalesPrtTotalTaxExc = work.SalesPrtTotalTaxExc;
            data.SalesPrtTotalTaxInc = work.SalesPrtTotalTaxInc;
            data.SalesSlipCd = work.SalesSlipCd;
            data.SalesSlipNum = work.SalesSlipNum;
            data.SalesSlipPrintDate = work.SalesSlipPrintDate;
            data.SalesSubtotalTax = work.SalesSubtotalTax;
            data.SalesSubtotalTaxExc = work.SalesSubtotalTaxExc;
            data.SalesSubtotalTaxInc = work.SalesSubtotalTaxInc;
            data.SalesTotalTaxExc = work.SalesTotalTaxExc;
            data.SalesTotalTaxInc = work.SalesTotalTaxInc;
            data.SalesWorkSubttlExc = work.SalesWorkSubttlExc;
            data.SalesWorkSubttlInc = work.SalesWorkSubttlInc;
            data.SalesWorkTotalTaxExc = work.SalesWorkTotalTaxExc;
            data.SalesWorkTotalTaxInc = work.SalesWorkTotalTaxInc;
            data.SalSubttlSubToTaxFre = work.SalSubttlSubToTaxFre;
            data.SearchSlipDate = work.SearchSlipDate;
            data.SectionCode = work.SectionCode;
            data.SectionGuideNm = work.SectionGuideNm;
            data.ShipmentDay = work.ShipmentDay;
            data.SlipAddressDiv = work.SlipAddressDiv;
            data.SlipNote = work.SlipNote;
            data.SlipNote2 = work.SlipNote2;
            data.SlipNote3 = work.SlipNote3;
            data.SlipPrintDivCd = work.SlipPrintDivCd;
            data.SlipPrintFinishCd = work.SlipPrintFinishCd;
            data.SlipPrtSetPaperId = work.SlipPrtSetPaperId;
            data.StockGoodsTtlTaxExc = work.StockGoodsTtlTaxExc;
            data.SubSectionCode = work.SubSectionCode;
            data.SubSectionName = work.SubSectionName;
            data.TotalAmountDispWayCd = work.TotalAmountDispWayCd;
            data.TotalCost = work.TotalCost;
            data.TtlAmntDispRateApy = work.TtlAmntDispRateApy;
            data.UoeRemark1 = work.UoeRemark1;
            data.UoeRemark2 = work.UoeRemark2;
            #endregion // �R�s�[

            return data;
        }

        #region �e��敪���̂̎擾

        /// <summary>
        /// �󒍃X�e�[�^�X���̂��擾���܂��B
        /// </summary>
        /// <param name="code">�󒍃X�e�[�^�X</param>
        /// <returns>�󒍃X�e�[�^�X����</returns>
        public static string GetAcptAnOdrStatusName(int code, int estimateDivide)
        {
            switch (code)
            {
                case 10:
                    switch (estimateDivide)
                    {
                        case 2:
                            return "�P������";
                        case 3:
                            return "��������";
                        case 1:
                        default:
                            return "����";
                    }
                case 20:
                    return "��";
                case 30:
                    return "����";
                case 40:
                    return "�ݏo";
                default:
                    return "";
            }
        }

        /// <summary>
        /// �ԓ`�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">�ԓ`�敪</param>
        /// <returns>�ԓ`�敪����</returns>
        public static string GetDebitNoteDivName(int code)
        {
            switch (code)
            {
                case 0:
                    return "���`";
                case 1:
                    return "�ԓ`";
                case 2:
                    return "����";
                default:
                    return "";
            }
        }

        /// <summary>
        /// ����`�[�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">����`�[�敪</param>
        /// <returns>����`�[�敪����</returns>
        public static string GetSalesSlipCdName(int code)
        {
            switch (code)
            {
                case 0:
                    return "��������";
                case 1:
                    return "�����ԕi";
                case 2:
                    return "�l��";
                default:
                    return "";
            }
        }

        /// <summary>
        /// �������@���̂��擾���܂��B
        /// </summary>
        /// <param name="code">�������@�R�[�h</param>
        /// <returns>�������@����</returns>
        public static string GetWayToOrderName(int code)
        {
            switch (code)
            {
                case 0:
                    return "�X��";
                case 1:
                    return "�d�b";
                case 2:
                    return "FAX";
                case 3:
                    return "�C���^�[�l�b�g";
                case 4:
                    return "�V�X�e���A��";
                default:
                    return "";
            }
        }

        /// <summary>
        /// ���|�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">���|�敪</param>
        /// <returns>���|�敪����</returns>
        public static string GetAccRecDivName(int code)
        {
            switch (code)
            {
                case 0:
                    return "���|�Ȃ�";
                case 1:
                    return "���|����";
                default:
                    return "";
            }
        }

        /// <summary>
        /// ���z�\�����@�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">���z�\�����@�敪</param>
        /// <returns>���z�\�����@�敪����</returns>
        public static string GetTotalAmountDispWayName(int code)
        {
            switch (code)
            {
                case 0:
                    return "���Ȃ�";
                case 1:
                    return "����";
                default:
                    return "";
            }
        }

        /// <summary>
        /// ���㏤�i�敪���̂��擾���܂��B
        /// </summary>
        /// <param name="code">���㏤�i�敪</param>
        /// <returns>���㏤�i�敪����</returns>
        public static string GetSalesGoodsCdName(int code)
        {
            switch (code)
            {
                case 0:
                    {
                        return "���i";
                    }
                case 1:
                    {
                        return "���i�O";
                    }
                case 2:
                    {
                        return "����Œ���";
                    }
                case 3:
                    {
                        return "�c������";
                    }
                case 4:
                    {
                        return "���|�p����Œ���";
                    }
                case 5:
                    {
                        return "���|�p�c������";
                    }
                case 10:
                    {
                        return "���|�p����Œ���(����)";
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        #endregion // �e��敪���̂̎擾

        #endregion // Public Static Method

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        /// <summary>
        /// ����f�[�^�������ʃI�u�W�F�N�g���f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        private void CacheSalesSlipSearchResult(SalesSlipSearchResultWork data)
        {
            try
            {
                _dataSet.SalesSlip.AddSalesSlipRow(this.RowFromUIData(data));
            }
            catch (ConstraintException)
            {
            }
        }

        /// <summary>
        /// ����f�[�^(����)�������ʃI�u�W�F�N�g���f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        private void CacheSalesSlipDetailSearchResult(SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip)
        {
            try
            {
                _dataSet.SalesDetail.AddSalesDetailRow(this.DetailRowFromUIData(data, slip));
            }
            catch (ConstraintException)
            {
            }
        }


        /// <summary>
        /// ����f�[�^�������ʃI�u�W�F�N�g���甄��f�[�^�������ʍs�N���X���擾���܂��B
        /// </summary>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        /// <returns>����f�[�^�������ʍs�N���X</returns>
        private SimpleInqCTIDataSet.SalesSlipRow RowFromUIData(SalesSlipSearchResultWork data)
        {
            SimpleInqCTIDataSet.SalesSlipRow row = _dataSet.SalesSlip.NewSalesSlipRow();

            this.SetRowFromUIData(ref row, data);
            return row;
        }

        /// <summary>
        /// ����f�[�^(����)�������ʃI�u�W�F�N�g���甄��f�[�^�������ʍs�N���X���擾���܂��B
        /// </summary>
        /// <param name="data">����f�[�^�������ʃI�u�W�F�N�g</param>
        /// <returns>����f�[�^�������ʍs�N���X</returns>
        private SimpleInqCTIDataSet.SalesDetailRow DetailRowFromUIData(SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip)
        {
            SimpleInqCTIDataSet.SalesDetailRow row = _dataSet.SalesDetail.NewSalesDetailRow();

            this.SetDetailRowFromUIData(ref row, data, slip);
            return row;
        }

        private Employee SearchStatic(string employeeCode)
        {
            return _employeeList.Find(
                delegate(Employee emp)
                {
                    return ( emp.EmployeeCode.Trim().Equals(employeeCode.Trim()) );
                });
        }

        /// <summary>
        /// ����f�[�^�������ʃ��[�N������f�[�^�s�N���X�ݒ菈��
        /// </summary>
        /// <param name="row">����f�[�^�s�N���X</param>
        /// <param name="data">����f�[�^�������ʃ��[�N�I�u�W�F�N�g</param>
        private void SetRowFromUIData(ref SimpleInqCTIDataSet.SalesSlipRow row, SalesSlipSearchResultWork data)    // MEMO:�������ʂ�ێ�
        {
            #region ���ڃR�s�[
            long salesTotalTaxExc;
            long salesSubtotalTax;
            long salesTotalTaxInc;

            // taxIsSum = true(�\������̂͊O�Ł{����), false(���ł̂�)
            bool taxIsSum;
            # region [taxIsSum]
            switch (data.TotalAmountDispWayCd)
            {
                case 1:
                    {
                        // ���z�\������
                        taxIsSum = true;
                    }
                    break;
                case 0:
                default:
                    {
                        // ���z�\�����Ȃ�

                        switch (data.ConsTaxLayMethod)
                        {
                            // 0:�`�[�P��
                            case 0:
                            // 1:���גP��
                            case 1:
                                {
                                    taxIsSum = true;
                                }
                                break;
                            // 2:�����e
                            case 2:
                            // 3:�����q
                            case 3:
                            // 9:��ې�
                            case 9:
                            default:
                                {
                                    taxIsSum = false;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            if (taxIsSum)
            {
                // �Ł��O�Ł{����
                salesTotalTaxExc = data.SalesTotalTaxExc;
                salesSubtotalTax = data.SalesSubtotalTax;
                salesTotalTaxInc = data.SalesTotalTaxInc;
            }
            else
            {
                // �Ł�����
                salesTotalTaxExc = data.SalesTotalTaxExc;
                salesSubtotalTax = data.SalAmntConsTaxInclu + data.SalesDisTtlTaxInclu;
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }

            # region [���㏤�i�敪]
            if (( data.SalesGoodsCd == 2 ) || ( data.SalesGoodsCd == 4 ))
            {
                // 2:����Œ���,4:���|�p����Œ���
                salesTotalTaxExc = 0;
            }
            else if (( data.SalesGoodsCd == 3 ) || ( data.SalesGoodsCd == 5 ))
            {
                // 3:�c������,5:���|�p�c������
                salesTotalTaxExc = salesTotalTaxInc;
                salesSubtotalTax = 0;
            }
            # endregion

            // �l���Z�b�g
            row.SalesTotalTaxExc = salesTotalTaxExc;
            row.SalesSubtotalTax = salesSubtotalTax;
            row.SalesTotalTaxInc = salesTotalTaxInc;

            row.RowNo = _rowNo;
            row.EnterpriseCode = data.EnterpriseCode;

            row.AcptAnOdrStatus = data.AcptAnOdrStatus;
            row.AcptAnOdrStatusName = GetAcptAnOdrStatusName(data.AcptAnOdrStatus, data.EstimateDivide);
            row.SearchSlipNum = data.SalesSlipNum;
            row.DebitNoteDiv = data.DebitNoteDiv;
            row.DebitNoteDivName = GetDebitNoteDivName(data.DebitNoteDiv);
            row.SalesSlipCd = data.SalesSlipCd;
            row.SalesSlipCdName = GetSalesSlipCdName(data.SalesSlipCd);

            // �`�[���t (�`�[��ʂɏ]��(���ז�))
            if (data.AcptAnOdrStatus == 40)
            {
                // �ݏo �� �o�ד����Z�b�g����
                row.SlipDateString = GetDateTimeString(data.ShipmentDay, ct_DateFormat);
            }
            else
            {
                // �ݏo�ȊO �� ��������Z�b�g����
                row.SlipDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);
            }

            // �o�ד�
            row.ShipmentDayString = GetDateTimeString(data.ShipmentDay, ct_DateFormat);
            // �����
            row.SalesDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);
            // �v���
            row.AddUpADateString = GetDateTimeString(data.AddUpADate, ct_DateFormat);

            row.FrontEmployeeNm = data.FrontEmployeeNm;
            row.SalesEmployeeNm = data.SalesEmployeeNm;
            row.AccRecDivCd = data.AccRecDivCd;
            row.AccRecDivName = GetAccRecDivName(data.AccRecDivCd);
            row.TotalAmountDispWayCd = data.TotalAmountDispWayCd;
            row.TotalAmountDispWayName = GetTotalAmountDispWayName(data.TotalAmountDispWayCd);

            row.TotalCost = data.TotalCost;
            row.SalesGoodsCd = data.SalesGoodsCd;
            row.SalesGoodsCdName = GetSalesGoodsCdName(data.SalesGoodsCd);
            row.ClaimCode = data.ClaimCode;
            row.ClaimName = data.ClaimSnm;
            row.CustomerCode = data.CustomerCode;
            row.CustomerName = data.CustomerName + " " + data.CustomerName2;
            row.SlipNote = data.SlipNote;
            row.SlipNote2 = data.SlipNote2;

            row.SearchSlipDate = data.SearchSlipDate;
            row.EstimateDivide = data.EstimateDivide;

            row.DetailRowCount = data.DetailRowCount;

            row.SectionName = data.SectionGuideNm;
            row.SubSectionName = data.SubSectionName;

            // �V�K���ǉ�����
            row.InputAgenCd = data.InputAgenCd;
            row.InputAgenNm = data.InputAgenNm;
            row.SalesPrtTotalTaxInc = data.SalesPrtTotalTaxInc;
            row.SalesPrtTotalTaxExc = data.SalesPrtTotalTaxExc;
            row.SalesWorkTotalTaxInc = data.SalesWorkTotalTaxInc;
            row.SalesWorkTotalTaxExc = data.SalesWorkTotalTaxExc;
            row.SalesPrtSubttlInc = data.SalesPrtSubttlInc;
            row.SalesPrtSubttlExc = data.SalesPrtSubttlExc;
            row.SalesWorkSubttlInc = data.SalesWorkSubttlInc;
            row.SalesWorkSubttlExc = data.SalesWorkSubttlExc;
            row.SalesNetPrice = data.SalesNetPrice;
            row.SalesOutTax = data.SalesOutTax;
            row.ItdedPartsDisOutTax = data.ItdedPartsDisOutTax;
            row.ItdedPartsDisInTax = data.ItdedPartsDisInTax;
            row.ItdedWorkDisOutTax = data.ItdedWorkDisOutTax;
            row.ItdedWorkDisInTax = data.ItdedWorkDisInTax;
            row.ItdedSalesDisTaxFre = data.ItdedSalesDisTaxFre;
            row.PartsDiscountRate = data.PartsDiscountRate;
            row.RavorDiscountRate = data.RavorDiscountRate;
            row.OutputName = data.OutputName;
            row.CustSlipNo = data.CustSlipNo;
            row.SlipNote3 = data.SlipNote3;
            row.EstimateValidityDateString = GetDateTimeString(data.EstimateValidityDate, ct_DateFormat);
            row.PartsNoPrtCd = data.PartsNoPrtCd;
            row.OptionPringDivCd = data.OptionPringDivCd;
            row.RateUseCode = data.RateUseCode;

            // ���s��
            row.SalesInputCode = data.SalesInputCode;          // �R�[�h
            row.SalesInputName = data.SalesInputName;          // �\����

            // �ޕʌ^�� (�^���w��ԍ�+�ޕʔԍ�)
            # region [�ޕʌ^�� 00000-0000]
            if (data.ModelDesignationNo == 0 && data.CategoryNo == 0)
            {
                row.CategoryModel = string.Empty;
            }
            else
            {
                row.CategoryModel = string.Empty;

                // �^���w��ԍ�
                if (data.ModelDesignationNo == 0)
                {
                    row.CategoryModel += new string(' ', 5);
                }
                else
                {
                    row.CategoryModel += data.ModelDesignationNo.ToString("00000");
                }

                // �n�C�t��
                row.CategoryModel += '-';

                // �ޕʔԍ�
                if (data.CategoryNo == 0)
                {
                }
                else
                {
                    row.CategoryModel += data.CategoryNo.ToString("0000");
                }
            }
            # endregion

            // �Ԏ햼��
            row.ModelFullName = data.ModelFullName;

            // �^��
            row.FullModel = data.FullModel;
            // �v���
            row.AddUpADateString = GetDateTimeString(data.AddUpADate, ct_DateFormat);
            // ���}�[�N1
            row.UoeRemark1 = data.UoeRemark1;
            // �Ǘ��ԍ�
            row.CarMngCode = data.CarMngCode;
            // �`�[�敪
            // ��������(data.EstimateDivide == 3)�̎��͋�
            if (data.EstimateDivide != 3)
            {
                switch (data.SalesSlipCd)
                {
                    case 0: //0:����
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "��������";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|����";
                        }
                        break;

                    case 1: //1:�ԕi
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "�����ԕi";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|�ԕi";
                        }
                        break;

                    case 2: //2:�l��
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "�l��";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|�l��";
                        }
                        break;

                    case 100: //100:��������
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "��������";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|��������";
                        }
                        break;

                    case 101: //101:�����ԕi
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "�����ԕi";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|�����ԕi";
                        }
                        break;

                    case 102: //102:�����l��
                        if (data.AccRecDivCd == 0) // 0:���|�Ȃ�
                        {
                            row.SlipDivName = "�����l��";
                        }
                        else // 1:���|
                        {
                            row.SlipDivName = "�|�����l��";
                        }
                        break;

                    default:
                        break;
                }
            }
            row.SalesSlipSearchResultWork = data;

            row.CarMngCode = data.CarMngCode;

            #endregion // ���ڃR�s�[
        }


        /// <summary>
        /// ����f�[�^�������ʃ��[�N������f�[�^�s�N���X�ݒ菈��
        /// </summary>
        /// <param name="row">����f�[�^�s�N���X</param>
        /// <param name="data">����f�[�^�������ʃ��[�N�I�u�W�F�N�g</param>
        private void SetDetailRowFromUIData(ref SimpleInqCTIDataSet.SalesDetailRow row, SalesSlipDetailSearchResultWork data, SalesSlipSearchResult slip)
        {
            #region ���ڃR�s�[

            long salesMoneyTaxExc;
            long salsePriceConsTax;
            long salesMoneyTaxInc;

            bool printTax = true;

            # region [printTax]
            switch (GetTaxPrintType(slip))
            {
                case 0:
                default:
                    {
                        // �`�[�P�ʁi���ז��̏���ł͕\�����Ȃ��j
                        printTax = false;
                    }
                    break;
                case 1:
                    {
                        // ���גP��/���z�\��
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        // �����e�q�E��ېŁi�ېŋ敪�����ł̂ݕ\���j
                        // �ېŋ敪�i0:�ې�,1:��ې�,2:�ېŁi���Łj�j
                        switch (data.TaxationDivCd)
                        {
                            case 0:
                            case 1:
                            default:
                                {
                                    printTax = false;
                                }
                                break;
                            case 2:
                                {
                                    printTax = true;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            if (printTax)
            {
                // �ŕ\��
                salesMoneyTaxExc = data.SalesMoneyTaxExc;
                salsePriceConsTax = data.SalesMoneyTaxInc - data.SalesMoneyTaxExc;
                salesMoneyTaxInc = data.SalesMoneyTaxInc;
            }
            else
            {
                // �Ŕ�\��
                salesMoneyTaxExc = data.SalesMoneyTaxExc;
                salsePriceConsTax = 0;
                salesMoneyTaxInc = salesMoneyTaxExc;
            }

            # region [���㏤�i�敪]
            if (( slip.SalesGoodsCd == 2 ) || ( slip.SalesGoodsCd == 4 ))
            {
                // 2:����Œ���,4:���|�p����Œ���
                salesMoneyTaxExc = 0;
            }
            else if (( slip.SalesGoodsCd == 3 ) || ( slip.SalesGoodsCd == 5 ))
            {
                // 3:�c������,5:���|�p�c������
                salesMoneyTaxExc = salesMoneyTaxInc;
                salsePriceConsTax = 0;
            }
            # endregion


            // �l���Z�b�g
            row.SalesMoneyTaxExc = salesMoneyTaxExc;
            row.SalsePriceConsTax = salsePriceConsTax;
            row.SalesMoneyTaxInc = salesMoneyTaxInc;

            row.AcptAnOdrStatus = data.AcptAnOdrStatus;
            row.SalesSlipNum = data.SalesSlipNum;
            row.SalesRowNo = data.SalesRowNo;
            row.SectionCode = data.SectionCode;
            row.SubSectionCode = data.SubSectionCode;

            row.SalesDateString = GetDateTimeString(data.SalesDate, ct_DateFormat);

            row.CommonSeqNo = data.CommonSeqNo;
            row.SalesSlipDtlNum = data.SalesSlipDtlNum;
            row.AcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
            row.SalesSlipDtlNumSrc = data.SalesSlipDtlNumSrc;
            row.SalesSlipCdDtl = data.SalesSlipCdDtl;

            row.DeliGdsCmpltDueDateString = GetDateTimeString(data.DeliGdsCmpltDueDate, ct_DateFormat);

            row.GoodsKindCode = data.GoodsKindCode;
            row.GoodsMakerCd = data.GoodsMakerCd;
            row.MakerName = data.MakerName;
            row.GoodsNo = data.GoodsNo;
            row.GoodsName = data.GoodsName;
            row.BLGoodsCode = data.BLGoodsCode;
            row.BLGoodsFullName = data.BLGoodsFullName;
            row.EnterpriseGanreCode = data.EnterpriseGanreCode;
            row.EnterpriseGanreName = data.EnterpriseGanreName;
            row.WarehouseCode = data.WarehouseCode;
            row.WarehouseName = data.WarehouseName;
            row.WarehouseShelfNo = data.WarehouseShelfNo;
            row.SalesOrderDivCd = data.SalesOrderDivCd;
            row.GoodsRateRank = data.GoodsRateRank;
            row.CustRateGrpCode = data.CustRateGrpCode;
            row.ListPriceRate = data.ListPriceRate;
            row.RateDivLPrice = data.RateDivLPrice;
            row.UnPrcCalcCdLPrice = data.UnPrcCalcCdLPrice;
            row.PriceCdLPrice = data.PriceCdLPrice;
            row.StdUnPrcLPrice = data.StdUnPrcLPrice;
            row.FracProcUnitLPrice = data.FracProcUnitLPrice;
            row.FracProcLPrice = data.FracProcLPrice;
            row.ListPriceTaxIncFl = data.ListPriceTaxIncFl;
            row.ListPriceTaxExcFl = data.ListPriceTaxExcFl;
            row.ListPriceChngCd = data.ListPriceChngCd;
            row.SalesRate = data.SalesRate;
            row.RateDivSalUnPrc = data.RateDivSalUnPrc;
            row.UnPrcCalcCdSalUnPrc = data.UnPrcCalcCdSalUnPrc;
            row.PriceCdSalUnPrc = data.PriceCdSalUnPrc;
            row.StdUnPrcSalUnPrc = data.StdUnPrcSalUnPrc;
            row.FracProcUnitSalUnPrc = data.FracProcUnitSalUnPrc;
            row.FracProcSalUnPrc = data.FracProcSalUnPrc;
            row.SalesUnPrcTaxIncFl = data.SalesUnPrcTaxIncFl;
            row.SalesUnPrcTaxExcFl = data.SalesUnPrcTaxExcFl;
            row.SalesUnPrcChngCd = data.SalesUnPrcChngCd;
            row.CostRate = data.CostRate;
            row.RateDivUnCst = data.RateDivUnCst;
            row.UnPrcCalcCdUnCst = data.UnPrcCalcCdUnCst;
            row.PriceCdUnCst = data.PriceCdUnCst;
            row.StdUnPrcUnCst = data.StdUnPrcUnCst;
            row.FracProcUnitUnCst = data.FracProcUnitUnCst;
            row.FracProcUnCst = data.FracProcUnCst;
            row.SalesUnitCost = data.SalesUnitCost;
            row.SalesUnitCostChngDiv = data.SalesUnitCostChngDiv;
            row.ShipmentCnt = data.ShipmentCnt;


            row.Cost = data.Cost;
            row.GrsProfitChkDiv = data.GrsProfitChkDiv;
            row.SalesGoodsCd = data.SalesGoodsCd;
            row.TaxationDivCd = data.TaxationDivCd;
            row.PartySlipNumDtl = data.PartySlipNumDtl;
            row.DtlNote = data.DtlNote;
            row.SupplierCd = data.SupplierCd;
            row.SupplierSnm = data.SupplierSnm;
            row.OrderNumber = data.OrderNumber;
            row.AcceptAnOrderCnt = data.AcceptAnOrderCnt;
            row.AcptAnOdrAdjustCnt = data.AcptAnOdrAdjustCnt;
            row.AcptAnOdrRemainCnt = data.AcptAnOdrRemainCnt;
            row.SlipMemo1 = data.SlipMemo1;
            row.SlipMemo2 = data.SlipMemo2;
            row.SlipMemo3 = data.SlipMemo3;
            row.InsideMemo1 = data.InsideMemo1;
            row.InsideMemo2 = data.InsideMemo2;
            row.InsideMemo3 = data.InsideMemo3;
            row.BfListPrice = data.BfListPrice;
            row.BfSalesUnitPrice = data.BfSalesUnitPrice;
            row.BfUnitCost = data.BfUnitCost;

            // �V�K���ǉ�
            row.SalesRowDerivNo = data.SalesRowDerivNo;
            row.GoodsSearchDivCd = data.GoodsSearchDivCd;
            row.GoodsLGroup = data.GoodsLGroup;
            row.GoodsLGroupName = data.GoodsLGroupName;
            row.GoodsMGroup = data.GoodsMGroup;
            row.GoodsMGroupName = data.GoodsMGroupName;
            row.BLGroupCode = data.BLGroupCode;
            row.BLGroupName = data.BLGroupName;
            row.PrtBLGoodsCode = data.PrtBLGoodsCode;
            row.PrtBLGoodsName = data.PrtBLGoodsName;
            row.SalesCode = data.SalesCode;
            row.SalesCdNm = data.SalesCdNm;
            row.WorkManHour = data.WorkManHour;
            row.WayToOrder = data.WayToOrder;

            // �������z(�����P�� * ���㐔)
            row.SalesUnitTotal = data.SalesUnitCost * data.AcceptAnOrderCnt;

            #endregion // ���ڃR�s�[
        }

        #endregion // Private Method

        // ===================================================================================== //
        // �v���C�x�[�g�X�^�e�B�b�N���\�b�h
        // ===================================================================================== //
        #region �� Private Static Method

        /// <summary>
        /// �����[�g�p�̃p�����[�^��UI�f�[�^����쐬���܂��B
        /// </summary>
        /// <param name="data"></param>
        /// <param name="extractSlipCdType"></param>
        /// <param name="showEstimateInput"></param>
        /// <returns></returns>
        private static SalesSlipSearchWork CreateParamDataFromUIData(SalesSlipSearch data, int extractSlipCdType, bool showEstimateInput)
        {
            SalesSlipSearchWork work = new SalesSlipSearchWork();

            #region ���ڃR�s�[

            // �S��
            if (data.SalesSlipCd == -1)
            {
                // MEMO �b��I�Ɂu�������ρv+�u�S�āv�̏ꍇ�͔���`�[�敪=0�ō쐬
                if (data.AcptAnOdrStatus == 16)
                {
                    work.SalesSlipCd = 0;
                }
                else
                {
                    work.SalesSlipCd = -1;
                }
                work.AccRecDivCd = -1;
            }
            //��������
            else if (data.SalesSlipCd == 100)
            {
                work.SalesSlipCd = 0;
                work.AccRecDivCd = 0;
            }
            //�����ԕi
            else if (data.SalesSlipCd == 101)
            {
                work.SalesSlipCd = 1;
                work.AccRecDivCd = 0;
            }
            //�|����E�|�ԕi
            else
            {
                work.SalesSlipCd = data.SalesSlipCd;
                work.AccRecDivCd = 1;
            }

            //�P������
            if (data.AcptAnOdrStatus == 15)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 2;
            }
            else if (data.AcptAnOdrStatus == 10)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 1;
            }
            // ��������
            else if (data.AcptAnOdrStatus == 16)
            {
                work.AcptAnOdrStatus = 10;
                work.EstimateDivide = 3;
            }
            //���̑�
            else
            {
                work.AcptAnOdrStatus = data.AcptAnOdrStatus;
                work.EstimateDivide = 0;
            }

            if (extractSlipCdType == 1)
            {
                work.SalesSlipCd = 0;
            }

            if (showEstimateInput == false)
            {
                work.EstimateDivide = -1;
            }

            work.ClaimCode = data.ClaimCode;
            work.CustomerCode = data.CustomerCode;
            work.EnterpriseCode = data.EnterpriseCode;
            work.FrontEmployeeCd = data.FrontEmployeeCd;
            work.SalesEmployeeCd = data.SalesEmployeeCd;
            work.GoodsMakerCd = data.GoodsMakerCd;
            work.GoodsNo = data.GoodsNo;

            work.SalesDateSt = GetLongDate(data.SalesDateSt);
            work.SalesDateEd = GetLongDate(data.SalesDateEd);
            work.ShipmentDaySt = GetLongDate(data.SalesDateSt); // �o�ד���������ɔ�������Z�b�g
            work.ShipmentDayEd = GetLongDate(data.SalesDateEd); // �o�ד���������ɔ�������Z�b�g

            work.SalesInputCode = data.SalesInputCode;

            work.SalesSlipNumSt = data.SalesSlipNumSt;
            work.SalesSlipNumEd = data.SalesSlipNumEd;
            work.PartySaleSlipNum = data.PartySaleSlipNum;

            if (data.SearchSlipDateSt == DateTime.MinValue) work.SearchSlipDateSt = 0;
            else work.SearchSlipDateSt = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SearchSlipDateSt);
            if (data.SearchSlipDateEd == DateTime.MinValue) work.SearchSlipDateEd = 0;
            else work.SearchSlipDateEd = TDateTime.DateTimeToLongDate("YYYYMMDD", data.SearchSlipDateEd);

            try
            {
                if (Int32.Parse(data.SectionCode.Trim()) == 0)
                {
                    work.SectionCode = string.Empty;
                }
                else
                {
                    work.SectionCode = data.SectionCode;
                }
            }
            catch
            {
                work.SectionCode = data.SectionCode;
            }
            work.SubSectionCode = data.SubSectionCode;
            // �^��*�Ή�
            string searchText;
            int searchType;
            GetSearchType(data.FullModel, out searchText, out searchType);
            work.FullModel = searchText;
            work.FullModelSrchTyp = searchType;

            #endregion

            return work;
        }

        /// <summary>
        /// ���t���l�擾����
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetLongDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return ( ( date.Year * 10000 ) + ( date.Month * 100 ) + ( date.Day ) );
            }
        }

        /// <summary>
        /// UI�f�[�^�I�u�W�F�N�g����p�����[�^�I�u�W�F�N�g�𐶐����܂��B
        /// </summary>
        /// <param name="data">UI�f�[�^�I�u�W�F�N�g</param>
        /// <returns>�p�����[�^�I�u�W�F�N�g</returns>
        private static SalesSlipDetailSearchWork CreateDetailParamDataFromUIData(SalesSlipDetailSearch data)
        {
            SalesSlipDetailSearchWork work = new SalesSlipDetailSearchWork();

            work.EnterpriseCode = data.EnterpriseCode;
            work.AcptAnOdrStatus = data.AcptAnOdrStatus;
            work.SalesSlipNum = data.SalesSlipNum;
            return work;
        }

        /// <summary>
        /// ���t��������擾���܂��B
        /// </summary>
        /// <param name="date">���t</param>
        /// <param name="format">�t�H�[�}�b�g������</param>
        /// <returns>���t������</returns>
        private static string GetDateTimeString(DateTime date, string format)
        {
            if (date == DateTime.MinValue)
            {
                return "";
            }
            else
            {
                return date.ToString(format);
            }
        }

        /// <summary>
        /// �����񂠂��܂��������擾
        /// </summary>
        /// <param name="originText">���̓��͕�����</param>
        /// <param name="searchText">�����[�g�A�Z���u���ɓn������������</param>
        /// <param name="searchType">�����[�g�A�Z���u���ɓn�������^�C�v</param>
        /// <returns></returns>
        private static void GetSearchType(string originText, out string searchText, out int searchType)
        {
            searchText = originText;
            bool stLike = originText.StartsWith("*");
            bool edLike = originText.EndsWith("*");

            if (stLike)
            {
                // �擪�� * ����菜��
                searchText = searchText.Substring(1);
            }
            if (edLike)
            {
                // ������ * ����菜��
                searchText = searchText.Substring(0, searchText.Length - 1);
            }

            // �擪��������*����菜���Ă��܂�*������ꍇ��3:�����܂�
            if (searchText.Contains("*"))
            {
                searchText = searchText.Replace("*", "");
                searchType = 3;
                return;
            }


            // �����^�C�v�̔���
            if (stLike)
            {
                if (edLike)
                {
                    // 3:�����܂�
                    searchType = 3;
                }
                else
                {
                    // 2:�����v
                    searchType = 2;
                }
            }
            else
            {
                if (edLike)
                {
                    // 1:�O����v
                    searchType = 1;
                }
                else
                {
                    // 0:���S��v
                    searchType = 0;
                }
            }
        }

        /// <summary>
        /// ����ŕ\���^�C�v�擾
        /// </summary>
        /// <param name="slipWork"></param>
        /// <returns>TaxPrintType�i0:�`�[�P��, 1:���גP��/���z�\������, 2:�����e/�����q/��ېŁj</returns>
        private static int GetTaxPrintType(SalesSlipSearchResult slip)
        {
            // ���z�\�����@
            switch (slip.TotalAmountDispWayCd)
            {
                case 1:
                    // ���z�\������
                    return 1;
                case 0:
                default:
                    // ���z�\�����Ȃ�
                    switch (slip.ConsTaxLayMethod)
                    {
                        // 0:�`�[�P��
                        case 0:
                            return 0;
                        // 1:���גP��
                        case 1:
                            return 1;
                        // 2:�����e
                        case 2:
                        // 3:�����q
                        case 3:
                        // 9:��ې�
                        case 9:
                        default:
                            return 2;
                    }
            }
        }
        #endregion // Private Static Method
    }
}
