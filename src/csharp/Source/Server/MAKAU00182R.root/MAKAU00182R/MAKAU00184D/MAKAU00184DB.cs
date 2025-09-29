using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CustAccRecInfSearchParameter
	/// <summary>
	///                      ���|���擾���o�����p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���|���擾���o�����p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    public class CustAccRecInfSearchParameter
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�v�㋒�_�R�[�h���X�g</summary>
        /// <remarks>���o�ΏۂƂȂ��Ă���v�㋒�_�R�[�h</remarks>
        private string[] _addUpSecCodeList;

        /// <summary>���Ӑ�R�[�h(�J�n)</summary>
        /// <remarks>CustomerCode���ݒ肳��Ă���ꍇ�͖���</remarks>
        private Int32 _startCustomerCode;

        /// <summary>���Ӑ�R�[�h(�I��)</summary>
        /// <remarks>CustomerCode���ݒ肳��Ă���ꍇ�͖���</remarks>
        private Int32 _endCustomerCode;

        /// <summary>�v��N���i�J�n�j</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _startAddUpYearMonth;

        /// <summary>�v��N���i�I���j</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _endAddUpYearMonth;

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

        /// public propaty name  :  AddUpSecCodet
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���o�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] AddUpSecCodeList
        {
            get { return _addUpSecCodeList; }
            set { _addUpSecCodeList = value; }
        }

        /// public propaty name  :  StartCustomerCode
        /// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
        /// <value>CustomerCode���ݒ肳��Ă���ꍇ�͖���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartCustomerCode
        {
            get { return _startCustomerCode; }
            set { _startCustomerCode = value; }
        }

        /// public propaty name  :  EndCustomerCode
        /// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        /// <value>CustomerCode���ݒ肳��Ă���ꍇ�͖���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndCustomerCode
        {
            get { return _endCustomerCode; }
            set { _endCustomerCode = value; }
        }

        /// public propaty name  :  StartAddUpYearMonth
        /// <summary>�v��N���i�J�n�j�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StartAddUpYearMonth
        {
            get { return _startAddUpYearMonth; }
            set { _startAddUpYearMonth = value; }
        }

        /// public propaty name  :  EndAddUpYearMonth
        /// <summary>�v��N���i�I���j�v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EndAddUpYearMonth
        {
            get { return _endAddUpYearMonth; }
            set { _endAddUpYearMonth = value; }
        }

        /// <summary>
        /// ���|���p���o�����p�����[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>CustAccRecInfSearchParameter�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustAccRecInfSearchParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustAccRecInfSearchParameter()
        {
        }
    }
}
