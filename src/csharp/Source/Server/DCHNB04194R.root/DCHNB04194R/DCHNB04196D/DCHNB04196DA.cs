using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesAnnualDataSelectParamWork
    /// <summary>
    ///                      ����N�Ԏ��яƉ�o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����N�Ԏ��яƉ�o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesAnnualDataSelectParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���_�R�[�h�����ݒ莞�́u�S�Ёv</remarks>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�S����/�󒍎�/���s�҃R�[�h</remarks>
        private string _employeeCode = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�W�v�敪</summary>
        /// <remarks>0:���_,1:���Ӑ�,2:�S����,3:�n��,4:�Ǝ�</remarks>
        private Int32 _totalDiv;

        /// <summary>�J�n�N��</summary>
        /// <remarks>YYYYMM �iex. �O���̊J�n�N���j</remarks>
        private Int32 _yearMonthSt;

        /// <summary>�I���N��</summary>
        /// <remarks>YYYYMM �iex. �����̓����N���j</remarks>
        private Int32 _yearMonthEd;

        /// <summary>���o�敪</summary>
        /// <remarks>0:�N�x����,1:�c��(����),2:�c��(���㓖���E����)</remarks>
        private Int32 _searchDiv;

        /// <summary>�]�ƈ��敪</summary>
        /// <remarks>10:�̔��S���� 20:��t�S���� 30:���͒S����</remarks>
        private Int32 _employeeDivCd;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�J�n�W�v�N����(���Ӑ�)</summary>
        /// <remarks>���Ӑ�O�����(�J�n)</remarks>
        private Int32 _stAddUpDate;

        /// <summary>�I���W�v�N����(���Ӑ�)</summary>
        /// <remarks>���Ӑ�O�����(�I��)</remarks>
        private Int32 _edAddUpDate;

        /// <summary>�W�v���Ӑ����(�N����)</summary>
        /// <remarks>���Ӑ捡�����(�I��)</remarks>
        private Int32 _custTotalDay;

        /// <summary>�J�n�W�v�N����(���_)</summary>
        /// <remarks>���_�O�����(�J�n)</remarks>
        private Int32 _stSecAddUpDate;

        /// <summary>�I���W�v�N����(���_)</summary>
        /// <remarks>���_�O�����(�I��)</remarks>
        private Int32 _edSecAddUpDate;

        /// <summary>�W�v���_����(�N����)</summary>
        /// <remarks>���_�������(�I��)</remarks>
        private Int32 _secTotalDay;

        /// <summary>�������_�R�[�h</summary>
        /// <remarks>���Ӑ搿�����_</remarks>
        private string _claimSectionCode = "";

        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// <summary>���_����</summary>
        private string _sectionName = string.Empty;

        /// <summary>selectionCode</summary>
        private string _selectionCode = string.Empty;

        /// <summary>selectionName</summary>
        private string _selectionName = string.Empty;
        // --- ADD 2010/08/02 --------------------------------<<<<<

        // ---------------------- ADD 2010/08/26 -------------->>>>>
        /// <summary>�J�nselectionName</summary>
        private string _st_selectionCode;

        /// <summary>�I��selectionName</summary>
        private string _ed_selectionCode;

        /// <summary>�����敪</summary>
        private Int32 _searDiv;

        /// <summary>���_�R�[�h���X�g</summary>
        private List<string[]> _sectionCodeList = new List<string[]>();
        // ---------------------- ADD 2010/08/26 ---------------<<<<<


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

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�S����/�󒍎�/���s�҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
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

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  TotalDiv
        /// <summary>�W�v�敪�v���p�e�B</summary>
        /// <value>0:���_,1:���Ӑ�,2:�S����,3:�n��,4:�Ǝ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDiv
        {
            get { return _totalDiv; }
            set { _totalDiv = value; }
        }

        /// public propaty name  :  YearMonthSt
        /// <summary>�J�n�N���v���p�e�B</summary>
        /// <value>YYYYMM �iex. �O���̊J�n�N���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 YearMonthSt
        {
            get { return _yearMonthSt; }
            set { _yearMonthSt = value; }
        }

        /// public propaty name  :  YearMonthEd
        /// <summary>�I���N���v���p�e�B</summary>
        /// <value>YYYYMM �iex. �����̓����N���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 YearMonthEd
        {
            get { return _yearMonthEd; }
            set { _yearMonthEd = value; }
        }

        /// public propaty name  :  SearchDiv
        /// <summary>���o�敪�v���p�e�B</summary>
        /// <value>0:�N�x����,1:�c��(����),2:�c��(���㓖���E����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

        /// public propaty name  :  EmployeeDivCd
        /// <summary>�]�ƈ��敪�v���p�e�B</summary>
        /// <value>10:�̔��S���� 20:��t�S���� 30:���͒S����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployeeDivCd
        {
            get { return _employeeDivCd; }
            set { _employeeDivCd = value; }
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

        /// public propaty name  :  StAddUpDate
        /// <summary>�J�n�W�v�N����(���Ӑ�)�v���p�e�B</summary>
        /// <value>���Ӑ�O�����(�J�n)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�W�v�N����(���Ӑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StAddUpDate
        {
            get { return _stAddUpDate; }
            set { _stAddUpDate = value; }
        }

        /// public propaty name  :  EdAddUpDate
        /// <summary>�I���W�v�N����(���Ӑ�)�v���p�e�B</summary>
        /// <value>���Ӑ�O�����(�I��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���W�v�N����(���Ӑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdAddUpDate
        {
            get { return _edAddUpDate; }
            set { _edAddUpDate = value; }
        }

        /// public propaty name  :  CustTotalDay
        /// <summary>�W�v���Ӑ����(�N����)�v���p�e�B</summary>
        /// <value>���Ӑ捡�����(�I��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v���Ӑ����(�N����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustTotalDay
        {
            get { return _custTotalDay; }
            set { _custTotalDay = value; }
        }

        /// public propaty name  :  StSecAddUpDate
        /// <summary>�J�n�W�v�N����(���_)�v���p�e�B</summary>
        /// <value>���_�O�����(�J�n)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�W�v�N����(���_)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StSecAddUpDate
        {
            get { return _stSecAddUpDate; }
            set { _stSecAddUpDate = value; }
        }

        /// public propaty name  :  EdSecAddUpDate
        /// <summary>�I���W�v�N����(���_)�v���p�e�B</summary>
        /// <value>���_�O�����(�I��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���W�v�N����(���_)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdSecAddUpDate
        {
            get { return _edSecAddUpDate; }
            set { _edSecAddUpDate = value; }
        }

        /// public propaty name  :  SecTotalDay
        /// <summary>�W�v���_����(�N����)�v���p�e�B</summary>
        /// <value>���_�������(�I��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v���_����(�N����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecTotalDay
        {
            get { return _secTotalDay; }
            set { _secTotalDay = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// <value>���Ӑ搿�����_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// public propaty name  :  _sectionName
        /// <summary>���_�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  SelectionCode
        /// <summary>SelectionCode�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SelectionCode�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelectionCode
        {
            get { return _selectionCode; }
            set { _selectionCode = value; }
        }

        /// public propaty name  :  SelectionName
        /// <summary>SelectionName�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SelectionName�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SelectionName
        {
            get { return _selectionName; }
            set { _selectionName = value; }
        }
        // --- ADD 2010/08/02 --------------------------------<<<<<

        // ---------------------- ADD 2010/08/26 --------------->>>>>
        /// public propaty name  :  St_SelectionCode
        /// <summary>�J�nSelectionCode�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nSelectionCode�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_SelectionCode
        {
            get { return _st_selectionCode; }
            set { _st_selectionCode = value; }
        }

        /// public propaty name  :  Ed_SelectionCode
        /// <summary>�I��SelectionCode�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��SelectionCode�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_SelectionCode
        {
            get { return _ed_selectionCode; }
            set { _ed_selectionCode = value; }
        }

        /// public propaty name  :  SearchDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearDiv
        {
            get { return _searDiv; }
            set { _searDiv = value; }
        }

        /// public propaty name  :  SectionCodeList
        /// <summary>���_�R�[�hList�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�hList�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string[]> SectionCodeList
        {
            get { return this._sectionCodeList; }
            set { this._sectionCodeList = value; }
        }
        // ---------------------- ADD 2010/08/26 ---------------<<<<<


        /// <summary>
        /// ����N�Ԏ��яƉ�o�����N���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalesAnnualDataSelectParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesAnnualDataSelectParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesAnnualDataSelectParamWork()
        {
        }

    }
}
