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
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using StockDB           = SingletonPolicy<StockDBAgent>;
    using LoginWorkerAcs    = SingletonPolicy<LoginWorker>;
    using StockDetailPair   = KeyValuePair<StockDetailWork>; 

    /// <summary>
    /// �v����̎d�����׃f�[�^�̍\�z�҃N���X
    /// </summary>
    public class SumUpStockDetailDataBuilder : SumUpInformationBuilder
    {
        #region <���݂̌v����̎d�����׃f�[�^�̃��R�[�h/>

        /// <summary>���݂̌v����̎d�����׃f�[�^�̃��R�[�h</summary>
        private StockDetailWork _currentStockDetailRecord;
        /// <summary>
        /// ���݂̌v����̎d�����׃f�[�^�̃��R�[�h�̃A�N�Z�T
        /// </summary>
        private StockDetailWork CurrentStockDetailRecord
        {
            get { return _currentStockDetailRecord; }
            set { _currentStockDetailRecord = value; }
        }

        #endregion  // <���݂̌v����̎d�����׃f�[�^�̃��R�[�h/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public SumUpStockDetailDataBuilder(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// �v����̎d�����׃f�[�^�ɔ������̎d�����׃f�[�^���}�[�W���܂��B
        /// </summary>
        public override void Merge()
        {
            // ������񂩂�d���f�[�^�i�v��j��������
            StockDB.Instance.Policy.InitializeSumUpStockInformation();

            foreach (int supplierSlipNo in StockDB.Instance.Policy.SumUpStockSlipDetailRecordMap.Keys)
            {
                int rowNo = 1;  // 2010/10/19 Add
                foreach (StockDetailWork stockDetailWork in StockDB.Instance.Policy.SumUpStockSlipDetailRecordMap[supplierSlipNo])
                {
                    string slipNo = supplierSlipNo.ToString();
                    CurrentStockDetailRecord = stockDetailWork;
                    StockDetailPair stockDetailRecordWithSlipNo = new StockDetailPair(slipNo, CurrentStockDetailRecord);

                    //// �o�^�ς݂̔��������x�[�X�Ƃ���v����͂��̂܂�
                    //if (supplierSlipNo > 0)
                    //{
                    //    MergeSupplierFormalSrc(stockDetailRecordWithSlipNo);// 017.�d���`���i���j
                    //    continue;
                    //}

                    // �������̎d�����׃f�[�^�̓��e���}�[�W
                    MergeSupplierFormal(stockDetailRecordWithSlipNo);       // 010.�d���`��
                    MergeSectionCode(stockDetailRecordWithSlipNo);          // 013.���_�R�[�h
                    MergeSupplierFormalSrc(stockDetailRecordWithSlipNo);    // 017.�d���`���i���j
                    MergeStockSlipDtlNumSrc(stockDetailRecordWithSlipNo);   // 018.�d�����גʔԁi���j
                    MergeAcptAnOdrStatusSync(stockDetailRecordWithSlipNo);  // 019.�󒍃X�e�[�^�X�i�����j
                    MergeSalesSlipDtlNumSync(stockDetailRecordWithSlipNo);  // 020.���㖾�גʔԁi�����j
                    {
                        MergeStockCount(stockDetailRecordWithSlipNo);       // 073.�d����
                    }
                    MergeOrderCnt(stockDetailRecordWithSlipNo);             // 074.��������
                    MergeOrderAdjustCnt(stockDetailRecordWithSlipNo);       // 075.����������
                    MergeOrderRemainCnt(stockDetailRecordWithSlipNo);       // 076.�����c��
                    MergeStockPriceConsTax(stockDetailRecordWithSlipNo);    // 081.�d�����z����Ŋz

                    CurrentStockDetailRecord.StockRowNo = rowNo++;          // 2010/10/19 Add
                }
            }
        }

        #endregion  // <Override/>

        #region <010.�d���`��/>

        /// <summary>
        /// �d���`�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:�d��
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeSupplierFormal(StockDetailPair stockDetailRecordWithSlipNo)
        {
            const int STOCK = 0;    // 0:�d��
            CurrentStockDetailRecord.SupplierFormal = STOCK;
        }

        #endregion  // <010.�d���`��/>

        #region <013.���_�R�[�h/>

        /// <summary>
        /// ���_�R�[�h���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE���Аݒ�}�X�^�̉������_�ݒ�敪�ɏ]���Z�b�g
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeSectionCode(StockDetailPair stockDetailRecordWithSlipNo)
        {
            string sectionCode = GetSectionCodeFromUOESetting();
            if (!string.IsNullOrEmpty(sectionCode))
            {
                CurrentStockDetailRecord.SectionCode = sectionCode;
            }
        }

        #endregion  // <013.���_�R�[�h/>

        #region <017.�d���`���i���j/>

        /// <summary>
        /// �d���`���i���j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �v�㌳�̎d���`��
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeSupplierFormalSrc(StockDetailPair stockDetailRecordWithSlipNo)
        {
            const int ORDER = 2;    // ����
            int supplierFormalSrc = ORDER;
            CurrentStockDetailRecord.SupplierFormalSrc = supplierFormalSrc;
        }

        #endregion  // <017.�d���`���i���j/>

        #region <018.�d�����גʔԁi���j/>

        /// <summary>
        /// �d�����גʔԁi���j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �v�㌳�̎d�����גʔ�
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeStockSlipDtlNumSrc(StockDetailPair stockDetailRecordWithSlipNo)
        {
            long stockSlipDtlNumSrc = stockDetailRecordWithSlipNo.Value.StockSlipDtlNum;
            CurrentStockDetailRecord.StockSlipDtlNumSrc = stockSlipDtlNumSrc;
        }

        #endregion  // <018.�d�����גʔԁi���j/>

        #region <019.�󒍃X�e�[�^�X�i�����j/>

        /// <summary>
        /// �󒍃X�e�[�^�X�i�����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���ݒ�Ƃ���
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeAcptAnOdrStatusSync(StockDetailPair stockDetailRecordWithSlipNo)
        {
            int acptAnOdrStatusSync = 0;
            CurrentStockDetailRecord.AcptAnOdrStatusSync = acptAnOdrStatusSync;
        }

        #endregion  // <019.�󒍃X�e�[�^�X�i�����j/>

        #region <020.���㖾�גʔԁi�����j/>

        /// <summary>
        /// ���㖾�גʔԁi�����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���ݒ�Ƃ���
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeSalesSlipDtlNumSync(StockDetailPair stockDetailRecordWithSlipNo)
        {
            long salesSlipDtlNumSync = 0;
            CurrentStockDetailRecord.SalesSlipDtlNumSync = salesSlipDtlNumSync;
        }

        #endregion  // <020.���㖾�גʔԁi�����j/>

        #region <073.�d����/>

        /// <summary>
        /// �d�������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// UOE�����f�[�^��UOE���_�o�ɐ�
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeStockCount(StockDetailPair stockDetailRecordWithSlipNo)
        {
            UOEOrderDtlWork uoeOrderDataRecord = StockDB.Instance.Policy.FindUOEOrderDtlWork(
                stockDetailRecordWithSlipNo.Value.DtlRelationGuid
            );
            double stockCount = 0.0;
            if (uoeOrderDataRecord != null)
            {
                stockCount = (double)uoeOrderDataRecord.UOESectOutGoodsCnt;
            }
            else
            {
                stockCount = stockDetailRecordWithSlipNo.Value.OrderRemainCnt;
            }
            CurrentStockDetailRecord.StockCount = stockCount;
        }

        #endregion  // <073.�d����/>

        #region <074.��������/>

        /// <summary>
        /// �������ʂ��}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d�����Ɠ���
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeOrderCnt(StockDetailPair stockDetailRecordWithSlipNo)
        {
            double orderCnt = CurrentStockDetailRecord.StockCount;
            CurrentStockDetailRecord.OrderCnt = orderCnt;
        }

        #endregion  // <074.��������/>

        #region <075.����������/>

        /// <summary>
        /// �������������}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeOrderAdjustCnt(StockDetailPair stockDetailRecordWithSlipNo)
        {
            CurrentStockDetailRecord.OrderAdjustCnt = 0;
        }

        #endregion  // <075.����������/>

        #region <076.�����c��/>

        /// <summary>
        /// �����c�����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d�����Ɠ���
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeOrderRemainCnt(StockDetailPair stockDetailRecordWithSlipNo)
        {
            double orderRemainCnt = CurrentStockDetailRecord.StockCount;
            CurrentStockDetailRecord.OrderRemainCnt = orderRemainCnt;
        }

        #endregion  // <076.�����c��/>

        #region <081.�d�����z����Ŋz/>

        /// <summary>
        /// �d�����z����Ŋz���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �d�����z�i�ō��݁j - �d�����z�i�Ŕ����j
        /// </remarks>
        /// <param name="stockDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̎d�����׃f�[�^</param>
        protected void MergeStockPriceConsTax(StockDetailPair stockDetailRecordWithSlipNo)
        {
            long stockPriceConsTax = CurrentStockDetailRecord.StockPriceTaxInc - CurrentStockDetailRecord.StockPriceTaxExc;
            CurrentStockDetailRecord.StockPriceConsTax = stockPriceConsTax;
        }

        #endregion  // <081.�d�����z����Ŋz/>
    }
}
