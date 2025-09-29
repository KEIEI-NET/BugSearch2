//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���Ӑ�}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerPrintWork
    /// <summary>
    ///                      ���Ӑ�}�X�^�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�}�X�^�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomerExportWork
    {
        # region �� private field ��
        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _customerCdSt;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _customerCdEd;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>�J�n���_�R�[�h</summary>
        private string _sectionCdSt;

        /// <summary>�I�����_�R�[�h</summary>
        private string _sectionCdEd;

        # endregion  �� private field ��

        # region �� public propaty ��
        /// public propaty name  :  CustomerCdSt
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCdSt
        {
            get { return _customerCdSt; }
            set { _customerCdSt = value; }
        }

        /// public propaty name  :  CustomerCdEd
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCdEd
        {
            get { return _customerCdEd; }
            set { _customerCdEd = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCdSt
        /// <summary>�J�n���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String SectionCdSt
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
        public String SectionCdEd
        {
            get { return _sectionCdEd; }
            set { _sectionCdEd = value; }
        }


        # endregion �� public propaty ��

        # region �� Constructor ��
        /// <summary>
        /// ���Ӑ�}�X�^�i�G�N�X�|�[�g�j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerExportWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerExportWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerExportWork()
        {
        }
        # endregion �� Constructor ��
    }
}
