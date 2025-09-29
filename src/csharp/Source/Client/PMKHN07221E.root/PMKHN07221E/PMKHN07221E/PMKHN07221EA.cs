//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �q�Ƀ}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �q�Ƀ}�X�^�i�G�N�X�|�[�g�j���s��
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
    /// public class name:   WarehouseExportWork
    /// <summary>
    ///                      �q�Ƀ}�X�^�i�G�N�X�|�[�g�j�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �q�Ƀ}�X�^�i�G�N�X�|�[�g�j�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/05/12  </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class WarehouseExportWork
    {
        # region �� private field ��
        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _warehouseCdSt = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _warehouseCdEd = "";

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        # endregion  �� private field ��

        # region �� public propaty ��
        /// public propaty name  :  WarehouseCdSt
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCdSt
        {
            get { return _warehouseCdSt; }
            set { _warehouseCdSt = value; }
        }

        /// public propaty name  :  WarehouseCdEd
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCdEd
        {
            get { return _warehouseCdEd; }
            set { _warehouseCdEd = value; }
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
        /// �q�Ƀ}�X�^�i�G�N�X�|�[�g�j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>WarehouseExportWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   WarehouseExportWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public WarehouseExportWork()
        {
        }
        # endregion �� Constructor ��
    }
}
