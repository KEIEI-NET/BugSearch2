using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustAccRecWork
    /// <summary>
    ///                      ���Ӑ攄�|���z���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ攄�|���z���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/06/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustAccRecWork : IFileHeader
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
        /// <remarks>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�O�񔄊|���z</summary>
        private Int64 _lastTimeAccRec;

        /// <summary>����萔���z�i�ʏ�����j</summary>
        private Int64 _thisTimeFeeDmdNrml;

        /// <summary>����l���z�i�ʏ�����j</summary>
        private Int64 _thisTimeDisDmdNrml;

        /// <summary>����������z�i�ʏ�����j</summary>
        /// <remarks>�����z�̍��v���z</remarks>
        private Int64 _thisTimeDmdNrml;

        /// <summary>����J�z�c���i���|�v�j</summary>
        /// <remarks>����J�z�c�����O�񔄊|���z�|��������z���v�i�ʏ�����j</remarks>
        private Int64 _thisTimeTtlBlcAcc;

        /// <summary>���E�㍡�񔄏���z</summary>
        /// <remarks>���E���ʁ@�u���E��F***�v�̒l���������z�ƂȂ�</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>���E�㍡�񔄏�����</summary>
        /// <remarks>���E����</remarks>
        private Int64 _ofsThisSalesTax;

        /// <summary>���E��O�őΏۊz</summary>
        /// <remarks>���E���ʁF�O�Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedOffsetOutTax;

        /// <summary>���E����őΏۊz</summary>
        /// <remarks>���E���ʁF���Ŋz�i�Ŕ����j�̏W�v</remarks>
        private Int64 _itdedOffsetInTax;

        /// <summary>���E���ېőΏۊz</summary>
        /// <remarks>���E���ʁF��ېŊz�̏W�v</remarks>
        private Int64 _itdedOffsetTaxFree;

        /// <summary>���E��O�ŏ����</summary>
        /// <remarks>���E���ʁF�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</remarks>
        private Int64 _offsetOutTax;

        /// <summary>���E����ŏ����</summary>
        /// <remarks>���E���ʁF���ŏ���ł̏W�v</remarks>
        private Int64 _offsetInTax;

        /// <summary>���񔄏���z</summary>
        /// <remarks>�����p�F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</remarks>
        private Int64 _thisTimeSales;

        /// <summary>���񔄏�����</summary>
        /// <remarks>�����p</remarks>
        private Int64 _thisSalesTax;

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
        /// <remarks>�����p�F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</remarks>
        private Int64 _salesInTax;

        /// <summary>���񔄏�ԕi���z</summary>
        /// <remarks>�ԕi�p�F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</remarks>
        private Int64 _thisSalesPricRgds;

        /// <summary>���񔄏�ԕi�����</summary>
        /// <remarks>�ԕi�p�F�ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
        private Int64 _thisSalesPrcTaxRgds;

        /// <summary>�ԕi�O�őΏۊz���v</summary>
        /// <remarks>�ԕi�p</remarks>
        private Int64 _ttlItdedRetOutTax;

        /// <summary>�ԕi���őΏۊz���v</summary>
        /// <remarks>�ԕi�p</remarks>
        private Int64 _ttlItdedRetInTax;

        /// <summary>�ԕi��ېőΏۊz���v</summary>
        /// <remarks>�ԕi�p</remarks>
        private Int64 _ttlItdedRetTaxFree;

        /// <summary>�ԕi�O�Ŋz���v</summary>
        /// <remarks>�ԕi�p</remarks>
        private Int64 _ttlRetOuterTax;

        /// <summary>�ԕi���Ŋz���v</summary>
        /// <remarks>�ԕi�p�F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</remarks>
        private Int64 _ttlRetInnerTax;

        /// <summary>���񔄏�l�����z</summary>
        /// <remarks>�l���p�F�Ŕ����̔���l�����z</remarks>
        private Int64 _thisSalesPricDis;

        /// <summary>���񔄏�l�������</summary>
        /// <remarks>�l���p�F�l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
        private Int64 _thisSalesPrcTaxDis;

        /// <summary>�l���O�őΏۊz���v</summary>
        /// <remarks>�l���p</remarks>
        private Int64 _ttlItdedDisOutTax;

        /// <summary>�l�����őΏۊz���v</summary>
        /// <remarks>�l���p</remarks>
        private Int64 _ttlItdedDisInTax;

        /// <summary>�l����ېőΏۊz���v</summary>
        /// <remarks>�l���p</remarks>
        private Int64 _ttlItdedDisTaxFree;

        /// <summary>�l���O�Ŋz���v</summary>
        /// <remarks>�l���p</remarks>
        private Int64 _ttlDisOuterTax;

        /// <summary>�l�����Ŋz���v</summary>
        /// <remarks>�l���p�F���ŏ��i�ԕi�̓��ŏ���Ŋz</remarks>
        private Int64 _ttlDisInnerTax;

        /// <summary>����Œ����z</summary>
        private Int64 _taxAdjust;

        /// <summary>�c�������z</summary>
        private Int64 _balanceAdjust;

        /// <summary>�v�Z�㓖�����|���z</summary>
        /// <remarks>�������̔��|���z + �J�z�z�{���񏃔�����z�{���񏃔������Ł{����Œ����z�{�c�������z</remarks>
        private Int64 _afCalTMonthAccRec;

        /// <summary>��2��O�c���i���|�v�j</summary>
        private Int64 _acpOdrTtl2TmBfAccRec;

        /// <summary>��3��O�c���i���|�v�j</summary>
        private Int64 _acpOdrTtl3TmBfAccRec;

        /// <summary>�����X�V���s�N����</summary>
        /// <remarks>YYYYMMDD�@�����X�V���s�N����</remarks>
        private DateTime _monthAddUpExpDate;

        /// <summary>�����X�V�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
        private DateTime _stMonCAddUpUpdDate;

        /// <summary>�O�񌎎��X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</remarks>
        private DateTime _laMonCAddUpUpdDate;

        /// <summary>����`�[����</summary>
        /// <remarks>����`�[�����i�|����{��������j</remarks>
        private Int32 _salesSlipCount;

        /// <summary>����œ]�ŕ���</summary>
        /// <remarks>����œ]�ŋ敪�ݒ�}�X�^���Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>����ŗ�</summary>
        /// <remarks>�ύX2007/8/22(�^,��) ����</remarks>
        private Double _consTaxRate;

        /// <summary>�[�������敪</summary>
        private Int32 _fractionProcCd;


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

        /// public propaty name  :  ResultsAddUpSecCd
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

        /// public propaty name  :  SupplierCd
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
        /// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
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

        /// public propaty name  :  SalesDate
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

        /// public propaty name  :  ThisTimeDmdNrml
        /// <summary>����������z�i�ʏ�����j�v���p�e�B</summary>
        /// <value>�����z�̍��v���z</value>
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
        /// <value>����J�z�c�����O�񔄊|���z�|��������z���v�i�ʏ�����j</value>
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
        /// <value>���E���ʁ@�u���E��F***�v�̒l���������z�ƂȂ�</value>
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
        /// <value>���E����</value>
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
        /// <value>���E���ʁF�O�Ŋz�i�Ŕ����j�̏W�v</value>
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
        /// <value>���E���ʁF���Ŋz�i�Ŕ����j�̏W�v</value>
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
        /// <value>���E���ʁF��ېŊz�̏W�v</value>
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
        /// <value>���E���ʁF�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j</value>
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
        /// <value>���E���ʁF���ŏ���ł̏W�v</value>
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

        /// public propaty name  :  ThisTimeSales
        /// <summary>���񔄏���z�v���p�e�B</summary>
        /// <value>�����p�F�l���A�ԕi���܂܂Ȃ��Ŕ����̔�����z</value>
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
        /// <value>�����p</value>
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
        /// <value>�����p�F���ŏ��i����̓��ŏ���Ŋz�i�ԕi�A�l���܂܂��j</value>
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
        /// <value>�ԕi�p�F�l�����܂܂Ȃ��Ŕ����̔���ԕi���z</value>
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
        /// <value>�ԕi�p�F�ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
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
        /// <value>�ԕi�p</value>
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
        /// <value>�ԕi�p</value>
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
        /// <value>�ԕi�p</value>
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
        /// <value>�ԕi�p</value>
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
        /// <value>�ԕi�p�F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</value>
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
        /// <value>�l���p�F�Ŕ����̔���l�����z</value>
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
        /// <value>�l���p�F�l���O�Ŋz���v�{�l�����Ŋz���v</value>
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
        /// <value>�l���p</value>
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
        /// <value>�l���p</value>
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
        /// <value>�l���p</value>
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
        /// <value>�l���p</value>
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
        /// <value>�l���p�F���ŏ��i�ԕi�̓��ŏ���Ŋz</value>
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

        /// public propaty name  :  TaxAdjust
        /// <summary>����Œ����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Œ����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TaxAdjust
        {
            get { return _taxAdjust; }
            set { _taxAdjust = value; }
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

        /// public propaty name  :  AfCalTMonthAccRec
        /// <summary>�v�Z�㓖�����|���z�v���p�e�B</summary>
        /// <value>�������̔��|���z + �J�z�z�{���񏃔�����z�{���񏃔������Ł{����Œ����z�{�c�������z</value>
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

        /// public propaty name  :  AcpOdrTtl2TmBfAccRec
        /// <summary>��2��O�c���i���|�v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��2��O�c���i���|�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl2TmBfAccRec
        {
            get { return _acpOdrTtl2TmBfAccRec; }
            set { _acpOdrTtl2TmBfAccRec = value; }
        }

        /// public propaty name  :  AcpOdrTtl3TmBfAccRec
        /// <summary>��3��O�c���i���|�v�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��3��O�c���i���|�v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 AcpOdrTtl3TmBfAccRec
        {
            get { return _acpOdrTtl3TmBfAccRec; }
            set { _acpOdrTtl3TmBfAccRec = value; }
        }

        /// public propaty name  :  MonthAddUpExpDate
        /// <summary>�����X�V���s�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�����X�V���s�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V���s�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime MonthAddUpExpDate
        {
            get { return _monthAddUpExpDate; }
            set { _monthAddUpExpDate = value; }
        }

        /// public propaty name  :  StMonCAddUpUpdDate
        /// <summary>�����X�V�J�n�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StMonCAddUpUpdDate
        {
            get { return _stMonCAddUpUpdDate; }
            set { _stMonCAddUpUpdDate = value; }
        }

        /// public propaty name  :  LaMonCAddUpUpdDate
        /// <summary>�O�񌎎��X�V�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"  �O�񌎎��X�V�ΏۂƂȂ����N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񌎎��X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LaMonCAddUpUpdDate
        {
            get { return _laMonCAddUpUpdDate; }
            set { _laMonCAddUpUpdDate = value; }
        }

        /// public propaty name  :  SalesSlipCount
        /// <summary>����`�[�����v���p�e�B</summary>
        /// <value>����`�[�����i�|����{��������j</value>
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
        /// <value>�ύX2007/8/22(�^,��) ����</value>
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


        /// <summary>
        /// ���Ӑ攄�|���z���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustAccRecWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustAccRecWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustAccRecWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CustAccRecWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CustAccRecWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CustAccRecWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustAccRecWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustAccRecWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CustAccRecWork || graph is ArrayList || graph is CustAccRecWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CustAccRecWork).FullName));

            if (graph != null && graph is CustAccRecWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustAccRecWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CustAccRecWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CustAccRecWork[])graph).Length;
            }
            else if (graph is CustAccRecWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����於��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //�����於��2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�v��N����
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //�v��N��
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //�O�񔄊|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //LastTimeAccRec
            //����萔���z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeFeeDmdNrml
            //����l���z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDisDmdNrml
            //����������z�i�ʏ�����j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeDmdNrml
            //����J�z�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeTtlBlcAcc
            //���E�㍡�񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisTimeSales
            //���E�㍡�񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //OfsThisSalesTax
            //���E��O�őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetOutTax
            //���E����őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetInTax
            //���E���ېőΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedOffsetTaxFree
            //���E��O�ŏ����
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetOutTax
            //���E����ŏ����
            serInfo.MemberInfo.Add(typeof(Int64)); //OffsetInTax
            //���񔄏���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisTimeSales
            //���񔄏�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesTax
            //����O�őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesOutTax
            //������őΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesInTax
            //�����ېőΏۊz
            serInfo.MemberInfo.Add(typeof(Int64)); //ItdedSalesTaxFree
            //����O�Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesOutTax
            //������Ŋz
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesInTax
            //���񔄏�ԕi���z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricRgds
            //���񔄏�ԕi�����
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxRgds
            //�ԕi�O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetOutTax
            //�ԕi���őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetInTax
            //�ԕi��ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedRetTaxFree
            //�ԕi�O�Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetOuterTax
            //�ԕi���Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlRetInnerTax
            //���񔄏�l�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPricDis
            //���񔄏�l�������
            serInfo.MemberInfo.Add(typeof(Int64)); //ThisSalesPrcTaxDis
            //�l���O�őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisOutTax
            //�l�����őΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisInTax
            //�l����ېőΏۊz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlItdedDisTaxFree
            //�l���O�Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisOuterTax
            //�l�����Ŋz���v
            serInfo.MemberInfo.Add(typeof(Int64)); //TtlDisInnerTax
            //����Œ����z
            serInfo.MemberInfo.Add(typeof(Int64)); //TaxAdjust
            //�c�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //BalanceAdjust
            //�v�Z�㓖�����|���z
            serInfo.MemberInfo.Add(typeof(Int64)); //AfCalTMonthAccRec
            //��2��O�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl2TmBfAccRec
            //��3��O�c���i���|�v�j
            serInfo.MemberInfo.Add(typeof(Int64)); //AcpOdrTtl3TmBfAccRec
            //�����X�V���s�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //MonthAddUpExpDate
            //�����X�V�J�n�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //StMonCAddUpUpdDate
            //�O�񌎎��X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //LaMonCAddUpUpdDate
            //����`�[����
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCount
            //����œ]�ŕ���
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //����ŗ�
            serInfo.MemberInfo.Add(typeof(Double)); //ConsTaxRate
            //�[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd


            serInfo.Serialize(writer, serInfo);
            if (graph is CustAccRecWork)
            {
                CustAccRecWork temp = (CustAccRecWork)graph;

                SetCustAccRecWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CustAccRecWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CustAccRecWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CustAccRecWork temp in lst)
                {
                    SetCustAccRecWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustAccRecWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 64;

        /// <summary>
        ///  CustAccRecWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustAccRecWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCustAccRecWork(System.IO.BinaryWriter writer, CustAccRecWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����於��
            writer.Write(temp.ClaimName);
            //�����於��2
            writer.Write(temp.ClaimName2);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�v��N����
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //�v��N��
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //�O�񔄊|���z
            writer.Write(temp.LastTimeAccRec);
            //����萔���z�i�ʏ�����j
            writer.Write(temp.ThisTimeFeeDmdNrml);
            //����l���z�i�ʏ�����j
            writer.Write(temp.ThisTimeDisDmdNrml);
            //����������z�i�ʏ�����j
            writer.Write(temp.ThisTimeDmdNrml);
            //����J�z�c���i���|�v�j
            writer.Write(temp.ThisTimeTtlBlcAcc);
            //���E�㍡�񔄏���z
            writer.Write(temp.OfsThisTimeSales);
            //���E�㍡�񔄏�����
            writer.Write(temp.OfsThisSalesTax);
            //���E��O�őΏۊz
            writer.Write(temp.ItdedOffsetOutTax);
            //���E����őΏۊz
            writer.Write(temp.ItdedOffsetInTax);
            //���E���ېőΏۊz
            writer.Write(temp.ItdedOffsetTaxFree);
            //���E��O�ŏ����
            writer.Write(temp.OffsetOutTax);
            //���E����ŏ����
            writer.Write(temp.OffsetInTax);
            //���񔄏���z
            writer.Write(temp.ThisTimeSales);
            //���񔄏�����
            writer.Write(temp.ThisSalesTax);
            //����O�őΏۊz
            writer.Write(temp.ItdedSalesOutTax);
            //������őΏۊz
            writer.Write(temp.ItdedSalesInTax);
            //�����ېőΏۊz
            writer.Write(temp.ItdedSalesTaxFree);
            //����O�Ŋz
            writer.Write(temp.SalesOutTax);
            //������Ŋz
            writer.Write(temp.SalesInTax);
            //���񔄏�ԕi���z
            writer.Write(temp.ThisSalesPricRgds);
            //���񔄏�ԕi�����
            writer.Write(temp.ThisSalesPrcTaxRgds);
            //�ԕi�O�őΏۊz���v
            writer.Write(temp.TtlItdedRetOutTax);
            //�ԕi���őΏۊz���v
            writer.Write(temp.TtlItdedRetInTax);
            //�ԕi��ېőΏۊz���v
            writer.Write(temp.TtlItdedRetTaxFree);
            //�ԕi�O�Ŋz���v
            writer.Write(temp.TtlRetOuterTax);
            //�ԕi���Ŋz���v
            writer.Write(temp.TtlRetInnerTax);
            //���񔄏�l�����z
            writer.Write(temp.ThisSalesPricDis);
            //���񔄏�l�������
            writer.Write(temp.ThisSalesPrcTaxDis);
            //�l���O�őΏۊz���v
            writer.Write(temp.TtlItdedDisOutTax);
            //�l�����őΏۊz���v
            writer.Write(temp.TtlItdedDisInTax);
            //�l����ېőΏۊz���v
            writer.Write(temp.TtlItdedDisTaxFree);
            //�l���O�Ŋz���v
            writer.Write(temp.TtlDisOuterTax);
            //�l�����Ŋz���v
            writer.Write(temp.TtlDisInnerTax);
            //����Œ����z
            writer.Write(temp.TaxAdjust);
            //�c�������z
            writer.Write(temp.BalanceAdjust);
            //�v�Z�㓖�����|���z
            writer.Write(temp.AfCalTMonthAccRec);
            //��2��O�c���i���|�v�j
            writer.Write(temp.AcpOdrTtl2TmBfAccRec);
            //��3��O�c���i���|�v�j
            writer.Write(temp.AcpOdrTtl3TmBfAccRec);
            //�����X�V���s�N����
            writer.Write((Int64)temp.MonthAddUpExpDate.Ticks);
            //�����X�V�J�n�N����
            writer.Write((Int64)temp.StMonCAddUpUpdDate.Ticks);
            //�O�񌎎��X�V�N����
            writer.Write((Int64)temp.LaMonCAddUpUpdDate.Ticks);
            //����`�[����
            writer.Write(temp.SalesSlipCount);
            //����œ]�ŕ���
            writer.Write(temp.ConsTaxLayMethod);
            //����ŗ�
            writer.Write(temp.ConsTaxRate);
            //�[�������敪
            writer.Write(temp.FractionProcCd);

        }

        /// <summary>
        ///  CustAccRecWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CustAccRecWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustAccRecWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CustAccRecWork GetCustAccRecWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CustAccRecWork temp = new CustAccRecWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����於��
            temp.ClaimName = reader.ReadString();
            //�����於��2
            temp.ClaimName2 = reader.ReadString();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�v��N����
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //�v��N��
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //�O�񔄊|���z
            temp.LastTimeAccRec = reader.ReadInt64();
            //����萔���z�i�ʏ�����j
            temp.ThisTimeFeeDmdNrml = reader.ReadInt64();
            //����l���z�i�ʏ�����j
            temp.ThisTimeDisDmdNrml = reader.ReadInt64();
            //����������z�i�ʏ�����j
            temp.ThisTimeDmdNrml = reader.ReadInt64();
            //����J�z�c���i���|�v�j
            temp.ThisTimeTtlBlcAcc = reader.ReadInt64();
            //���E�㍡�񔄏���z
            temp.OfsThisTimeSales = reader.ReadInt64();
            //���E�㍡�񔄏�����
            temp.OfsThisSalesTax = reader.ReadInt64();
            //���E��O�őΏۊz
            temp.ItdedOffsetOutTax = reader.ReadInt64();
            //���E����őΏۊz
            temp.ItdedOffsetInTax = reader.ReadInt64();
            //���E���ېőΏۊz
            temp.ItdedOffsetTaxFree = reader.ReadInt64();
            //���E��O�ŏ����
            temp.OffsetOutTax = reader.ReadInt64();
            //���E����ŏ����
            temp.OffsetInTax = reader.ReadInt64();
            //���񔄏���z
            temp.ThisTimeSales = reader.ReadInt64();
            //���񔄏�����
            temp.ThisSalesTax = reader.ReadInt64();
            //����O�őΏۊz
            temp.ItdedSalesOutTax = reader.ReadInt64();
            //������őΏۊz
            temp.ItdedSalesInTax = reader.ReadInt64();
            //�����ېőΏۊz
            temp.ItdedSalesTaxFree = reader.ReadInt64();
            //����O�Ŋz
            temp.SalesOutTax = reader.ReadInt64();
            //������Ŋz
            temp.SalesInTax = reader.ReadInt64();
            //���񔄏�ԕi���z
            temp.ThisSalesPricRgds = reader.ReadInt64();
            //���񔄏�ԕi�����
            temp.ThisSalesPrcTaxRgds = reader.ReadInt64();
            //�ԕi�O�őΏۊz���v
            temp.TtlItdedRetOutTax = reader.ReadInt64();
            //�ԕi���őΏۊz���v
            temp.TtlItdedRetInTax = reader.ReadInt64();
            //�ԕi��ېőΏۊz���v
            temp.TtlItdedRetTaxFree = reader.ReadInt64();
            //�ԕi�O�Ŋz���v
            temp.TtlRetOuterTax = reader.ReadInt64();
            //�ԕi���Ŋz���v
            temp.TtlRetInnerTax = reader.ReadInt64();
            //���񔄏�l�����z
            temp.ThisSalesPricDis = reader.ReadInt64();
            //���񔄏�l�������
            temp.ThisSalesPrcTaxDis = reader.ReadInt64();
            //�l���O�őΏۊz���v
            temp.TtlItdedDisOutTax = reader.ReadInt64();
            //�l�����őΏۊz���v
            temp.TtlItdedDisInTax = reader.ReadInt64();
            //�l����ېőΏۊz���v
            temp.TtlItdedDisTaxFree = reader.ReadInt64();
            //�l���O�Ŋz���v
            temp.TtlDisOuterTax = reader.ReadInt64();
            //�l�����Ŋz���v
            temp.TtlDisInnerTax = reader.ReadInt64();
            //����Œ����z
            temp.TaxAdjust = reader.ReadInt64();
            //�c�������z
            temp.BalanceAdjust = reader.ReadInt64();
            //�v�Z�㓖�����|���z
            temp.AfCalTMonthAccRec = reader.ReadInt64();
            //��2��O�c���i���|�v�j
            temp.AcpOdrTtl2TmBfAccRec = reader.ReadInt64();
            //��3��O�c���i���|�v�j
            temp.AcpOdrTtl3TmBfAccRec = reader.ReadInt64();
            //�����X�V���s�N����
            temp.MonthAddUpExpDate = new DateTime(reader.ReadInt64());
            //�����X�V�J�n�N����
            temp.StMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //�O�񌎎��X�V�N����
            temp.LaMonCAddUpUpdDate = new DateTime(reader.ReadInt64());
            //����`�[����
            temp.SalesSlipCount = reader.ReadInt32();
            //����œ]�ŕ���
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //����ŗ�
            temp.ConsTaxRate = reader.ReadDouble();
            //�[�������敪
            temp.FractionProcCd = reader.ReadInt32();


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
        /// <returns>CustAccRecWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustAccRecWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CustAccRecWork temp = GetCustAccRecWork(reader, serInfo);
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
                    retValue = (CustAccRecWork[])lst.ToArray(typeof(CustAccRecWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
