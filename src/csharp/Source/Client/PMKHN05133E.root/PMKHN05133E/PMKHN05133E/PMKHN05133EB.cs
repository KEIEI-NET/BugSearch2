//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ��f�[�^�N���X(���_�R�[�h�A���_����)
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@���_�R�[�h�ϊ���ʃf�[�^�N���X(���_�R�[�h�A���_����)
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̋��_�R�[�h�ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class SectionDispInfo
    {
        #region -- Member --

        /// <summary>�_���폜�t���O</summary>
        private int logicalDelete = 0;
        /// <summary>���_�R�[�h</summary>
        private string sectionCd = String.Empty;
        /// <summary>���_����</summary>
        private string sectionNm = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�_���폜�t���O�v���p�e�B</summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>���_�R�[�h�v���p�e�B</summary>
        public string SectionCode
        {
            get { return this.sectionCd; }
            set { this.sectionCd = value; }
        }

        /// <summary>���_����</summary>
        public string SectionName
        {
            get { return this.sectionNm; }
            set { this.sectionNm = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@���_�R�[�h�ϊ���ʃf�[�^�N���X(���_�R�[�h�A���_����)�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A���_�R�[�h�ϊ���ʃf�[�^�N���X(���_�R�[�h�A���_����)�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>   
        public SectionDispInfo()
        {
            // �����Ȃ�
        }

        /// <summary>
        /// PM.NS�����c�[���@���_�R�[�h�ϊ���ʃf�[�^�]���N���X(���_�R�[�h�A���_����)�R���X�g���N�^
        /// </summary>
        /// <param name="code">���_�R�[�h</param>
        /// <param name="name">���_����</param>
        /// <param name="logicalDel">�_���폜�t���O</param>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A���_�R�[�h�ϊ���ʃf�[�^�]���N���X(���_�R�[�h�A���_����)�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>   
        public SectionDispInfo(string code, string name, int logicalDel)
        {
            this.SectionCode = code;
            this.SectionName = name;
            this.logicalDelete = logicalDel;
        }

        #endregion
    }
}
