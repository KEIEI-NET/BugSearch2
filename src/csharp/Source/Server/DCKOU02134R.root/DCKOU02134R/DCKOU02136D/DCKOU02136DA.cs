using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StcRetGdsSlipTtlExtraWork
    /// <summary>
    ///                      �d���ԕi�`�[(�ӕ�)���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���ԕi�`�[(�ӕ�)���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StcRetGdsSlipTtlExtraWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�z��ŕ������_�w��@�S���_�̏ꍇ�͔z��0</remarks>
        private string[] _sectionCode;

        /// <summary>�d���v����t(�J�n)</summary>
        /// <remarks>�����͎��� 0</remarks>
        private Int32 _stockAddUpADateSt;

        /// <summary>�d���v����t(�I��)</summary>
        /// <remarks>�����͎��� 0</remarks>
        private Int32 _stockAddUpADateEd;

        /// <summary>�d���`�[�ԍ�(�J�n)</summary>
        /// <remarks>�����͎��� 0</remarks>
        private Int32 _supplierSlipNoSt;

        /// <summary>�d���`�[�ԍ�(�I��)</summary>
        /// <remarks>�����͎��� 0</remarks>
        private Int32 _supplierSlipNoEd;

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�����͎��� 0</remarks>
        private Int32 _supplierCd;

        /// <summary>�d�����͎҃R�[�h</summary>
        /// <remarks>�����͎��͋󕶎�("")</remarks>
        private string _stockInputName = "";


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
        /// <value>�z��ŕ������_�w��@�S���_�̏ꍇ�͔z��0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  StockAddUpADateSt
        /// <summary>�d���v����t(�J�n)�v���p�e�B</summary>
        /// <value>�����͎��� 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockAddUpADateSt
        {
            get { return _stockAddUpADateSt; }
            set { _stockAddUpADateSt = value; }
        }

        /// public propaty name  :  StockAddUpADateEd
        /// <summary>�d���v����t(�I��)�v���p�e�B</summary>
        /// <value>�����͎��� 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���v����t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockAddUpADateEd
        {
            get { return _stockAddUpADateEd; }
            set { _stockAddUpADateEd = value; }
        }

        /// public propaty name  :  SupplierSlipNoSt
        /// <summary>�d���`�[�ԍ�(�J�n)�v���p�e�B</summary>
        /// <value>�����͎��� 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNoSt
        {
            get { return _supplierSlipNoSt; }
            set { _supplierSlipNoSt = value; }
        }

        /// public propaty name  :  SupplierSlipNoEd
        /// <summary>�d���`�[�ԍ�(�I��)�v���p�e�B</summary>
        /// <value>�����͎��� 0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNoEd
        {
            get { return _supplierSlipNoEd; }
            set { _supplierSlipNoEd = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�����͎��� 0</value>
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

        /// public propaty name  :  StockInputName
        /// <summary>�d�����͎҃R�[�h�v���p�e�B</summary>
        /// <value>�����͎��͋󕶎�("")</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockInputName
        {
            get { return _stockInputName; }
            set { _stockInputName = value; }
        }


        /// <summary>
        /// �d���ԕi�`�[(�ӕ�)���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StcRetGdsSlipTtlExtraWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StcRetGdsSlipTtlExtraWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StcRetGdsSlipTtlExtraWork()
        {
        }

    }
}