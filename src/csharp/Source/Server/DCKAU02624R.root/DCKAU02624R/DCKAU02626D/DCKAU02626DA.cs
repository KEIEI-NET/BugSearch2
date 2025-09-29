using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_AccRecConsTaxDiffWork
    /// <summary>
    ///                      ���|����ō��ٕ\���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���|����ō��ٕ\���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_AccRecConsTaxDiffWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�o�͑Ώۋ��_</summary>
        /// <remarks>null�̏ꍇ�͑S���_</remarks>
        private String[] _secCodeList;

        /// <summary>�J�n�v���</summary>
        private Int32 _st_SalesDate;

        /// <summary>�I���v���</summary>
        private Int32 _ed_SalesDate;


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

        /// public propaty name  :  SecCodeList
        /// <summary>�o�͑Ώۋ��_�v���p�e�B</summary>
        /// <value>null�̏ꍇ�͑S���_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͑Ώۋ��_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String[] SecCodeList
        {
            get { return _secCodeList; }
            set { _secCodeList = value; }
        }

        /// public propaty name  :  St_SalesDate
        /// <summary>�J�n�v����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>�I���v����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }


        /// <summary>
        /// ���|����ō��ٕ\���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_AccRecConsTaxDiffWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_AccRecConsTaxDiffWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_AccRecConsTaxDiffWork()
        {
        }

    }
}
