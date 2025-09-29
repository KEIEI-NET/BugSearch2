using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchSuplierPayRet
    /// <summary>
    ///                      �����p�d����x�����z�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����p�d����x�����z�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/2/8</br>
    /// <br>Genarated Date   :   2007/05/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007/5/29  �ؑ��@����</br>
    /// <br>                 :   �d����x�����z�N���X�̃��C�A�E�g��</br>
    /// <br>                 :   �ύX�ɂȂ������߁A�C��</br>
    /// <br>Update Note      :   2007/09/05  �D�c�@�E�l</br>
    /// <br>                 :   DC.NS�p�ɍ��ڒǉ�</br>
    /// <br>Update Note      :   2008/07/08  �E�@�K�j</br>
    /// <br>                 :   Partsman�p�ɕύX</br>
    /// </remarks>
    public class SearchSuplierPayRet
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

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// <summary>���Ӑ�R�[�h</summary>
        //private Int32 _customerCode;

        ///// <summary>���Ӑ於��</summary>
        //private string _customerName = "";

        ///// <summary>���Ӑ於��2</summary>
        //private string _customerName2 = "";

        ///// <summary>���Ӑ旪��</summary>
        //private string _customerSnm = "";
        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCode;

        /// <summary>�d���於��</summary>
        private string _supplierName = "";

        /// <summary>�d���於��2</summary>
        private string _supplierName2 = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// <summary>�x����R�[�h</summary>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        private string _payeeName = "";

        /// <summary>�x���於��2</summary>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        private string _payeeSnm = "";

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD �x�������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�O��x�����z</summary>
        private Int64 _lastTimePayment;

        /// <summary>����x�����z�i�ʏ�x���j</summary>
        private Int64 _thisTimePayNrml;

        /// <summary>����萔���z�i�ʏ�x���j</summary>
        private Int64 _thisTimeFeePayNrml;

        /// <summary>����l���z�i�ʏ�x���j</summary>
        private Int64 _thisTimeDisPayNrml;

        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>���񃊃x�[�g�z�i�ʏ�x���j</summary>
        private Int64 _thisTimeRbtPayNrml;
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/

        /// <summary>����J�z�c���i�x���v�j</summary>
        /// <remarks>����J�z�c�����O��x���z�|����x���z�i�x���v�j</remarks>
        private Int64 _thisTimeTtlBlcPay;

        /// <summary>���񏃎d�����z</summary>
        /// <remarks>���d�� = �d�� - �ԕi</remarks>
        private Int64 _thisNetStckPrice;

        /// <summary>���񏃎d�������</summary>
        /// <remarks>���d�� = �d�� - �ԕi</remarks>
        private Int64 _thisNetStcPrcTax;

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
        /// <remarks>����d�����z���d���O�őΏۊz�{�d�����őΏۊz�{�d����ېőΏۊz</remarks>
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
        /// <remarks>����ԕi���z���ԕi�O�őΏۊz�{�ԕi���őΏۊz�{�ԕi��ېőΏۊz</remarks>
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
        private Int64 _ttlRetInnerTax;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>�[�������敪�ݒ�}�X�^�Q�� 0:�`�[�P��1:���גP��2:�������ꊇ</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�d�������Őŗ�</summary>
        /// <remarks>�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p</remarks>
        private Double _supplierConsTaxRate;

        /// <summary>�[�������敪</summary>
        private Int32 _fractionProcCd;

        /// <summary>�d�����v�c���i�x���v�j</summary>
        /// <remarks>���񕪂̎x�����z</remarks>
        private Int64 _stockTotalPayBalance;

        /// <summary>�d��2��O�c���i�x���v�j</summary>
        private Int64 _stockTtl2TmBfBlPay;

        /// <summary>�d��3��O�c���i�x���v�j</summary>
        private Int64 _stockTtl3TmBfBlPay;

        /// <summary>�����X�V���s�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _cAddUpUpdExecDate;

        /// <summary>���Z�����ʔ�</summary>
        private Int32 _supProcNum;

        /// <summary>�����X�V�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����</remarks>
        private DateTime _startCAddUpUpdDate;

        /// <summary>�O������X�V�N����</summary>
        /// <remarks>"YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����</remarks>
        private DateTime _lastCAddUpUpdDate;

        /// <summary>���t�͈́i�J�n�j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _startDateSpan;

        /// <summary>���t�͈́i�I���j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _endDateSpan;

        /// <summary>����x���v</summary>
        /// <remarks>����x���v������x�����z(�ʏ�x��)�{����萔���z(�ʏ�x��)�{����l���z(�ʏ�x��)�{���񃊃x�[�g�z(�ʏ�x��)</remarks>
        private Int64 _thisTimePaymentMeter;

        /// <summary>���E��d���v</summary>
        /// <remarks>���E��d���v�����E��O�őΏۊz�{���E����őΏۊz�{���E���ېőΏۊz</remarks>
        private Int64 _stcMtrAfOffset;

        /// <summary>���E��d������Ōv</summary>
        /// <remarks>���E��d������Ōv�����E��O�ŏ���Ł{���E����ŏ����</remarks>
        private Int64 _stcConsTaxMtrAfOffset;

        // 2007.09.05 hikita add start ------------------------------------------>>
        /// <summary>�c�����v</summary>
        /// <remarks>�c�����v���d��3��O�c���{�d��2��O�c�� + ����J�z�c��</remarks>
        private Int64 _blnceTtl;

        /// <summary>�����c��</summary>
        /// <remarks>�����c�����c�����v + �d�����v�c��</remarks>
        private Int64 _balance;
        // 2007.09.05 hikita add end --------------------------------------------<< 

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";

        /// <summary>�d�������œ]�ŕ�������</summary>
        /// <remarks>�`�[�P�ʁA���גP�ʁA�����P��</remarks>
        private string _suppCTaxLayMethodNm = "";

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>���E�㍡��d�����z</summary>
        /// <remarks>���E����</remarks>
        private Int64 _ofsThisTimeStock;

        /// <summary>���E�㍡��d������Ŋz</summary>
        /// <remarks>���E����</remarks>
        private Int64 _ofsThisStockTax;
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

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

        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        ///// public propaty name  :  CustomerCode
        ///// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustomerCode
        //{
        //    get { return _customerCode; }
        //    set { _customerCode = value; }
        //}

        ///// public propaty name  :  CustomerName
        ///// <summary>���Ӑ於�̃v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string CustomerName
        //{
        //    get { return _customerName; }
        //    set { _customerName = value; }
        //}

        ///// public propaty name  :  CustomerName2
        ///// <summary>���Ӑ於��2�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string CustomerName2
        //{
        //    get { return _customerName2; }
        //    set { _customerName2 = value; }
        //}

        ///// public propaty name  :  CustomerSnm
        ///// <summary>���Ӑ旪�̃v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string CustomerSnm
        //{
        //    get { return _customerSnm; }
        //    set { _customerSnm = value; }
        //}
        /// public property name  :  SupplierCode
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        /// public property name  :  SupplierName
        /// <summary>�d���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於�̃v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; }
        }

        /// public property name  :  SupplierName2
        /// <summary>�d���於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於��2�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public string SupplierName2
        {
            get { return _supplierName2; }
            set { _supplierName2 = value; }
        }

        /// public property name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/07/08</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<

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

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於�̂Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����於�̂Q�v���p�e�B</br>
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

        /// public propaty name  :  ThisTimePayNrml
        /// <summary>����x�����z�i�ʏ�x���j�v���p�e�B</summary>
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

        /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  ThisTimeRbtPayNrml
        /// <summary>���񃊃x�[�g�z�i�ʏ�x���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񃊃x�[�g�z�i�ʏ�x���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimeRbtPayNrml
        {
            get { return _thisTimeRbtPayNrml; }
            set { _thisTimeRbtPayNrml = value; }
        }
           --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  ThisTimeTtlBlcPay
        /// <summary>����J�z�c���i�x���v�j�v���p�e�B</summary>
        /// <value>����J�z�c�����O��x���z�|����x���z�i�x���v�j</value>
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

        /// public propaty name  :  ThisNetStckPrice
        /// <summary>���񏃎d�����z�v���p�e�B</summary>
        /// <value>���d�� = �d�� - �ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񏃎d�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisNetStckPrice
        {
            get { return _thisNetStckPrice; }
            set { _thisNetStckPrice = value; }
        }

        /// public propaty name  :  ThisNetStcPrcTax
        /// <summary>���񏃎d������Ńv���p�e�B</summary>
        /// <value>���d�� = �d�� - �ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񏃎d������Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisNetStcPrcTax
        {
            get { return _thisNetStcPrcTax; }
            set { _thisNetStcPrcTax = value; }
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
        /// <value>����d�����z���d���O�őΏۊz�{�d�����őΏۊz�{�d����ېőΏۊz</value>
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
        /// <value>����ԕi���z���ԕi�O�őΏۊz�{�ԕi���őΏۊz�{�ԕi��ېőΏۊz</value>
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

        /// public propaty name  :  StockTotalPayBalance
        /// <summary>�d�����v�c���i�x���v�j�v���p�e�B</summary>
        /// <value>���񕪂̎x�����z</value>
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

        /// public propaty name  :  SupProcNum
        /// <summary>���Z�����ʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�����ʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupProcNum
        {
            get { return _supProcNum; }
            set { _supProcNum = value; }
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

        /// public propaty name  :  StartDateSpan
        /// <summary>���t�͈́i�J�n�j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���t�͈́i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
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
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndDateSpan
        {
            get { return _endDateSpan; }
            set { _endDateSpan = value; }
        }

        /// public propaty name  :  ThisTimePaymentMeter
        /// <summary>����x���v�v���p�e�B</summary>
        /// <value>����x���v������x�����z(�ʏ�x��)�{����萔���z(�ʏ�x��)�{����l���z(�ʏ�x��)�{���񃊃x�[�g�z(�ʏ�x��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����x���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 ThisTimePaymentMeter
        {
            get { return _thisTimePaymentMeter; }
            set { _thisTimePaymentMeter = value; }
        }

        /// public propaty name  :  StcMtrAfOffset
        /// <summary>���E��d���v�v���p�e�B</summary>
        /// <value>���E��d���v�����E��O�őΏۊz�{���E����őΏۊz�{���E���ېőΏۊz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E��d���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StcMtrAfOffset
        {
            get { return _stcMtrAfOffset; }
            set { _stcMtrAfOffset = value; }
        }

        /// public propaty name  :  StcConsTaxMtrAfOffset
        /// <summary>���E��d������Ōv�v���p�e�B</summary>
        /// <value>���E��d������Ōv�����E��O�ŏ���Ł{���E����ŏ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���E��d������Ōv�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StcConsTaxMtrAfOffset
        {
            get { return _stcConsTaxMtrAfOffset; }
            set { _stcConsTaxMtrAfOffset = value; }
        }

        /// public propaty name  :  BlnceTtl  
        /// <summary>�c�����v�v���p�e�B</summary>
        /// <value>�c�����v���d��3��O�c���{�d��2��O�c�� + �O��x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c�����v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 BlnceTtl
        {
            get { return _blnceTtl; }
            set { _blnceTtl = value; }
        }

        /// public propaty name  :  Balance  
        /// <summary>�����c���v���p�e�B</summary>
        /// <value>�����c�����c�����v + ����x�����z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Balance
        {
            get { return _balance; }
            set { _balance = value; }
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

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  OfsThisTimeStock  
        /// <summary>���E�㍡��d�����z�v���p�e�B</summary>
        /// <value>���E����</value>
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
        /// <value>���E����</value>
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
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// �����p�d����x�����z�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SearchSuplierPayRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchSuplierPayRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchSuplierPayRet()
        {
        }

        /// <summary>
        /// �����p�d����x�����z�N���X�R���X�g���N�^
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
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="supplierName">�d���於��</param>
        /// <param name="supplierName2">�d���於��2</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="payeeName">�x���於��</param>
        /// <param name="payeeName2">�x���於��2</param>
        /// <param name="payeeSnm">�x���旪��</param>
        /// <param name="addUpDate">�v��N����(YYYYMMDD �x�������s�Ȃ������i������j)</param>
        /// <param name="addUpYearMonth">�v��N��(YYYYMM)</param>
        /// <param name="lastTimePayment">�O��x�����z</param>
        /// <param name="thisTimePayNrml">����x�����z�i�ʏ�x���j</param>
        /// <param name="thisTimeFeePayNrml">����萔���z�i�ʏ�x���j</param>
        /// <param name="thisTimeDisPayNrml">����l���z�i�ʏ�x���j</param>
        /// <param name="thisTimeTtlBlcPay">����J�z�c���i�x���v�j(����J�z�c�����O��x���z�|����x���z�i�x���v�j)</param>
        /// <param name="thisNetStckPrice">���񏃎d�����z(���d�� = �d�� - �ԕi)</param>
        /// <param name="thisNetStcPrcTax">���񏃎d�������(���d�� = �d�� - �ԕi)</param>
        /// <param name="itdedOffsetOutTax">���E��O�őΏۊz(���E�p�F�O�Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedOffsetInTax">���E����őΏۊz(���E�p�F���Ŋz�i�Ŕ����j�̏W�v)</param>
        /// <param name="itdedOffsetTaxFree">���E���ېőΏۊz(���E�p�F��ېŊz�̏W�v)</param>
        /// <param name="offsetOutTax">���E��O�ŏ����(���E�p�F�O�ŏ���ł̏W�v�@�i�����]�Ŏ��́A�ېőΏۊz����Z�o�j)</param>
        /// <param name="offsetInTax">���E����ŏ����(���E�p�F���ŏ���ł̏W�v)</param>
        /// <param name="thisTimeStockPrice">����d�����z(����d�����z���d���O�őΏۊz�{�d�����őΏۊz�{�d����ېőΏۊz)</param>
        /// <param name="thisStcPrcTax">����d�������(����d������Ł��d���O�Ŋz���v�{�d�����Ŋz���v)</param>
        /// <param name="ttlItdedStcOutTax">�d���O�őΏۊz���v</param>
        /// <param name="ttlItdedStcInTax">�d�����őΏۊz���v</param>
        /// <param name="ttlItdedStcTaxFree">�d����ېőΏۊz���v</param>
        /// <param name="ttlStockOuterTax">�d���O�Ŋz���v</param>
        /// <param name="ttlStockInnerTax">�d�����Ŋz���v</param>
        /// <param name="thisStckPricRgds">����ԕi���z(����ԕi���z���ԕi�O�őΏۊz�{�ԕi���őΏۊz�{�ԕi��ېőΏۊz)</param>
        /// <param name="thisStcPrcTaxRgds">����ԕi�����(����ԕi����Ł��ԕi�O�Ŋz���v�{�ԕi���Ŋz���v)</param>
        /// <param name="ttlItdedRetOutTax">�ԕi�O�őΏۊz���v</param>
        /// <param name="ttlItdedRetInTax">�ԕi���őΏۊz���v</param>
        /// <param name="ttlItdedRetTaxFree">�ԕi��ېőΏۊz���v</param>
        /// <param name="ttlRetOuterTax">�ԕi�O�Ŋz���v</param>
        /// <param name="ttlRetInnerTax">�ԕi���Ŋz���v</param>
        /// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h(�[�������敪�ݒ�}�X�^�Q�� 0:�`�[�P��1:���גP��2:�������ꊇ)</param>
        /// <param name="supplierConsTaxRate">�d�������Őŗ�(�����]�ŏ���ł��Z�o����ꍇ�Ɏg�p)</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <param name="stockTotalPayBalance">�d�����v�c���i�x���v�j(���񕪂̎x�����z)</param>
        /// <param name="stockTtl2TmBfBlPay">�d��2��O�c���i�x���v�j</param>
        /// <param name="stockTtl3TmBfBlPay">�d��3��O�c���i�x���v�j</param>
        /// <param name="cAddUpUpdExecDate">�����X�V���s�N����(YYYYMMDD)</param>
        /// <param name="supProcNum">���Z�����ʔ�</param>
        /// <param name="startCAddUpUpdDate">�����X�V�J�n�N����("YYYYMMDD"  �����X�V�ΏۂƂȂ�J�n�N����)</param>
        /// <param name="lastCAddUpUpdDate">�O������X�V�N����("YYYYMMDD"  �O������X�V�ΏۂƂȂ����N����)</param>
        /// <param name="startDateSpan">���t�͈́i�J�n�j(YYYYMMDD)</param>
        /// <param name="endDateSpan">���t�͈́i�I���j(YYYYMMDD)</param>
        /// <param name="thisTimePaymentMeter">����x���v(����x���v������x�����z(�ʏ�x��)�{����萔���z(�ʏ�x��)�{����l���z(�ʏ�x��)�{���񃊃x�[�g�z(�ʏ�x��))</param>
        /// <param name="stcMtrAfOffset">���E��d���v(���E��d���v�����E��O�őΏۊz�{���E����őΏۊz�{���E���ېőΏۊz)</param>
        /// <param name="stcConsTaxMtrAfOffset">���E��d������Ōv(���E��d������Ōv�����E��O�ŏ���Ł{���E����ŏ����)</param>
        /// <param name="blnceTtl">�c�����v���d��3��O�c���{�d��2��O�c�� + �O��x�����z</param>
        /// <param name="balance">�����c�����c�����v + ����x�����z</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <param name="suppCTaxLayMethodNm">�d�������œ]�ŕ�������(�`�[�P�ʁA���גP�ʁA�����P��)</param>
        /// <param name="ofsThisTimeStock">���E�㍡��d�����z</param>
        /// <param name="ofsThisStockTax">���E�㍡��d������Ŋz</param>
        /// <returns>SearchSuplierPayRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchSuplierPayRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        //public SearchSuplierPayRet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 payeeCode, string payeeName, string payeeName2, string payeeSnm, DateTime addUpDate, DateTime addUpYearMonth, Int64 lastTimePayment, Int64 thisTimePayNrml, Int64 thisTimeFeePayNrml, Int64 thisTimeDisPayNrml, Int64 thisTimeRbtPayNrml, Int64 thisTimeTtlBlcPay, Int64 thisNetStckPrice, Int64 thisNetStcPrcTax, Int64 itdedOffsetOutTax, Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, Int64 offsetInTax, Int64 thisTimeStockPrice, Int64 thisStcPrcTax, Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, Int64 ttlStockOuterTax, Int64 ttlStockInnerTax, Int64 thisStckPricRgds, Int64 thisStcPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int32 fractionProcCd, Int64 stockTotalPayBalance, Int64 stockTtl2TmBfBlPay, Int64 stockTtl3TmBfBlPay, DateTime cAddUpUpdExecDate, Int32 supProcNum, DateTime startCAddUpUpdDate, DateTime lastCAddUpUpdDate, Int32 startDateSpan, Int32 endDateSpan, Int64 thisTimePaymentMeter, Int64 stcMtrAfOffset, Int64 stcConsTaxMtrAfOffset, Int64 blnceTtl, Int64 balance, string enterpriseName, string updEmployeeName, string addUpSecName, string suppCTaxLayMethodNm)
        public SearchSuplierPayRet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, 
                                   Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, 
                                   string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode,
                                   Int32 supplierCode, string supplierName, string supplierName2,
                                   string supplierSnm, Int32 payeeCode, string payeeName, 
                                   string payeeName2, string payeeSnm, DateTime addUpDate, 
                                   DateTime addUpYearMonth, Int64 lastTimePayment, Int64 thisTimePayNrml, 
                                   Int64 thisTimeFeePayNrml, Int64 thisTimeDisPayNrml, Int64 thisTimeTtlBlcPay, 
                                   Int64 thisNetStckPrice, Int64 thisNetStcPrcTax, Int64 itdedOffsetOutTax, 
                                   Int64 itdedOffsetInTax, Int64 itdedOffsetTaxFree, Int64 offsetOutTax, 
                                   Int64 offsetInTax, Int64 thisTimeStockPrice, Int64 thisStcPrcTax, 
                                   Int64 ttlItdedStcOutTax, Int64 ttlItdedStcInTax, Int64 ttlItdedStcTaxFree, 
                                   Int64 ttlStockOuterTax, Int64 ttlStockInnerTax, Int64 thisStckPricRgds, 
                                   Int64 thisStcPrcTaxRgds, Int64 ttlItdedRetOutTax, Int64 ttlItdedRetInTax, 
                                   Int64 ttlItdedRetTaxFree, Int64 ttlRetOuterTax, Int64 ttlRetInnerTax, 
                                   Int32 suppCTaxLayCd, Double supplierConsTaxRate, Int32 fractionProcCd, 
                                   Int64 stockTotalPayBalance, Int64 stockTtl2TmBfBlPay, Int64 stockTtl3TmBfBlPay, 
                                   DateTime cAddUpUpdExecDate, Int32 supProcNum, DateTime startCAddUpUpdDate, 
                                   DateTime lastCAddUpUpdDate, Int32 startDateSpan, Int32 endDateSpan, 
                                   Int64 thisTimePaymentMeter, Int64 stcMtrAfOffset, Int64 stcConsTaxMtrAfOffset, 
                                   Int64 blnceTtl, Int64 balance, string enterpriseName, 
                                   string updEmployeeName, string addUpSecName, string suppCTaxLayMethodNm,
                                   Int64 ofsThisTimeStock, Int64 ofsThisStockTax)
        // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
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
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //this._customerCode = customerCode;
            //this._customerName = customerName;
            //this._customerName2 = customerName2;
            //this._customerSnm = customerSnm;
            this._supplierCode = supplierCode;
            this._supplierName = supplierName;
            this._supplierName2 = supplierName2;
            this._supplierSnm = supplierSnm;
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            this._payeeCode = payeeCode;
            this._payeeName = payeeName;
            this._payeeName2 = payeeName2;
            this._payeeSnm = payeeSnm;
            this.AddUpDate = addUpDate;
            this.AddUpYearMonth = addUpYearMonth;
            this._lastTimePayment = lastTimePayment;
            this._thisTimePayNrml = thisTimePayNrml;
            this._thisTimeFeePayNrml = thisTimeFeePayNrml;
            this._thisTimeDisPayNrml = thisTimeDisPayNrml;
            /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
            this._thisTimeRbtPayNrml = thisTimeRbtPayNrml;
               --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            this._thisTimeTtlBlcPay = thisTimeTtlBlcPay;
            this._thisNetStckPrice = thisNetStckPrice;
            this._thisNetStcPrcTax = thisNetStcPrcTax;
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
            this._suppCTaxLayCd = suppCTaxLayCd;
            this._supplierConsTaxRate = supplierConsTaxRate;
            this._fractionProcCd = fractionProcCd;
            this._stockTotalPayBalance = stockTotalPayBalance;
            this._stockTtl2TmBfBlPay = stockTtl2TmBfBlPay;
            this._stockTtl3TmBfBlPay = stockTtl3TmBfBlPay;
            this.CAddUpUpdExecDate = cAddUpUpdExecDate;
            this._supProcNum = supProcNum;
            this.StartCAddUpUpdDate = startCAddUpUpdDate;
            this.LastCAddUpUpdDate = lastCAddUpUpdDate;
            this._startDateSpan = startDateSpan;
            this._endDateSpan = endDateSpan;
            this._thisTimePaymentMeter = thisTimePaymentMeter;
            this._stcMtrAfOffset = stcMtrAfOffset;
            this._stcConsTaxMtrAfOffset = stcConsTaxMtrAfOffset;
            this._blnceTtl = blnceTtl;
            this._balance = balance;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;
            this._ofsThisTimeStock = ofsThisTimeStock;
            this._ofsThisStockTax = ofsThisStockTax;
        }

        /// <summary>
        /// �����p�d����x�����z�N���X��������
        /// </summary>
        /// <returns>SearchSuplierPayRet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SearchSuplierPayRet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchSuplierPayRet Clone()
        {
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //return new SearchSuplierPayRet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._addUpDate, this._addUpYearMonth, this._lastTimePayment, this._thisTimePayNrml, this._thisTimeFeePayNrml, this._thisTimeDisPayNrml, this._thisTimeRbtPayNrml, this._thisTimeTtlBlcPay, this._thisNetStckPrice, this._thisNetStcPrcTax, this._itdedOffsetOutTax, this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, this._offsetInTax, this._thisTimeStockPrice, this._thisStcPrcTax, this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, this._ttlStockOuterTax, this._ttlStockInnerTax, this._thisStckPricRgds, this._thisStcPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, this._suppCTaxLayCd, this._supplierConsTaxRate, this._fractionProcCd, this._stockTotalPayBalance, this._stockTtl2TmBfBlPay, this._stockTtl3TmBfBlPay, this._cAddUpUpdExecDate, this._supProcNum, this._startCAddUpUpdDate, this._lastCAddUpUpdDate, this._startDateSpan, this._endDateSpan, this._thisTimePaymentMeter, this._stcMtrAfOffset, this._stcConsTaxMtrAfOffset, this._blnceTtl, this._balance, this._enterpriseName, this._updEmployeeName, this._addUpSecName, this._suppCTaxLayMethodNm);
            return new SearchSuplierPayRet(this._createDateTime, this._updateDateTime, this._enterpriseCode, 
                                           this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, 
                                           this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, 
                                           this._supplierCode, this._supplierName, this._supplierName2, 
                                           this._supplierSnm, this._payeeCode, this._payeeName, 
                                           this._payeeName2, this._payeeSnm, this._addUpDate, 
                                           this._addUpYearMonth, this._lastTimePayment, this._thisTimePayNrml, 
                                           this._thisTimeFeePayNrml, this._thisTimeDisPayNrml, this._thisTimeTtlBlcPay, 
                                           this._thisNetStckPrice, this._thisNetStcPrcTax, this._itdedOffsetOutTax, 
                                           this._itdedOffsetInTax, this._itdedOffsetTaxFree, this._offsetOutTax, 
                                           this._offsetInTax, this._thisTimeStockPrice, this._thisStcPrcTax, 
                                           this._ttlItdedStcOutTax, this._ttlItdedStcInTax, this._ttlItdedStcTaxFree, 
                                           this._ttlStockOuterTax, this._ttlStockInnerTax, this._thisStckPricRgds, 
                                           this._thisStcPrcTaxRgds, this._ttlItdedRetOutTax, this._ttlItdedRetInTax, 
                                           this._ttlItdedRetTaxFree, this._ttlRetOuterTax, this._ttlRetInnerTax, 
                                           this._suppCTaxLayCd, this._supplierConsTaxRate, this._fractionProcCd, 
                                           this._stockTotalPayBalance, this._stockTtl2TmBfBlPay, this._stockTtl3TmBfBlPay, 
                                           this._cAddUpUpdExecDate, this._supProcNum, this._startCAddUpUpdDate, 
                                           this._lastCAddUpUpdDate, this._startDateSpan, this._endDateSpan, 
                                           this._thisTimePaymentMeter, this._stcMtrAfOffset, this._stcConsTaxMtrAfOffset, 
                                           this._blnceTtl, this._balance, this._enterpriseName, 
                                           this._updEmployeeName, this._addUpSecName, this._suppCTaxLayMethodNm,
                                           this._ofsThisTimeStock, this._ofsThisStockTax);
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// �����p�d����x�����z�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchSuplierPayRet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchSuplierPayRet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SearchSuplierPayRet target)
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
                // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                 //&& (this.CustomerCode == target.CustomerCode)
                 //&& (this.CustomerName == target.CustomerName)
                 //&& (this.CustomerName2 == target.CustomerName2)
                 //&& (this.CustomerSnm == target.CustomerSnm)
                 && (this.SupplierCode == target.SupplierCode)
                 && (this.SupplierName == target.SupplierName)
                 && (this.SupplierName2 == target.SupplierName2)
                 && (this.SupplierSnm == target.SupplierSnm)
                // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
                 && (this.PayeeCode == target.PayeeCode)
                 && (this.PayeeName == target.PayeeName)
                 && (this.PayeeName2 == target.PayeeName2)
                 && (this.PayeeSnm == target.PayeeSnm)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.LastTimePayment == target.LastTimePayment)
                 && (this.ThisTimePayNrml == target.ThisTimePayNrml)
                 && (this.ThisTimeFeePayNrml == target.ThisTimeFeePayNrml)
                 && (this.ThisTimeDisPayNrml == target.ThisTimeDisPayNrml)
                /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
                && (this.ThisTimeRbtPayNrml == target.ThisTimeRbtPayNrml)
                   --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
                 && (this.ThisTimeTtlBlcPay == target.ThisTimeTtlBlcPay)
                 && (this.ThisNetStckPrice == target.ThisNetStckPrice)
                 && (this.ThisNetStcPrcTax == target.ThisNetStcPrcTax)
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
                 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
                 && (this.SupplierConsTaxRate == target.SupplierConsTaxRate)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.StockTotalPayBalance == target.StockTotalPayBalance)
                 && (this.StockTtl2TmBfBlPay == target.StockTtl2TmBfBlPay)
                 && (this.StockTtl3TmBfBlPay == target.StockTtl3TmBfBlPay)
                 && (this.CAddUpUpdExecDate == target.CAddUpUpdExecDate)
                 && (this.SupProcNum == target.SupProcNum)
                 && (this.StartCAddUpUpdDate == target.StartCAddUpUpdDate)
                 && (this.LastCAddUpUpdDate == target.LastCAddUpUpdDate)
                 && (this.StartDateSpan == target.StartDateSpan)
                 && (this.EndDateSpan == target.EndDateSpan)
                 && (this.ThisTimePaymentMeter == target.ThisTimePaymentMeter)
                 && (this.StcMtrAfOffset == target.StcMtrAfOffset)
                 && (this.StcConsTaxMtrAfOffset == target.StcConsTaxMtrAfOffset)
                 && (this.BlnceTtl == target.BlnceTtl)
                 && (this.Balance == target.Balance)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName)
                 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm)
                 && (this.OfsThisTimeStock == target.OfsThisTimeStock)
                 && (this.OfsThisStockTax == target.OfsThisStockTax)
                 );
        }

        /// <summary>
        /// �����p�d����x�����z�N���X��r����
        /// </summary>
        /// <param name="searchSuplierPayRet1">
        ///                    ��r����SearchSuplierPayRet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="searchSuplierPayRet2">��r����SearchSuplierPayRet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchSuplierPayRet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SearchSuplierPayRet searchSuplierPayRet1, SearchSuplierPayRet searchSuplierPayRet2)
        {
            return ((searchSuplierPayRet1.CreateDateTime == searchSuplierPayRet2.CreateDateTime)
                 && (searchSuplierPayRet1.UpdateDateTime == searchSuplierPayRet2.UpdateDateTime)
                 && (searchSuplierPayRet1.EnterpriseCode == searchSuplierPayRet2.EnterpriseCode)
                 && (searchSuplierPayRet1.FileHeaderGuid == searchSuplierPayRet2.FileHeaderGuid)
                 && (searchSuplierPayRet1.UpdEmployeeCode == searchSuplierPayRet2.UpdEmployeeCode)
                 && (searchSuplierPayRet1.UpdAssemblyId1 == searchSuplierPayRet2.UpdAssemblyId1)
                 && (searchSuplierPayRet1.UpdAssemblyId2 == searchSuplierPayRet2.UpdAssemblyId2)
                 && (searchSuplierPayRet1.LogicalDeleteCode == searchSuplierPayRet2.LogicalDeleteCode)
                 && (searchSuplierPayRet1.AddUpSecCode == searchSuplierPayRet2.AddUpSecCode)
                // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                 //&& (searchSuplierPayRet1.CustomerCode == searchSuplierPayRet2.CustomerCode)
                 //&& (searchSuplierPayRet1.CustomerName == searchSuplierPayRet2.CustomerName)
                 //&& (searchSuplierPayRet1.CustomerName2 == searchSuplierPayRet2.CustomerName2)
                 //&& (searchSuplierPayRet1.CustomerSnm == searchSuplierPayRet2.CustomerSnm)
                 && (searchSuplierPayRet1.SupplierCode == searchSuplierPayRet2.SupplierCode)
                 && (searchSuplierPayRet1.SupplierName == searchSuplierPayRet2.SupplierName)
                 && (searchSuplierPayRet1.SupplierName2 == searchSuplierPayRet2.SupplierName2)
                 && (searchSuplierPayRet1.SupplierSnm == searchSuplierPayRet2.SupplierSnm)
                // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
                 && (searchSuplierPayRet1.PayeeCode == searchSuplierPayRet2.PayeeCode)
                 && (searchSuplierPayRet1.PayeeName == searchSuplierPayRet2.PayeeName)
                 && (searchSuplierPayRet1.PayeeName2 == searchSuplierPayRet2.PayeeName2)
                 && (searchSuplierPayRet1.PayeeSnm == searchSuplierPayRet2.PayeeSnm)
                 && (searchSuplierPayRet1.AddUpDate == searchSuplierPayRet2.AddUpDate)
                 && (searchSuplierPayRet1.AddUpYearMonth == searchSuplierPayRet2.AddUpYearMonth)
                 && (searchSuplierPayRet1.LastTimePayment == searchSuplierPayRet2.LastTimePayment)
                 && (searchSuplierPayRet1.ThisTimePayNrml == searchSuplierPayRet2.ThisTimePayNrml)
                 && (searchSuplierPayRet1.ThisTimeFeePayNrml == searchSuplierPayRet2.ThisTimeFeePayNrml)
                 && (searchSuplierPayRet1.ThisTimeDisPayNrml == searchSuplierPayRet2.ThisTimeDisPayNrml)
                /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
                && (searchSuplierPayRet1.ThisTimeRbtPayNrml == searchSuplierPayRet2.ThisTimeRbtPayNrml)
                   --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
                 && (searchSuplierPayRet1.ThisTimeTtlBlcPay == searchSuplierPayRet2.ThisTimeTtlBlcPay)
                 && (searchSuplierPayRet1.ThisNetStckPrice == searchSuplierPayRet2.ThisNetStckPrice)
                 && (searchSuplierPayRet1.ThisNetStcPrcTax == searchSuplierPayRet2.ThisNetStcPrcTax)
                 && (searchSuplierPayRet1.ItdedOffsetOutTax == searchSuplierPayRet2.ItdedOffsetOutTax)
                 && (searchSuplierPayRet1.ItdedOffsetInTax == searchSuplierPayRet2.ItdedOffsetInTax)
                 && (searchSuplierPayRet1.ItdedOffsetTaxFree == searchSuplierPayRet2.ItdedOffsetTaxFree)
                 && (searchSuplierPayRet1.OffsetOutTax == searchSuplierPayRet2.OffsetOutTax)
                 && (searchSuplierPayRet1.OffsetInTax == searchSuplierPayRet2.OffsetInTax)
                 && (searchSuplierPayRet1.ThisTimeStockPrice == searchSuplierPayRet2.ThisTimeStockPrice)
                 && (searchSuplierPayRet1.ThisStcPrcTax == searchSuplierPayRet2.ThisStcPrcTax)
                 && (searchSuplierPayRet1.TtlItdedStcOutTax == searchSuplierPayRet2.TtlItdedStcOutTax)
                 && (searchSuplierPayRet1.TtlItdedStcInTax == searchSuplierPayRet2.TtlItdedStcInTax)
                 && (searchSuplierPayRet1.TtlItdedStcTaxFree == searchSuplierPayRet2.TtlItdedStcTaxFree)
                 && (searchSuplierPayRet1.TtlStockOuterTax == searchSuplierPayRet2.TtlStockOuterTax)
                 && (searchSuplierPayRet1.TtlStockInnerTax == searchSuplierPayRet2.TtlStockInnerTax)
                 && (searchSuplierPayRet1.ThisStckPricRgds == searchSuplierPayRet2.ThisStckPricRgds)
                 && (searchSuplierPayRet1.ThisStcPrcTaxRgds == searchSuplierPayRet2.ThisStcPrcTaxRgds)
                 && (searchSuplierPayRet1.TtlItdedRetOutTax == searchSuplierPayRet2.TtlItdedRetOutTax)
                 && (searchSuplierPayRet1.TtlItdedRetInTax == searchSuplierPayRet2.TtlItdedRetInTax)
                 && (searchSuplierPayRet1.TtlItdedRetTaxFree == searchSuplierPayRet2.TtlItdedRetTaxFree)
                 && (searchSuplierPayRet1.TtlRetOuterTax == searchSuplierPayRet2.TtlRetOuterTax)
                 && (searchSuplierPayRet1.TtlRetInnerTax == searchSuplierPayRet2.TtlRetInnerTax)
                 && (searchSuplierPayRet1.SuppCTaxLayCd == searchSuplierPayRet2.SuppCTaxLayCd)
                 && (searchSuplierPayRet1.SupplierConsTaxRate == searchSuplierPayRet2.SupplierConsTaxRate)
                 && (searchSuplierPayRet1.FractionProcCd == searchSuplierPayRet2.FractionProcCd)
                 && (searchSuplierPayRet1.StockTotalPayBalance == searchSuplierPayRet2.StockTotalPayBalance)
                 && (searchSuplierPayRet1.StockTtl2TmBfBlPay == searchSuplierPayRet2.StockTtl2TmBfBlPay)
                 && (searchSuplierPayRet1.StockTtl3TmBfBlPay == searchSuplierPayRet2.StockTtl3TmBfBlPay)
                 && (searchSuplierPayRet1.CAddUpUpdExecDate == searchSuplierPayRet2.CAddUpUpdExecDate)
                 && (searchSuplierPayRet1.SupProcNum == searchSuplierPayRet2.SupProcNum)
                 && (searchSuplierPayRet1.StartCAddUpUpdDate == searchSuplierPayRet2.StartCAddUpUpdDate)
                 && (searchSuplierPayRet1.LastCAddUpUpdDate == searchSuplierPayRet2.LastCAddUpUpdDate)
                 && (searchSuplierPayRet1.StartDateSpan == searchSuplierPayRet2.StartDateSpan)
                 && (searchSuplierPayRet1.EndDateSpan == searchSuplierPayRet2.EndDateSpan)
                 && (searchSuplierPayRet1.ThisTimePaymentMeter == searchSuplierPayRet2.ThisTimePaymentMeter)
                 && (searchSuplierPayRet1.StcMtrAfOffset == searchSuplierPayRet2.StcMtrAfOffset)
                 && (searchSuplierPayRet1.StcConsTaxMtrAfOffset == searchSuplierPayRet2.StcConsTaxMtrAfOffset)
                 && (searchSuplierPayRet1.BlnceTtl == searchSuplierPayRet2.BlnceTtl)
                 && (searchSuplierPayRet1.Balance == searchSuplierPayRet2.Balance)
                 && (searchSuplierPayRet1.EnterpriseName == searchSuplierPayRet2.EnterpriseName)
                 && (searchSuplierPayRet1.UpdEmployeeName == searchSuplierPayRet2.UpdEmployeeName)
                 && (searchSuplierPayRet1.AddUpSecName == searchSuplierPayRet2.AddUpSecName)
                 && (searchSuplierPayRet1.SuppCTaxLayMethodNm == searchSuplierPayRet2.SuppCTaxLayMethodNm)
                 && (searchSuplierPayRet1.OfsThisTimeStock == searchSuplierPayRet2.OfsThisTimeStock)
                 && (searchSuplierPayRet1.OfsThisStockTax == searchSuplierPayRet2.OfsThisStockTax)
                 );
        }
        /// <summary>
        /// �����p�d����x�����z�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchSuplierPayRet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchSuplierPayRet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SearchSuplierPayRet target)
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
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            //if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            //if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            //if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SupplierCode != target.SupplierCode) resList.Add("SupplierCode");
            if (this.SupplierName != target.SupplierName) resList.Add("SupplierName");
            if (this.SupplierName2 != target.SupplierName2) resList.Add("SupplierName2");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            if (this.PayeeCode != target.PayeeCode) resList.Add("PayeeCode");
            if (this.PayeeName != target.PayeeName) resList.Add("PayeeName");
            if (this.PayeeName2 != target.PayeeName2) resList.Add("PayeeName2");
            if (this.PayeeSnm != target.PayeeSnm) resList.Add("PayeeSnm");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.LastTimePayment != target.LastTimePayment) resList.Add("LastTimePayment");
            if (this.ThisTimePayNrml != target.ThisTimePayNrml) resList.Add("ThisTimePayNrml");
            if (this.ThisTimeFeePayNrml != target.ThisTimeFeePayNrml) resList.Add("ThisTimeFeePayNrml");
            if (this.ThisTimeDisPayNrml != target.ThisTimeDisPayNrml) resList.Add("ThisTimeDisPayNrml");
            /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
            if (this.ThisTimeRbtPayNrml != target.ThisTimeRbtPayNrml) resList.Add("ThisTimeRbtPayNrml");
               --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            if (this.ThisTimeTtlBlcPay != target.ThisTimeTtlBlcPay) resList.Add("ThisTimeTtlBlcPay");
            if (this.ThisNetStckPrice != target.ThisNetStckPrice) resList.Add("ThisNetStckPrice");
            if (this.ThisNetStcPrcTax != target.ThisNetStcPrcTax) resList.Add("ThisNetStcPrcTax");
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
            if (this.SuppCTaxLayCd != target.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (this.SupplierConsTaxRate != target.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.StockTotalPayBalance != target.StockTotalPayBalance) resList.Add("StockTotalPayBalance");
            if (this.StockTtl2TmBfBlPay != target.StockTtl2TmBfBlPay) resList.Add("StockTtl2TmBfBlPay");
            if (this.StockTtl3TmBfBlPay != target.StockTtl3TmBfBlPay) resList.Add("StockTtl3TmBfBlPay");
            if (this.CAddUpUpdExecDate != target.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (this.SupProcNum != target.SupProcNum) resList.Add("SupProcNum");
            if (this.StartCAddUpUpdDate != target.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (this.LastCAddUpUpdDate != target.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (this.StartDateSpan != target.StartDateSpan) resList.Add("StartDateSpan");
            if (this.EndDateSpan != target.EndDateSpan) resList.Add("EndDateSpan");
            if (this.ThisTimePaymentMeter != target.ThisTimePaymentMeter) resList.Add("ThisTimePaymentMeter");
            if (this.StcMtrAfOffset != target.StcMtrAfOffset) resList.Add("StcMtrAfOffset");
            if (this.StcConsTaxMtrAfOffset != target.StcConsTaxMtrAfOffset) resList.Add("StcConsTaxMtrAfOffset");
            if (this.BlnceTtl != target.BlnceTtl) resList.Add("BlnceTtl");
            if (this.Balance != target.Balance) resList.Add("Balance");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            if (this.OfsThisTimeStock != target.OfsThisTimeStock) resList.Add("OfsThisTimeStock");
            if (this.OfsThisStockTax != target.OfsThisStockTax) resList.Add("OfsThisStockTax");

            return resList;
        }

        /// <summary>
        /// �����p�d����x�����z�N���X��r����
        /// </summary>
        /// <param name="searchSuplierPayRet1">��r����SearchSuplierPayRet�N���X�̃C���X�^���X</param>
        /// <param name="searchSuplierPayRet2">��r����SearchSuplierPayRet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchSuplierPayRet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SearchSuplierPayRet searchSuplierPayRet1, SearchSuplierPayRet searchSuplierPayRet2)
        {
            ArrayList resList = new ArrayList();
            if (searchSuplierPayRet1.CreateDateTime != searchSuplierPayRet2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchSuplierPayRet1.UpdateDateTime != searchSuplierPayRet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchSuplierPayRet1.EnterpriseCode != searchSuplierPayRet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchSuplierPayRet1.FileHeaderGuid != searchSuplierPayRet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchSuplierPayRet1.UpdEmployeeCode != searchSuplierPayRet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchSuplierPayRet1.UpdAssemblyId1 != searchSuplierPayRet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchSuplierPayRet1.UpdAssemblyId2 != searchSuplierPayRet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchSuplierPayRet1.LogicalDeleteCode != searchSuplierPayRet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchSuplierPayRet1.AddUpSecCode != searchSuplierPayRet2.AddUpSecCode) resList.Add("AddUpSecCode");
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //if (searchSuplierPayRet1.CustomerCode != searchSuplierPayRet2.CustomerCode) resList.Add("CustomerCode");
            //if (searchSuplierPayRet1.CustomerName != searchSuplierPayRet2.CustomerName) resList.Add("CustomerName");
            //if (searchSuplierPayRet1.CustomerName2 != searchSuplierPayRet2.CustomerName2) resList.Add("CustomerName2");
            //if (searchSuplierPayRet1.CustomerSnm != searchSuplierPayRet2.CustomerSnm) resList.Add("CustomerSnm");
            if (searchSuplierPayRet1.SupplierCode != searchSuplierPayRet2.SupplierCode) resList.Add("SupplierCode");
            if (searchSuplierPayRet1.SupplierName != searchSuplierPayRet2.SupplierName) resList.Add("SupplierName");
            if (searchSuplierPayRet1.SupplierName2 != searchSuplierPayRet2.SupplierName2) resList.Add("SupplierName2");
            if (searchSuplierPayRet1.SupplierSnm != searchSuplierPayRet2.SupplierSnm) resList.Add("SupplierSnm");
            // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
            if (searchSuplierPayRet1.PayeeCode != searchSuplierPayRet2.PayeeCode) resList.Add("PayeeCode");
            if (searchSuplierPayRet1.PayeeName != searchSuplierPayRet2.PayeeName) resList.Add("PayeeName");
            if (searchSuplierPayRet1.PayeeName2 != searchSuplierPayRet2.PayeeName2) resList.Add("PayeeName2");
            if (searchSuplierPayRet1.PayeeSnm != searchSuplierPayRet2.PayeeSnm) resList.Add("PayeeSnm");
            if (searchSuplierPayRet1.AddUpDate != searchSuplierPayRet2.AddUpDate) resList.Add("AddUpDate");
            if (searchSuplierPayRet1.AddUpYearMonth != searchSuplierPayRet2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (searchSuplierPayRet1.LastTimePayment != searchSuplierPayRet2.LastTimePayment) resList.Add("LastTimePayment");
            if (searchSuplierPayRet1.ThisTimePayNrml != searchSuplierPayRet2.ThisTimePayNrml) resList.Add("ThisTimePayNrml");
            if (searchSuplierPayRet1.ThisTimeFeePayNrml != searchSuplierPayRet2.ThisTimeFeePayNrml) resList.Add("ThisTimeFeePayNrml");
            if (searchSuplierPayRet1.ThisTimeDisPayNrml != searchSuplierPayRet2.ThisTimeDisPayNrml) resList.Add("ThisTimeDisPayNrml");
            /* --- DEL 2008/07/08 --------------------------------------------------------------------->>>>>
            if (searchSuplierPayRet1.ThisTimeRbtPayNrml != searchSuplierPayRet2.ThisTimeRbtPayNrml) resList.Add("ThisTimeRbtPayNrml");
               --- DEL 2008/07/08 ---------------------------------------------------------------------<<<<<*/
            if (searchSuplierPayRet1.ThisTimeTtlBlcPay != searchSuplierPayRet2.ThisTimeTtlBlcPay) resList.Add("ThisTimeTtlBlcPay");
            if (searchSuplierPayRet1.ThisNetStckPrice != searchSuplierPayRet2.ThisNetStckPrice) resList.Add("ThisNetStckPrice");
            if (searchSuplierPayRet1.ThisNetStcPrcTax != searchSuplierPayRet2.ThisNetStcPrcTax) resList.Add("ThisNetStcPrcTax");
            if (searchSuplierPayRet1.ItdedOffsetOutTax != searchSuplierPayRet2.ItdedOffsetOutTax) resList.Add("ItdedOffsetOutTax");
            if (searchSuplierPayRet1.ItdedOffsetInTax != searchSuplierPayRet2.ItdedOffsetInTax) resList.Add("ItdedOffsetInTax");
            if (searchSuplierPayRet1.ItdedOffsetTaxFree != searchSuplierPayRet2.ItdedOffsetTaxFree) resList.Add("ItdedOffsetTaxFree");
            if (searchSuplierPayRet1.OffsetOutTax != searchSuplierPayRet2.OffsetOutTax) resList.Add("OffsetOutTax");
            if (searchSuplierPayRet1.OffsetInTax != searchSuplierPayRet2.OffsetInTax) resList.Add("OffsetInTax");
            if (searchSuplierPayRet1.ThisTimeStockPrice != searchSuplierPayRet2.ThisTimeStockPrice) resList.Add("ThisTimeStockPrice");
            if (searchSuplierPayRet1.ThisStcPrcTax != searchSuplierPayRet2.ThisStcPrcTax) resList.Add("ThisStcPrcTax");
            if (searchSuplierPayRet1.TtlItdedStcOutTax != searchSuplierPayRet2.TtlItdedStcOutTax) resList.Add("TtlItdedStcOutTax");
            if (searchSuplierPayRet1.TtlItdedStcInTax != searchSuplierPayRet2.TtlItdedStcInTax) resList.Add("TtlItdedStcInTax");
            if (searchSuplierPayRet1.TtlItdedStcTaxFree != searchSuplierPayRet2.TtlItdedStcTaxFree) resList.Add("TtlItdedStcTaxFree");
            if (searchSuplierPayRet1.TtlStockOuterTax != searchSuplierPayRet2.TtlStockOuterTax) resList.Add("TtlStockOuterTax");
            if (searchSuplierPayRet1.TtlStockInnerTax != searchSuplierPayRet2.TtlStockInnerTax) resList.Add("TtlStockInnerTax");
            if (searchSuplierPayRet1.ThisStckPricRgds != searchSuplierPayRet2.ThisStckPricRgds) resList.Add("ThisStckPricRgds");
            if (searchSuplierPayRet1.ThisStcPrcTaxRgds != searchSuplierPayRet2.ThisStcPrcTaxRgds) resList.Add("ThisStcPrcTaxRgds");
            if (searchSuplierPayRet1.TtlItdedRetOutTax != searchSuplierPayRet2.TtlItdedRetOutTax) resList.Add("TtlItdedRetOutTax");
            if (searchSuplierPayRet1.TtlItdedRetInTax != searchSuplierPayRet2.TtlItdedRetInTax) resList.Add("TtlItdedRetInTax");
            if (searchSuplierPayRet1.TtlItdedRetTaxFree != searchSuplierPayRet2.TtlItdedRetTaxFree) resList.Add("TtlItdedRetTaxFree");
            if (searchSuplierPayRet1.TtlRetOuterTax != searchSuplierPayRet2.TtlRetOuterTax) resList.Add("TtlRetOuterTax");
            if (searchSuplierPayRet1.TtlRetInnerTax != searchSuplierPayRet2.TtlRetInnerTax) resList.Add("TtlRetInnerTax");
            if (searchSuplierPayRet1.SuppCTaxLayCd != searchSuplierPayRet2.SuppCTaxLayCd) resList.Add("SuppCTaxLayCd");
            if (searchSuplierPayRet1.SupplierConsTaxRate != searchSuplierPayRet2.SupplierConsTaxRate) resList.Add("SupplierConsTaxRate");
            if (searchSuplierPayRet1.FractionProcCd != searchSuplierPayRet2.FractionProcCd) resList.Add("FractionProcCd");
            if (searchSuplierPayRet1.StockTotalPayBalance != searchSuplierPayRet2.StockTotalPayBalance) resList.Add("StockTotalPayBalance");
            if (searchSuplierPayRet1.StockTtl2TmBfBlPay != searchSuplierPayRet2.StockTtl2TmBfBlPay) resList.Add("StockTtl2TmBfBlPay");
            if (searchSuplierPayRet1.StockTtl3TmBfBlPay != searchSuplierPayRet2.StockTtl3TmBfBlPay) resList.Add("StockTtl3TmBfBlPay");
            if (searchSuplierPayRet1.CAddUpUpdExecDate != searchSuplierPayRet2.CAddUpUpdExecDate) resList.Add("CAddUpUpdExecDate");
            if (searchSuplierPayRet1.SupProcNum != searchSuplierPayRet2.SupProcNum) resList.Add("SupProcNum");
            if (searchSuplierPayRet1.StartCAddUpUpdDate != searchSuplierPayRet2.StartCAddUpUpdDate) resList.Add("StartCAddUpUpdDate");
            if (searchSuplierPayRet1.LastCAddUpUpdDate != searchSuplierPayRet2.LastCAddUpUpdDate) resList.Add("LastCAddUpUpdDate");
            if (searchSuplierPayRet1.StartDateSpan != searchSuplierPayRet2.StartDateSpan) resList.Add("StartDateSpan");
            if (searchSuplierPayRet1.EndDateSpan != searchSuplierPayRet2.EndDateSpan) resList.Add("EndDateSpan");
            if (searchSuplierPayRet1.ThisTimePaymentMeter != searchSuplierPayRet2.ThisTimePaymentMeter) resList.Add("ThisTimePaymentMeter");
            if (searchSuplierPayRet1.StcMtrAfOffset != searchSuplierPayRet2.StcMtrAfOffset) resList.Add("StcMtrAfOffset");
            if (searchSuplierPayRet1.StcConsTaxMtrAfOffset != searchSuplierPayRet2.StcConsTaxMtrAfOffset) resList.Add("StcConsTaxMtrAfOffset");
            if (searchSuplierPayRet1.BlnceTtl != searchSuplierPayRet2.BlnceTtl) resList.Add("BlnceTtl");
            if (searchSuplierPayRet1.Balance != searchSuplierPayRet2.Balance) resList.Add("Balance");
            if (searchSuplierPayRet1.EnterpriseName != searchSuplierPayRet2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchSuplierPayRet1.UpdEmployeeName != searchSuplierPayRet2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchSuplierPayRet1.AddUpSecName != searchSuplierPayRet2.AddUpSecName) resList.Add("AddUpSecName");
            if (searchSuplierPayRet1.SuppCTaxLayMethodNm != searchSuplierPayRet2.SuppCTaxLayMethodNm) resList.Add("SuppCTaxLayMethodNm");
            if (searchSuplierPayRet1.OfsThisTimeStock != searchSuplierPayRet2.OfsThisTimeStock) resList.Add("OfsThisTimeStock");
            if (searchSuplierPayRet1.OfsThisStockTax != searchSuplierPayRet2.OfsThisStockTax) resList.Add("OfsThisStockTax");

            return resList;
        }
    }
}
