using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SuplierPay
    /// <summary>
    ///                      �d����x�����z�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����x�����z�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SuplierPay
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

        /// <summary>�x����R�[�h</summary>
        /// <remarks>�x����̐e�R�[�h</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        private string _payeeName = "";

        /// <summary>�x���於��2</summary>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        private string _payeeSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�x����̎q�R�[�h�i�e���R�[�h�̏ꍇ�O�Z�b�g�j</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD �x�������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�O��x�����z</summary>
        private Int64 _lastTimePayment;

        /// <summary>����萔���z�i�ʏ�x���j</summary>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>����l���z�i�ʏ�x���j</summary>
        private Int64 _thisTimeDisPayNrml;

        /// <summary>����x�����z�i�ʏ�x���j</summary>
        /// <remarks>�x���z�̍��v���z</remarks>
        private Int64 _thisTimePayNrml;

        /// <summary>����J�z�c���i�x���v�j</summary>
        /// <remarks>����J�z�c�����O��x���z �[�@����x���z���v�i�ʏ�x���j</remarks>
        private Int64 _thisTimeTtlBlcPay;

        /// <summary>���E�㍡��d�����z</summary>
        /// <remarks>���E����</remarks>
        private Int64 _ofsThisTimeSales;

        /// <summary>���E�㍡��d�������</summary>
        /// <remarks>���E����</remarks>
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

        /// <summary>����d�����z</summary>
        /// <remarks>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</remarks>
        private Int64 _thisTimeStockPrice;

        /// <summary>����d�������</summary>
        /// <remarks>����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v</remarks>
        private Int64 _thisStcPrcTax;

        /// <summary>�d���O�őΏۊz���v</summary>
        private Int64 _ttlItdedStcOutTax;

        /// <summary>�d�����őΏۊz���v</summary>
        private Int64 _ttlItdedStcInTax;

        /// <summary>�d����ېőΏۊz���v</summary>
        private Int64 _ttlItdedStcTaxFree;

        /// <summary>�d���O�Ŋz���v</summary>
        private Int64 _ttlStockOuterTax;

        /// <summary>�d�����Ŋz���v</summary>
        private Int64 _ttlStockInnerTax;

        /// <summary>����ԕi���z</summary>
        /// <remarks>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</remarks>
        private Int64 _thisStckPricRgds;

        /// <summary>����ԕi�����</summary>
        /// <remarks>����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</remarks>
        private Int64 _thisStcPrcTaxRgds;

        /// <summary>�ԕi�O�őΏۊz���v</summary>
        private Int64 _ttlItdedRetOutTax;

        /// <summary>�ԕi���őΏۊz���v</summary>
        private Int64 _ttlItdedRetInTax;

        /// <summary>�ԕi��ېőΏۊz���v</summary>
        private Int64 _ttlItdedRetTaxFree;

        /// <summary>�ԕi�O�Ŋz���v</summary>
        private Int64 _ttlRetOuterTax;

        /// <summary>�ԕi���Ŋz���v</summary>
        /// <remarks>�|�d���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</remarks>
        private Int64 _ttlRetInnerTax;

        /// <summary>����l�����z</summary>
        /// <remarks>�|�d���F�Ŕ����̎d���l�������z</remarks>
        private Int64 _thisStckPricDis;

        /// <summary>����l�������</summary>
        /// <remarks>����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</remarks>
        private Int64 _thisStcPrcTaxDis;

        /// <summary>�l���O�őΏۊz���v</summary>
        private Int64 _ttlItdedDisOutTax;

        /// <summary>�l�����őΏۊz���v</summary>
        private Int64 _ttlItdedDisInTax;

        /// <summary>�l����ېőΏۊz���v</summary>
        private Int64 _ttlItdedDisTaxFree;

        /// <summary>�l���O�Ŋz���v</summary>
        private Int64 _ttlDisOuterTax;

        /// <summary>�l�����Ŋz���v</summary>
        /// <remarks>�|�d���F���ŏ��i�l���̓��ŏ���Ŋz</remarks>
        private Int64 _ttlDisInnerTax;

        /// <summary>��������z</summary>
        /// <remarks>���E�p�d�����v</remarks>
        private Int64 _thisRecvOffset;

        /// <summary>�����摊�E�����</summary>
        /// <remarks>���E�p�d������Ł����E�p�d���`�[�O�Ŋz�{���E�p�d���`�[���Ŋz</remarks>
        private Int64 _thisRecvOffsetTax;

        /// <summary>������O�őΏۊz���v</summary>
        /// <remarks>���E�p�d���`�[�̊O�őΏۊz</remarks>
        private Int64 _thisRecvOutTax;

        /// <summary>��������őΏۊz���v</summary>
        /// <remarks>���E�p�d���`�[�̓��őΏۊz</remarks>
        private Int64 _thisRecvInTax;

        /// <summary>�������ېőΏۊz���v</summary>
        /// <remarks>���E�p�d���`�[�̔�ېőΏۊz</remarks>
        private Int64 _thisRecvTaxFree;

        /// <summary>������O�Ŋz���v</summary>
        /// <remarks>���E�p�d���`�[�O�Ŋz</remarks>
        private Int64 _thisRecvOuterTax;

        /// <summary>��������Ŋz���v</summary>
        /// <remarks>���E�p�d���`�[���Ŋz</remarks>
        private Int64 _thisRecvInnerTax;

        /// <summary>����Œ����z</summary>
        private Int64 _taxAdjust;

        /// <summary>�c�������z</summary>
        private Int64 _balanceAdjust;

        /// <summary>�d�����v�c���i�x���v�j</summary>
        /// <remarks>���񕪂̎x�����z����J�z�c���i�x���v�j�{���񏃎d�����z�{���񏃏���Ł{�c�������{����Œ����z</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>�d��2��O�c���i�x���v�j</summary>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>�d��3��O�c���i�x���v�j</summary>
        private Int64 _stockTtl3TmBfBlPay;

        /// <summary>�����X�V���s�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>�����X�V�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>�O������X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>�d���`�[����</summary>
        private Int32 _stockSlipCount;

        /// <summary>�x���\���</summary>
        /// <remarks>���񐿋����̎x���i�����j�\���</remarks>
        private DateTime _paymentSchedule;

        /// <summary>�x������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _paymentCond;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>�[�������敪�ݒ�}�X�^�Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�d�������Őŗ�</summary>
        /// <remarks>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</remarks>
        private Double _supplierConsTaxRate;

        /// <summary>�[�������敪</summary>
        private Int32 _fractionProcCd;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";

        /// <summary>�d�������œ]�ŕ�������</summary>
        /// <remarks>�`�[�P�ʁA���גP�ʁA�����P��</remarks>
        private string _suppCTaxLayMethodNm = "";


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

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// <value>�x����̐e�R�[�h</value>
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

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�x����̎q�R�[�h�i�e���R�[�h�̏ꍇ�O�Z�b�g�j</value>
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
        /// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
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
        /// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
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
        /// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
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
        /// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
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
        /// <value>YYYYMMDD �x�������s�Ȃ������i������j</value>
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

        /// public propaty name  :  LastTimePayment
        /// <summary>�O��x�����z�v���p�e�B</summary>
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

        /// public propaty name  :  ThisTimeFeePayNrml
        /// <summary>����萔���z�i�ʏ�x���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����萔���z�i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeFeePayNrml
        {
            get { return _thisTimeFeePayNrml; }
            set { _thisTimeFeePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeDisPayNrml
        /// <summary>����l���z�i�ʏ�x���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l���z�i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeDisPayNrml
        {
            get { return _thisTimeDisPayNrml; }
            set { _thisTimeDisPayNrml = value; }
        }

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>����x�����z�i�ʏ�x���j�v���p�e�B</summary>
        /// <value>�x���z�̍��v���z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����x�����z�i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimePayNrml
        {
            get { return _thisTimePayNrml; }
            set { _thisTimePayNrml = value; }
        }

        /// public propaty name  :  ThisTimeTtlBlcPay
        /// <summary>����J�z�c���i�x���v�j�v���p�e�B</summary>
        /// <value>����J�z�c�����O��x���z �[�@����x���z���v�i�ʏ�x���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����J�z�c���i�x���v�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeTtlBlcPay
        {
            get { return _thisTimeTtlBlcPay; }
            set { _thisTimeTtlBlcPay = value; }
        }

        /// public propaty name  :  OfsThisTimeSales
        /// <summary>���E�㍡��d�����z�v���p�e�B</summary>
        /// <value>���E����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡��d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 OfsThisTimeSales
        {
            get { return _ofsThisTimeSales; }
            set { _ofsThisTimeSales = value; }
        }

        /// public propaty name  :  OfsThisSalesTax
        /// <summary>���E�㍡��d������Ńv���p�e�B</summary>
        /// <value>���E����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E�㍡��d������Ńv���p�e�B</br>
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

        /// public propaty name  :  ThisTimeStockPrice
        /// <summary>����d�����z�v���p�e�B</summary>
        /// <value>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z</value>
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

        /// public propaty name  :  ThisStcPrcTax
        /// <summary>����d������Ńv���p�e�B</summary>
        /// <value>����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����d������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStcPrcTax
        {
            get { return _thisStcPrcTax; }
            set { _thisStcPrcTax = value; }
        }

        /// public propaty name  :  TtlItdedStcOutTax
        /// <summary>�d���O�őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedStcOutTax
        {
            get { return _ttlItdedStcOutTax; }
            set { _ttlItdedStcOutTax = value; }
        }

        /// public propaty name  :  TtlItdedStcInTax
        /// <summary>�d�����őΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedStcInTax
        {
            get { return _ttlItdedStcInTax; }
            set { _ttlItdedStcInTax = value; }
        }

        /// public propaty name  :  TtlItdedStcTaxFree
        /// <summary>�d����ېőΏۊz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlItdedStcTaxFree
        {
            get { return _ttlItdedStcTaxFree; }
            set { _ttlItdedStcTaxFree = value; }
        }

        /// public propaty name  :  TtlStockOuterTax
        /// <summary>�d���O�Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���O�Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlStockOuterTax
        {
            get { return _ttlStockOuterTax; }
            set { _ttlStockOuterTax = value; }
        }

        /// public propaty name  :  TtlStockInnerTax
        /// <summary>�d�����Ŋz���v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TtlStockInnerTax
        {
            get { return _ttlStockInnerTax; }
            set { _ttlStockInnerTax = value; }
        }

        /// public propaty name  :  ThisStckPricRgds
        /// <summary>����ԕi���z�v���p�e�B</summary>
        /// <value>�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z</value>
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

        /// public propaty name  :  ThisStcPrcTaxRgds
        /// <summary>����ԕi����Ńv���p�e�B</summary>
        /// <value>����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ԕi����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStcPrcTaxRgds
        {
            get { return _thisStcPrcTaxRgds; }
            set { _thisStcPrcTaxRgds = value; }
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
        /// <value>�|�d���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j</value>
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

        /// public propaty name  :  ThisStckPricDis
        /// <summary>����l�����z�v���p�e�B</summary>
        /// <value>�|�d���F�Ŕ����̎d���l�������z</value>
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

        /// public propaty name  :  ThisStcPrcTaxDis
        /// <summary>����l������Ńv���p�e�B</summary>
        /// <value>����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����l������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisStcPrcTaxDis
        {
            get { return _thisStcPrcTaxDis; }
            set { _thisStcPrcTaxDis = value; }
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
        /// <value>�|�d���F���ŏ��i�l���̓��ŏ���Ŋz</value>
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

        /// public propaty name  :  ThisRecvOffset
        /// <summary>��������z�v���p�e�B</summary>
        /// <value>���E�p�d�����v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisRecvOffset
        {
            get { return _thisRecvOffset; }
            set { _thisRecvOffset = value; }
        }

        /// public propaty name  :  ThisRecvOffsetTax
        /// <summary>�����摊�E����Ńv���p�e�B</summary>
        /// <value>���E�p�d������Ł����E�p�d���`�[�O�Ŋz�{���E�p�d���`�[���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����摊�E����Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisRecvOffsetTax
        {
            get { return _thisRecvOffsetTax; }
            set { _thisRecvOffsetTax = value; }
        }

        /// public propaty name  :  ThisRecvOutTax
        /// <summary>������O�őΏۊz���v�v���p�e�B</summary>
        /// <value>���E�p�d���`�[�̊O�őΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������O�őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisRecvOutTax
        {
            get { return _thisRecvOutTax; }
            set { _thisRecvOutTax = value; }
        }

        /// public propaty name  :  ThisRecvInTax
        /// <summary>��������őΏۊz���v�v���p�e�B</summary>
        /// <value>���E�p�d���`�[�̓��őΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������őΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisRecvInTax
        {
            get { return _thisRecvInTax; }
            set { _thisRecvInTax = value; }
        }

        /// public propaty name  :  ThisRecvTaxFree
        /// <summary>�������ېőΏۊz���v�v���p�e�B</summary>
        /// <value>���E�p�d���`�[�̔�ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ېőΏۊz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisRecvTaxFree
        {
            get { return _thisRecvTaxFree; }
            set { _thisRecvTaxFree = value; }
        }

        /// public propaty name  :  ThisRecvOuterTax
        /// <summary>������O�Ŋz���v�v���p�e�B</summary>
        /// <value>���E�p�d���`�[�O�Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������O�Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisRecvOuterTax
        {
            get { return _thisRecvOuterTax; }
            set { _thisRecvOuterTax = value; }
        }

        /// public propaty name  :  ThisRecvInnerTax
        /// <summary>��������Ŋz���v�v���p�e�B</summary>
        /// <value>���E�p�d���`�[���Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������Ŋz���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisRecvInnerTax
        {
            get { return _thisRecvInnerTax; }
            set { _thisRecvInnerTax = value; }
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

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>�d�����v�c���i�x���v�j�v���p�e�B</summary>
        /// <value>���񕪂̎x�����z����J�z�c���i�x���v�j�{���񏃎d�����z�{���񏃏���Ł{�c�������{����Œ����z</value>
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

        /// public propaty name  :  StockTtl2TmBfBlPay
        /// <summary>�d��2��O�c���i�x���v�j�v���p�e�B</summary>
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

        /// public propaty name  :  StockTtl3TmBfBlPay
        /// <summary>�d��3��O�c���i�x���v�j�v���p�e�B</summary>
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

        /// public propaty name  :  StockSlipCount
        /// <summary>�d���`�[�����v���p�e�B</summary>
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

        /// public propaty name  :  PaymentSchedule
        /// <summary>�x���\����v���p�e�B</summary>
        /// <value>���񐿋����̎x���i�����j�\���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PaymentSchedule
        {
            get { return _paymentSchedule; }
            set { _paymentSchedule = value; }
        }

        /// public propaty name  :  PaymentScheduleJpFormal
        /// <summary>�x���\��� �a��v���p�e�B</summary>
        /// <value>���񐿋����̎x���i�����j�\���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���\��� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentScheduleJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _paymentSchedule); }
            set { }
        }

        /// public propaty name  :  PaymentScheduleJpInFormal
        /// <summary>�x���\��� �a��(��)�v���p�e�B</summary>
        /// <value>���񐿋����̎x���i�����j�\���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���\��� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentScheduleJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _paymentSchedule); }
            set { }
        }

        /// public propaty name  :  PaymentScheduleAdFormal
        /// <summary>�x���\��� ����v���p�e�B</summary>
        /// <value>���񐿋����̎x���i�����j�\���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���\��� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentScheduleAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _paymentSchedule); }
            set { }
        }

        /// public propaty name  :  PaymentScheduleAdInFormal
        /// <summary>�x���\��� ����(��)�v���p�e�B</summary>
        /// <value>���񐿋����̎x���i�����j�\���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���\��� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentScheduleAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _paymentSchedule); }
            set { }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>�x�������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>�[�������敪�ݒ�}�X�^�Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SupplierConsTaxRate
        /// <summary>�d�������Őŗ��v���p�e�B</summary>
        /// <value>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������Őŗ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SupplierConsTaxRate
        {
            get { return _supplierConsTaxRate; }
            set { _supplierConsTaxRate = value; }
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

        /// public propaty name  :  SuppCTaxLayMethodNm
        /// <summary>�d�������œ]�ŕ������̃v���p�e�B</summary>
        /// <value>�`�[�P�ʁA���גP�ʁA�����P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppCTaxLayMethodNm
        {
            get { return _suppCTaxLayMethodNm; }
            set { _suppCTaxLayMethodNm = value; }
        }


        /// <summary>
        /// �d����x�����z�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SuplierPay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuplierPay()
        {
        }

        /// <summary>
        /// �d����x�����z�}�X�^�R���X�g���N�^
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
        /// <param name="payeeCode">�x����R�[�h(�x����̐e�R�[�h)</param>
        /// <param name="payeeName">�x���於��</param>
        /// <param name="payeeName2">�x���於��2</param>
        /// <param name="payeeSnm">�x���旪��</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�x����̎q�R�[�h�i�e���R�[�h�̏ꍇ�O�Z�b�g�j)</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="addUpDate">�v��N����(YYYYMMDD �x�������s�Ȃ������i������j)</param>
        /// <param name="addUpYearMonth">�v��N��(YYYYMM)</param>
        /// <param name="lastTimePayment">�O��x�����z</param>
        /// <param name="thisTimeFeePayNrml">����萔���z�i�ʏ�x���j</param>
        /// <param name="thisTimeDisPayNrml">����l���z�i�ʏ�x���j</param>
        /// <param name="thisTimePayNrml">����x�����z�i�ʏ�x���j(�x���z�̍��v���z)</param>
        /// <param name="thisTimeTtlBlcPay">����J�z�c���i�x���v�j(����J�z�c�����O��x���z �[�@����x���z���v�i�ʏ�x���j)</param>
        /// <param name="ofsThisTimeSales">���E�㍡��d�����z(���E����)</param>
        /// <param name="ofsThisSalesTax">���E�㍡��d�������(���E����)</param>
        /// <param name="itdedOffsetOutTax">���E��O�őΏۊz(���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedOffsetInTax">���E����őΏۊz(���E�p�F���Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedOffsetTaxFree">���E���ېőΏۊz(���E�p�F��ېŊz�̏W�v)</param>
        /// <param name="offsetOutTax">���E��O�ŏ����(���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
        /// <param name="offsetInTax">���E����ŏ����(���E�p�F���ŏ���ł̏W�v)</param>
        /// <param name="thisTimeStockPrice">����d�����z(�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d�����z)</param>
        /// <param name="thisStcPrcTax">����d�������(����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v)</param>
        /// <param name="ttlItdedStcOutTax">�d���O�őΏۊz���v</param>
        /// <param name="ttlItdedStcInTax">�d�����őΏۊz���v</param>
        /// <param name="ttlItdedStcTaxFree">�d����ېőΏۊz���v</param>
        /// <param name="ttlStockOuterTax">�d���O�Ŋz���v</param>
        /// <param name="ttlStockInnerTax">�d�����Ŋz���v</param>
        /// <param name="thisStckPricRgds">����ԕi���z(�|�d���F�l���A�ԕi���܂܂Ȃ� �Ŕ����̎d���ԕi���z)</param>
        /// <param name="thisStcPrcTaxRgds">����ԕi�����(����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v)</param>
        /// <param name="ttlItdedRetOutTax">�ԕi�O�őΏۊz���v</param>
        /// <param name="ttlItdedRetInTax">�ԕi���őΏۊz���v</param>
        /// <param name="ttlItdedRetTaxFree">�ԕi��ېőΏۊz���v</param>
        /// <param name="ttlRetOuterTax">�ԕi�O�Ŋz���v</param>
        /// <param name="ttlRetInnerTax">�ԕi���Ŋz���v(�|�d���F���ŏ��i�ԕi�̓��ŏ���Ŋz�i�l���܂܂��j)</param>
        /// <param name="thisStckPricDis">����l�����z(�|�d���F�Ŕ����̎d���l�������z)</param>
        /// <param name="thisStcPrcTaxDis">����l�������(����l������Ł��l���O�Ŋz���v�{�l�����Ŋz���v)</param>
        /// <param name="ttlItdedDisOutTax">�l���O�őΏۊz���v</param>
        /// <param name="ttlItdedDisInTax">�l�����őΏۊz���v</param>
        /// <param name="ttlItdedDisTaxFree">�l����ېőΏۊz���v</param>
        /// <param name="ttlDisOuterTax">�l���O�Ŋz���v</param>
        /// <param name="ttlDisInnerTax">�l�����Ŋz���v(�|�d���F���ŏ��i�l���̓��ŏ���Ŋz)</param>
        /// <param name="thisRecvOffset">��������z(���E�p�d�����v)</param>
        /// <param name="thisRecvOffsetTax">�����摊�E�����(���E�p�d������Ł����E�p�d���`�[�O�Ŋz�{���E�p�d���`�[���Ŋz)</param>
        /// <param name="thisRecvOutTax">������O�őΏۊz���v(���E�p�d���`�[�̊O�őΏۊz)</param>
        /// <param name="thisRecvInTax">��������őΏۊz���v(���E�p�d���`�[�̓��őΏۊz)</param>
        /// <param name="thisRecvTaxFree">�������ېőΏۊz���v(���E�p�d���`�[�̔�ېőΏۊz)</param>
        /// <param name="thisRecvOuterTax">������O�Ŋz���v(���E�p�d���`�[�O�Ŋz)</param>
        /// <param name="thisRecvInnerTax">��������Ŋz���v(���E�p�d���`�[���Ŋz)</param>
        /// <param name="taxAdjust">����Œ����z</param>
        /// <param name="balanceAdjust">�c�������z</param>
        /// <param name="stockTotalPayBalance">�d�����v�c���i�x���v�j(���񕪂̎x�����z����J�z�c���i�x���v�j�{���񏃎d�����z�{���񏃏���Ł{�c�������{����Œ����z)</param>
        /// <param name="stockTtl2TmBfBlPay">�d��2��O�c���i�x���v�j</param>
        /// <param name="stockTtl3TmBfBlPay">�d��3��O�c���i�x���v�j</param>
        /// <param name="cAddUpUpdExecDate">�����X�V���s�N����(YYYYMMDD)</param>
        /// <param name="startCAddUpUpdDate">�����X�V�J�n�N����("YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����)</param>
        /// <param name="lastCAddUpUpdDate">�O������X�V�N����("YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����)</param>
        /// <param name="stockSlipCount">�d���`�[����</param>
        /// <param name="paymentSchedule">�x���\���(���񐿋����̎x���i�����j�\���)</param>
        /// <param name="paymentCond">�x������(10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�)</param>
        /// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h(�[�������敪�ݒ�}�X�^�Q�� 0:�`�[�P��1:���גP��2:�������ꊇ)</param>
        /// <param name="supplierConsTaxRate">�d�������Őŗ�(�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p)</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <param name="suppCTaxLayMethodNm">�d�������œ]�ŕ�������(�`�[�P�ʁA���גP�ʁA�����P��)</param>
        /// <returns>SuplierPay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuplierPay(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 payeeCode, string payeeName, string payeeName2, string payeeSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimePayment, Int64 thisTimeFeePayNrml, Int64 thisTimeDisPayNrml, Int64 thisTimePayNrml, Int64 thisTimeTtlBlcPay, Int64 ofsThisTimeSales, Int64 ofsThisSalesTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeStockPrice, Int64 thisStcPrcTax, Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, Int64 ttlStockOuterTax, Int64 ttlStockInnerTax, Int64 thisStckPricRgds, Int64 thisStcPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int64 thisStckPricDis, Int64 thisStcPrcTaxDis, Int64 ttlItdedDisOutTax, Int64 ttlItdedDisInTax, Int64 ttlItdedDisTaxFree, Int64 ttlDisOuterTax, Int64 ttlDisInnerTax, Int64 thisRecvOffset, Int64 thisRecvOffsetTax, Int64 thisRecvOutTax, Int64 thisRecvInTax, Int64 thisRecvTaxFree, Int64 thisRecvOuterTax, Int64 thisRecvInnerTax, Int64 taxAdjust, Int64 balanceAdjust, Int64 stockTotalPayBalance, Int64 stockTtl2TmBfBlPay, Int64 stockTtl3TmBfBlPay, DateTime cAddUpUpdExecDate, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 stockSlipCount, DateTime paymentSchedule, Int32 paymentCond, Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int32 fractionProcCd, string enterpriseName, string updEmployeeName, string addUpSecName, string suppCTaxLayMethodNm)
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
            this._payeeCode = payeeCode;
            this._payeeName = payeeName;
            this._payeeName2 = payeeName2;
            this._payeeSnm = payeeSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this.AddUpDate = addUpDate;
            this.AddUpYearMonth = addUpYearMonth;
            this._lastTimePayment = lastTimePayment;
            this._thisTimeFeePayNrml = thisTimeFeePayNrml;
            this._thisTimeDisPayNrml = thisTimeDisPayNrml;
            this._thisTimePayNrml = thisTimePayNrml;
            this._thisTimeTtlBlcPay = thisTimeTtlBlcPay;
            this._ofsThisTimeSales = ofsThisTimeSales;
            this._ofsThisSalesTax = ofsThisSalesTax;
            this._itdedOffsetOutTax = itdedOffsetOutTax;
            this._itdedOffsetInTax = itdedOffsetInTax;
            this._itdedOffsetTaxFree = itdedOffsetTaxFree;
            this._offsetOutTax = offsetOutTax;
            this._offsetInTax = offsetInTax;
            this._thisTimeStockPrice = thisTimeStockPrice;
            this._thisStcPrcTax = thisStcPrcTax;
            this._ttlItdedStcOutTax = ttlItdedStcOutTax;
            this._ttlItdedStcInTax = ttlItdedStcInTax;
            this._ttlItdedStcTaxFree = ttlItdedStcTaxFree;
            this._ttlStockOuterTax = ttlStockOuterTax;
            this._ttlStockInnerTax = ttlStockInnerTax;
            this._thisStckPricRgds = thisStckPricRgds;
            this._thisStcPrcTaxRgds = thisStcPrcTaxRgds;
            this._ttlItdedRetOutTax = ttlItdedRetOutTax;
            this._ttlItdedRetInTax = ttlItdedRetInTax;
            this._ttlItdedRetTaxFree = ttlItdedRetTaxFree;
            this._ttlRetOuterTax = ttlRetOuterTax;
            this._ttlRetInnerTax = ttlRetInnerTax;
            this._thisStckPricDis = thisStckPricDis;
            this._thisStcPrcTaxDis = thisStcPrcTaxDis;
            this._ttlItdedDisOutTax = ttlItdedDisOutTax;
            this._ttlItdedDisInTax = ttlItdedDisInTax;
            this._ttlItdedDisTaxFree = ttlItdedDisTaxFree;
            this._ttlDisOuterTax = ttlDisOuterTax;
            this._ttlDisInnerTax = ttlDisInnerTax;
            this._thisRecvOffset = thisRecvOffset;
            this._thisRecvOffsetTax = thisRecvOffsetTax;
            this._thisRecvOutTax = thisRecvOutTax;
            this._thisRecvInTax = thisRecvInTax;
            this._thisRecvTaxFree = thisRecvTaxFree;
            this._thisRecvOuterTax = thisRecvOuterTax;
            this._thisRecvInnerTax = thisRecvInnerTax;
            this._taxAdjust = taxAdjust;
            this._balanceAdjust = balanceAdjust;
            this._stockTotalPayBalance = stockTotalPayBalance;
            this._stockTtl2TmBfBlPay = stockTtl2TmBfBlPay;
            this._stockTtl3TmBfBlPay = stockTtl3TmBfBlPay;
            this.CAddUpUpdExecDate = cAddUpUpdExecDate;
            this.StartCAddUpUpdDate = startCAddUpUpdDate;
            this.LastCAddUpUpdDate = lastCAddUpUpdDate;
            this._stockSlipCount = stockSlipCount;
            this.PaymentSchedule = paymentSchedule;
            this._paymentCond = paymentCond;
            this._suppCTaxLayCd = suppCTaxLayCd;
            this._supplierConsTaxRate = supplierConsTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;

        }

        /// <summary>
        /// �d����x�����z�}�X�^��������
        /// </summary>
        /// <returns>SuplierPay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SuplierPay�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuplierPay Clone()
        {
            return new SuplierPay(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._addUpDate, this._addUpYearMonth, this._lastTimePayment, this._thisTimeFeePayNrml, this._thisTimeDisPayNrml, this._thisTimePayNrml, this._thisTimeTtlBlcPay, this._ofsThisTimeSales, this._ofsThisSalesTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeStockPrice, this._thisStcPrcTax, this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, this._ttlStockOuterTax, this._ttlStockInnerTax, this._thisStckPricRgds, this._thisStcPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._thisStckPricDis, this._thisStcPrcTaxDis, this._ttlItdedDisOutTax, this._ttlItdedDisInTax, this._ttlItdedDisTaxFree, this._ttlDisOuterTax, this._ttlDisInnerTax, this._thisRecvOffset, this._thisRecvOffsetTax, this._thisRecvOutTax, this._thisRecvInTax, this._thisRecvTaxFree, this._thisRecvOuterTax, this._thisRecvInnerTax, this._taxAdjust, this._balanceAdjust, this._stockTotalPayBalance, this._stockTtl2TmBfBlPay, this._stockTtl3TmBfBlPay, this._cAddUpUpdExecDate, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._stockSlipCount, this._paymentSchedule, this._paymentCond, this._suppCTaxLayCd, this._supplierConsTaxRate, this._fractionProcCd, this._enterpriseName, this._updEmployeeName, this._addUpSecName, this._suppCTaxLayMethodNm);
        }

        /// <summary>
        /// �d����x�����z�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SuplierPay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SuplierPay target)
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
                 && (this.PayeeCode == target.PayeeCode)
                 && (this.PayeeName == target.PayeeName)
                 && (this.PayeeName2 == target.PayeeName2)
                 && (this.PayeeSnm == target.PayeeSnm)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.LastTimePayment == target.LastTimePayment)
                 && (this.ThisTimeFeePayNrml == target.ThisTimeFeePayNrml)
                 && (this.ThisTimeDisPayNrml == target.ThisTimeDisPayNrml)
                 && (this.ThisTimePayNrml == target.ThisTimePayNrml)
                 && (this.ThisTimeTtlBlcPay == target.ThisTimeTtlBlcPay)
                 && (this.OfsThisTimeSales == target.OfsThisTimeSales)
                 && (this.OfsThisSalesTax == target.OfsThisSalesTax)
                 && (this.ItdedOffsetOutTax == target.ItdedOffsetOutTax)
                 && (this.ItdedOffsetInTax == target.ItdedOffsetInTax)
                 && (this.ItdedOffsetTaxFree == target.ItdedOffsetTaxFree)
                 && (this.OffsetOutTax == target.OffsetOutTax)
                 && (this.OffsetInTax == target.OffsetInTax)
                 && (this.ThisTimeStockPrice == target.ThisTimeStockPrice)
                 && (this.ThisStcPrcTax == target.ThisStcPrcTax)
                 && (this.TtlItdedStcOutTax == target.TtlItdedStcOutTax)
                 && (this.TtlItdedStcInTax == target.TtlItdedStcInTax)
                 && (this.TtlItdedStcTaxFree == target.TtlItdedStcTaxFree)
                 && (this.TtlStockOuterTax == target.TtlStockOuterTax)
                 && (this.TtlStockInnerTax == target.TtlStockInnerTax)
                 && (this.ThisStckPricRgds == target.ThisStckPricRgds)
                 && (this.ThisStcPrcTaxRgds == target.ThisStcPrcTaxRgds)
                 && (this.TtlItdedRetOutTax == target.TtlItdedRetOutTax)
                 && (this.TtlItdedRetInTax == target.TtlItdedRetInTax)
                 && (this.TtlItdedRetTaxFree == target.TtlItdedRetTaxFree)
                 && (this.TtlRetOuterTax == target.TtlRetOuterTax)
                 && (this.TtlRetInnerTax == target.TtlRetInnerTax)
                 && (this.ThisStckPricDis == target.ThisStckPricDis)
                 && (this.ThisStcPrcTaxDis == target.ThisStcPrcTaxDis)
                 && (this.TtlItdedDisOutTax == target.TtlItdedDisOutTax)
                 && (this.TtlItdedDisInTax == target.TtlItdedDisInTax)
                 && (this.TtlItdedDisTaxFree == target.TtlItdedDisTaxFree)
                 && (this.TtlDisOuterTax == target.TtlDisOuterTax)
                 && (this.TtlDisInnerTax == target.TtlDisInnerTax)
                 && (this.ThisRecvOffset == target.ThisRecvOffset)
                 && (this.ThisRecvOffsetTax == target.ThisRecvOffsetTax)
                 && (this.ThisRecvOutTax == target.ThisRecvOutTax)
                 && (this.ThisRecvInTax == target.ThisRecvInTax)
                 && (this.ThisRecvTaxFree == target.ThisRecvTaxFree)
                 && (this.ThisRecvOuterTax == target.ThisRecvOuterTax)
                 && (this.ThisRecvInnerTax == target.ThisRecvInnerTax)
                 && (this.TaxAdjust == target.TaxAdjust)
                 && (this.BalanceAdjust == target.BalanceAdjust)
                 && (this.StockTotalPayBalance == target.StockTotalPayBalance)
                 && (this.StockTtl2TmBfBlPay == target.StockTtl2TmBfBlPay)
                 && (this.StockTtl3TmBfBlPay == target.StockTtl3TmBfBlPay)
                 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
                 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
                 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
                 && (this.StockSlipCount == target.StockSlipCount)
                 && (this.PaymentSchedule == target.PaymentSchedule)
                 && (this.PaymentCond == target.PaymentCond)
                 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
                 && (this.SupplierConsTaxRate == target.SupplierConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName)
                 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm));
        }

        /// <summary>
        /// �d����x�����z�}�X�^��r����
        /// </summary>
        /// <param name="suplierPay1">
        ///                    ��r����SuplierPay�N���X�̃C���X�^���X
        /// </param>
        /// <param name="suplierPay2">��r����SuplierPay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SuplierPay suplierPay1, SuplierPay suplierPay2)
        {
            return ((suplierPay1.CreateDateTime == suplierPay2.CreateDateTime)
                 && (suplierPay1.UpdateDateTime == suplierPay2.UpdateDateTime)
                 && (suplierPay1.EnterpriseCode == suplierPay2.EnterpriseCode)
                 && (suplierPay1.FileHeaderGuid == suplierPay2.FileHeaderGuid)
                 && (suplierPay1.UpdEmployeeCode == suplierPay2.UpdEmployeeCode)
                 && (suplierPay1.UpdAssemblyId1 == suplierPay2.UpdAssemblyId1)
                 && (suplierPay1.UpdAssemblyId2 == suplierPay2.UpdAssemblyId2)
                 && (suplierPay1.LogicalDeleteCode == suplierPay2.LogicalDeleteCode)
                 && (suplierPay1.AddUpSecCode == suplierPay2.AddUpSecCode)
                 && (suplierPay1.PayeeCode == suplierPay2.PayeeCode)
                 && (suplierPay1.PayeeName == suplierPay2.PayeeName)
                 && (suplierPay1.PayeeName2 == suplierPay2.PayeeName2)
                 && (suplierPay1.PayeeSnm == suplierPay2.PayeeSnm)
                 && (suplierPay1.CustomerCode == suplierPay2.CustomerCode)
                 && (suplierPay1.CustomerName == suplierPay2.CustomerName)
                 && (suplierPay1.CustomerName2 == suplierPay2.CustomerName2)
                 && (suplierPay1.CustomerSnm == suplierPay2.CustomerSnm)
                 && (suplierPay1.AddUpDate == suplierPay2.AddUpDate)
                 && (suplierPay1.AddUpYearMonth == suplierPay2.AddUpYearMonth)
                 && (suplierPay1.LastTimePayment == suplierPay2.LastTimePayment)
                 && (suplierPay1.ThisTimeFeePayNrml == suplierPay2.ThisTimeFeePayNrml)
                 && (suplierPay1.ThisTimeDisPayNrml == suplierPay2.ThisTimeDisPayNrml)
                 && (suplierPay1.ThisTimePayNrml == suplierPay2.ThisTimePayNrml)
                 && (suplierPay1.ThisTimeTtlBlcPay == suplierPay2.ThisTimeTtlBlcPay)
                 && (suplierPay1.OfsThisTimeSales == suplierPay2.OfsThisTimeSales)
                 && (suplierPay1.OfsThisSalesTax == suplierPay2.OfsThisSalesTax)
                 && (suplierPay1.ItdedOffsetOutTax == suplierPay2.ItdedOffsetOutTax)
                 && (suplierPay1.ItdedOffsetInTax == suplierPay2.ItdedOffsetInTax)
                 && (suplierPay1.ItdedOffsetTaxFree == suplierPay2.ItdedOffsetTaxFree)
                 && (suplierPay1.OffsetOutTax == suplierPay2.OffsetOutTax)
                 && (suplierPay1.OffsetInTax == suplierPay2.OffsetInTax)
                 && (suplierPay1.ThisTimeStockPrice == suplierPay2.ThisTimeStockPrice)
                 && (suplierPay1.ThisStcPrcTax == suplierPay2.ThisStcPrcTax)
                 && (suplierPay1.TtlItdedStcOutTax == suplierPay2.TtlItdedStcOutTax)
                 && (suplierPay1.TtlItdedStcInTax == suplierPay2.TtlItdedStcInTax)
                 && (suplierPay1.TtlItdedStcTaxFree == suplierPay2.TtlItdedStcTaxFree)
                 && (suplierPay1.TtlStockOuterTax == suplierPay2.TtlStockOuterTax)
                 && (suplierPay1.TtlStockInnerTax == suplierPay2.TtlStockInnerTax)
                 && (suplierPay1.ThisStckPricRgds == suplierPay2.ThisStckPricRgds)
                 && (suplierPay1.ThisStcPrcTaxRgds == suplierPay2.ThisStcPrcTaxRgds)
                 && (suplierPay1.TtlItdedRetOutTax == suplierPay2.TtlItdedRetOutTax)
                 && (suplierPay1.TtlItdedRetInTax == suplierPay2.TtlItdedRetInTax)
                 && (suplierPay1.TtlItdedRetTaxFree == suplierPay2.TtlItdedRetTaxFree)
                 && (suplierPay1.TtlRetOuterTax == suplierPay2.TtlRetOuterTax)
                 && (suplierPay1.TtlRetInnerTax == suplierPay2.TtlRetInnerTax)
                 && (suplierPay1.ThisStckPricDis == suplierPay2.ThisStckPricDis)
                 && (suplierPay1.ThisStcPrcTaxDis == suplierPay2.ThisStcPrcTaxDis)
                 && (suplierPay1.TtlItdedDisOutTax == suplierPay2.TtlItdedDisOutTax)
                 && (suplierPay1.TtlItdedDisInTax == suplierPay2.TtlItdedDisInTax)
                 && (suplierPay1.TtlItdedDisTaxFree == suplierPay2.TtlItdedDisTaxFree)
                 && (suplierPay1.TtlDisOuterTax == suplierPay2.TtlDisOuterTax)
                 && (suplierPay1.TtlDisInnerTax == suplierPay2.TtlDisInnerTax)
                 && (suplierPay1.ThisRecvOffset == suplierPay2.ThisRecvOffset)
                 && (suplierPay1.ThisRecvOffsetTax == suplierPay2.ThisRecvOffsetTax)
                 && (suplierPay1.ThisRecvOutTax == suplierPay2.ThisRecvOutTax)
                 && (suplierPay1.ThisRecvInTax == suplierPay2.ThisRecvInTax)
                 && (suplierPay1.ThisRecvTaxFree == suplierPay2.ThisRecvTaxFree)
                 && (suplierPay1.ThisRecvOuterTax == suplierPay2.ThisRecvOuterTax)
                 && (suplierPay1.ThisRecvInnerTax == suplierPay2.ThisRecvInnerTax)
                 && (suplierPay1.TaxAdjust == suplierPay2.TaxAdjust)
                 && (suplierPay1.BalanceAdjust == suplierPay2.BalanceAdjust)
                 && (suplierPay1.StockTotalPayBalance == suplierPay2.StockTotalPayBalance)
                 && (suplierPay1.StockTtl2TmBfBlPay == suplierPay2.StockTtl2TmBfBlPay)
                 && (suplierPay1.StockTtl3TmBfBlPay == suplierPay2.StockTtl3TmBfBlPay)
                 && (suplierPay1.CAddUpUpdExecDate == suplierPay2.CAddUpUpdExecDate)
                 && (suplierPay1.StartCAddUpUpdDate == suplierPay2.StartCAddUpUpdDate)
                 && (suplierPay1.LastCAddUpUpdDate == suplierPay2.LastCAddUpUpdDate)
                 && (suplierPay1.StockSlipCount == suplierPay2.StockSlipCount)
                 && (suplierPay1.PaymentSchedule == suplierPay2.PaymentSchedule)
                 && (suplierPay1.PaymentCond == suplierPay2.PaymentCond)
                 && (suplierPay1.SuppCTaxLayCd == suplierPay2.SuppCTaxLayCd)
                 && (suplierPay1.SupplierConsTaxRate == suplierPay2.SupplierConsTaxRate)
                 && (suplierPay1.FractionProcCd == suplierPay2.FractionProcCd)
                 && (suplierPay1.EnterpriseName == suplierPay2.EnterpriseName)
                 && (suplierPay1.UpdEmployeeName == suplierPay2.UpdEmployeeName)
                 && (suplierPay1.AddUpSecName == suplierPay2.AddUpSecName)
                 && (suplierPay1.SuppCTaxLayMethodNm == suplierPay2.SuppCTaxLayMethodNm));
        }
        /// <summary>
        /// �d����x�����z�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SuplierPay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPay�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SuplierPay target)
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
            if (this.PayeeCode != target.PayeeCode) resList.Add("PayeeCode");
            if (this.PayeeName != target.PayeeName) resList.Add("PayeeName");
            if (this.PayeeName2 != target.PayeeName2) resList.Add("PayeeName2");
            if (this.PayeeSnm != target.PayeeSnm) resList.Add("PayeeSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.LastTimePayment != target.LastTimePayment) resList.Add("LastTimePayment");
            if (this.ThisTimeFeePayNrml != target.ThisTimeFeePayNrml) resList.Add("ThisTimeFeePayNrml");
            if (this.ThisTimeDisPayNrml != target.ThisTimeDisPayNrml) resList.Add("ThisTimeDisPayNrml");
            if (this.ThisTimePayNrml != target.ThisTimePayNrml) resList.Add("ThisTimePayNrml");
            if (this.ThisTimeTtlBlcPay != target.ThisTimeTtlBlcPay) resList.Add("ThisTimeTtlBlcPay");
            if (this.OfsThisTimeSales != target.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (this.OfsThisSalesTax != target.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (this.ItdedOffsetOutTax != target.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (this.ItdedOffsetInTax != target.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (this.ItdedOffsetTaxFree != target.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (this.OffsetOutTax != target.OffsetOutTax) resList.Add("OffsetOutTax");
            if (this.OffsetInTax != target.OffsetInTax) resList.Add("OffsetInTax");
            if (this.ThisTimeStockPrice != target.ThisTimeStockPrice) resList.Add("ThisTimeStockPrice");
            if (this.ThisStcPrcTax != target.ThisStcPrcTax) resList.Add("ThisStcPrcTax");
            if (this.TtlItdedStcOutTax != target.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (this.TtlItdedStcInTax != target.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (this.TtlItdedStcTaxFree != target.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (this.TtlStockOuterTax != target.TtlStockOuterTax) resList.Add("TtlStockOuterTax");
            if (this.TtlStockInnerTax != target.TtlStockInnerTax) resList.Add("TtlStockInnerTax");
            if (this.ThisStckPricRgds != target.ThisStckPricRgds) resList.Add("ThisStckPricRgds");
            if (this.ThisStcPrcTaxRgds != target.ThisStcPrcTaxRgds) resList.Add("ThisStcPrcTaxRgds");
            if (this.TtlItdedRetOutTax != target.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (this.TtlItdedRetInTax != target.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (this.TtlItdedRetTaxFree != target.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (this.TtlRetOuterTax != target.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (this.TtlRetInnerTax != target.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (this.ThisStckPricDis != target.ThisStckPricDis) resList.Add("ThisStckPricDis");
            if (this.ThisStcPrcTaxDis != target.ThisStcPrcTaxDis) resList.Add("ThisStcPrcTaxDis");
            if (this.TtlItdedDisOutTax != target.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (this.TtlItdedDisInTax != target.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (this.TtlItdedDisTaxFree != target.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (this.TtlDisOuterTax != target.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (this.TtlDisInnerTax != target.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            if (this.ThisRecvOffset != target.ThisRecvOffset) resList.Add("ThisRecvOffset");
            if (this.ThisRecvOffsetTax != target.ThisRecvOffsetTax) resList.Add("ThisRecvOffsetTax");
            if (this.ThisRecvOutTax != target.ThisRecvOutTax) resList.Add("ThisRecvOutTax");
            if (this.ThisRecvInTax != target.ThisRecvInTax) resList.Add("ThisRecvInTax");
            if (this.ThisRecvTaxFree != target.ThisRecvTaxFree) resList.Add("ThisRecvTaxFree");
            if (this.ThisRecvOuterTax != target.ThisRecvOuterTax) resList.Add("ThisRecvOuterTax");
            if (this.ThisRecvInnerTax != target.ThisRecvInnerTax) resList.Add("ThisRecvInnerTax");
            if (this.TaxAdjust != target.TaxAdjust) resList.Add("TaxAdjust");
            if (this.BalanceAdjust != target.BalanceAdjust) resList.Add("BalanceAdjust");
            if (this.StockTotalPayBalance != target.StockTotalPayBalance) resList.Add("StockTotalPayBalance");
            if (this.StockTtl2TmBfBlPay != target.StockTtl2TmBfBlPay) resList.Add("StockTtl2TmBfBlPay");
            if (this.StockTtl3TmBfBlPay != target.StockTtl3TmBfBlPay) resList.Add("StockTtl3TmBfBlPay");
            if (this.CAddUpUpdExecDate != target.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (this.StartCAddUpUpdDate != target.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (this.StockSlipCount != target.StockSlipCount) resList.Add("StockSlipCount");
            if (this.PaymentSchedule != target.PaymentSchedule) resList.Add("PaymentSchedule");
            if (this.PaymentCond != target.PaymentCond) resList.Add("PaymentCond");
            if (this.SuppCTaxLayCd != target.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (this.SupplierConsTaxRate != target.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");

            return resList;
        }

        /// <summary>
        /// �d����x�����z�}�X�^��r����
        /// </summary>
        /// <param name="suplierPay1">��r����SuplierPay�N���X�̃C���X�^���X</param>
        /// <param name="suplierPay2">��r����SuplierPay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuplierPay�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SuplierPay suplierPay1, SuplierPay suplierPay2)
        {
            ArrayList resList = new ArrayList();
            if (suplierPay1.CreateDateTime != suplierPay2.CreateDateTime) resList.Add("CreateDateTime");
            if (suplierPay1.UpdateDateTime != suplierPay2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (suplierPay1.EnterpriseCode != suplierPay2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (suplierPay1.FileHeaderGuid != suplierPay2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (suplierPay1.UpdEmployeeCode != suplierPay2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (suplierPay1.UpdAssemblyId1 != suplierPay2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (suplierPay1.UpdAssemblyId2 != suplierPay2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (suplierPay1.LogicalDeleteCode != suplierPay2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (suplierPay1.AddUpSecCode != suplierPay2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (suplierPay1.PayeeCode != suplierPay2.PayeeCode) resList.Add("PayeeCode");
            if (suplierPay1.PayeeName != suplierPay2.PayeeName) resList.Add("PayeeName");
            if (suplierPay1.PayeeName2 != suplierPay2.PayeeName2) resList.Add("PayeeName2");
            if (suplierPay1.PayeeSnm != suplierPay2.PayeeSnm) resList.Add("PayeeSnm");
            if (suplierPay1.CustomerCode != suplierPay2.CustomerCode) resList.Add("CustomerCode");
            if (suplierPay1.CustomerName != suplierPay2.CustomerName) resList.Add("CustomerName");
            if (suplierPay1.CustomerName2 != suplierPay2.CustomerName2) resList.Add("CustomerName2");
            if (suplierPay1.CustomerSnm != suplierPay2.CustomerSnm) resList.Add("CustomerSnm");
            if (suplierPay1.AddUpDate != suplierPay2.AddUpDate) resList.Add("AddUpDate");
            if (suplierPay1.AddUpYearMonth != suplierPay2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (suplierPay1.LastTimePayment != suplierPay2.LastTimePayment) resList.Add("LastTimePayment");
            if (suplierPay1.ThisTimeFeePayNrml != suplierPay2.ThisTimeFeePayNrml) resList.Add("ThisTimeFeePayNrml");
            if (suplierPay1.ThisTimeDisPayNrml != suplierPay2.ThisTimeDisPayNrml) resList.Add("ThisTimeDisPayNrml");
            if (suplierPay1.ThisTimePayNrml != suplierPay2.ThisTimePayNrml) resList.Add("ThisTimePayNrml");
            if (suplierPay1.ThisTimeTtlBlcPay != suplierPay2.ThisTimeTtlBlcPay) resList.Add("ThisTimeTtlBlcPay");
            if (suplierPay1.OfsThisTimeSales != suplierPay2.OfsThisTimeSales) resList.Add("OfsThisTimeSales");
            if (suplierPay1.OfsThisSalesTax != suplierPay2.OfsThisSalesTax) resList.Add("OfsThisSalesTax");
            if (suplierPay1.ItdedOffsetOutTax != suplierPay2.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (suplierPay1.ItdedOffsetInTax != suplierPay2.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (suplierPay1.ItdedOffsetTaxFree != suplierPay2.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (suplierPay1.OffsetOutTax != suplierPay2.OffsetOutTax) resList.Add("OffsetOutTax");
            if (suplierPay1.OffsetInTax != suplierPay2.OffsetInTax) resList.Add("OffsetInTax");
            if (suplierPay1.ThisTimeStockPrice != suplierPay2.ThisTimeStockPrice) resList.Add("ThisTimeStockPrice");
            if (suplierPay1.ThisStcPrcTax != suplierPay2.ThisStcPrcTax) resList.Add("ThisStcPrcTax");
            if (suplierPay1.TtlItdedStcOutTax != suplierPay2.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (suplierPay1.TtlItdedStcInTax != suplierPay2.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (suplierPay1.TtlItdedStcTaxFree != suplierPay2.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (suplierPay1.TtlStockOuterTax != suplierPay2.TtlStockOuterTax) resList.Add("TtlStockOuterTax");
            if (suplierPay1.TtlStockInnerTax != suplierPay2.TtlStockInnerTax) resList.Add("TtlStockInnerTax");
            if (suplierPay1.ThisStckPricRgds != suplierPay2.ThisStckPricRgds) resList.Add("ThisStckPricRgds");
            if (suplierPay1.ThisStcPrcTaxRgds != suplierPay2.ThisStcPrcTaxRgds) resList.Add("ThisStcPrcTaxRgds");
            if (suplierPay1.TtlItdedRetOutTax != suplierPay2.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (suplierPay1.TtlItdedRetInTax != suplierPay2.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (suplierPay1.TtlItdedRetTaxFree != suplierPay2.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (suplierPay1.TtlRetOuterTax != suplierPay2.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (suplierPay1.TtlRetInnerTax != suplierPay2.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (suplierPay1.ThisStckPricDis != suplierPay2.ThisStckPricDis) resList.Add("ThisStckPricDis");
            if (suplierPay1.ThisStcPrcTaxDis != suplierPay2.ThisStcPrcTaxDis) resList.Add("ThisStcPrcTaxDis");
            if (suplierPay1.TtlItdedDisOutTax != suplierPay2.TtlItdedDisOutTax) resList.Add("TtlItdedDisOutTax");
            if (suplierPay1.TtlItdedDisInTax != suplierPay2.TtlItdedDisInTax) resList.Add("TtlItdedDisInTax");
            if (suplierPay1.TtlItdedDisTaxFree != suplierPay2.TtlItdedDisTaxFree) resList.Add("TtlItdedDisTaxFree");
            if (suplierPay1.TtlDisOuterTax != suplierPay2.TtlDisOuterTax) resList.Add("TtlDisOuterTax");
            if (suplierPay1.TtlDisInnerTax != suplierPay2.TtlDisInnerTax) resList.Add("TtlDisInnerTax");
            if (suplierPay1.ThisRecvOffset != suplierPay2.ThisRecvOffset) resList.Add("ThisRecvOffset");
            if (suplierPay1.ThisRecvOffsetTax != suplierPay2.ThisRecvOffsetTax) resList.Add("ThisRecvOffsetTax");
            if (suplierPay1.ThisRecvOutTax != suplierPay2.ThisRecvOutTax) resList.Add("ThisRecvOutTax");
            if (suplierPay1.ThisRecvInTax != suplierPay2.ThisRecvInTax) resList.Add("ThisRecvInTax");
            if (suplierPay1.ThisRecvTaxFree != suplierPay2.ThisRecvTaxFree) resList.Add("ThisRecvTaxFree");
            if (suplierPay1.ThisRecvOuterTax != suplierPay2.ThisRecvOuterTax) resList.Add("ThisRecvOuterTax");
            if (suplierPay1.ThisRecvInnerTax != suplierPay2.ThisRecvInnerTax) resList.Add("ThisRecvInnerTax");
            if (suplierPay1.TaxAdjust != suplierPay2.TaxAdjust) resList.Add("TaxAdjust");
            if (suplierPay1.BalanceAdjust != suplierPay2.BalanceAdjust) resList.Add("BalanceAdjust");
            if (suplierPay1.StockTotalPayBalance != suplierPay2.StockTotalPayBalance) resList.Add("StockTotalPayBalance");
            if (suplierPay1.StockTtl2TmBfBlPay != suplierPay2.StockTtl2TmBfBlPay) resList.Add("StockTtl2TmBfBlPay");
            if (suplierPay1.StockTtl3TmBfBlPay != suplierPay2.StockTtl3TmBfBlPay) resList.Add("StockTtl3TmBfBlPay");
            if (suplierPay1.CAddUpUpdExecDate != suplierPay2.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (suplierPay1.StartCAddUpUpdDate != suplierPay2.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (suplierPay1.LastCAddUpUpdDate != suplierPay2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (suplierPay1.StockSlipCount != suplierPay2.StockSlipCount) resList.Add("StockSlipCount");
            if (suplierPay1.PaymentSchedule != suplierPay2.PaymentSchedule) resList.Add("PaymentSchedule");
            if (suplierPay1.PaymentCond != suplierPay2.PaymentCond) resList.Add("PaymentCond");
            if (suplierPay1.SuppCTaxLayCd != suplierPay2.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (suplierPay1.SupplierConsTaxRate != suplierPay2.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (suplierPay1.FractionProcCd != suplierPay2.FractionProcCd) resList.Add("FractionProcCd");
            if (suplierPay1.EnterpriseName != suplierPay2.EnterpriseName) resList.Add("EnterpriseName");
            if (suplierPay1.UpdEmployeeName != suplierPay2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (suplierPay1.AddUpSecName != suplierPay2.AddUpSecName) resList.Add("AddUpSecName");
            if (suplierPay1.SuppCTaxLayMethodNm != suplierPay2.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");

            return resList;
        }
    }
}
