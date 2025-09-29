//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I���}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �I���}�X�^�i�G�N�X�|�[�g�j���s��
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
    /// public class name:   InventoryExportWork
    /// <summary>
    ///                      �I���}�X�^�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���}�X�^�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InventoryExportWork
    {
        # region �� private field ��
        /// <summary>�J�n�I���ʔԃR�[�h</summary>
        private int _inventorySeqNoSt;

        /// <summary>�I���I���ʔԃR�[�h</summary>
        private int _inventorySeqNoEd;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        # endregion  �� private field ��

        # region �� public propaty ��

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

        /// public propaty name  :  InventorySeqNoSt
        /// <summary>�J�n�I���ʔԃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�I���ʔԃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventorySeqNoSt
        {
            get { return _inventorySeqNoSt; }
            set { _inventorySeqNoSt = value; }
        }

        /// public propaty name  :  InventorySeqNoEd
        /// <summary>�I���I���ʔԃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���I���ʔԃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventorySeqNoEd
        {
            get { return _inventorySeqNoEd; }
            set { _inventorySeqNoEd = value; }
        }


        # endregion �� public propaty ��

        # region �� Constructor ��
        /// <summary>
        /// �I���}�X�^�i�G�N�X�|�[�g�j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>InventoryExportWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryExportWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventoryExportWork()
        {
        }
        # endregion �� Constructor ��

    }
}
