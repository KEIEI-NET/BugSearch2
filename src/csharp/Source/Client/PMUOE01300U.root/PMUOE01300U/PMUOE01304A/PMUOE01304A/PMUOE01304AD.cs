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

using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    using LoginWorkerAcs    = SingletonPolicy<LoginWorker>;
    using StockDB           = SingletonPolicy<StockDBAgent>;
    using OrderStockDataPair= KeyValuePair<ReceivedText>;
    using SupplierDB        = SingletonPolicy<SupplierDBAgent>;
    using AllDefSetDB       = SingletonPolicy<AllDefSetDBAgent>;
    using TaxRateSetDB      = SingletonPolicy<TaxRateSetDBAgent>;

    /// <summary>
    /// �������̎d���f�[�^�̍\�z�҃N���X
    /// </summary>
    public class OrderStockDataBuilder : OrderInformationBuilder
    {
        #region <�i�����/>

        /// <summary>�������̃��b�Z�[�W</summary>
        protected const string NOW_RUNNING = "�d���f�[�^(�������)���쐬��";    // LITERAL:

        /// <summary>�i�����</summary>
        private readonly UpdateProgressEventArgs _progressInfo = new UpdateProgressEventArgs(NOW_RUNNING, 0, 0);
        /// <summary>
        /// �i�������擾���܂��B
        /// </summary>
        protected UpdateProgressEventArgs ProgressInfo { get { return _progressInfo; } }

        #endregion  // <�i�����/>

        #region <���݂̔������̎d���f�[�^�̃��R�[�h/>

        /// <summary>���݂�UOE�����f�[�^�̃��R�[�h</summary>
        private StockSlipWork _currentStockSlipRecord;
        /// <summary>
        /// ���݂�UOE�����f�[�^�̃��R�[�h�̃A�N�Z�T
        /// </summary>
        /// <value>���݂�UOE�����f�[�^�̃��R�[�h</value>
        private StockSlipWork CurrentStockSlipRecord
        {
            get { return _currentStockSlipRecord; }
            set { _currentStockSlipRecord = value; }
        }

        #endregion  // <���݂̔������̎d���f�[�^�̃��R�[�h/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <param name="receivedTelegramAgreegate">��M�d���̏W����</param>
        /// <param name="observer">�ȈՃI�u�U�[�o�[</param>
        public OrderStockDataBuilder(
            UOESupplierHelper uoeSupplier,
            IAgreegate<ReceivedText> receivedTelegramAgreegate,
            IProgressUpdatable observer
        ) : base(uoeSupplier, receivedTelegramAgreegate, observer)
        { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// �������̎d���f�[�^�Ɏ�M�d�������UOE�����f�[�^�̓��e���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �������̎d���f�[�^�̍\�z�ɂ����閾���Y�Ƃɂ��ꍇ������
        /// MergeStockDate()�F023.�d����
        /// �݂̂ł��B
        /// ��L���\�b�h�ȊO�ł��ꍇ������������������ꍇ�A�����Y�Ɨp�̃T�u�N���X�����������邱�ƁB
        /// </remarks>
        public override void Merge()
        {
            ProgressInfo.IsRunning = true;

            foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)
            {
                ProgressInfo.Max += uoeSlip.Count;
            }

            // �o�ד`�[�ԍ��̃��[�v
            foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)
            {
                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();

                // ����o�ד`�[�ԍ��ɂ������M�e�L�X�g�i���ׁj�̃��[�v
                foreach (ReceivedText receivedTelegram in uoeSlip)
                {
                    Observer.Update(ProgressInfo);

                    bool isNewRecord = false;

                    CurrentStockSlipRecord = StockDB.Instance.Policy.FindStockSlipWork(receivedTelegram);
                    if (CurrentStockSlipRecord == null)
                    {
                        CurrentStockSlipRecord = new StockSlipWork();
                        isNewRecord = true;
                    }
                    Debug.Assert(!isNewRecord, "�d���f�[�^�ɐV���ȃ��R�[�h�������I�ɑ}�����悤�Ƃ��Ă��܂��B");

                    OrderStockDataPair stockDataWithSlipNo = new OrderStockDataPair(
                        StockDB.Instance.Policy.FindSupplierSlipNo(receivedTelegram),
                        receivedTelegram
                    );

                    // �o�^�ς݂̔������͊�{�I�ɂ��̂܂�
                    if (!receivedTelegram.IsTelephoneOrder())
                    {
                        MergeStockSectionCd(stockDataWithSlipNo);   // 018.�d�����_�R�[�h
                        MergeStockDate(stockDataWithSlipNo);        // 023.�d�����@��026.�x����R�[�h��019.�d���v�㋒�_�R�[�h���Q�Ƃ��邽�߁A��������Ƀ}�[�W
                        MergePartySaleSlipNum(stockDataWithSlipNo); // 069.�����`�[�ԍ�
                        continue;
                    }

                    // �d�����׃f�[�^�̓��e���}�[�W
                    MergeEnterpriseCode(stockDataWithSlipNo);       // 003.��ƃR�[�h
                    MergeSupplierFormal(stockDataWithSlipNo);       // 009.�d���`��
                    MergeSupplierSlipNo(stockDataWithSlipNo);       // 010.�d���`�[�ԍ�
                    MergeSectionCode(stockDataWithSlipNo);          // 011.���_�R�[�h
                    MergeSubSectionCode(stockDataWithSlipNo);       // 012.����R�[�h
                    MergeDebitNoteNo(stockDataWithSlipNo);          // 013.�ԓ`�敪
                    MergeSupplierSlipCd(stockDataWithSlipNo);       // 015.�d���`�[�敪
                    MergeStockGoodsCd(stockDataWithSlipNo);         // 016.�d�����i�敪
                    MergeAccPayDivCd(stockDataWithSlipNo);          // 017.���|�敪
                    MergeStockSectionCd(stockDataWithSlipNo);       // 018.�d�����_�R�[�h
                    MergeStockAddUpSectionCd(stockDataWithSlipNo);  // 019.�d���v�㋒�_�R�[�h
                    MergeStockSlipUpdateCd(stockDataWithSlipNo);    // 020.�d���`�[�X�V�敪
                    MergeInputDay(stockDataWithSlipNo);             // 021.���͓�
                    MergeDelayPaymentDiv(stockDataWithSlipNo);      // 025.�����敪
                    MergePayeeCode(stockDataWithSlipNo);            // 026.�x����R�[�h
                    MergePayeeSnm(stockDataWithSlipNo);             // 027.�x���旪��
                    MergeStockDate(stockDataWithSlipNo);            // 023.�d�����@��026.�x����R�[�h��019.�d���v�㋒�_�R�[�h���Q�Ƃ��邽�߁A��������Ƀ}�[�W
                    {
                        MergeSupplierCd(stockDataWithSlipNo);       // 028.�d����R�[�h
                    }
                    MergeSupplierNm1(stockDataWithSlipNo);          // 029.�d���於1
                    MergeSupplierNm2(stockDataWithSlipNo);          // 030.�d���於2
                    MergeSupplierSnm(stockDataWithSlipNo);          // 031.�d���旪��
                    MergeBuisinessTypeCode(stockDataWithSlipNo);    // 032.�Ǝ�R�[�h
                    MergeBuisinessTypeName(stockDataWithSlipNo);    // 033.�Ǝ햼��
                    MergeSalesAreaCode(stockDataWithSlipNo);        // 034.�̔��G���A�R�[�h
                    MergeSalesAreaName(stockDataWithSlipNo);        // 035.�̔��G���A����
                    MergeStockInputCode(stockDataWithSlipNo);       // 036.�d�����͎҃R�[�h
                    MergeStockInputName(stockDataWithSlipNo);       // 037.�d�����͎Җ���
                    {
                        MergeStockAgentCode(stockDataWithSlipNo);   // 038.�d���S���҃R�[�h
                        MergeStockAgentName(stockDataWithSlipNo);   // 039.�d���S���Җ���
                    }
                    MergeSuppTtlAmntDspWayCd(stockDataWithSlipNo);  // 040.�d���摍�z�\�����@�敪
                    MergeTtlAmntDispRateApy(stockDataWithSlipNo);   // 041.���z�\���|���K�p�敪
                    MergeStockTotalPrice(stockDataWithSlipNo);      // 042.�d�����z���v
                    MergeStockSubttlPrice(stockDataWithSlipNo);     // 043.�d�����z���v
                    MergeSuppCTaxLayCd(stockDataWithSlipNo);        // 061.�d�������œ]�ŕ����R�[�h
                    MergeSupplierConsTaxRate(stockDataWithSlipNo);  // 062.�d�������Őŗ�
                    MergeStockFractionProcCd(stockDataWithSlipNo);  // 064.�d���[�������敪
                    MergeAutoPayment(stockDataWithSlipNo);          // 065.�����x���敪
                    MergePartySaleSlipNum(stockDataWithSlipNo);     // 069.�����`�[�ԍ�
                    MergeDetailRowCount(stockDataWithSlipNo);       // 072.���׍s��
                    {
                        MergeUoeRemark1(stockDataWithSlipNo);       // 075.UOE���}�[�N1
                        MergeUoeRemark2(stockDataWithSlipNo);       // 076.UOE���}�[�N2
                    }

                    // �Ή�����d�����׃f�[�^��ێ�
                    StockDetailWork foundStockDetailWork = StockDB.Instance.Policy.FindStockDetailWork(receivedTelegram);
                    if (foundStockDetailWork != null)
                    {
                        stockDetailWorkList.Add(foundStockDetailWork);
                    }

                    ProgressInfo.Count++;
                }   // foreach (ReceivedText receivedTelegram in uoeSlip)

                // �d���f�[�^�̏��Z�o
                if (stockDetailWorkList.Count > 0)
                {
                    SetCalculatedStockSlipWork(stockDetailWorkList);
                }
            }   // foreach (IList<ReceivedText> uoeSlip in ReceivedTelegramAgreegate.GroupedListMap.Values)

            ProgressInfo.IsRunning = false;
        }

        #endregion  // <Override/>

        #region <003.��ƃR�[�h/>

        /// <summary>
        /// ��ƃR�[�h���}�[�W���܂��B
        /// </summary>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeEnterpriseCode(OrderStockDataPair stockDataWithSlipNo)
        {
            string enterpriseCode = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
            CurrentStockSlipRecord.EnterpriseCode = enterpriseCode;
        }

        #endregion  // <003.��ƃR�[�h/>

        #region <009.�d���`��/>

        /// <summary>
        /// �d���`�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 2:����
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSupplierFormal(OrderStockDataPair stockDataWithSlipNo)
        {
            const int ORDER = 2;    // 2:����
            CurrentStockSlipRecord.SupplierFormal = ORDER;
        }

        #endregion  // <009.�d���`��/>

        #region <010.�d���`�[�ԍ�/>

        /// <summary>
        /// �d���`�[�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �̔ԁ@��UOE�����f�[�^�̎d���`�[�ԍ���ݒ肵�Ă��܂��B
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSupplierSlipNo(OrderStockDataPair stockDataWithSlipNo)
        {
            int supplierSlipNo = int.Parse(stockDataWithSlipNo.Key);
            CurrentStockSlipRecord.SupplierSlipNo = supplierSlipNo;
        }

        #endregion  // <010.�d���`�[�ԍ�/>

        #region <011.���_�R�[�h/>

        /// <summary>
        /// ���_�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�C���S���҂̏������_�R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSectionCode(OrderStockDataPair stockDataWithSlipNo)
        {
            string sectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
            CurrentStockSlipRecord.SectionCode = sectionCode;
        }

        #endregion  // <011.���_�R�[�h/>

        #region <012.����R�[�h/>

        /// <summary>
        /// ����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �S���҂̏�������R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSubSectionCode(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeDebitNoteNo(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierSlipCd(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockGoodsCd(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeAccPayDivCd(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockSectionCd(OrderStockDataPair stockDataWithSlipNo)
        {
            // �d�����_�R�[�h���}�[�W
            string stockSectionCd = GetStockSectionCd(stockDataWithSlipNo.Value);
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
        protected string GetStockSectionCd(ReceivedText receivedTelegram)
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
                    UOEOrderDtlWork uoeOrderDetail = StockDB.Instance.Policy.FindUOEOrderDtlWork(receivedTelegram);
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
        protected void MergeStockAddUpSectionCd(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockSlipUpdateCd(OrderStockDataPair stockDataWithSlipNo)
        {
            const int NOT_UPDATE = 0;   // 0:���X�V
            CurrentStockSlipRecord.StockSlipUpdateCd = NOT_UPDATE;
        }

        #endregion  // <020.�d���`�[�X�V�敪/>

        #region <021.���͓�/>

        /// <summary>
        /// ���͓����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// YYYYMMDD�i�X�V�N�����j
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeInputDay(OrderStockDataPair stockDataWithSlipNo)
        {
            DateTime inputDay = DateTime.Now;
            CurrentStockSlipRecord.InputDay = inputDay;
        }

        #endregion  // <021.���͓�/>

        #region <023.�d����/>

        /// <summary>
        /// �d�������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �����Y�Ƃ̏ꍇ�A��M�d���̕��ރR�[�h���Z�o
        /// ���ς݂̏ꍇ�A
        /// ��026.�x����R�[�h��019.�d���v�㋒�_�R�[�h���Q�Ƃ��邽�߁A��������Ƀ}�[�W
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockDate(OrderStockDataPair stockDataWithSlipNo)
        {
            if (stockDataWithSlipNo.Value.IsTelephoneOrder()) return;   // �d�b�����̏ꍇ�A���ݒ�

            DateTime stockDate = CurrentStockSlipRecord.StockDate;

            if (UoeSupplier is UOEMeijiDecorator)
            {
                ReceivedDate receivedDate = new ReceivedDate(stockDataWithSlipNo.Value.ClassifiedCode.Trim());
                stockDate = receivedDate.ToDateTime();
            }
            else
            {
                if (stockDate.Equals(DateTime.MinValue))
                {
                    UOEOrderDtlWork uoeOrderDetailRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(
                        stockDataWithSlipNo.Value.DtlRelationGuid
                    );
                    if (uoeOrderDetailRecord != null)
                    {
                        stockDate = uoeOrderDetailRecord.ReceiveDate;
                    }
                    else
                    {
                        stockDate = DateTime.Now;
                    }
                }
            }

            // �����`�F�b�N
            stockDate = GetDayPayment(stockDate, CurrentStockSlipRecord);
            CurrentStockSlipRecord.StockDate = stockDate;
        }

        #region <�����`�F�b�N/>

        /// <summary>
        /// �������l�������d�������擾���܂��B
        /// </summary>
        /// <remarks>
        /// ���|�I�v�V��������̏ꍇ�A�d���f�[�^�̎d����R�[�h�ɂāA�d�������Ǝd�������̒����`�F�b�N
        /// ���|�I�v�V�����Ȃ��̏ꍇ�A�d���f�[�^�̎d���v�㋒�_�R�[�h�ɂāA���㌎���̒����`�F�b�N
        /// </remarks>
        /// <param name="stockDate">�d����</param>
        /// <param name="stockSlipWork">�d���f�[�^</param>
        /// <returns>
        /// ���ς݂̏ꍇ�A�O���������+1��
        /// </returns>
        public static DateTime GetDayPayment(
            DateTime stockDate,
            StockSlipWork stockSlipWork
        )
        {
            // �����Z�o���W���[��
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime previousTotalDay= DateTime.MinValue;
            DateTime currentTotalDay = DateTime.MinValue;
            {
                // ���|�I�v�V��������
                if (LoginWorkerAcs.Instance.Policy.HasStockingPaymentOption)
                {
                    // �d�������̒����擾
                    if (totalDayCalculator.CheckMonthlyAccPay(
                        stockSlipWork.StockAddUpSectionCd,
                        stockSlipWork.PayeeCode,
                        stockDate
                    ))
                    {
                        if (totalDayCalculator.GetTotalDayMonthlyAccPay(
                            stockSlipWork.StockAddUpSectionCd,
                            stockSlipWork.PayeeCode,
                            out previousTotalDay,
                            out currentTotalDay
                        ).Equals(0))
                        {
                            return previousTotalDay.AddDays(1);
                        }
                    }

                    // �d�������̒����擾
                    if (totalDayCalculator.CheckPayment(
                        stockSlipWork.StockAddUpSectionCd,
                        stockSlipWork.PayeeCode,
                        stockDate
                    ))
                    {
                        if (totalDayCalculator.GetTotalDayPayment(
                            stockSlipWork.StockAddUpSectionCd,
                            stockSlipWork.PayeeCode,
                            out previousTotalDay,
                            out currentTotalDay
                        ).Equals(0))
                        {
                            return previousTotalDay.AddDays(1);
                        }
                    }
                }
                // ���|�I�v�V�����Ȃ�
                else
                {
                    totalDayCalculator.InitializeHisMonthlyAccPay();

                    // ���㌎���̒����擾
                    if (totalDayCalculator.CheckMonthlyAccRec(
                        stockSlipWork.StockAddUpSectionCd,
                        stockSlipWork.PayeeCode,
                        stockDate
                    ))
                    {
                        if (totalDayCalculator.GetHisTotalDayMonthly(
                            stockSlipWork.StockAddUpSectionCd,
                            out previousTotalDay,
                            out currentTotalDay
                        ).Equals(0))
                        {
                            return previousTotalDay.AddDays(1);
                        }
                    }
                }
            }

            return stockDate;
        }

        #endregion  // <�����`�F�b�N/>

        #endregion  // <023.�d����/>

        #region <025.�����敪/>

        /// <summary>
        /// �����敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:����
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeDelayPaymentDiv(OrderStockDataPair stockDataWithSlipNo)
        {
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
        protected void MergePayeeCode(OrderStockDataPair stockDataWithSlipNo)
        {
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
        protected void MergePayeeSnm(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierCd(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
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
        protected void MergeSupplierNm1(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierNm2(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierSnm(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeBuisinessTypeCode(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeBuisinessTypeName(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeSalesAreaCode(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeSalesAreaName(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockInputCode(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockInputName(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockAgentCode(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
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
        protected void MergeStockAgentName(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
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
        protected void MergeSuppTtlAmntDspWayCd(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeTtlAmntDispRateApy(OrderStockDataPair stockDataWithSlipNo)
        {
            int ttlAmntDispRateApy = AllDefSetDB.Instance.Policy.AllDefSet.TtlAmntDspRateDivCd;
            CurrentStockSlipRecord.TtlAmntDispRateApy = ttlAmntDispRateApy;
        }

        #endregion  // <041.���z�\���|���K�p�敪/>

        #region <042.�d�����z���v/>

        /// <summary>
        /// �d�����z���v���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d�����׃f�[�^�̎d�����z�i�Ŕ����j���v
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockTotalPrice(OrderStockDataPair stockDataWithSlipNo)
        {
            long stockTotalPrice = StockDB.Instance.Policy.GetStockTotalPrice(stockDataWithSlipNo.Value);
            CurrentStockSlipRecord.StockTotalPrice = stockTotalPrice;
        }

        #endregion  // <042.�d�����z���v/>

        #region <043.�d�����z���v/>

        /// <summary>
        /// �d�����z���v���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d�����׃f�[�^�̎d�����z�i�ō��݁j���v
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockSubttlPrice(OrderStockDataPair stockDataWithSlipNo)
        {
            long stockSubttlPrice = StockDB.Instance.Policy.GetStockSubttlPrice(stockDataWithSlipNo.Value);
            CurrentStockSlipRecord.StockSubttlPrice = stockSubttlPrice;
        }

        #endregion  // <043.�d�����z���v/>

        #region <044.�d�����z�v�i�ō��݁j/>

        /// <summary>
        /// �d�����z�v�i�ō��݁j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d�����׃f�[�^�̎d�����z�i�ō��݁j���v
        /// �i�d�����z���v�������l�j
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockTtlPricTaxInc(OrderStockDataPair stockDataWithSlipNo)
        {
            long stockTtlPricTaxInc = CurrentStockSlipRecord.StockSubttlPrice;
            CurrentStockSlipRecord.StockTtlPricTaxInc = stockTtlPricTaxInc;
        }

        #endregion  // <044.�d�����z�v�i�ō��݁j/>

        #region <045.�d�����z�v�i�Ŕ����j/>

        /// <summary>
        /// �d�����z�v�i�Ŕ����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d�����׃f�[�^�̎d�����z�i�Ŕ����j���v
        /// �i�d�����z���v�������l�j
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeStockTtlPricTaxExc(OrderStockDataPair stockDataWithSlipNo)
        {
            long stockTtlPricTaxExc = CurrentStockSlipRecord.StockTotalPrice;
            CurrentStockSlipRecord.StockTtlPricTaxExc = stockTtlPricTaxExc;
        }

        #endregion  // <044.�d�����z�v�i�ō��݁j/>

        #region <061.�d�������œ]�ŕ����R�[�h/>

        /// <summary>
        /// �d�������œ]�ŕ����R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d����}�X�^�̎d�������œ]�ŕ����R�[�h
        /// </remarks>
        /// <param name="stockDataWithSlipNo">�`�[�ԍ��Ǝ�M�d��</param>
        protected void MergeSuppCTaxLayCd(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeSupplierConsTaxRate(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeStockFractionProcCd(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergeAutoPayment(OrderStockDataPair stockDataWithSlipNo)
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
        protected void MergePartySaleSlipNum(OrderStockDataPair stockDataWithSlipNo)
        {
            string partySaleSlipNum = stockDataWithSlipNo.Value.UOESectionSlipNo;
            CurrentStockSlipRecord.PartySaleSlipNum = partySaleSlipNum;
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
        protected void MergeDetailRowCount(OrderStockDataPair stockDataWithSlipNo)
        {
            int detailRowCount = StockDB.Instance.Policy.GetDetailRowCount(stockDataWithSlipNo.Value);
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
        protected void MergeUoeRemark1(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
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
        protected void MergeUoeRemark2(OrderStockDataPair stockDataWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(stockDataWithSlipNo.Value);
            if (uoeOrderRecord != null)
            {
                string uoeRemark2 = uoeOrderRecord.UoeRemark2;
                CurrentStockSlipRecord.UoeRemark2 = uoeRemark2;
            }
        }

        #endregion  // <076.UOE���}�[�N2/>

        /// <summary>
        /// �d���f�[�^�̏����Z�o���A�ݒ肵�܂��B
        /// </summary>
        /// <param name="uoeStockDetailWorkList"></param>
        protected void SetCalculatedStockSlipWork(List<StockDetailWork> uoeStockDetailWorkList)
        {
            Supplier supplier = SupplierDB.Instance.Policy.Find(UoeSupplier);
            if (supplier == null) return;

            UOESendReceiveComponent component = new UOESendReceiveComponent();
            StockProcMoney stockProcMoney = component.GetStockProcMoney(supplier.StockCnsTaxFrcProcCd);
            if (stockProcMoney == null) return;
            
            StockSlipPriceCalculator.TotalPriceSetting(
                ref _currentStockSlipRecord,
                uoeStockDetailWorkList,
                stockProcMoney.FractionProcUnit,
                supplier.StockCnsTaxFrcProcCd
            );
        }
    }
}
