using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MenueStPrintWork
	/// <summary>
	///                      ���j���[����ݒ�i����j�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���j���[����ݒ�i����j�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2013/02/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class MenueStPrintWork 
    {
        # region �� private field ��

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�J�n�]�ƈ��R�[�h</summary>
        private string _employeeCodeSt;

        /// <summary>�I���]�ƈ��R�[�h</summary>
        private string _employeeCodeEd;

        /// <summary>�����</summary>
        private Int32 _sortCode;

        # endregion  �� private field ��

        # region �� public propaty ��
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

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>�J�n�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>�I���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  SortCode
        /// <summary>������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SortCode
        {
            get { return _sortCode; }
            set { _sortCode = value; }
        }
        # endregion �� public propaty ��

        # region �� Constructor ��
        /// <summary>
        /// ���j���[����ݒ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MenueStPrintWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeePrintWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MenueStPrintWork()
        {
        }
        # endregion �� Constructor ��
    }
}
