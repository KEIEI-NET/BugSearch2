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

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// UOE����M�����̍ė��p���i�N���X
    /// </summary>
    public sealed class UOESendReceiveComponent
    {
        #region <UOE�����f�[�^�A�N�Z�X/>

        /// <summary>UOE�����f�[�^�A�N�Z�X</summary>
        /// <remarks>���M�����̃N���X�̍ė��p</remarks>
        private readonly UOEOrderDtlAcs _uoeOoderDtlAcs;
        /// <summary>
        /// UOE�����f�[�^�A�N�Z�X���擾���܂��B
        /// </summary>
        /// <value>UOE�����f�[�^�A�N�Z�X</value>
        private UOEOrderDtlAcs UoeOoderDtlAcs { get { return _uoeOoderDtlAcs; } }

        #endregion  // <UOE�����f�[�^�A�N�Z�X/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UOESendReceiveComponent()
        {
            _uoeOoderDtlAcs = new UOEOrderDtlAcs();
        }

        #endregion  // <Constructor/>

        #region <����M/>

        /// <summary>
        /// �d���v���d���̉����i��M�e�L�X�g�j����M���܂��B
        /// </summary>
        /// <param name="uoeSndRcvCtlPara">UOE����M����p�����[�^</param>
        /// <param name="uoeSndHedList">���M�d���̃��X�g</param>
        /// <param name="receivingUOESupplier">��M����UOE������</param>
        /// <param name="uoeRecHed">����</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public static int ReceiveUOEStockRequestText(
            UoeSndRcvCtlPara uoeSndRcvCtlPara,
            List<UoeSndHed> uoeSndHedList,
            EnumUoeConst.ReceivingUOESupplier receivingUOESupplier,
            out UoeRecHed uoeRecHed,
            out string errorMessage
        )
        {
            UoeSndRcvCtlAcs realSendReceiveControlAcs = new UoeSndRcvCtlAcs();
            int status = realSendReceiveControlAcs.ReceiveUOEStockRequestTextAndInsertJNL(
                uoeSndRcvCtlPara,
                uoeSndHedList,
                receivingUOESupplier,
                out uoeRecHed,
                out errorMessage
            );
            // JNL��DataSet���C���X�^���X�����Ă��Ȃ����߁AUoeSndRcvCtlAcs.ReceiveUOEStockRequestTextAndInsertJNL()�� 4 ��Ԃ�
            if (status.Equals((int)Result.RemoteStatus.NotFound))
            {
                status = (int)Result.RemoteStatus.Normal;
            }
            // ����M�N���X���Ń��b�Z�[�W���o�͂��邽�߁A�߂�l�����H
            if (!status.Equals((int)Result.RemoteStatus.Normal) || uoeRecHed == null || uoeRecHed.UoeRecDtlList.Count.Equals(0))
            {
                status = (int)Result.Code.Abort;
            }
            else
            {
                status = (int)Result.Code.Normal;
            }

            return status;
        }

        #endregion  // <����M/>

        #region <�ō����z�̎擾/>

        /// <summary>
        /// �d���ō����z���擾���܂��B
        /// </summary>
        /// <remarks>
        /// [�ė��p��]<br/>
        /// PMUOE01046AA.cs::UOEOrderDtlAcs.GetStockPriceTaxInc()
        /// </remarks>
        /// <param name="targetPrice">�Ώۋ��z</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        /// <returns>�ō��݋��z</returns>
        public double GetStockPriceTaxInc(
            double targetPrice,
            int taxationCode,
            int stockCnsTaxFrcProcCd
        )
        {
            return UoeOoderDtlAcs.GetStockPriceTaxInc(targetPrice, taxationCode, stockCnsTaxFrcProcCd);
        }

        /// <summary>
        /// �d�����z���v�Z���܂��B
        /// </summary>
        /// <remarks>
        /// [�ė��p��]<br/>
        /// PMUOE01046AA.cs::UOEOrderDtlAcs.CalculationStockPrice()
        /// </remarks>
        /// <param name="stockCount">�d����</param>
        /// <param name="stockUnitPrice">�d���P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="stockMoneyFrcProcCd">�d�����z�[�������R�[�h</param>
        /// <param name="taxFracProcCode">����Œ[�������敪</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <param name="stockPriceConsTax">�d�������</param>
        /// <returns>
        /// <c>true</c> :����<br/>
        /// <c>false</c>:���s
        /// </returns>
        public bool CalculationStockPrice(
            double stockCount,
            double stockUnitPrice,
            int taxationCode,
            int stockMoneyFrcProcCd,
            int taxFracProcCode,
            out long stockPriceTaxInc,
            out long stockPriceTaxExc,
            out long stockPriceConsTax
        )
        {
            return UoeOoderDtlAcs.CalculationStockPrice(
                stockCount,
                stockUnitPrice,
                taxationCode,
                stockMoneyFrcProcCd,
                taxFracProcCode,
                out stockPriceTaxInc,
                out stockPriceTaxExc,
                out stockPriceConsTax
            );
        }

        #endregion  // <�ō����z�̎擾/>

        #region <���z�\���敪�Z�b�g/>

        /// <summary>
        /// �d���f�[�^�̍��v�����Z�o���܂��B
        /// </summary>
        /// <remarks>
        /// [�ė��p��]<br/>
        /// PMUOE01048AA.cs::UOESalesStockAcs.uoeStockSlipCreate()
        /// </remarks>
        /// <param name="stockSlipWork">�d���f�[�^�̃��R�[�h</param>
        /// <param name="stockDetailWorkList">�d�����׃f�[�^�̃��X�g</param>
        /// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
        public void CalculateTotalPrice(
            ref StockSlipWork stockSlipWork,
            List<StockDetailWork> stockDetailWorkList,
            int stockCnsTaxFrcProcCd
        )
        {
            // �[�������P��
            StockProcMoney stockProcMoney = UoeOoderDtlAcs.GetStockProcMoney(
                1,  // TODO:Magic Number
                stockCnsTaxFrcProcCd,
                999999999.0
            );

            // �d���f�[�^�̏��Z�o
            StockSlipPriceCalculator.TotalPriceSetting(
                ref stockSlipWork,
                stockDetailWorkList,
                stockProcMoney.FractionProcUnit,
                stockCnsTaxFrcProcCd
            ); // TODO:044�`058?
        }

        #endregion  // <���z�\���敪�Z�b�g/>

        #region <�d���f�[�^�̏��Z�o/>

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <remarks>
        /// [�ė��p��]<br/>
        /// PMUOE01046AA.cs::UOEOrderDtlAcs.GetStockProcMoney()<br/>
        /// PMUOE01047AA.cs::UOEAnswerAcs.GetStockSlipWorkFromStockDetailDataTable()
        /// </remarks>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <returns>�d�����z�����敪�ݒ�}�X�^�̃��R�[�h</returns>
        public StockProcMoney GetStockProcMoney(int fractionProcCode)
        {
            return UoeOoderDtlAcs.GetStockProcMoney(1, fractionProcCode, 999999999);
        }

        #endregion  // <�d���f�[�^�̏��Z�o/>
    }
}
