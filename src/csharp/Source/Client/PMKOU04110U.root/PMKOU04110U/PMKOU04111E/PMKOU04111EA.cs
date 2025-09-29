using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SuppYearResultCndtn
    /// <summary>
    ///                      �d���N�Ԏ��яƉ�o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���N�Ԏ��яƉ�o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SuppYearResultCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���_�R�[�h�����ݒ莞�́u�S�Ёv</remarks>
        private string _sectionCode = "";

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>���_�R�[�h�X�^�[�g</summary>
        private string _sectionCodeSt = "";

        /// <summary>���_�R�[�h�I��</summary>
        private string _sectionCodeEnd = "";
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>�d����R�[�h�X�^�[�g</summary>
        private Int32 _supplierCdSt;

        /// <summary>�d����R�[�h�I��</summary>
        private Int32 _supplierCdEnd;

        /// <summary>��ʋ敪</summary>
        private string _mainDiv;
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>���Z��敪</summary>
        /// <remarks>0:�e�A1:�q�@�@�q�̏ꍇ�ɂ͔��|�c���Ɖ�^�u�p�̍��ڂ͕Ԃ��Ȃ�</remarks>
        private Int32 _accDiv;

        /// <summary>�d�������(�N����)</summary>
        /// <remarks>YYYYMMDD �d����̍ŏI���N����</remarks>
        private DateTime _suppTotalDay;

        /// <summary>����N����</summary>
        /// <remarks>YYYYMMDD ���|�c���Ɖ�^�u�̓������ڗp</remarks>
        private DateTime _companyBiginDate;

        /// <summary>�����J�n�N���x</summary>
        /// <remarks>YYYYMM ���яƉ�^�u�Ŏg�p</remarks>
        private DateTime _this_YearMonth;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM ���ݏ������N����ݒ�</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>���В���(�N����)</summary>
        /// <remarks>YYYYMMDD ���Ђ̍ŏI���N����</remarks>
        private DateTime _secTotalDay;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���_�R�[�h�����ݒ莞�́u�S�Ёv</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  SectionCodeSt
        /// <summary>���_�R�[�h�X�^�[�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�X�^�[�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEnd
        /// <summary>���_�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEnd
        {
            get { return _sectionCodeEnd; }
            set { _sectionCodeEnd = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  SupplierCdSt
        /// <summary>�d����R�[�h�X�^�[�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�X�^�[�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEnd
        /// <summary>�d����R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdEnd
        {
            get { return _supplierCdEnd; }
            set { _supplierCdEnd = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// public propaty name  :  AccDiv
        /// <summary>���Z��敪�v���p�e�B</summary>
        /// <value>0:�e�A1:�q�@�@�q�̏ꍇ�ɂ͔��|�c���Ɖ�^�u�p�̍��ڂ͕Ԃ��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccDiv
        {
            get { return _accDiv; }
            set { _accDiv = value; }
        }

        /// public propaty name  :  SuppTotalDay
        /// <summary>�d�������(�N����)�v���p�e�B</summary>
        /// <value>YYYYMMDD �d����̍ŏI���N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������(�N����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SuppTotalDay
        {
            get { return _suppTotalDay; }
            set { _suppTotalDay = value; }
        }

        /// public propaty name  :  CompanyBiginDate
        /// <summary>����N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���|�c���Ɖ�^�u�̓������ڗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CompanyBiginDate
        {
            get { return _companyBiginDate; }
            set { _companyBiginDate = value; }
        }

        /// public propaty name  :  CompanyBiginDateJpFormal
        /// <summary>����N���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD ���|�c���Ɖ�^�u�̓������ڗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyBiginDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _companyBiginDate); }
            set { }
        }

        /// public propaty name  :  CompanyBiginDateJpInFormal
        /// <summary>����N���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD ���|�c���Ɖ�^�u�̓������ڗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyBiginDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _companyBiginDate); }
            set { }
        }

        /// public propaty name  :  CompanyBiginDateAdFormal
        /// <summary>����N���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD ���|�c���Ɖ�^�u�̓������ڗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyBiginDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _companyBiginDate); }
            set { }
        }

        /// public propaty name  :  CompanyBiginDateAdInFormal
        /// <summary>����N���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD ���|�c���Ɖ�^�u�̓������ڗp</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyBiginDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _companyBiginDate); }
            set { }
        }

        /// public propaty name  :  This_YearMonth
        /// <summary>�����J�n�N���x�v���p�e�B</summary>
        /// <value>YYYYMM ���яƉ�^�u�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����J�n�N���x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime This_YearMonth
        {
            get { return _this_YearMonth; }
            set { _this_YearMonth = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM ���ݏ������N����ݒ�</value>
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
        /// <value>YYYYMM ���ݏ������N����ݒ�</value>
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
        /// <value>YYYYMM ���ݏ������N����ݒ�</value>
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
        /// <value>YYYYMM ���ݏ������N����ݒ�</value>
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
        /// <value>YYYYMM ���ݏ������N����ݒ�</value>
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

        /// public propaty name  :  SecTotalDay
        /// <summary>���В���(�N����)�v���p�e�B</summary>
        /// <value>YYYYMMDD ���Ђ̍ŏI���N����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���В���(�N����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SecTotalDay
        {
            get { return _secTotalDay; }
            set { _secTotalDay = value; }
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

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// public propaty name  :  MainDiv
        /// <summary>��ʋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainDiv
        {
            get { return _mainDiv; }
            set { _mainDiv = value; }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>
        /// �d���N�Ԏ��яƉ�o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuppYearResultCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppYearResultCndtn()
        {
        }

        /// <summary>
        /// �d���N�Ԏ��яƉ�o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h(���_�R�[�h�����ݒ莞�́u�S�Ёv)</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="accDiv">���Z��敪(0:�e�A1:�q�@�@�q�̏ꍇ�ɂ͔��|�c���Ɖ�^�u�p�̍��ڂ͕Ԃ��Ȃ�)</param>
        /// <param name="suppTotalDay">�d�������(�N����)(YYYYMMDD �d����̍ŏI���N����)</param>
        /// <param name="companyBiginDate">����N����(YYYYMMDD ���|�c���Ɖ�^�u�̓������ڗp)</param>
        /// <param name="this_YearMonth">�����J�n�N���x(YYYYMM ���яƉ�^�u�Ŏg�p)</param>
        /// <param name="addUpYearMonth">�v��N��(YYYYMM ���ݏ������N����ݒ�)</param>
        /// <param name="secTotalDay">���В���(�N����)(YYYYMMDD ���Ђ̍ŏI���N����)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>SuppYearResultCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppYearResultCndtn(string enterpriseCode, string sectionCode, Int32 supplierCd, Int32 accDiv, DateTime suppTotalDay, DateTime companyBiginDate, DateTime this_YearMonth, DateTime addUpYearMonth, DateTime secTotalDay, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._supplierCd = supplierCd;
            this._accDiv = accDiv;
            this._suppTotalDay = suppTotalDay;
            this.CompanyBiginDate = companyBiginDate;
            this._this_YearMonth = this_YearMonth;
            this.AddUpYearMonth = addUpYearMonth;
            this._secTotalDay = secTotalDay;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// �d���N�Ԏ��яƉ�o�����N���X���[�N��������
        /// </summary>
        /// <returns>SuppYearResultCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SuppYearResultCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppYearResultCndtn Clone()
        {
            return new SuppYearResultCndtn(this._enterpriseCode, this._sectionCode, this._supplierCd, this._accDiv, this._suppTotalDay, this._companyBiginDate, this._this_YearMonth, this._addUpYearMonth, this._secTotalDay, this._enterpriseName);
        }

        /// <summary>
        /// �d���N�Ԏ��яƉ�o�����N���X���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SuppYearResultCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SuppYearResultCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.AccDiv == target.AccDiv)
                 && (this.SuppTotalDay == target.SuppTotalDay)
                 && (this.CompanyBiginDate == target.CompanyBiginDate)
                 && (this.This_YearMonth == target.This_YearMonth)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.SecTotalDay == target.SecTotalDay)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// �d���N�Ԏ��яƉ�o�����N���X���[�N��r����
        /// </summary>
        /// <param name="suppYearResultCndtn1">
        ///                    ��r����SuppYearResultCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="suppYearResultCndtn2">��r����SuppYearResultCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SuppYearResultCndtn suppYearResultCndtn1, SuppYearResultCndtn suppYearResultCndtn2)
        {
            return ((suppYearResultCndtn1.EnterpriseCode == suppYearResultCndtn2.EnterpriseCode)
                 && (suppYearResultCndtn1.SectionCode == suppYearResultCndtn2.SectionCode)
                 && (suppYearResultCndtn1.SupplierCd == suppYearResultCndtn2.SupplierCd)
                 && (suppYearResultCndtn1.AccDiv == suppYearResultCndtn2.AccDiv)
                 && (suppYearResultCndtn1.SuppTotalDay == suppYearResultCndtn2.SuppTotalDay)
                 && (suppYearResultCndtn1.CompanyBiginDate == suppYearResultCndtn2.CompanyBiginDate)
                 && (suppYearResultCndtn1.This_YearMonth == suppYearResultCndtn2.This_YearMonth)
                 && (suppYearResultCndtn1.AddUpYearMonth == suppYearResultCndtn2.AddUpYearMonth)
                 && (suppYearResultCndtn1.SecTotalDay == suppYearResultCndtn2.SecTotalDay)
                 && (suppYearResultCndtn1.EnterpriseName == suppYearResultCndtn2.EnterpriseName));
        }
        /// <summary>
        /// �d���N�Ԏ��яƉ�o�����N���X���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SuppYearResultCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SuppYearResultCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.AccDiv != target.AccDiv) resList.Add("AccDiv");
            if (this.SuppTotalDay != target.SuppTotalDay) resList.Add("SuppTotalDay");
            if (this.CompanyBiginDate != target.CompanyBiginDate) resList.Add("CompanyBiginDate");
            if (this.This_YearMonth != target.This_YearMonth) resList.Add("This_YearMonth");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.SecTotalDay != target.SecTotalDay) resList.Add("SecTotalDay");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// �d���N�Ԏ��яƉ�o�����N���X���[�N��r����
        /// </summary>
        /// <param name="suppYearResultCndtn1">��r����SuppYearResultCndtn�N���X�̃C���X�^���X</param>
        /// <param name="suppYearResultCndtn2">��r����SuppYearResultCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SuppYearResultCndtn suppYearResultCndtn1, SuppYearResultCndtn suppYearResultCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (suppYearResultCndtn1.EnterpriseCode != suppYearResultCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (suppYearResultCndtn1.SectionCode != suppYearResultCndtn2.SectionCode) resList.Add("SectionCode");
            if (suppYearResultCndtn1.SupplierCd != suppYearResultCndtn2.SupplierCd) resList.Add("SupplierCd");
            if (suppYearResultCndtn1.AccDiv != suppYearResultCndtn2.AccDiv) resList.Add("AccDiv");
            if (suppYearResultCndtn1.SuppTotalDay != suppYearResultCndtn2.SuppTotalDay) resList.Add("SuppTotalDay");
            if (suppYearResultCndtn1.CompanyBiginDate != suppYearResultCndtn2.CompanyBiginDate) resList.Add("CompanyBiginDate");
            if (suppYearResultCndtn1.This_YearMonth != suppYearResultCndtn2.This_YearMonth) resList.Add("This_YearMonth");
            if (suppYearResultCndtn1.AddUpYearMonth != suppYearResultCndtn2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (suppYearResultCndtn1.SecTotalDay != suppYearResultCndtn2.SecTotalDay) resList.Add("SecTotalDay");
            if (suppYearResultCndtn1.EnterpriseName != suppYearResultCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
