//****************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ��R�[�h�ύX���ێ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//========================================================================================//
// ����
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@���_�R�[�h�ϊ���ʕύX���ێ��f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̋��_�R�[�h�ϊ���ʕύX���ێ��f�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class SectionConvertData
    {
        #region -- Member --

        /// <summary>�ϊ��O���_�R�[�h</summary>
        private string bfsectionCd = String.Empty;
        /// <summary>�ϊ��㋒�_�R�[�h</summary>
        private string afsectionCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�ύX�O���_�R�[�h</summary>
        public string BfSectionCd
        {
            get { return this.bfsectionCd; }
            set { this.bfsectionCd = value; }
        }

        /// <summary>�ύX�㋒�_�R�[�h</summary>
        public string AfSectionCd
        {
            get { return this.afsectionCd; }
            set { this.afsectionCd = value; }
        }

        #endregion
    }
}
