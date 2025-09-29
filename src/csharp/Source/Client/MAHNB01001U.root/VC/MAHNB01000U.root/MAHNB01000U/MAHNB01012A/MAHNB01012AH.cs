using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Text;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���d���������̓A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���d���������͂̐���S�ʂ��s���܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2008.01.21</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.01.21 20056 ���n ��� �V�K�쐬</br>
    /// <br>Update Note : 2010/03/01 ����� PM.NS�ێ�˗��T�����ǑΉ�</br>
    /// <br>              �P�����W���[���̊|���D��Ǘ��}�X�^�L���b�V���������g�p����悤�ɕύX</br>
    /// <br>Update Note: 2011/08/15 Redmine#23578 杍^ �A��16�ł̊|���Z�o�̏C�����e�̑Ή�</br>
    /// </remarks>
    public class SalesSlipStockInfoInputAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        private static SalesSlipStockInfoInputAcs _salesSlipStockInfoInputAcs;
        private StockTemp _stockTemp;
        private CustomerInfoAcs _customerInfoAcs;
        private SupplierAcs _supplierAcs;
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private StockPriceCalculate _stockPriceCalculate;
        private int _salesRowNo = 0;
        private string _enterpriseCode;
        private UnitPriceCalculation _unitPriceCalculation;
        private SalesInputDataSet.SalesDetailRow _salesDetailRow;
        private Dictionary<SalesSlipInputAcs.GoodsInfoKey, GoodsUnitData> _goodsUnitDataInfo;
        #endregion

        // ===================================================================================== //
        // �O���ɒ񋟂���萔�Q
        // ===================================================================================== //
        # region Public Readonly Members
        /// <summary>�����p�_�~�[�d���`�[�ԍ�</summary>
        public static readonly string ctDummyPartySalesSilpNum = "DummyPartySalesSilpNum";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private SalesSlipStockInfoInputAcs()
        {
            this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._stockPriceCalculate = new StockPriceCalculate();
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            this._salesSlipInputInitDataAcs.CacheStockProcMoneyList += new SalesSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._unitPriceCalculation.CacheStockProcMoneyList);
            this._salesSlipInputInitDataAcs.CacheStockProcMoneyList += new SalesSlipInputInitDataAcs.CacheStockProcMoneyListEventHandler(this._stockPriceCalculate.CacheStockProcMoneyList);
            this._salesSlipInputInitDataAcs.CacheRateProtyMngList += new SalesSlipInputInitDataAcs.CacheRateProtyMngListEventHandler(this._unitPriceCalculation.CacheRateProtyMngAllList); // ADD 2010/03/01
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        }
        /// <summary>
        /// ���d���������̓A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>���d���������̓A�N�Z�X�N���X �C���X�^���X</returns>
        public static SalesSlipStockInfoInputAcs GetInstance()
        {
            if (_salesSlipStockInfoInputAcs == null)
            {
                _salesSlipStockInfoInputAcs = new SalesSlipStockInfoInputAcs();
            }

            return _salesSlipStockInfoInputAcs;
        }
        #endregion

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region ��Delegete
        /// <summary>�������ʃZ�b�g�C�x���g</summary>
        public delegate void SetDisplayStockInfoEventHandler(StockTemp stockTemp);
        /// <summary>������L���b�V���C�x���g</summary>
        public delegate void CacheStockTempEventHandler(int salesRowNo, StockTemp stockTemp);
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region ��Events
        /// <summary>��ŐV���ݒ�C�x���g</summary>
        public event SetDisplayStockInfoEventHandler SetDisplay;
        /// <summary>��ŐV���ݒ�C�x���g</summary>
        public event CacheStockTempEventHandler CacheStockTemp;
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Properties
        /// <summary>�d�����v���p�e�B</summary>
        public StockTemp StockTemp
        {
            get { return this._stockTemp; }
            set { this._stockTemp = value; }
        }

        /// <summary>���㖾�׃f�[�^�s�I�u�W�F�N�g</summary>
        public SalesInputDataSet.SalesDetailRow SalesDetailRow
        {
            get { return _salesDetailRow; }
            set { _salesDetailRow = value; }
        }

        /// <summary>���i�A�����f�B�N�V���i��</summary>
        public Dictionary<SalesSlipInputAcs.GoodsInfoKey, GoodsUnitData> GoodsUnitDataInfo
        {
            get { return this._goodsUnitDataInfo; }
            set { this._goodsUnitDataInfo = value; }
        }
        #endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        #region �� Enums
        /// <summary>
        /// �P�����
        /// </summary>
        public enum UnitPriceKind
        {
            /// <summary>����P��</summary>
            SalesUnitPrice = 1,
            /// <summary>���㌴��</summary>
            SalesUnitCost = 2,
            /// <summary>�d���P��</summary>
            StockUnitPrice = 3,
            /// <summary>�艿</summary>
            ListPrice = 4,
        }

        /// <summary>
        /// �d���`��
        /// </summary>
        public enum SupplierFormal
        {
            /// <summary>�ݒ�Ȃ�</summary>
            Non = -1,
            /// <summary>�d��</summary>
            Stock = 0,
            /// <summary>����</summary>
            ArrivalGoods = 1,
            /// <summary>����</summary>
            Order = 2,
        }

        /// <summary>
        /// �d���`�[�敪
        /// </summary>
        public enum SupplierSlipCd
        {
            /// <summary>�d��</summary>
            Stock = 10,
            /// <summary>�ԕi</summary>
            RetGoods = 20,
        }

        /// <summary>
        /// ���|�敪
        /// </summary>
        public enum AccPayDivCd : int
        {
            /// <summary>���|�Ȃ�</summary>
            NonAccPay = 0,
            /// <summary>���|</summary>
            AccPay = 1,
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region ��Public Methods
        // ----  ADD 2011/08/15 ------>>>>
        /// <summary>
        /// �|���D��敪���Z�b�g���܂��B
        /// </summary>
        /// <remarks>�|���D��敪���Z�b�g���܂��B</remarks>
        public void SetUnitPriceCalculation()
        {
            if (this._salesSlipInputInitDataAcs.GetCompanyInf() != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = this._salesSlipInputInitDataAcs.GetCompanyInf().RatePriorityDiv;
            }
        }
        // ----  ADD 2011/08/15 ------<<<<

        /// <summary>
        /// �d�����I�u�W�F�N�g����ʂɐݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        /// <param name="salesDetailRow">���㖾�׃f�[�^�s�I�u�W�F�N�g</param>
        public void SettingStockTemp(int salesRowNo, StockTemp stockTemp, SalesInputDataSet.SalesDetailRow salesDetailRow)
        {
            this._stockTemp = stockTemp;
            this._salesRowNo = salesRowNo;
            this._salesDetailRow = salesDetailRow;

            this.SetDisplayCall();
        }

        /// <summary>
        /// �d�����L���b�V������
        /// </summary>
        /// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        public void Cache(StockTemp stockTemp)
        {
            if (stockTemp == null) return;

            this._stockTemp = stockTemp.Clone();

            this.CacheCall(stockTemp);
        }

        /// <summary>
        /// �d�����f�[�^�ɓ��Ӑ�i�d����j�̏���ݒ肵�܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailRow">���㖾�׃f�[�^�s�I�u�W�F�N�g</param>
        public void DataSettingStockTemp(ref StockTemp stockTemp, SalesInputDataSet.SalesDetailRow salesDetailRow)
        {
            // ���i����
            if (stockTemp.GoodsName != salesDetailRow.GoodsName) stockTemp.GoodsName = salesDetailRow.GoodsName;

        }

        /// <summary>
        /// �d�����f�[�^�ɓ��Ӑ�i�d����j�̏���ݒ肵�܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����f�[�^�I�u�W�F�N�g�iref�j</param>
        /// <param name="supplier">�d����}�X�^�I�u�W�F�N�g</param>
        public void SettingStockTempFromSupplier(ref StockTemp stockTemp, Supplier supplier)
        {
            if ((stockTemp == null) || (supplier == null))
            {
                stockTemp.SupplierCd = 0;				        // �d����R�[�h
                stockTemp.SupplierNm1 = string.Empty;	        // �d���於�̂P
                stockTemp.SupplierNm2 = string.Empty;	        // �d���於�̂Q
                stockTemp.SupplierSnm = string.Empty;	        // �d���旪��
                stockTemp.BusinessTypeCode = 0;			        // �Ǝ�R�[�h
                stockTemp.BusinessTypeName = string.Empty;		// �Ǝ햼��
                stockTemp.StockAddUpSectionCd = string.Empty;	// �d���v�㋒�_
                stockTemp.SalesAreaCode = 0;			        // �̔��G���A�R�[�h
                stockTemp.SalesAreaName = string.Empty;			// �̔��G���A����
                stockTemp.SuppRateGrpCode = 0;			        // �d����|���O���[�v�R�[�h

                stockTemp.PayeeCode = 0;				        // �x����R�[�h
                stockTemp.PayeeSnm = string.Empty;				// �x���旪��
                stockTemp.SuppCTaxLayCd = 0;			        // ����œ]�ŕ���
                stockTemp.SuppTtlAmntDspWayCd = 0;              // �d���摍�z�\�����@�敪

                stockTemp.PayeeName = string.Empty;             // �x���於�̂P
                stockTemp.PayeeName2 = string.Empty;            // �x���於�̂Q
                stockTemp.TotalDay = 0;                         // ����
                stockTemp.NTimeCalcStDate = 0;                  // ���񗈊��J�n��
            }
            else
            {
                if (supplier == null) supplier = new Supplier();

                // �x������擾
                Supplier payeeSupplier;
                int status = this._supplierAcs.Read(out payeeSupplier, supplier.EnterpriseCode, supplier.PayeeCode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    payeeSupplier = new Supplier();
                }

                if (payeeSupplier == null)
                {
                    payeeSupplier = new Supplier();
                }

                // �d������
                stockTemp.SupplierCd = supplier.SupplierCd;				    // �d����R�[�h
                stockTemp.SupplierNm1 = supplier.SupplierNm1;				// �d���於�̂P
                stockTemp.SupplierNm2 = supplier.SupplierNm2;				// �d���於�̂Q
                stockTemp.SupplierSnm = supplier.SupplierSnm;				// �d���旪��
                stockTemp.BusinessTypeCode = supplier.BusinessTypeCode;		// �Ǝ�R�[�h
                stockTemp.BusinessTypeName = supplier.BusinessTypeName;		// �Ǝ햼��
                stockTemp.SalesAreaCode = supplier.SalesAreaCode;			// �̔��G���A�R�[�h
                stockTemp.SalesAreaName = supplier.SalesAreaName;			// �̔��G���A����

                if (!string.IsNullOrEmpty(supplier.StockAgentCode.Trim()))
                {
                    Employee employee = this._salesSlipInputInitDataAcs.GetEmployee(supplier.StockAgentCode);
                    if (employee != null)
                    {
                        stockTemp.StockAgentCode = supplier.StockAgentCode.Trim();
                        string name = supplier.StockAgentName;
                        if (name.Length > 16) name = name.Substring(0, 16);
                        stockTemp.StockAgentName = name;
                    }
                }

                // �d���v�㋒�_
                stockTemp.StockAddUpSectionCd = supplier.PaymentSectionCode;

                //this.SuppRateGrpCodeSetting(ref stockTemp, customerInfo, custSuppli); // �d����|���O���[�v�R�[�h

                // ����ł̒[�������敪
                double fractionProcUnit;
                int fractionProcCd;
                this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, supplier.StockCnsTaxFrcProcCd, 999999999, out fractionProcUnit, out fractionProcCd);
                stockTemp.StockFractionProcCd = fractionProcCd;

                // �ȉ��A�x������
                stockTemp.PayeeCode = payeeSupplier.SupplierCd;
                stockTemp.PayeeSnm = payeeSupplier.SupplierSnm;
                stockTemp.PayeeName = payeeSupplier.SupplierNm1;
                stockTemp.PayeeName2 = payeeSupplier.SupplierNm2;
                stockTemp.TotalDay = payeeSupplier.PaymentTotalDay;
                stockTemp.NTimeCalcStDate = payeeSupplier.NTimeCalcStDate;

                this.SettingAddUpDate(ref stockTemp);

                // �d���݌ɑS�̐ݒ�}�X�^���擾
                StockTtlSt stockTtlSt = this._salesSlipInputInitDataAcs.GetStockTtlSt();

                // �S�̏����l�ݒ�}�X�^���擾
                AllDefSet allDefSet = this._salesSlipInputInitDataAcs.GetAllDefSet();

                if (stockTtlSt == null) stockTtlSt = new StockTtlSt();

                // �d����}�X�^�̎d�������œ]�ŕ����Q�Ƌ敪��
                // �u1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�d�����}�X�^�́u�d�������œ]�ŕ����R�[�h�v��ݒ肷��
                // �u0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͐ŗ��ݒ�}�X�^�́u����œ]�ŕ����R�[�h�v��ݒ肷��
                stockTemp.SuppCTaxLayCd = (payeeSupplier.SuppCTaxLayRefCd == 1) ? payeeSupplier.SuppCTaxLayCd : this._salesSlipInputInitDataAcs.GetConsTaxLayMethod(0);

                // �d����}�X�^�̎d���摍�z�\�����@�Q�Ƌ敪��
                // �1:�d����Q�Ɓv�̏ꍇ�͓��Ӑ�d�����}�X�^�́u�d���摍�z�\�����@�敪�v��ݒ肷��
                // �0:�S�̐ݒ�Q�Ɓv�̏ꍇ�͑S�̏����l�ݒ�}�X�^�́u���z�\�����@�敪�v��ݒ肷��
                stockTemp.SuppTtlAmntDspWayCd = (payeeSupplier.StckTtlAmntDspWayRef == 1) ? payeeSupplier.SuppTtlAmntDspWayCd : allDefSet.TotalAmountDispWayCd;

                // ���z�\���|���K�p�敪
                stockTemp.TtlAmntDispRateApy = allDefSet.TtlAmntDspRateDivCd;
            }
        }

        /// <summary>
        /// �������ݒ菈��
        /// </summary>
        /// <param name="stockSlip">�d����f�[�^�I�u�W�F�N�g</param>
        public void SettingStockTempStockFromAgentBelongInfo(ref StockTemp stockTemp)
        {
            string belongSecCd;
            int belongSubSecCd;
            this._salesSlipInputInitDataAcs.GetBelongInfo_FromEmployee(stockTemp.StockAgentCode, out belongSecCd, out belongSubSecCd);

            stockTemp.StockSectionCd = belongSecCd;
            stockTemp.SubSectionCode = belongSubSecCd;
        }

        /// <summary>
        /// �d�����I�u�W�F�N�g�̐��ʂ�ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        public void SettingStockTempStockCnt(ref StockTemp stockTemp, double stockCount)
        {

            if (stockTemp == null) return;

            //--------------------------------------------
            // �V�K�o�^�s
            //--------------------------------------------
            if (stockTemp.StockSlipDtlNum == 0)
            {
                if (stockTemp.EditStatus == SalesSlipInputAcs.ctEDITSTATUS_AddUpNew)
                {
                    // �v��V�K
                    stockTemp.StockCount = stockCount;
                    stockTemp.OrderCnt = stockTemp.OrderCnt;
                    stockTemp.OrderAdjustCnt = 0;
                    stockTemp.OrderRemainCnt = stockTemp.OrderCnt - stockTemp.StockCount;
                }
                else
                {
                    // �V�K
                    stockTemp.StockCount = stockCount;
                    stockTemp.OrderCnt = stockCount;
                    stockTemp.OrderAdjustCnt = 0;
                    stockTemp.OrderRemainCnt = stockCount;
                }
            }
            else
            //--------------------------------------------
            // �����C���s
            //--------------------------------------------
            {
                double adjustCnt = stockCount - stockTemp.StockCount; // ���͑O�Ƃ̍���
                stockTemp.StockCount = stockCount;
                stockTemp.OrderCnt = stockTemp.StockCount;
                stockTemp.OrderAdjustCnt = stockTemp.OrderAdjustCnt + adjustCnt;
                stockTemp.OrderRemainCnt = stockTemp.OrderRemainCnt + adjustCnt;
            }

            //// �|������P�����Čv�Z
            //this.SalesDetailRowGoodsPriceSetting(ref row);

        }

        /// <summary>
        /// �d���P���ݒ菈��
        /// </summary>
        /// <param name="stockTemp"></param>
        /// <param name="row"></param>
        public void SettingStockTempFromStockUnitPrice(ref StockTemp stockTemp, SalesInputDataSet.SalesDetailRow row)
        {
            // �P���Z�o
            this.CalclationUnitPrice(ref stockTemp);

            //// ���P���A���敪
            //switch (this._salesSlipInputInitDataAcs.GetAllDefSet().UnCstLinkDiv)
            //{
            //    // ���Ȃ�
            //    case 0:
            //        // �P���Z�o
            //        this.CalclationUnitPrice(ref stockTemp);
            //        break;
            //    // ����
            //    case 1:
            //        // �P���Z�o
            //        this.CalclationUnitPrice(ref stockTemp);
            //        if ((stockTemp.StockUnitPriceFl == 0) && (stockTemp.StockUnitTaxPriceFl == 0))
            //        {
            //            stockTemp.StockUnitPriceFl = row.SalesUnitCostTaxExc;
            //            stockTemp.StockUnitTaxPriceFl = row.SalesUnitCostTaxInc;
            //        }
            //        break;
            //    // ����
            //    case 2:
            //        stockTemp.StockUnitPriceFl = row.SalesUnitCostTaxExc;
            //        stockTemp.StockUnitTaxPriceFl = row.SalesUnitCostTaxInc;
            //        break;
            //}
        }

        /// <summary>
        /// �d�����I�u�W�F�N�g�̎d���`����ݒ�
        /// </summary>
        /// <param name="stockTemp"></param>
        /// <param name="supplierFormal"></param>
        public void SettingStockTempFromSupplierFormal(ref StockTemp stockTemp, int supplierFormal)
        {
            if (stockTemp == null) return;

            stockTemp.SupplierFormal = supplierFormal;
        }

        /// <summary>
        /// �d�����I�u�W�F�N�g�̎d���`�[�ԍ���ݒ�
        /// </summary>
        /// <param name="stockTemp"></param>
        /// <param name="partySalesSlipNum"></param>
        public void SettingStockTempFromPartySalesSilpNum(ref StockTemp stockTemp, string partySalesSlipNum)
        {
            if (stockTemp == null) return;

            stockTemp.PartySaleSlipNum = partySalesSlipNum;
        }

        /// <summary>
        /// �\�����Ă���d���P���̒l���擾���܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        /// <returns>�\���P��</returns>
        public double GetUnitPriceDisplay(StockTemp stockTemp)
        {
            return ((stockTemp.SuppTtlAmntDspWayCd == 1) || (stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)) ? stockTemp.StockUnitTaxPriceFl : stockTemp.StockUnitPriceFl;
        }

        /// <summary>
        /// �\�����Ă���艿�̒l���擾���܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        /// <returns>�\���艿</returns>
        public double GetListPriceDisplay(StockTemp stockTemp)
        {
            return ((stockTemp.SuppTtlAmntDspWayCd == 1) || (stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc)) ? stockTemp.ListPriceTaxIncFl : stockTemp.ListPriceTaxExcFl;
        }

        /// <summary>
        /// ���͂����d���P�����d�����I�u�W�F�N�g�ɃZ�b�g���܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        /// <param name="stockUnitPriceDisplay">���͂����d���P��</param>
        public void UnitPriceSetting(ref StockTemp stockTemp, double stockUnitPriceDisplay)
        {
            double stockUnitPriceTaxExc;
            double stockUnitPriceTaxInc;

            int taxationDivCd = stockTemp.TaxationCode;
            if (stockTemp.SuppCTaxLayCd == (int)SalesSlipInputAcs.ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            // �\�����i���Ŕ����A�ō��݉��i���Z�o����
            this.CalcTaxExcAndTaxInc(taxationDivCd, stockTemp.SupplierCd, stockTemp.SupplierConsTaxRate, stockTemp.SuppTtlAmntDspWayCd, stockUnitPriceDisplay, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc);

            stockTemp.StockUnitPriceFl = stockUnitPriceTaxExc;
            stockTemp.StockUnitTaxPriceFl = stockUnitPriceTaxInc;
            stockTemp.StockUnitChngDiv = 1;
        }

        /// <summary>
        /// ���͂����艿�𓯎��d���I�u�W�F�N�g�ɃZ�b�g���܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        /// <param name="listPriceDisplay">���͂����艿</param>
        public void ListPriceSetting(ref StockTemp stockTemp, double listPriceDisplay)
        {
            double listPriceTaxExcFl;
            double listPriceTaxIncFl;

            int taxationDivCd = stockTemp.TaxationCode;
            if (stockTemp.SuppCTaxLayCd == (int)SalesSlipInputAcs.ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            // �\�����i���Ŕ����A�ō��݉��i���Z�o����
            this.CalcTaxExcAndTaxInc(taxationDivCd, stockTemp.SupplierSlipCd, stockTemp.SupplierConsTaxRate, stockTemp.SuppTtlAmntDspWayCd, listPriceDisplay, out listPriceTaxExcFl, out listPriceTaxIncFl);

            stockTemp.ListPriceTaxExcFl = listPriceTaxExcFl;
            stockTemp.ListPriceTaxIncFl = listPriceTaxIncFl;
        }

        ///// <summary>
        ///// �d���P���Čv�Z�`�F�b�N
        ///// </summary>
        ///// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        ///// <returns></returns>
        //public bool SalesUnitPriceReCalcCheck(StockTemp stockTemp)
        //{
        //    bool ret = false;

        //    switch (stockTemp.UnPrcCalcCdStckUnPrc)
        //    {
        //        case (int)UnitPriceCalculation.UnitPrcCalcDiv.RateVal:				// ��P���~�|��
        //            {
        //                double targetPrice = (stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc) ? stockTemp.StockUnitTaxPriceFl : stockTemp.StockUnitPriceFl;
        //                if (targetPrice != stockTemp.StdUnPrcStckUnPrc)
        //                {
        //                    ret = true;
        //                }
        //                break;
        //            }

        //        case (int)UnitPriceCalculation.UnitPrcCalcDiv.UpRate:				// �����~����UP��
        //        case (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:	// ������(1-�e����)
        //            {
        //                break;
        //            }
        //    }

        //    return ret;
        //}

        /// <summary>
        /// �P���Z�o���W���[���ɂ��A�P�����Z�o���܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        public void CalclationUnitPrice(ref StockTemp stockTemp)
        {
            //if (this._salesSlipInputInitDataAcs.GetAllDefSet().UnCstLinkDiv == 2) return; // ���P���A�������݂̏ꍇ�A�|���Z�o���Ȃ�

            if ((stockTemp.GoodsMakerCd == 0) || (string.IsNullOrEmpty(stockTemp.GoodsNo))) return; // ���[�J�[�E�i�Ԗ����͎��́A�|���Z�o���Ȃ�

            int SalesUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.BLGoodsCode = stockTemp.RateBLGoodsCode;							// BL�R�[�h
            unitPriceCalcParam.GoodsRateGrpCode = stockTemp.RateGoodsRateGrpCd;                 // ���i�|���O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = stockTemp.RateBLGroupCode;                         // BL�O���[�v�R�[�h
            unitPriceCalcParam.SectionCode = stockTemp.SectionCode;								// ���_�R�[�h
            unitPriceCalcParam.CountFl = stockTemp.StockCount;									// ����
            unitPriceCalcParam.CustomerCode = stockTemp.SupplierCd; 							// ���Ӑ�R�[�h
            unitPriceCalcParam.CustRateGrpCode = stockTemp.CustRateGrpCode;						// ���Ӑ�|���O���[�v�R�[�h
            unitPriceCalcParam.SupplierCd = stockTemp.SupplierCd;								// �d����R�[�h
            //unitPriceCalcParam.SuppRateGrpCode = stockTemp.SuppRateGrpCode;						// �d����|���O���[�v�R�[�h
            //unitPriceCalcParam.DetailGoodsGanreCode = stockTemp.BLGroupCode;        			// ���i�敪�ڍ׃R�[�h
            //unitPriceCalcParam.EnterpriseGanreCode = stockTemp.EnterpriseGanreCode;				// ���Е��ރR�[�h
            unitPriceCalcParam.GoodsMakerCd = stockTemp.GoodsMakerCd;							// ���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = stockTemp.GoodsNo;										// ���i�ԍ�
            unitPriceCalcParam.GoodsRateRank = stockTemp.GoodsRateRank;							// ���i�|�������N
            //unitPriceCalcParam.LargeGoodsGanreCode = stockTemp.GoodsLGroup;     				// ���i�敪�O���[�v�R�[�h
            //unitPriceCalcParam.ListPriceTaxExcFl = stockTemp.ListPriceTaxExcFl;					// �艿�ō�
            //unitPriceCalcParam.ListPriceTaxIncFl = stockTemp.ListPriceTaxIncFl;					// �艿��
            //unitPriceCalcParam.MediumGoodsGanreCode = stockTemp.GoodsMGroup;	        		// ���i�敪�R�[�h
            unitPriceCalcParam.PriceApplyDate = (stockTemp.SupplierFormal == (int)SalesSlipStockInfoInputAcs.SupplierFormal.Stock) ? stockTemp.StockDate : stockTemp.ArrivalGoodsDay;
            unitPriceCalcParam.SalesUnPrcFrcProcCd = SalesUnPrcFrcProcCd;						// ����P���[�������R�[�h
            unitPriceCalcParam.StockUnPrcFrcProcCd = SalesUnPrcFrcProcCd;                       // �d���P���[�������R�[�h
            unitPriceCalcParam.SectionCode = stockTemp.SectionCode;								// ���_�R�[�h
            unitPriceCalcParam.TaxationDivCd = stockTemp.TaxationCode;							// �ېŋ敪

            int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
            unitPriceCalcParam.TaxRate = stockTemp.SupplierConsTaxRate;							// �ŗ�
            unitPriceCalcParam.TotalAmountDispWayCd = stockTemp.SuppTtlAmntDspWayCd;			// ���z�\�����@�敪
            unitPriceCalcParam.TtlAmntDspRateDivCd = stockTemp.TtlAmntDispRateApy;				// ���z�\���|���K�p�敪

            // ����
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataFromDic(stockTemp.GoodsMakerCd, stockTemp.GoodsNo);
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            if (unitPriceCalcRetList != null)
            {
                foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
                {
                    if (unitPriceCalcRet.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                    {
                        //--------------------------------------------
                        // �d���P��
                        //--------------------------------------------
                        this.StockTempRateInfoClear(ref stockTemp);
                        stockTemp.RateDivStckUnPrc = unitPriceCalcRet.RateSettingDivide;	// �|���ݒ�敪
                        stockTemp.RateSectStckUnPrc = unitPriceCalcRet.SectionCode;			// �|���擾���_�R�[�h
                        stockTemp.UnPrcCalcCdStckUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;	// �P���Z�o�敪
                        stockTemp.PriceCdStckUnPrc = unitPriceCalcRet.PriceDiv;				// ���i�敪
                        stockTemp.StdUnPrcStckUnPrc = unitPriceCalcRet.StdUnitPrice;		// ����i
                        stockTemp.StockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;	// �P���i�Ŕ��j
                        stockTemp.StockUnitTaxPriceFl = unitPriceCalcRet.UnitPriceTaxIncFl;	// �P���i�ō��j
                        stockTemp.StockRate = unitPriceCalcRet.RateVal;						// �|��
                        stockTemp.FracProcUnitStcUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;// �[�������P��
                        stockTemp.FracProcStckUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;	// �[�������敪
                        stockTemp.RateBLGoodsCode = stockTemp.BLGoodsCode;					// BL���i�R�[�h(�|��)
                        stockTemp.RateBLGoodsName = stockTemp.BLGoodsFullName;				// BL���i����(�|��)
                        stockTemp.RateGoodsRateGrpCd = stockTemp.GoodsMGroup;               // ���i�|���O���[�v�R�[�h�i�|���j
                        stockTemp.RateGoodsRateGrpNm = stockTemp.GoodsMGroupName;           // ���i�|���O���[�v���́i�|���j
                        stockTemp.RateBLGroupCode = stockTemp.BLGroupCode;                  // BL�O���[�v�R�[�h�i�|���j
                        stockTemp.RateBLGroupName = stockTemp.BLGroupName;                  // BL�O���[�v���́i�|���j
                        stockTemp.BfStockUnitPriceFl = unitPriceCalcRet.UnitPriceTaxExcFl;	// �ύX�O�����i�Ŕ����j
                        stockTemp.StockUnitChngDiv = 0;										// �P���ύX�敪
                        stockTemp.OpenPriceDiv = unitPriceCalcRet.OpenPriceDiv;				// �I�[�v�����i�敪
                    }
                }
            }
        }

        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="stockTemp">�d�����f�[�^�I�u�W�F�N�g</param>
        public void CalculationStockPrice(ref StockTemp stockTemp)
        {
            // �d�����z���z���Z��
            long stockPriceTaxInc;
            long stockPriceTaxExc;
            double taxRate = stockTemp.SupplierConsTaxRate;

            // ���Ӑ�}�X�^�������Œ[�����������擾
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
            double fracProcUnit;
            int fracProcCd;
            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);
            
            int stockPriceFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockTemp.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd); // �d�����z�[�������R�[�h
            int taxationCode = stockTemp.TaxationCode;

            // ��ې�
            if (stockTemp.SuppCTaxLayCd == (int)SalesSlipInputAcs.ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }

            double stockUnitPrice = 0;
            if ((stockTemp.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc) || (stockTemp.SuppTtlAmntDspWayCd == 1))
            {
                stockUnitPrice = stockTemp.StockUnitTaxPriceFl;
            }
            else
            {
                stockUnitPrice = stockTemp.StockUnitPriceFl;
            }

            // ���z�\�����͓��łŌv�Z����
            if ((stockTemp.TaxationCode != (int)CalculateTax.TaxationCode.TaxInc) && (stockTemp.SuppTtlAmntDspWayCd == 1)) taxationCode = 2;

            if (this.CalculationStockPrice(
                stockTemp.StockCount,
                stockUnitPrice,
                taxationCode,
                taxRate,
                fracProcUnit,
                fracProcCd,
                stockPriceFrcProcCd,
                out stockPriceTaxInc,
                out stockPriceTaxExc))
            {
                stockTemp.StockPriceTaxExc = stockPriceTaxExc;
                stockTemp.StockPriceTaxInc = stockPriceTaxInc;
                //����
                //stockTemp.StockPriceConsTax = (long)((decimal)stockTemp.StockPriceTaxInc - (decimal)stockTemp.StockPriceTaxExc);
                stockTemp.StockPriceConsTaxDetail = (long)((decimal)stockTemp.StockPriceTaxInc - (decimal)stockTemp.StockPriceTaxExc);
            }
        }

        /// <summary>
        /// �P�����m�F�p�I�u�W�F�N�g�擾
        /// </summary>
        /// <param name="StockTemp">�d�����I�u�W�F�N�g</param>
        /// <returns>�P�����m�F�p�I�u�W�F�N�g</returns>
        public UnPrcInfoConf GetUnitPriceInfoConf(StockTemp stockTemp)
        {
            UnPrcInfoConf unPrcInfoConf = new UnPrcInfoConf();

            if (stockTemp != null)
            {
                unPrcInfoConf.CustomerCode = stockTemp.SupplierCd;  					// ���Ӑ�R�[�h
                unPrcInfoConf.CustomerSnm = stockTemp.SupplierSnm;						// ���Ӑ旪��
                unPrcInfoConf.SupplierCd = stockTemp.SupplierCd;						// �d����R�[�h
                unPrcInfoConf.SupplierSnm = stockTemp.SupplierSnm;						// �d���旪��
                unPrcInfoConf.CustRateGrpCode = stockTemp.CustRateGrpCode;				// ���Ӑ�|���O���[�v�R�[�h
                unPrcInfoConf.GoodsNo = stockTemp.GoodsNo;								// ���i�ԍ�
                unPrcInfoConf.GoodsName = stockTemp.GoodsName;							// ���i����
                unPrcInfoConf.GoodsMakerCd = stockTemp.GoodsMakerCd;					// ���i���[�J�[�R�[�h
                unPrcInfoConf.MakerName = stockTemp.MakerName;							// ���[�J�[����
                unPrcInfoConf.BLGoodsCode = stockTemp.RateBLGoodsCode;					// BL���i�R�[�h
                unPrcInfoConf.BLGoodsFullName = stockTemp.RateBLGoodsName;				// BL���i�R�[�h���́i�S�p�j
                unPrcInfoConf.GoodsRateGrpCode = stockTemp.RateGoodsRateGrpCd;          // ���i�|���O���[�v�R�[�h�i�|���j
                unPrcInfoConf.GoodsRateGrpCodeNm = stockTemp.RateGoodsRateGrpNm;        // ���i�|���O���[�v���́i�|���j
                unPrcInfoConf.BLGroupCode = stockTemp.RateBLGroupCode;                  // BL�O���[�v�R�[�h�i�|���j
                unPrcInfoConf.BLGroupName = stockTemp.RateBLGroupName;                  // BL�O���[�v���́i�|���j
                unPrcInfoConf.GoodsRateRank = stockTemp.GoodsRateRank;					// ���i�|�������N
                unPrcInfoConf.PriceApplyDate = (stockTemp.SupplierFormal == (int)SalesSlipStockInfoInputAcs.SupplierFormal.Stock) ? stockTemp.StockDate : stockTemp.ArrivalGoodsDay;	// ���i�K�p��
                unPrcInfoConf.CountFl = stockTemp.StockCount;    						// ����

                unPrcInfoConf.RateSettingDivide = stockTemp.RateDivStckUnPrc;		// �|���ݒ�敪
                unPrcInfoConf.UnitPrcCalcDiv = stockTemp.UnPrcCalcCdStckUnPrc;		// �P���Z�o�敪
                unPrcInfoConf.RateVal = stockTemp.StockRate;						// �|��
                unPrcInfoConf.UnPrcFracProcUnit = stockTemp.FracProcUnitStcUnPrc;	// �P���[�������P��
                unPrcInfoConf.UnPrcFracProcDiv = stockTemp.FracProcStckUnPrc;		// �P���[�������敪
                unPrcInfoConf.StdUnitPrice = stockTemp.StdUnPrcStckUnPrc;			// ��P��
                unPrcInfoConf.SectionCode = stockTemp.RateSectStckUnPrc;			// �|���ݒ苒�_

                unPrcInfoConf.UnitPriceTaxExcFl = stockTemp.StockUnitPriceFl;       // �P���i�Ŕ��j
                unPrcInfoConf.UnitPriceTaxIncFl = stockTemp.StockUnitTaxPriceFl;    // �P���i�ō��j
            }

            return unPrcInfoConf;
        }

        /// <summary>
        /// �P���m�F��ʌ��ʃN���X���A�P�����ݒ��ݒ肵�܂��B
        /// </summary>
        /// <param name="unPrcInfoConfRet">�P���m�F��ʌ��ʃI�u�W�F�N�g</param>
        /// <param name="stockTemp">�d�����I�u�W�F�N�g</param>
        public void UnPrcInfoSetting(UnPrcInfoConfRet unPrcInfoConfRet, ref StockTemp stockTemp)
        {
            if (stockTemp == null) return;
            // ����P��
            stockTemp.UnPrcCalcCdStckUnPrc = unPrcInfoConfRet.UnitPrcCalcDiv;		// �P���Z�o�敪
            stockTemp.StockRate = unPrcInfoConfRet.RateVal;							// �|��
            stockTemp.StdUnPrcStckUnPrc = unPrcInfoConfRet.StdUnitPrice;			// ��P��
            stockTemp.StockUnitPriceFl = unPrcInfoConfRet.UnitPriceTaxExcFl;        // �P���i�Ŕ��j
            stockTemp.StockUnitTaxPriceFl = unPrcInfoConfRet.UnitPriceTaxIncFl;     // �P���i�ō��j
            stockTemp.FracProcUnitStcUnPrc = unPrcInfoConfRet.UnPrcFracProcUnit;	// �[�������P��
            stockTemp.FracProcStckUnPrc = unPrcInfoConfRet.UnPrcFracProcDiv;		// �[�������敪
        }

        /// <summary>
        /// �v�����ݒ肵�܂��B
        /// </summary>
        /// <param name="salesTemp"></param>
        public void SettingAddUpDate(ref StockTemp stockTemp)
        {
            DateTime addUpDate;
            int delayPaymentDiv;
            SalesSlipInputAcs.CalcAddUpDate(stockTemp.StockDate, stockTemp.TotalDay, stockTemp.NTimeCalcStDate, out addUpDate, out delayPaymentDiv);

            stockTemp.StockAddUpADate = addUpDate;
            stockTemp.DelayPaymentDiv = delayPaymentDiv;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// ��ʕ\���C�x���g���s
        /// </summary>
        private void SetDisplayCall()
        {
            if (this.SetDisplay != null)
            {
                this.SetDisplay(this._stockTemp);
            }
        }

        /// <summary>
        /// �L���b�V���C�x���g�R�[������
        /// </summary>
        /// <param name="stockTemp"></param>
        private void CacheCall(StockTemp stockTemp)
        {
            if (this.CacheStockTemp != null)
            {
                this.CacheStockTemp(this._salesRowNo, stockTemp);
            }
        }

        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <param name="count">����</param>
        /// <param name="unitPrice">�P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="taxRate">����ŗ�</param>
        /// <param name="taxFracProcUnit">����Œ[�������P��</param>
        /// <param name="taxFracProcCd">����Œ[�������敪</param>
        /// <param name="fracProcCode">�[�������R�[�h</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <returns></returns>
        private bool CalculationStockPrice(double count, double unitPrice, int taxationCode, double taxRate, double taxFracProcUnit, int taxFracProcCd, int fracProcCode, out long stockPriceTaxInc, out long stockPriceTaxExc)
        {
            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;

            // �d������0�܂��͎d���P����0�̏ꍇ�͂��ׂ�0�ŏI��
            if ((count == 0) || (unitPrice == 0)) return true;

            // �O�ł̏ꍇ
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                double unitPriceExc = unitPrice;	// �P���i�Ŕ����j
                double unitPriceInc;				// �P���i�ō��݁j
                double unitPriceTax;				// �P���i����Łj
                long priceExc = 0;					// ���i�i�Ŕ����j
                long priceInc;						// ���i�i�ō��݁j
                long priceTax;						// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;		// �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;		// �d�����z�i�Ŕ����j		
            }
            // ���ł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                double unitPriceExc;				// �P���i�Ŕ����j
                double unitPriceInc = unitPrice;	// �P���i�ō��݁j
                double unitPriceTax;				// �P���i����Łj
                long priceExc;						// ���i�i�Ŕ����j
                long priceInc = 0;					// ���i�i�ō��݁j
                long priceTax;						// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, count, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceInc;		// �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;		// �d�����z�i�Ŕ����j
            }
            // ��ېł̏ꍇ
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                double unitPriceExc = unitPrice;	// �P���i�Ŕ����j
                double unitPriceInc;				// �P���i�ō��݁j
                double unitPriceTax;				// �P���i����Łj
                long priceExc = 0;					// ���i�i�Ŕ����j
                long priceInc;						// ���i�i�ō��݁j
                long priceTax;						// ���i�i����Łj

                this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, count, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, fracProcCode, taxRate, taxFracProcUnit, taxFracProcCd);

                stockPriceTaxInc = priceExc;		// �d�����z�i�ō��݁j
                stockPriceTaxExc = priceExc;		// �d�����z�i�ō��݁j
            }

            return true;
        }

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
        public void CalcTaxExcAndTaxInc(int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // ���Ӑ�}�X�^�������Œ[�����������擾
            int salesTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, customerCode, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
            double fracProcUnit;
            int fracProcCd;
            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

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
        /// ��������I�u�W�F�N�g�̊|���֌W�̏����N���A���܂��B
        /// </summary>
        /// <param name="salesTemp"></param>
        private void StockTempRateInfoClear(ref StockTemp stockTemp)
        {
            stockTemp.RateDivStckUnPrc = string.Empty;	// �|���ݒ�敪
            stockTemp.RateSectStckUnPrc = string.Empty;	// �|���擾���_�R�[�h
            stockTemp.UnPrcCalcCdStckUnPrc = 0;	// �P���Z�o�敪
            stockTemp.PriceCdStckUnPrc = 0;		// ���i�敪
            stockTemp.StdUnPrcStckUnPrc = 0;	// ����i
            stockTemp.StockUnitPriceFl = 0;	    // �P���i�Ŕ��j
            stockTemp.StockUnitTaxPriceFl = 0;	// �P���i�ō��j
            stockTemp.StockRate = 0;			// �|��
            stockTemp.FracProcUnitStcUnPrc = 0; // �[�������P��
            stockTemp.FracProcStckUnPrc = 0;	// �[�������敪
            stockTemp.RateBLGoodsCode = 0;		// BL���i�R�[�h(�|��)
            stockTemp.RateBLGoodsName = string.Empty;		// BL���i����(�|��)
            stockTemp.RateGoodsRateGrpCd = 0;   // ���i�|���O���[�v�R�[�h�i�|���j
            stockTemp.RateGoodsRateGrpNm = string.Empty; // ���i�|���O���[�v���́i�|���j
            stockTemp.RateBLGroupCode = 0;      // BL�O���[�v�R�[�h�i�|���j
            stockTemp.RateBLGroupName = string.Empty; // BL�O���[�v���́i�|���j
            stockTemp.BfStockUnitPriceFl = 0;	// �ύX�O�����i�Ŕ����j
            stockTemp.StockUnitChngDiv = 0;		// �P���ύX�敪
            stockTemp.OpenPriceDiv = 0;			// �I�[�v�����i�敪
        }

        /// <summary>
        /// ���i�A���f�[�^�I�u�W�F�N�g�擾(���iDictionary���擾)
        /// </summary>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns></returns>
        private GoodsUnitData GetGoodsUnitDataFromDic(int goodsMakerCode, string goodsNo)
        {
            GoodsUnitData goodsUnitData = null;
            SalesSlipInputAcs.GoodsInfoKey goodsInfoKey = new SalesSlipInputAcs.GoodsInfoKey(goodsNo, goodsMakerCode);
            if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) goodsUnitData = this._goodsUnitDataInfo[goodsInfoKey];
            return goodsUnitData;
        }
        #endregion

        // ===================================================================================== //
        // �X�^�e�B�b�N���\�b�h
        // ===================================================================================== //
        #region ��Static Methods
        /// <summary>
        /// �\���p�d���`�[�敪�����A�f�[�^�p�̎d���`�[�敪�A���|�敪���Z�b�g���܂�
        /// </summary>
        /// <param name="stockSlip">�d���I�u�W�F�N�g</param>
        static public void SetSlipCdAndAccPayDivCdFromDisplay(int supplierSlipDisplay, ref StockTemp stockTemp)
        {
            int supplierSlipCd;
            int accPayDivCd;

            GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay(supplierSlipDisplay, out supplierSlipCd, out accPayDivCd);

            stockTemp.SupplierSlipCd = supplierSlipCd;
            stockTemp.AccPayDivCd = accPayDivCd;
        }

        /// <summary>
        /// �\���p�d���`�[�敪���A�d���`�[�敪�A���|�敪���擾���܂��B
        /// </summary>
        /// <param name="supplierSlipDisplay">�\���p�d���`�[�敪</param>
        /// <param name="supplierSlipCd">�d���`�[�敪</param>
        /// <param name="accPayDivCd">���|�敪</param>
        static public void GetSlipCdAndAccPayDivCdFromSupplierSlipDisplay(int supplierSlipDisplay, out int supplierSlipCd, out int accPayDivCd)
        {
            // �����l�͊|�d��
            supplierSlipCd = 10;
            accPayDivCd = 1;
            switch (supplierSlipDisplay)
            {
                case 10:                                    // �|�d��
                    {
                        supplierSlipCd = 10;
                        accPayDivCd = 1;
                        break;
                    }
                case 20:                                    // �|�ԕi
                    {
                        supplierSlipCd = 20;
                        accPayDivCd = 1;
                        break;
                    }
                case 30:                                    // �����d��
                    {
                        supplierSlipCd = 10;
                        accPayDivCd = 0;
                        break;
                    }
                case 40:                                    // �����ԕi
                    {
                        supplierSlipCd = 20;
                        accPayDivCd = 0;
                        break;
                    }
            }
        }

        ///// <summary>
        ///// �f�[�^�̎d���`�[�敪�A���|�敪���A�\���p�d���`�[�敪���Z�b�g���܂��B
        ///// </summary>
        ///// <param name="stockSlip">�d���I�u�W�F�N�g</param>
        //static public void SetDisplayFromSlipCdAndAccPayDivCd(ref StockTemp stockTemp)
        //{
        //    stockTemp.SupplierSlipDisplay = GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(stockTemp.SupplierSlipCd, stockTemp.AccPayDivCd);
        //}

        /// <summary>
        /// �d���`�[�敪�A���|�敪���A�\���p�d���`�[�敪���܂��B
        /// </summary>
        /// <param name="supplierSlipCd">�d���`�[�敪</param>
        /// <param name="accPayDivCd">���|�敪</param>
        /// <returns>�\���p�d���`�[�敪</returns>
        static public int GetSupplierSlipDisplayFromSlipCdAndAccPayDivCd(int supplierSlipCd, int accPayDivCd)
        {
            // 10:�|�d��
            // 20:�|�ԕi
            // 30:�����d��
            // 40:�����ԕi
            int value = 0;
            switch (supplierSlipCd)
            {
                case 10:
                    {
                        value = 10;
                        break;
                    }
                case 20:
                    {
                        value = 20;
                        break;
                    }
            }
            switch (accPayDivCd)
            {
                case 0:
                    {
                        value += 20;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return value;
        }
        #endregion

    }
}
