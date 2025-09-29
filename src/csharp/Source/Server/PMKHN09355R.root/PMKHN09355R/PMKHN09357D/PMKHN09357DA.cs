using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CustomerCustomerChangeParamWork
	/// <summary>
	///                      ���Ӑ�ꊇ�C�����o�����N���X���[�N���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�ꊇ�C�����o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustomerCustomerChangeParamWork 
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


        /// <summary>
        /// ���Ӑ�ꊇ�C�����o�����N���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerCustomerChangeParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerCustomerChangeParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerCustomerChangeParamWork()
        {
        }
    }
}
