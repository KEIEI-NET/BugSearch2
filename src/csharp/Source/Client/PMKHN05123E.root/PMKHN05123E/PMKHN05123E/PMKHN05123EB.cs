//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��f�[�^�N���X(���Ӑ�R�[�h�A���Ӑ於��)
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(���Ӑ�R�[�h�A���Ӑ於��)
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class CustomerDispInfo
    {
        #region -- Member --

        /// <summary>�_���폜�t���O</summary>
        private int logicalDelete = 0;
        /// <summary>���Ӑ�R�[�h</summary>
        private int customerCd = 0;
        /// <summary>���Ӑ於</summary>
        private string customerNm = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�_���폜�t���O�v���p�e�B</summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        public int CustomerCode
        {
            get { return this.customerCd; }
            set { this.customerCd = value; }
        }

        /// <summary>���Ӑ於�v���p�e�B</summary>
        public string CustomerName
        {
            get { return this.customerNm; }
            set { this.customerNm = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(���Ӑ�R�[�h�A���Ӑ於��)�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A���Ӑ�}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(���Ӑ�R�[�h�A���Ӑ於��)�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks> 
        public CustomerDispInfo()
        {
            // �����Ȃ�
        }

        /// <summary>
        /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ���ʃf�[�^�]���N���X(���Ӑ�R�[�h�A���Ӑ於��)�R���X�g���N�^
        /// </summary>
        /// <param name="code">���Ӑ�R�[�h</param>
        /// <param name="name">���Ӑ於��</param>
        /// <param name="logicalDel">�_���폜�t���O</param>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A���Ӑ�}�X�^�R�[�h�ϊ���ʃf�[�^�]���N���X(���Ӑ�R�[�h�A���Ӑ於��)�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>  
        public CustomerDispInfo(int code, string name, int logicalDel)
        {
            this.CustomerCode = code;
            this.CustomerName = name;
            this.LogicalDelete = logicalDel;
        }

        #endregion
    }
}
