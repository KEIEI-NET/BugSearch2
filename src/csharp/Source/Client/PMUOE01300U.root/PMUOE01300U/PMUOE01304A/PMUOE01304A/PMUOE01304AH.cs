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
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2009/10/15  �C�����e : �݌ɒ����f�[�^�̍��v���z���ďW�v����悤�ɏC��(MANTIS[0014424])
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    using StockDB               = SingletonPolicy<StockDBAgent>;
    using SupplierDB            = SingletonPolicy<SupplierDBAgent>;
    using SumUpStockAdjustPair  = KeyValuePair<IList<StockAdjustDtlWork>>;

    /// <summary>
    /// �v����̍݌ɒ����f�[�^�̍\�z�҃N���X
    /// </summary>
    public class SumUpStockAdjustBuilder : SumUpInformationBuilder
    {
        #region <���݂̌v����̍݌ɒ����f�[�^�̃��R�[�h/>

        /// <summary>���݂̌v����̍݌ɒ����f�[�^�̃��R�[�h</summary>
        private StockAdjustWork _currentStockAdjustRecord;
        /// <summary>
        /// ���݂̌v����̍݌ɒ����f�[�^�̃��R�[�h�̃A�N�Z�T
        /// </summary>
        private StockAdjustWork CurrentStockAdjustRecord
        {
            get { return _currentStockAdjustRecord; }
            set { _currentStockAdjustRecord = value; }
        }

        #endregion  // <���݂̌v����̍݌ɒ����f�[�^�̃��R�[�h/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public SumUpStockAdjustBuilder(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// �v����̍݌ɒ����f�[�^�ɔ������̎d���f�[�^�̓��e���}�[�W���܂��B
        /// </summary>
        public override void Merge()
        {
            foreach (int supplierSlipNo in StockDB.Instance.Policy.SumUpStockAdjustDetailRecordMap.Keys)
            {
                string slipNo = supplierSlipNo.ToString();
                SumUpStockAdjustPair stockAdjustWithSlipNo = new SumUpStockAdjustPair(
                    slipNo,
                    StockDB.Instance.Policy.SumUpStockAdjustDetailRecordMap[supplierSlipNo]
                );

                CurrentStockAdjustRecord = StockDB.Instance.Policy.SumUpAdjustRecordMap[supplierSlipNo];

                // �d���f�[�^�̓��e���}�[�W
                MergeAcPaySlipCd(stockAdjustWithSlipNo);        // 011.�󕥌��`�[�敪
                MergeAcPayTransCd(stockAdjustWithSlipNo);       // 012.�󕥌�����敪
                MergeAdjustDate(stockAdjustWithSlipNo);         // 013.�������t
                MergeInputDay(stockAdjustWithSlipNo);           // 014.���͓��t
                // 2009/10/15 Add >>>
                MergeStockSubttlPrice(stockAdjustWithSlipNo);   // 020.�d�����z���v
                // 2009/10/15 Add <<<
            }
        }

        #endregion  // <Override/>

        #region <011.�󕥌��`�[�敪/>

        /// <summary>
        /// �󕥌��`�[�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 13:�݌Ɏd���@��2009/02/05 �v�㌳�̓`�[�敪�ɕύX�H
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ����f�[�^</param>
        protected void MergeAcPaySlipCd(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            const int STOCK_STOCK = 13; // 13:�݌Ɏd��
            CurrentStockAdjustRecord.AcPaySlipCd = STOCK_STOCK;
        }

        #endregion  // <011.�󕥌��`�[�敪/>

        #region <012.�󕥌�����敪/>

        /// <summary>
        /// �󕥌�����敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 30:�݌ɐ�����
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ����f�[�^</param>
        protected void MergeAcPayTransCd(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            const int STOCK_ADJUST= 30; // 30:�݌ɐ�����
            const int NORMAL_SLIP = 10; // 10:�ʏ�`�[
            CurrentStockAdjustRecord.AcPayTransCd = STOCK_ADJUST;
        }

        #endregion  // <012.�󕥌�����敪/>

        #region <013.�������t/>

        /// <summary>
        /// �������t���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t�i�����̃`�F�b�N�j
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ����f�[�^</param>
        protected void MergeAdjustDate(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            DateTime adjustDate = DateTime.Now;

            // �����`�F�b�N
            adjustDate = GetDayPayment(adjustDate, UoeSupplier);

            CurrentStockAdjustRecord.AdjustDate = adjustDate;
        }

        #region <�����`�F�b�N/>

        /// <summary>
        /// �������l�������������t���擾���܂��B
        /// </summary>
        /// <remarks>
        /// �d���f�[�^�̎d���v�㋒�_�R�[�h�ɂāA���㌎���̒����`�F�b�N
        /// </remarks>
        /// <param name="adjustDate">�������t</param>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns>
        /// ���ς݂̏ꍇ�A�O���������+1��
        /// </returns>
        public static DateTime GetDayPayment(
            DateTime adjustDate,
            UOESupplierHelper uoeSupplier
        )
        {
            string stockAddUpSectionCd = string.Empty;  // �d���v�㋒�_�R�[�h
            int payeeCode = 0;                          // �x����R�[�h
            {
                Supplier supplier = SupplierDB.Instance.Policy.Find(uoeSupplier);
                if (supplier == null) return adjustDate;

                stockAddUpSectionCd = supplier.PaymentSectionCode;
                payeeCode = supplier.PayeeCode;
            }

            // �����Z�o���W���[��
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime previousTotalDay= DateTime.MinValue;
            DateTime currentTotalDay = DateTime.MinValue;
            {
                totalDayCalculator.InitializeHisMonthlyAccPay();

                // ���㌎���̒����擾
                if (totalDayCalculator.CheckMonthlyAccRec(
                    stockAddUpSectionCd,
                    payeeCode,
                    adjustDate
                ))
                {
                    if (totalDayCalculator.GetHisTotalDayMonthly(
                        stockAddUpSectionCd,
                        out previousTotalDay,
                        out currentTotalDay
                    ).Equals(0))
                    {
                        return previousTotalDay.AddDays(1);
                    }
                }
            }

            return adjustDate;
        }

        #endregion  // <�����`�F�b�N/>

        #endregion  // <013.�������t/>

        #region <014.���͓��t/>

        /// <summary>
        /// ���͓��t���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ����f�[�^</param>
        protected void MergeInputDay(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            DateTime inputDay = DateTime.Now;
            CurrentStockAdjustRecord.InputDay = inputDay;
        }

        #endregion  // <014.���͓��t/>

        // 2009/10/15 Add >>>
        #region <020.�d�����z���v>
        /// <summary>
        /// �d�����z���v���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// ���ׂ̍݌ɒ������z���W�v
        /// </remarks>
        /// <param name="stockAdjustWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ����f�[�^</param>
        protected void MergeStockSubttlPrice(SumUpStockAdjustPair stockAdjustWithSlipNo)
        {
            long sum = 0;
            foreach (StockAdjustDtlWork stockAdjustDtlWork in stockAdjustWithSlipNo.Value)
            {
                sum += stockAdjustDtlWork.StockPriceTaxExc;
            }
            CurrentStockAdjustRecord.StockSubttlPrice = sum;
        }
        #endregion
        // 2009/10/15 Add <<<
    }
}
