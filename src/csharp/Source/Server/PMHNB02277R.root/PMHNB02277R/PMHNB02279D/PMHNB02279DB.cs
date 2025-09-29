using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SumRsltInfo_BillBalanceWork
    /// <summary>
    ///                      ���|�c���ꗗ�\(����)���o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���|�c���ꗗ�\(����)���o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/06/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :   3H ������</br>
    /// <br>Date	         :   2020/04/10</br>
    /// <br>UpdateNote       : 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer       : ���O</br>
    /// <br>Date             : 2022/10/13</br>  
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SumRsltInfo_BillBalanceWork
    {
        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�v�㋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���_�K�C�h����</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>�O�񔄊|���z</summary>
        /// <remarks>�O�񔄊|���z</remarks>
        private Int64 _lastTimeAccRec;

        /// <summary>����������z�i�ʏ�����j</summary>
        /// <remarks>����������z�i�ʏ�����j</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>����J�z�c���i���|�v�j</summary>
        /// <remarks>����J�z�c���i���|�v�j</remarks>
        private Int64 _thisTimeTtlBlcAcc;

        /// <summary>���E�㍡�񔄏���z</summary>
        /// <remarks>���E�㍡�񔄏���z</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>�ԕi�l��</summary>
        /// <remarks>���񔄏�ԕi���z+���񔄏�l�����z</remarks>
        private Int64 _thisRgdsDisPric;

        /// <summary>���E�㍡�񔄏�����</summary>
        /// <remarks>���E�㍡�񔄏�����</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>�v�Z�㓖�����|���z</summary>
        /// <remarks>�v�Z�㓖�����|���z</remarks>
        private Int64 _afCalTMonthAccRec;

        /// <summary>����`�[����</summary>
        /// <remarks>����`�[����</remarks>
        private Int32 _salesSlipCount;

        /// <summary>�S���҃R�[�h</summary>
        /// <remarks>�ڋq�S���]�ƈ��R�[�h or �W���S���]�ƈ��R�[�h</remarks>
        private string _agentCd = "";

        /// <summary>����</summary>
        /// <remarks>����</remarks>
        private string _name = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�̔��G���A�R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        /// <remarks>�K�C�h����</remarks>
        private string _salesAreaName = "";

        /// <summary>����萔���z�i�ʏ�����j</summary>
        /// <remarks>����萔���z�i�ʏ�����j</remarks>
        private Int64 _thisTimeFeeDmdNrml;

        /// <summary>����l���z�i�ʏ�����j</summary>
        /// <remarks>����l���z�i�ʏ�����j</remarks>
        private Int64 _thisTimeDisDmdNrml;

        /// <summary>��������</summary>
        /// <remarks>����R�[�h�F�����̓������z</remarks>
        private Int64 _cashDeposit;

        /// <summary>�U��</summary>
        /// <remarks>����R�[�h�F�U���̓������z</remarks>
        private Int64 _trfrDeposit;

        /// <summary>���؎�</summary>
        /// <remarks>����R�[�h�F���؎�̓������z</remarks>
        private Int64 _checkDeposit;

        /// <summary>��`</summary>
        /// <remarks>����R�[�h�F��`�̓������z</remarks>
        private Int64 _draftDeposit;

        /// <summary>���E</summary>
        /// <remarks>����R�[�h�F���E�̓������z</remarks>
        private Int64 _offsetDeposit;

        /// <summary>�����U��</summary>
        /// <remarks>����R�[�h�F�����U�ւ̓������z</remarks>
        private Int64 _fundTransferDeposit;

        /// <summary>���̑�</summary>
        /// <remarks>����R�[�h�F���̑��̓������z</remarks>
        private Int64 _othsDeposit;

        /// <summary>���񔄏���z</summary>
        /// <remarks>���񔄏���z</remarks>
        private Int64 _thisTimeSales;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customersnm = "";

        /// <summary>�����������_�R�[�h</summary>
        private string _sumSecCode = "";

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        /// <summary>�ŗ�1�^�C�g��</summary>
        /// <remarks>�ŗ�1�^�C�g��</remarks>
        private string _titleTaxRate1 = string.Empty;

        /// <summary>�ŗ�2�^�C�g��</summary>
        /// <remarks>�ŗ�2�^�C�g��</remarks>
        private string _titleTaxRate2 = string.Empty;

        /// <summary>����z(�v�ŗ�1)</summary>
        /// <remarks>����z(�v�ŗ�1)</remarks>
        private Int64 _totalThisTimeSalesTaxRate1;

        /// <summary>����z(�v�ŗ�2)</summary>
        /// <remarks>����z(�v�ŗ�2)</remarks>
        private Int64 _totalThisTimeSalesTaxRate2;

        /// <summary>����z(�v���̑�)</summary>
        /// <remarks>����z(�v���̑�)</remarks>
        private Int64 _totalThisTimeSalesOther;

        /// <summary>�ԕi�l��(�v�ŗ�1)</summary>
        /// <remarks>�ԕi�l��(�v�ŗ�1)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate1;

        /// <summary>�ԕi�l��(�v�ŗ�2)</summary>
        /// <remarks>�ԕi�l��(�v�ŗ�2)</remarks>
        private Int64 _totalThisRgdsDisPricTaxRate2;

        /// <summary>�ԕi�l��(�v���̑�)</summary>
        /// <remarks>�ԕi�l��(�v���̑�)</remarks>
        private Int64 _totalThisRgdsDisPricOther;

        /// <summary>������z(�v�ŗ�1)</summary>
        /// <remarks>������z(�v�ŗ�1)</remarks>
        private Int64 _totalPureSalesTaxRate1;

        /// <summary>������z(�v�ŗ�2)</summary>
        /// <remarks>������z(�v�ŗ�2)</remarks>
        private Int64 _totalPureSalesTaxRate2;

        /// <summary>������z(�v���̑�)</summary>
        /// <remarks>������z(�v���̑�)</remarks>
        private Int64 _totalPureSalesOther;

        /// <summary>�����(�v�ŗ�1)</summary>
        /// <remarks>�����(�v�ŗ�1)</remarks>
        private Int64 _totalSalesPricTaxTaxRate1;

        /// <summary>�����(�v�ŗ�2)</summary>
        /// <remarks>�����(�v�ŗ�2)</remarks>
        private Int64 _totalSalesPricTaxTaxRate2;

        /// <summary>�����(�v���̑�)</summary>
        /// <remarks>�����(�v���̑�)</remarks>
        private Int64 _totalSalesPricTaxOther;

        /// <summary>�������v(�v�ŗ�1)</summary>
        /// <remarks>�������v(�v�ŗ�1)</remarks>
        private Int64 _totalAfCalTMonthAccRecTaxRate1;

        /// <summary>�������v(�v�ŗ�2)</summary>
        /// <remarks>�������v(�v�ŗ�2)</remarks>
        private Int64 _totalAfCalTMonthAccRecTaxRate2;

        /// <summary>�������v(�v���̑�)</summary>
        /// <remarks>�������v(�v���̑�)</remarks>
        private Int64 _totalAfCalTMonthAccRecOther;

        /// <summary>����(�v�ŗ�1)</summary>
        /// <remarks>����(�v�ŗ�1)</remarks>
        private Int32 _totalSalesSlipCountTaxRate1;

        /// <summary>����(�v�ŗ�2)</summary>
        /// <remarks>����(�v�ŗ�2)</remarks>
        private Int32 _totalSalesSlipCountTaxRate2;

        /// <summary>����(�v���̑�)</summary>
        /// <remarks>����(�v���̑�)</remarks>
        private Int32 _totalSalesSlipCountOther;
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

        // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
        /// <summary>����z(��ې�)</summary>
        /// <remarks>����z(��ې�)</remarks>
        private Int64 _totalThisTimeSalesTaxFree;

        /// <summary>�ԕi�l��(��ې�)</summary>
        /// <remarks>�ԕi�l��(��ې�)</remarks>
        private Int64 _totalThisRgdsDisPricTaxFree;

        /// <summary>������z(��ې�)</summary>
        /// <remarks>������z(��ې�)</remarks>
        private Int64 _totalPureSalesTaxFree;

        /// <summary>�����(��ې�)</summary>
        /// <remarks>�����(��ې�)</remarks>
        private Int64 _totalSalesPricTaxTaxFree;

        /// <summary>�������v(��ې�)</summary>
        /// <remarks>�������v(��ې�)</remarks>
        private Int64 _totalAfCalTMonthAccRecTaxFree;

        /// <summary>����(��ې�)</summary>
        /// <remarks>����(��ې�)</remarks>
        private Int32 _totalSalesSlipCountTaxFree;
        // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�v�㋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���_�K�C�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  LastTimeAccRec
        /// <summary>�O�񔄊|���z�v���p�e�B</summary>
        /// <value>�O�񔄊|���z</value>
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

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
        /// <value>����������z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDmdNrml
        {
            get { return _thisTimeDmdNrml; }
            set { _thisTimeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcAcc
        /// <summary>����J�z�c���i���|�v�j�v���p�e�B</summary>
        /// <value>����J�z�c���i���|�v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����J�z�c���i���|�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcAcc
        {
            get { return _thisTimeTtlBlcAcc; }
            set { _thisTimeTtlBlcAcc = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
        /// <value>���E�㍡�񔄏���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  ThisRgdsDisPric
        /// <summary>�ԕi�l���v���p�e�B</summary>
        /// <value>���񔄏�ԕi���z+���񔄏�l�����z</value>
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

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
        /// <value>���E�㍡�񔄏�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡�񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisSalesTax
        {
            get { return _ofsThisSalesTax; }
            set { _ofsThisSalesTax = value; }
        }

        /// public propaty name  :  AfCalTMonthAccRec
        /// <summary>�v�Z�㓖�����|���z�v���p�e�B</summary>
        /// <value>�v�Z�㓖�����|���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�Z�㓖�����|���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AfCalTMonthAccRec
        {
            get { return _afCalTMonthAccRec; }
            set { _afCalTMonthAccRec = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>����`�[�����v���p�e�B</summary>
        /// <value>����`�[����</value>
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

        /// public propaty name  :  AgentCd
        /// <summary>�S���҃R�[�h�v���p�e�B</summary>
        /// <value>�ڋq�S���]�ƈ��R�[�h or �W���S���]�ƈ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AgentCd
        {
            get { return _agentCd; }
            set { _agentCd = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// <value>����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�̔��G���A�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// <value>�K�C�h����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  ThisTimeFeeDmdNrml
        /// <summary>����萔���z�i�ʏ�����j�v���p�e�B</summary>
        /// <value>����萔���z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����萔���z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeFeeDmdNrml
        {
            get { return _thisTimeFeeDmdNrml; }
            set { _thisTimeFeeDmdNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisDmdNrml
        /// <summary>����l���z�i�ʏ�����j�v���p�e�B</summary>
        /// <value>����l���z�i�ʏ�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���z�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDisDmdNrml
        {
            get { return _thisTimeDisDmdNrml; }
            set { _thisTimeDisDmdNrml = value; }
        }

        /// public propaty name  :  CashDeposit
        /// <summary>���������v���p�e�B</summary>
        /// <value>����R�[�h�F�����̓������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CashDeposit
        {
            get { return _cashDeposit; }
            set { _cashDeposit = value; }
        }

        /// public propaty name  :  TrfrDeposit
        /// <summary>�U���v���p�e�B</summary>
        /// <value>����R�[�h�F�U���̓������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �U���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TrfrDeposit
        {
            get { return _trfrDeposit; }
            set { _trfrDeposit = value; }
        }

        /// public propaty name  :  CheckDeposit
        /// <summary>���؎�v���p�e�B</summary>
        /// <value>����R�[�h�F���؎�̓������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���؎�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CheckDeposit
        {
            get { return _checkDeposit; }
            set { _checkDeposit = value; }
        }

        /// public propaty name  :  DraftDeposit
        /// <summary>��`�v���p�e�B</summary>
        /// <value>����R�[�h�F��`�̓������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DraftDeposit
        {
            get { return _draftDeposit; }
            set { _draftDeposit = value; }
        }

        /// public propaty name  :  OffsetDeposit
        /// <summary>���E�v���p�e�B</summary>
        /// <value>����R�[�h�F���E�̓������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OffsetDeposit
        {
            get { return _offsetDeposit; }
            set { _offsetDeposit = value; }
        }

        /// public propaty name  :  FundTransferDeposit
        /// <summary>�����U�փv���p�e�B</summary>
        /// <value>����R�[�h�F�����U�ւ̓������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����U�փv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FundTransferDeposit
        {
            get { return _fundTransferDeposit; }
            set { _fundTransferDeposit = value; }
        }

        /// public propaty name  :  OthsDeposit
        /// <summary>���̑��v���p�e�B</summary>
        /// <value>����R�[�h�F���̑��̓������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̑��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OthsDeposit
        {
            get { return _othsDeposit; }
            set { _othsDeposit = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>���񔄏���z�v���p�e�B</summary>
        /// <value>���񔄏���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeSales
        {
            get { return _thisTimeSales; }
            set { _thisTimeSales = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  Customersnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Customersnm
        {
            get { return _customersnm; }
            set { _customersnm = value; }
        }

        /// public propaty name  :  SumSecCode
        /// <summary>�����������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SumSecCode
        {
            get { return _sumSecCode; }
            set { _sumSecCode = value; }
        }

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
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

        /// public propaty name  :  TotalThisTimeSalesTaxRate1
        /// <summary>����z(�v�ŗ�1) </summary>
        /// <value>����z(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxRate1
        {
            get { return _totalThisTimeSalesTaxRate1; }
            set { _totalThisTimeSalesTaxRate1 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesTaxRate2
        /// <summary>����z(�v�ŗ�2) </summary>
        /// <value>����z(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxRate2
        {
            get { return _totalThisTimeSalesTaxRate2; }
            set { _totalThisTimeSalesTaxRate2 = value; }
        }

        /// public propaty name  :  TotalThisTimeSalesOther
        /// <summary>����z(�v���̑�) </summary>
        /// <value>����z(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesOther
        {
            get { return _totalThisTimeSalesOther; }
            set { _totalThisTimeSalesOther = value; }
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

        /// public propaty name  :  TotalPureSalesTaxRate1
        /// <summary>������z(�v�ŗ�1) </summary>
        /// <value>������z(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxRate1
        {
            get { return _totalPureSalesTaxRate1; }
            set { _totalPureSalesTaxRate1 = value; }
        }

        /// public propaty name  :  TotalPureSalesTaxRate2
        /// <summary>������z(�v�ŗ�2) </summary>
        /// <value>������z(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxRate2
        {
            get { return _totalPureSalesTaxRate2; }
            set { _totalPureSalesTaxRate2 = value; }
        }

        /// public propaty name  :  TotalPureSalesOther
        /// <summary>������z(�v���̑�) </summary>
        /// <value>������z(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureSalesOther
        {
            get { return _totalPureSalesOther; }
            set { _totalPureSalesOther = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxTaxRate1
        /// <summary>�����(�v�ŗ�1) </summary>
        /// <value>�����(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxRate1
        {
            get { return _totalSalesPricTaxTaxRate1; }
            set { _totalSalesPricTaxTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxTaxRate2
        /// <summary>�����(�v�ŗ�2) </summary>
        /// <value>�����(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxRate2
        {
            get { return _totalSalesPricTaxTaxRate2; }
            set { _totalSalesPricTaxTaxRate2 = value; }
        }

        /// public propaty name  :  TotalSalesPricTaxOther
        /// <summary>�����(�v���̑�) </summary>
        /// <value>�����(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxOther
        {
            get { return _totalSalesPricTaxOther; }
            set { _totalSalesPricTaxOther = value; }
        }

        /// public propaty name  :  TotalAfCalTMonthAccRecTaxRate1
        /// <summary>�������v(�v�ŗ�1) </summary>
        /// <value>�������v(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalAfCalTMonthAccRecTaxRate1
        {
            get { return _totalAfCalTMonthAccRecTaxRate1; }
            set { _totalAfCalTMonthAccRecTaxRate1 = value; }
        }

        /// public propaty name  :  TotalAfCalTMonthAccRecTaxRate2
        /// <summary>�������v(�v�ŗ�2) </summary>
        /// <value>�������v(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalAfCalTMonthAccRecTaxRate2
        {
            get { return _totalAfCalTMonthAccRecTaxRate2; }
            set { _totalAfCalTMonthAccRecTaxRate2 = value; }
        }

        /// public propaty name  :  TotalAfCalTMonthAccRecOther
        /// <summary>�������v(�v���̑�) </summary>
        /// <value>�������v(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalAfCalTMonthAccRecOther
        {
            get { return _totalAfCalTMonthAccRecOther; }
            set { _totalAfCalTMonthAccRecOther = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate1
        /// <summary>����(�v�ŗ�1) </summary>
        /// <value>����(�v�ŗ�1) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v�ŗ�1) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxRate1
        {
            get { return _totalSalesSlipCountTaxRate1; }
            set { _totalSalesSlipCountTaxRate1 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxRate2
        /// <summary>����(�v�ŗ�2) </summary>
        /// <value>����(�v�ŗ�2) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v�ŗ�2) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxRate2
        {
            get { return _totalSalesSlipCountTaxRate2; }
            set { _totalSalesSlipCountTaxRate2 = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountOther
        /// <summary>����(�v���̑�) </summary>
        /// <value>����(�v���̑�) </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�v���̑�) �v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountOther
        {
            get { return _totalSalesSlipCountOther; }
            set { _totalSalesSlipCountOther = value; }
        }
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

        // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
        /// public propaty name  :  TotalThisTimeSalesTaxFree
        /// <summary>����z(��ې�)�v���p�e�B</summary>
        /// <value>����z(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����z(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisTimeSalesTaxFree
        {
            get { return _totalThisTimeSalesTaxFree; }
            set { _totalThisTimeSalesTaxFree = value; }
        }
        /// public propaty name  :  TotalThisRgdsDisPricTaxFree
        /// <summary>�ԕi�l��(��ې�)�v���p�e�B</summary>
        /// <value>�ԕi�l��(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�l��(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalThisRgdsDisPricTaxFree
        {
            get { return _totalThisRgdsDisPricTaxFree; }
            set { _totalThisRgdsDisPricTaxFree = value; }
        }
        /// public propaty name  :  TotalPureSalesTaxFree
        /// <summary>������z(��ې�)�v���p�e�B</summary>
        /// <value>������z(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ������z(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalPureSalesTaxFree
        {
            get { return _totalPureSalesTaxFree; }
            set { _totalPureSalesTaxFree = value; }
        }
        /// public propaty name  :  TotalSalesPricTaxTaxFree
        /// <summary>�����(��ې�)�v���p�e�B</summary>
        /// <value>�����(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �����(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalSalesPricTaxTaxFree
        {
            get { return _totalSalesPricTaxTaxFree; }
            set { _totalSalesPricTaxTaxFree = value; }
        }

        /// public propaty name  :  TotalAfCalTMonthAccRecTaxFree
        /// <summary>�������v(��ې�)�v���p�e�B</summary>
        /// <value>�������v(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �������v(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TotalAfCalTMonthAccRecTaxFree
        {
            get { return _totalAfCalTMonthAccRecTaxFree; }
            set { _totalAfCalTMonthAccRecTaxFree = value; }
        }

        /// public propaty name  :  TotalSalesSlipCountTaxFree
        /// <summary>����(��ې�)�v���p�e�B</summary>
        /// <value>����(��ې�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ����(��ې�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalSalesSlipCountTaxFree
        {
            get { return _totalSalesSlipCountTaxFree; }
            set { _totalSalesSlipCountTaxFree = value; }
        }

        // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<

        /// <summary>
        /// ���|�c���ꗗ�\(����)���o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SumRsltInfo_BillBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumRsltInfo_BillBalanceWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SumRsltInfo_BillBalanceWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SumRsltInfo_BillBalanceWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SumRsltInfo_BillBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :   3H ������</br>
    /// <br>Date	         :   2020/04/10</br>
    /// </remarks>
    public class SumRsltInfo_BillBalanceWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumRsltInfo_BillBalanceWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer       :   3H ������</br>
        /// <br>Date	         :   2020/04/10</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SumRsltInfo_BillBalanceWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SumRsltInfo_BillBalanceWork || graph is ArrayList || graph is SumRsltInfo_BillBalanceWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SumRsltInfo_BillBalanceWork).FullName));

            if (graph != null && graph is SumRsltInfo_BillBalanceWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SumRsltInfo_BillBalanceWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SumRsltInfo_BillBalanceWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SumRsltInfo_BillBalanceWork[])graph).Length;
            }
            else if (graph is SumRsltInfo_BillBalanceWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //�O�񔄊|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccRec
            //����������z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //����J�z�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcc
            //���E�㍡�񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //�ԕi�l��
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisRgdsDisPric
            //���E�㍡�񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //�v�Z�㓖�����|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalTMonthAccRec
            //����`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //�S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AgentCd
            //����
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //����萔���z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //����l���z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //��������
            serInfo.MemberInfo.Add(typeof(Int64)); //CashDeposit
            //�U��
            serInfo.MemberInfo.Add(typeof(Int64)); //TrfrDeposit
            //���؎�
            serInfo.MemberInfo.Add(typeof(Int64)); //CheckDeposit
            //��`
            serInfo.MemberInfo.Add(typeof(Int64)); //DraftDeposit
            //���E
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetDeposit
            //�����U��
            serInfo.MemberInfo.Add(typeof(Int64)); //FundTransferDeposit
            //���̑�
            serInfo.MemberInfo.Add(typeof(Int64)); //OthsDeposit
            //���񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //Customersnm
            //�����������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SumSecCode
            // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
            // ����z(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxRate1
            // ����z(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxRate2
            // ����z(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesOther
            // �ԕi�l��(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate1
            // �ԕi�l��(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxRate2
            // �ԕi�l��(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricOther
            // ������z(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxRate1
            // ������z(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxRate2
            // ������z(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesOther
            // �����(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxRate1
            // �����(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxRate2
            // �����(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTax_Other
            // �������v(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalAfCalTMonthAccRecTaxRate1
            // �������v(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalAfCalTMonthAccRecTaxRate2
            // �������v(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalAfCalTMonthAccRecOther
            // ����(�v�ŗ�1)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxRate1
            // ����(�v�ŗ�2)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxRate2
            // ����(�v���̑�)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountOther
            // �ŗ�1�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate1
            // �ŗ�2�^�C�g��
            serInfo.MemberInfo.Add(typeof(string)); //TtitleTaxRate2
            // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

            // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
            // ����z(��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisTimeSalesTaxFree
            // �ԕi�l��(��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalThisRgdsDisPricTaxFree
            // ������z(��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalPureSalesTaxFree
            // �����(��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalSalesPricTaxTaxFree
            // �������v(��ې�)
            serInfo.MemberInfo.Add(typeof(Int64)); //TotalAfCalTMonthAccRecTaxFree
            // ����(��ې�)
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalSalesSlipCountTaxFree
            // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SumRsltInfo_BillBalanceWork)
            {
                SumRsltInfo_BillBalanceWork temp = (SumRsltInfo_BillBalanceWork)graph;

                SetSumRsltInfo_BillBalanceWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SumRsltInfo_BillBalanceWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SumRsltInfo_BillBalanceWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SumRsltInfo_BillBalanceWork temp in lst)
                {
                    SetSumRsltInfo_BillBalanceWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SumRsltInfo_BillBalanceWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 29; // DEL 3H ������ 2020/04/10
        // --- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
        //private const int currentMemberCount = 49; // ADD 3H ������ 2020/04/10
        // --- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
        private const int currentMemberCount = 55; // ADD 2022/09/19 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j

        /// <summary>
        ///  SumRsltInfo_BillBalanceWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumRsltInfo_BillBalanceWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer       :   3H ������</br>
        /// <br>Date	         :   2020/04/10</br>
        /// </remarks>
        private void SetSumRsltInfo_BillBalanceWork(System.IO.BinaryWriter writer, SumRsltInfo_BillBalanceWork temp)
        {
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //�O�񔄊|���z
            writer.Write(temp.LastTimeAccRec);
            //����������z�i�ʏ�����j
            writer.Write(temp.ThisTimeDmdNrml);
            //����J�z�c���i���|�v�j
            writer.Write(temp.ThisTimeTtlBlcAcc);
            //���E�㍡�񔄏���z
            writer.Write(temp.OfsThisTimeSales);
            //�ԕi�l��
            writer.Write(temp.ThisRgdsDisPric);
            //���E�㍡�񔄏�����
            writer.Write(temp.OfsThisSalesTax);
            //�v�Z�㓖�����|���z
            writer.Write(temp.AfCalTMonthAccRec);
            //����`�[����
            writer.Write(temp.SalesSlipCount);
            //�S���҃R�[�h
            writer.Write(temp.AgentCd);
            //����
            writer.Write(temp.Name);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����
            writer.Write(temp.SalesAreaName);
            //����萔���z�i�ʏ�����j
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //����l���z�i�ʏ�����j
            writer.Write(temp.ThisTimeDisDmdNrml);
            //��������
            writer.Write(temp.CashDeposit);
            //�U��
            writer.Write(temp.TrfrDeposit);
            //���؎�
            writer.Write(temp.CheckDeposit);
            //��`
            writer.Write(temp.DraftDeposit);
            //���E
            writer.Write(temp.OffsetDeposit);
            //�����U��
            writer.Write(temp.FundTransferDeposit);
            //���̑�
            writer.Write(temp.OthsDeposit);
            //���񔄏���z
            writer.Write(temp.ThisTimeSales);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.Customersnm);
            //�����������_�R�[�h
            writer.Write(temp.SumSecCode);
            // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
            //����z(�v�ŗ�1)
            writer.Write(temp.TotalThisTimeSalesTaxRate1);
            //����z(�v�ŗ�2)
            writer.Write(temp.TotalThisTimeSalesTaxRate2);
            //����z(�v���̑�)
            writer.Write(temp.TotalThisTimeSalesOther);
            //�ԕi�l��(�v�ŗ�1)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate1);
            //�ԕi�l��(�v�ŗ�2)
            writer.Write(temp.TotalThisRgdsDisPricTaxRate2);
            //�ԕi�l��(�v���̑�)
            writer.Write(temp.TotalThisRgdsDisPricOther);
            //������z(�v�ŗ�1)
            writer.Write(temp.TotalPureSalesTaxRate1);
            //������z(�v�ŗ�2)
            writer.Write(temp.TotalPureSalesTaxRate2);
            //������z(�v���̑�)
            writer.Write(temp.TotalPureSalesOther);
            //�����(�v�ŗ�1)
            writer.Write(temp.TotalSalesPricTaxTaxRate1);
            //�����(�v�ŗ�2)
            writer.Write(temp.TotalSalesPricTaxTaxRate2);
            //�����(�v���̑�)
            writer.Write(temp.TotalSalesPricTaxOther);
            //�������v(�v�ŗ�1)
            writer.Write(temp.TotalAfCalTMonthAccRecTaxRate1);
            //�������v(�v�ŗ�2)
            writer.Write(temp.TotalAfCalTMonthAccRecTaxRate2);
            //�������v(�v���̑�)
            writer.Write(temp.TotalAfCalTMonthAccRecOther);
            //����(�v�ŗ�1)
            writer.Write(temp.TotalSalesSlipCountTaxRate1);
            //����(�v�ŗ�2)
            writer.Write(temp.TotalSalesSlipCountTaxRate2);
            //����(�v���̑�)
            writer.Write(temp.TotalSalesSlipCountOther);
            //�ŗ�1�^�C�g��
            writer.Write(temp.TitleTaxRate1);
            //�ŗ�2�^�C�g��
            writer.Write(temp.TitleTaxRate2);
            // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

            // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
            // ����z(��ې�)
            writer.Write(temp.TotalThisTimeSalesTaxFree);
            // �ԕi�l��(��ې�)
            writer.Write(temp.TotalThisRgdsDisPricTaxFree);
            // ������z(��ې�)
            writer.Write(temp.TotalPureSalesTaxFree);
            // �����(��ې�)
            writer.Write(temp.TotalSalesPricTaxTaxFree);
            // �������v(��ې�)
            writer.Write(temp.TotalAfCalTMonthAccRecTaxFree);
            // ����(��ې�)
            writer.Write(temp.TotalSalesSlipCountTaxFree);
            // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<
        }

        /// <summary>
        ///  SumRsltInfo_BillBalanceWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SumRsltInfo_BillBalanceWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumRsltInfo_BillBalanceWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer       :   3H ������</br>
        /// <br>Date	         :   2020/04/10</br>
        /// </remarks>
        private SumRsltInfo_BillBalanceWork GetSumRsltInfo_BillBalanceWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SumRsltInfo_BillBalanceWork temp = new SumRsltInfo_BillBalanceWork();

            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //�O�񔄊|���z
            temp.LastTimeAccRec = reader.ReadInt64();
            //����������z�i�ʏ�����j
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //����J�z�c���i���|�v�j
            temp.ThisTimeTtlBlcAcc = reader.ReadInt64();
            //���E�㍡�񔄏���z
            temp.OfsThisTimeSales = reader.ReadInt64();
            //�ԕi�l��
            temp.ThisRgdsDisPric = reader.ReadInt64();
            //���E�㍡�񔄏�����
            temp.OfsThisSalesTax = reader.ReadInt64();
            //�v�Z�㓖�����|���z
            temp.AfCalTMonthAccRec = reader.ReadInt64();
            //����`�[����
            temp.SalesSlipCount = reader.ReadInt32();
            //�S���҃R�[�h
            temp.AgentCd = reader.ReadString();
            //����
            temp.Name = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����
            temp.SalesAreaName = reader.ReadString();
            //����萔���z�i�ʏ�����j
            temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
            //����l���z�i�ʏ�����j
            temp.ThisTimeDisDmdNrml = reader.ReadInt64();
            //��������
            temp.CashDeposit = reader.ReadInt64();
            //�U��
            temp.TrfrDeposit = reader.ReadInt64();
            //���؎�
            temp.CheckDeposit = reader.ReadInt64();
            //��`
            temp.DraftDeposit = reader.ReadInt64();
            //���E
            temp.OffsetDeposit = reader.ReadInt64();
            //�����U��
            temp.FundTransferDeposit = reader.ReadInt64();
            //���̑�
            temp.OthsDeposit = reader.ReadInt64();
            //���񔄏���z
            temp.ThisTimeSales = reader.ReadInt64();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.Customersnm = reader.ReadString();
            //�����������_�R�[�h
            temp.SumSecCode = reader.ReadString();
            // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
            //����z(�v�ŗ�1)
            temp.TotalThisTimeSalesTaxRate1 = reader.ReadInt64();
            //����z(�v�ŗ�2)
            temp.TotalThisTimeSalesTaxRate2 = reader.ReadInt64();
            //����z(�v���̑�)
            temp.TotalThisTimeSalesOther = reader.ReadInt64();
            //�ԕi�l��(�v�ŗ�1)
            temp.TotalThisRgdsDisPricTaxRate1 = reader.ReadInt64();
            //�ԕi�l��(�v�ŗ�2)
            temp.TotalThisRgdsDisPricTaxRate2 = reader.ReadInt64();
            //�ԕi�l��(�v���̑�)
            temp.TotalThisRgdsDisPricOther = reader.ReadInt64();
            //������z(�v�ŗ�1)
            temp.TotalPureSalesTaxRate1 = reader.ReadInt64();
            //������z(�v�ŗ�2)
            temp.TotalPureSalesTaxRate2 = reader.ReadInt64();
            //������z(�v���̑�)
            temp.TotalPureSalesOther = reader.ReadInt64();
            //�����(�v�ŗ�1)
            temp.TotalSalesPricTaxTaxRate1 = reader.ReadInt64();
            //�����(�v�ŗ�2)
            temp.TotalSalesPricTaxTaxRate2 = reader.ReadInt64();
            //�����(�v���̑�)
            temp.TotalSalesPricTaxOther = reader.ReadInt64();
            //�������v(�v�ŗ�1)
            temp.TotalAfCalTMonthAccRecTaxRate1 = reader.ReadInt64();
            //�������v(�v�ŗ�2)
            temp.TotalAfCalTMonthAccRecTaxRate2 = reader.ReadInt64();
            //�������v(�v���̑�)
            temp.TotalAfCalTMonthAccRecOther = reader.ReadInt64();
            //����(�v�ŗ�1)
            temp.TotalSalesSlipCountTaxRate1 = reader.ReadInt32();
            //����(�v�ŗ�2)
            temp.TotalSalesSlipCountTaxRate2 = reader.ReadInt32();
            //����(�v���̑�)
            temp.TotalSalesSlipCountOther = reader.ReadInt32();
            //�ŗ�1�^�C�g��
            temp.TitleTaxRate1 = reader.ReadString();
            //�ŗ�2�^�C�g��
            temp.TitleTaxRate2 = reader.ReadString();
            // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

            // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ----->>>>>
            // ����z(��ې�)
            temp.TotalThisTimeSalesTaxFree = reader.ReadInt64();
            // �ԕi�l��(��ې�)
            temp.TotalThisRgdsDisPricTaxFree = reader.ReadInt64();
            // ������z(��ې�)
            temp.TotalPureSalesTaxFree = reader.ReadInt64();
            // �����(��ې�)
            temp.TotalSalesPricTaxTaxFree = reader.ReadInt64();
            // �������v(��ې�)
            temp.TotalAfCalTMonthAccRecTaxFree = reader.ReadInt64();
            // ����(��ې�)
            temp.TotalSalesSlipCountTaxFree = reader.ReadInt32();
            // --- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j -----<<<<<

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
        /// <returns>SumRsltInfo_BillBalanceWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumRsltInfo_BillBalanceWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SumRsltInfo_BillBalanceWork temp = GetSumRsltInfo_BillBalanceWork(reader, serInfo);
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
                    retValue = (SumRsltInfo_BillBalanceWork[])lst.ToArray(typeof(SumRsltInfo_BillBalanceWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
