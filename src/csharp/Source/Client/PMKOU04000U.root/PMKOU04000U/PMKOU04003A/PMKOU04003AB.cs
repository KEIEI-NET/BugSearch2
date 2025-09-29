//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d����d�q�����s�A�N�Z�X�N���X
// �v���O�����T�v   : �d����d�q�����Ŏg�p����A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI��c �W�v
// �C �� ��  2013/01/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI�y�~ �їR��
// �C �� ��  2013/03/01  �C�����e : �V�X�e���e�X�g��QNo233�Ή�
//                                  �ԕi�v��^�u�̒I�ԏ����Z�b�g����悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : 杍^
// �C �� ��  2014/01/07  �C�����e : Redmine#41771 �d���`�[���͏����8%���őΉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    public partial class SuppPtrStockDetailAcs
    {

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SuppPtrStockDetailAcs()
        {
            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �����_�R�[�h�擾
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

            //�d���ԕi�v��X�V���i�̃C���X�^���X�擾
            this._stockSlipRetPlnAcs = StockSlipRetPlnAcs.GetInstance();

            // �f�[�^�Z�b�g���쐬
            this._detailDataSet = new SuppPtrStcDetailDataSet();

            // �d����}�X�^�A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();

            // �d�����z�����ݒ�A�N�Z�X�N���X
            this._stockProcMoneyAcs = new StockProcMoneyAcs();

            // �d�����z�����敪�ݒ胊�X�g�擾
            this.GetStockProcMonyList();

            // �d�����z�Z�o���W���[��
            this._stockPriceCalculate = new StockPriceCalculate();
            this._stockPriceCalculate.CacheStockProcMoneyList(this._stockProcMoneyList);

            // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
            this._taxRateSetAcs = new TaxRateSetAcs();
        }

        #endregion // �R���X�g���N�^

        # region enum
        /// <summary>
        /// ���z�\�����@�敪
        /// </summary>
        internal enum TotalAmountDispWayCd : int
        {
            /// <summary>���z�\�����Ȃ�</summary>
            NoTotalAmount = 0,
            /// <summary>���z�\������</summary>
            TotalAmount = 1,
        }
        /// <summary>
        /// ����œ]�ŕ���
        /// </summary>
        internal enum ConsTaxLayMethod : int
        {
            /// <summary>�`�[�]��</summary>
            SlipLay = 0,
            /// <summary>���ד]��</summary>
            DetailLay = 1,
            /// <summary>�����e</summary>
            DemandParentLay = 2,
            /// <summary>�����q</summary>
            DemandChildLay = 3,
            /// <summary>��ې�</summary>
            TaxExempt = 9,
        }
        /// <summary>
        /// �d���`�[�敪�i���ׁj
        /// </summary>
        internal enum StockSlipCdDtl : int
        {
            /// <summary>�d��</summary>
            Stock = 0,
            /// <summary>�ԕi</summary>
            RetGoods = 1,
            /// <summary>�l��</summary>
            Discount = 2,
        }
        /// <summary>
        /// ���i�敪
        /// </summary>
        internal enum SalesGoodsCd : int
        {
            /// <summary>���i</summary>
            Goods = 0,
            /// <summary>���i�O</summary>
            NonGoods = 1,
            /// <summary>����Œ���</summary>
            ConsTaxAdjust = 2,
            /// <summary>�c������</summary>
            BalanceAdjust = 3,
            /// <summary>���|�p����Œ���</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>���|�p�c������</summary>
            AccRecBalanceAdjust = 5,
        }
        # endregion

        # region const
        /// <summary>�[�������Ώۋ��z�敪�i������z�j</summary>
        internal const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
        internal const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>�[�������Ώۋ��z�敪�i����P���j</summary>
        internal const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        # endregion

        # region struct
        # region [�d���`�[�_��KEY]
        /// <summary>
        /// �d���`�[�_��KEY
        /// </summary>
        private struct StockSlipLogicalKey
        {
            /// <summary>��ƃR�[�h</summary>
            private string _enterpriseCode;
            /// <summary>�d����</summary>
            private int _supplierCd;
            /// <summary>�d����</summary>
            private DateTime _stockDate;
            /// <summary>�`�[�敪</summary>
            private int _supplierSlipCd;
            /// <summary>�`�[�ԍ�</summary>
            private string _partySaleSlipNum;
            /// <summary>���_�R�[�h</summary>
            private string _sectionCode;

            /// <summary>
            /// ��ƃR�[�h
            /// </summary>
            public string EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }
            /// <summary>
            /// �d����
            /// </summary>
            public int SupplierCd
            {
                get { return _supplierCd; }
                set { _supplierCd = value; }
            }
            /// <summary>
            /// �d����
            /// </summary>
            public DateTime StockDate
            {
                get { return _stockDate; }
                set { _stockDate = value; }
            }
            /// <summary>
            /// �`�[�敪
            /// </summary>
            public int SupplierSlipCd
            {
                get { return _supplierSlipCd; }
                set { _supplierSlipCd = value; }
            }
            /// <summary>
            /// �`�[�ԍ�
            /// </summary>
            /// <remarks>�����̓`�[�ԍ�</remarks>
            public string PartySaleSlipNum
            {
                get { return _partySaleSlipNum; }
                set { _partySaleSlipNum = value; }
            }
            /// <summary>
            /// ���_�R�[�h
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="enterpriseCode">��ƃR�[�h</param>
            /// <param name="supplierCd">�d����</param>
            /// <param name="stockDate">�d����</param>
            /// <param name="supplierSlipCd">�`�[�敪</param>
            /// <param name="partySaleSlipNum">�`�[�ԍ�</param>
            /// <param name="sectionCode">���_�R�[�h</param>
            public StockSlipLogicalKey(string enterpriseCode, int supplierCd, DateTime stockDate, int supplierSlipCd, string partySaleSlipNum, string sectionCode)
            {
                _enterpriseCode = enterpriseCode;
                _supplierCd = supplierCd;
                _stockDate = stockDate;
                _supplierSlipCd = supplierSlipCd;
                _partySaleSlipNum = partySaleSlipNum;
                _sectionCode = sectionCode;
            }
        }
        # endregion
        # region [���iKEY]
        /// <summary>
        /// ���iKEY
        /// </summary>
        private struct GoodsKey
        {
            /// <summary>�i��</summary>
            private string _goodsNo;
            /// <summary>���[�J�[</summary>
            private int _goodsMakerCd;
            /// <summary>
            /// �i��
            /// </summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>
            /// ���[�J�[
            /// </summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="goodsNo">�i��</param>
            /// <param name="goodsMakerCd">���[�J�[</param>
            public GoodsKey(string goodsNo, int goodsMakerCd)
            {
                _goodsNo = goodsNo;
                _goodsMakerCd = goodsMakerCd;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="goodsUnitData">���i</param>
            public GoodsKey(GoodsUnitData goodsUnitData)
            {
                _goodsNo = goodsUnitData.GoodsNo;
                _goodsMakerCd = goodsUnitData.GoodsMakerCd;
            }
        }
        # endregion
        # endregion

        # region class
        # region [�ԓ`�o�^�p�����[�^]
        /// <summary>
        /// �ԓ`�o�^�p�����[�^
        /// </summary>
        public class RedSlipWriteParameter
        {
            /// <summary>��ƃR�[�h</summary>
            private string _enterpriseCode;
            /// <summary>�`�[�敪</summary>
            private int _slipCd;
            /// <summary>���͏]�ƈ��R�[�h</summary>
            private string _inputEmployeeCd;
            /// <summary>���͏]�ƈ�����</summary>
            private string _inputEmployeeNm;
            /// <summary>�����</summary>
            private DateTime _salesDate;
            /// <summary>�萔����(���)</summary>
            private double _feeRateOfOrder;
            /// <summary>�萔���z(���)</summary>
            private Int64 _feePriceOfOrder;
            /// <summary>�萔����(�݌�)</summary>
            private double _feeRateOfStock;
            /// <summary>�萔���z(�݌�)</summary>
            private Int64 _feePriceOfStock;
            /// <summary>�萔����(���v)</summary>
            private double _feeRateOfTotal;
            /// <summary>�萔���z(���v)</summary>
            private Int64 _feePriceOfTotal;
            /// <summary>�̔��敪</summary>
            private Int32 _salesCodeDiv;
            /// <summary>���Ӑ撍��</summary>
            private string _partySalesSlipNo;
            /// <summary>���l�P</summary>
            private string _slipNote;
            /// <summary>���l�Q</summary>
            private string _slipNote2;
            /// <summary>���l�R</summary>
            private string _slipNote3;
            /// <summary>�ԕi���R</summary>
            private string _returnReason;
            /// <summary>�ԕi���R�R�[�h</summary>
            private Int32 _returnReasonDiv;
            /// <summary>���_�R�[�h</summary>
            private string _sectionCode;
            /// <summary>���Ӑ�R�[�h</summary>
            private int _customerCode;
            /// <summary>�ԗ����s����</summary>
            private int _mileage;
            /// <summary>���q���l</summary>
            private string _carNote;

            /// <summary>
            /// ���q���l
            /// </summary>
            public string CarNote
            {
                get { return _carNote; }
                set { _carNote = value; }
            }
            /// <summary>
            /// �ԗ����s����
            /// </summary>
            public int Mileage
            {
                get { return _mileage; }
                set { _mileage = value; }
            }

            /// <summary>
            /// ��ƃR�[�h
            /// </summary>
            public string EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }
            /// <summary>
            /// �`�[�敪
            /// </summary>
            public int SlipCd
            {
                get { return _slipCd; }
                set { _slipCd = value; }
            }
            /// <summary>
            /// ���͏]�ƈ��R�[�h
            /// </summary>
            public string InputEmployeeCd
            {
                get { return _inputEmployeeCd; }
                set { _inputEmployeeCd = value; }
            }
            /// <summary>
            /// ���͏]�ƈ�����
            /// </summary>
            public string InputEmployeeNm
            {
                get { return _inputEmployeeNm; }
                set { _inputEmployeeNm = value; }
            }
            /// <summary>
            /// �����
            /// </summary>
            public DateTime SalesDate
            {
                get { return _salesDate; }
                set { _salesDate = value; }
            }
            /// <summary>
            /// �萔����(���)
            /// </summary>
            public double FeeRateOfOrder
            {
                get { return _feeRateOfOrder; }
                set { _feeRateOfOrder = value; }
            }
            /// <summary>
            /// �萔���z(���)
            /// </summary>
            public Int64 FeePriceOfOrder
            {
                get { return _feePriceOfOrder; }
                set { _feePriceOfOrder = value; }
            }
            /// <summary>
            /// �萔����(�݌�)
            /// </summary>
            public double FeeRateOfStock
            {
                get { return _feeRateOfStock; }
                set { _feeRateOfStock = value; }
            }
            /// <summary>
            /// �萔���z(�݌�)
            /// </summary>
            public Int64 FeePriceOfStock
            {
                get { return _feePriceOfStock; }
                set { _feePriceOfStock = value; }
            }
            /// <summary>
            /// �萔����(���v)
            /// </summary>
            public double FeeRateOfTotal
            {
                get { return _feeRateOfTotal; }
                set { _feeRateOfTotal = value; }
            }
            /// <summary>
            /// �萔���z(���v)
            /// </summary>
            public Int64 FeePriceOfTotal
            {
                get { return _feePriceOfTotal; }
                set { _feePriceOfTotal = value; }
            }
            /// <summary>
            /// �̔��敪
            /// </summary>
            public Int32 SalesCodeDiv
            {
                get { return _salesCodeDiv; }
                set { _salesCodeDiv = value; }
            }
            /// <summary>
            /// ���Ӑ撍��
            /// </summary>
            public string PartySalesSlipNo
            {
                get { return _partySalesSlipNo; }
                set { _partySalesSlipNo = value; }
            }
            /// <summary>
            /// ���l�P
            /// </summary>
            public string SlipNote
            {
                get { return _slipNote; }
                set { _slipNote = value; }
            }
            /// <summary>
            /// ���l�Q
            /// </summary>
            public string SlipNote2
            {
                get { return _slipNote2; }
                set { _slipNote2 = value; }
            }
            /// <summary>
            /// ���l�R
            /// </summary>
            public string SlipNote3
            {
                get { return _slipNote3; }
                set { _slipNote3 = value; }
            }
            /// <summary>
            /// �ԕi���R
            /// </summary>
            public string ReturnReason
            {
                get { return _returnReason; }
                set { _returnReason = value; }
            }
            /// <summary>
            /// �ԕi���R�R�[�h
            /// </summary>
            public Int32 RetGoodsReasonDiv
            {
                get { return _returnReasonDiv; }
                set { _returnReasonDiv = value; }
            }
            /// <summary>
            /// ���_�R�[�h
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public RedSlipWriteParameter()
            {
                _enterpriseCode = string.Empty;
                _slipCd = 0;
                _inputEmployeeCd = string.Empty;
                _inputEmployeeNm = string.Empty;
                _salesDate = DateTime.MinValue;
                _feeRateOfOrder = 0;
                _feePriceOfOrder = 0;
                _feeRateOfStock = 0;
                _feePriceOfStock = 0;
                _feeRateOfTotal = 0;
                _feePriceOfTotal = 0;
                _salesCodeDiv = 0;
                _partySalesSlipNo = string.Empty;
                _slipNote = string.Empty;
                _slipNote2 = string.Empty;
                _slipNote3 = string.Empty;
                _returnReason = string.Empty;
                _sectionCode = string.Empty;
                _customerCode = 0;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="enterpriseCode">��ƃR�[�h</param>
            /// <param name="slipCd">�`�[�敪</param>
            /// <param name="inputEmployeeCd">���͏]�ƈ��R�[�h</param>
            /// <param name="inputEmployeeNm">���͏]�ƈ�����</param>
            /// <param name="salesDate">�����</param>
            /// <param name="feeRateOfOrder">�萔����(���)</param>
            /// <param name="feePriceOfOrder">�萔���z(���)</param>
            /// <param name="feeRateOfStock">�萔����(�݌�)</param>
            /// <param name="feePriceOfStock">�萔���z(�݌�)</param>
            /// <param name="feeRateOfTotal">�萔����(���v)</param>
            /// <param name="feePriceOfTotal">�萔���z(���v)</param>
            /// <param name="salesCodeDiv">�̔��敪</param>
            /// <param name="partySalesSlipNo">���Ӑ撍��</param>
            /// <param name="slipNote">���l�P</param>
            /// <param name="slipNote2">���l�Q</param>
            /// <param name="slipNote3">���l�R</param>
            /// <param name="returnReason">�ԕi���R</param>
            /// <param name="returnReasonDiv">�ԕi���R�R�[�h</param>
            /// <param name="sectionCode">���_�R�[�h</param>
            /// <param name="customerCode">���Ӑ�R�[�h</param>
            public RedSlipWriteParameter(string enterpriseCode, int slipCd, string inputEmployeeCd, string inputEmployeeNm, DateTime salesDate, double feeRateOfOrder, Int64 feePriceOfOrder, double feeRateOfStock, Int64 feePriceOfStock, double feeRateOfTotal, Int64 feePriceOfTotal, Int32 salesCodeDiv, string partySalesSlipNo, string slipNote, string slipNote2, string slipNote3, string returnReason, int returnReasonDiv, string sectionCode, int customerCode)
            {
                _enterpriseCode = enterpriseCode;
                _slipCd = slipCd;
                _inputEmployeeCd = inputEmployeeCd;
                _inputEmployeeNm = inputEmployeeNm;
                _salesDate = salesDate;
                _feeRateOfOrder = feeRateOfOrder;
                _feePriceOfOrder = feePriceOfOrder;
                _feeRateOfStock = feeRateOfStock;
                _feePriceOfStock = feePriceOfStock;
                _feeRateOfTotal = feeRateOfTotal;
                _feePriceOfTotal = feePriceOfTotal;
                _salesCodeDiv = salesCodeDiv;
                _partySalesSlipNo = partySalesSlipNo;
                _slipNote = slipNote;
                _slipNote2 = slipNote2;
                _slipNote3 = slipNote3;
                _returnReason = returnReason;
                _returnReasonDiv = returnReasonDiv;
                _sectionCode = sectionCode;
                _customerCode = customerCode;
            }
        }
        # endregion

        /// <summary>
        /// �d�����z�����敪�}�X�^��r�N���X(������z(����))
        /// </summary>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
        # endregion

        #region �v���C�x�[�g�ϐ�
        private string _enterpriseCode = string.Empty;             // ��ƃR�[�h
        private StockSlipRetPlnAcs _stockSlipRetPlnAcs = null;     // �d���ԕi�\��v��X�V���i�A�N�Z�X
        private SuppPtrStcDetailDataSet _detailDataSet = null;     // ���׃f�[�^�i�[�f�[�^�Z�b�g
        private SupplierAcs _supplierAcs = null;                   // �d����}�X�^�A�N�Z�X�N���X
        private Supplier _supplier = null;							// �v��Ώۂ̎d������
        private StockProcMoneyAcs _stockProcMoneyAcs = null;       // �d�����z�����ݒ�A�N�Z�X�N���X
        private List<StockProcMoney> _stockProcMoneyList = null;   // �d�����z�����敪�ݒ胊�X�g
        private StockPriceCalculate _stockPriceCalculate = null;   // �d�����z�Z�o���W���[��
        private Dictionary<GoodsKey, GoodsUnitData> _goodsUnitDataDic;  // ���i�f�B�N�V���i��
        private GoodsAcs _goodsAcs;                                // ���i�A�N�Z�X�N���X
        private string _loginSectionCode = string.Empty;           // �����_�R�[�h
        private TaxRateSetAcs _taxRateSetAcs = null;                // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
        TaxRateSet _taxRateSet = null;                              // �ŗ����
        private double _taxRate = 0.0;                              // �ŗ�(�ŗ��ݒ�}�X�^����擾)
       #endregion

        /// <summary>
        /// �ԕi�\��f�[�^�폜����
        /// </summary>
        /// <param name="para">�ԕi�v��p�p�����[�^</param>
        /// <param name="delSlipView">�폜�Ώۓ`�[���X�g</param>
        /// <param name="delRetSlipView">�폜�Ώۓ`�[���X�g(�ԕi�v��g�p��)</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        public int DeleteSlip(RetGdsAddUpWriteParameter para, DataRow[] delSlipView, SuppPtrStcDetailDataSet.RetGdsStcListDataTable delRetGdsStcList, out string errorMessage)
        {

            errorMessage = string.Empty;
            StockSlipWork stockSlipWork = new StockSlipWork();
            ArrayList stockSlipWorkList = new ArrayList();
            Int32 retSuppSlipNo = 0;

            foreach (DataRow rowView in delSlipView)
            {

                // stockSlipWork�ɒl��ݒ肷��
                stockSlipWork = new StockSlipWork();
                // �폜�Ώۓ`�[����d���`�[�ԍ����擾���A�ԕi�v��g�p��DataSet����Ή��f�[�^�𒊏o����
                retSuppSlipNo = ConvertInt32Column(rowView[_detailDataSet.StcList.SupplierSlipNoColumn.ColumnName]);
                DataRow[] delRetRows = delRetGdsStcList.Select(string.Format("{0} = {1}", delRetGdsStcList.SupplierSlipNoColumn.ColumnName, retSuppSlipNo));
                SlcListFromStockSlipWorkData(para, rowView, delRetRows[0], out stockSlipWork);

                // stockSlipWorkList�ɒǉ�����
                stockSlipWorkList.Add(stockSlipWork);

            }

            object dataObj = (object)stockSlipWorkList;

            // �ԕi�\��f�[�^�폜����(PMKAK01100Acs)
            int status = _stockSlipRetPlnAcs.DeleteStockSlipRetPln(ref dataObj, out errorMessage);

            return status;
        }

        /// <summary>
        /// �ԕi�v�㏈��
        /// </summary>
        /// <param name="para">�ԕi�v��p�p�����[�^</param>
        /// <param name="regGdsDetail">�ԓ`�f�[�^�Z�b�g</param>
        /// <param name="stcList">�d���`�[�f�[�^�Z�b�g</param>
        /// <param name="retGdsStcList">�d���`�[�f�[�^�Z�b�g(�ԕi�v��g�p��)</param>
        /// <param name="StcDetail">�d�����׃f�[�^�Z�b�g</param>
        /// <param name="RetGdsStcDetail">�d�����׃f�[�^�Z�b�g(�ԕi�v��g�p��)</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// <br>Note       : �V�X�e���e�X�g��QNo233�Ή� �ԕi�v��^�u�̒I�ԏ����Z�b�g����悤�ɏC��</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2013/03/01</br>
        /// </remarks>
        public int WriteRetGoodsAddUp(RetGdsAddUpWriteParameter para, DataView regGdsDetail, SuppPtrStcDetailDataSet.StcListDataTable stcList, SuppPtrStcDetailDataSet.RetGdsStcListDataTable retGdsStcList, SuppPtrStcDetailDataSet.StcDetailDataTable StcDetail, SuppPtrStcDetailDataSet.RetGdsStcDetailDataTable RetGdsStcDetail, out string errMessage)                      
        {
            // �G���[���b�Z�[�W������������
            errMessage = string.Empty;

            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            �������݃p�����[�^���X�g
            //      --CustomSerializeArrayList      �d�����X�g
            //          --StockSlipWork             �d���f�[�^�I�u�W�F�N�g
            //          --ArrayList                 �d�����׃��X�g
            //              --StockDetailWork       �d�����׃f�[�^�I�u�W�F�N�g
            //          --ArrayList                 �d�����גǉ���񃊃X�g
            //              --SlipDetailAddInfoWork �d�����גǉ����f�[�^�I�u�W�F�N�g
            //------------------------------------------------------------------------------------
            CustomSerializeArrayList dataList = new CustomSerializeArrayList();

            // �d�����׃f�[�^�I�u�W�F�N�g
            StockDetailWork stockDetailWork = null;
            // �d���f�[�^�I�u�W�F�N�g
            StockSlipWork stockSlipWork = new StockSlipWork();
            // �d�����׃��X�g
            List<StockDetailWork> stockDetailWorkList = null;

            // �d�����גǉ���񃊃X�g
            ArrayList slipDtlAdInfoWorkList = null;

            // �ޔ�p�`�[�ԍ�
            string retGdsSlipNum = string.Empty;
            string preRetGdsSlipNum = string.Empty;
            // �d���`�[�ԍ�
            Int32 retSuppSlipNo = 0;

            // �d������擾
            if (this._supplierAcs.Read(out this._supplier, this._enterpriseCode, para.SupplierCode) != 0 ||
                this._supplier == null)
            {
                errMessage = "�d����}�X�^�̎擾�Ɏ��s���܂����B";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            // �ŗ����擾
            if (this.TaxRateSetRead(out this._taxRateSet) != 0 ||
                this._taxRateSet == null)
            {
                errMessage = "�ŗ����}�X�^�̎擾�Ɏ��s���܂����B";
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else
            {
                //this._taxRate = this.GetTaxRate(this._taxRateSet, DateTime.Now); // DEL 杍^ 2014/01/07 
                this._taxRate = this.GetTaxRate(this._taxRateSet, para.RetGdsDate); // ADD 杍^ 2014/01/07 
            }

            // �O���b�h�̏����\�[�g
            // �ԕi�`�[�ԍ�,�q�ɔԍ�,�d���`�[�ԍ�,���׍s�ԍ�
            string sortString = string.Format("{0} ,{1} ,{2} ,{3}",
                _detailDataSet.RedSlipDetail.RetGdsSlipNumColumn.ColumnName,
                _detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName,
                _detailDataSet.RedSlipDetail.SupplierSlipNoColumn.ColumnName,
                _detailDataSet.RedSlipDetail.StockRowNoColumn.ColumnName);
            regGdsDetail.Sort = sortString;

            // ��ʏ�̃O���b�h�̍s�������[�v
            foreach (DataRowView rowView in regGdsDetail)
            {
                // �ޔ�p�q�ɃR�[�h
                Int32 retWarehouseCode = 0;
                string warehouseCode = string.Empty;
                string shelfNo = string.Empty; //ADD 2013/03/01 �V�X�e����QNo233

                // �O���b�h�̏�񂩂�d���`�[�ԍ����擾����
                retSuppSlipNo = ConvertInt32Column(rowView[_detailDataSet.RedSlipDetail.SupplierSlipNoColumn.ColumnName]);
                if (retSuppSlipNo == 0)
                {
                    // �d���`�[�ԍ���0�̏ꍇ
                    errMessage = "�d���`�[�ԍ���0�ł�";
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else
                {
                    // �O���b�h�̏�񂩂�ԕi�`�[�ԍ����擾����
                    retGdsSlipNum = ConvertStringColumn(rowView[_detailDataSet.RedSlipDetail.RetGdsSlipNumColumn.ColumnName]);

                    // �O���b�h�̏�񂩂�q�ɃR�[�h���擾����
                    warehouseCode = ConvertStringColumn(rowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName]);
                    // �O���b�h�̏�񂩂�I�Ԃ��擾����
                    shelfNo = ConvertStringColumn(rowView[_detailDataSet.RedSlipDetail.ShelfNoColumn.ColumnName]); //ADD 2013/03/01 �V�X�e����QNo233

                    if (retGdsSlipNum == string.Empty && (!Int32.TryParse(warehouseCode, out retWarehouseCode) || retWarehouseCode == 0))
                    {
                        // �ԕi�`�[�ԍ��Ƒq�ɃR�[�h�̂ǂ���������͂̏ꍇ
                        errMessage = "�ԕi�`�[�ԍ��Ƒq�ɃR�[�h�̂ǂ���������͂ł�";
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }

                    // �ԕi�`�[�ԍ��������͑q�ɃR�[�h���ς�����ꍇ
                    if ((retGdsSlipNum != string.Empty && retWarehouseCode == 0 && retGdsSlipNum != preRetGdsSlipNum) ||
                        (preRetGdsSlipNum != string.Empty && retWarehouseCode != 0) ||
                        (retGdsSlipNum == string.Empty && retWarehouseCode != 0))
                    {
                        if (stockSlipWork.SupplierSlipNo != 0)
                        {
                            // �������X�g�Ɏd���f�[�^��ǉ�����(�d���ԕi�v��)
                            RedSlipAddUpList(para, preRetGdsSlipNum, stockSlipWork, ref stockDetailWorkList, ref slipDtlAdInfoWorkList, ref dataList);
                        }

                        // �ԕi�`�[�ԍ��̍X�V
                        preRetGdsSlipNum = retGdsSlipNum;

                        // �d���`�[�f�[�^���擾����
                        DataRow[] rows = stcList.Select(string.Format("{0} = {1}", stcList.SupplierSlipNoColumn.ColumnName, retSuppSlipNo));
                        DataRow[] retRows = retGdsStcList.Select(string.Format("{0} = {1}", retGdsStcList.SupplierSlipNoColumn.ColumnName, retSuppSlipNo));
                        if (rows.Length > 0 && retRows.Length >0)
                        {
                            // DataRow���烏�[�N�ɕϊ�
                            SlcListFromStockSlipWorkData(para, rows[0], retRows[0], out stockSlipWork);
                        }
                        else
                        {
                            // �d���`�[���擾�ł��Ȃ������ꍇ
                            errMessage = "�d���`�[�f�[�^���擾�o���܂���ł���";
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }

                        // �d�����׃��X�g�̏�����
                        stockDetailWorkList = new List<StockDetailWork>();

                        // �d�����גǉ���񃊃X�g
                        slipDtlAdInfoWorkList = new ArrayList();
                    }
                }

                // �d�����׃f�[�^�̎擾
                int SupplierSlipNo = ConvertInt32Column(rowView[_detailDataSet.RedSlipDetail.SupplierSlipNoColumn.ColumnName]); // �d���`�[�ԍ�
                int StockRowNo = ConvertInt32Column(rowView[_detailDataSet.RedSlipDetail.StockRowNoColumn.ColumnName]); // �d���s�ԍ�
                if (SupplierSlipNo > 0 && StockRowNo > 0)
                {
                    DataRow[] rows = StcDetail.Select(
                        string.Format("{0} = {1} AND {2} = {3}",
                        StcDetail.SupplierSlipNoColumn.ColumnName, SupplierSlipNo,
                        StcDetail.StockRowNoColumn.ColumnName, StockRowNo));
                    // �ԕi�v��p�d�����׃f�[�^
                    DataRow[] retRows = RetGdsStcDetail.Select(
                        string.Format("{0} = {1} AND {2} = {3}",
                        RetGdsStcDetail.SupplierSlipNoColumn.ColumnName, SupplierSlipNo,
                        RetGdsStcDetail.StockRowNoColumn.ColumnName, StockRowNo));

                    if (rows.Length > 0 && retRows.Length > 0)
                    {
                        // DataRow���烏�[�N�ɕϊ�
                        RedSlipFromStockDetailWorkData(para, rows[0], retRows[0], out stockDetailWork);

                        // �O���b�h�ɓ��͂��ꂽ�ԕi�����u�d�����v�ɃZ�b�g����
                        double returnCount = ConvertDoubleColumn(rowView[_detailDataSet.RedSlipDetail.ReturnCntColumn.ColumnName]);

                        // ��ʕ\����-1���|���Ă��邽�߁A�����߂�
                        returnCount *= -1.0;
                        stockDetailWork.StockCount = returnCount;

                        // �O���b�h�ɓ��͂��ꂽ�q�ɃR�[�h���u�q�ɃR�[�h�v�ɃZ�b�g����
                        stockDetailWork.WarehouseCode = warehouseCode;
                        // �O���b�h�ɕ\�����ꂽ�I�Ԃ��Z�b�g����
                        stockDetailWork.WarehouseShelfNo = shelfNo; //ADD 2013/03/01 �V�X�e����QNo233
         
                        stockDetailWorkList.Add(stockDetailWork);

                        // �d�����׃f�[�^�I�u�W�F�N�g(�d���ԕi�v��)�ɒǉ�����
                        slipDtlAdInfoWorkList.Add(new SlipDetailAddInfoWork());
                    }
                    else
                    {
                        // �d�����ׂ��擾�ł��Ȃ������ꍇ
                        errMessage = "�d�����׃f�[�^���擾�o���܂���ł���";
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }

            // �Ō�̃f�[�^�o�^
            RedSlipAddUpList(para, preRetGdsSlipNum, stockSlipWork, ref stockDetailWorkList, ref slipDtlAdInfoWorkList, ref dataList);

            object dataObj = (object)dataList;

            // �d���ԕi�\��f�[�^�v�㏈��(PMKAK01100A)
            int status = _stockSlipRetPlnAcs.AddUpStockSlipRetPln((object)dataObj, out errMessage);

            return status;
        }

        /// <summary>
        /// �������X�g�Ɏd���f�[�^��ǉ�����(�d���ԕi�v��)
        /// </summary>
        /// <param name="para">�ԕi�v��p�p�����[�^</param>
        /// <param name="GdsSlipNum">�`�[�ԍ�</param>
        /// <param name="stockSlipWork">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="redStockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="slipDtlAdInfoWorkList">�d�����׃��X�g</param>
        /// <param name="dataList">�d�����X�g</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private void RedSlipAddUpList(RetGdsAddUpWriteParameter para, string GdsSlipNum, StockSlipWork stockSlipWork, ref List<StockDetailWork> redStockDetailList, ref ArrayList slipDtlAdInfoWorkList, ref CustomSerializeArrayList dataList)
        {
            if (redStockDetailList.Count <= 0)
            {
                // ���׃f�[�^�������ꍇ�̓��X�g�ɒǉ����Ȃ�
                return;
            }

            // �d���ԕi�����p�����[�^�̍쐬
            StockSlipLogicalKey key = new StockSlipLogicalKey();
            key.EnterpriseCode = para.EnterpriseCode;
            key.SectionCode = para.SectionCode;
            key.SupplierCd = para.SupplierCode;
            key.StockDate = para.RetGdsDate;
            key.PartySaleSlipNum = GdsSlipNum;
            RedSlipWriteParameter parameter = new RedSlipWriteParameter();
            parameter.SectionCode = para.SectionCode;
            parameter.SlipCd = para.SlipCd;
            parameter.SalesDate = DateTime.MinValue;
            parameter.InputEmployeeCd = para.StockAgentCd;
            parameter.InputEmployeeNm = para.StockAgentNm;
            parameter.ReturnReason = para.ReturnReason;
            parameter.FeePriceOfTotal = para.FeePriceOfTotal;
            parameter.EnterpriseCode = this._enterpriseCode;
            parameter.RetGoodsReasonDiv = para.RetGoodsReasonDiv;
            parameter.SlipNote = para.SlipNote;
            parameter.SlipNote2 = para.SlipNote2;

            // �d���ԕi�f�[�^�̎擾
            CreateRedStockSlip(key, ref stockSlipWork, ref redStockDetailList, parameter, para.RetGdsDate);

            // --- ADD 杍^ 2014/01/07 ------------ >>>>>>
            // ����œ]�ŕ����ҏW���f���\�b�h�̕Ԓl��true�̏ꍇ�A
            if (CheckConsTaxLayMethod(stockSlipWork))
            {
                // �d���f�[�^(StockSlipRf).�d�������œ]�ŕ���(SuppCTaxLayCdRF)���O�F�`�[�P��
                stockSlipWork.SuppCTaxLayCd = 0;
            }
            // --- ADD 杍^ 2014/01/07 ------------ <<<<<<

            if (GdsSlipNum != string.Empty && parameter.FeePriceOfTotal != 0)
            {
                // �萔�����גǉ�����
                AddFeeDetail(ref redStockDetailList, ref stockSlipWork, parameter);

                // �d�����׃f�[�^�I�u�W�F�N�g(�d���ԕi�v��)�ɒǉ�����
                slipDtlAdInfoWorkList.Add(new SlipDetailAddInfoWork());
            }

            #region [�`�[���z�Z�o]
            // �萔�����ׂ��ǉ������\�������邽�߁A���̃^�C�~���O�œ`�[���z�Z�o���s��

            // �d����}�X�^�������Œ[�����������擾
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlipWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
            double fracProcUnit;
            int fracProcCd;
            this.GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // MAKON01112A�̋��ʃN���X�g�p
            StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipWork, redStockDetailList, fracProcUnit, fracProcCd);
            #endregion

            // �d�����׃��X�g�̃f�[�^�ϊ�
            ArrayList detailList = new ArrayList();
            detailList.AddRange(redStockDetailList.ToArray());

            // �������X�g�Ɏd���f�[�^��ǉ�����(�d���ԕi�v��)
            CustomSerializeArrayList stockSlipDataList = new CustomSerializeArrayList();
            stockSlipDataList.Add(stockSlipWork);
            stockSlipDataList.Add(detailList);
            stockSlipDataList.Add(slipDtlAdInfoWorkList);
            dataList.Add(stockSlipDataList);
        }

        // --- ADD 杍^ 2014/01/07 ---------->>>>>
        /// <summary>
        /// ����œ]�ŕ����ҏW���f���\�b�h
        /// </summary>
        /// <param name="stockSlip">�d���f�[�^</param>
        /// <remarks>
        /// <br>Note       : ����œ]�ŕ����ҏW���f���s���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/01/07</br>
        /// </remarks>
        /// <returns>true:���݂��� false:���݂��Ȃ�</returns>
        private bool CheckConsTaxLayMethod(StockSlipWork stockSlipWork)
        {
            bool consTaxLayMethodFlg = false;

            // �@�����̏���œ]�ŕ������A�����e���͐����q�̏ꍇ�A
            if (stockSlipWork.SuppCTaxLayCd == 2 || stockSlipWork.SuppCTaxLayCd == 3)
            {
                // �A�ŗ��ݒ肪�Q���ȏ゠��ꍇ�A
                if (this._taxRateSet.TaxRateStartDate2 != DateTime.MinValue
                    || this._taxRateSet.TaxRateStartDate3 != DateTime.MinValue)
                {
                    // �B����������t�Ɛԓ`������t�ŁA�ŗ����Ⴄ�ꍇ�A
                    if (stockSlipWork.SupplierConsTaxRate != this._taxRate)
                    {
                        consTaxLayMethodFlg = true;
                    }
                }
            }

            return consTaxLayMethodFlg;
        }
        // --- ADD 杍^ 2014/01/07 ----------<<<<<

        /// <summary>
        /// �d�����z�����敪�ݒ胊�X�g�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private void GetStockProcMonyList()
        {
            ArrayList al = null;
            int status = this._stockProcMoneyAcs.Search(out al, _enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (al != null)
                {
                    this._stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])al.ToArray(typeof(StockProcMoney)));
                }
            }
            return;
        }

        /// <summary>
        /// StcList��RetGdsStcList��stockSlipWork�ڍ�����
        /// </summary>
        /// <param name="para">�ԕi�v��p�p�����[�^</param>
        /// <param name="listRowView">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="retListRow">�d���f�[�^�I�u�W�F�N�g(�ԕi�v��g�p��)</param>
        /// <returns>�d���f�[�^���[�N�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        public void SlcListFromStockSlipWorkData(RetGdsAddUpWriteParameter para, DataRow listRowView, DataRow retListRow, out StockSlipWork stockSlipWork)
        {
            stockSlipWork = new StockSlipWork();

            stockSlipWork.EnterpriseCode = para.EnterpriseCode; // ��ƃR�[�h	
            stockSlipWork.SupplierFormal = ConvertInt32Column(listRowView[_detailDataSet.StcList.SupplierFormalColumn.ColumnName]); // �d���`��	
            stockSlipWork.SupplierSlipNo = ConvertInt32Column(listRowView[_detailDataSet.StcList.SupplierSlipNoColumn.ColumnName]); // �d���`�[�ԍ�	
            stockSlipWork.SectionCode = ConvertStringColumn(listRowView[_detailDataSet.StcList.SectionCdColumn.ColumnName]); // ���_�R�[�h
            stockSlipWork.DebitNoteDiv = ConvertInt32Column(listRowView[_detailDataSet.StcList.DebitNoteDivColumn.ColumnName]); // �ԓ`�敪	
            stockSlipWork.SupplierSlipCd = ConvertInt32Column(listRowView[_detailDataSet.StcList.SupplierSlipCdColumn.ColumnName]); // �d���`�[�敪	
            stockSlipWork.AccPayDivCd = ConvertInt32Column(listRowView[_detailDataSet.StcList.AccPayDivCdColumn.ColumnName]); // ���|�敪	
            stockSlipWork.StockDate = ConvertDateTimeColumn(listRowView[_detailDataSet.StcList.StockDateColumn.ColumnName]); // �d����	
            stockSlipWork.StockAddUpADate = ConvertDateTimeColumn(listRowView[_detailDataSet.StcList.StockAddUpADateColumn.ColumnName]); // �d���v����t	
            stockSlipWork.SupplierCd = ConvertInt32Column(listRowView[_detailDataSet.StcList.SupplierCdColumn.ColumnName]); // �d����R�[�h	
            stockSlipWork.SupplierSnm = ConvertStringColumn(listRowView[_detailDataSet.StcList.SupplierSnmColumn.ColumnName]); // �d���旪��	
            stockSlipWork.StockInputName = ConvertStringColumn(listRowView[_detailDataSet.StcList.StockInputNameColumn.ColumnName]); // �d�����͎Җ���	
            stockSlipWork.StockAgentName = ConvertStringColumn(listRowView[_detailDataSet.StcList.StockAgentNameColumn.ColumnName]); // �d���S���Җ���	
            stockSlipWork.StockTtlPricTaxExc = ConvertInt64Column(listRowView[_detailDataSet.StcList.StockTtlPricTaxExcColumn.ColumnName]); // �d�����z�v�i�Ŕ����j	
            stockSlipWork.StockPriceConsTax = ConvertInt64Column(listRowView[_detailDataSet.StcList.StockPriceConsTaxColumn.ColumnName]); // �d�����z����Ŋz	
            stockSlipWork.PartySaleSlipNum = ConvertStringColumn(listRowView[_detailDataSet.StcList.PartySaleSlipNumColumn.ColumnName]); // �����`�[�ԍ�	
            stockSlipWork.SupplierSlipNote1 = ConvertStringColumn(listRowView[_detailDataSet.StcList.SupplierSlipNote1Column.ColumnName]); // �d���`�[���l1	
            stockSlipWork.SupplierSlipNote2 = ConvertStringColumn(listRowView[_detailDataSet.StcList.SupplierSlipNote2Column.ColumnName]); // �d���`�[���l2	
            stockSlipWork.UoeRemark1 = ConvertStringColumn(listRowView[_detailDataSet.StcList.UoeRemark1Column.ColumnName]); // �t�n�d���}�[�N�P	
            stockSlipWork.UoeRemark2 = ConvertStringColumn(listRowView[_detailDataSet.StcList.UoeRemark2Column.ColumnName]); // �t�n�d���}�[�N�Q	

            // �ʃf�[�^�Z�b�g����擾
            stockSlipWork.LogicalDeleteCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.LogicalDeleteCdColumn.ColumnName]); // �_���폜�敪
            stockSlipWork.SubSectionCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SubSectionCodeColumn.ColumnName]); // ����R�[�h
            stockSlipWork.DebitNLnkSuppSlipNo = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.DebitNLnkSuppSlipNoColumn.ColumnName]); // �ԍ��A���d���`�[�ԍ�
            stockSlipWork.StockGoodsCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.StockGoodsCdColumn.ColumnName]); // �d�����i�敪	
            stockSlipWork.StockSectionCd = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.StockSectionCdColumn.ColumnName]); // �d�����_�R�[�h	
            stockSlipWork.StockAddUpSectionCd = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.StockAddUpSectionCdColumn.ColumnName]); // �d���v�㋒�_�R�[�h	
            stockSlipWork.StockSlipUpdateCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.StockSlipUpdateCdColumn.ColumnName]); // �d���`�[�X�V�敪
            stockSlipWork.InputDay = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.InputDayColumn.ColumnName]); // ���͓�
            stockSlipWork.ArrivalGoodsDay = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.ArrivalGoodsDayColumn.ColumnName]); // ���ד�
            stockSlipWork.DelayPaymentDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.DelayPaymentDivColumn.ColumnName]); // �����敪
            stockSlipWork.PayeeCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.PayeeCodeColumn.ColumnName]); // �x����R�[�h
            stockSlipWork.PayeeSnm = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.PayeeSnmColumn.ColumnName]); // �x���旪��
            stockSlipWork.SupplierNm1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.SupplierNm1Column.ColumnName]); // �d���於1
            stockSlipWork.SupplierNm2 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.SupplierNm2Column.ColumnName]); // �d���於2
            stockSlipWork.BusinessTypeCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.BusinessTypeCodeColumn.ColumnName]); // �Ǝ�R�[�h
            stockSlipWork.BusinessTypeName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.BusinessTypeNameColumn.ColumnName]); // �Ǝ햼��
            stockSlipWork.SalesAreaCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SalesAreaCodeColumn.ColumnName]); // �̔��G���A�R�[�h
            stockSlipWork.SalesAreaName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.SalesAreaNameColumn.ColumnName]); // �̔��G���A����
            stockSlipWork.StockInputCode = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.StockInputCodeColumn.ColumnName]); // �d�����͎҃R�[�h
            stockSlipWork.StockAgentCode = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.StockAgentCodeColumn.ColumnName]); // �d���S���҃R�[�h
            stockSlipWork.SuppTtlAmntDspWayCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SuppTtlAmntDspWayCdColumn.ColumnName]); // �d���摍�z�\�����@�敪	
            stockSlipWork.TtlAmntDispRateApy = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.TtlAmntDispRateApyColumn.ColumnName]); // ���z�\���|���K�p�敪	
            stockSlipWork.StockTotalPrice = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockTotalPriceColumn.ColumnName]); // �d�����z���v	
            stockSlipWork.StockSubttlPrice = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockSubttlPriceColumn.ColumnName]); // �d�����z���v	
            stockSlipWork.StockTtlPricTaxInc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockTtlPricTaxIncColumn.ColumnName]); // �d�����z�v�i�ō��݁j	
            stockSlipWork.StockNetPrice = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockNetPriceColumn.ColumnName]); // �d���������z
            stockSlipWork.TtlItdedStcOutTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.TtlItdedStcOutTaxColumn.ColumnName]); // �d���O�őΏۊz���v	
            stockSlipWork.TtlItdedStcInTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.TtlItdedStcInTaxColumn.ColumnName]); // �d�����őΏۊz���v	
            stockSlipWork.TtlItdedStcTaxFree = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.TtlItdedStcTaxFreeColumn.ColumnName]); // �d����ېőΏۊz���v	
            stockSlipWork.StockOutTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockOutTaxColumn.ColumnName]); // �d�����z����Ŋz�i�O�Łj	
            stockSlipWork.StckPrcConsTaxInclu = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StckPrcConsTaxIncluColumn.ColumnName]); // �d�����z����Ŋz�i���Łj	
            stockSlipWork.StckDisTtlTaxExc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StckDisTtlTaxExcColumn.ColumnName]); // �d���l�����z�v�i�Ŕ����j	
            stockSlipWork.ItdedStockDisOutTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.ItdedStockDisOutTaxColumn.ColumnName]); // �d���l���O�őΏۊz���v	
            stockSlipWork.ItdedStockDisInTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.ItdedStockDisInTaxColumn.ColumnName]); // �d���l�����őΏۊz���v	
            stockSlipWork.ItdedStockDisTaxFre = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.ItdedStockDisTaxFreColumn.ColumnName]); // �d���l����ېőΏۊz���v	
            stockSlipWork.StockDisOutTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StockDisOutTaxColumn.ColumnName]); // �d���l������Ŋz�i�O�Łj	
            stockSlipWork.StckDisTtlTaxInclu = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.StckDisTtlTaxIncluColumn.ColumnName]); // �d���l������Ŋz�i���Łj	
            stockSlipWork.TaxAdjust = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.TaxAdjustColumn.ColumnName]); // ����Œ����z	
            stockSlipWork.BalanceAdjust = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.BalanceAdjustColumn.ColumnName]); // �c�������z	
            stockSlipWork.SuppCTaxLayCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SuppCTaxLayCdColumn.ColumnName]); // �d�������œ]�ŕ����R�[�h	
            stockSlipWork.SupplierConsTaxRate = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcList.SupplierConsTaxRateColumn.ColumnName]); // �d�������Őŗ�	
            stockSlipWork.AccPayConsTax = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcList.AccPayConsTaxColumn.ColumnName]); // ���|�����	
            stockSlipWork.StockFractionProcCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.StockFractionProcCdColumn.ColumnName]); // �d���[�������敪	
            stockSlipWork.AutoPayment = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.AutoPaymentColumn.ColumnName]); // �����x���敪	
            stockSlipWork.AutoPaySlipNum = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.AutoPaySlipNumColumn.ColumnName]); // �����x���`�[�ԍ�	
            stockSlipWork.DetailRowCount = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.DetailRowCountColumn.ColumnName]); // ���׍s��	
            stockSlipWork.EdiSendDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.EdiSendDateColumn.ColumnName]); // �d�c�h���M��	
            stockSlipWork.EdiTakeInDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.EdiTakeInDateColumn.ColumnName]); // �d�c�h�捞��	
            stockSlipWork.SlipPrintDivCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SlipPrintDivCdColumn.ColumnName]); // �`�[���s�敪	
            stockSlipWork.SlipPrintFinishCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SlipPrintFinishCdColumn.ColumnName]); // �`�[���s�ϋ敪	
            stockSlipWork.StockSlipPrintDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcList.StockSlipPrintDateColumn.ColumnName]); // �d���`�[���s��	
            stockSlipWork.SlipPrtSetPaperId = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.SlipPrtSetPaperIdColumn.ColumnName]); // �`�[����ݒ�p���[ID	
            stockSlipWork.SlipAddressDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.SlipAddressDivColumn.ColumnName]); // �`�[�Z���敪	
            stockSlipWork.AddresseeCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.AddresseeCodeColumn.ColumnName]); // �[�i��R�[�h	
            stockSlipWork.AddresseeName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeNameColumn.ColumnName]); // �[�i�於��	
            stockSlipWork.AddresseeName2 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeName2Column.ColumnName]); // �[�i�於��2	
            stockSlipWork.AddresseePostNo = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseePostNoColumn.ColumnName]); // �[�i��X�֔ԍ�	
            stockSlipWork.AddresseeAddr1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeAddr1Column.ColumnName]); // �[�i��Z��1(�s���{���s��S�E�����E��)	
            stockSlipWork.AddresseeAddr3 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeAddr3Column.ColumnName]); // �[�i��Z��3(�Ԓn)	
            stockSlipWork.AddresseeAddr4 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeAddr4Column.ColumnName]); // �[�i��Z��4(�A�p�[�g����)	
            stockSlipWork.AddresseeTelNo = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeTelNoColumn.ColumnName]); // �[�i��d�b�ԍ�	
            stockSlipWork.AddresseeFaxNo = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcList.AddresseeFaxNoColumn.ColumnName]); // �[�i��FAX�ԍ�	
            stockSlipWork.DirectSendingCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcList.DirectSendingCdColumn.ColumnName]); // �����敪

        }

        /// <summary>
        /// StcDetail��RetGdsStcDetail��stockDetailWork�ڍ�����
        /// </summary>
        /// <param name="para">�ԕi�v��p�p�����[�^</param>
        /// <param name="listRow">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="retListRow">�d���f�[�^�I�u�W�F�N�g(�ԕi�v��g�p��)</param>
        /// <returns>�d�����׃f�[�^�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/25</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        public void RedSlipFromStockDetailWorkData(RetGdsAddUpWriteParameter para, DataRow listRow, DataRow retListRow, out StockDetailWork stockDetailWork)
        {
            stockDetailWork = new StockDetailWork();

            stockDetailWork.EnterpriseCode = para.EnterpriseCode;                                                                               // ��ƃR�[�h
            stockDetailWork.StockRowNo = ConvertInt32Column(listRow[_detailDataSet.StcDetail.StockRowNoColumn.ColumnName]); // �sNo
            stockDetailWork.SupplierFormal = ConvertInt32Column(listRow[_detailDataSet.StcDetail.SupplierFormalColumn.ColumnName]); // �d���`��
            stockDetailWork.StockSlipCdDtl = ConvertInt32Column(listRow[_detailDataSet.StcDetail.StockSlipCdDtlColumn.ColumnName]); // ���׋敪
            stockDetailWork.StockAgentName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.StockAgentNameColumn.ColumnName]); // �S���Җ�
            stockDetailWork.GoodsName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.GoodsNameColumn.ColumnName]); // �i��
            stockDetailWork.GoodsNo = ConvertStringColumn(listRow[_detailDataSet.StcDetail.GoodsNoColumn.ColumnName]); // �i��
            stockDetailWork.GoodsMakerCd = ConvertInt32Column(listRow[_detailDataSet.StcDetail.GoodsMakerCdColumn.ColumnName]); // ���[�J�[�R�[�h
            stockDetailWork.MakerName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.MakerNameColumn.ColumnName]); // ���[�J�[����
            stockDetailWork.BLGoodsCode = ConvertInt32Column(listRow[_detailDataSet.StcDetail.BLGoodsCodeColumn.ColumnName]); // BL�R�[�h
            stockDetailWork.BLGroupCode = ConvertInt32Column(listRow[_detailDataSet.StcDetail.BLGroupCodeColumn.ColumnName]); // BL�O���[�v
            stockDetailWork.StockUnitPriceFl = ConvertDoubleColumn(listRow[_detailDataSet.StcDetail.StockUnitPriceFlColumn.ColumnName]); // ���P��
            stockDetailWork.ListPriceTaxExcFl = ConvertDoubleColumn(listRow[_detailDataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName]); // �W�����i
            stockDetailWork.OpenPriceDiv = ConvertInt32Column(listRow[_detailDataSet.StcDetail.OpenPriceDivColumn.ColumnName]); // �I�[�v�����i�敪
            // �ԕi�f�[�^�����Ƃ���̂Ń}�C�i�X�ɂ���
            stockDetailWork.StockPriceConsTax = -1 * ConvertInt64Column(listRow[_detailDataSet.StcDetail.StockPriceConsTaxColumn.ColumnName]); // �d�����z����Ŋz
            stockDetailWork.StockInputName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.StockInputNameColumn.ColumnName]); // ���s��
            stockDetailWork.SupplierCd = ConvertInt32Column(listRow[_detailDataSet.StcDetail.SupplierCdColumn.ColumnName]); // �d����R�[�h
            stockDetailWork.SupplierSnm = ConvertStringColumn(listRow[_detailDataSet.StcDetail.SupplierSnmColumn.ColumnName]); // �d���於
            stockDetailWork.StockOrderDivCd = ConvertInt32Column(listRow[_detailDataSet.StcDetail.StockOrderDivCdColumn.ColumnName]); // �ݎ�
            stockDetailWork.WarehouseCode = ConvertStringColumn(listRow[_detailDataSet.StcDetail.WarehouseCdColumn.ColumnName]); // �q�ɃR�[�h
            stockDetailWork.WarehouseName = ConvertStringColumn(listRow[_detailDataSet.StcDetail.WarehouseNameColumn.ColumnName]); // �q��
            stockDetailWork.WarehouseShelfNo = ConvertStringColumn(listRow[_detailDataSet.StcDetail.WarehouseShelfNoColumn.ColumnName]); // �I��
            stockDetailWork.SupplierSlipNo = ConvertInt32Column(listRow[_detailDataSet.StcDetail.SupplierSlipNoColumn.ColumnName]); // �d��SEQ/�x��No
            stockDetailWork.BfStockUnitPriceFl = ConvertDoubleColumn(listRow[_detailDataSet.StcDetail.BfStockUnitPriceFlColumn.ColumnName]); // �ύX�O�d���P���i�����j
            stockDetailWork.BfListPrice = ConvertDoubleColumn(listRow[_detailDataSet.StcDetail.BfListPriceColumn.ColumnName]); // �ύX�O�艿
            stockDetailWork.LogicalDeleteCode = ConvertInt32Column(listRow[_detailDataSet.StcDetail.LogicalDeleteCodeColumn.ColumnName]); // �_���폜�敪

            // �ʃf�[�^�Z�b�g����擾
            stockDetailWork.AcceptAnOrderNo = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.AcceptAnOrderNoColumn.ColumnName]); // �󒍔ԍ�
            stockDetailWork.CommonSeqNo = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.CommonSeqNoColumn.ColumnName]); // ���ʒʔ�
            stockDetailWork.StockSlipDtlNum = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.StockSlipDtlNumColumn.ColumnName]); // �d�����גʔ�
            stockDetailWork.SupplierFormalSrc = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.SupplierFormalSrcColumn.ColumnName]); // �d���`���i���j
            stockDetailWork.StockSlipDtlNumSrc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.StockSlipDtlNumSrcColumn.ColumnName]); // �d�����גʔԁi���j
            stockDetailWork.AcptAnOdrStatusSync = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.AcptAnOdrStatusSyncColumn.ColumnName]); // �󒍃X�e�[�^�X�i�����j
            stockDetailWork.SalesSlipDtlNumSync = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.SalesSlipDtlNumSyncColumn.ColumnName]); // ���㖾�גʔԁi�����j
            stockDetailWork.SubSectionCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.SubSectionCodeColumn.ColumnName]); // ����R�[�h
            stockDetailWork.StockInputCode = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockInputCodeColumn.ColumnName]); // �d�����͎҃R�[�h
            stockDetailWork.StockAgentCode = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockAgentCodeColumn.ColumnName]); // �d���S���҃R�[�h
            stockDetailWork.GoodsKindCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.GoodsKindCodeColumn.ColumnName]); // ���i����
            stockDetailWork.MakerKanaName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.MakerKanaNameColumn.ColumnName]); // ���[�J�[�J�i����
            stockDetailWork.CmpltMakerKanaName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.CmpltMakerKanaNameColumn.ColumnName]); // ���[�J�[�J�i���́i�ꎮ�j
            stockDetailWork.GoodsNameKana = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.GoodsNameKanaColumn.ColumnName]); // ���i���̃J�i
            stockDetailWork.GoodsLGroup = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.GoodsLGroupColumn.ColumnName]); // ���i�啪�ރR�[�h
            stockDetailWork.GoodsLGroupName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.GoodsLGroupNameColumn.ColumnName]); // ���i�啪�ޖ���
            stockDetailWork.GoodsMGroup = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.GoodsMGroupColumn.ColumnName]); // ���i�����ރR�[�h
            stockDetailWork.GoodsMGroupName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.GoodsMGroupNameColumn.ColumnName]); // ���i�����ޖ���
            stockDetailWork.BLGroupName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.BLGroupNameColumn.ColumnName]); // BL�O���[�v�R�[�h����
            stockDetailWork.BLGoodsFullName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.BLGoodsFullNameColumn.ColumnName]); // BL���i�R�[�h���́i�S�p�j
            stockDetailWork.EnterpriseGanreCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.EnterpriseGanreCodeColumn.ColumnName]); // ���Е��ރR�[�h
            stockDetailWork.EnterpriseGanreName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.EnterpriseGanreNameColumn.ColumnName]); // ���Е��ޖ���
            stockDetailWork.GoodsRateRank = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.GoodsRateRankColumn.ColumnName]); // ���i�|�������N
            stockDetailWork.CustRateGrpCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.CustRateGrpCodeColumn.ColumnName]); // ���Ӑ�|���O���[�v�R�[�h
            stockDetailWork.SuppRateGrpCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.SuppRateGrpCodeColumn.ColumnName]); // �d����|���O���[�v�R�[�h
            stockDetailWork.ListPriceTaxIncFl = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.ListPriceTaxIncFlColumn.ColumnName]); // �艿�i�ō��C�����j
            stockDetailWork.StockRate = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockRateColumn.ColumnName]); // �d����
            stockDetailWork.RateSectStckUnPrc = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateSectStckUnPrcColumn.ColumnName]); // �|���ݒ苒�_�i�d���P���j
            stockDetailWork.RateDivStckUnPrc = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateDivStckUnPrcColumn.ColumnName]); // �|���ݒ�敪�i�d���P���j
            stockDetailWork.UnPrcCalcCdStckUnPrc = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.UnPrcCalcCdStckUnPrcColumn.ColumnName]); // �P���Z�o�敪�i�d���P���j
            stockDetailWork.PriceCdStckUnPrc = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.PriceCdStckUnPrcColumn.ColumnName]); // ���i�敪�i�d���P���j
            stockDetailWork.StdUnPrcStckUnPrc = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.StdUnPrcStckUnPrcColumn.ColumnName]); // ��P���i�d���P���j
            stockDetailWork.FracProcUnitStcUnPrc = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.FracProcUnitStcUnPrcColumn.ColumnName]); // �[�������P�ʁi�d���P���j
            stockDetailWork.FracProcStckUnPrc = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.FracProcStckUnPrcColumn.ColumnName]); // �[�������i�d���P���j
            stockDetailWork.StockUnitTaxPriceFl = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockUnitTaxPriceFlColumn.ColumnName]); // �d���P���i�ō��C�����j
            stockDetailWork.StockUnitChngDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.StockUnitChngDivColumn.ColumnName]); // �d���P���ύX�敪
            stockDetailWork.RateBLGoodsCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.RateBLGoodsCodeColumn.ColumnName]); // BL���i�R�[�h�i�|���j
            stockDetailWork.RateBLGoodsName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateBLGoodsNameColumn.ColumnName]); // BL���i�R�[�h���́i�|���j
            stockDetailWork.RateGoodsRateGrpCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.RateGoodsRateGrpCdColumn.ColumnName]); // ���i�|���O���[�v�R�[�h�i�|���j
            stockDetailWork.RateGoodsRateGrpNm = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateGoodsRateGrpNmColumn.ColumnName]); // ���i�|���O���[�v���́i�|���j
            stockDetailWork.RateBLGroupCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.RateBLGroupCodeColumn.ColumnName]); // BL�O���[�v�R�[�h�i�|���j
            stockDetailWork.RateBLGroupName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.RateBLGroupNameColumn.ColumnName]); // BL�O���[�v���́i�|���j
            stockDetailWork.OrderCnt = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderCntColumn.ColumnName]); // ��������
            stockDetailWork.OrderAdjustCnt = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderAdjustCntColumn.ColumnName]); // ����������
            stockDetailWork.OrderRemainCnt = ConvertDoubleColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderRemainCntColumn.ColumnName]); // �����c��
            stockDetailWork.RemainCntUpdDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcDetail.RemainCntUpdDateColumn.ColumnName]); // �c���X�V��
            stockDetailWork.StockPriceTaxExc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.StockPriceTaxExcColumn.ColumnName]); // �d�����z�i�Ŕ����j
            stockDetailWork.StockPriceTaxInc = ConvertInt64Column(retListRow[_detailDataSet.RetGdsStcDetail.StockPriceTaxIncColumn.ColumnName]); // �d�����z�i�ō��݁j
            stockDetailWork.StockGoodsCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.StockGoodsCdColumn.ColumnName]); // �d�����i�敪
            stockDetailWork.TaxationCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.TaxationCodeColumn.ColumnName]); // �ېŋ敪
            stockDetailWork.StockDtiSlipNote1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.StockDtiSlipNote1Column.ColumnName]); // �d���`�[���ה��l1
            stockDetailWork.SalesCustomerCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.SalesCustomerCodeColumn.ColumnName]); // �̔���R�[�h
            stockDetailWork.SalesCustomerSnm = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.SalesCustomerSnmColumn.ColumnName]); // �̔��旪��
            stockDetailWork.SlipMemo1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.SlipMemo1Column.ColumnName]); // �`�[�����P
            stockDetailWork.SlipMemo2 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.SlipMemo2Column.ColumnName]); // �`�[�����Q
            stockDetailWork.SlipMemo3 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.SlipMemo3Column.ColumnName]); // �`�[�����R
            stockDetailWork.InsideMemo1 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.InsideMemo1Column.ColumnName]); // �Г������P
            stockDetailWork.InsideMemo2 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.InsideMemo2Column.ColumnName]); // �Г������Q
            stockDetailWork.InsideMemo3 = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.InsideMemo3Column.ColumnName]); // �Г������R
            stockDetailWork.AddresseeCode = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.AddresseeCodeColumn.ColumnName]); // �[�i��R�[�h
            stockDetailWork.AddresseeName = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.AddresseeNameColumn.ColumnName]); // �[�i�於��
            stockDetailWork.DirectSendingCd = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.DirectSendingCdColumn.ColumnName]); // �����敪
            stockDetailWork.OrderNumber = ConvertStringColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderNumberColumn.ColumnName]); // �����ԍ�
            stockDetailWork.WayToOrder = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.WayToOrderColumn.ColumnName]); // �������@
            stockDetailWork.DeliGdsCmpltDueDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcDetail.DeliGdsCmpltDueDateColumn.ColumnName]); // �[�i�����\���
            stockDetailWork.ExpectDeliveryDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcDetail.ExpectDeliveryDateColumn.ColumnName]); // ��]�[��
            stockDetailWork.OrderDataCreateDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.OrderDataCreateDivColumn.ColumnName]); // �����f�[�^�쐬�敪
            stockDetailWork.OrderDataCreateDate = ConvertDateTimeColumn(retListRow[_detailDataSet.RetGdsStcDetail.OrderDataCreateDateColumn.ColumnName]); // �����f�[�^�쐬��
            stockDetailWork.OrderFormIssuedDiv = ConvertInt32Column(retListRow[_detailDataSet.RetGdsStcDetail.OrderFormIssuedDivColumn.ColumnName]); // ���������s�ϋ敪

            if (listRow[_detailDataSet.StcDetail.GoodsMakerCdColumn.ColumnName] != DBNull.Value &&
                (string)listRow[_detailDataSet.StcDetail.GoodsMakerCdColumn.ColumnName] != string.Empty)
            {
                stockDetailWork.GoodsMakerCd = Int32.Parse((string)listRow[_detailDataSet.StcDetail.GoodsMakerCdColumn.ColumnName]);        // ���i���[�J�[�R�[�h
            }
            if(listRow[_detailDataSet.StcDetail.BLGroupCodeColumn.ColumnName] != DBNull.Value &&
               (string)listRow[_detailDataSet.StcDetail.BLGroupCodeColumn.ColumnName] != string.Empty)
            {
                stockDetailWork.BLGroupCode = Int32.Parse((string)listRow[_detailDataSet.StcDetail.BLGroupCodeColumn.ColumnName]);          // BL�O���[�v�R�[�h 
            }
            if(listRow[_detailDataSet.StcDetail.BLGoodsCodeColumn.ColumnName] != DBNull.Value &&
               (string)listRow[_detailDataSet.StcDetail.BLGoodsCodeColumn.ColumnName] != string.Empty)
            {
                stockDetailWork.BLGoodsCode = Int32.Parse((string)listRow[_detailDataSet.StcDetail.BLGoodsCodeColumn.ColumnName]);          // BL���i�R�[�h
            }

        }

        #region ���f�[�^�R���o�[�g�p
        private String ConvertStringColumn(object column)
        {
            return (column is String) ? column as String : String.Empty;
        }
        private Int32 ConvertInt32Column(object column)
        {
            return (column is Int32) ? (Int32)column : 0;
        }
        private Int64 ConvertInt64Column(object column)
        {
            return (column is Int64) ? (Int64)column : 0;
        }
        private Double ConvertDoubleColumn(object column)
        {
            return (column is Double) ? (Double)column : 0;
        }
        private DateTime ConvertDateTimeColumn(object column)
        {
            return (column is DateTime) ? (DateTime)column : DateTime.MinValue;
        }
        #endregion ���f�[�^�R���o�[�g�p

        #region ��PMKAU04003AB.cs����̃R�s�[

        /// <summary>
        /// �o�^�p�d���ԕi�`�[�����i�ǉ��p�j
        /// </summary>
        /// <param name="key"></param>
        /// <param name="redStockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="redStockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="parameter">�ԓ`�o�^�p�����[�^</param>
        /// <param name="stockDateForUpdate">�X�V���t</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private void CreateRedStockSlip(StockSlipLogicalKey key, ref StockSlipWork redStockSlip, ref List<StockDetailWork> redStockDetailList, RedSlipWriteParameter parameter, DateTime stockDateForUpdate)
        {
            //--------------------------------------------------------------------
            // ������f�[�^�ǂݍ��ݎ��ɓ����Ɏ擾�����A
            // �@�������͎d���f�[�^�����ɂ��āA�V���ɒǉ��p���R�[�h�𐶐����܂��B
            //--------------------------------------------------------------------
            int supplierSlipCd; // 10:�d��,20:�ԕi
            int stockSlipCdDtl; // 0:�d��,1:�ԕi,2:�l��

            if (parameter.SlipCd == 10)
            {
                supplierSlipCd = 10; // 10:�d��
                stockSlipCdDtl = 0;  // 0:�d��
            }
            else
            {
                supplierSlipCd = 20; // 20:�ԕi
                stockSlipCdDtl = 1;  // 1:�ԕi
            }

            DateTime inputDay = parameter.SalesDate;
            DateTime stockDate = key.StockDate;
            string stockInputCode = parameter.InputEmployeeCd;
            string stockInputName = parameter.InputEmployeeNm;
            int retGoodsReasonDiv = parameter.RetGoodsReasonDiv;
            string retGoodsReason = parameter.ReturnReason;
            string partySaleSlipNum = key.PartySaleSlipNum;

            # region [�`�[]
            redStockSlip.CreateDateTime = DateTime.MinValue; // �쐬����
            redStockSlip.UpdateDateTime = DateTime.MinValue; // �X�V����
            redStockSlip.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
            redStockSlip.FileHeaderGuid = Guid.Empty; // GUID
            redStockSlip.UpdEmployeeCode = string.Empty; // �X�V�]�ƈ��R�[�h
            redStockSlip.UpdAssemblyId1 = string.Empty; // �X�V�A�Z���u��ID1
            redStockSlip.UpdAssemblyId2 = string.Empty; // �X�V�A�Z���u��ID2
            redStockSlip.LogicalDeleteCode = 0; // �_���폜�敪
            redStockSlip.SectionCode = this._loginSectionCode; // ���_�R�[�h�̓��O�C�����_������
            redStockSlip.DebitNoteDiv = 0; // �ԓ`�敪
            redStockSlip.DebitNLnkSuppSlipNo = 0; // �ԍ��A���d���`�[�ԍ�
            redStockSlip.SupplierSlipCd = supplierSlipCd; // �d���`�[�敪
            redStockSlip.StockSlipUpdateCd = 0; // �d���`�[�X�V�敪
            redStockSlip.InputDay = inputDay; // ���͓�
            redStockSlip.ArrivalGoodsDay = stockDate; // ���ד�
            if (stockDateForUpdate != null && stockDateForUpdate != DateTime.MinValue)
            {
                redStockSlip.StockDate = stockDateForUpdate; // �d���� �O���b�h��œ��͂��ꂽ�d����
            }
            else
            {
                redStockSlip.StockDate = stockDate; // �d����
            }
            redStockSlip.StockAddUpADate = stockDate; // �d���v����t
            redStockSlip.DelayPaymentDiv = 0; // �����敪
            redStockSlip.StockInputCode = stockInputCode; // �d�����͎҃R�[�h
            redStockSlip.StockInputName = stockInputName; // �d�����͎Җ���
            redStockSlip.StockAgentCode = stockInputCode; // �d���S���҃R�[�h
            redStockSlip.StockAgentName = stockInputName; // �d���S���Җ���
            redStockSlip.RetGoodsReasonDiv = retGoodsReasonDiv; // �ԕi���R�R�[�h
            redStockSlip.RetGoodsReason = retGoodsReason; // �ԕi���R
            redStockSlip.PartySaleSlipNum = partySaleSlipNum; // �����`�[�ԍ�
            redStockSlip.SupplierSlipNote1 = parameter.SlipNote; // �d���`�[���l1
            redStockSlip.SupplierSlipNote2 = parameter.SlipNote2; // �d���`�[���l2
            redStockSlip.DetailRowCount = redStockDetailList.Count; // ���׍s��
            redStockSlip.EdiSendDate = DateTime.MinValue; // �d�c�h���M��
            redStockSlip.EdiTakeInDate = DateTime.MinValue; // �d�c�h�捞��
            redStockSlip.UoeRemark1 = string.Empty; // �t�n�d���}�[�N�P
            redStockSlip.UoeRemark2 = string.Empty; // �t�n�d���}�[�N�Q
            redStockSlip.SlipPrintDivCd = 0; // �`�[���s�敪
            redStockSlip.SlipPrintFinishCd = 0; // �`�[���s�ϋ敪
            redStockSlip.StockSlipPrintDate = DateTime.MinValue; // �d���`�[���s��
            redStockSlip.SlipPrtSetPaperId = string.Empty; // �`�[����ݒ�p���[ID
            # endregion

            // ���׃��[�v
            for (int index = 0; index < redStockDetailList.Count; index++)
            {
                StockDetailWork redStockDetail = redStockDetailList[index];
                int supplierFormalSrc = redStockDetail.SupplierFormal;
                long stockSlipDtlNumSrc = redStockDetail.StockSlipDtlNum;

                # region [����]
                redStockDetail.CreateDateTime = DateTime.MinValue; // �쐬����
                redStockDetail.UpdateDateTime = DateTime.MinValue; // �X�V����
                redStockDetail.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
                redStockDetail.FileHeaderGuid = Guid.Empty; // GUID
                redStockDetail.UpdEmployeeCode = string.Empty; // �X�V�]�ƈ��R�[�h
                redStockDetail.UpdAssemblyId1 = string.Empty; // �X�V�A�Z���u��ID1
                redStockDetail.UpdAssemblyId2 = string.Empty; // �X�V�A�Z���u��ID2
                redStockDetail.LogicalDeleteCode = 0; // �_���폜�敪
                redStockDetail.StockRowNo = (index + 1); // �d���s�ԍ�
                redStockDetail.SectionCode = redStockSlip.SectionCode; // ���_�R�[�h ���O�C�����_������
                redStockDetail.AcptAnOdrStatusSync = 30; // �󒍃X�e�[�^�X�i�����j=30:����
                redStockDetail.StockSlipCdDtl = stockSlipCdDtl; // �d���`�[�敪�i���ׁj
                redStockDetail.StockInputCode = redStockSlip.StockInputCode; // �d�����͎҃R�[�h
                redStockDetail.StockInputName = redStockSlip.StockInputName; // �d�����͎Җ���
                redStockDetail.StockAgentCode = redStockSlip.StockAgentCode; // �d���S���҃R�[�h
                redStockDetail.StockAgentName = redStockSlip.StockAgentName; // �d���S���Җ���
                redStockDetail.RemainCntUpdDate = DateTime.MinValue; // �c���X�V��
                redStockDetail.StockDtiSlipNote1 = string.Empty; // �d���`�[���ה��l1
                redStockDetail.SlipMemo1 = string.Empty; // �`�[�����P
                redStockDetail.SlipMemo2 = string.Empty; // �`�[�����Q
                redStockDetail.SlipMemo3 = string.Empty; // �`�[�����R
                redStockDetail.InsideMemo1 = string.Empty; // �Г������P
                redStockDetail.InsideMemo2 = string.Empty; // �Г������Q
                redStockDetail.InsideMemo3 = string.Empty; // �Г������R
                redStockDetail.SupplierCd = redStockSlip.SupplierCd; // �d����R�[�h
                redStockDetail.SupplierSnm = redStockSlip.SupplierSnm; // �d���旪��
                redStockDetail.AddresseeCode = 0; // �[�i��R�[�h
                redStockDetail.AddresseeName = string.Empty; // �[�i�於��
                redStockDetail.DirectSendingCd = 0; // �����敪
                redStockDetail.OrderNumber = string.Empty; // �����ԍ�
                redStockDetail.WayToOrder = 0; // �������@
                redStockDetail.DeliGdsCmpltDueDate = DateTime.MinValue; // �[�i�����\���
                redStockDetail.ExpectDeliveryDate = DateTime.MinValue; // ��]�[��
                redStockDetail.OrderDataCreateDiv = 0; // �����f�[�^�쐬�敪
                redStockDetail.OrderDataCreateDate = DateTime.MinValue; // �����f�[�^�쐬��
                redStockDetail.OrderFormIssuedDiv = 0; // ���������s�ϋ敪
                # endregion

                # region [���׋��z�Z�o]
                double stockUnitPriceTaxExc;
                double stockUnitPriceTaxInc;
                long stockPriceConsTax;
                long stockPriceTaxExc;
                long stockPriceTaxInc;
                // �Z�o
                CalculateStockPrice(redStockSlip, redStockDetail, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax);
                // �i�[
                redStockDetail.StockUnitPriceFl = stockUnitPriceTaxExc;
                redStockDetail.StockUnitTaxPriceFl = stockUnitPriceTaxInc;
                redStockDetail.StockPriceTaxExc = stockPriceTaxExc;
                redStockDetail.StockPriceTaxInc = stockPriceTaxInc;
                redStockDetail.StockPriceConsTax = stockPriceConsTax;
                # endregion
            }
        }

        /// <summary>
        /// �w�肵������ŗ������Ɏd�����׃f�[�^�s�I�u�W�F�N�g�̋��z�����X�V���܂��B
        /// </summary>
        /// <param name="stockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockDetail">�d�����׃f�[�^�I�u�W�F�N�g</param>
        /// <param name="stockUnitPriceFl">�d���P���i�Ŕ��C�����j</param>
        /// <param name="stockUnitTaxPriceFl">�d���P���i�ō��C�����j</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockPriceConsTax">�d�����z����Ŋz</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        public void CalculateStockPrice(StockSlipWork stockSlip, StockDetailWork stockDetail, out double stockUnitPriceFl, out double stockUnitTaxPriceFl, out long stockPriceTaxExc, out long stockPriceTaxInc, out long stockPriceConsTax)
        {
            stockUnitPriceFl = 0;
            stockUnitTaxPriceFl = 0;
            stockPriceTaxExc = 0;
            stockPriceTaxInc = 0;
            stockPriceConsTax = 0;

            // �v�㏈���ȊO����R�[�����ꂽ�ꍇ�͎d��������擾
            if (this._supplier == null)
            {
                // �d������擾
                if (this._supplierAcs.Read(out this._supplier, this._enterpriseCode, stockSlip.SupplierCd) != 0 ||
                    this._supplier == null)
                {
                    return;
                }
            }

            // ���P��(�ō�)�Z�o
            this.CalcTaxExcAndTaxIncForStock(stockDetail.TaxationCode, stockSlip.SupplierCd, this._taxRate, this._supplier.SuppTtlAmntDspWayCd, stockDetail.StockUnitPriceFl, out stockUnitPriceFl, out stockUnitTaxPriceFl);


            // �d�����z�[�������R�[�h
            int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);
            // ����Œ[�������敪
            int taxFracProcCode = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);


            // ��ېŎ��͐ō����z���Ŕ������z
            if (stockSlip.SuppCTaxLayCd == 9)
            {
                stockDetail.StockPriceTaxInc = stockDetail.StockPriceTaxExc;
                stockDetail.StockUnitTaxPriceFl = stockDetail.StockUnitPriceFl;
            }
            else
            {
                // �ېŋ敪���u�O�Łv�̏ꍇ
                if (stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    double stockUnitPrice = stockDetail.StockUnitPriceFl;

                    if (this.CalculateStockPrice(
                        stockDetail.StockCount,
                        stockUnitPrice,
                        stockDetail.TaxationCode,
                        stockSlip.SupplierConsTaxRate,
                        stockMoneyFrcProcCd,
                        taxFracProcCode,
                        out stockPriceTaxInc,
                        out stockPriceTaxExc,
                        out stockPriceConsTax))
                    {
                        if (stockDetail.StockGoodsCd <= 1)
                        {
                            stockDetail.StockPriceTaxInc = stockPriceTaxInc;
                        }
                    }
                }
                // �ېŋ敪���u���Łv�̏ꍇ
                else if (stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    double stockUnitPrice = stockDetail.StockUnitPriceFl;

                    if (this.CalculateStockPrice(
                        stockDetail.StockUnitPriceFl,
                        stockUnitPrice,
                        stockDetail.TaxationCode,
                        stockSlip.SupplierConsTaxRate,
                        stockMoneyFrcProcCd,
                        taxFracProcCode,
                        out stockPriceTaxInc,
                        out stockPriceTaxExc,
                        out stockPriceConsTax))
                    {
                        if (stockDetail.StockGoodsCd <= 1)
                        {
                            stockDetail.StockPriceTaxExc = stockPriceTaxExc;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z���܂��B
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="displayPrice">�Ώۋ��z</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private void CalcTaxExcAndTaxIncForStock(int taxationCode, int supplierCd, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // �d����}�X�^�������Œ[�����������擾
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, supplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
            double fracProcUnit;
            int fracProcCd;
            this.GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

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

        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="stockCount">�d����</param>
        /// <param name="stockUnitPrice">�d���P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="taxRate">����ŗ�</param>
        /// <param name="stockMoneyFrcProcCd">�d�����z�[�������R�[�h</param>
        /// <param name="taxFracProcCode">����Œ[�������敪</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <param name="stockPriceConsTax">�d�������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private bool CalculateStockPrice(double stockCount, double stockUnitPrice, int taxationCode, double taxRate, int stockMoneyFrcProcCd, int taxFracProcCode,
            out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax)
        {
            double taxFracProcUnit;
            int taxFracProcCd;
            GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd);

            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;
            stockPriceConsTax = 0;

            // �d������0�܂��͎d���P����0�̏ꍇ�͂��ׂ�0�ŏI��
            if ((stockCount == 0) || (stockUnitPrice == 0)) return true;

            // �O�ł̏ꍇ
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = stockUnitPrice;	// �P���i�Ŕ����j
                double unitPriceInc;					// �P���i�ō��݁j
                double unitPriceTax;					// �P���i����Łj
                long priceExc = 0;						// ���i�i�Ŕ����j
                long priceInc;							// ���i�i�ō��݁j
                long priceTax;							// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;			// �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;			// �d�����z�i�Ŕ����j		
                stockPriceConsTax = priceTax;			// �d�������
            }
            // ���ł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;					// �P���i�Ŕ����j
                double unitPriceInc = stockUnitPrice;	// �P���i�ō��݁j
                double unitPriceTax;					// �P���i����Łj
                long priceExc;							// ���i�i�Ŕ����j
                long priceInc = 0;						// ���i�i�ō��݁j
                long priceTax;							// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxExcFromTaxInc((int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;			// �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;			// �d�����z�i�Ŕ����j
                stockPriceConsTax = priceTax;			// �d�������
            }
            // ��ېł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = stockUnitPrice;	// �P���i�Ŕ����j
                double unitPriceInc;					// �P���i�ō��݁j
                double unitPriceTax;					// �P���i����Łj
                long priceExc = 0;						// ���i�i�Ŕ����j
                long priceInc;							// ���i�i�ō��݁j
                long priceTax;							// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxIncFromTaxExc((int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceExc;			// �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;			// �d�����z�i�ō��݁j
                stockPriceConsTax = priceTax;			// �d�������
            }

            return true;
        }

        /// <summary>
        /// �[�������P�ʁA�[�������敪�擾����
        /// </summary>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="fractionProcUnit">�[�������P��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        public void GetStockFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
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
            List<StockProcMoney> stockProcMoneyList = this._stockProcMoneyList.FindAll(
                delegate(StockProcMoney sProcMoney)
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
            stockProcMoneyList.Sort(new StockProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // ������z�Y�����R�[�h�擾
            //-----------------------------------------------------------------------------
            StockProcMoney stockProcMoney = stockProcMoneyList.Find(
                delegate(StockProcMoney spm)
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
            if (stockProcMoney != null)
            {
                fractionProcUnit = stockProcMoney.FractionProcUnit;
                fractionProcCd = stockProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// �o�^�p�ԓ`�@�萔�����גǉ�����
        /// </summary>
        /// <param name="redStockDetailList">�d�����׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="redStockSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="parameter">�ԓ`�o�^�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private void AddFeeDetail(ref List<StockDetailWork> redStockDetailList, ref StockSlipWork redStockSlip, RedSlipWriteParameter parameter)
        {
            # region [�f�[�^����]
            // �i��
            const string feeName = "�ԕi�萔���z";

            // �ېŋ敪�E�Ŕ����z�E�ō����z
            int taxationCode = 0;
            long stockMoneyTaxExc;
            long stockMoneyTaxInc;
            long stockPriceConsTax;
            this.CalculateSalesMoneyForFee(redStockSlip, parameter.FeePriceOfTotal, out taxationCode, out stockMoneyTaxExc, out stockMoneyTaxInc, out stockPriceConsTax);
            # endregion

            StockDetailWork feeDetail = new StockDetailWork();

            string stockInputCode = parameter.InputEmployeeCd;
            string stockInputName = parameter.InputEmployeeNm;

            # region [�萔���f�[�^�i�[]
            feeDetail.CreateDateTime = DateTime.MinValue; // �쐬����
            feeDetail.UpdateDateTime = DateTime.MinValue; // �X�V����
            feeDetail.EnterpriseCode = parameter.EnterpriseCode; // ��ƃR�[�h
            feeDetail.FileHeaderGuid = Guid.Empty; // GUID
            feeDetail.UpdEmployeeCode = string.Empty; // �X�V�]�ƈ��R�[�h
            feeDetail.UpdAssemblyId1 = string.Empty; // �X�V�A�Z���u��ID1
            feeDetail.UpdAssemblyId2 = string.Empty; // �X�V�A�Z���u��ID2
            feeDetail.LogicalDeleteCode = 0; // �_���폜�敪
            feeDetail.AcceptAnOrderNo = 0; // �󒍔ԍ�
            feeDetail.SupplierFormal = 0; // �d���`�� 3:�d���ԕi�\��
            feeDetail.SupplierSlipNo = 0; // �d���`�[�ԍ�
            feeDetail.StockRowNo = redStockDetailList.Count + 1; // �d���s�ԍ�
            feeDetail.SectionCode = redStockDetailList[0].SectionCode; // ���_�R�[�h
            feeDetail.SubSectionCode = redStockDetailList[0].SubSectionCode; // ����R�[�h
            feeDetail.CommonSeqNo = 0; // ���ʒʔ�
            feeDetail.StockSlipDtlNum = 0; // �d�����גʔ�
            feeDetail.SupplierFormalSrc = 0; // �d���`���i���j
            feeDetail.StockSlipDtlNumSrc = 0; // �d�����גʔԁi���j
            feeDetail.AcptAnOdrStatusSync = 0; // �󒍃X�e�[�^�X(����)
            feeDetail.SalesSlipDtlNumSync = 0; // ���㖾�גʔԁi�����j
            feeDetail.StockSlipCdDtl = (int)StockSlipCdDtl.Discount; // �d���`�[�敪�i���ׁj�@��2:�l��
            feeDetail.StockInputCode = stockInputCode; // �d�����͎҃R�[�h
            feeDetail.StockInputName = stockInputName; // �d�����͎Җ���
            feeDetail.StockAgentCode = stockInputCode; // �d���S���҃R�[�h
            feeDetail.StockAgentName = stockInputName; // �d���S���Җ���
            feeDetail.GoodsKindCode = 0; // ���i����
            feeDetail.GoodsMakerCd = 0; // ���i���[�J�[�R�[�h
            feeDetail.MakerName = string.Empty; // ���[�J�[����
            feeDetail.MakerKanaName = string.Empty; // ���[�J�[�J�i����
            feeDetail.CmpltMakerKanaName = string.Empty; // ���[�J�[�J�i���́i�ꎮ�j
            feeDetail.GoodsNo = string.Empty; // ���i�ԍ�
            feeDetail.GoodsName = feeName; // ���i���́@���u�ԕi�萔���z�v
            feeDetail.GoodsNameKana = feeName; // ���i���̃J�i�@���u�ԕi�萔���z�v
            feeDetail.GoodsLGroup = 0; // ���i�啪�ރR�[�h
            feeDetail.GoodsLGroupName = string.Empty; // ���i�啪�ޖ���
            feeDetail.GoodsMGroup = 0; // ���i�����ރR�[�h
            feeDetail.GoodsMGroupName = string.Empty; // ���i�����ޖ���
            feeDetail.BLGroupCode = 0; // BL�O���[�v�R�[�h
            feeDetail.BLGroupName = string.Empty; // BL�O���[�v�R�[�h����
            feeDetail.BLGoodsCode = 0; // BL���i�R�[�h
            feeDetail.BLGoodsFullName = string.Empty; // BL���i�R�[�h���́i�S�p�j
            feeDetail.EnterpriseGanreCode = 0; // ���Е��ރR�[�h
            feeDetail.EnterpriseGanreName = string.Empty; // ���Е��ޖ���
            feeDetail.WarehouseCode = string.Empty; // �q�ɃR�[�h
            feeDetail.WarehouseName = string.Empty; // �q�ɖ���
            feeDetail.WarehouseShelfNo = string.Empty; // �q�ɒI��
            feeDetail.StockOrderDivCd = 0; // �d���݌Ɏ�񂹋敪
            feeDetail.OpenPriceDiv = 0; // �I�[�v�����i�敪
            feeDetail.GoodsRateRank = string.Empty; // ���i�|�������N
            feeDetail.CustRateGrpCode = 0; // ���Ӑ�|���O���[�v�R�[�h
            feeDetail.SuppRateGrpCode = 0; // �d����|���O���[�v�R�[�h
            feeDetail.ListPriceTaxExcFl = 0; // �艿�i�Ŕ��C�����j
            feeDetail.ListPriceTaxIncFl = 0; // �艿�i�ō��C�����j
            feeDetail.StockRate = 0; // �d����
            feeDetail.RateSectStckUnPrc = string.Empty; // �|���ݒ苒�_�i�d���P���j
            feeDetail.RateDivStckUnPrc = string.Empty; // �|���ݒ�敪�i�d���P���j
            feeDetail.UnPrcCalcCdStckUnPrc = 0; // �P���Z�o�敪�i�d���P���j
            feeDetail.PriceCdStckUnPrc = 0; // ���i�敪�i�d���P���j
            feeDetail.StdUnPrcStckUnPrc = 0; // ��P���i�d���P���j
            feeDetail.FracProcUnitStcUnPrc = 0; // �[�������P�ʁi�d���P���j
            feeDetail.FracProcStckUnPrc = 0; // �[�������i�d���P���j
            feeDetail.StockUnitPriceFl = 0; // �d���P���i�Ŕ��C�����j
            feeDetail.StockUnitTaxPriceFl = 0; // �d���P���i�ō��C�����j
            feeDetail.StockUnitChngDiv = 0; // �d���P���ύX�敪
            feeDetail.BfStockUnitPriceFl = 0; // �ύX�O�d���P���i�����j
            feeDetail.BfListPrice = 0; // �ύX�O�艿
            feeDetail.RateBLGoodsCode = 0; // BL���i�R�[�h�i�|���j
            feeDetail.RateBLGoodsName = string.Empty; // BL���i�R�[�h���́i�|���j
            feeDetail.RateGoodsRateGrpCd = 0; // ���i�|���O���[�v�R�[�h�i�|���j
            feeDetail.RateGoodsRateGrpNm = string.Empty; // ���i�|���O���[�v���́i�|���j
            feeDetail.RateBLGroupCode = 0; // BL�O���[�v�R�[�h�i�|���j
            feeDetail.RateBLGroupName = string.Empty; // BL�O���[�v���́i�|���j
            feeDetail.StockCount = 0; // �d����
            feeDetail.OrderCnt = 0; // �󒍐���
            feeDetail.OrderAdjustCnt = 0; // �󒍒�����
            feeDetail.OrderRemainCnt = 0; // �󒍎c��
            feeDetail.RemainCntUpdDate = DateTime.MinValue; // �c���X�V��
            feeDetail.StockPriceTaxExc = stockMoneyTaxExc; // �d�����z�i�Ŕ����j�@���萔���z
            feeDetail.StockPriceTaxInc = stockMoneyTaxInc; // �d�����z�i�ō��݁j�@���萔���z
            feeDetail.StockGoodsCd = 0; // �d�����i�敪
            feeDetail.StockPriceConsTax = stockPriceConsTax; // �d�����z����Ŋz
            feeDetail.TaxationCode = taxationCode; // �ېŋ敪
            feeDetail.StockDtiSlipNote1 = string.Empty; // �d���`�[���ה��l1
            feeDetail.SalesCustomerCode = 0; // �̔���R�[�h
            feeDetail.SalesCustomerSnm = string.Empty; // �̔��旪��
            feeDetail.SlipMemo1 = string.Empty; // �`�[�����P
            feeDetail.SlipMemo2 = string.Empty; // �`�[�����Q
            feeDetail.SlipMemo3 = string.Empty; // �`�[�����R
            feeDetail.InsideMemo1 = string.Empty; // �Г������P
            feeDetail.InsideMemo2 = string.Empty; // �Г������Q
            feeDetail.InsideMemo3 = string.Empty; // �Г������R
            feeDetail.SupplierCd = 0; // �d����R�[�h
            feeDetail.SupplierSnm = string.Empty; // �d���旪��
            feeDetail.AddresseeCode = 0; // �[�i��R�[�h
            feeDetail.AddresseeName = string.Empty; // �[�i�旪��
            feeDetail.DirectSendingCd = 0; // �����敪
            feeDetail.OrderNumber = string.Empty; // �����ԍ�
            feeDetail.WayToOrder = 0; // �������@
            feeDetail.DeliGdsCmpltDueDate = DateTime.MinValue; // �[�i�����\���
            feeDetail.ExpectDeliveryDate = DateTime.MinValue; // ��]�[��
            feeDetail.OrderDataCreateDiv = 0; // �����f�[�^�쐬�敪
            feeDetail.OrderDataCreateDate = DateTime.MinValue; // �����f�[�^�쐬��
            feeDetail.OrderFormIssuedDiv = 0; // ���������s�ϋ敪
            # endregion

            redStockDetailList.Add(feeDetail);

            // �萔�����ׂ��d�����׃f�[�^�Ƃ��ĂP���ǉ������̂ŁA���׍s�������Z
            redStockSlip.DetailRowCount++;
        }

        /// <summary>
        /// �萔�����z�Z�o����
        /// </summary>
        /// <param name="redSalesSlip">�d���f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesMoneyDisplay">������z</param>
        /// <param name="taxationDivCd">�ېŋ敪</param>
        /// <param name="salesMoneyTaxExc">������z�i�Ŕ����j</param>
        /// <param name="salesMoneyTaxInc">������z�i�Ŕ����j</param>
        /// <param name="salesPriceConsTax"������z����Ŋz></param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private void CalculateSalesMoneyForFee(StockSlipWork redStockSlip, long salesMoneyDisplay, out int taxationDivCd, out long salesMoneyTaxExc, out long salesMoneyTaxInc, out long salesPriceConsTax)
        {
            // ���z�����R�[�h�擾
            int salesTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, redStockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);


            // �Œ[�������敪�R�[�h�E�P�ʎ擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // ��ې�
            if (redStockSlip.SuppCTaxLayCd == (int)ConsTaxLayMethod.TaxExempt)
            {
                salesMoneyTaxExc = salesMoneyDisplay;
                salesMoneyTaxInc = salesMoneyDisplay;
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // ���z�\�����Ȃ�
            else if (redStockSlip.SuppTtlAmntDspWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
            {
                salesMoneyTaxExc = salesMoneyDisplay;
                salesMoneyTaxInc = salesMoneyDisplay + CalculateTax.GetTaxFromPriceExc(redStockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoneyDisplay);
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxExc;
            }
            // ���z�\������
            else
            {
                salesMoneyTaxExc = salesMoneyDisplay - CalculateTax.GetTaxFromPriceInc(redStockSlip.SupplierConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoneyDisplay);
                salesMoneyTaxInc = salesMoneyDisplay;
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
            }

            salesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
        }

        #endregion

        /// <summary>
        /// ���i���ǂݍ���
        /// </summary>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <returns>status</returns>
        /// <br>Note       : ���i���擾���܂��B</br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        public int ReadGoods(string goodsNo, int goodsMakerCd, out GoodsUnitData goodsUnitData)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            goodsUnitData = null;

            if (_goodsAcs == null)
            {
                _goodsAcs = new GoodsAcs();
                string retMessage;
                _goodsAcs.SearchInitial(_enterpriseCode, _loginSectionCode, out retMessage);

                // ���i�f�B�N�V���i������
                _goodsUnitDataDic = new Dictionary<GoodsKey, GoodsUnitData>();
            }

            // �L���b�V������T��
            GoodsKey key = new GoodsKey(goodsNo, goodsMakerCd);
            if (_goodsUnitDataDic.ContainsKey(key))
            {
                goodsUnitData = _goodsUnitDataDic[key];
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                // ���i�ǂݍ���(goodsUnitData�ɂ͍݌Ƀ��X�g���܂܂��)
                status = _goodsAcs.Read(this._enterpriseCode, goodsMakerCd, goodsNo, ConstantManagement.LogicalMode.GetData0, out goodsUnitData);

                // �f�B�N�V���i���ɒǉ�
                if (!_goodsUnitDataDic.ContainsKey(new GoodsKey(goodsUnitData)))
                {
                    _goodsUnitDataDic.Add(new GoodsKey(goodsUnitData), goodsUnitData);
                }
            }
            return status;
        }

        /// <summary>
        /// �݌Ɏ擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="warehouseCode">�݌ɃR�[�h</param>
        /// <param name="retStock">�݌�</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �݌ɂ��擾���܂��B</br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        public int SelectStock(GoodsUnitData goodsUnitData, string warehouseCode, out Stock retStock)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retStock = null;

            // �p�����[�^�`�F�b�N����
            if (goodsUnitData == null ||
                 warehouseCode.Trim() == string.Empty ||
                 goodsUnitData.StockList == null ||
                 goodsUnitData.StockList.Count == 0)
            {
                return status;
            }

            // ���X�g������T��
            retStock = goodsUnitData.StockList.Find(
                        delegate(Stock stock)
                        {
                            return (stock.WarehouseCode.Trim() == warehouseCode.Trim());
                        }
                        );

            if (retStock != null)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        # region [�ԓ`�d�����ה�����z�Z�o]
        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="redSlipRow">�ԓ`���f�[�^�Z�b�g</param>
        /// <param name="listRow">�d�����f�[�^�Z�b�g</param>
        /// <param name="listRow">�d�����f�[�^�Z�b�g(�ԕi�v��g�p��)</param>
        /// <param name="detailRow">�d�����׏��f�[�^�Z�b�g</param>
        /// <param name="retDetailRow">�d�����׏��f�[�^�Z�b�g(�ԕi�v��g�p��)</param>
        /// <param name="stockPriceTaxExc">�ԕi�`�[���z</param>
        /// <remarks>
        /// <br>Note       : �d�����z���v�Z���܂��B</br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        public void CalculationSalesMoney(SuppPtrStcDetailDataSet.RedSlipDetailRow redSlipRow, SuppPtrStcDetailDataSet.StcListRow listRow,�@SuppPtrStcDetailDataSet.RetGdsStcListRow retListRow, SuppPtrStcDetailDataSet.StcDetailRow detailRow, SuppPtrStcDetailDataSet.RetGdsStcDetailRow retDetailRow, out long stockPriceTaxExc)
        {
            // �ԕi�v��p�p�����[�^������
            RetGdsAddUpWriteParameter para = new SuppPtrStockDetailAcs.RetGdsAddUpWriteParameter();
            // �d���f�[�^������
            StockSlipWork stockSlip = new StockSlipWork();
            // �d�����׏�����
            StockDetailWork stockDetail = new StockDetailWork();
            // �p�����[�^�Ɋ�ƃR�[�h�ݒ�
            para.EnterpriseCode = this._enterpriseCode;
            // �d���f�[�^�쐬
            SlcListFromStockSlipWorkData(para, listRow, retListRow, out stockSlip);
            // �d�����׃f�[�^�쐬
            RedSlipFromStockDetailWorkData(para, detailRow, retDetailRow, out stockDetail);

            // RedSlipDetailRow�̕ԕi�����d�����׃f�[�^�̎d�����ɃZ�b�g����
            stockDetail.StockCount = redSlipRow.ReturnCnt;
            // RedSlipDetailRow�̌������d�����׃f�[�^�̎d���P���ɃZ�b�g����
            stockDetail.StockUnitPriceFl = redSlipRow.StockUnitPrice;
            // �d�����z�Čv�Z
            double stockUnitPriceTaxExc;  // �d���P���i�Ŕ��C�����j
            double stockUnitPriceTaxInc;  // �d���P���i�ō��C�����j
            long stockPriceConsTax;       // �d�����z����Ŋz
            long stockPriceTaxInc;        // �d�����z�i�ō��݁j
            // ���z���Z�o
            CalculateStockPrice(stockSlip, stockDetail, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax);
        }

        #endregion

        #region class
        #region �p�����[�^
        /// <summary>
        /// �ԕi�v��p�p�����[�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : [�d���ԕi�v��] �V�K�ǉ�</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2013/01/21</br>
        /// </remarks>
        public class RetGdsAddUpWriteParameter
        {
            /// <summary>��ƃR�[�h</summary>
            private string _enterpriseCode;
            /// <summary>�`�[�敪</summary>
            private int _slipCd;
            /// <summary>�S���ҏ]�ƈ��R�[�h</summary>
            private string _stockAgentCd;
            /// <summary>�S���ҏ]�ƈ�����</summary>
            private string _stockAgentNm;
            /// <summary>�ԕi���t</summary>
            private DateTime _retGdsDate;
            /// <summary>�萔���z(���v)</summary>
            private Int64 _feePriceOfTotal;
            /// <summary>���l�P</summary>
            private string _slipNote;
            /// <summary>���l�Q</summary>
            private string _slipNote2;
            /// <summary>�ԕi���R</summary>
            private string _returnReason;
            /// <summary>�ԕi���R�R�[�h</summary>
            private Int32 _returnReasonDiv;
            /// <summary>���_�R�[�h</summary>
            private string _sectionCode;
            /// <summary>�d����R�[�h</summary>
            private int _supplierCode;

            /// <summary>
            /// ��ƃR�[�h
            /// </summary>
            public string EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }
            /// <summary>
            /// �`�[�敪
            /// </summary>
            public int SlipCd
            {
                get { return _slipCd; }
                set { _slipCd = value; }
            }

            /// <summary>
            /// �S���]�ƈ��R�[�h
            /// </summary>
            public string StockAgentCd
            {
                get { return _stockAgentCd; }
                set { _stockAgentCd = value; }
            }

            /// <summary>
            /// �S���]�ƈ�����
            /// </summary>
            public string StockAgentNm
            {
                get { return _stockAgentNm; }
                set { _stockAgentNm = value; }
            }

            /// <summary>
            /// �ԕi���t
            /// </summary>
            public DateTime RetGdsDate
            {
                get { return _retGdsDate; }
                set { _retGdsDate = value; }
            }

            /// <summary>
            /// �萔���z(���v)
            /// </summary>
            public Int64 FeePriceOfTotal
            {
                get { return _feePriceOfTotal; }
                set { _feePriceOfTotal = value; }
            }

            /// <summary>
            /// ���l�P
            /// </summary>
            public string SlipNote
            {
                get { return _slipNote; }
                set { _slipNote = value; }
            }

            /// <summary>
            /// ���l�Q
            /// </summary>
            public string SlipNote2
            {
                get { return _slipNote2; }
                set { _slipNote2 = value; }
            }

            /// <summary>
            /// �ԕi���R
            /// </summary>
            public string ReturnReason
            {
                get { return _returnReason; }
                set { _returnReason = value; }
            }

            /// <summary>
            /// �ԕi���R�R�[�h
            /// </summary>
            public Int32 RetGoodsReasonDiv
            {
                get { return _returnReasonDiv; }
                set { _returnReasonDiv = value; }
            }

            /// <summary>
            /// ���_�R�[�h
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }

            /// <summary>
            /// �d����R�[�h
            /// </summary>
            public int SupplierCode
            {
                get { return _supplierCode; }
                set { _supplierCode = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public RetGdsAddUpWriteParameter()
            {
                _enterpriseCode = string.Empty;
                _slipCd = 0;
                _stockAgentCd = string.Empty;
                _stockAgentNm = string.Empty;
                _retGdsDate = DateTime.MinValue;
                _feePriceOfTotal = 0;
                _slipNote = string.Empty;
                _slipNote2 = string.Empty;
                _returnReason = string.Empty;
                _sectionCode = string.Empty;
                _supplierCode = 0;
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="enterpriseCode">��ƃR�[�h</param>
            /// <param name="slipCd">�`�[�敪</param>
            /// <param name="stockAgentCd">�S���ҏ]�ƈ��R�[�h</param>
            /// <param name="stockAgentNm">�S���ҏ]�ƈ�����</param>
            /// <param name="retGdsDate">�ԕi���t</param>
            /// <param name="feePriceOfTotal">�萔���z(���v)</param>
            /// <param name="slipNote">���l�P</param>
            /// <param name="slipNote2">���l�Q</param>
            /// <param name="returnReason">�ԕi���R</param>
            /// <param name="returnReasonDiv">�ԕi���R�R�[�h</param>
            /// <param name="sectionCode">���_�R�[�h</param>
            /// <param name="supplierCode">�d����R�[�h</param>
            public RetGdsAddUpWriteParameter(string enterpriseCode, int slipCd, string stockAgentCd, string stockAgentNm, DateTime retGdsDate, double feeRateOfOrder, Int64 feePriceOfOrder, double feeRateOfStock, Int64 feePriceOfStock, double feeRateOfTotal, Int64 feePriceOfTotal, Int32 salesCodeDiv, string partySalesSlipNo, string slipNote, string slipNote2, string slipNote3, string returnReason, int returnReasonDiv, string sectionCode, int supplierCode)
            {
                _enterpriseCode = enterpriseCode;
                _slipCd = slipCd;
                _stockAgentCd = stockAgentCd;
                _stockAgentNm = stockAgentNm;
                _retGdsDate = retGdsDate;
                _feePriceOfTotal = feePriceOfTotal;
                _slipNote = slipNote;
                _slipNote2 = slipNote2;
                _returnReason = returnReason;
                _returnReasonDiv = returnReasonDiv;
                _sectionCode = sectionCode;
                _supplierCode = supplierCode;
            }
        }
    #endregion �p�����[�^
    #endregion �N���X

        #region[�ŗ��}�X�^�擾]
        /// <summary>
        /// �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ���N���X</param>
        /// <returns>status</returns>
        private int TaxRateSetRead(out TaxRateSet taxRateSet)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // �ŗ��ݒ�����擾
            status = this._taxRateSetAcs.Read(out taxRateSet, this._enterpriseCode, 0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                taxRateSet = new TaxRateSet();
            }
            return status;
        }

        /// <summary>
        /// �ŗ��擾(�ŗ��ݒ�}�X�^)
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ���</param>
        /// <param name="targetDate">�ŗ��K�p��</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        private double GetTaxRate(TaxRateSet taxRateSet, DateTime targetDate)
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }
        #endregion[�ŗ��}�X�^�擾]
    }
}
