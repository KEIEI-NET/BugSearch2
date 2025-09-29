using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppYearResultAccPayWork
    /// <summary>
    ///                      �d���N�Ԏ��яƉ�(�c���Ɖ�)���o���ʃN���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���N�Ԏ��яƉ�(�c���Ɖ�)���o���ʃN���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppYearResultAccPayWork
    {
        /// <summary>�d��3��O�c���i�x���v�j</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _stockTtl3TmBfBlPay;

        /// <summary>�d��2��O�c���i�x���v�j</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>�O��x�����z</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _lastTimePayment;

        /// <summary>�x�����(����)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _cashePayment;

        /// <summary>�x�����(�U��)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _trfrPayment;

        /// <summary>�x�����(���؎�)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _checkKPayment;

        /// <summary>�x�����(��`)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _draftPayment;

        /// <summary>�x�����(���E)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _offsetPayment;

        /// <summary>�x�����(�����U��)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _fundtransferPayment;

        /// <summary>�x�����(E-Money)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _emoneyPayment;

        /// <summary>�x�����(���̑�)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _otherPayment;

        /// <summary>�x�����(�萔��)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>�x�����(�l��)</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _thisTimeDisPayNrml;

        /// <summary>�d���`�[����</summary>
        /// <remarks>�x�����p</remarks>
        private Int32 _stockSlipCount;

        /// <summary>����d�����z</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>����ԕi���z</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _thisStckPricRgds;

        /// <summary>����l�����z</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _thisStckPricDis;

        /// <summary>���E�㍡��d�����z</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>���E�㍡��d�������</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>�d�����v�c���i�x���v�j</summary>
        /// <remarks>�x�����p</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>�O�񔃊|���z</summary>
        /// <remarks>�����p�@�O�����c</remarks>
        private Int64 _monthLastTimeAccPay;

        /// <summary>�������(����)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthCashePayment;

        /// <summary>�������(�U��)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthTrfrPayment;

        /// <summary>�������(���؎�)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthCheckKPayment;

        /// <summary>�������(��`)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthDraftPayment;

        /// <summary>�������(���E)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthOffsetPayment;

        /// <summary>�������(�����U��)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthFundtransferPayment;

        /// <summary>�������(E-Money)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthEmoneyPayment;

        /// <summary>�������(���̑�)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthOtherPayment;

        /// <summary>�������(�萔��)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthThisTimeFeePayNrml;

        /// <summary>�������(�l��)</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthThisTimeDisPayNrml;

        /// <summary>�����d���`�[����</summary>
        /// <remarks>�����p</remarks>
        private Int32 _monthStockSlipCount;

        /// <summary>��������d�����z</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthThisTimeStockPrice;

        /// <summary>��������ԕi���z</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthThisStckPricRgds;

        /// <summary>��������l�����z</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthThisStckPricDis;

        /// <summary>�������E�㍡��d�����z</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthOfsThisTimeStock;

        /// <summary>�������E�㍡��d�������</summary>
        /// <remarks>�����p</remarks>
        private Int64 _monthOfsThisStockTax;

        /// <summary>�����d�����v�c���i���|�v�j</summary>
        /// <remarks>�����p�@���ݔ��|�c��</remarks>
        private Int64 _monthStckTtlAccPayBalance;

        /// <summary>�����d���`�[����</summary>
        /// <remarks>�����p</remarks>
        private Int32 _yearStockSlipCount;

        /// <summary>��������d�����z</summary>
        /// <remarks>�����p</remarks>
        private Int64 _yearThisTimeStockPrice;

        /// <summary>��������ԕi���z</summary>
        /// <remarks>�����p</remarks>
        private Int64 _yearThisStckPricRgds;

        /// <summary>��������l�����z</summary>
        /// <remarks>�����p</remarks>
        private Int64 _yearThisStckPricDis;

        /// <summary>�������E�㍡��d�����z</summary>
        /// <remarks>�����p</remarks>
        private Int64 _yearOfsThisTimeStock;

        /// <summary>�������E�㍡��d�������</summary>
        /// <remarks>�����p</remarks>
        private Int64 _yearOfsThisStockTax;


        /// public propaty name  :  StockTtl3TmBfBlPay
        /// <summary>�d��3��O�c���i�x���v�j�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��3��O�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtl3TmBfBlPay
        {
            get { return _stockTtl3TmBfBlPay; }
            set { _stockTtl3TmBfBlPay = value; }
        }

        /// public propaty name  :  StockTtl2TmBfBlPay
        /// <summary>�d��2��O�c���i�x���v�j�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��2��O�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTtl2TmBfBlPay
        {
            get { return _stockTtl2TmBfBlPay; }
            set { _stockTtl2TmBfBlPay = value; }
        }

        /// public propaty name  :  LastTimePayment
        /// <summary>�O��x�����z�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O��x�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimePayment
        {
            get { return _lastTimePayment; }
            set { _lastTimePayment = value; }
        }

        /// public propaty name  :  CashePayment
        /// <summary>�x�����(����)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CashePayment
        {
            get { return _cashePayment; }
            set { _cashePayment = value; }
        }

        /// public propaty name  :  TrfrPayment
        /// <summary>�x�����(�U��)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(�U��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TrfrPayment
        {
            get { return _trfrPayment; }
            set { _trfrPayment = value; }
        }

        /// public propaty name  :  CheckKPayment
        /// <summary>�x�����(���؎�)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(���؎�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CheckKPayment
        {
            get { return _checkKPayment; }
            set { _checkKPayment = value; }
        }

        /// public propaty name  :  DraftPayment
        /// <summary>�x�����(��`)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(��`)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DraftPayment
        {
            get { return _draftPayment; }
            set { _draftPayment = value; }
        }

        /// public propaty name  :  OffsetPayment
        /// <summary>�x�����(���E)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(���E)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OffsetPayment
        {
            get { return _offsetPayment; }
            set { _offsetPayment = value; }
        }

        /// public propaty name  :  FundtransferPayment
        /// <summary>�x�����(�����U��)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(�����U��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FundtransferPayment
        {
            get { return _fundtransferPayment; }
            set { _fundtransferPayment = value; }
        }

        /// public propaty name  :  EmoneyPayment
        /// <summary>�x�����(E-Money)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(E-Money)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 EmoneyPayment
        {
            get { return _emoneyPayment; }
            set { _emoneyPayment = value; }
        }

        /// public propaty name  :  OtherPayment
        /// <summary>�x�����(���̑�)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(���̑�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OtherPayment
        {
            get { return _otherPayment; }
            set { _otherPayment = value; }
        }

        /// public propaty name  :  ThisTimeFeePayNrml
        /// <summary>�x�����(�萔��)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(�萔��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeFeePayNrml
        {
            get { return _thisTimeFeePayNrml; }
            set { _thisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisPayNrml
        /// <summary>�x�����(�l��)�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����(�l��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDisPayNrml
        {
            get { return _thisTimeDisPayNrml; }
            set { _thisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>�d���`�[�����v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>����d�����z�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeStockPrice
        {
            get { return _thisTimeStockPrice; }
            set { _thisTimeStockPrice = value; }
        }

        /// public propaty name  :  ThisStckPricRgds
        /// <summary>����ԕi���z�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ԕi���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStckPricRgds
        {
            get { return _thisStckPricRgds; }
            set { _thisStckPricRgds = value; }
        }

        /// public propaty name  :  ThisStckPricDis
        /// <summary>����l�����z�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStckPricDis
        {
            get { return _thisStckPricDis; }
            set { _thisStckPricDis = value; }
        }

        /// public propaty name  :  OfsThisTimeStock
        /// <summary>���E�㍡��d�����z�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡��d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeStock
        {
            get { return _ofsThisTimeStock; }
            set { _ofsThisTimeStock = value; }
        }

        /// public propaty name  :  OfsThisStockTax
        /// <summary>���E�㍡��d������Ńv���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡��d������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisStockTax
        {
            get { return _ofsThisStockTax; }
            set { _ofsThisStockTax = value; }
        }

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>�d�����v�c���i�x���v�j�v���p�e�B</summary>
        /// <value>�x�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockTotalPayBalance
        {
            get { return _stockTotalPayBalance; }
            set { _stockTotalPayBalance = value; }
        }

        /// public propaty name  :  MonthLastTimeAccPay
        /// <summary>�O�񔃊|���z�v���p�e�B</summary>
        /// <value>�����p�@�O�����c</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񔃊|���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthLastTimeAccPay
        {
            get { return _monthLastTimeAccPay; }
            set { _monthLastTimeAccPay = value; }
        }

        /// public propaty name  :  MonthCashePayment
        /// <summary>�������(����)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthCashePayment
        {
            get { return _monthCashePayment; }
            set { _monthCashePayment = value; }
        }

        /// public propaty name  :  MonthTrfrPayment
        /// <summary>�������(�U��)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(�U��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthTrfrPayment
        {
            get { return _monthTrfrPayment; }
            set { _monthTrfrPayment = value; }
        }

        /// public propaty name  :  MonthCheckKPayment
        /// <summary>�������(���؎�)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(���؎�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthCheckKPayment
        {
            get { return _monthCheckKPayment; }
            set { _monthCheckKPayment = value; }
        }

        /// public propaty name  :  MonthDraftPayment
        /// <summary>�������(��`)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(��`)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthDraftPayment
        {
            get { return _monthDraftPayment; }
            set { _monthDraftPayment = value; }
        }

        /// public propaty name  :  MonthOffsetPayment
        /// <summary>�������(���E)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(���E)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthOffsetPayment
        {
            get { return _monthOffsetPayment; }
            set { _monthOffsetPayment = value; }
        }

        /// public propaty name  :  MonthFundtransferPayment
        /// <summary>�������(�����U��)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(�����U��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthFundtransferPayment
        {
            get { return _monthFundtransferPayment; }
            set { _monthFundtransferPayment = value; }
        }

        /// public propaty name  :  MonthEmoneyPayment
        /// <summary>�������(E-Money)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(E-Money)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthEmoneyPayment
        {
            get { return _monthEmoneyPayment; }
            set { _monthEmoneyPayment = value; }
        }

        /// public propaty name  :  MonthOtherPayment
        /// <summary>�������(���̑�)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(���̑�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthOtherPayment
        {
            get { return _monthOtherPayment; }
            set { _monthOtherPayment = value; }
        }

        /// public propaty name  :  MonthThisTimeFeePayNrml
        /// <summary>�������(�萔��)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(�萔��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthThisTimeFeePayNrml
        {
            get { return _monthThisTimeFeePayNrml; }
            set { _monthThisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  MonthThisTimeDisPayNrml
        /// <summary>�������(�l��)�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������(�l��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthThisTimeDisPayNrml
        {
            get { return _monthThisTimeDisPayNrml; }
            set { _monthThisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  MonthStockSlipCount
        /// <summary>�����d���`�[�����v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����d���`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MonthStockSlipCount
        {
            get { return _monthStockSlipCount; }
            set { _monthStockSlipCount = value; }
        }

        /// public propaty name  :  MonthThisTimeStockPrice
        /// <summary>��������d�����z�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthThisTimeStockPrice
        {
            get { return _monthThisTimeStockPrice; }
            set { _monthThisTimeStockPrice = value; }
        }

        /// public propaty name  :  MonthThisStckPricRgds
        /// <summary>��������ԕi���z�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������ԕi���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthThisStckPricRgds
        {
            get { return _monthThisStckPricRgds; }
            set { _monthThisStckPricRgds = value; }
        }

        /// public propaty name  :  MonthThisStckPricDis
        /// <summary>��������l�����z�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthThisStckPricDis
        {
            get { return _monthThisStckPricDis; }
            set { _monthThisStckPricDis = value; }
        }

        /// public propaty name  :  MonthOfsThisTimeStock
        /// <summary>�������E�㍡��d�����z�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������E�㍡��d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthOfsThisTimeStock
        {
            get { return _monthOfsThisTimeStock; }
            set { _monthOfsThisTimeStock = value; }
        }

        /// public propaty name  :  MonthOfsThisStockTax
        /// <summary>�������E�㍡��d������Ńv���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������E�㍡��d������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthOfsThisStockTax
        {
            get { return _monthOfsThisStockTax; }
            set { _monthOfsThisStockTax = value; }
        }

        /// public propaty name  :  MonthStckTtlAccPayBalance
        /// <summary>�����d�����v�c���i���|�v�j�v���p�e�B</summary>
        /// <value>�����p�@���ݔ��|�c��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����d�����v�c���i���|�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthStckTtlAccPayBalance
        {
            get { return _monthStckTtlAccPayBalance; }
            set { _monthStckTtlAccPayBalance = value; }
        }

        /// public propaty name  :  YearStockSlipCount
        /// <summary>�����d���`�[�����v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����d���`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 YearStockSlipCount
        {
            get { return _yearStockSlipCount; }
            set { _yearStockSlipCount = value; }
        }

        /// public propaty name  :  YearThisTimeStockPrice
        /// <summary>��������d�����z�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 YearThisTimeStockPrice
        {
            get { return _yearThisTimeStockPrice; }
            set { _yearThisTimeStockPrice = value; }
        }

        /// public propaty name  :  YearThisStckPricRgds
        /// <summary>��������ԕi���z�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������ԕi���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 YearThisStckPricRgds
        {
            get { return _yearThisStckPricRgds; }
            set { _yearThisStckPricRgds = value; }
        }

        /// public propaty name  :  YearThisStckPricDis
        /// <summary>��������l�����z�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 YearThisStckPricDis
        {
            get { return _yearThisStckPricDis; }
            set { _yearThisStckPricDis = value; }
        }

        /// public propaty name  :  YearOfsThisTimeStock
        /// <summary>�������E�㍡��d�����z�v���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������E�㍡��d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 YearOfsThisTimeStock
        {
            get { return _yearOfsThisTimeStock; }
            set { _yearOfsThisTimeStock = value; }
        }

        /// public propaty name  :  YearOfsThisStockTax
        /// <summary>�������E�㍡��d������Ńv���p�e�B</summary>
        /// <value>�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������E�㍡��d������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 YearOfsThisStockTax
        {
            get { return _yearOfsThisStockTax; }
            set { _yearOfsThisStockTax = value; }
        }


        /// <summary>
        /// �d���N�Ԏ��яƉ�(�c���Ɖ�)���o���ʃN���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuppYearResultAccPayWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultAccPayWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppYearResultAccPayWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SuppYearResultAccPayWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SuppYearResultAccPayWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SuppYearResultAccPayWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultAccPayWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SuppYearResultAccPayWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SuppYearResultAccPayWork || graph is ArrayList || graph is SuppYearResultAccPayWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SuppYearResultAccPayWork).FullName));

            if (graph != null && graph is SuppYearResultAccPayWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SuppYearResultAccPayWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SuppYearResultAccPayWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SuppYearResultAccPayWork[])graph).Length;
            }
            else if (graph is SuppYearResultAccPayWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�d��3��O�c���i�x���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl3TmBfBlPay
            //�d��2��O�c���i�x���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTtl2TmBfBlPay
            //�O��x�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimePayment
            //�x�����(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //CashePayment
            //�x�����(�U��)
            serInfo.MemberInfo.Add(typeof(Int64)); //TrfrPayment
            //�x�����(���؎�)
            serInfo.MemberInfo.Add(typeof(Int64)); //CheckKPayment
            //�x�����(��`)
            serInfo.MemberInfo.Add(typeof(Int64)); //DraftPayment
            //�x�����(���E)
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetPayment
            //�x�����(�����U��)
            serInfo.MemberInfo.Add(typeof(Int64)); //FundtransferPayment
            //�x�����(E-Money)
            serInfo.MemberInfo.Add(typeof(Int64)); //EmoneyPayment
            //�x�����(���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //OtherPayment
            //�x�����(�萔��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeePayNrml
            //�x�����(�l��)
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisPayNrml
            //�d���`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //����d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice
            //����ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricRgds
            //����l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisStckPricDis
            //���E�㍡��d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //���E�㍡��d�������
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //�d�����v�c���i�x���v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //StockTotalPayBalance
            //�O�񔃊|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthLastTimeAccPay
            //�������(����)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthCashePayment
            //�������(�U��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthTrfrPayment
            //�������(���؎�)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthCheckKPayment
            //�������(��`)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthDraftPayment
            //�������(���E)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthOffsetPayment
            //�������(�����U��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthFundtransferPayment
            //�������(E-Money)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthEmoneyPayment
            //�������(���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthOtherPayment
            //�������(�萔��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisTimeFeePayNrml
            //�������(�l��)
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisTimeDisPayNrml
            //�����d���`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthStockSlipCount
            //��������d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisTimeStockPrice
            //��������ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisStckPricRgds
            //��������l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthThisStckPricDis
            //�������E�㍡��d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthOfsThisTimeStock
            //�������E�㍡��d�������
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthOfsThisStockTax
            //�����d�����v�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //MonthStckTtlAccPayBalance
            //�����d���`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //YearStockSlipCount
            //��������d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //YearThisTimeStockPrice
            //��������ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //YearThisStckPricRgds
            //��������l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //YearThisStckPricDis
            //�������E�㍡��d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //YearOfsThisTimeStock
            //�������E�㍡��d�������
            serInfo.MemberInfo.Add(typeof(Int64)); //YearOfsThisStockTax


            serInfo.Serialize(writer, serInfo);
            if (graph is SuppYearResultAccPayWork)
            {
                SuppYearResultAccPayWork temp = (SuppYearResultAccPayWork)graph;

                SetSuppYearResultAccPayWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SuppYearResultAccPayWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SuppYearResultAccPayWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SuppYearResultAccPayWork temp in lst)
                {
                    SetSuppYearResultAccPayWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SuppYearResultAccPayWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  SuppYearResultAccPayWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultAccPayWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSuppYearResultAccPayWork(System.IO.BinaryWriter writer, SuppYearResultAccPayWork temp)
        {
            //�d��3��O�c���i�x���v�j
            writer.Write(temp.StockTtl3TmBfBlPay);
            //�d��2��O�c���i�x���v�j
            writer.Write(temp.StockTtl2TmBfBlPay);
            //�O��x�����z
            writer.Write(temp.LastTimePayment);
            //�x�����(����)
            writer.Write(temp.CashePayment);
            //�x�����(�U��)
            writer.Write(temp.TrfrPayment);
            //�x�����(���؎�)
            writer.Write(temp.CheckKPayment);
            //�x�����(��`)
            writer.Write(temp.DraftPayment);
            //�x�����(���E)
            writer.Write(temp.OffsetPayment);
            //�x�����(�����U��)
            writer.Write(temp.FundtransferPayment);
            //�x�����(E-Money)
            writer.Write(temp.EmoneyPayment);
            //�x�����(���̑�)
            writer.Write(temp.OtherPayment);
            //�x�����(�萔��)
            writer.Write(temp.ThisTimeFeePayNrml);
            //�x�����(�l��)
            writer.Write(temp.ThisTimeDisPayNrml);
            //�d���`�[����
            writer.Write(temp.StockSlipCount);
            //����d�����z
            writer.Write(temp.ThisTimeStockPrice);
            //����ԕi���z
            writer.Write(temp.ThisStckPricRgds);
            //����l�����z
            writer.Write(temp.ThisStckPricDis);
            //���E�㍡��d�����z
            writer.Write(temp.OfsThisTimeStock);
            //���E�㍡��d�������
            writer.Write(temp.OfsThisStockTax);
            //�d�����v�c���i�x���v�j
            writer.Write(temp.StockTotalPayBalance);
            //�O�񔃊|���z
            writer.Write(temp.MonthLastTimeAccPay);
            //�������(����)
            writer.Write(temp.MonthCashePayment);
            //�������(�U��)
            writer.Write(temp.MonthTrfrPayment);
            //�������(���؎�)
            writer.Write(temp.MonthCheckKPayment);
            //�������(��`)
            writer.Write(temp.MonthDraftPayment);
            //�������(���E)
            writer.Write(temp.MonthOffsetPayment);
            //�������(�����U��)
            writer.Write(temp.MonthFundtransferPayment);
            //�������(E-Money)
            writer.Write(temp.MonthEmoneyPayment);
            //�������(���̑�)
            writer.Write(temp.MonthOtherPayment);
            //�������(�萔��)
            writer.Write(temp.MonthThisTimeFeePayNrml);
            //�������(�l��)
            writer.Write(temp.MonthThisTimeDisPayNrml);
            //�����d���`�[����
            writer.Write(temp.MonthStockSlipCount);
            //��������d�����z
            writer.Write(temp.MonthThisTimeStockPrice);
            //��������ԕi���z
            writer.Write(temp.MonthThisStckPricRgds);
            //��������l�����z
            writer.Write(temp.MonthThisStckPricDis);
            //�������E�㍡��d�����z
            writer.Write(temp.MonthOfsThisTimeStock);
            //�������E�㍡��d�������
            writer.Write(temp.MonthOfsThisStockTax);
            //�����d�����v�c���i���|�v�j
            writer.Write(temp.MonthStckTtlAccPayBalance);
            //�����d���`�[����
            writer.Write(temp.YearStockSlipCount);
            //��������d�����z
            writer.Write(temp.YearThisTimeStockPrice);
            //��������ԕi���z
            writer.Write(temp.YearThisStckPricRgds);
            //��������l�����z
            writer.Write(temp.YearThisStckPricDis);
            //�������E�㍡��d�����z
            writer.Write(temp.YearOfsThisTimeStock);
            //�������E�㍡��d�������
            writer.Write(temp.YearOfsThisStockTax);

        }

        /// <summary>
        ///  SuppYearResultAccPayWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SuppYearResultAccPayWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultAccPayWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SuppYearResultAccPayWork GetSuppYearResultAccPayWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SuppYearResultAccPayWork temp = new SuppYearResultAccPayWork();

            //�d��3��O�c���i�x���v�j
            temp.StockTtl3TmBfBlPay = reader.ReadInt64();
            //�d��2��O�c���i�x���v�j
            temp.StockTtl2TmBfBlPay = reader.ReadInt64();
            //�O��x�����z
            temp.LastTimePayment = reader.ReadInt64();
            //�x�����(����)
            temp.CashePayment = reader.ReadInt64();
            //�x�����(�U��)
            temp.TrfrPayment = reader.ReadInt64();
            //�x�����(���؎�)
            temp.CheckKPayment = reader.ReadInt64();
            //�x�����(��`)
            temp.DraftPayment = reader.ReadInt64();
            //�x�����(���E)
            temp.OffsetPayment = reader.ReadInt64();
            //�x�����(�����U��)
            temp.FundtransferPayment = reader.ReadInt64();
            //�x�����(E-Money)
            temp.EmoneyPayment = reader.ReadInt64();
            //�x�����(���̑�)
            temp.OtherPayment = reader.ReadInt64();
            //�x�����(�萔��)
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //�x�����(�l��)
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //�d���`�[����
            temp.StockSlipCount = reader.ReadInt32();
            //����d�����z
            temp.ThisTimeStockPrice = reader.ReadInt64();
            //����ԕi���z
            temp.ThisStckPricRgds = reader.ReadInt64();
            //����l�����z
            temp.ThisStckPricDis = reader.ReadInt64();
            //���E�㍡��d�����z
            temp.OfsThisTimeStock = reader.ReadInt64();
            //���E�㍡��d�������
            temp.OfsThisStockTax = reader.ReadInt64();
            //�d�����v�c���i�x���v�j
            temp.StockTotalPayBalance = reader.ReadInt64();
            //�O�񔃊|���z
            temp.MonthLastTimeAccPay = reader.ReadInt64();
            //�������(����)
            temp.MonthCashePayment = reader.ReadInt64();
            //�������(�U��)
            temp.MonthTrfrPayment = reader.ReadInt64();
            //�������(���؎�)
            temp.MonthCheckKPayment = reader.ReadInt64();
            //�������(��`)
            temp.MonthDraftPayment = reader.ReadInt64();
            //�������(���E)
            temp.MonthOffsetPayment = reader.ReadInt64();
            //�������(�����U��)
            temp.MonthFundtransferPayment = reader.ReadInt64();
            //�������(E-Money)
            temp.MonthEmoneyPayment = reader.ReadInt64();
            //�������(���̑�)
            temp.MonthOtherPayment = reader.ReadInt64();
            //�������(�萔��)
            temp.MonthThisTimeFeePayNrml = reader.ReadInt64();
            //�������(�l��)
            temp.MonthThisTimeDisPayNrml = reader.ReadInt64();
            //�����d���`�[����
            temp.MonthStockSlipCount = reader.ReadInt32();
            //��������d�����z
            temp.MonthThisTimeStockPrice = reader.ReadInt64();
            //��������ԕi���z
            temp.MonthThisStckPricRgds = reader.ReadInt64();
            //��������l�����z
            temp.MonthThisStckPricDis = reader.ReadInt64();
            //�������E�㍡��d�����z
            temp.MonthOfsThisTimeStock = reader.ReadInt64();
            //�������E�㍡��d�������
            temp.MonthOfsThisStockTax = reader.ReadInt64();
            //�����d�����v�c���i���|�v�j
            temp.MonthStckTtlAccPayBalance = reader.ReadInt64();
            //�����d���`�[����
            temp.YearStockSlipCount = reader.ReadInt32();
            //��������d�����z
            temp.YearThisTimeStockPrice = reader.ReadInt64();
            //��������ԕi���z
            temp.YearThisStckPricRgds = reader.ReadInt64();
            //��������l�����z
            temp.YearThisStckPricDis = reader.ReadInt64();
            //�������E�㍡��d�����z
            temp.YearOfsThisTimeStock = reader.ReadInt64();
            //�������E�㍡��d�������
            temp.YearOfsThisStockTax = reader.ReadInt64();


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
        /// <returns>SuppYearResultAccPayWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultAccPayWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SuppYearResultAccPayWork temp = GetSuppYearResultAccPayWork(reader, serInfo);
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
                    retValue = (SuppYearResultAccPayWork[])lst.ToArray(typeof(SuppYearResultAccPayWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}
