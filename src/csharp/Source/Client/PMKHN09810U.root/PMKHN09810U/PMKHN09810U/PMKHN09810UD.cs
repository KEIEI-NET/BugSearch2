//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�C���|�[�g�E�G�N�X�|�[�g�t���[���N���X
// �v���O�����T�v   : �C���|�[�g�E�G�N�X�|�[�g���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �C���|�[�g�Ώۍ��ڐݒ�̃R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �C���|�[�g�ݒ�ɂĐݒ���e���R���g���[������N���X�ł��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// </remarks>
    [Serializable]
    public class SetUpControlInfo
    {
        #region �v���C�x�[�g�����o
        private string _fileName;
        private string _itemName;
        private int _itemId;
        private int _updateDiv = 0;
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SetUpControlInfo()
        {
        }
        #endregion

        #region �v���p�e�B
        /// <summary>�t�@�C����</summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>���ږ�</summary>
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        /// <summary>����ID</summary>
        public int ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        /// <summary>���ڍX�V�敪</summary>
        public int UpdateDiv
        {
            get { return _updateDiv; }
            set { _updateDiv = value; }
        }
        #endregion
    }
}
