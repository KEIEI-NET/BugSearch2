using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEStockUpdSearch
    /// <summary>
    ///                      UOE���ɍX�V���������N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE���ɍX�V���������N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOEStockUpdSearch
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>���O�C�����_�R�[�h��ݒ�</remarks>
        private string _sectionCode = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�݌Ɉꊇ 1:�݌Ɉꊇ�ȊO</remarks>
        private Int32 _procDiv;

        /// <summary>UOE������R�[�h</summary>
        /// <remarks>��ʏ�̎d����R�[�h��ݒ�</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>��ʏ�̔[�i���ԍ���ݒ�</remarks>
        private string _slipNo = "";

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
        /// <value>���O�C�����_�R�[�h��ݒ�</value>
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

        /// public propaty name  :  ProcDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�݌Ɉꊇ 1:�݌Ɉꊇ�ȊO</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// <value>��ʏ�̎d����R�[�h��ݒ�</value>
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

        /// public propaty name  :  SlipNo
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// <value>��ʏ�̔[�i���ԍ���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
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
        /// UOE���ɍX�V���������N���X�R���X�g���N�^
        /// </summary>
        /// <returns>UOEStockUpdSearch�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearch�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEStockUpdSearch()
        {
        }

        /// <summary>
        /// UOE���ɍX�V���������N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h(���O�C�����_�R�[�h��ݒ�)</param>
        /// <param name="procDiv">�����敪(0:�݌Ɉꊇ 1:�݌Ɉꊇ�ȊO)</param>
        /// <param name="uOESupplierCd">UOE������R�[�h(��ʏ�̎d����R�[�h��ݒ�)</param>
        /// <param name="slipNo">�`�[�ԍ�(��ʏ�̔[�i���ԍ���ݒ�)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>UOEStockUpdSearch�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearch�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEStockUpdSearch(string enterpriseCode, string sectionCode, Int32 procDiv, Int32 uOESupplierCd, string slipNo, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._procDiv = procDiv;
            this._uOESupplierCd = uOESupplierCd;
            this._slipNo = slipNo;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// UOE���ɍX�V���������N���X��������
        /// </summary>
        /// <returns>UOEStockUpdSearch�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UOEStockUpdSearch�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEStockUpdSearch Clone()
        {
            return new UOEStockUpdSearch(this._enterpriseCode, this._sectionCode, this._procDiv, this._uOESupplierCd, this._slipNo, this._enterpriseName);
        }

        /// <summary>
        /// UOE���ɍX�V���������N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOEStockUpdSearch�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearch�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UOEStockUpdSearch target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.ProcDiv == target.ProcDiv)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.SlipNo == target.SlipNo)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// UOE���ɍX�V���������N���X��r����
        /// </summary>
        /// <param name="uOEStockUpdSearch1">
        ///                    ��r����UOEStockUpdSearch�N���X�̃C���X�^���X
        /// </param>
        /// <param name="uOEStockUpdSearch2">��r����UOEStockUpdSearch�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearch�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UOEStockUpdSearch uOEStockUpdSearch1, UOEStockUpdSearch uOEStockUpdSearch2)
        {
            return ((uOEStockUpdSearch1.EnterpriseCode == uOEStockUpdSearch2.EnterpriseCode)
                 && (uOEStockUpdSearch1.SectionCode == uOEStockUpdSearch2.SectionCode)
                 && (uOEStockUpdSearch1.ProcDiv == uOEStockUpdSearch2.ProcDiv)
                 && (uOEStockUpdSearch1.UOESupplierCd == uOEStockUpdSearch2.UOESupplierCd)
                 && (uOEStockUpdSearch1.SlipNo == uOEStockUpdSearch2.SlipNo)
                 && (uOEStockUpdSearch1.EnterpriseName == uOEStockUpdSearch2.EnterpriseName));
        }
        /// <summary>
        /// UOE���ɍX�V���������N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOEStockUpdSearch�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearch�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UOEStockUpdSearch target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.ProcDiv != target.ProcDiv) resList.Add("ProcDiv");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.SlipNo != target.SlipNo) resList.Add("SlipNo");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// UOE���ɍX�V���������N���X��r����
        /// </summary>
        /// <param name="uOEStockUpdSearch1">��r����UOEStockUpdSearch�N���X�̃C���X�^���X</param>
        /// <param name="uOEStockUpdSearch2">��r����UOEStockUpdSearch�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEStockUpdSearch�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UOEStockUpdSearch uOEStockUpdSearch1, UOEStockUpdSearch uOEStockUpdSearch2)
        {
            ArrayList resList = new ArrayList();
            if (uOEStockUpdSearch1.EnterpriseCode != uOEStockUpdSearch2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOEStockUpdSearch1.SectionCode != uOEStockUpdSearch2.SectionCode) resList.Add("SectionCode");
            if (uOEStockUpdSearch1.ProcDiv != uOEStockUpdSearch2.ProcDiv) resList.Add("ProcDiv");
            if (uOEStockUpdSearch1.UOESupplierCd != uOEStockUpdSearch2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOEStockUpdSearch1.SlipNo != uOEStockUpdSearch2.SlipNo) resList.Add("SlipNo");
            if (uOEStockUpdSearch1.EnterpriseName != uOEStockUpdSearch2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���������ݒ�N���X
    /// </summary>
    public class UOEEnterUpdCndtn
    {
        #region ��Private�萔
        private string _enterpriseCode;     // ��ƃR�[�h
        private Int32 _processDiv;          // �����敪
        private Int32 _supplierCd;          // �d����R�[�h
        private string _supplierName;       // �d���於��
        private Int32 _slipNo;              // �[�i��No.
        #endregion

        #region ��Property
        /// <summary> ��ƃR�[�h </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode;}
            set { this._enterpriseCode = value;}
        }
        /// <summary> �����敪 </summary>
        public Int32 ProcessDiv
        {
            get { return this._processDiv;}
            set { this._processDiv = value;}
        }
        /// <summary> �d����R�[�h </summary>
        public Int32 SupplierCd
        {
            get { return this._supplierCd;}
            set { this._supplierCd = value;}
        }
        /// <summary> �d���於�� </summary>
        public string SupplierName
        {
            get { return this._supplierName; }
            set { this._supplierName = value; }
        }
        /// <summary> �[�iNo. </summary>
        public Int32 SlipNo
        {
            get { return this._slipNo;}
            set { this._slipNo = value;}
        }
        #endregion
    }
}
*/