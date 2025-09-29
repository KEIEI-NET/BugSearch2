//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�ꊇ�C��
// �v���O�����T�v   �F���Ӑ�̕ύX���ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/11/27     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerCustomerChangeParam
    /// <summary>
    ///                      ���Ӑ�ꊇ�C�����o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�ꊇ�C�����o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomerCustomerChangeParam
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�J�n�Ǘ����_�R�[�h</summary>
        private string _stMngSectionCode = "";

        /// <summary>�I���Ǘ����_�R�[�h</summary>
        private string _edMngSectionCode = "";

        /// <summary>�J�n���Ӑ�</summary>
        private Int32 _stCustomerCode;

        /// <summary>�I�����Ӑ�</summary>
        private Int32 _edCustomerCode;

        /// <summary>�J�n�J�i</summary>
        private string _stKana = "";

        /// <summary>�I���J�i</summary>
        private string _edKana = "";

        /// <summary>�J�n�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _stCustomerAgentCd = "";

        /// <summary>�I���ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _edCustomerAgentCd = "";

        /// <summary>�J�n�̔��G���A�R�[�h</summary>
        private Int32 _stSalesAreaCode;

        /// <summary>�I���̔��G���A�R�[�h</summary>
        private Int32 _edSalesAreaCode;

        /// <summary>�J�n�Ǝ�R�[�h</summary>
        private Int32 _stBusinessTypeCode;

        /// <summary>�I���Ǝ�R�[�h</summary>
        private Int32 _edBusinessTypeCode;

        /// <summary>�����敪</summary>
        /// <remarks>0:���Ӑ�}�X�^�{�ϓ����@1���Ӑ�}�X�^+�ϓ����+�|��G</remarks>
        private Int32 _searchDiv;

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

        /// public propaty name  :  StMngSectionCode
        /// <summary>�J�n�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StMngSectionCode
        {
            get { return _stMngSectionCode; }
            set { _stMngSectionCode = value; }
        }

        /// public propaty name  :  EdMngSectionCode
        /// <summary>�I���Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdMngSectionCode
        {
            get { return _edMngSectionCode; }
            set { _edMngSectionCode = value; }
        }

        /// public propaty name  :  StCustomerCode
        /// <summary>�J�n���Ӑ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StCustomerCode
        {
            get { return _stCustomerCode; }
            set { _stCustomerCode = value; }
        }

        /// public propaty name  :  EdCustomerCode
        /// <summary>�I�����Ӑ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdCustomerCode
        {
            get { return _edCustomerCode; }
            set { _edCustomerCode = value; }
        }

        /// public propaty name  :  StKana
        /// <summary>�J�n�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StKana
        {
            get { return _stKana; }
            set { _stKana = value; }
        }

        /// public propaty name  :  EdKana
        /// <summary>�I���J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdKana
        {
            get { return _edKana; }
            set { _edKana = value; }
        }

        /// public propaty name  :  StCustomerAgentCd
        /// <summary>�J�n�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StCustomerAgentCd
        {
            get { return _stCustomerAgentCd; }
            set { _stCustomerAgentCd = value; }
        }

        /// public propaty name  :  EdCustomerAgentCd
        /// <summary>�I���ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdCustomerAgentCd
        {
            get { return _edCustomerAgentCd; }
            set { _edCustomerAgentCd = value; }
        }

        /// public propaty name  :  StSalesAreaCode
        /// <summary>�J�n�̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StSalesAreaCode
        {
            get { return _stSalesAreaCode; }
            set { _stSalesAreaCode = value; }
        }

        /// public propaty name  :  EdSalesAreaCode
        /// <summary>�I���̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdSalesAreaCode
        {
            get { return _edSalesAreaCode; }
            set { _edSalesAreaCode = value; }
        }

        /// public propaty name  :  StBusinessTypeCode
        /// <summary>�J�n�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StBusinessTypeCode
        {
            get { return _stBusinessTypeCode; }
            set { _stBusinessTypeCode = value; }
        }

        /// public propaty name  :  EdBusinessTypeCode
        /// <summary>�I���Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdBusinessTypeCode
        {
            get { return _edBusinessTypeCode; }
            set { _edBusinessTypeCode = value; }
        }

        /// public propaty name  :  SearchDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�}�X�^�{�ϓ����@1���Ӑ�}�X�^+�ϓ����+�|��G</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
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
        /// ���Ӑ�ꊇ�C�����o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerCustomerChangeParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerCustomerChangeParam()
        {
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C�����o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="stMngSectionCode">�J�n�Ǘ����_�R�[�h</param>
        /// <param name="edMngSectionCode">�I���Ǘ����_�R�[�h</param>
        /// <param name="stCustomerCode">�J�n���Ӑ�</param>
        /// <param name="edCustomerCode">�I�����Ӑ�</param>
        /// <param name="stKana">�J�n�J�i</param>
        /// <param name="edKana">�I���J�i</param>
        /// <param name="stCustomerAgentCd">�J�n�ڋq�S���]�ƈ��R�[�h(�����^)</param>
        /// <param name="edCustomerAgentCd">�I���ڋq�S���]�ƈ��R�[�h(�����^)</param>
        /// <param name="stSalesAreaCode">�J�n�̔��G���A�R�[�h</param>
        /// <param name="edSalesAreaCode">�I���̔��G���A�R�[�h</param>
        /// <param name="stBusinessTypeCode">�J�n�Ǝ�R�[�h</param>
        /// <param name="edBusinessTypeCode">�I���Ǝ�R�[�h</param>
        /// <param name="searchDiv">�����敪(0:���Ӑ�}�X�^�{�ϓ����@1���Ӑ�}�X�^+�ϓ����+�|��G)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>CustomerCustomerChangeParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerCustomerChangeParam(string enterpriseCode, string stMngSectionCode, string edMngSectionCode, Int32 stCustomerCode, Int32 edCustomerCode, string stKana, string edKana, string stCustomerAgentCd, string edCustomerAgentCd, Int32 stSalesAreaCode, Int32 edSalesAreaCode, Int32 stBusinessTypeCode, Int32 edBusinessTypeCode, Int32 searchDiv, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._stMngSectionCode = stMngSectionCode;
            this._edMngSectionCode = edMngSectionCode;
            this._stCustomerCode = stCustomerCode;
            this._edCustomerCode = edCustomerCode;
            this._stKana = stKana;
            this._edKana = edKana;
            this._stCustomerAgentCd = stCustomerAgentCd;
            this._edCustomerAgentCd = edCustomerAgentCd;
            this._stSalesAreaCode = stSalesAreaCode;
            this._edSalesAreaCode = edSalesAreaCode;
            this._stBusinessTypeCode = stBusinessTypeCode;
            this._edBusinessTypeCode = edBusinessTypeCode;
            this._searchDiv = searchDiv;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// ���Ӑ�ꊇ�C�����o�����N���X���[�N��������
        /// </summary>
        /// <returns>CustomerCustomerChangeParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomerCustomerChangeParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerCustomerChangeParam Clone()
        {
            return new CustomerCustomerChangeParam(this._enterpriseCode, this._stMngSectionCode, this._edMngSectionCode, this._stCustomerCode, this._edCustomerCode, this._stKana, this._edKana, this._stCustomerAgentCd, this._edCustomerAgentCd, this._stSalesAreaCode, this._edSalesAreaCode, this._stBusinessTypeCode, this._edBusinessTypeCode, this._searchDiv, this._enterpriseName);
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C�����o�����N���X���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomerCustomerChangeParam�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeParam�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustomerCustomerChangeParam target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.StMngSectionCode == target.StMngSectionCode)
                 && (this.EdMngSectionCode == target.EdMngSectionCode)
                 && (this.StCustomerCode == target.StCustomerCode)
                 && (this.EdCustomerCode == target.EdCustomerCode)
                 && (this.StKana == target.StKana)
                 && (this.EdKana == target.EdKana)
                 && (this.StCustomerAgentCd == target.StCustomerAgentCd)
                 && (this.EdCustomerAgentCd == target.EdCustomerAgentCd)
                 && (this.StSalesAreaCode == target.StSalesAreaCode)
                 && (this.EdSalesAreaCode == target.EdSalesAreaCode)
                 && (this.StBusinessTypeCode == target.StBusinessTypeCode)
                 && (this.EdBusinessTypeCode == target.EdBusinessTypeCode)
                 && (this.SearchDiv == target.SearchDiv)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C�����o�����N���X���[�N��r����
        /// </summary>
        /// <param name="customerCustomerChangeParam1">
        ///                    ��r����CustomerCustomerChangeParam�N���X�̃C���X�^���X
        /// </param>
        /// <param name="customerCustomerChangeParam2">��r����CustomerCustomerChangeParam�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeParam�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustomerCustomerChangeParam customerCustomerChangeParam1, CustomerCustomerChangeParam customerCustomerChangeParam2)
        {
            return ((customerCustomerChangeParam1.EnterpriseCode == customerCustomerChangeParam2.EnterpriseCode)
                 && (customerCustomerChangeParam1.StMngSectionCode == customerCustomerChangeParam2.StMngSectionCode)
                 && (customerCustomerChangeParam1.EdMngSectionCode == customerCustomerChangeParam2.EdMngSectionCode)
                 && (customerCustomerChangeParam1.StCustomerCode == customerCustomerChangeParam2.StCustomerCode)
                 && (customerCustomerChangeParam1.EdCustomerCode == customerCustomerChangeParam2.EdCustomerCode)
                 && (customerCustomerChangeParam1.StKana == customerCustomerChangeParam2.StKana)
                 && (customerCustomerChangeParam1.EdKana == customerCustomerChangeParam2.EdKana)
                 && (customerCustomerChangeParam1.StCustomerAgentCd == customerCustomerChangeParam2.StCustomerAgentCd)
                 && (customerCustomerChangeParam1.EdCustomerAgentCd == customerCustomerChangeParam2.EdCustomerAgentCd)
                 && (customerCustomerChangeParam1.StSalesAreaCode == customerCustomerChangeParam2.StSalesAreaCode)
                 && (customerCustomerChangeParam1.EdSalesAreaCode == customerCustomerChangeParam2.EdSalesAreaCode)
                 && (customerCustomerChangeParam1.StBusinessTypeCode == customerCustomerChangeParam2.StBusinessTypeCode)
                 && (customerCustomerChangeParam1.EdBusinessTypeCode == customerCustomerChangeParam2.EdBusinessTypeCode)
                 && (customerCustomerChangeParam1.SearchDiv == customerCustomerChangeParam2.SearchDiv)
                 && (customerCustomerChangeParam1.EnterpriseName == customerCustomerChangeParam2.EnterpriseName));
        }
        /// <summary>
        /// ���Ӑ�ꊇ�C�����o�����N���X���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomerCustomerChangeParam�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustomerCustomerChangeParam target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.StMngSectionCode != target.StMngSectionCode) resList.Add("StMngSectionCode");
            if (this.EdMngSectionCode != target.EdMngSectionCode) resList.Add("EdMngSectionCode");
            if (this.StCustomerCode != target.StCustomerCode) resList.Add("StCustomerCode");
            if (this.EdCustomerCode != target.EdCustomerCode) resList.Add("EdCustomerCode");
            if (this.StKana != target.StKana) resList.Add("StKana");
            if (this.EdKana != target.EdKana) resList.Add("EdKana");
            if (this.StCustomerAgentCd != target.StCustomerAgentCd) resList.Add("StCustomerAgentCd");
            if (this.EdCustomerAgentCd != target.EdCustomerAgentCd) resList.Add("EdCustomerAgentCd");
            if (this.StSalesAreaCode != target.StSalesAreaCode) resList.Add("StSalesAreaCode");
            if (this.EdSalesAreaCode != target.EdSalesAreaCode) resList.Add("EdSalesAreaCode");
            if (this.StBusinessTypeCode != target.StBusinessTypeCode) resList.Add("StBusinessTypeCode");
            if (this.EdBusinessTypeCode != target.EdBusinessTypeCode) resList.Add("EdBusinessTypeCode");
            if (this.SearchDiv != target.SearchDiv) resList.Add("SearchDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C�����o�����N���X���[�N��r����
        /// </summary>
        /// <param name="customerCustomerChangeParam1">��r����CustomerCustomerChangeParam�N���X�̃C���X�^���X</param>
        /// <param name="customerCustomerChangeParam2">��r����CustomerCustomerChangeParam�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustomerCustomerChangeParam customerCustomerChangeParam1, CustomerCustomerChangeParam customerCustomerChangeParam2)
        {
            ArrayList resList = new ArrayList();
            if (customerCustomerChangeParam1.EnterpriseCode != customerCustomerChangeParam2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (customerCustomerChangeParam1.StMngSectionCode != customerCustomerChangeParam2.StMngSectionCode) resList.Add("StMngSectionCode");
            if (customerCustomerChangeParam1.EdMngSectionCode != customerCustomerChangeParam2.EdMngSectionCode) resList.Add("EdMngSectionCode");
            if (customerCustomerChangeParam1.StCustomerCode != customerCustomerChangeParam2.StCustomerCode) resList.Add("StCustomerCode");
            if (customerCustomerChangeParam1.EdCustomerCode != customerCustomerChangeParam2.EdCustomerCode) resList.Add("EdCustomerCode");
            if (customerCustomerChangeParam1.StKana != customerCustomerChangeParam2.StKana) resList.Add("StKana");
            if (customerCustomerChangeParam1.EdKana != customerCustomerChangeParam2.EdKana) resList.Add("EdKana");
            if (customerCustomerChangeParam1.StCustomerAgentCd != customerCustomerChangeParam2.StCustomerAgentCd) resList.Add("StCustomerAgentCd");
            if (customerCustomerChangeParam1.EdCustomerAgentCd != customerCustomerChangeParam2.EdCustomerAgentCd) resList.Add("EdCustomerAgentCd");
            if (customerCustomerChangeParam1.StSalesAreaCode != customerCustomerChangeParam2.StSalesAreaCode) resList.Add("StSalesAreaCode");
            if (customerCustomerChangeParam1.EdSalesAreaCode != customerCustomerChangeParam2.EdSalesAreaCode) resList.Add("EdSalesAreaCode");
            if (customerCustomerChangeParam1.StBusinessTypeCode != customerCustomerChangeParam2.StBusinessTypeCode) resList.Add("StBusinessTypeCode");
            if (customerCustomerChangeParam1.EdBusinessTypeCode != customerCustomerChangeParam2.EdBusinessTypeCode) resList.Add("EdBusinessTypeCode");
            if (customerCustomerChangeParam1.SearchDiv != customerCustomerChangeParam2.SearchDiv) resList.Add("SearchDiv");
            if (customerCustomerChangeParam1.EnterpriseName != customerCustomerChangeParam2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
