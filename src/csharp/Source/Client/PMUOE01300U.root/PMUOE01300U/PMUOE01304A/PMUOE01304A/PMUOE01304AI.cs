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

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using StockDB               = SingletonPolicy<StockDBAgent>;
    using StockAdjustDetailPair = KeyValuePair<StockAdjustDtlWork>;

    /// <summary>
    /// �v����̍݌ɒ������׃f�[�^�̍\�z�҃N���X
    /// </summary>
    public class SumUpStockAdjustDetailBuilder : SumUpInformationBuilder
    {
        #region <���݂̌v����̍݌ɒ������׃f�[�^�̃��R�[�h/>

        /// <summary>���݂̌v����̍݌ɒ������׃f�[�^�̃��R�[�h</summary>
        private StockAdjustDtlWork _currentStockAdjustDtlRecord;
        /// <summary>
        /// ���݂̌v����̍݌ɒ������׃f�[�^�̃��R�[�h�̃A�N�Z�T
        /// </summary>
        private StockAdjustDtlWork CurrentStockAdjustDtlRecord
        {
            get { return _currentStockAdjustDtlRecord; }
            set { _currentStockAdjustDtlRecord = value; }
        }

        #endregion  // <���݂̌v����̍݌ɒ������׃f�[�^�̃��R�[�h/>

        /// <summary>�݌ɒ����s�ԍ��̃J�E���^</summary>
        private int _stockAdjustRowNoCount;

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        public SumUpStockAdjustDetailBuilder(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// �v����̍݌ɒ������׃f�[�^�ɔ������̎d�����׃f�[�^���}�[�W���܂��B
        /// </summary>
        public override void Merge()
        {
            // ������񂩂�݌ɒ����f�[�^��������
            StockDB.Instance.Policy.InitializeSumUpAdjustInformation();

            foreach (int supplierSlipNo in StockDB.Instance.Policy.SumUpStockAdjustDetailRecordMap.Keys)
            {
                _stockAdjustRowNoCount = 0; // �݌ɒ����s�ԍ��̃J�E���^�����Z�b�g

                foreach (StockAdjustDtlWork stockAdjustDtlWork in StockDB.Instance.Policy.SumUpStockAdjustDetailRecordMap[supplierSlipNo])
                {
                    _stockAdjustRowNoCount++;

                    string slipNo = supplierSlipNo.ToString();
                    CurrentStockAdjustDtlRecord = stockAdjustDtlWork;
                    StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo = new StockAdjustDetailPair(
                        slipNo,
                        CurrentStockAdjustDtlRecord
                    );
                    // �������̎d�����׃f�[�^�̓��e���}�[�W
                    MergeStockAdjustRowNo(stockAdjustDetailRecordWithSlipNo);       // 011.�݌ɒ����s�ԍ�
                    MergeSupplierFormalSrc(stockAdjustDetailRecordWithSlipNo);      // 012.�d���`���i���j
                    MergeAcPaySlipCd(stockAdjustDetailRecordWithSlipNo);            // 014.�󕥌��`�[�敪
                    MergeAcPayTransCd(stockAdjustDetailRecordWithSlipNo);           // 015.�󕥌�����敪
                    MergeAdjustDate(stockAdjustDetailRecordWithSlipNo);             // 016.�������t
                    MergeInputDay(stockAdjustDetailRecordWithSlipNo);               // 017.���͓��t
                    MergeOpenPriceDiv(stockAdjustDetailRecordWithSlipNo);           // 032.�I�[�v�����i�敪
                    MergeStockPriceTaxExc(stockAdjustDetailRecordWithSlipNo);       // 033.�d�����z�i�Ŕ����j
                }
            }
        }

        #endregion  // <Override/>

        #region <011.�݌ɒ����s�ԍ�/>

        /// <summary>
        /// �݌ɒ����s�ԍ����}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �̔�
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ������׃f�[�^</param>
        protected void MergeStockAdjustRowNo(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            int stockAdjustRowNo = _stockAdjustRowNoCount;
            CurrentStockAdjustDtlRecord.StockAdjustRowNo = stockAdjustRowNo;
        }

        #endregion  // <011.�݌ɒ����s�ԍ�/>

        #region <012.�d���`���i���j/>

        /// <summary>
        /// �d���`���i���j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 2:����
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ������׃f�[�^</param>
        protected void MergeSupplierFormalSrc(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            int supplierFormalSrc = 2;  // ����
            CurrentStockAdjustDtlRecord.SupplierFormalSrc = supplierFormalSrc;
        }

        #endregion  // <012.�d���`���i���j/>

        #region <014.�󕥌��`�[�敪/>

        /// <summary>
        /// �󕥌��`�[�敪���}�[�W���܂��B
        /// </summary>
        /// <param name="stockAdjustDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ������׃f�[�^</param>
        protected void MergeAcPaySlipCd(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            const int STOCK_STOCK = 13; // 13:�݌Ɏd��
            CurrentStockAdjustDtlRecord.AcPaySlipCd = STOCK_STOCK;
        }

        #endregion  // <014.�󕥌��`�[�敪/>

        #region <015.�󕥌�����敪/>

        /// <summary>
        /// �󕥌�����敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 10:�ʏ�`�[
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ������׃f�[�^</param>
        protected void MergeAcPayTransCd(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            const int NORMAL_SLIP = 10; // 10:�ʏ�`�[
            const int STOCK_ADJUST= 30; // 30:�݌ɐ�����
            CurrentStockAdjustDtlRecord.AcPayTransCd = STOCK_ADJUST;
        }

        #endregion  // <015.�󕥌�����敪/>

        #region <016.�������t/>

        /// <summary>
        /// �������t���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ������׃f�[�^</param>
        protected void MergeAdjustDate(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            DateTime adjustDate = DateTime.Now;

            // �����`�F�b�N
            adjustDate = SumUpStockAdjustBuilder.GetDayPayment(adjustDate, UoeSupplier);

            CurrentStockAdjustDtlRecord.AdjustDate = adjustDate;
        }

        #endregion  // <016.�������t/>

        #region <017.���͓��t/>

        /// <summary>
        /// �������t���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �V�X�e�����t
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ������׃f�[�^</param>
        protected void MergeInputDay(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            DateTime inputDay = DateTime.Now;
            CurrentStockAdjustDtlRecord.InputDay = inputDay;
        }

        #endregion  // <017.���͓��t/>

        #region <032.�I�[�v�����i�敪/>

        /// <summary>
        /// �I�[�v�����i�敪���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// 0:�ʏ�
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ������׃f�[�^</param>
        protected void MergeOpenPriceDiv(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            const int NORMAL = 0;   // 0:�ʏ�
            CurrentStockAdjustDtlRecord.OpenPriceDiv = NORMAL;
        }

        #endregion  // <032.�I�[�v�����i�敪/>

        #region <033.�d�����z�i�Ŕ����j/>

        /// <summary>
        /// �d�����z�i�Ŕ����j���}�[�W���܂��B
        /// </summary>
        /// <remarks>
        /// �񓚌����i=�d���P���i�Ŕ�, �����j�j�~�񓚐��i=�������j
        /// </remarks>
        /// <param name="stockAdjustDetailRecordWithSlipNo">�o�ד`�[�ԍ��Ɣ������̍݌ɒ������׃f�[�^</param>
        protected void MergeStockPriceTaxExc(StockAdjustDetailPair stockAdjustDetailRecordWithSlipNo)
        {
            double answerCostPrice  = CurrentStockAdjustDtlRecord.StockUnitPriceFl;
            double answerCount      = CurrentStockAdjustDtlRecord.AdjustCount;
            CurrentStockAdjustDtlRecord.StockPriceTaxExc = (long)(answerCostPrice * answerCount);
        }

        #endregion  // <033.�d�����z�i�Ŕ����j/>
    }
}
