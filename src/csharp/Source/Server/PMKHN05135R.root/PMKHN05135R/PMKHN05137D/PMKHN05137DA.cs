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
    public class SectionSearchParamWork
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterPriseCode = String.Empty;

        /// <summary>���_�R�[�h(�J�n)</summary>
        private string sectionStCd = String.Empty;

        /// <summary>���_�R�[�h(�I��)</summary>
        private string sectionEdCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// ��ƃR�[�h�v���p�e�B
        /// </summary>
        public string EnterPriseCode
        {
            get { return this.enterPriseCode; }
            set { this.enterPriseCode = value; }
        }

        /// <summary>
        /// ���_�R�[�h(�J�n)�v���p�e�B
        /// </summary>
        public string SectionStCd
        {
            get { return this.sectionStCd; }
            set { this.sectionStCd = value; }
        }

        /// <summary>
        /// ���_�R�[�h(�I��)�v���p�e�B
        /// </summary>
        public string SectionEdCd
        {
            get { return this.sectionEdCd; }
            set { this.sectionEdCd = value; }
        }

        #endregion
    }
}
