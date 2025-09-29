//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Controller
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� �� 
// �� �� ��  2010/10/19  �C�����e : �����ԍ����܂�����������d���`�[�̑Ή�(MANTIS[0015563])
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs    = SingletonPolicy<LoginWorker>;
    using StockDB           = SingletonPolicy<StockDBAgent>;
    using SumUpStockDataPair= KeyValuePair<IList<StockDetailWork>>;
    using SupplierDB        = SingletonPolicy<SupplierDBAgent>;
    // 2010/10/19 Add >>>
    using AllDefSetDB = SingletonPolicy<AllDefSetDBAgent>;
    using TaxRateSetDB = SingletonPolicy<TaxRateSetDBAgent>;
    // 2010/10/19 Add <<<

    /// <summary>
    /// �v����̎d���f�[�^�̍\�z�҃N���X
    /// </summary>
    public class SumUpStockDataBuilder : SumUpInformationBuilder
    {
        #region <���݂̌v����̎d���f�[�^�̃��R�[�h/>

        /// <summary>���݂̌v����̎d���f�[�^�̃��R�[�h</summary>
        private StockSlipWork _currentStockSlipRecord;
        /// <summary>
        /// ���݂̌v����̎d���f�[�^�̃��R�[�h�̃A�N�Z�T
        /// </summary>
        private StockSlipWork CurrentStockSlipRecord
        {
            get { return _currentStockSlipRecord; }
            set { _currentStockSlipRecord = value; }
        }

        #endregion  // <���݂̌v����̎d���f�[�^�̃��R�[�h/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public SumUpStockDataBuilder(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// �v����̎d���f�[�^�ɔ������̎d���f�[�^���}�[�W���܂��B
        /// </summary>
        public override void Merge()
        {
            foreach (int supplierSlipNo in StockDB.Instance.Policy.SumUpStockSlipDetailRecordMap.Keys)
            {
                string slipNo = supplierSlipNo.ToString();
                SumUpStockDataPair stockDataWithSlipNo = new SumUpStockDataPair(
                    slipNo,
                    StockDB.Instance.Policy.SumUpStockSlipDetailRecordMap[supplierSlipNo]
                );

                CurrentStockSlipRecord = StockDB.Instance.Policy.SumUpStockSlipRecordMap[supplierSlipNo];

                // �d�����׃f�[�^�̓��e���}�[�W
                // 2010/10/19 Add >>>
                MergeEnterpriseCode(stockDataWithSlipNo);	// 003.��ƃR�[�h
                MergeSubSectionCode(stockDataWithSlipNo);	// 012.����R�[�h
                MergeDebitNoteNo(stockDataWithSlipNo);		// 013.�ԓ`�敪
                MergeSupplierSlipCd(stockDataWithSlipNo);	// 015.�d���`�[�敪
                MergeStockGoodsCd(stockDataWithSlipNo);	// 016.�d�����i�敪
                MergeAccPayDivCd(stockDataWithSlipNo);		// 017.���|�敪
                MergeStockSectionCd(stockDataWithSlipNo);	// 018.�d�����_�R�[�h
                MergeStockAddUpSectionCd(stockDataWithSlipNo);	// 019.�d���v�㋒�_�R�[�h
                MergeStockSlipUpdateCd(stockDataWithSlipNo);	// 020.�d���`�[�X�V�敪
                MergeDelayPaymentDiv(stockDataWithSlipNo);	// 025.�����敪
                MergePayeeCode(stockDataWithSlipNo);		// 026.�x����R�[�h
                MergePayeeSnm(stockDataWithSlipNo);		// 027.�x���旪��
                MergeSupplierCd(stockDataWithSlipNo);		// 028.�d����R�[�h
                MergeSupplierNm1(stockDataWithSlipNo);		// 029.�d���於1
                MergeSupplierNm2(stockDataWithSlipNo);		// 030.�d���於2
                MergeSupplierSnm(stockDataWithSlipNo);		// 031.�d���旪��
                MergeBuisinessTypeCode(stockDataWithSlipNo);	// 032.�Ǝ�R�[�h
                MergeBuisinessTypeName(stockDataWithSlipNo);	// 033.�Ǝ햼��
                MergeSalesAreaCode(stockDataWithSlipNo);	// 034.�̔��G���A�R�[�h
                MergeSalesAreaName(stockDataWithSlipNo);	// 035.�̔��G���A����
                MergeStockInputCode(stockDataWithSlipNo);	// 036.�d�����͎҃R�[�h
                MergeStockInputName(stockDataWithSlipNo);	// 037.�d�����͎Җ���
                MergeStockAgentCode(stockDataWithSlipNo);	// 038.�d���S���҃R�[�h
                MergeStockAgentName(stockDataWithSlipNo);	// 039.�d���S���Җ���
                MergeSuppTtlAmntDspWayCd(stockDataWithSlipNo);	// 040.�d���摍�z�\�����@�敪
                MergeTtlAmntDispRateApy(stockDataWithSlipNo);	// 041.���z�\���|���K�p�敪
                MergeSuppCTaxLayCd(stockDataWithSlipNo);	// 061.�d�������œ]�ŕ����R�[�h
                MergeSupplierConsTaxRate(stockDataWithSlipNo);	// 062.�d�������Őŗ�
                MergeStockFractionProcCd(stockDataWithSlipNo); // 064.�d���[�������敪
                MergeAutoPayment(stockDataWithSlipNo);		// 065.�����x���敪
                MergePartySaleSlipNum(stockDataWithSlipNo);	// 069.�����`�[�ԍ�
                MergeDetailRowCount(stockDataWithSlipNo);	// 072.���׍s��
                MergeUoeRemark1(stockDataWithSlipNo);		// 075.UOE���}�[�N1
                MergeUoeRemark2(stockDataWithSlipNo);		// 076.UOE���}�[�N2
                // 2010/10/19 Add <<<

                MergeSupplierFormal(stockDataWithSlipNo);   // 009.�d���`��
                MergeSectionCode(stockDataWithSlipNo);      // 011.���_�R�[�h
                MergeInputDay(stockDataWithSlipNo);         // 021.���͓�
                MergeArrivalGoodsDay(stockDataWithSlipNo);  // 022.���ד�
                MergeStockDate(stockDataWithSlipNo);        // 023.�d����
                MergeStockAddUpADate(stockDataWithSlipNo);  // 024.�d���v����t
                {
                    // 2010/10/19 Del ������񂪂܂����鎖������̂ŁA�K���W�v������>>>
                    //// �o�^�ς݂̔��������x�[�X�Ƃ���v����͂��̂܂�
                    //if (supplierSlipNo > 0)
                    //{
                    //    continue;
                    //}
                    // 2010/10/19 Del <<<

                    // 044.�d�����z�i�ō��݁j
                    // 045.�d�����z�i�Ŕ����j
                    // 046.�d���������z
                    // 047.�d�����z����Ŋz
                    // 048.�d���O�őΏۊz���v
                    // 049.�d�����őΏۊz���v
                    // 050.�d����ېőΏۊz���v
                    // 051.�d�����z����Ŋz�i�O�Łj
                    // 052.�d�����z����Ŋz�i���Łj
                    // 053.�d���l�����z�v�i�Ŕ����j
                    // 054.�d���l���O�őΏۊz���v
                    // 055.�d���l�����őΏۊz���v
                    // 056.�d���l����ېőΏۊz���v
                    // 057.�d���l������Ŋz�i�O�Łj
                    // 058.�d���l������Ŋz�i���Łj
                    CalculateTotalPrice(stockDataWithSlipNo);
                }
            }
        }

        #endregion  // <Override/>

        #region <009.�d���`��/>

        /// <summary>
        /// �d���`�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:�d��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝd���f�[�^</param>
        protected void MergeSupplierFormal(SumUpStockDataPair stockDataWithSlipNo)
        {
            const int STOCK = 0;    // 0:�d��
            CurrentStockSlipRecord.SupplierFormal = STOCK;
        }

        #endregion  // <009.�d���`��/>

        #region <011.���_�R�[�h/>

        /// <summary>
        /// ���͓����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C���S���҂̋��_�R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝd���f�[�^</param>
        protected void MergeSectionCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            string sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
            CurrentStockSlipRecord.SectionCode = sectionCode;
        }

        #endregion  // <011.���_�R�[�h/>

        #region <021.���͓�/>

        /// <summary>
        /// ���͓����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝd���f�[�^</param>
        protected void MergeInputDay(SumUpStockDataPair stockDataWithSlipNo)
        {
            DateTime inputDay = DateTime.Now;
            CurrentStockSlipRecord.InputDay = inputDay;
        }

        #endregion  // <021.���͓�/>

        #region <022.�o�ד�/>

        /// <summary>
        /// �o�ד����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝd���f�[�^</param>
        protected void MergeArrivalGoodsDay(SumUpStockDataPair stockDataWithSlipNo)
        {
            DateTime arrivalGoodsDay = DateTime.Now;
            CurrentStockSlipRecord.ArrivalGoodsDay = arrivalGoodsDay;
        }

        #endregion  // <022.�o�ד�/>

        #region <023.�d����/>

        /// <summary>
        /// �d�������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M���t���Z�b�g�i2.UOE�����f�[�^�̎�M���t�j
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝd���f�[�^</param>
        protected void MergeStockDate(SumUpStockDataPair stockDataWithSlipNo)
        {
            DateTime stockDate = DateTime.Now;
            {
                UOEOrderDtlWork uoeOrderDataRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(
                    stockDataWithSlipNo.Value[0].DtlRelationGuid
                );
                if (uoeOrderDataRecord != null)
                {
                    stockDate = uoeOrderDataRecord.ReceiveDate;
                }
            }

            stockDate = OrderStockDataBuilder.GetDayPayment(stockDate, CurrentStockSlipRecord);
            CurrentStockSlipRecord.StockDate = stockDate;
        }

        #endregion  // <023.�d����/>

        #region <024.�d���v����t/>

        /// <summary>
        /// �d���v����t���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d�������Z�b�g
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝd���f�[�^</param>
        protected void MergeStockAddUpADate(SumUpStockDataPair stockDataWithSlipNo)
        {
            DateTime stockAddUpADate = CurrentStockSlipRecord.StockDate;
            CurrentStockSlipRecord.StockAddUpADate = stockAddUpADate;
        }

        #endregion  // <024.�d���v����t/>

        #region <044�`058.�d���f�[�^�̏��Z�o/>

        /// <summary>
        /// �����\���敪�Z�b�g�����Z�o���܂��B
        /// </summary>
        /// <remarks>
        /// ���ʎ��@�����\���敪�Z�b�g�d�l���Q��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝd���f�[�^</param>
        protected void CalculateTotalPrice(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier == null) return;

            List<StockDetailWork> stockDetailWorkList = (List<StockDetailWork>)stockDataWithSlipNo.Value;

            PrintTotalPrice(CurrentStockSlipRecord);

            UoeSndRcvComponent.CalculateTotalPrice(
                ref _currentStockSlipRecord,
                stockDetailWorkList,
                supplier.StockCnsTaxFrcProcCd
            );

            PrintTotalPrice(CurrentStockSlipRecord);
        }

        /// <summary>
        /// �����\���敪�Z�b�g����\�����܂��B
        /// </summary>
        /// <param name="stockSlipWork">�d���f�[�^</param>
        [Conditional("DEBUG")]
        private static void PrintTotalPrice(StockSlipWork stockSlipWork)
        {
            StringBuilder str = new StringBuilder();
            {
                str.Append("�d�����z�v�i�ō��݁j�F").Append(stockSlipWork.StockTtlPricTaxInc).Append(Environment.NewLine);
                str.Append("�d�����z�v�i�Ŕ����j�F").Append(stockSlipWork.StockTtlPricTaxExc).Append(Environment.NewLine);
                str.Append("�d���������z�F").Append(stockSlipWork.StockNetPrice).Append(Environment.NewLine);
                str.Append("�d�����z����Ŋz�F").Append(stockSlipWork.StockPriceConsTax).Append(Environment.NewLine);
                str.Append("�d���O�őΏۊz���v�F").Append(stockSlipWork.TtlItdedStcOutTax).Append(Environment.NewLine);
                str.Append("�d�����őΏۊz���v�F").Append(stockSlipWork.TtlItdedStcInTax).Append(Environment.NewLine);
                str.Append("�d����ېőΏۊz���v�F").Append(stockSlipWork.TtlItdedStcTaxFree).Append(Environment.NewLine);
                str.Append("�d�����z����Ŋz�i�O�Łj�F").Append(stockSlipWork.StockOutTax).Append(Environment.NewLine);
                str.Append("�d�����z����Ŋz�i���Łj�F").Append(stockSlipWork.StckPrcConsTaxInclu).Append(Environment.NewLine);
                str.Append("�d�����z����Ŋz�i�Ŕ����j�F").Append(stockSlipWork.StckDisTtlTaxExc).Append(Environment.NewLine);
                str.Append("�d���l���O�őΏۊz���v�F").Append(stockSlipWork.ItdedStockDisOutTax).Append(Environment.NewLine);
                str.Append("�d���l�����őΏۊz���v�F").Append(stockSlipWork.ItdedStockDisInTax).Append(Environment.NewLine);
                str.Append("�d���l����ېőΏۊz���v�F").Append(stockSlipWork.ItdedStockDisTaxFre).Append(Environment.NewLine);
                str.Append("�d���l������Ŋz�i�O�Łj�F").Append(stockSlipWork.StockDisOutTax).Append(Environment.NewLine);
                str.Append("�d���l������Ŋz�i���Łj�F").Append(stockSlipWork.StckDisTtlTaxInclu).Append(Environment.NewLine);
            }
            Debug.WriteLine(str.ToString());
        }

        #endregion  // <044�`058.�d���f�[�^�̏��Z�o/>

        // 2010/10/19 Add >>>

        #region <003.��ƃR�[�h/>

        /// <summary>
        /// ��ƃR�[�h���}�[�W���܂��B
        /// </summary>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeEnterpriseCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            string enterpriseCode = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
            CurrentStockSlipRecord.EnterpriseCode = enterpriseCode;
        }

        #endregion

        #region <012.����R�[�h/>

        /// <summary>
        /// ����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �S���҂̏�������R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSubSectionCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            int subSectionCode = LoginWorkerAcs.Instance.Policy.Detail.BelongSubSectionCode;
            CurrentStockSlipRecord.SubSectionCode = subSectionCode;
        }

        #endregion  // <012.����R�[�h/>

        #region <013.�ԓ`�敪/>

        /// <summary>
        /// �ԓ`�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:���`
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeDebitNoteNo(SumUpStockDataPair stockDataWithSlipNo)
        {
            const int BLACK = 0;    // 0:���`
            CurrentStockSlipRecord.DebitNoteDiv = BLACK;
        }

        #endregion  // <013.�ԓ`�敪/>

        #region <015.�d���`�[�敪/>

        /// <summary>
        /// �d���`�[�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 10:�d��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSupplierSlipCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            const int STOCK = 10;   // 10:�d��
            CurrentStockSlipRecord.SupplierSlipCd = STOCK;
        }

        #endregion  // <015.�d���`�[�敪/>

        #region <016.�d�����i�敪/>

        /// <summary>
        /// �d�����i�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:���i
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockGoodsCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            const int GOODS = 0;    // 0:���i
            CurrentStockSlipRecord.StockGoodsCd = GOODS;
        }

        #endregion  // <016.�d�����i�敪/>

        #region <017.���|�敪/>

        /// <summary>
        /// ���|�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 1:���|
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeAccPayDivCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            const int PAYABLE_PRICE = 1;    // 1:���|
            CurrentStockSlipRecord.AccPayDivCd = PAYABLE_PRICE;
        }

        #endregion  // <017.���|�敪/>

        #region <018.�d�����_�R�[�h/>

        /// <summary>
        /// �d�����_�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE���Аݒ�}�X�^�̉������_�ݒ�敪�ɏ]��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockSectionCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            // �d�����_�R�[�h���}�[�W
            string stockSectionCd = GetStockSectionCd(stockDataWithSlipNo);
            if (!string.IsNullOrEmpty(stockSectionCd))
            {
                CurrentStockSlipRecord.StockSectionCd = stockSectionCd;
            }
        }

        /// <summary>
        /// �d�����_�R�[�h���擾���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�e�L�X�g</param>
        /// <returns>�d�����_�R�[�h</returns>
        protected string GetStockSectionCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            string stockSectionCd = string.Empty;

            int distSectionSetDiv = LoginWorkerAcs.Instance.Policy.UOESetting.DistSectionSetDiv;

            switch (distSectionSetDiv)
            {
                // �d���}�X�^
                case (int)LoginWorker.OroshishoDistSectionSetDiv.SupplierMaster:
                    {
                        Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
                        if (supplier != null)
                        {
                            stockSectionCd = supplier.MngSectionCode;
                        }
                        break;
                    }
                // �����f�[�^
                case (int)LoginWorker.OroshishoDistSectionSetDiv.OrderData:
                    {
                        UOEOrderDtlWork uoeOrderDetail = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
                        if (uoeOrderDetail != null)
                        {
                            stockSectionCd = uoeOrderDetail.SectionCode;
                        }
                        break;
                    }
                // UOE���Ѓ}�X�^
                case (int)LoginWorker.OroshishoDistSectionSetDiv.UOESettingMaster:
                    {
                        stockSectionCd = LoginWorkerAcs.Instance.Policy.UOESetting.SectionCode;
                        break;
                    }
            }

            return stockSectionCd;
        }

        #endregion  // <018.�d�����_�R�[�h/>

        #region <019.�d���v�㋒�_�R�[�h/>

        /// <summary>
        /// �d���v�㋒�_�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎x�����_�R�[�h���Z�b�g
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockAddUpSectionCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string stockAddUpSectionCd = supplier.PaymentSectionCode;
                CurrentStockSlipRecord.StockAddUpSectionCd = stockAddUpSectionCd;
            }
        }

        #endregion  // <019.�d���v�㋒�_�R�[�h/>

        #region <020.�d���`�[�X�V�敪/>

        /// <summary>
        /// �d���`�[�X�V�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:���X�V
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockSlipUpdateCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            // TODO1
            const int NOT_UPDATE = 0;   // 0:���X�V
            CurrentStockSlipRecord.StockSlipUpdateCd = NOT_UPDATE;
        }

        #endregion  // <020.�d���`�[�X�V�敪/>

        #region <025.�����敪/>

        /// <summary>
        /// �����敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:����
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeDelayPaymentDiv(SumUpStockDataPair stockDataWithSlipNo)
        {
            // TODO1
            const int THIS_MONTH = 0;   // 0:����
            CurrentStockSlipRecord.DelayPaymentDiv = THIS_MONTH;
        }

        #endregion  // <025.�����敪/>

        #region <026.�x����R�[�h/>

        /// <summary>
        /// �x����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎x����R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergePayeeCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            // TODO1
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int payeeCode = supplier.PayeeCode;
                CurrentStockSlipRecord.PayeeCode = payeeCode;
            }
        }

        #endregion  // <026.�x����R�[�h/>

        #region <027.�x���旪��/>

        /// <summary>
        /// �x���旪�̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎x����ɑ΂��闪��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergePayeeSnm(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string payeeSnm = supplier.PayeeSnm;
                CurrentStockSlipRecord.PayeeSnm = payeeSnm;
            }
        }

        #endregion  // <027.�x���旪��/>

        #region <028.�d����R�[�h/>

        /// <summary>
        /// �d����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE�����f�[�^�̎d����R�[�h�i= UOE������}�X�^�̎d����R�[�h�j
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSupplierCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
            if (uoeOrderRecord != null)
            {
                int supplierCd = uoeOrderRecord.SupplierCd;
                CurrentStockSlipRecord.SupplierCd = supplierCd;
            }
        }

        #endregion  // <028.�d����R�[�h/>

        #region <029.�d���於1/>

        /// <summary>
        /// �d���於1���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎d���於1
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSupplierNm1(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string supplierNm1 = supplier.SupplierNm1;
                CurrentStockSlipRecord.SupplierNm1 = supplierNm1;
            }
        }

        #endregion  // <029.�d���於1/>

        #region <030.�d���於2/>

        /// <summary>
        /// �d���於2���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎d���於2
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSupplierNm2(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string supplierNm2 = supplier.SupplierNm2;
                CurrentStockSlipRecord.SupplierNm2 = supplierNm2;
            }
        }

        #endregion  // <030.�d���於2/>

        #region <031.�d���旪��/>

        /// <summary>
        /// �d���旪�̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎d���旪��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSupplierSnm(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string supplierSnm = supplier.SupplierSnm;
                CurrentStockSlipRecord.SupplierSnm = supplierSnm;
            }
        }

        #endregion  // <031.�d���旪��/>

        #region <032.�Ǝ�R�[�h/>

        /// <summary>
        /// �Ǝ�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̋Ǝ�R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeBuisinessTypeCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int businessTypeCode = supplier.BusinessTypeCode;
                CurrentStockSlipRecord.BusinessTypeCode = businessTypeCode;
            }
        }

        #endregion  // <032.�Ǝ�R�[�h/>

        #region <033.�Ǝ햼��/>

        /// <summary>
        /// �Ǝ햼�̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �Ǝ햼��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeBuisinessTypeName(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string businessTypeName = supplier.BusinessTypeName;
                CurrentStockSlipRecord.BusinessTypeName = businessTypeName;
            }
        }

        #endregion  // <033.�Ǝ햼��/>

        #region <034.�̔��G���A�R�[�h/>

        /// <summary>
        /// �̔��G���A�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̒n��R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSalesAreaCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int salesAreaCode = supplier.SalesAreaCode;
                CurrentStockSlipRecord.SalesAreaCode = salesAreaCode;
            }
        }

        #endregion  // <034.�̔��G���A�R�[�h/>

        #region <035.�̔��G���A����/>

        /// <summary>
        /// �̔��G���A���̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �n�於��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSalesAreaName(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                string salesAreaName = supplier.SalesAreaName;
                CurrentStockSlipRecord.SalesAreaName = salesAreaName;
            }
        }

        #endregion  // <035.�̔��G���A����/>

        #region <036.�d�����͎҃R�[�h/>

        /// <summary>
        /// �d�����͎҃R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C���S����
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockInputCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            string stockInputCode = LoginWorkerAcs.Instance.Policy.Profile.EmployeeCode;
            CurrentStockSlipRecord.StockInputCode = stockInputCode;
        }

        #endregion  // <036.�d�����͎҃R�[�h/>

        #region <037.�d�����͎Җ���/>

        /// <summary>
        /// �d�����͎Җ��̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C���S���҂̖���
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockInputName(SumUpStockDataPair stockDataWithSlipNo)
        {
            string stockInputName = LoginWorkerAcs.Instance.Policy.Profile.Name;
            CurrentStockSlipRecord.StockInputName = stockInputName;
        }

        #endregion  // <037.�d�����͎Җ���/>

        #region <038.�d���S���҃R�[�h/>

        /// <summary>
        /// �d���S���҃R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE�����f�[�^�̏]�ƈ��R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockAgentCode(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
            if (uoeOrderRecord != null)
            {
                string stockAgentCode = uoeOrderRecord.EmployeeCode;
                CurrentStockSlipRecord.StockAgentCode = stockAgentCode;
            }
        }

        #endregion  // <038.�d���S���҃R�[�h/>

        #region <039.�d���S���Җ���/>

        /// <summary>
        /// �d���S���Җ��̂��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE�����f�[�^�̏]�ƈ�����
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockAgentName(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
            if (uoeOrderRecord != null)
            {
                string stockAgentName = uoeOrderRecord.EmployeeName;
                CurrentStockSlipRecord.StockAgentName = stockAgentName;
            }
        }

        #endregion  // <039.�d���S���Җ���/>

        #region <040.�d���摍�z�\�����@�敪/>

        /// <summary>
        /// �d���摍�z�\�����@�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎d���摍�z�\�����@�敪
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSuppTtlAmntDspWayCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int suppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;
                CurrentStockSlipRecord.SuppTtlAmntDspWayCd = suppTtlAmntDspWayCd;
            }
        }

        #endregion  // <040.�d���摍�z�\�����@�敪/>

        #region <041.���z�\���|���K�p�敪/>

        /// <summary>
        /// ���z�\���|���K�p�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �S�̏����ݒ�}�X�^�̑��z�\���|���K�p�敪
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeTtlAmntDispRateApy(SumUpStockDataPair stockDataWithSlipNo)
        {
            int ttlAmntDispRateApy = AllDefSetDB.Instance.Policy.AllDefSet.TtlAmntDspRateDivCd;
            CurrentStockSlipRecord.TtlAmntDispRateApy = ttlAmntDispRateApy;
        }

        #endregion  // <041.���z�\���|���K�p�敪/>

        #region <061.�d�������œ]�ŕ����R�[�h/>

        /// <summary>
        /// �d�������œ]�ŕ����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎d�������œ]�ŕ����R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSuppCTaxLayCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier != null)
            {
                int suppCTaxLayCd = supplier.SuppCTaxLayCd;
                CurrentStockSlipRecord.SuppCTaxLayCd = suppCTaxLayCd;
            }
        }

        #endregion  // <061.�d�������œ]�ŕ����R�[�h/>

        #region <062.�d�������Őŗ�/>

        /// <summary>
        /// �d�������Őŗ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �ŗ��ݒ�}�X�^���
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSupplierConsTaxRate(SumUpStockDataPair stockDataWithSlipNo)
        {
            double supplierConsTaxRate = TaxRateSetDB.Instance.Policy.TaxRateOfNow;
            CurrentStockSlipRecord.SupplierConsTaxRate = supplierConsTaxRate;
        }

        #endregion  // <062.�d�������Őŗ�/>

        #region <064.�d���[�������敪/>

        /// <summary>
        /// �d���[�������敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 1:�؎̂�, 2:�l�̌ܓ�, 3:�؏グ�i����Łj
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockFractionProcCd(SumUpStockDataPair stockDataWithSlipNo)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier == null) return;

            UOESendReceiveComponent component = new UOESendReceiveComponent();
            {
                StockProcMoney stockProcMoney = component.GetStockProcMoney(supplier.StockCnsTaxFrcProcCd);
                {
                    if (stockProcMoney == null) return;

                    CurrentStockSlipRecord.StockFractionProcCd = stockProcMoney.FractionProcCd;
                }
            }
        }

        #endregion  // <064.�d���[�������敪/>

        #region <065.�����x���敪/>

        /// <summary>
        /// �����x���敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:�ʏ�x��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeAutoPayment(SumUpStockDataPair stockDataWithSlipNo)
        {
            const int NORMAL = 0;   // 0:�ʏ�x��
            CurrentStockSlipRecord.AutoPayment = NORMAL;
        }

        #endregion  // <065.�����x���敪/>

        #region <069.�����`�[�ԍ�/>

        /// <summary>
        /// �����`�[�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ��M�d���̏o�ד`�[�ԍ�
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergePartySaleSlipNum(SumUpStockDataPair stockDataWithSlipNo)
        {
            // TODO
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);

            if (uoeOrderRecord != null)
            {
                string partySaleSlipNum = uoeOrderRecord.UOESectionSlipNo;
                CurrentStockSlipRecord.PartySaleSlipNum = partySaleSlipNum;
            }
        }

        #endregion  // <069.�����`�[�ԍ�/>

        #region <072.���׍s��/>

        /// <summary>
        /// ���׍s�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���׍s��
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeDetailRowCount(SumUpStockDataPair stockDataWithSlipNo)
        {
            int detailRowCount = stockDataWithSlipNo.Value.Count;
            CurrentStockSlipRecord.DetailRowCount = detailRowCount;
        }

        #endregion  // <072.���׍s��/>

        #region <075.UOE���}�[�N1/>

        /// <summary>
        /// UOE���}�[�N1���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE�����f�[�^��UOE���}�[�N1
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeUoeRemark1(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
            if (uoeOrderRecord != null)
            {
                string uoeRemark1 = uoeOrderRecord.UoeRemark1;
                CurrentStockSlipRecord.UoeRemark1 = uoeRemark1;
            }
        }

        #endregion  // <075.UOE���}�[�N1/>

        #region <076.UOE���}�[�N2/>

        /// <summary>
        /// UOE���}�[�N2���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE�����f�[�^��UOE���}�[�N2
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeUoeRemark2(SumUpStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value[0].DtlRelationGuid);
            if (uoeOrderRecord != null)
            {
                string uoeRemark2 = uoeOrderRecord.UoeRemark2;
                CurrentStockSlipRecord.UoeRemark2 = uoeRemark2;
            }
        }

        #endregion  // <076.UOE���}�[�N2/>

        // 2010/10/19 Add <<<
    }
}
