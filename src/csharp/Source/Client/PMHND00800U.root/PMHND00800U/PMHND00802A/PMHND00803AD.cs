//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : HT�v���O������������
// �v���O�����T�v   : HT�v���O�������������t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370104-00 �쐬�S�� : �X�R�@�_
// �� �� ��  2017/12/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �o�[�W�������N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�[�W�������N���X�̒�`�Ǝ���</br>
    /// <br>Programmer : �X�R�@�_</br>
    /// <br>Date       : 2017/12/22</br>
    /// </remarks>
    public class PMHND00803AD
    {

        #region << private�ϐ� >>

        /// <summary>
        /// �t�@�C����
        /// </summary>
        public string fileName;

        /// <summary>
        /// �X�V���t
        /// </summary>
        public DateTime changeDateTime;

        #endregion

        /// public propaty name  :  FileName
        /// <summary>�t�@�C����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// public propaty name  :  ChangeDateTime
        /// <summary>�X�V���t</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���t</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ChangeDateTime
        {
            get { return changeDateTime; }
            set { changeDateTime = value; }
        }

    }
}
