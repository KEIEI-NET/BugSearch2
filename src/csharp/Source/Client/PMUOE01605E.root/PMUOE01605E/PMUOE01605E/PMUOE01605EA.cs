using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SlipNoAlwcData
    /// <summary>
    ///                      �`�[�ԍ����������N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �`�[�ԍ����������N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2009/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/19  ����</br>
    /// <br>                 :   ���敪�ύX</br>
    /// <br>                 :   1:����P���@2:���㌴���@3:�d���P�� 4:�艿 5:��ƌ��� 6:��Ɣ���</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   1:�����ݒ�,2:�����ݒ�,3:���i�ݒ�,4:��ƌ���,5:��Ɣ���</br>
    /// </remarks>
    public class SlipNoAlwcData
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>UOE������R�[�h</summary>
        private Int32 _supplierCode;

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>�񓚕ۑ��t�H���_</summary>
        private string _answerSaveFolder = "";

        /// <summary>�S���҃R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�S���Җ���</summary>
        private string _employeeName = "";

        /// <summary>�����X�V</summary>
        private Int32 _priceUpdateCode;

        /// <summary>�d���f�[�^�쐬�敪</summary>
        private Int32 _stockDataCode;

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

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }

        /// public propaty name  :  AnswerSaveFolder
        /// <summary>�񓚕ۑ��t�H���_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕ۑ��t�H���_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnswerSaveFolder
        {
            get { return _answerSaveFolder; }
            set { _answerSaveFolder = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>�S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  PriceUpdateCode
        /// <summary>�����X�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����X�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceUpdateCode
        {
            get { return _priceUpdateCode; }
            set { _priceUpdateCode = value; }
        }

        /// public propaty name  :  StockDataCode
        /// <summary>�d���f�[�^�쐬�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���f�[�^�쐬�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDataCode
        {
            get { return _stockDataCode; }
            set { _stockDataCode = value; }
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


        /// <summary>
        /// �`�[�ԍ����������N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SlipNoAlwcData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipNoAlwcData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipNoAlwcData()
        {
        }

        /// <summary>
        /// �`�[�ԍ����������N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCode">������R�[�h</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESupplierName">UOE�����於��</param>
        /// <param name="answerSaveFolder">�񓚕ۑ��t�H���_</param>
        /// <param name="employeeCode">�S���҃R�[�h</param>
        /// <param name="employeeName">�S���Җ���</param>
        /// <param name="priceUpdateCode">�����X�V</param>
        /// <param name="stockDataCode">�d���f�[�^�쐬�敪</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>SlipNoAlwcData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipNoAlwcData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipNoAlwcData(string enterpriseCode, string sectionCode,Int32 supplierCode, Int32 uOESupplierCd, string uOESupplierName, string answerSaveFolder, string employeeCode, string employeeName, Int32 priceUpdateCode, Int32 stockDataCode, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._supplierCode = supplierCode;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._answerSaveFolder = answerSaveFolder;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._priceUpdateCode = priceUpdateCode;
            this._stockDataCode = stockDataCode;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// �`�[�ԍ����������N���X��������
        /// </summary>
        /// <returns>SlipNoAlwcData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SlipNoAlwcData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipNoAlwcData Clone()
        {
            return new SlipNoAlwcData(this._enterpriseCode, this._sectionCode, this._supplierCode, this._uOESupplierCd, this._uOESupplierName, this._answerSaveFolder, this._employeeCode, this._employeeName, this._priceUpdateCode, this._stockDataCode, this._enterpriseName);
        }

        /// <summary>
        /// �`�[�ԍ����������N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SlipNoAlwcData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipNoAlwcData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SlipNoAlwcData target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SupplierCode == target.SupplierCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.AnswerSaveFolder == target.AnswerSaveFolder)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.PriceUpdateCode == target.PriceUpdateCode)
                 && (this.StockDataCode == target.StockDataCode)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// �`�[�ԍ����������N���X��r����
        /// </summary>
        /// <param name="slipNoAlwcData1">
        ///                    ��r����SlipNoAlwcData�N���X�̃C���X�^���X
        /// </param>
        /// <param name="slipNoAlwcData2">��r����SlipNoAlwcData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipNoAlwcData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SlipNoAlwcData slipNoAlwcData1, SlipNoAlwcData slipNoAlwcData2)
        {
            return ((slipNoAlwcData1.EnterpriseCode == slipNoAlwcData2.EnterpriseCode)
                 && (slipNoAlwcData1.SectionCode == slipNoAlwcData2.SectionCode)
                 && (slipNoAlwcData1.SupplierCode == slipNoAlwcData2.SupplierCode)
                 && (slipNoAlwcData1.UOESupplierCd == slipNoAlwcData2.UOESupplierCd)
                 && (slipNoAlwcData1.UOESupplierName == slipNoAlwcData2.UOESupplierName)
                 && (slipNoAlwcData1.AnswerSaveFolder == slipNoAlwcData2.AnswerSaveFolder)
                 && (slipNoAlwcData1.EmployeeCode == slipNoAlwcData2.EmployeeCode)
                 && (slipNoAlwcData1.EmployeeName == slipNoAlwcData2.EmployeeName)
                 && (slipNoAlwcData1.PriceUpdateCode == slipNoAlwcData2.PriceUpdateCode)
                 && (slipNoAlwcData1.StockDataCode == slipNoAlwcData2.StockDataCode)
                 && (slipNoAlwcData1.EnterpriseName == slipNoAlwcData2.EnterpriseName));
        }
        /// <summary>
        /// �`�[�ԍ����������N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SlipNoAlwcData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipNoAlwcData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SlipNoAlwcData target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SupplierCode != target.SupplierCode) resList.Add("SupplierCode");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.AnswerSaveFolder != target.AnswerSaveFolder) resList.Add("AnswerSaveFolder");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.PriceUpdateCode != target.PriceUpdateCode) resList.Add("PriceUpdateCode");
            if (this.StockDataCode != target.StockDataCode) resList.Add("StockDataCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// �`�[�ԍ����������N���X��r����
        /// </summary>
        /// <param name="slipNoAlwcData1">��r����SlipNoAlwcData�N���X�̃C���X�^���X</param>
        /// <param name="slipNoAlwcData2">��r����SlipNoAlwcData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SlipNoAlwcData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SlipNoAlwcData slipNoAlwcData1, SlipNoAlwcData slipNoAlwcData2)
        {
            ArrayList resList = new ArrayList();
            if (slipNoAlwcData1.EnterpriseCode != slipNoAlwcData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (slipNoAlwcData1.SectionCode != slipNoAlwcData2.SectionCode) resList.Add("SectionCode");
            if (slipNoAlwcData1.SupplierCode != slipNoAlwcData2.SupplierCode) resList.Add("SupplierCode");
            if (slipNoAlwcData1.UOESupplierCd != slipNoAlwcData2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (slipNoAlwcData1.UOESupplierName != slipNoAlwcData2.UOESupplierName) resList.Add("UOESupplierName");
            if (slipNoAlwcData1.AnswerSaveFolder != slipNoAlwcData2.AnswerSaveFolder) resList.Add("AnswerSaveFolder");
            if (slipNoAlwcData1.EmployeeCode != slipNoAlwcData2.EmployeeCode) resList.Add("EmployeeCode");
            if (slipNoAlwcData1.EmployeeName != slipNoAlwcData2.EmployeeName) resList.Add("EmployeeName");
            if (slipNoAlwcData1.PriceUpdateCode != slipNoAlwcData2.PriceUpdateCode) resList.Add("PriceUpdateCode");
            if (slipNoAlwcData1.StockDataCode != slipNoAlwcData2.StockDataCode) resList.Add("StockDataCode");
            if (slipNoAlwcData1.EnterpriseName != slipNoAlwcData2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}