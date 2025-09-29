//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[���@���_�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̋��_�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class SectionSearchWork
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

        /// <summary>
        /// �_���폜�t���O�v���p�e�B
        /// </summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>
        /// ���_�R�[�h(�J�n)�v���p�e�B
        /// </summary>
        public string SectionCd
        {
            get { return this.sectionCd; }
            set { this.sectionCd = value; }
        }

        /// <summary>
        /// ���_���̃v���p�e�B
        /// </summary>
        public string SectionNm
        {
            get { return this.sectionNm; }
            set { this.sectionNm = value; }
        }

        #endregion
    }
}
