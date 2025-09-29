//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �]�ƈ��}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �]�ƈ��}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   EmployeeExportWork
    /// <summary>
    ///                      �]�ƈ��}�X�^�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �]�ƈ��}�X�^�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class EmployeeExportWork
    {
        # region �� private field ��
        /// <summary>�J�n���_�R�[�h</summary>
        private string _sectionCdSt = "";

        /// <summary>�I�����_�R�[�h</summary>
        private string _sectionCdEd = "";

        /// <summary>�J�n�S���҃R�[�h</summary>
        private string _employeeCdSt = "";

        /// <summary>�I���S���҃R�[�h</summary>
        private string _employeeCdEd = "";

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        # endregion  �� private field ��
        # region �� public propaty ��
        /// public propaty name  :  SectionCdSt
        /// <summary>�J�n���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCdSt
        {
            get { return _sectionCdSt; }
            set { _sectionCdSt = value; }
        }

        /// public propaty name  :  SectionCdEd
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCdEd
        {
            get { return _sectionCdEd; }
            set { _sectionCdEd = value; }
        }

        /// public propaty name  :  EmployeeCdSt
        /// <summary>�J�n�S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCdSt
        {
            get { return _employeeCdSt; }
            set { _employeeCdSt = value; }
        }

        /// public propaty name  :  EmployeeCdEd
        /// <summary>�I���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCdEd
        {
            get { return _employeeCdEd; }
            set { _employeeCdEd = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
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

        # endregion �� public propaty ��
        # region �� Constructor ��
        /// <summary>
        /// �]�ƈ��}�X�^�i�G�N�X�|�[�g�j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsPrintWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   EmployeeExportWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EmployeeExportWork()
        {
        }
        # endregion �� Constructor ��
    }
}
