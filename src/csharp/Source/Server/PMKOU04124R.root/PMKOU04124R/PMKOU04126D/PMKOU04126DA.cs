using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SuppYearResultCndtnWork
    /// <summary>
    ///                      �d���N�Ԏ��яƉ�o�����N���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���N�Ԏ��яƉ�o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SuppYearResultCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���_�R�[�h�����ݒ莞�́u�S�Ёv</remarks>
        private string _sectionCode = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>���_�R�[�h�X�^�[�g</summary>
        private string _sectionCodeSt = "";

        /// <summary>���_�R�[�h�I��</summary>
        private string _sectionCodeEnd = "";

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
        /// �d���N�Ԏ��яƉ�o�����N���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SuppYearResultCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SuppYearResultCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SuppYearResultCndtnWork()
        {
        }

    }
}
