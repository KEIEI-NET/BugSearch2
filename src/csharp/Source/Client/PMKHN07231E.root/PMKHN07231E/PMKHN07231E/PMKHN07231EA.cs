//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_���}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���_���}�X�^�i�G�N�X�|�[�g�j���s��
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
    /// public class name:   SecExportSetWork
    /// <summary>
    ///                      ���_���}�X�^�i�G�N�X�|�[�g�j�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���_���}�X�^�i�G�N�X�|�[�g�j�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SecExportSetWork
    {
        # region �� private field ��
        /// <summary>�J�n���_�R�[�h</summary>
        private string _sectionCodeSt = "";

        /// <summary>�I�����_�R�[�h</summary>
        private string _sectionCodeEd = "";

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        # endregion  �� private field ��

        # region �� public propaty ��
        /// public propaty name  :  SectionCodeSt
        /// <summary>�J�n���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
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
        /// ���_���}�X�^�i�G�N�X�|�[�g�j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
        /// <returns>SecExportSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecExportSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SecExportSetWork()
		{
		}
        # endregion �� Constructor ��
    }
}
