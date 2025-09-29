using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustDmdPrcInfSearchParameter
    /// <summary>
    ///                      ���Ӑ挳�����o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ挳�����o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustDmdPrcInfSearchParameter
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h�i�����w��j</summary>
        /// <remarks>�i�z��j</remarks>
        private string[] _addUpSecCodeList;

        /// <summary>�J�n�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _startAddUpYearMonth;

        /// <summary>�I���v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _endAddUpYearMonth;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _startCustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _endCustomerCode;


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

        /// public propaty name  :  AddUpSecCodeList
        /// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i�z��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] AddUpSecCodeList
        {
            get { return _addUpSecCodeList; }
            set { _addUpSecCodeList = value; }
        }

        /// public propaty name  :  StartAddUpYearMonth
        /// <summary>�J�n�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StartAddUpYearMonth
        {
            get { return _startAddUpYearMonth; }
            set { _startAddUpYearMonth = value; }
        }

        /// public propaty name  :  EndAddUpYearMonth
        /// <summary>�I���v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EndAddUpYearMonth
        {
            get { return _endAddUpYearMonth; }
            set { _endAddUpYearMonth = value; }
        }

        /// public propaty name  :  StartCustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartCustomerCode
        {
            get { return _startCustomerCode; }
            set { _startCustomerCode = value; }
        }

        /// public propaty name  :  EndCustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndCustomerCode
        {
            get { return _endCustomerCode; }
            set { _endCustomerCode = value; }
        }


        /// <summary>
        /// ���Ӑ挳�����o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustDmdPrcInfSearchParameterWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustDmdPrcInfSearchParameterWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustDmdPrcInfSearchParameter()
        {
        }

    }
}
