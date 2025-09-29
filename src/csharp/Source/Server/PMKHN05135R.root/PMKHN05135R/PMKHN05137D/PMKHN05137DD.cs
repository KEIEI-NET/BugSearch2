//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
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
    /// PM.NS�����c�[���@���_�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̋��_�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class SectionConvertPrmWork
    {
        #region -- Member --

        /// <summary>�ϊ��O���_�R�[�h</summary>
        private string bfSectionCode = String.Empty;
        /// <summary>�ϊ��㋒�_�R�[�h</summary>
        private string afSectionCode = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// �ύX�O���_�R�[�h
        /// </summary>
        public string BfSectionCode
        {
            get { return this.bfSectionCode; }
            set { this.bfSectionCode = value; }
        }

        /// <summary>
        /// �ύX�㋒�_�R�[�h
        /// </summary>
        public string AfSectionCode
        {
            get { return this.afSectionCode; }
            set { this.afSectionCode = value; }
        }

        #endregion
    }
}
