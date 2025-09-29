using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustSalesAnnualDataSelectResultWork
    /// <summary>
    ///                      ���Ӑ�ʔ���N�Ԏ��яƉ�o���ʃN���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�ʔ���N�Ԏ��яƉ�o���ʃN���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustSalesAnnualDataSelectResultWork 
    {
        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _aUPYearMonth;

        /// <summary>����`�[�敪</summary>
        /// <remarks>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:��Ɓ@�����Ӑ�ʂ̂ݎg�p</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>����݌Ɏ��敪 </summary>
        /// <remarks>0:���A1:�݌Ɂ@�����Ӑ�ʂ̂ݎg�p</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>���i����</summary>
        /// <remarks>0:�����A1:���̑��@�����Ӑ�ʂ̂ݎg�p</remarks>
        private Int32 _goodsKindCode;

        /// <summary>������z�i�Ŕ����j(����,��{)</summary>
        /// <remarks>������z�i�Ŕ����j</remarks>
        private Int64 _salesMoneyTaxExc;

        /// <summary>�ԕi�z(����,��{)</summary>
        private Int64 _salesRetGoodsPrice;

        /// <summary>�l�����z(����,��{)</summary>
        private Int64 _discountPrice;

        /// <summary>�e���z(����,��{)</summary>
        private Int64 _grossProfit;

        /// <summary>����ڕW�z</summary>
        /// <remarks>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</remarks>
        private Int64 _salesTargetMoney;

        /// <summary>�e���ڕW�z</summary>
        /// <remarks>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</remarks>
        private Int64 _salesTargetProfit;

        /// <summary>�����</summary>
        /// <remarks>�o�׉�(���㎞�̂݁j</remarks>
        private Int32 _salesTimes;

        /// <summary>���ԓ`�[����</summary>
        /// <remarks>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</remarks>
        private Int32 _termSalesSlipCount;

        /// <summary>����</summary>
        private Int64 _cost;

        /// <summary>�O�񐿋����z</summary>
        private Int64 _lastTimeDemand;

        /// <summary>�O�񔄊|���z</summary>
        private Int64 _lastTimeAccRec;

        /// <summary>��2��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>��3��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>����`�[����</summary>
        /// <remarks>�|���̓`�[����</remarks>
        private Int32 _salesSlipCount;

        /// <summary>�����������(����)</summary>
        private Int64 _casheDeposit;

        /// <summary>�����������(�U��)</summary>
        private Int64 _trfrDeposit;

        /// <summary>�����������(���؎�)</summary>
        private Int64 _checkKDeposit;

        /// <summary>�����������(��`)</summary>
        private Int64 _draftDeposit;

        /// <summary>�����������(���E)</summary>
        private Int64 _offsetDeposit;

        /// <summary>�����������(�����U��)</summary>
        private Int64 _fundtransferDeposit;

        /// <summary>�����������(E-Money)</summary>
        private Int64 _emoneyDeposit;

        /// <summary>�����������(���̑�)</summary>
        private Int64 _otherDeposit;

        /// <summary>�����������(�萔��)</summary>
        private Int64 _thisTimeFeeDmdNrml;

        /// <summary>�����������(�l��)</summary>
        private Int64 _thisTimeDisDmdNrml;

        /// <summary>���������</summary>
        private Int64 _ofsThisSalesTax;

        /// <summary>�����������(����)</summary>
        private Int64 _thisMCasheDeposit;

        /// <summary>�����������(�U��)</summary>
        private Int64 _thisMhTrfrDeposit;

        /// <summary>�����������(���؎�)</summary>
        private Int64 _thisMCheckKDeposit;

        /// <summary>�����������(��`)</summary>
        private Int64 _thisMDraftDeposit;

        /// <summary>�����������(���E)</summary>
        private Int64 _thisMOffsetDeposit;

        /// <summary>�����������(�����U��)</summary>
        private Int64 _thisMFundtransferDeposit;

        /// <summary>�����������(E-Money)</summary>
        private Int64 _thisMEmoneyDeposit;

        /// <summary>�����������(���̑�)</summary>
        private Int64 _thisMOtherDeposit;

        /// <summary>�����������(�萔��)</summary>
        private Int64 _thisMThisTimeFeeDmdNrml;

        /// <summary>�����������(�l��)</summary>
        private Int64 _thisMThisTimeDisDmdNrml;

        /// <summary>���������</summary>
        private Int64 _thisMOfsThisSalesTax;

        /// <summary>�����敪</summary>
        private Int32 _claimDiv;

        /// <summary>������z�i�Ŕ���)(�D��)</summary>
        /// <remarks>������z�i�Ŕ����j</remarks>
        private Int64 _exSalesMoneyTaxExc;

        /// <summary>�ԕi�z(�D��)</summary>
        private Int64 _exSalesRetGoodsPrice;

        /// <summary>�l�����z(�D��)</summary>
        private Int64 _exDiscountPrice;

        /// <summary>�e���z(�D��)</summary>
        private Int64 _exGrossProfit;


        /// public propaty name  :  AUPYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AUPYearMonth
        {
            get { return _aUPYearMonth; }
            set { _aUPYearMonth = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>����`�[�敪�v���p�e�B</summary>
        /// <value>0:����,1:�ԕi,2:�l��,3:����,4:���v,5:��Ɓ@�����Ӑ�ʂ̂ݎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>����݌Ɏ��敪 �v���p�e�B</summary>
        /// <value>0:���A1:�݌Ɂ@�����Ӑ�ʂ̂ݎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݌Ɏ��敪 �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:�����A1:���̑��@�����Ӑ�ʂ̂ݎg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j(����,��{)�v���p�e�B</summary>
        /// <value>������z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j(����,��{)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesRetGoodsPrice
        /// <summary>�ԕi�z(����,��{)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z(����,��{)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesRetGoodsPrice
        {
            get { return _salesRetGoodsPrice; }
            set { _salesRetGoodsPrice = value; }
        }

        /// public propaty name  :  DiscountPrice
        /// <summary>�l�����z(����,��{)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����z(����,��{)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountPrice
        {
            get { return _discountPrice; }
            set { _discountPrice = value; }
        }

        /// public propaty name  :  GrossProfit
        /// <summary>�e���z(����,��{)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(����,��{)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 GrossProfit
        {
            get { return _grossProfit; }
            set { _grossProfit = value; }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW�z�v���p�e�B</summary>
        /// <value>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>�e���ڕW�z�v���p�e�B</summary>
        /// <value>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���ڕW�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTimes
        /// <summary>����񐔃v���p�e�B</summary>
        /// <value>�o�׉�(���㎞�̂݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesTimes
        {
            get { return _salesTimes; }
            set { _salesTimes = value; }
        }

        /// public propaty name  :  TermSalesSlipCount
        /// <summary>���ԓ`�[�����v���p�e�B</summary>
        /// <value>������v��N���̃��R�[�h�ɂ͓����l���Z�b�g����܂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ԓ`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TermSalesSlipCount
        {
            get { return _termSalesSlipCount; }
            set { _termSalesSlipCount = value; }
        }

        /// public propaty name  :  Cost
        /// <summary>�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        /// public propaty name  :  LastTimeDemand
        /// <summary>�O�񐿋����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񐿋����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimeDemand
        {
            get { return _lastTimeDemand; }
            set { _lastTimeDemand = value; }
        }

        /// public propaty name  :  LastTimeAccRec
        /// <summary>�O�񔄊|���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񔄊|���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimeAccRec
        {
            get { return _lastTimeAccRec; }
            set { _lastTimeAccRec = value; }
        }

        /// public propaty name  :  AcpOdrTtl2TmBfBlDmd
        /// <summary>��2��O�c���i�����v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��2��O�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfBlDmd
        {
            get { return _acpOdrTtl2TmBfBlDmd; }
            set { _acpOdrTtl2TmBfBlDmd = value; }
        }

        /// public propaty name  :  AcpOdrTtl3TmBfBlDmd
        /// <summary>��3��O�c���i�����v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��3��O�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl3TmBfBlDmd
        {
            get { return _acpOdrTtl3TmBfBlDmd; }
            set { _acpOdrTtl3TmBfBlDmd = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>����`�[�����v���p�e�B</summary>
        /// <value>�|���̓`�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesSlipCount
        {
            get { return _salesSlipCount; }
            set { _salesSlipCount = value; }
        }

        /// public propaty name  :  CasheDeposit
        /// <summary>�����������(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CasheDeposit
        {
            get { return _casheDeposit; }
            set { _casheDeposit = value; }
        }

        /// public propaty name  :  TrfrDeposit
        /// <summary>�����������(�U��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(�U��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TrfrDeposit
        {
            get { return _trfrDeposit; }
            set { _trfrDeposit = value; }
        }

        /// public propaty name  :  CheckKDeposit
        /// <summary>�����������(���؎�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(���؎�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CheckKDeposit
        {
            get { return _checkKDeposit; }
            set { _checkKDeposit = value; }
        }

        /// public propaty name  :  DraftDeposit
        /// <summary>�����������(��`)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(��`)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DraftDeposit
        {
            get { return _draftDeposit; }
            set { _draftDeposit = value; }
        }

        /// public propaty name  :  OffsetDeposit
        /// <summary>�����������(���E)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(���E)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OffsetDeposit
        {
            get { return _offsetDeposit; }
            set { _offsetDeposit = value; }
        }

        /// public propaty name  :  FundtransferDeposit
        /// <summary>�����������(�����U��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(�����U��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FundtransferDeposit
        {
            get { return _fundtransferDeposit; }
            set { _fundtransferDeposit = value; }
        }

        /// public propaty name  :  EmoneyDeposit
        /// <summary>�����������(E-Money)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(E-Money)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 EmoneyDeposit
        {
            get { return _emoneyDeposit; }
            set { _emoneyDeposit = value; }
        }

        /// public propaty name  :  OtherDeposit
        /// <summary>�����������(���̑�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(���̑�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OtherDeposit
        {
            get { return _otherDeposit; }
            set { _otherDeposit = value; }
        }

        /// public propaty name  :  ThisTimeFeeDmdNrml
        /// <summary>�����������(�萔��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(�萔��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeFeeDmdNrml
        {
            get { return _thisTimeFeeDmdNrml; }
            set { _thisTimeFeeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisDmdNrml
        /// <summary>�����������(�l��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(�l��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDisDmdNrml
        {
            get { return _thisTimeDisDmdNrml; }
            set { _thisTimeDisDmdNrml = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>��������Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  ThisMCasheDeposit
        /// <summary>�����������(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMCasheDeposit
        {
            get { return _thisMCasheDeposit; }
            set { _thisMCasheDeposit = value; }
        }

        /// public propaty name  :  ThisMhTrfrDeposit
        /// <summary>�����������(�U��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(�U��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMhTrfrDeposit
        {
            get { return _thisMhTrfrDeposit; }
            set { _thisMhTrfrDeposit = value; }
        }

        /// public propaty name  :  ThisMCheckKDeposit
        /// <summary>�����������(���؎�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(���؎�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMCheckKDeposit
        {
            get { return _thisMCheckKDeposit; }
            set { _thisMCheckKDeposit = value; }
        }

        /// public propaty name  :  ThisMDraftDeposit
        /// <summary>�����������(��`)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(��`)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMDraftDeposit
        {
            get { return _thisMDraftDeposit; }
            set { _thisMDraftDeposit = value; }
        }

        /// public propaty name  :  ThisMOffsetDeposit
        /// <summary>�����������(���E)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(���E)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMOffsetDeposit
        {
            get { return _thisMOffsetDeposit; }
            set { _thisMOffsetDeposit = value; }
        }

        /// public propaty name  :  ThisMFundtransferDeposit
        /// <summary>�����������(�����U��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(�����U��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMFundtransferDeposit
        {
            get { return _thisMFundtransferDeposit; }
            set { _thisMFundtransferDeposit = value; }
        }

        /// public propaty name  :  ThisMEmoneyDeposit
        /// <summary>�����������(E-Money)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(E-Money)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMEmoneyDeposit
        {
            get { return _thisMEmoneyDeposit; }
            set { _thisMEmoneyDeposit = value; }
        }

        /// public propaty name  :  ThisMOtherDeposit
        /// <summary>�����������(���̑�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(���̑�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMOtherDeposit
        {
            get { return _thisMOtherDeposit; }
            set { _thisMOtherDeposit = value; }
        }

        /// public propaty name  :  ThisMThisTimeFeeDmdNrml
        /// <summary>�����������(�萔��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(�萔��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMThisTimeFeeDmdNrml
        {
            get { return _thisMThisTimeFeeDmdNrml; }
            set { _thisMThisTimeFeeDmdNrml = value; }
        }

        /// public propaty name  :  ThisMThisTimeDisDmdNrml
        /// <summary>�����������(�l��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������(�l��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMThisTimeDisDmdNrml
        {
            get { return _thisMThisTimeDisDmdNrml; }
            set { _thisMThisTimeDisDmdNrml = value; }
        }

        /// public propaty name  :  ThisMOfsThisSalesTax
        /// <summary>��������Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisMOfsThisSalesTax
        {
            get { return _thisMOfsThisSalesTax; }
            set { _thisMOfsThisSalesTax = value; }
        }

        /// public propaty name  :  claimDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 claimDiv
        {
            get { return _claimDiv; }
            set { _claimDiv = value; }
        }

        /// public propaty name  :  ExSalesMoneyTaxExc
        /// <summary>������z�i�Ŕ���)(�D��)�v���p�e�B</summary>
        /// <value>������z�i�Ŕ����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ���)(�D��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ExSalesMoneyTaxExc
        {
            get { return _exSalesMoneyTaxExc; }
            set { _exSalesMoneyTaxExc = value; }
        }

        /// public propaty name  :  ExSalesRetGoodsPrice
        /// <summary>�ԕi�z(�D��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�z(�D��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ExSalesRetGoodsPrice
        {
            get { return _exSalesRetGoodsPrice; }
            set { _exSalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  ExDiscountPrice
        /// <summary>�l�����z(�D��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����z(�D��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ExDiscountPrice
        {
            get { return _exDiscountPrice; }
            set { _exDiscountPrice = value; }
        }

        /// public propaty name  :  ExGrossProfit
        /// <summary>�e���z(�D��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���z(�D��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ExGrossProfit
        {
            get { return _exGrossProfit; }
            set { _exGrossProfit = value; }
        }


        /// <summary>
        /// ���Ӑ�ʔ���N�Ԏ��яƉ�o���ʃN���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustSalesAnnualDataSelectResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesAnnualDataSelectResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSalesAnnualDataSelectResultWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustSalesAnnualDataSelectResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustSalesAnnualDataSelectResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustSalesAnnualDataSelectResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesAnnualDataSelectResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustSalesAnnualDataSelectResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustSalesAnnualDataSelectResultWork || graph is ArrayList || graph is CustSalesAnnualDataSelectResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CustSalesAnnualDataSelectResultWork).FullName));

            if (graph != null && graph is CustSalesAnnualDataSelectResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustSalesAnnualDataSelectResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustSalesAnnualDataSelectResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustSalesAnnualDataSelectResultWork[])graph).Length;
            }
            else if (graph is CustSalesAnnualDataSelectResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //AUPYearMonth
            //����`�[�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //����݌Ɏ��敪 
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //������z�i�Ŕ����j(����,��{)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //�ԕi�z(����,��{)
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesRetGoodsPrice
            //�l�����z(����,��{)
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPrice
            //�e���z(����,��{)
            serInfo.MemberInfo.Add(typeof(Int64)); //GrossProfit
            //����ڕW�z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney
            //�e���ڕW�z
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit
            //�����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesTimes
            //���ԓ`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //TermSalesSlipCount
            //����
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //�O�񐿋����z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeDemand
            //�O�񔄊|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccRec
            //��2��O�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfBlDmd
            //��3��O�c���i�����v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfBlDmd
            //����`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //�����������(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //CasheDeposit
            //�����������(�U��)
            serInfo.MemberInfo.Add(typeof(Int64)); //TrfrDeposit
            //�����������(���؎�)
            serInfo.MemberInfo.Add(typeof(Int64)); //CheckKDeposit
            //�����������(��`)
            serInfo.MemberInfo.Add(typeof(Int64)); //DraftDeposit
            //�����������(���E)
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetDeposit
            //�����������(�����U��)
            serInfo.MemberInfo.Add(typeof(Int64)); //FundtransferDeposit
            //�����������(E-Money)
            serInfo.MemberInfo.Add(typeof(Int64)); //EmoneyDeposit
            //�����������(���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //OtherDeposit
            //�����������(�萔��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //�����������(�l��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //���������
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //�����������(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMCasheDeposit
            //�����������(�U��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMhTrfrDeposit
            //�����������(���؎�)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMCheckKDeposit
            //�����������(��`)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMDraftDeposit
            //�����������(���E)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMOffsetDeposit
            //�����������(�����U��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMFundtransferDeposit
            //�����������(E-Money)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMEmoneyDeposit
            //�����������(���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMOtherDeposit
            //�����������(�萔��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMThisTimeFeeDmdNrml
            //�����������(�l��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMThisTimeDisDmdNrml
            //���������
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisMOfsThisSalesTax
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //claimDiv
            //������z�i�Ŕ���)(�D��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ExSalesMoneyTaxExc
            //�ԕi�z(�D��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ExSalesRetGoodsPrice
            //�l�����z(�D��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ExDiscountPrice
            //�e���z(�D��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ExGrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is CustSalesAnnualDataSelectResultWork)
            {
                CustSalesAnnualDataSelectResultWork temp = (CustSalesAnnualDataSelectResultWork)graph;

                SetCustSalesAnnualDataSelectResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustSalesAnnualDataSelectResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustSalesAnnualDataSelectResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustSalesAnnualDataSelectResultWork temp in lst)
                {
                    SetCustSalesAnnualDataSelectResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustSalesAnnualDataSelectResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 45;

        /// <summary>
        ///  CustSalesAnnualDataSelectResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesAnnualDataSelectResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCustSalesAnnualDataSelectResultWork(System.IO.BinaryWriter writer, CustSalesAnnualDataSelectResultWork temp)
        {
            //�v��N��
            writer.Write(temp.AUPYearMonth);
            //����`�[�敪
            writer.Write(temp.SalesSlipCdDtl);
            //����݌Ɏ��敪 
            writer.Write(temp.SalesOrderDivCd);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //������z�i�Ŕ����j(����,��{)
            writer.Write(temp.SalesMoneyTaxExc);
            //�ԕi�z(����,��{)
            writer.Write(temp.SalesRetGoodsPrice);
            //�l�����z(����,��{)
            writer.Write(temp.DiscountPrice);
            //�e���z(����,��{)
            writer.Write(temp.GrossProfit);
            //����ڕW�z
            writer.Write(temp.SalesTargetMoney);
            //�e���ڕW�z
            writer.Write(temp.SalesTargetProfit);
            //�����
            writer.Write(temp.SalesTimes);
            //���ԓ`�[����
            writer.Write(temp.TermSalesSlipCount);
            //����
            writer.Write(temp.Cost);
            //�O�񐿋����z
            writer.Write(temp.LastTimeDemand);
            //�O�񔄊|���z
            writer.Write(temp.LastTimeAccRec);
            //��2��O�c���i�����v�j
            writer.Write(temp.AcpOdrTtl2TmBfBlDmd);
            //��3��O�c���i�����v�j
            writer.Write(temp.AcpOdrTtl3TmBfBlDmd);
            //����`�[����
            writer.Write(temp.SalesSlipCount);
            //�����������(����)
            writer.Write(temp.CasheDeposit);
            //�����������(�U��)
            writer.Write(temp.TrfrDeposit);
            //�����������(���؎�)
            writer.Write(temp.CheckKDeposit);
            //�����������(��`)
            writer.Write(temp.DraftDeposit);
            //�����������(���E)
            writer.Write(temp.OffsetDeposit);
            //�����������(�����U��)
            writer.Write(temp.FundtransferDeposit);
            //�����������(E-Money)
            writer.Write(temp.EmoneyDeposit);
            //�����������(���̑�)
            writer.Write(temp.OtherDeposit);
            //�����������(�萔��)
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //�����������(�l��)
            writer.Write(temp.ThisTimeDisDmdNrml);
            //���������
            writer.Write(temp.OfsThisSalesTax);
            //�����������(����)
            writer.Write(temp.ThisMCasheDeposit);
            //�����������(�U��)
            writer.Write(temp.ThisMhTrfrDeposit);
            //�����������(���؎�)
            writer.Write(temp.ThisMCheckKDeposit);
            //�����������(��`)
            writer.Write(temp.ThisMDraftDeposit);
            //�����������(���E)
            writer.Write(temp.ThisMOffsetDeposit);
            //�����������(�����U��)
            writer.Write(temp.ThisMFundtransferDeposit);
            //�����������(E-Money)
            writer.Write(temp.ThisMEmoneyDeposit);
            //�����������(���̑�)
            writer.Write(temp.ThisMOtherDeposit);
            //�����������(�萔��)
            writer.Write(temp.ThisMThisTimeFeeDmdNrml);
            //�����������(�l��)
            writer.Write(temp.ThisMThisTimeDisDmdNrml);
            //���������
            writer.Write(temp.ThisMOfsThisSalesTax);
            //�����敪
            writer.Write(temp.claimDiv);
            //������z�i�Ŕ���)(�D��)
            writer.Write(temp.ExSalesMoneyTaxExc);
            //�ԕi�z(�D��)
            writer.Write(temp.ExSalesRetGoodsPrice);
            //�l�����z(�D��)
            writer.Write(temp.ExDiscountPrice);
            //�e���z(�D��)
            writer.Write(temp.ExGrossProfit);

        }

        /// <summary>
        ///  CustSalesAnnualDataSelectResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustSalesAnnualDataSelectResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesAnnualDataSelectResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CustSalesAnnualDataSelectResultWork GetCustSalesAnnualDataSelectResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CustSalesAnnualDataSelectResultWork temp = new CustSalesAnnualDataSelectResultWork();

            //�v��N��
            temp.AUPYearMonth = reader.ReadInt32();
            //����`�[�敪
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //����݌Ɏ��敪 
            temp.SalesOrderDivCd = reader.ReadInt32();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //������z�i�Ŕ����j(����,��{)
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //�ԕi�z(����,��{)
            temp.SalesRetGoodsPrice = reader.ReadInt64();
            //�l�����z(����,��{)
            temp.DiscountPrice = reader.ReadInt64();
            //�e���z(����,��{)
            temp.GrossProfit = reader.ReadInt64();
            //����ڕW�z
            temp.SalesTargetMoney = reader.ReadInt64();
            //�e���ڕW�z
            temp.SalesTargetProfit = reader.ReadInt64();
            //�����
            temp.SalesTimes = reader.ReadInt32();
            //���ԓ`�[����
            temp.TermSalesSlipCount = reader.ReadInt32();
            //����
            temp.Cost = reader.ReadInt64();
            //�O�񐿋����z
            temp.LastTimeDemand = reader.ReadInt64();
            //�O�񔄊|���z
            temp.LastTimeAccRec = reader.ReadInt64();
            //��2��O�c���i�����v�j
            temp.AcpOdrTtl2TmBfBlDmd = reader.ReadInt64();
            //��3��O�c���i�����v�j
            temp.AcpOdrTtl3TmBfBlDmd = reader.ReadInt64();
            //����`�[����
            temp.SalesSlipCount = reader.ReadInt32();
            //�����������(����)
            temp.CasheDeposit = reader.ReadInt64();
            //�����������(�U��)
            temp.TrfrDeposit = reader.ReadInt64();
            //�����������(���؎�)
            temp.CheckKDeposit = reader.ReadInt64();
            //�����������(��`)
            temp.DraftDeposit = reader.ReadInt64();
            //�����������(���E)
            temp.OffsetDeposit = reader.ReadInt64();
            //�����������(�����U��)
            temp.FundtransferDeposit = reader.ReadInt64();
            //�����������(E-Money)
            temp.EmoneyDeposit = reader.ReadInt64();
            //�����������(���̑�)
            temp.OtherDeposit = reader.ReadInt64();
            //�����������(�萔��)
            temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
            //�����������(�l��)
            temp.ThisTimeDisDmdNrml = reader.ReadInt64();
            //���������
            temp.OfsThisSalesTax = reader.ReadInt64();
            //�����������(����)
            temp.ThisMCasheDeposit = reader.ReadInt64();
            //�����������(�U��)
            temp.ThisMhTrfrDeposit = reader.ReadInt64();
            //�����������(���؎�)
            temp.ThisMCheckKDeposit = reader.ReadInt64();
            //�����������(��`)
            temp.ThisMDraftDeposit = reader.ReadInt64();
            //�����������(���E)
            temp.ThisMOffsetDeposit = reader.ReadInt64();
            //�����������(�����U��)
            temp.ThisMFundtransferDeposit = reader.ReadInt64();
            //�����������(E-Money)
            temp.ThisMEmoneyDeposit = reader.ReadInt64();
            //�����������(���̑�)
            temp.ThisMOtherDeposit = reader.ReadInt64();
            //�����������(�萔��)
            temp.ThisMThisTimeFeeDmdNrml = reader.ReadInt64();
            //�����������(�l��)
            temp.ThisMThisTimeDisDmdNrml = reader.ReadInt64();
            //���������
            temp.ThisMOfsThisSalesTax = reader.ReadInt64();
            //�����敪
            temp.claimDiv = reader.ReadInt32();
            //������z�i�Ŕ���)(�D��)
            temp.ExSalesMoneyTaxExc = reader.ReadInt64();
            //�ԕi�z(�D��)
            temp.ExSalesRetGoodsPrice = reader.ReadInt64();
            //�l�����z(�D��)
            temp.ExDiscountPrice = reader.ReadInt64();
            //�e���z(�D��)
            temp.ExGrossProfit = reader.ReadInt64();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>CustSalesAnnualDataSelectResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesAnnualDataSelectResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustSalesAnnualDataSelectResultWork temp = GetCustSalesAnnualDataSelectResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (CustSalesAnnualDataSelectResultWork[])lst.ToArray(typeof(CustSalesAnnualDataSelectResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
