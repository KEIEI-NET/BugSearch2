using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InpDisplay
    /// <summary>
    ///                      ��ʓ��̓N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��ʓ��̓N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InpDisplay
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_��</summary>
        private string _sectionName = "";

        /// <summary>�Ɩ��敪</summary>
        /// <remarks>1:���� 2:���� 3:�݌Ɋm�F</remarks>
        private Int32 _businessCode;

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</remarks>
        private Int32 _systemDivCd;

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE�����於��</summary>
        private string _uOESupplierName = "";

        /// <summary>UOE�[�i�敪</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>�[�i�敪����</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>�t�H���[�[�i�敪</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>�t�H���[�[�i�敪����</summary>
        private string _followDeliGoodsDivNm = "";

        /// <summary>UOE�w�苒�_</summary>
        private string _uOEResvdSection = "";

        /// <summary>UOE�w�苒�_����</summary>
        private string _uOEResvdSectionNm = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�˗��҃R�[�h</remarks>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        /// <remarks>�˗��Җ���</remarks>
        private string _employeeName = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�Ɩ��敪����</summary>
        private string _businessName = "";


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

        /// public propaty name  :  SectionName
        /// <summary>���_���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  BusinessCode
        /// <summary>�Ɩ��敪�v���p�e�B</summary>
        /// <value>1:���� 2:���� 3:�݌Ɋm�F</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
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

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>�t�H���[�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>�t�H���[�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDivNm
        {
            get { return _followDeliGoodsDivNm; }
            set { _followDeliGoodsDivNm = value; }
        }

        /// public propaty name  :  UOEResvdSection
        /// <summary>UOE�w�苒�_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>UOE�w�苒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�w�苒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEResvdSectionNm
        {
            get { return _uOEResvdSectionNm; }
            set { _uOEResvdSectionNm = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�˗��҃R�[�h</value>
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

        /// public propaty name  :  EmployeeName
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// <value>�˗��Җ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
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

        /// public propaty name  :  BusinessName
        /// <summary>�Ɩ��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ɩ��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessName
        {
            get { return _businessName; }
            set { _businessName = value; }
        }


        /// <summary>
        /// ��ʓ��̓N���X�R���X�g���N�^
        /// </summary>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay()
        {
        }

        /// <summary>
        /// ��ʓ��̓N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionName">���_��</param>
        /// <param name="businessCode">�Ɩ��敪(1:���� 2:���� 3:�݌Ɋm�F)</param>
        /// <param name="systemDivCd">�V�X�e���敪(0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[)</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="uOESupplierName">UOE�����於��</param>
        /// <param name="uOEDeliGoodsDiv">UOE�[�i�敪</param>
        /// <param name="deliveredGoodsDivNm">�[�i�敪����</param>
        /// <param name="followDeliGoodsDiv">�t�H���[�[�i�敪</param>
        /// <param name="followDeliGoodsDivNm">�t�H���[�[�i�敪����</param>
        /// <param name="uOEResvdSection">UOE�w�苒�_</param>
        /// <param name="uOEResvdSectionNm">UOE�w�苒�_����</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h(�˗��҃R�[�h)</param>
        /// <param name="employeeName">�]�ƈ�����(�˗��Җ���)</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="businessName">�Ɩ��敪����</param>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay(string enterpriseCode, string sectionCode, string sectionName, Int32 businessCode, Int32 systemDivCd, Int32 uOESupplierCd, string uOESupplierName, string uOEDeliGoodsDiv, string deliveredGoodsDivNm, string followDeliGoodsDiv, string followDeliGoodsDivNm, string uOEResvdSection, string uOEResvdSectionNm, string employeeCode, string employeeName, string uoeRemark1, string uoeRemark2, string enterpriseName, string businessName)
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._businessCode = businessCode;
            this._systemDivCd = systemDivCd;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._followDeliGoodsDivNm = followDeliGoodsDivNm;
            this._uOEResvdSection = uOEResvdSection;
            this._uOEResvdSectionNm = uOEResvdSectionNm;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._enterpriseName = enterpriseName;
            this._businessName = businessName;

        }

        /// <summary>
        /// ��ʓ��̓N���X��������
        /// </summary>
        /// <returns>InpDisplay�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����InpDisplay�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InpDisplay Clone()
        {
            return new InpDisplay(this._enterpriseCode, this._sectionCode, this._sectionName, this._businessCode, this._systemDivCd, this._uOESupplierCd, this._uOESupplierName, this._uOEDeliGoodsDiv, this._deliveredGoodsDivNm, this._followDeliGoodsDiv, this._followDeliGoodsDivNm, this._uOEResvdSection, this._uOEResvdSectionNm, this._employeeCode, this._employeeName, this._uoeRemark1, this._uoeRemark2, this._enterpriseName, this._businessName);
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(InpDisplay target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.BusinessCode == target.BusinessCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.FollowDeliGoodsDivNm == target.FollowDeliGoodsDivNm)
                 && (this.UOEResvdSection == target.UOEResvdSection)
                 && (this.UOEResvdSectionNm == target.UOEResvdSectionNm)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.BusinessName == target.BusinessName));
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="inpDisplay1">
        ///                    ��r����InpDisplay�N���X�̃C���X�^���X
        /// </param>
        /// <param name="inpDisplay2">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            return ((inpDisplay1.EnterpriseCode == inpDisplay2.EnterpriseCode)
                 && (inpDisplay1.SectionCode == inpDisplay2.SectionCode)
                 && (inpDisplay1.SectionName == inpDisplay2.SectionName)
                 && (inpDisplay1.BusinessCode == inpDisplay2.BusinessCode)
                 && (inpDisplay1.SystemDivCd == inpDisplay2.SystemDivCd)
                 && (inpDisplay1.UOESupplierCd == inpDisplay2.UOESupplierCd)
                 && (inpDisplay1.UOESupplierName == inpDisplay2.UOESupplierName)
                 && (inpDisplay1.UOEDeliGoodsDiv == inpDisplay2.UOEDeliGoodsDiv)
                 && (inpDisplay1.DeliveredGoodsDivNm == inpDisplay2.DeliveredGoodsDivNm)
                 && (inpDisplay1.FollowDeliGoodsDiv == inpDisplay2.FollowDeliGoodsDiv)
                 && (inpDisplay1.FollowDeliGoodsDivNm == inpDisplay2.FollowDeliGoodsDivNm)
                 && (inpDisplay1.UOEResvdSection == inpDisplay2.UOEResvdSection)
                 && (inpDisplay1.UOEResvdSectionNm == inpDisplay2.UOEResvdSectionNm)
                 && (inpDisplay1.EmployeeCode == inpDisplay2.EmployeeCode)
                 && (inpDisplay1.EmployeeName == inpDisplay2.EmployeeName)
                 && (inpDisplay1.UoeRemark1 == inpDisplay2.UoeRemark1)
                 && (inpDisplay1.UoeRemark2 == inpDisplay2.UoeRemark2)
                 && (inpDisplay1.EnterpriseName == inpDisplay2.EnterpriseName)
                 && (inpDisplay1.BusinessName == inpDisplay2.BusinessName));
        }
        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(InpDisplay target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.BusinessCode != target.BusinessCode) resList.Add("BusinessCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.FollowDeliGoodsDivNm != target.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (this.UOEResvdSection != target.UOEResvdSection) resList.Add("UOEResvdSection");
            if (this.UOEResvdSectionNm != target.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.BusinessName != target.BusinessName) resList.Add("BusinessName");

            return resList;
        }

        /// <summary>
        /// ��ʓ��̓N���X��r����
        /// </summary>
        /// <param name="inpDisplay1">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <param name="inpDisplay2">��r����InpDisplay�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InpDisplay�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(InpDisplay inpDisplay1, InpDisplay inpDisplay2)
        {
            ArrayList resList = new ArrayList();
            if (inpDisplay1.EnterpriseCode != inpDisplay2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (inpDisplay1.SectionCode != inpDisplay2.SectionCode) resList.Add("SectionCode");
            if (inpDisplay1.SectionName != inpDisplay2.SectionName) resList.Add("SectionName");
            if (inpDisplay1.BusinessCode != inpDisplay2.BusinessCode) resList.Add("BusinessCode");
            if (inpDisplay1.SystemDivCd != inpDisplay2.SystemDivCd) resList.Add("SystemDivCd");
            if (inpDisplay1.UOESupplierCd != inpDisplay2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (inpDisplay1.UOESupplierName != inpDisplay2.UOESupplierName) resList.Add("UOESupplierName");
            if (inpDisplay1.UOEDeliGoodsDiv != inpDisplay2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (inpDisplay1.DeliveredGoodsDivNm != inpDisplay2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (inpDisplay1.FollowDeliGoodsDiv != inpDisplay2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (inpDisplay1.FollowDeliGoodsDivNm != inpDisplay2.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (inpDisplay1.UOEResvdSection != inpDisplay2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (inpDisplay1.UOEResvdSectionNm != inpDisplay2.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (inpDisplay1.EmployeeCode != inpDisplay2.EmployeeCode) resList.Add("EmployeeCode");
            if (inpDisplay1.EmployeeName != inpDisplay2.EmployeeName) resList.Add("EmployeeName");
            if (inpDisplay1.UoeRemark1 != inpDisplay2.UoeRemark1) resList.Add("UoeRemark1");
            if (inpDisplay1.UoeRemark2 != inpDisplay2.UoeRemark2) resList.Add("UoeRemark2");
            if (inpDisplay1.EnterpriseName != inpDisplay2.EnterpriseName) resList.Add("EnterpriseName");
            if (inpDisplay1.BusinessName != inpDisplay2.BusinessName) resList.Add("BusinessName");

            return resList;
        }
    }
}
