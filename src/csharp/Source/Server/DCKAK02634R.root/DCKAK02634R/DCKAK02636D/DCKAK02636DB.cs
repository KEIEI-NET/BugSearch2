using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   AccPaymentListResultWork
    /// <summary>
    ///                      ���|�c���ꗗ�\���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���|�c���ꗗ�\���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :   3H ������</br>
    /// <br>Date	         :   2020/03/02</br>
    /// <br>Update Note      :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer       :   3H ����</br>
    /// <br>Date             :   2022/10/09</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class AccPaymentListResultWork
    {
        /// <summary>���_�R�[�h</summary>
        /// <remarks>�v�㋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_����</summary>
        /// <remarks>���_�K�C�h����</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�x����R�[�h</summary>
        private Int32 _payeeCode;

        /// <summary>�x���旪��</summary>
        private string _payeeSnm = "";

        /// <summary>�O�����|�c</summary>
        /// <remarks>�O�񔃊|���z</remarks>
        private Int64 _lastTimeAccPay;

        /// <summary>�����x��</summary>
        /// <remarks>����x�����z�i�ʏ�x���j</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>�J�z�z</summary>
        /// <remarks>����J�z�c���i���|�v�j</remarks>
        private Int64 _thisTimeTtlBlcAcPay;

        /// <summary>�d���z</summary>
        /// <remarks>���E�㍡��d�����z</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>�ԕi�l��</summary>
        /// <remarks>����ԕi���z+����l�����z</remarks>
        private Int64 _thisRgdsDisPric;

        /// <summary>�����</summary>
        /// <remarks>���E�㍡��d�������</remarks>
        private Int64 _ofsThisStockTax;

        /// <summary>�������c��</summary>
        /// <remarks>�d�����v�c��</remarks>
        private Int64 _stckTtlAccPayBalance;

        /// <summary>����</summary>
        /// <remarks>�d���`�[����</remarks>
        private Int32 _stockSlipCount;

        /// <summary>�萔��</summary>
        /// <remarks>����萔���z�i�ʏ�x���j</remarks>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>�l��</summary>
        /// <remarks>����l���z�i�ʏ�x���j</remarks>
        private Int64 _thisTimeDisPayNrml;

        /// <summary>����</summary>
        /// <remarks>����R�[�h�F�����̎x�����z</remarks>
        private Int64 _cashPayment;

        /// <summary>�U��</summary>
        /// <remarks>����R�[�h�F�U���̎x�����z</remarks>
        private Int64 _trfrPayment;

        /// <summary>���؎�</summary>
        /// <remarks>����R�[�h�F���؎�̎x�����z</remarks>
        private Int64 _checkPayment;

        /// <summary>��`</summary>
        /// <remarks>����R�[�h�F��`�̎x�����z</remarks>
        private Int64 _draftPayment;

        /// <summary>���E</summary>
        /// <remarks>����R�[�h�F���E�̎x�����z</remarks>
        private Int64 _offsetPayment;

        /// <summary>�����U��</summary>
        /// <remarks>����R�[�h�F�����U�ւ̎x�����z</remarks>
        private Int64 _fundTransferPayment;

        /// <summary>���̑�</summary>
        /// <remarks>����R�[�h�F���̑��̎x�����z</remarks>
        private Int64 _othsPayment;

        /// <summary>����d�����z</summary>
        /// <remarks>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</remarks>
        private Int64 _thisTimeStockPrice;

        // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
        /// <summary>�ŗ�1�^�C�g��</summary>
        /// <remarks>�ŗ�1�^�C�g��</remarks>
        private string _titleTaxRate1 = string.Empty;

        /// <summary>�ŗ�2�^�C�g��</summary>
        /// <remarks>�ŗ�2�^�C�g��</remarks>
        private string _titleTaxRate2 = string.Empty;

        /// <summary>�d���z(�v�ŗ�1)</summary>
        /// <remarks>�d���z(�v�ŗ�1)</remarks>
        private Int64 _totalThisTimeStockPriceTaxRate1;

        /// <summary>�d���z(�v�ŗ�2)</summary>
        /// <remarks>�d���z(�v�ŗ�2)</remarks>
        private Int64 _totalThisTimeStockPriceTaxRate2;

        /// <summary>�d���z(�v���̑�)</summary>
        /// <remarks>�d���z(�v���̑�)</remarks>
        private Int64 _totalThisTimeStockPriceOther;

        /// <summary>�ԕi�l��(�v�ŗ�1)</summary>
        /// <remarks>�ԕi�l��(�v�ŗ�1)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate1;

        /// <summary>�ԕi�l��(�v�ŗ�2)</summary>
        /// <remarks>�ԕi�l��(�v�ŗ�2)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate2;

        /// <summary>�ԕi�l��(�v���̑�)</summary>
        /// <remarks>�ԕi�l��(�v���̑�)</remarks>
        private Int64 _totalThisRgdsDisPricOther;

        /// <summary>���d���z(�v�ŗ�1)</summary>
        /// <remarks>���d���z(�v�ŗ�1)</remarks>
        private Int64 _totalPureStockTaxRate1;

        /// <summary>���d���z(�v�ŗ�2)</summary>
        /// <remarks>���d���z(�v�ŗ�2)</remarks>
        private Int64 _totalPureStockTaxRate2;

        /// <summary>���d���z(�v���̑�)</summary>
        /// <remarks>���d���z(�v���̑�)</remarks>
        private Int64 _totalPureStockOther;

        /// <summary>�����(�v�ŗ�1)</summary>
        /// <remarks>�����(�v�ŗ�1)</remarks>
        private Int64 _totalStockPricTaxTaxRate1;

        /// <summary>�����(�v�ŗ�2)</summary>
        /// <remarks>�����(�v�ŗ�2)</remarks>
        private Int64 _totalStockPricTaxTaxRate2;

        /// <summary>�����(�v���̑�)</summary>
        /// <remarks>�����(�v���̑�)</remarks>
        private Int64 _totalStockPricTaxOther;

        /// <summary>�������v(�v�ŗ�1)</summary>
        /// <remarks>�������v(�v�ŗ�1)</remarks>
        private Int64 _totalStckTtlAccPayBalanceTaxRate1;

        /// <summary>�������v(�v�ŗ�2)</summary>
        /// <remarks>�������v(�v�ŗ�2)</remarks>
        private Int64 _totalStckTtlAccPayBalanceTaxRate2;

        /// <summary>�������v(�v���̑�)</summary>
        /// <remarks>�������v(�v���̑�)</remarks>
        private Int64 _totalStckTtlAccPayBalanceOther;

        /// <summary>����(�v�ŗ�1)</summary>
        /// <remarks>����(�v�ŗ�1)</remarks>
        private Int32 _totalStockSlipCountTaxRate1;

        /// <summary>����(�v�ŗ�2)</summary>
        /// <remarks>����(�v�ŗ�2)</remarks>
        private Int32 _totalStockSlipCountTaxRate2;

        /// <summary>����(�v���̑�)</summary>
        /// <remarks>����(�v���̑�)</remarks>
        private Int32 _totalStockSlipCountOther;
        // --- ADD END 3H ������ 2020/03/02 ----------<<<<<

        // --- ADD START 3H ���� 2022/10/09 ----->>>>>
        /// <summary>�d���z(�v��ې�)</summary>
        /// <remarks>�d���z(�v��ې�)</remarks>
        private Int64 _totalThisTimeStockPriceTaxFree;

        /// <summary>�ԕi�l��(�v��ې�)</summary>
        /// <remarks>�ԕi�l��(�v��ې�)</remarks>
        private Int64 _totalThisRgdsDisPricTaxFree;

        /// <summary>���d���z(�v��ې�)</summary>
        /// <remarks>���d���z(�v��ې�)</remarks>
        private Int64 _totalPureStockTaxFree;

        /// <summary>�����(�v��ې�)</summary>
        /// <remarks>�����(�v��ې�)</remarks>
        private Int64 _totalStockPricTaxTaxFree;

        /// <summary>�������v(�v��ې�)</summary>
        /// <remarks>�������v(�v��ې�)</remarks>
        private Int64 _totalStckTtlAccPayBalanceTaxFree;

        /// <summary>����(�v��ې�)</summary>
        /// <remarks>����(�v��ې�)</remarks>
        private Int32 _totalStockSlipCountTaxFree;
        // --- ADD END 3H ���� 2022/10/09 -----<<<<<

        /// public propaty name  :  AddUpSecCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�v�㋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_���̃v���p�e�B</summary>
        /// <value>���_�K�C�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  LastTimeAccPay
        /// <summary>�O�����|�c�v���p�e�B</summary>
        /// <value>�O�񔃊|���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�����|�c�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastTimeAccPay
        {
            get { return _lastTimeAccPay; }
            set { _lastTimeAccPay = value; }
        }

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>�����x���v���p�e�B</summary>
        /// <value>����x�����z�i�ʏ�x���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimePayNrml
        {
            get { return _thisTimePayNrml; }
            set { _thisTimePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcAcPay
        /// <summary>�J�z�z�v���p�e�B</summary>
        /// <value>����J�z�c���i���|�v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�z�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcAcPay
        {
            get { return _thisTimeTtlBlcAcPay; }
            set { _thisTimeTtlBlcAcPay = value; }
        }

        /// public propaty name  :  OfsThisTimeStock
        /// <summary>�d���z�v���p�e�B</summary>
        /// <value>���E�㍡��d�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeStock
        {
            get { return _ofsThisTimeStock; }
            set { _ofsThisTimeStock = value; }
        }

        /// public propaty name  :  ThisRgdsDisPric
        /// <summary>�ԕi�l���v���p�e�B</summary>
        /// <value>����ԕi���z+����l�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisRgdsDisPric
        {
            get { return _thisRgdsDisPric; }
            set { _thisRgdsDisPric = value; }
        }

        /// public propaty name  :  OfsThisStockTax
        /// <summary>����Ńv���p�e�B</summary>
        /// <value>���E�㍡��d�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisStockTax
        {
            get { return _ofsThisStockTax; }
            set { _ofsThisStockTax = value; }
        }

        /// public propaty name  :  StckTtlAccPayBalance
        /// <summary>�������c���v���p�e�B</summary>
        /// <value>�d�����v�c��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StckTtlAccPayBalance
        {
            get { return _stckTtlAccPayBalance; }
            set { _stckTtlAccPayBalance = value; }
        }

        /// public propaty name  :  StockSlipCount
        /// <summary>�����v���p�e�B</summary>
        /// <value>�d���`�[����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSlipCount
        {
            get { return _stockSlipCount; }
            set { _stockSlipCount = value; }
        }

        /// public propaty name  :  ThisTimeFeePayNrml
        /// <summary>�萔���v���p�e�B</summary>
        /// <value>����萔���z�i�ʏ�x���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeFeePayNrml
        {
            get { return _thisTimeFeePayNrml; }
            set { _thisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisPayNrml
        /// <summary>�l���v���p�e�B</summary>
        /// <value>����l���z�i�ʏ�x���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDisPayNrml
        {
            get { return _thisTimeDisPayNrml; }
            set { _thisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  CashPayment
        /// <summary>�����v���p�e�B</summary>
        /// <value>����R�[�h�F�����̎x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CashPayment
        {
            get { return _cashPayment; }
            set { _cashPayment = value; }
        }

        /// public propaty name  :  TrfrPayment
        /// <summary>�U���v���p�e�B</summary>
        /// <value>����R�[�h�F�U���̎x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �U���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TrfrPayment
        {
            get { return _trfrPayment; }
            set { _trfrPayment = value; }
        }

        /// public propaty name  :  CheckPayment
        /// <summary>���؎�v���p�e�B</summary>
        /// <value>����R�[�h�F���؎�̎x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���؎�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CheckPayment
        {
            get { return _checkPayment; }
            set { _checkPayment = value; }
        }

        /// public propaty name  :  DraftPayment
        /// <summary>��`�v���p�e�B</summary>
        /// <value>����R�[�h�F��`�̎x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DraftPayment
        {
            get { return _draftPayment; }
            set { _draftPayment = value; }
        }

        /// public propaty name  :  OffsetPayment
        /// <summary>���E�v���p�e�B</summary>
        /// <value>����R�[�h�F���E�̎x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OffsetPayment
        {
            get { return _offsetPayment; }
            set { _offsetPayment = value; }
        }

        /// public propaty name  :  FundTransferPayment
        /// <summary>�����U�փv���p�e�B</summary>
        /// <value>����R�[�h�F�����U�ւ̎x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����U�փv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FundTransferPayment
        {
            get { return _fundTransferPayment; }
            set { _fundTransferPayment = value; }
        }

        /// public propaty name  :  OthsPayment
        /// <summary>���̑��v���p�e�B</summary>
        /// <value>����R�[�h�F���̑��̎x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̑��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OthsPayment
        {
            get { return _othsPayment; }
            set { _othsPayment = value; }
        }

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>����d�����z�v���p�e�B</summary>
        /// <value>�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</value>
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

        // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
        /// public propaty name  :  TitleTaxRate1
        /// <summary>�ŗ�1�^�C�g��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1�^�C�g��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleTaxRate1
        {
            get { return _titleTaxRate1; }
            set { _titleTaxRate1 = value; }
        }

        /// public propaty name  :  TitleTaxRate2
        /// <summary>�ŗ�2�^�C�g��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2�^�C�g��</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TitleTaxRate2
        {
            get { return _titleTaxRate2; }
            set { _titleTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeStockPriceTaxRate1
        /// <summary>�d���z(�v�ŗ�1) </summary>
        /// <value>�d���z(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���z(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeStockPriceTaxRate1
        {
            get { return _totalThisTimeStockPriceTaxRate1; }
            set { _totalThisTimeStockPriceTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeStockPriceTaxRate2
        /// <summary>�d���z(�v�ŗ�2) </summary>
        /// <value>�d���z(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���z(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeStockPriceTaxRate2
        {
            get { return _totalThisTimeStockPriceTaxRate2; }
            set { _totalThisTimeStockPriceTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeStockPriceOther
        /// <summary>�d���z(�v���̑�) </summary>
        /// <value>�d���z(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���z(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeStockPriceOther
        {
            get { return _totalThisTimeStockPriceOther; }
            set { _totalThisTimeStockPriceOther = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxRate1
        /// <summary>�ԕi�l��(�v�ŗ�1) </summary>
        /// <value>�ԕi�l��(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxRate1
        {
            get { return _totalThisRgdsDisPricTaxRate1; }
            set { _totalThisRgdsDisPricTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxRate2
        /// <summary>�ԕi�l��(�v�ŗ�2) </summary>
        /// <value>�ԕi�l��(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxRate2
        {
            get { return _totalThisRgdsDisPricTaxRate2; }
            set { _totalThisRgdsDisPricTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricOther
        /// <summary>�ԕi�l��(�v���̑�) </summary>
        /// <value>�ԕi�l��(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricOther
        {
            get { return _totalThisRgdsDisPricOther; }
            set { _totalThisRgdsDisPricOther = value; }
        }

        /// public propaty name  :  TotalPureStockTaxRate1
        /// <summary>���d���z(�v�ŗ�1) </summary>
        /// <value>���d���z(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���z(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureStockTaxRate1
        {
            get { return _totalPureStockTaxRate1; }
            set { _totalPureStockTaxRate1 = value; }
        }

        /// public propaty name  :  TotalPureStockTaxRate2
        /// <summary>���d���z(�v�ŗ�2) </summary>
        /// <value>���d���z(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���z(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureStockTaxRate2
        {
            get { return _totalPureStockTaxRate2; }
            set { _totalPureStockTaxRate2 = value; }
        }

        /// public propaty name  :  TotalPureStockOther
        /// <summary>���d���z(�v���̑�) </summary>
        /// <value>���d���z(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���z(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureStockOther
        {
            get { return _totalPureStockOther; }
            set { _totalPureStockOther = value; }
        }

        /// public propaty name  :  TotalStockPricTaxTaxRate1
        /// <summary>�����(�v�ŗ�1) </summary>
        /// <value>�����(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalStockPricTaxTaxRate1
        {
            get { return _totalStockPricTaxTaxRate1; }
            set { _totalStockPricTaxTaxRate1 = value; }
        }

        /// public propaty name  :  TotalStockPricTaxTaxRate2
        /// <summary>�����(�v�ŗ�2) </summary>
        /// <value>�����(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalStockPricTaxTaxRate2
        {
            get { return _totalStockPricTaxTaxRate2; }
            set { _totalStockPricTaxTaxRate2 = value; }
        }

        /// public propaty name  :  TotalStockPricTaxOther
        /// <summary>�����(�v���̑�) </summary>
        /// <value>�����(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalStockPricTaxOther
        {
            get { return _totalStockPricTaxOther; }
            set { _totalStockPricTaxOther = value; }
        }

        /// public propaty name  :  TotalStckTtlAccPayBalanceTaxRate1
        /// <summary>�������v(�v�ŗ�1) </summary>
        /// <value>�������v(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalStckTtlAccPayBalanceTaxRate1
        {
            get { return _totalStckTtlAccPayBalanceTaxRate1; }
            set { _totalStckTtlAccPayBalanceTaxRate1 = value; }
        }

        /// public propaty name  :  TotalStckTtlAccPayBalanceTaxRate2
        /// <summary>�������v(�v�ŗ�2) </summary>
        /// <value>�������v(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalStckTtlAccPayBalanceTaxRate2
        {
            get { return _totalStckTtlAccPayBalanceTaxRate2; }
            set { _totalStckTtlAccPayBalanceTaxRate2 = value; }
        }

        /// public propaty name  :  TotalStckTtlAccPayBalanceOther
        /// <summary>�������v(�v���̑�) </summary>
        /// <value>�������v(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalStckTtlAccPayBalanceOther
        {
            get { return _totalStckTtlAccPayBalanceOther; }
            set { _totalStckTtlAccPayBalanceOther = value; }
        }

        /// public propaty name  :  TotalStockSlipCountTaxRate1
        /// <summary>����(�v�ŗ�1) </summary>
        /// <value>����(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalStockSlipCountTaxRate1
        {
            get { return _totalStockSlipCountTaxRate1; }
            set { _totalStockSlipCountTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate2
        /// <summary>����(�v�ŗ�2) </summary>
        /// <value>����(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalStockSlipCountTaxRate2
        {
            get { return _totalStockSlipCountTaxRate2; }
            set { _totalStockSlipCountTaxRate2 = value; }
        }

        /// public propaty name  :  TotalStockSlipCountOther
        /// <summary>����(�v���̑�) </summary>
        /// <value>����(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalStockSlipCountOther
        {
            get { return _totalStockSlipCountOther; }
            set { _totalStockSlipCountOther = value; }
        }
        // --- ADD END 3H ������ 2020/03/02 ----------<<<<<

        // --- ADD START 3H ���� 2022/10/09 ----->>>>>
        /// public propaty name  :  TotalThisTimeStockPriceTaxFree
        /// <summary>�d���z(�v��ې�) </summary>
        /// <value>�d���z(�v��ې�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���z(�v��ې�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeStockPriceTaxFree
        {
            get { return _totalThisTimeStockPriceTaxFree; }
            set { _totalThisTimeStockPriceTaxFree = value; }
        }

        /// public propaty name  :  TotalThisRgdsDisPricTaxFree
        /// <summary>�ԕi�l��(�v��ې�) </summary>
        /// <value>�ԕi�l��(�v��ې�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(�v��ې�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxFree
        {
            get { return _totalThisRgdsDisPricTaxFree; }
            set { _totalThisRgdsDisPricTaxFree = value; }
        }

        /// public propaty name  :  TotalPureStockTaxFree
        /// <summary>���d���z(�v��ې�) </summary>
        /// <value>���d���z(�v��ې�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���d���z(�v��ې�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureStockTaxFree
        {
            get { return _totalPureStockTaxFree; }
            set { _totalPureStockTaxFree = value; }
        }

        /// public propaty name  :  TotalStockPricTaxTaxFree
        /// <summary>�����(�v��ې�) </summary>
        /// <value>�����(�v��ې�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v��ې�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalStockPricTaxTaxFree
        {
            get { return _totalStockPricTaxTaxFree; }
            set { _totalStockPricTaxTaxFree = value; }
        }

        /// public propaty name  :  TotalStckTtlAccPayBalanceTaxFree
        /// <summary>�������v(�v��ې�) </summary>
        /// <value>�������v(�v��ې�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v��ې�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalStckTtlAccPayBalanceTaxFree
        {
            get { return _totalStckTtlAccPayBalanceTaxFree; }
            set { _totalStckTtlAccPayBalanceTaxFree = value; }
        }

        /// public propaty name  :  TotalStockSlipCountTaxFree
        /// <summary>����(�v��ې�) </summary>
        /// <value>����(�v��ې�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v��ې�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalStockSlipCountTaxFree
        {
            get { return _totalStockSlipCountTaxFree; }
            set { _totalStockSlipCountTaxFree = value; }
        }
        // --- ADD END 3H ���� 2022/10/09 -----<<<<<

        /// <summary>
        /// ���|�c���ꗗ�\���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>AccPaymentListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccPaymentListResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AccPaymentListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>AccPaymentListResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   AccPaymentListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :   3H ������</br>
    /// <br>Date	         :   2020/03/02</br>
    /// <br>UpdateNote       :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer       :   3H ����</br>
    /// <br>Date             :   2022/10/09</br>
    /// </remarks>
    public class AccPaymentListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccPaymentListResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer       :   3H ������</br>
        /// <br>Date	         :   2020/03/02</br>
        /// <br>UpdateNote       :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer       :   3H ����</br>
        /// <br>Date             :   2022/10/09</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AccPaymentListResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AccPaymentListResultWork || graph is ArrayList || graph is AccPaymentListResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(AccPaymentListResultWork).FullName));

            if (graph != null && graph is AccPaymentListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AccPaymentListResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AccPaymentListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AccPaymentListResultWork[])graph).Length;
            }
            else if (graph is AccPaymentListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�O�����|�c
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccPay
            //�����x��
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimePayNrml
            //�J�z�z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcPay
            //�d���z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeStock
            //�ԕi�l��
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisRgdsDisPric
            //�����
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisStockTax
            //�������c��
            serInfo.MemberInfo.Add(typeof(Int64)); //StckTtlAccPayBalance
            //����
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSlipCount
            //�萔��
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeePayNrml
            //�l��
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisPayNrml
            //����
            serInfo.MemberInfo.Add(typeof(Int64)); //CashPayment
            //�U��
            serInfo.MemberInfo.Add(typeof(Int64)); //TrfrPayment
            //���؎�
            serInfo.MemberInfo.Add(typeof(Int64)); //CheckPayment
            //��`
            serInfo.MemberInfo.Add(typeof(Int64)); //DraftPayment
            //���E
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetPayment
            //�����U��
            serInfo.MemberInfo.Add(typeof(Int64)); //FundTransferPayment
            //���̑�
            serInfo.MemberInfo.Add(typeof(Int64)); //OthsPayment
            //����d�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeStockPrice

            // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
            // �d���z(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeStockPriceTaxRate1
            // �d���z(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeStockPriceTaxRate2
            // �d���z(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeStockPriceOther
            // �ԕi�l��(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate1
            // �ԕi�l��(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate2
            // �ԕi�l��(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricOther
            // ���d���z(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureStockTaxRate1
            // ���d���z(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureStockTaxRate2
            // ���d���z(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureStockOther
            // �����(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStockPricTaxTaxRate1
            // �����(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStockPricTaxTaxRate2
            // �����(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStockPricTaxOther
            // �������v(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStckTtlAccPayBalanceTaxRate1
            // �������v(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStckTtlAccPayBalanceTaxRate2
            // �������v(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStckTtlAccPayBalanceOther
            // ����(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalStockSlipCountTaxRate1
            // ����(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalStockSlipCountTaxRate2
            // ����(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalStockSlipCountOther
            // �ŗ�1�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate1
            // �ŗ�2�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate2
            // --- ADD END 3H ������ 2020/03/02 ----------<<<<<

            // --- ADD START 3H ���� 2022/10/09 ----->>>>>
            // �d���z(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeStockPriceTaxFree
            // �ԕi�l��(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxFree
            // ���d���z(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureStockTaxFree
            // �����(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStockPricTaxTaxFree
            // �������v(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalStckTtlAccPayBalanceTaxFree
            // ����(�v��ې�)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalStockSlipCountTaxFree
            // --- ADD END 3H ���� 2022/10/09 -----<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is AccPaymentListResultWork)
            {
                AccPaymentListResultWork temp = (AccPaymentListResultWork)graph;

                SetAccPaymentListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AccPaymentListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AccPaymentListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AccPaymentListResultWork temp in lst)
                {
                    SetAccPaymentListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AccPaymentListResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 22; // DEL 3H ������ 2020/03/02
        //private const int currentMemberCount = 42; // ADD 3H ������ 2020/03/02 // DEL 3H ���� 2022/10/09
        private const int currentMemberCount = 48;   // ADD 3H ���� 2022/10/09

        /// <summary>
        ///  AccPaymentListResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccPaymentListResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer       :   3H ������</br>
        /// <br>Date	         :   2020/03/02</br>
        /// <br>UpdateNote       :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer       :   3H ����</br>
        /// <br>Date             :   2022/10/09</br>
        /// </remarks>
        private void SetAccPaymentListResultWork(System.IO.BinaryWriter writer, AccPaymentListResultWork temp)
        {
            //���_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_����
            writer.Write(temp.SectionGuideSnm);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�O�����|�c
            writer.Write(temp.LastTimeAccPay);
            //�����x��
            writer.Write(temp.ThisTimePayNrml);
            //�J�z�z
            writer.Write(temp.ThisTimeTtlBlcAcPay);
            //�d���z
            writer.Write(temp.OfsThisTimeStock);
            //�ԕi�l��
            writer.Write(temp.ThisRgdsDisPric);
            //�����
            writer.Write(temp.OfsThisStockTax);
            //�������c��
            writer.Write(temp.StckTtlAccPayBalance);
            //����
            writer.Write(temp.StockSlipCount);
            //�萔��
            writer.Write(temp.ThisTimeFeePayNrml);
            //�l��
            writer.Write(temp.ThisTimeDisPayNrml);
            //����
            writer.Write(temp.CashPayment);
            //�U��
            writer.Write(temp.TrfrPayment);
            //���؎�
            writer.Write(temp.CheckPayment);
            //��`
            writer.Write(temp.DraftPayment);
            //���E
            writer.Write(temp.OffsetPayment);
            //�����U��
            writer.Write(temp.FundTransferPayment);
            //���̑�
            writer.Write(temp.OthsPayment);
            //����d�����z
            writer.Write(temp.ThisTimeStockPrice);
            // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
            //�d���z(�v�ŗ�1)
            writer.Write(temp.TotalThisTimeStockPriceTaxRate1);
            //�d���z(�v�ŗ�2)
            writer.Write(temp.TotalThisTimeStockPriceTaxRate2);
            //�d���z(�v���̑�)
            writer.Write(temp.TotalThisTimeStockPriceOther);
            //�ԕi�l��(�v�ŗ�1)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate1);
            //�ԕi�l��(�v�ŗ�2)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate2);
            //�ԕi�l��(�v���̑�)
            writer.Write(temp.TotalThisRgdsDisPricOther);
            //���d���z(�v�ŗ�1)
            writer.Write(temp.TotalPureStockTaxRate1);
            //���d���z(�v�ŗ�2)
            writer.Write(temp.TotalPureStockTaxRate2);
            //���d���z(�v���̑�)
            writer.Write(temp.TotalPureStockOther);
            //�����(�v�ŗ�1)
            writer.Write(temp.TotalStockPricTaxTaxRate1);
            //�����(�v�ŗ�2)
            writer.Write(temp.TotalStockPricTaxTaxRate2);
            //�����(�v���̑�)
            writer.Write(temp.TotalStockPricTaxOther);
            //�������v(�v�ŗ�1)
            writer.Write(temp.TotalStckTtlAccPayBalanceTaxRate1);
            //�������v(�v�ŗ�2)
            writer.Write(temp.TotalStckTtlAccPayBalanceTaxRate2);
            //�������v(�v���̑�)
            writer.Write(temp.TotalStckTtlAccPayBalanceOther);
            //����(�v�ŗ�1)
            writer.Write(temp.TotalStockSlipCountTaxRate1);
            //����(�v�ŗ�2)
            writer.Write(temp.TotalStockSlipCountTaxRate2);
            //����(�v���̑�)
            writer.Write(temp.TotalStockSlipCountOther);
            //�ŗ�1�^�C�g��
            writer.Write(temp.TitleTaxRate1);
            //�ŗ�2�^�C�g��
            writer.Write(temp.TitleTaxRate2);
            // --- ADD END 3H ������ 2020/03/02 ----------<<<<<
            // --- ADD START 3H ���� 2022/10/09 ----->>>>>
            // �d���z(�v��ې�)
            writer.Write(temp.TotalThisTimeStockPriceTaxFree);
            // �ԕi�l��(�v��ې�)
            writer.Write(temp.TotalThisRgdsDisPricTaxFree);
            // ���d���z(�v��ې�)
            writer.Write(temp.TotalPureStockTaxFree);
            // �����(�v��ې�)
            writer.Write(temp.TotalStockPricTaxTaxFree);
            // �������v(�v��ې�)
            writer.Write(temp.TotalStckTtlAccPayBalanceTaxFree);
            // ����(�v��ې�)
            writer.Write(temp.TotalStockSlipCountTaxFree);
            // --- ADD END 3H ���� 2022/10/09 -----<<<<<

        }

        /// <summary>
        ///  AccPaymentListResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>AccPaymentListResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccPaymentListResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer       :   3H ����</br>
        /// <br>Date             :   2022/10/09</br>
        /// </remarks>
        private AccPaymentListResultWork GetAccPaymentListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            AccPaymentListResultWork temp = new AccPaymentListResultWork();

            //���_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_����
            temp.SectionGuideSnm = reader.ReadString();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�O�����|�c
            temp.LastTimeAccPay = reader.ReadInt64();
            //�����x��
            temp.ThisTimePayNrml = reader.ReadInt64();
            //�J�z�z
            temp.ThisTimeTtlBlcAcPay = reader.ReadInt64();
            //�d���z
            temp.OfsThisTimeStock = reader.ReadInt64();
            //�ԕi�l��
            temp.ThisRgdsDisPric = reader.ReadInt64();
            //�����
            temp.OfsThisStockTax = reader.ReadInt64();
            //�������c��
            temp.StckTtlAccPayBalance = reader.ReadInt64();
            //����
            temp.StockSlipCount = reader.ReadInt32();
            //�萔��
            temp.ThisTimeFeePayNrml = reader.ReadInt64();
            //�l��
            temp.ThisTimeDisPayNrml = reader.ReadInt64();
            //����
            temp.CashPayment = reader.ReadInt64();
            //�U��
            temp.TrfrPayment = reader.ReadInt64();
            //���؎�
            temp.CheckPayment = reader.ReadInt64();
            //��`
            temp.DraftPayment = reader.ReadInt64();
            //���E
            temp.OffsetPayment = reader.ReadInt64();
            //�����U��
            temp.FundTransferPayment = reader.ReadInt64();
            //���̑�
            temp.OthsPayment = reader.ReadInt64();
            //����d�����z
            temp.ThisTimeStockPrice = reader.ReadInt64();
            // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
            //�d���z(�v�ŗ�1)
            temp.TotalThisTimeStockPriceTaxRate1 = reader.ReadInt64();
            //�d���z(�v�ŗ�2)
            temp.TotalThisTimeStockPriceTaxRate2 = reader.ReadInt64();
            //�d���z(�v���̑�)
            temp.TotalThisTimeStockPriceOther = reader.ReadInt64();
            //�ԕi�l��(�v�ŗ�1)
            temp.TotalThisRgdsDisPricTaxRate1 = reader.ReadInt64();
            //�ԕi�l��(�v�ŗ�2)
            temp.TotalThisRgdsDisPricTaxRate2 = reader.ReadInt64();
            //�ԕi�l��(�v���̑�)
            temp.TotalThisRgdsDisPricOther = reader.ReadInt64();
            //���d���z(�v�ŗ�1)
            temp.TotalPureStockTaxRate1 = reader.ReadInt64();
            //���d���z(�v�ŗ�2)
            temp.TotalPureStockTaxRate2 = reader.ReadInt64();
            //���d���z(�v���̑�)
            temp.TotalPureStockOther = reader.ReadInt64();
            //�����(�v�ŗ�1)
            temp.TotalStockPricTaxTaxRate1 = reader.ReadInt64();
            //�����(�v�ŗ�2)
            temp.TotalStockPricTaxTaxRate2 = reader.ReadInt64();
            //�����(�v���̑�)
            temp.TotalStockPricTaxOther = reader.ReadInt64();
            //�������v(�v�ŗ�1)
            temp.TotalStckTtlAccPayBalanceTaxRate1 = reader.ReadInt64();
            //�������v(�v�ŗ�2)
            temp.TotalStckTtlAccPayBalanceTaxRate2 = reader.ReadInt64();
            //�������v(�v���̑�)
            temp.TotalStckTtlAccPayBalanceOther = reader.ReadInt64();
            //����(�v�ŗ�1)
            temp.TotalStockSlipCountTaxRate1 = reader.ReadInt32();
            //����(�v�ŗ�2)
            temp.TotalStockSlipCountTaxRate2 = reader.ReadInt32();
            //����(�v���̑�)
            temp.TotalStockSlipCountOther = reader.ReadInt32();
            //�ŗ�1�^�C�g��
            temp.TitleTaxRate1 = reader.ReadString();
            //�ŗ�2�^�C�g��
            temp.TitleTaxRate2 = reader.ReadString();
            // --- ADD END 3H ������ 2020/03/02 ----------<<<<<
            // --- ADD START 3H ���� 2022/10/09 ----->>>>>
            // �d���z(�v��ې�)
            temp.TotalThisTimeStockPriceTaxFree = reader.ReadInt64();
            // �ԕi�l��(�v��ې�)
            temp.TotalThisRgdsDisPricTaxFree = reader.ReadInt64();
            // ���d���z(�v��ې�)
            temp.TotalPureStockTaxFree = reader.ReadInt64();
            // �����(�v��ې�)
            temp.TotalStockPricTaxTaxFree = reader.ReadInt64();
            // �������v(�v��ې�)
            temp.TotalStckTtlAccPayBalanceTaxFree = reader.ReadInt64();
            // ����(�v��ې�)
            temp.TotalStockSlipCountTaxFree = reader.ReadInt32();
            // --- ADD END 3H ���� 2022/10/09 -----<<<<<

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
        /// <returns>AccPaymentListResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccPaymentListResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AccPaymentListResultWork temp = GetAccPaymentListResultWork(reader, serInfo);
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
                    retValue = (AccPaymentListResultWork[])lst.ToArray(typeof(AccPaymentListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
