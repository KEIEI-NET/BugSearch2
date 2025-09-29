using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesReportOrderCndtn
    /// <summary>
    ///                      ���㑬��\�����o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���㑬��\�����o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SalesReportOrderCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>������t�i�J�n�j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_SalesDate;

        /// <summary>������t�i�I���j</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_SalesDate;

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

        /// public propaty name  :  St_SalesDate
        /// <summary>������t�i�J�n�j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>������t�i�I���j�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
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
        /// ���㑬��\�����o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SalesReportOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesReportOrderCndtn()
        {
        }

        /// <summary>
        /// ���㑬��\�����o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="st_SalesDate">������t�i�J�n�j(YYYYMMDD)</param>
        /// <param name="ed_SalesDate">������t�i�I���j(YYYYMMDD)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>SalesReportOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesReportOrderCndtn(string enterpriseCode, string sectionCode, Int32 st_SalesDate, Int32 ed_SalesDate, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._st_SalesDate = st_SalesDate;
            this._ed_SalesDate = ed_SalesDate;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// ���㑬��\�����o�����N���X��������
        /// </summary>
        /// <returns>SalesReportOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesReportOrderCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesReportOrderCndtn Clone()
        {
            return new SalesReportOrderCndtn(this._enterpriseCode, this._sectionCode, this._st_SalesDate, this._ed_SalesDate, this._enterpriseName);
        }

        /// <summary>
        /// ���㑬��\�����o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesReportOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SalesReportOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.St_SalesDate == target.St_SalesDate)
                 && (this.Ed_SalesDate == target.Ed_SalesDate)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// ���㑬��\�����o�����N���X��r����
        /// </summary>
        /// <param name="salesReportOrderCndtn1">
        ///                    ��r����SalesReportOrderCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesReportOrderCndtn2">��r����SalesReportOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SalesReportOrderCndtn salesReportOrderCndtn1, SalesReportOrderCndtn salesReportOrderCndtn2)
        {
            return ((salesReportOrderCndtn1.EnterpriseCode == salesReportOrderCndtn2.EnterpriseCode)
                 && (salesReportOrderCndtn1.SectionCode == salesReportOrderCndtn2.SectionCode)
                 && (salesReportOrderCndtn1.St_SalesDate == salesReportOrderCndtn2.St_SalesDate)
                 && (salesReportOrderCndtn1.Ed_SalesDate == salesReportOrderCndtn2.Ed_SalesDate)
                 && (salesReportOrderCndtn1.EnterpriseName == salesReportOrderCndtn2.EnterpriseName));
        }
        /// <summary>
        /// ���㑬��\�����o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SalesReportOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportOrderCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SalesReportOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.St_SalesDate != target.St_SalesDate) resList.Add("St_SalesDate");
            if (this.Ed_SalesDate != target.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// ���㑬��\�����o�����N���X��r����
        /// </summary>
        /// <param name="salesReportOrderCndtn1">��r����SalesReportOrderCndtn�N���X�̃C���X�^���X</param>
        /// <param name="salesReportOrderCndtn2">��r����SalesReportOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesReportOrderCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SalesReportOrderCndtn salesReportOrderCndtn1, SalesReportOrderCndtn salesReportOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (salesReportOrderCndtn1.EnterpriseCode != salesReportOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesReportOrderCndtn1.SectionCode != salesReportOrderCndtn2.SectionCode) resList.Add("SectionCode");
            if (salesReportOrderCndtn1.St_SalesDate != salesReportOrderCndtn2.St_SalesDate) resList.Add("St_SalesDate");
            if (salesReportOrderCndtn1.Ed_SalesDate != salesReportOrderCndtn2.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (salesReportOrderCndtn1.EnterpriseName != salesReportOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
