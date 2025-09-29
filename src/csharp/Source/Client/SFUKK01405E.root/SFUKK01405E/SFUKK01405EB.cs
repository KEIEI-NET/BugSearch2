using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   DepositCustDmdPrc
	/// <summary>
	///                      �������Ӑ搿�����z���N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �������Ӑ搿�����z���N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/1/18</br>
	/// <br>Genarated Date   :   2007/04/18  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2007/4/18  �ؑ��@����</br>
	/// <br>                 :   ���Ӑ搿�����z�}�X�^�̃��C�A�E�g�ύX</br>
	/// <br>                 :   �ɔ����C��</br>
    /// <br>Update Note      :   2007.10.05  20081 �D�c �E�l</br>
    /// <br>                 :   ���Ӑ搿�����z�}�X�^�̃��C�A�E�g�ύX</br>
    /// <br>                 :   �ɔ����C��(DC.NS�p)</br>
    /// </remarks>
    public class DepositCustDmdPrc
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>������R�[�h</summary>
        /// <remarks>������e�R�[�h</remarks>
        private Int32 _claimCode;

        /// <summary>�����於��</summary>
        private string _claimName = "";

        /// <summary>�����於��2</summary>
        private string _claimName2 = "";

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�O�񐿋����z</summary>
        private Int64 _lastTimeDemand;

        /// <summary>����������z�i�ʏ�����j</summary>
        private Int64 _thisTimeDmdNrml;

        /// <summary>����萔���z�i�ʏ�����j</summary>
        private Int64 _thisTimeFeeDmdNrml;

        /// <summary>����l���z�i�ʏ�����j</summary>
        private Int64 _thisTimeDisDmdNrml;

        /// <summary>����J�z�c���i�����v�j</summary>
        /// <remarks>����J�z�c�����O�񐿋��z�|�����z�i�����v�j</remarks>
        private Int64 _thisTimeTtlBlcDmd;

        /// <summary>���񔄏���z</summary>
        private Int64 _thisTimeSales;

        /// <summary>���񔄏�����</summary>
        private Int64 _thisSalesTax;

        /// <summary>���E�㍡�񔄏���z</summary>
        private Int64 _ofsThisTimeSales;

        /// <summary>���E�㍡�񔄏�����</summary>
        private Int64 _ofsThisSalesTax;

        /// <summary>���E��O�őΏۊz</summary>
        /// <remarks>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedOffsetOutTax;

        /// <summary>���E����őΏۊz</summary>
        /// <remarks>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedOffsetInTax;

        /// <summary>���E���ېőΏۊz</summary>
        /// <remarks>���E�p�F��ېŊz�̏W�v</remarks>
        private Int64 _itdedOffsetTaxFree;

        /// <summary>���E��O�ŏ����</summary>
        /// <remarks>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
        private Int64 _offsetOutTax;

        /// <summary>���E����ŏ����</summary>
        /// <remarks>���E�p�F���ŏ���ł̏W�v</remarks>
        private Int64 _offsetInTax;

        /// <summary>����O�őΏۊz</summary>
        /// <remarks>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedSalesOutTax;

        /// <summary>������őΏۊz</summary>
        /// <remarks>�����p�F���Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedSalesInTax;

        /// <summary>�����ېőΏۊz</summary>
        /// <remarks>�����p�F��ېŊz�̏W�v</remarks>
        private Int64 _itdedSalesTaxFree;

        /// <summary>����O�Ŋz</summary>
        /// <remarks>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
        private Int64 _salesOutTax;

        /// <summary>������Ŋz</summary>
        /// <remarks>�����p�F���ŏ���ł̏W�v</remarks>
        private Int64 _salesInTax;

        /// <summary>���񔄏�ԕi���z</summary>
        /// <remarks>���񔄏�ԕi���z���ԕi�O�őΏۊz�{�ԕi���őΏۊz�{�ԕi��ېőΏۊz</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>���񔄏�ԕi�����</summary>
        /// <remarks>���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
        private Int64 _thisSalesPrcTaxRgds;

        /// <summary>�ԕi�O�őΏۊz���v</summary>
        private Int64 _ttlItdedRetOutTax;

        /// <summary>�ԕi���őΏۊz���v</summary>
        private Int64 _ttlItdedRetInTax;

        /// <summary>�ԕi��ېőΏۊz���v</summary>
        private Int64 _ttlItdedRetTaxFree;

        /// <summary>�ԕi�O�Ŋz���v</summary>
        private Int64 _ttlRetOuterTax;

        /// <summary>�ԕi���Ŋz���v</summary>
        private Int64 _ttlRetInnerTax;

        /// <summary>���񔄏�l�����z</summary>
        private Int64 _thisSalesPricDis;

        /// <summary>���񔄏�l�������</summary>
        /// <remarks>���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
        private Int64 _thisSalesPrcTaxDis;

        /// <summary>�l���O�őΏۊz���v</summary>
        private Int64 _ttlItdedDisOutTax;

        /// <summary>�l�����őΏۊz���v</summary>
        private Int64 _ttlItdedDisInTax;

        /// <summary>�l����ېőΏۊz���v</summary>
        private Int64 _ttlItdedDisTaxFree;

        /// <summary>�l���O�Ŋz���v</summary>
        private Int64 _ttlDisOuterTax;

        /// <summary>�l�����Ŋz���v</summary>
        private Int64 _ttlDisInnerTax;

        /// <summary>�c�������z</summary>
        private Int64 _balanceAdjust;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>����ŗ�</summary>
        /// <remarks>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</remarks>
        private Double _consTaxRate;

        /// <summary>�[�������敪</summary>
        private Int32 _fractionProcCd;

        /// <summary>�v�Z�㐿�����z</summary>
        /// <remarks>���񕪂̐������z</remarks>
        private Int64 _afCalDemandPrice;

        /// <summary>��2��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl2TmBfBlDmd;

        /// <summary>��3��O�c���i�����v�j</summary>
        private Int64 _acpOdrTtl3TmBfBlDmd;

        /// <summary>�����X�V���s�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>����`�[����</summary>
        private Int32 _saleslSlipCount;

        /// <summary>���������s��</summary>
        /// <remarks>"YYYYMMDD"  �������𔭍s�����N����</remarks>
        private Int32 _billPrintDate;

        /// <summary>�����X�V�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>�O������X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>�����\���</summary>
        private DateTime _expectedDepositDate;

        /// <summary>�������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _collectCond;

        /// <summary>���t�͈́i�J�n�j</summary>
        /// <remarks>YYYYMMDD �蓮�Œǉ�</remarks>
        private Int32 _startDateSpan;

        /// <summary>���t�͈́i�I���j</summary>
        /// <remarks>YYYYMMDD �蓮�Œǉ�</remarks>
        private Int32 _endDateSpan;

        /// <summary>����������z�i�a����j</summary>
        /// <remarks>�蓮�Œǉ�</remarks>
        private Int64 _thisTimeDmdDepo;

        /// <summary>����萔���z�i�a����j</summary>
        /// <remarks>�蓮�Œǉ�</remarks>
        private Int64 _thisTimeFeeDmdDepo;

        /// <summary>����l���z�i�a����j</summary>
        /// <remarks>�蓮�Œǉ�</remarks>
        private Int64 _thisTimeDisDmdDepo;

        /// <summary>��������v�i�ʏ�����j</summary>
        /// <remarks>�蓮�Œǉ�</remarks>
        private Int64 _thisTimeDmdNrmlTtl;

        /// <summary>��������v�i�a����j</summary>
        /// <remarks>�蓮�Œǉ�</remarks>
        private Int64 _thisTimeDmdDepoTtl;

        /// <summary>��������v</summary>
        /// <remarks>�蓮�Œǉ�</remarks>
        private Int64 _thisTimeDmdTtl;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
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

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>������e�R�[�h</value>
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

        /// public propaty name  :  ClaimName
        /// <summary>�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>�����於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
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

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  AddUpDateJpFormal
        /// <summary>�v��N���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateJpInFormal
        /// <summary>�v��N���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateAdFormal
        /// <summary>�v��N���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateAdInFormal
        /// <summary>�v��N���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  AddUpYearMonthJpFormal
        /// <summary>�v��N�� �a��v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpYearMonthJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthJpInFormal
        /// <summary>�v��N�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpYearMonthJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthAdFormal
        /// <summary>�v��N�� ����v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpYearMonthAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM", _addUpYearMonth); }
            set { }
        }

        /// public propaty name  :  AddUpYearMonthAdInFormal
        /// <summary>�v��N�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpYearMonthAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM", _addUpYearMonth); }
            set { }
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

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
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

        /// public propaty name  :  ThisTimeFeeDmdNrml
        /// <summary>����萔���z�i�ʏ�����j�v���p�e�B</summary>
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

        /// public propaty name  :  ThisTimeTtlBlcDmd
        /// <summary>����J�z�c���i�����v�j�v���p�e�B</summary>
        /// <value>����J�z�c�����O�񐿋��z�|�����z�i�����v�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����J�z�c���i�����v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcDmd
        {
            get { return _thisTimeTtlBlcDmd; }
            set { _thisTimeTtlBlcDmd = value; }
        }

        /// public propaty name  :  ThisTimeSales
        /// <summary>���񔄏���z�v���p�e�B</summary>
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

        /// public propaty name  :  ThisSalesTax
        /// <summary>���񔄏����Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesTax
        {
            get { return _thisSalesTax; }
            set { _thisSalesTax = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>���E�㍡�񔄏���z�v���p�e�B</summary>
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

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>���E�㍡�񔄏����Ńv���p�e�B</summary>
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

        /// public propaty name  :  ItdedOffsetOutTax
        /// <summary>���E��O�őΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E��O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedOffsetOutTax
        {
            get { return _itdedOffsetOutTax; }
            set { _itdedOffsetOutTax = value; }
        }

        /// public propaty name  :  ItdedOffsetInTax
        /// <summary>���E����őΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F���Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E����őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedOffsetInTax
        {
            get { return _itdedOffsetInTax; }
            set { _itdedOffsetInTax = value; }
        }

        /// public propaty name  :  ItdedOffsetTaxFree
        /// <summary>���E���ېőΏۊz�v���p�e�B</summary>
        /// <value>���E�p�F��ېŊz�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E���ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedOffsetTaxFree
        {
            get { return _itdedOffsetTaxFree; }
            set { _itdedOffsetTaxFree = value; }
        }

        /// public propaty name  :  OffsetOutTax
        /// <summary>���E��O�ŏ���Ńv���p�e�B</summary>
        /// <value>���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E��O�ŏ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OffsetOutTax
        {
            get { return _offsetOutTax; }
            set { _offsetOutTax = value; }
        }

        /// public propaty name  :  OffsetInTax
        /// <summary>���E����ŏ���Ńv���p�e�B</summary>
        /// <value>���E�p�F���ŏ���ł̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E����ŏ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OffsetInTax
        {
            get { return _offsetInTax; }
            set { _offsetInTax = value; }
        }

        /// public propaty name  :  ItdedSalesOutTax
        /// <summary>����O�őΏۊz�v���p�e�B</summary>
        /// <value>�����p�F�O�Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesOutTax
        {
            get { return _itdedSalesOutTax; }
            set { _itdedSalesOutTax = value; }
        }

        /// public propaty name  :  ItdedSalesInTax
        /// <summary>������őΏۊz�v���p�e�B</summary>
        /// <value>�����p�F���Ŋz�i�Ŕ����j�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������őΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesInTax
        {
            get { return _itdedSalesInTax; }
            set { _itdedSalesInTax = value; }
        }

        /// public propaty name  :  ItdedSalesTaxFree
        /// <summary>�����ېőΏۊz�v���p�e�B</summary>
        /// <value>�����p�F��ېŊz�̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ېőΏۊz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ItdedSalesTaxFree
        {
            get { return _itdedSalesTaxFree; }
            set { _itdedSalesTaxFree = value; }
        }

        /// public propaty name  :  SalesOutTax
        /// <summary>����O�Ŋz�v���p�e�B</summary>
        /// <value>�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����O�Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesOutTax
        {
            get { return _salesOutTax; }
            set { _salesOutTax = value; }
        }

        /// public propaty name  :  SalesInTax
        /// <summary>������Ŋz�v���p�e�B</summary>
        /// <value>�����p�F���ŏ���ł̏W�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesInTax
        {
            get { return _salesInTax; }
            set { _salesInTax = value; }
        }

        /// public propaty name  :  ThisSalesPricRgds
        /// <summary>���񔄏�ԕi���z�v���p�e�B</summary>
        /// <value>���񔄏�ԕi���z���ԕi�O�őΏۊz�{�ԕi���őΏۊz�{�ԕi��ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�ԕi���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPricRgds
        {
            get { return _thisSalesPricRgds; }
            set { _thisSalesPricRgds = value; }
        }

        /// public propaty name  :  ThisSalesPrcTaxRgds
        /// <summary>���񔄏�ԕi����Ńv���p�e�B</summary>
        /// <value>���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�ԕi����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPrcTaxRgds
        {
            get { return _thisSalesPrcTaxRgds; }
            set { _thisSalesPrcTaxRgds = value; }
        }

        /// public propaty name  :  TtlItdedRetOutTax
        /// <summary>�ԕi�O�őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedRetOutTax
        {
            get { return _ttlItdedRetOutTax; }
            set { _ttlItdedRetOutTax = value; }
        }

        /// public propaty name  :  TtlItdedRetInTax
        /// <summary>�ԕi���őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedRetInTax
        {
            get { return _ttlItdedRetInTax; }
            set { _ttlItdedRetInTax = value; }
        }

        /// public propaty name  :  TtlItdedRetTaxFree
        /// <summary>�ԕi��ېőΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi��ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedRetTaxFree
        {
            get { return _ttlItdedRetTaxFree; }
            set { _ttlItdedRetTaxFree = value; }
        }

        /// public propaty name  :  TtlRetOuterTax
        /// <summary>�ԕi�O�Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi�O�Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlRetOuterTax
        {
            get { return _ttlRetOuterTax; }
            set { _ttlRetOuterTax = value; }
        }

        /// public propaty name  :  TtlRetInnerTax
        /// <summary>�ԕi���Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԕi���Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlRetInnerTax
        {
            get { return _ttlRetInnerTax; }
            set { _ttlRetInnerTax = value; }
        }

        /// public propaty name  :  ThisSalesPricDis
        /// <summary>���񔄏�l�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�l�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPricDis
        {
            get { return _thisSalesPricDis; }
            set { _thisSalesPricDis = value; }
        }

        /// public propaty name  :  ThisSalesPrcTaxDis
        /// <summary>���񔄏�l������Ńv���p�e�B</summary>
        /// <value>���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񔄏�l������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisSalesPrcTaxDis
        {
            get { return _thisSalesPrcTaxDis; }
            set { _thisSalesPrcTaxDis = value; }
        }

        /// public propaty name  :  TtlItdedDisOutTax
        /// <summary>�l���O�őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedDisOutTax
        {
            get { return _ttlItdedDisOutTax; }
            set { _ttlItdedDisOutTax = value; }
        }

        /// public propaty name  :  TtlItdedDisInTax
        /// <summary>�l�����őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedDisInTax
        {
            get { return _ttlItdedDisInTax; }
            set { _ttlItdedDisInTax = value; }
        }

        /// public propaty name  :  TtlItdedDisTaxFree
        /// <summary>�l����ېőΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedDisTaxFree
        {
            get { return _ttlItdedDisTaxFree; }
            set { _ttlItdedDisTaxFree = value; }
        }

        /// public propaty name  :  TtlDisOuterTax
        /// <summary>�l���O�Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���O�Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlDisOuterTax
        {
            get { return _ttlDisOuterTax; }
            set { _ttlDisOuterTax = value; }
        }

        /// public propaty name  :  TtlDisInnerTax
        /// <summary>�l�����Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlDisInnerTax
        {
            get { return _ttlDisInnerTax; }
            set { _ttlDisInnerTax = value; }
        }

        /// public propaty name  :  BalanceAdjust
        /// <summary>�c�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BalanceAdjust
        {
            get { return _balanceAdjust; }
            set { _balanceAdjust = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
        /// <value>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  ConsTaxRate
        /// <summary>����ŗ��v���p�e�B</summary>
        /// <value>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>�[�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  AfCalDemandPrice
        /// <summary>�v�Z�㐿�����z�v���p�e�B</summary>
        /// <value>���񕪂̐������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�Z�㐿�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AfCalDemandPrice
        {
            get { return _afCalDemandPrice; }
            set { _afCalDemandPrice = value; }
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

        /// public propaty name  :  CAddUpUpdExecDate
        /// <summary>�����X�V���s�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CAddUpUpdExecDate
        {
            get { return _cAddUpUpdExecDate; }
            set { _cAddUpUpdExecDate = value; }
        }

        /// public propaty name  :  CAddUpUpdExecDateJpFormal
        /// <summary>�����X�V���s�N���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CAddUpUpdExecDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateJpInFormal
        /// <summary>�����X�V���s�N���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CAddUpUpdExecDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateAdFormal
        /// <summary>�����X�V���s�N���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CAddUpUpdExecDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  CAddUpUpdExecDateAdInFormal
        /// <summary>�����X�V���s�N���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CAddUpUpdExecDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _cAddUpUpdExecDate); }
            set { }
        }

        /// public propaty name  :  SaleslSlipCount
        /// <summary>����`�[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SaleslSlipCount
        {
            get { return _saleslSlipCount; }
            set { _saleslSlipCount = value; }
        }

        /// public propaty name  :  BillPrintDate
        /// <summary>���������s���v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �������𔭍s�����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BillPrintDate
        {
            get { return _billPrintDate; }
            set { _billPrintDate = value; }
        }

        /// public propaty name  :  StartCAddUpUpdDate
        /// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StartCAddUpUpdDate
        {
            get { return _startCAddUpUpdDate; }
            set { _startCAddUpUpdDate = value; }
        }

        /// public propaty name  :  StartCAddUpUpdDateJpFormal
        /// <summary>�����X�V�J�n�N���� �a��v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCAddUpUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateJpInFormal
        /// <summary>�����X�V�J�n�N���� �a��(��)�v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCAddUpUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateAdFormal
        /// <summary>�����X�V�J�n�N���� ����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCAddUpUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  StartCAddUpUpdDateAdInFormal
        /// <summary>�����X�V�J�n�N���� ����(��)�v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartCAddUpUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _startCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDate
        /// <summary>�O������X�V�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O������X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastCAddUpUpdDate
        {
            get { return _lastCAddUpUpdDate; }
            set { _lastCAddUpUpdDate = value; }
        }

        /// public propaty name  :  LastCAddUpUpdDateJpFormal
        /// <summary>�O������X�V�N���� �a��v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O������X�V�N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastCAddUpUpdDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateJpInFormal
        /// <summary>�O������X�V�N���� �a��(��)�v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O������X�V�N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastCAddUpUpdDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateAdFormal
        /// <summary>�O������X�V�N���� ����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O������X�V�N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastCAddUpUpdDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  LastCAddUpUpdDateAdInFormal
        /// <summary>�O������X�V�N���� ����(��)�v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O������X�V�N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastCAddUpUpdDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastCAddUpUpdDate); }
            set { }
        }

        /// public propaty name  :  ExpectedDepositDate
        /// <summary>�����\����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ExpectedDepositDate
        {
            get { return _expectedDepositDate; }
            set { _expectedDepositDate = value; }
        }

        /// public propaty name  :  ExpectedDepositDateJpFormal
        /// <summary>�����\��� �a��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\��� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExpectedDepositDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _expectedDepositDate); }
            set { }
        }

        /// public propaty name  :  ExpectedDepositDateJpInFormal
        /// <summary>�����\��� �a��(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\��� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExpectedDepositDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _expectedDepositDate); }
            set { }
        }

        /// public propaty name  :  ExpectedDepositDateAdFormal
        /// <summary>�����\��� ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\��� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExpectedDepositDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _expectedDepositDate); }
            set { }
        }

        /// public propaty name  :  ExpectedDepositDateAdInFormal
        /// <summary>�����\��� ����(��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����\��� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ExpectedDepositDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _expectedDepositDate); }
            set { }
        }

        /// public propaty name  :  CollectCond
        /// <summary>��������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  StartDateSpan
        /// <summary>���t�͈́i�J�n�j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���t�͈́i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   �蓮�Œǉ�</br>
        /// </remarks>
        public Int32 StartDateSpan
        {
            get { return _startDateSpan; }
            set { _startDateSpan = value; }
        }

        /// public propaty name  :  EndDateSpan
        /// <summary>���t�͈́i�I���j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���t�͈́i�I���j�v���p�e�B</br>
        /// <br>Programer        :   �蓮�Œǉ�</br>
        /// </remarks>
        public Int32 EndDateSpan
        {
            get { return _endDateSpan; }
            set { _endDateSpan = value; }
        }

        /// public propaty name  :  ThisTimeDmdDepo
        /// <summary>����������z�i�a����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����������z�i�a����j�v���p�e�B</br>
        /// <br>Programer        :   �蓮�Œǉ�</br>
        /// </remarks>
        public Int64 ThisTimeDmdDepo
        {
            get { return _thisTimeDmdDepo; }
            set { _thisTimeDmdDepo = value; }
        }

        /// public propaty name  :  ThisTimeFeeDmdDepo
        /// <summary>����萔���z�i�a����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����萔���z�i�a����j�v���p�e�B</br>
        /// <br>Programer        :   �蓮�Œǉ�</br>
        /// </remarks>
        public Int64 ThisTimeFeeDmdDepo
        {
            get { return _thisTimeFeeDmdDepo; }
            set { _thisTimeFeeDmdDepo = value; }
        }

        /// public propaty name  :  ThisTimeDisDmdDepo
        /// <summary>����l���z�i�a����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���z�i�a����j�v���p�e�B</br>
        /// <br>Programer        :   �蓮�Œǉ�</br>
        /// </remarks>
        public Int64 ThisTimeDisDmdDepo
        {
            get { return _thisTimeDisDmdDepo; }
            set { _thisTimeDisDmdDepo = value; }
        }

        /// public propaty name  :  ThisTimeDmdNrmlTtl
        /// <summary>��������v�i�ʏ�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v�i�ʏ�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDmdNrmlTtl
        {
            get { return _thisTimeDmdNrmlTtl; }
            set { _thisTimeDmdNrmlTtl = value; }
        }

        /// public propaty name  :  ThisTimeDmdDepoTtl
        /// <summary>��������v�i�a����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v�i�a����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDmdDepoTtl
        {
            get { return _thisTimeDmdDepoTtl; }
            set { _thisTimeDmdDepoTtl = value; }
        }

        /// public propaty name  :  ThisTimeDmdTtl
        /// <summary>��������v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDmdTtl
        {
            get { return _thisTimeDmdTtl; }
            set { _thisTimeDmdTtl = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  AddUpSecName
        /// <summary>�v�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }


        /// <summary>
        /// �������Ӑ搿�����z���R���X�g���N�^
        /// </summary>
        /// <returns>DepositCustDmdPrc�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositCustDmdPrc�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DepositCustDmdPrc()
        {
        }

        /// <summary>
        /// �������Ӑ搿�����z���R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="claimCode">������R�[�h(������e�R�[�h)</param>
        /// <param name="claimName">�����於��</param>
        /// <param name="claimName2">�����於��2</param>
        /// <param name="claimSnm">�����旪��</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="addUpDate">�v��N����(YYYYMMDD ���������s�Ȃ������i������j)</param>
        /// <param name="addUpYearMonth">�v��N��(YYYYMM)</param>
        /// <param name="lastTimeDemand">�O�񐿋����z</param>
        /// <param name="thisTimeDmdNrml">����������z�i�ʏ�����j</param>
        /// <param name="thisTimeFeeDmdNrml">����萔���z�i�ʏ�����j</param>
        /// <param name="thisTimeDisDmdNrml">����l���z�i�ʏ�����j</param>
        /// <param name="thisTimeTtlBlcDmd">����J�z�c���i�����v�j(����J�z�c�����O�񐿋��z�|�����z�i�����v�j)</param>
        /// <param name="thisTimeSales">���񔄏���z</param>
        /// <param name="thisSalesTax">���񔄏�����</param>
        /// <param name="ofsThisTimeSales">���E�㍡�񔄏���z</param>
        /// <param name="ofsThisSalesTax">���E�㍡�񔄏�����</param>
        /// <param name="itdedOffsetOutTax">���E��O�őΏۊz(���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedOffsetInTax">���E����őΏۊz(���E�p�F���Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedOffsetTaxFree">���E���ېőΏۊz(���E�p�F��ېŊz�̏W�v)</param>
        /// <param name="offsetOutTax">���E��O�ŏ����(���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
        /// <param name="offsetInTax">���E����ŏ����(���E�p�F���ŏ���ł̏W�v)</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz(�����p�F�O�Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedSalesInTax">������őΏۊz(�����p�F���Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedSalesTaxFree">�����ېőΏۊz(�����p�F��ېŊz�̏W�v)</param>
        /// <param name="salesOutTax">����O�Ŋz(�����p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
        /// <param name="salesInTax">������Ŋz(�����p�F���ŏ���ł̏W�v)</param>
        /// <param name="thisSalesPricRgds">���񔄏�ԕi���z(���񔄏�ԕi���z���ԕi�O�őΏۊz�{�ԕi���őΏۊz�{�ԕi��ېőΏۊz)</param>
        /// <param name="thisSalesPrcTaxRgds">���񔄏�ԕi�����(���񔄏�ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v)</param>
        /// <param name="ttlItdedRetOutTax">�ԕi�O�őΏۊz���v</param>
        /// <param name="ttlItdedRetInTax">�ԕi���őΏۊz���v</param>
        /// <param name="ttlItdedRetTaxFree">�ԕi��ېőΏۊz���v</param>
        /// <param name="ttlRetOuterTax">�ԕi�O�Ŋz���v</param>
        /// <param name="ttlRetInnerTax">�ԕi���Ŋz���v</param>
        /// <param name="thisSalesPricDis">���񔄏�l�����z</param>
        /// <param name="thisSalesPrcTaxDis">���񔄏�l�������(���񔄏�l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v)</param>
        /// <param name="ttlItdedDisOutTax">�l���O�őΏۊz���v</param>
        /// <param name="ttlItdedDisInTax">�l�����őΏۊz���v</param>
        /// <param name="ttlItdedDisTaxFree">�l����ېőΏۊz���v</param>
        /// <param name="ttlDisOuterTax">�l���O�Ŋz���v</param>
        /// <param name="ttlDisInnerTax">�l�����Ŋz���v</param>
        /// <param name="balanceAdjust">�c�������z</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���(����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ)</param>
        /// <param name="consTaxRate">����ŗ�(�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p)</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <param name="afCalDemandPrice">�v�Z�㐿�����z(���񕪂̐������z)</param>
        /// <param name="acpOdrTtl2TmBfBlDmd">��2��O�c���i�����v�j</param>
        /// <param name="acpOdrTtl3TmBfBlDmd">��3��O�c���i�����v�j</param>
        /// <param name="cAddUpUpdExecDate">�����X�V���s�N����(YYYYMMDD)</param>
        /// <param name="saleslSlipCount">����`�[����</param>
        /// <param name="billPrintDate">���������s��("YYYYMMDD"  �������𔭍s�����N����)</param>
        /// <param name="startCAddUpUpdDate">�����X�V�J�n�N����("YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����)</param>
        /// <param name="lastCAddUpUpdDate">�O������X�V�N����("YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����)</param>
        /// <param name="expectedDepositDate">�����\���</param>
        /// <param name="collectCond">�������(10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�)</param>
        /// <param name="startDateSpan">���t�͈́i�J�n�j(YYYYMMDD)</param>
        /// <param name="endDateSpan">���t�͈́i�I���j(YYYYMMDD)</param>
        /// <param name="thisTimeDmdDepo">����������z�i�a����j</param>
        /// <param name="thisTimeFeeDmdDepo">����萔���z�i�a����j</param>
        /// <param name="thisTimeDisDmdDepo">����l���z�i�a����j</param>
        /// <param name="thisTimeDmdNrmlTtl">��������v�i�ʏ�����j</param>
        /// <param name="thisTimeDmdDepoTtl">��������v�i�a����j</param>
        /// <param name="thisTimeDmdTtl">��������v</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <returns>DepositCustDmdPrc�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositCustDmdPrc�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DepositCustDmdPrc(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimeDemand, Int64 thisTimeDmdNrml, Int64 thisTimeFeeDmdNrml, Int64 thisTimeDisDmdNrml, Int64 thisTimeTtlBlcDmd, Int64 thisTimeSales, Int64 thisSalesTax, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 itdedSalesOutTax, Int64 itdedSalesInTax, Int64 itdedSalesTaxFree, Int64 salesOutTax, Int64 salesInTax, Int64 thisSalesPricRgds, Int64 thisSalesPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisSalesPricDis, Int64 thisSalesPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 balanceAdjust, Int32 consTaxLayMethod, Double consTaxRate, Int32 fractionProcCd, Int64 afCalDemandPrice, Int64 acpOdrTtl2TmBfBlDmd, Int64 acpOdrTtl3TmBfBlDmd, DateTime cAddUpUpdExecDate, Int32 saleslSlipCount, Int32 billPrintDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, DateTime expectedDepositDate, Int32 collectCond, Int32 startDateSpan, Int32 endDateSpan, Int64 thisTimeDmdDepo, Int64 thisTimeFeeDmdDepo, Int64 thisTimeDisDmdDepo, Int64 thisTimeDmdNrmlTtl, Int64 thisTimeDmdDepoTtl, Int64 thisTimeDmdTtl, string enterpriseName, string updEmployeeName, string addUpSecName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._addUpSecCode = addUpSecCode;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this.AddUpDate = addUpDate;
            this.AddUpYearMonth = addUpYearMonth;
            this._lastTimeDemand = lastTimeDemand;
            this._thisTimeDmdNrml = thisTimeDmdNrml;
            this._thisTimeFeeDmdNrml = thisTimeFeeDmdNrml;
            this._thisTimeDisDmdNrml = thisTimeDisDmdNrml;
            this._thisTimeTtlBlcDmd = thisTimeTtlBlcDmd;
            this._thisTimeSales = thisTimeSales;
            this._thisSalesTax = thisSalesTax;
            this._ofsThisTimeSales = ofsThisTimeSales;
            this._ofsThisSalesTax = ofsThisSalesTax;
            this._itdedOffsetOutTax = itdedOffsetOutTax;
            this._itdedOffsetInTax = itdedOffsetInTax;
            this._itdedOffsetTaxFree = itdedOffsetTaxFree;
            this._offsetOutTax = offsetOutTax;
            this._offsetInTax = offsetInTax;
            this._itdedSalesOutTax = itdedSalesOutTax;
            this._itdedSalesInTax = itdedSalesInTax;
            this._itdedSalesTaxFree = itdedSalesTaxFree;
            this._salesOutTax = salesOutTax;
            this._salesInTax = salesInTax;
            this._thisSalesPricRgds = thisSalesPricRgds;
            this._thisSalesPrcTaxRgds = thisSalesPrcTaxRgds;
            this._ttlItdedRetOutTax = ttlItdedRetOutTax;
            this._ttlItdedRetInTax = ttlItdedRetInTax;
            this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
            this._ttlRetOuterTax = ttlRetOuterTax;
            this._ttlRetInnerTax = ttlRetInnerTax;
            this._thisSalesPricDis = thisSalesPricDis;
            this._thisSalesPrcTaxDis = thisSalesPrcTaxDis;
            this._ttlItdedDisOutTax = ttlItdedDisOutTax;
            this._ttlItdedDisInTax = ttlItdedDisInTax;
            this._ttlItdedDisTaxFree = ttlItdedDisTaxFree;
            this._ttlDisOuterTax = ttlDisOuterTax;
            this._ttlDisInnerTax = ttlDisInnerTax;
            this._balanceAdjust = balanceAdjust;
            this._consTaxLayMethod = consTaxLayMethod;
            this._consTaxRate = consTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._afCalDemandPrice = afCalDemandPrice;
            this._acpOdrTtl2TmBfBlDmd = acpOdrTtl2TmBfBlDmd;
            this._acpOdrTtl3TmBfBlDmd = acpOdrTtl3TmBfBlDmd;
            this.CAddUpUpdExecDate = cAddUpUpdExecDate;
            this._saleslSlipCount = saleslSlipCount;
            this._billPrintDate = billPrintDate;
            this.StartCAddUpUpdDate = startCAddUpUpdDate;
            this.LastCAddUpUpdDate = lastCAddUpUpdDate;
            this.ExpectedDepositDate = expectedDepositDate;
            this._collectCond = collectCond;
            this._startDateSpan = startDateSpan;
            this._endDateSpan = endDateSpan;
            this._thisTimeDmdDepo = thisTimeDmdDepo;
            this._thisTimeFeeDmdDepo = thisTimeFeeDmdDepo;
            this._thisTimeDisDmdDepo = thisTimeDisDmdDepo;
            this._thisTimeDmdNrmlTtl = thisTimeDmdNrmlTtl;
            this._thisTimeDmdDepoTtl = thisTimeDmdDepoTtl;
            this._thisTimeDmdTtl = thisTimeDmdTtl;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// �������Ӑ搿�����z��񕡐�����
        /// </summary>
        /// <returns>DepositCustDmdPrc�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����DepositCustDmdPrc�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DepositCustDmdPrc Clone()
        {
            return new DepositCustDmdPrc(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimeDemand, this._thisTimeDmdNrml, this._thisTimeFeeDmdNrml, this._thisTimeDisDmdNrml, this._thisTimeTtlBlcDmd, this._thisTimeSales, this._thisSalesTax, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._itdedSalesOutTax, this._itdedSalesInTax, this._itdedSalesTaxFree, this._salesOutTax, this._salesInTax, this._thisSalesPricRgds, this._thisSalesPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisSalesPricDis, this._thisSalesPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._balanceAdjust, this._consTaxLayMethod, this._consTaxRate, this._fractionProcCd, this._afCalDemandPrice, this._acpOdrTtl2TmBfBlDmd, this._acpOdrTtl3TmBfBlDmd, this._cAddUpUpdExecDate, this._saleslSlipCount, this._billPrintDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._expectedDepositDate, this._collectCond, this._startDateSpan, this._endDateSpan, this._thisTimeDmdDepo, this._thisTimeFeeDmdDepo, this._thisTimeDisDmdDepo, this._thisTimeDmdNrmlTtl, this._thisTimeDmdDepoTtl, this._thisTimeDmdTtl, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
        }

        /// <summary>
        /// �������Ӑ搿�����z����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�DepositCustDmdPrc�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositCustDmdPrc�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(DepositCustDmdPrc target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.LastTimeDemand == target.LastTimeDemand)
                 && (this.ThisTimeDmdNrml == target.ThisTimeDmdNrml)
                 && (this.ThisTimeFeeDmdNrml == target.ThisTimeFeeDmdNrml)
                 && (this.ThisTimeDisDmdNrml == target.ThisTimeDisDmdNrml)
                 && (this.ThisTimeTtlBlcDmd == target.ThisTimeTtlBlcDmd)
                 && (this.ThisTimeSales == target.ThisTimeSales)
                 && (this.ThisSalesTax == target.ThisSalesTax)
                 && (this.OfsThisTimeSales == target.OfsThisTimeSales)
                 && (this.OfsThisSalesTax == target.OfsThisSalesTax)
                 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
                 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
                 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
                 && (this.OffsetOutTax == target.OffsetOutTax)
                 && (this.OffsetInTax == target.OffsetInTax)
                 && (this.ItdedSalesOutTax == target.ItdedSalesOutTax)
                 && (this.ItdedSalesInTax == target.ItdedSalesInTax)
                 && (this.ItdedSalesTaxFree == target.ItdedSalesTaxFree)
                 && (this.SalesOutTax == target.SalesOutTax)
                 && (this.SalesInTax == target.SalesInTax)
                 && (this.ThisSalesPricRgds == target.ThisSalesPricRgds)
                 && (this.ThisSalesPrcTaxRgds == target.ThisSalesPrcTaxRgds)
                 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
                 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
                 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
                 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
                 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
                 && (this.ThisSalesPricDis == target.ThisSalesPricDis)
                 && (this.ThisSalesPrcTaxDis == target.ThisSalesPrcTaxDis)
                 && (this.TtlItdedDisOutTax == target.TtlItdedDisOutTax)
                 && (this.TtlItdedDisInTax == target.TtlItdedDisInTax)
                 && (this.TtlItdedDisTaxFree == target.TtlItdedDisTaxFree)
                 && (this.TtlDisOuterTax == target.TtlDisOuterTax)
                 && (this.TtlDisInnerTax == target.TtlDisInnerTax)
                 && (this.BalanceAdjust == target.BalanceAdjust)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.ConsTaxRate == target.ConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.AfCalDemandPrice == target.AfCalDemandPrice)
                 && (this.AcpOdrTtl2TmBfBlDmd == target.AcpOdrTtl2TmBfBlDmd)
                 && (this.AcpOdrTtl3TmBfBlDmd == target.AcpOdrTtl3TmBfBlDmd)
                 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
                 && (this.SaleslSlipCount == target.SaleslSlipCount)
                 && (this.BillPrintDate == target.BillPrintDate)
                 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
                 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
                 && (this.ExpectedDepositDate == target.ExpectedDepositDate)
                 && (this.CollectCond == target.CollectCond)
                 && (this.StartDateSpan == target.StartDateSpan)
                 && (this.EndDateSpan == target.EndDateSpan)
                 && (this.ThisTimeDmdDepo == target.ThisTimeDmdDepo)
                 && (this.ThisTimeFeeDmdDepo == target.ThisTimeFeeDmdDepo)
                 && (this.ThisTimeDisDmdDepo == target.ThisTimeDisDmdDepo)
                 && (this.ThisTimeDmdNrmlTtl == target.ThisTimeDmdNrmlTtl)
                 && (this.ThisTimeDmdDepoTtl == target.ThisTimeDmdDepoTtl)
                 && (this.ThisTimeDmdTtl == target.ThisTimeDmdTtl)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// �������Ӑ搿�����z����r����
        /// </summary>
        /// <param name="depositCustDmdPrc1">
        ///                    ��r����DepositCustDmdPrc�N���X�̃C���X�^���X
        /// </param>
        /// <param name="depositCustDmdPrc2">��r����DepositCustDmdPrc�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositCustDmdPrc�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(DepositCustDmdPrc depositCustDmdPrc1, DepositCustDmdPrc depositCustDmdPrc2)
        {
            return ((depositCustDmdPrc1.CreateDateTime == depositCustDmdPrc2.CreateDateTime)
                 && (depositCustDmdPrc1.UpdateDateTime == depositCustDmdPrc2.UpdateDateTime)
                 && (depositCustDmdPrc1.EnterpriseCode == depositCustDmdPrc2.EnterpriseCode)
                 && (depositCustDmdPrc1.FileHeaderGuid == depositCustDmdPrc2.FileHeaderGuid)
                 && (depositCustDmdPrc1.UpdEmployeeCode == depositCustDmdPrc2.UpdEmployeeCode)
                 && (depositCustDmdPrc1.UpdAssemblyId1 == depositCustDmdPrc2.UpdAssemblyId1)
                 && (depositCustDmdPrc1.UpdAssemblyId2 == depositCustDmdPrc2.UpdAssemblyId2)
                 && (depositCustDmdPrc1.LogicalDeleteCode == depositCustDmdPrc2.LogicalDeleteCode)
                 && (depositCustDmdPrc1.AddUpSecCode == depositCustDmdPrc2.AddUpSecCode)
                 && (depositCustDmdPrc1.ClaimCode == depositCustDmdPrc2.ClaimCode)
                 && (depositCustDmdPrc1.ClaimName == depositCustDmdPrc2.ClaimName)
                 && (depositCustDmdPrc1.ClaimName2 == depositCustDmdPrc2.ClaimName2)
                 && (depositCustDmdPrc1.ClaimSnm == depositCustDmdPrc2.ClaimSnm)
                 && (depositCustDmdPrc1.CustomerCode == depositCustDmdPrc2.CustomerCode)
                 && (depositCustDmdPrc1.CustomerName == depositCustDmdPrc2.CustomerName)
                 && (depositCustDmdPrc1.CustomerName2 == depositCustDmdPrc2.CustomerName2)
                 && (depositCustDmdPrc1.CustomerSnm == depositCustDmdPrc2.CustomerSnm)
                 && (depositCustDmdPrc1.AddUpDate == depositCustDmdPrc2.AddUpDate)
                 && (depositCustDmdPrc1.AddUpYearMonth == depositCustDmdPrc2.AddUpYearMonth)
                 && (depositCustDmdPrc1.LastTimeDemand == depositCustDmdPrc2.LastTimeDemand)
                 && (depositCustDmdPrc1.ThisTimeDmdNrml == depositCustDmdPrc2.ThisTimeDmdNrml)
                 && (depositCustDmdPrc1.ThisTimeFeeDmdNrml == depositCustDmdPrc2.ThisTimeFeeDmdNrml)
                 && (depositCustDmdPrc1.ThisTimeDisDmdNrml == depositCustDmdPrc2.ThisTimeDisDmdNrml)
                 && (depositCustDmdPrc1.ThisTimeTtlBlcDmd == depositCustDmdPrc2.ThisTimeTtlBlcDmd)
                 && (depositCustDmdPrc1.ThisTimeSales == depositCustDmdPrc2.ThisTimeSales)
                 && (depositCustDmdPrc1.ThisSalesTax == depositCustDmdPrc2.ThisSalesTax)
                 && (depositCustDmdPrc1.OfsThisTimeSales == depositCustDmdPrc2.OfsThisTimeSales)
                 && (depositCustDmdPrc1.OfsThisSalesTax == depositCustDmdPrc2.OfsThisSalesTax)
                 && (depositCustDmdPrc1.ItdedOffsetOutTax == depositCustDmdPrc2.ItdedOffsetOutTax)
                 && (depositCustDmdPrc1.ItdedOffsetInTax == depositCustDmdPrc2.ItdedOffsetInTax)
                 && (depositCustDmdPrc1.ItdedOffsetTaxFree == depositCustDmdPrc2.ItdedOffsetTaxFree)
                 && (depositCustDmdPrc1.OffsetOutTax == depositCustDmdPrc2.OffsetOutTax)
                 && (depositCustDmdPrc1.OffsetInTax == depositCustDmdPrc2.OffsetInTax)
                 && (depositCustDmdPrc1.ItdedSalesOutTax == depositCustDmdPrc2.ItdedSalesOutTax)
                 && (depositCustDmdPrc1.ItdedSalesInTax == depositCustDmdPrc2.ItdedSalesInTax)
                 && (depositCustDmdPrc1.ItdedSalesTaxFree == depositCustDmdPrc2.ItdedSalesTaxFree)
                 && (depositCustDmdPrc1.SalesOutTax == depositCustDmdPrc2.SalesOutTax)
                 && (depositCustDmdPrc1.SalesInTax == depositCustDmdPrc2.SalesInTax)
                 && (depositCustDmdPrc1.ThisSalesPricRgds == depositCustDmdPrc2.ThisSalesPricRgds)
                 && (depositCustDmdPrc1.ThisSalesPrcTaxRgds == depositCustDmdPrc2.ThisSalesPrcTaxRgds)
                 && (depositCustDmdPrc1.TtlItdedRetOutTax == depositCustDmdPrc2.TtlItdedRetOutTax)
                 && (depositCustDmdPrc1.TtlItdedRetInTax == depositCustDmdPrc2.TtlItdedRetInTax)
                 && (depositCustDmdPrc1.TtlItdedRetTaxFree == depositCustDmdPrc2.TtlItdedRetTaxFree)
                 && (depositCustDmdPrc1.TtlRetOuterTax == depositCustDmdPrc2.TtlRetOuterTax)
                 && (depositCustDmdPrc1.TtlRetInnerTax == depositCustDmdPrc2.TtlRetInnerTax)
                 && (depositCustDmdPrc1.ThisSalesPricDis == depositCustDmdPrc2.ThisSalesPricDis)
                 && (depositCustDmdPrc1.ThisSalesPrcTaxDis == depositCustDmdPrc2.ThisSalesPrcTaxDis)
                 && (depositCustDmdPrc1.TtlItdedDisOutTax == depositCustDmdPrc2.TtlItdedDisOutTax)
                 && (depositCustDmdPrc1.TtlItdedDisInTax == depositCustDmdPrc2.TtlItdedDisInTax)
                 && (depositCustDmdPrc1.TtlItdedDisTaxFree == depositCustDmdPrc2.TtlItdedDisTaxFree)
                 && (depositCustDmdPrc1.TtlDisOuterTax == depositCustDmdPrc2.TtlDisOuterTax)
                 && (depositCustDmdPrc1.TtlDisInnerTax == depositCustDmdPrc2.TtlDisInnerTax)
                 && (depositCustDmdPrc1.BalanceAdjust == depositCustDmdPrc2.BalanceAdjust)
                 && (depositCustDmdPrc1.ConsTaxLayMethod == depositCustDmdPrc2.ConsTaxLayMethod)
                 && (depositCustDmdPrc1.ConsTaxRate == depositCustDmdPrc2.ConsTaxRate)
                 && (depositCustDmdPrc1.FractionProcCd == depositCustDmdPrc2.FractionProcCd)
                 && (depositCustDmdPrc1.AfCalDemandPrice == depositCustDmdPrc2.AfCalDemandPrice)
                 && (depositCustDmdPrc1.AcpOdrTtl2TmBfBlDmd == depositCustDmdPrc2.AcpOdrTtl2TmBfBlDmd)
                 && (depositCustDmdPrc1.AcpOdrTtl3TmBfBlDmd == depositCustDmdPrc2.AcpOdrTtl3TmBfBlDmd)
                 && (depositCustDmdPrc1.CAddUpUpdExecDate == depositCustDmdPrc2.CAddUpUpdExecDate)
                 && (depositCustDmdPrc1.SaleslSlipCount == depositCustDmdPrc2.SaleslSlipCount)
                 && (depositCustDmdPrc1.BillPrintDate == depositCustDmdPrc2.BillPrintDate)
                 && (depositCustDmdPrc1.StartCAddUpUpdDate == depositCustDmdPrc2.StartCAddUpUpdDate)
                 && (depositCustDmdPrc1.LastCAddUpUpdDate == depositCustDmdPrc2.LastCAddUpUpdDate)
                 && (depositCustDmdPrc1.ExpectedDepositDate == depositCustDmdPrc2.ExpectedDepositDate)
                 && (depositCustDmdPrc1.CollectCond == depositCustDmdPrc2.CollectCond)
                 && (depositCustDmdPrc1.StartDateSpan == depositCustDmdPrc2.StartDateSpan)
                 && (depositCustDmdPrc1.EndDateSpan == depositCustDmdPrc2.EndDateSpan)
                 && (depositCustDmdPrc1.ThisTimeDmdDepo == depositCustDmdPrc2.ThisTimeDmdDepo)
                 && (depositCustDmdPrc1.ThisTimeFeeDmdDepo == depositCustDmdPrc2.ThisTimeFeeDmdDepo)
                 && (depositCustDmdPrc1.ThisTimeDisDmdDepo == depositCustDmdPrc2.ThisTimeDisDmdDepo)
                 && (depositCustDmdPrc1.ThisTimeDmdNrmlTtl == depositCustDmdPrc2.ThisTimeDmdNrmlTtl)
                 && (depositCustDmdPrc1.ThisTimeDmdDepoTtl == depositCustDmdPrc2.ThisTimeDmdDepoTtl)
                 && (depositCustDmdPrc1.ThisTimeDmdTtl == depositCustDmdPrc2.ThisTimeDmdTtl)
                 && (depositCustDmdPrc1.EnterpriseName == depositCustDmdPrc2.EnterpriseName)
                 && (depositCustDmdPrc1.UpdEmployeeName == depositCustDmdPrc2.UpdEmployeeName)
                 && (depositCustDmdPrc1.AddUpSecName == depositCustDmdPrc2.AddUpSecName));
        }
        /// <summary>
        /// �������Ӑ搿�����z����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�DepositCustDmdPrc�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositCustDmdPrc�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(DepositCustDmdPrc target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.LastTimeDemand != target.LastTimeDemand) resList.Add("LastTimeDemand");
            if (this.ThisTimeDmdNrml != target.ThisTimeDmdNrml) resList.Add("ThisTimeDmdNrml");
            if (this.ThisTimeFeeDmdNrml != target.ThisTimeFeeDmdNrml) resList.Add("ThisTimeFeeDmdNrml");
            if (this.ThisTimeDisDmdNrml != target.ThisTimeDisDmdNrml) resList.Add("ThisTimeDisDmdNrml");
            if (this.ThisTimeTtlBlcDmd != target.ThisTimeTtlBlcDmd) resList.Add("ThisTimeTtlBlcDmd");
            if (this.ThisTimeSales != target.ThisTimeSales) resList.Add("ThisTimeSales");
            if (this.ThisSalesTax != target.ThisSalesTax) resList.Add("ThisSalesTax");
            if (this.OfsThisTimeSales != target.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (this.OfsThisSalesTax != target.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (this.ItdedOffsetOutTax != target.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (this.ItdedOffsetInTax != target.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (this.OffsetOutTax != target.OffsetOutTax) resList.Add("OffsetOutTax");
            if (this.OffsetInTax != target.OffsetInTax) resList.Add("OffsetInTax");
            if (this.ItdedSalesOutTax != target.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (this.ItdedSalesInTax != target.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (this.ItdedSalesTaxFree != target.ItdedSalesTaxFree) resList.Add("ItdedSalesTaxFree");
            if (this.SalesOutTax != target.SalesOutTax) resList.Add("SalesOutTax");
            if (this.SalesInTax != target.SalesInTax) resList.Add("SalesInTax");
            if (this.ThisSalesPricRgds != target.ThisSalesPricRgds) resList.Add("ThisSalesPricRgds");
            if (this.ThisSalesPrcTaxRgds != target.ThisSalesPrcTaxRgds) resList.Add("ThisSalesPrcTaxRgds");
            if (this.TtlItdedRetOutTax != target.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (this.TtlItdedRetInTax != target.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (this.TtlRetOuterTax != target.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (this.TtlRetInnerTax != target.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (this.ThisSalesPricDis != target.ThisSalesPricDis) resList.Add("ThisSalesPricDis");
            if (this.ThisSalesPrcTaxDis != target.ThisSalesPrcTaxDis) resList.Add("ThisSalesPrcTaxDis");
            if (this.TtlItdedDisOutTax != target.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (this.TtlItdedDisInTax != target.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (this.TtlItdedDisTaxFree != target.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (this.TtlDisOuterTax != target.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (this.TtlDisInnerTax != target.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            if (this.BalanceAdjust != target.BalanceAdjust) resList.Add("BalanceAdjust");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.ConsTaxRate != target.ConsTaxRate) resList.Add("ConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.AfCalDemandPrice != target.AfCalDemandPrice) resList.Add("AfCalDemandPrice");
            if (this.AcpOdrTtl2TmBfBlDmd != target.AcpOdrTtl2TmBfBlDmd) resList.Add("AcpOdrTtl2TmBfBlDmd");
            if (this.AcpOdrTtl3TmBfBlDmd != target.AcpOdrTtl3TmBfBlDmd) resList.Add("AcpOdrTtl3TmBfBlDmd");
            if (this.CAddUpUpdExecDate != target.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (this.SaleslSlipCount != target.SaleslSlipCount) resList.Add("SaleslSlipCount");
            if (this.BillPrintDate != target.BillPrintDate) resList.Add("BillPrintDate");
            if (this.StartCAddUpUpdDate != target.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (this.ExpectedDepositDate != target.ExpectedDepositDate) resList.Add("ExpectedDepositDate");
            if (this.CollectCond != target.CollectCond) resList.Add("CollectCond");
            if (this.StartDateSpan != target.StartDateSpan) resList.Add("StartDateSpan");
            if (this.EndDateSpan != target.EndDateSpan) resList.Add("EndDateSpan");
            if (this.ThisTimeDmdDepo != target.ThisTimeDmdDepo) resList.Add("ThisTimeDmdDepo");
            if (this.ThisTimeFeeDmdDepo != target.ThisTimeFeeDmdDepo) resList.Add("ThisTimeFeeDmdDepo");
            if (this.ThisTimeDisDmdDepo != target.ThisTimeDisDmdDepo) resList.Add("ThisTimeDisDmdDepo");
            if (this.ThisTimeDmdNrmlTtl != target.ThisTimeDmdNrmlTtl) resList.Add("ThisTimeDmdNrmlTtl");
            if (this.ThisTimeDmdDepoTtl != target.ThisTimeDmdDepoTtl) resList.Add("ThisTimeDmdDepoTtl");
            if (this.ThisTimeDmdTtl != target.ThisTimeDmdTtl) resList.Add("ThisTimeDmdTtl");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// �������Ӑ搿�����z����r����
        /// </summary>
        /// <param name="depositCustDmdPrc1">��r����DepositCustDmdPrc�N���X�̃C���X�^���X</param>
        /// <param name="depositCustDmdPrc2">��r����DepositCustDmdPrc�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DepositCustDmdPrc�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(DepositCustDmdPrc depositCustDmdPrc1, DepositCustDmdPrc depositCustDmdPrc2)
        {
            ArrayList resList = new ArrayList();
            if (depositCustDmdPrc1.CreateDateTime != depositCustDmdPrc2.CreateDateTime) resList.Add("CreateDateTime");
            if (depositCustDmdPrc1.UpdateDateTime != depositCustDmdPrc2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (depositCustDmdPrc1.EnterpriseCode != depositCustDmdPrc2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (depositCustDmdPrc1.FileHeaderGuid != depositCustDmdPrc2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (depositCustDmdPrc1.UpdEmployeeCode != depositCustDmdPrc2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (depositCustDmdPrc1.UpdAssemblyId1 != depositCustDmdPrc2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (depositCustDmdPrc1.UpdAssemblyId2 != depositCustDmdPrc2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (depositCustDmdPrc1.LogicalDeleteCode != depositCustDmdPrc2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (depositCustDmdPrc1.AddUpSecCode != depositCustDmdPrc2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (depositCustDmdPrc1.ClaimCode != depositCustDmdPrc2.ClaimCode) resList.Add("ClaimCode");
            if (depositCustDmdPrc1.ClaimName != depositCustDmdPrc2.ClaimName) resList.Add("ClaimName");
            if (depositCustDmdPrc1.ClaimName2 != depositCustDmdPrc2.ClaimName2) resList.Add("ClaimName2");
            if (depositCustDmdPrc1.ClaimSnm != depositCustDmdPrc2.ClaimSnm) resList.Add("ClaimSnm");
            if (depositCustDmdPrc1.CustomerCode != depositCustDmdPrc2.CustomerCode) resList.Add("CustomerCode");
            if (depositCustDmdPrc1.CustomerName != depositCustDmdPrc2.CustomerName) resList.Add("CustomerName");
            if (depositCustDmdPrc1.CustomerName2 != depositCustDmdPrc2.CustomerName2) resList.Add("CustomerName2");
            if (depositCustDmdPrc1.CustomerSnm != depositCustDmdPrc2.CustomerSnm) resList.Add("CustomerSnm");
            if (depositCustDmdPrc1.AddUpDate != depositCustDmdPrc2.AddUpDate) resList.Add("AddUpDate");
            if (depositCustDmdPrc1.AddUpYearMonth != depositCustDmdPrc2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (depositCustDmdPrc1.LastTimeDemand != depositCustDmdPrc2.LastTimeDemand) resList.Add("LastTimeDemand");
            if (depositCustDmdPrc1.ThisTimeDmdNrml != depositCustDmdPrc2.ThisTimeDmdNrml) resList.Add("ThisTimeDmdNrml");
            if (depositCustDmdPrc1.ThisTimeFeeDmdNrml != depositCustDmdPrc2.ThisTimeFeeDmdNrml) resList.Add("ThisTimeFeeDmdNrml");
            if (depositCustDmdPrc1.ThisTimeDisDmdNrml != depositCustDmdPrc2.ThisTimeDisDmdNrml) resList.Add("ThisTimeDisDmdNrml");
            if (depositCustDmdPrc1.ThisTimeTtlBlcDmd != depositCustDmdPrc2.ThisTimeTtlBlcDmd) resList.Add("ThisTimeTtlBlcDmd");
            if (depositCustDmdPrc1.ThisTimeSales != depositCustDmdPrc2.ThisTimeSales) resList.Add("ThisTimeSales");
            if (depositCustDmdPrc1.ThisSalesTax != depositCustDmdPrc2.ThisSalesTax) resList.Add("ThisSalesTax");
            if (depositCustDmdPrc1.OfsThisTimeSales != depositCustDmdPrc2.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (depositCustDmdPrc1.OfsThisSalesTax != depositCustDmdPrc2.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (depositCustDmdPrc1.ItdedOffsetOutTax != depositCustDmdPrc2.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (depositCustDmdPrc1.ItdedOffsetInTax != depositCustDmdPrc2.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (depositCustDmdPrc1.ItdedOffsetTaxFree != depositCustDmdPrc2.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (depositCustDmdPrc1.OffsetOutTax != depositCustDmdPrc2.OffsetOutTax) resList.Add("OffsetOutTax");
            if (depositCustDmdPrc1.OffsetInTax != depositCustDmdPrc2.OffsetInTax) resList.Add("OffsetInTax");
            if (depositCustDmdPrc1.ItdedSalesOutTax != depositCustDmdPrc2.ItdedSalesOutTax) resList.Add("ItdedSalesOutTax");
            if (depositCustDmdPrc1.ItdedSalesInTax != depositCustDmdPrc2.ItdedSalesInTax) resList.Add("ItdedSalesInTax");
            if (depositCustDmdPrc1.ItdedSalesTaxFree != depositCustDmdPrc2.ItdedSalesTaxFree) resList.Add("ItdedSalesTaxFree");
            if (depositCustDmdPrc1.SalesOutTax != depositCustDmdPrc2.SalesOutTax) resList.Add("SalesOutTax");
            if (depositCustDmdPrc1.SalesInTax != depositCustDmdPrc2.SalesInTax) resList.Add("SalesInTax");
            if (depositCustDmdPrc1.ThisSalesPricRgds != depositCustDmdPrc2.ThisSalesPricRgds) resList.Add("ThisSalesPricRgds");
            if (depositCustDmdPrc1.ThisSalesPrcTaxRgds != depositCustDmdPrc2.ThisSalesPrcTaxRgds) resList.Add("ThisSalesPrcTaxRgds");
            if (depositCustDmdPrc1.TtlItdedRetOutTax != depositCustDmdPrc2.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (depositCustDmdPrc1.TtlItdedRetInTax != depositCustDmdPrc2.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (depositCustDmdPrc1.TtlItdedRetTaxFree != depositCustDmdPrc2.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (depositCustDmdPrc1.TtlRetOuterTax != depositCustDmdPrc2.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (depositCustDmdPrc1.TtlRetInnerTax != depositCustDmdPrc2.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (depositCustDmdPrc1.ThisSalesPricDis != depositCustDmdPrc2.ThisSalesPricDis) resList.Add("ThisSalesPricDis");
            if (depositCustDmdPrc1.ThisSalesPrcTaxDis != depositCustDmdPrc2.ThisSalesPrcTaxDis) resList.Add("ThisSalesPrcTaxDis");
            if (depositCustDmdPrc1.TtlItdedDisOutTax != depositCustDmdPrc2.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (depositCustDmdPrc1.TtlItdedDisInTax != depositCustDmdPrc2.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (depositCustDmdPrc1.TtlItdedDisTaxFree != depositCustDmdPrc2.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (depositCustDmdPrc1.TtlDisOuterTax != depositCustDmdPrc2.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (depositCustDmdPrc1.TtlDisInnerTax != depositCustDmdPrc2.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            if (depositCustDmdPrc1.BalanceAdjust != depositCustDmdPrc2.BalanceAdjust) resList.Add("BalanceAdjust");
            if (depositCustDmdPrc1.ConsTaxLayMethod != depositCustDmdPrc2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (depositCustDmdPrc1.ConsTaxRate != depositCustDmdPrc2.ConsTaxRate) resList.Add("ConsTaxRate");
            if (depositCustDmdPrc1.FractionProcCd != depositCustDmdPrc2.FractionProcCd) resList.Add("FractionProcCd");
            if (depositCustDmdPrc1.AfCalDemandPrice != depositCustDmdPrc2.AfCalDemandPrice) resList.Add("AfCalDemandPrice");
            if (depositCustDmdPrc1.AcpOdrTtl2TmBfBlDmd != depositCustDmdPrc2.AcpOdrTtl2TmBfBlDmd) resList.Add("AcpOdrTtl2TmBfBlDmd");
            if (depositCustDmdPrc1.AcpOdrTtl3TmBfBlDmd != depositCustDmdPrc2.AcpOdrTtl3TmBfBlDmd) resList.Add("AcpOdrTtl3TmBfBlDmd");
            if (depositCustDmdPrc1.CAddUpUpdExecDate != depositCustDmdPrc2.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (depositCustDmdPrc1.SaleslSlipCount != depositCustDmdPrc2.SaleslSlipCount) resList.Add("SaleslSlipCount");
            if (depositCustDmdPrc1.BillPrintDate != depositCustDmdPrc2.BillPrintDate) resList.Add("BillPrintDate");
            if (depositCustDmdPrc1.StartCAddUpUpdDate != depositCustDmdPrc2.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (depositCustDmdPrc1.LastCAddUpUpdDate != depositCustDmdPrc2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (depositCustDmdPrc1.ExpectedDepositDate != depositCustDmdPrc2.ExpectedDepositDate) resList.Add("ExpectedDepositDate");
            if (depositCustDmdPrc1.CollectCond != depositCustDmdPrc2.CollectCond) resList.Add("CollectCond");
            if (depositCustDmdPrc1.StartDateSpan != depositCustDmdPrc2.StartDateSpan) resList.Add("StartDateSpan");
            if (depositCustDmdPrc1.EndDateSpan != depositCustDmdPrc2.EndDateSpan) resList.Add("EndDateSpan");
            if (depositCustDmdPrc1.ThisTimeDmdDepo != depositCustDmdPrc2.ThisTimeDmdDepo) resList.Add("ThisTimeDmdDepo");
            if (depositCustDmdPrc1.ThisTimeFeeDmdDepo != depositCustDmdPrc2.ThisTimeFeeDmdDepo) resList.Add("ThisTimeFeeDmdDepo");
            if (depositCustDmdPrc1.ThisTimeDisDmdDepo != depositCustDmdPrc2.ThisTimeDisDmdDepo) resList.Add("ThisTimeDisDmdDepo");
            if (depositCustDmdPrc1.ThisTimeDmdNrmlTtl != depositCustDmdPrc2.ThisTimeDmdNrmlTtl) resList.Add("ThisTimeDmdNrmlTtl");
            if (depositCustDmdPrc1.ThisTimeDmdDepoTtl != depositCustDmdPrc2.ThisTimeDmdDepoTtl) resList.Add("ThisTimeDmdDepoTtl");
            if (depositCustDmdPrc1.ThisTimeDmdTtl != depositCustDmdPrc2.ThisTimeDmdTtl) resList.Add("ThisTimeDmdTtl");
            if (depositCustDmdPrc1.EnterpriseName != depositCustDmdPrc2.EnterpriseName) resList.Add("EnterpriseName");
            if (depositCustDmdPrc1.UpdEmployeeName != depositCustDmdPrc2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (depositCustDmdPrc1.AddUpSecName != depositCustDmdPrc2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}
